using Evaluacion_II.Enums;

namespace Evaluacion_II.Champions;
[Serializable]
public class Champion
{
    public string Name { get; set; }
    public float CurrentHealth { get; set; }
    public BaseStats Stats { get; set; }
    public Role PrimaryRole { get; set; }

    public Champion()
    {
        CurrentHealth = this.Stats.MaxHealth;
    }

    public Champion(string name, BaseStats stats, Role primaryRole)
    {
        Name = name;
        Stats = stats;
        CurrentHealth = Stats.MaxHealth;
        PrimaryRole = primaryRole;
    }
    public void AutoAttack(Champion target, ref bool isCritical)
    {
        float attackBaseDamage  = isCritical ? this.Stats.AttackDamage * this.Stats.CriticalRate : this.Stats.AttackDamage;
        float targetBaseDefense = Math.Clamp(target.Stats.Armor - this.Stats.ArmorPenetration, 0.0f, float.PositiveInfinity);
        
        // adicionar daño bonus de los items
        // adicionar defensa bonus de los items

        float battleDamage = Math.Clamp(attackBaseDamage - targetBaseDefense, 0.0f, float.PositiveInfinity);
        target.ReceiveDamage(battleDamage);

    }

    public void ReceiveDamage(float battleDamage)
    {
        this.CurrentHealth -= battleDamage;
        Console.WriteLine($"{this.Name} received {battleDamage} damage. HP: {this.CurrentHealth}/{this.Stats.MaxHealth}");
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Basic Stats: \n{this.Stats}");
    }
}

