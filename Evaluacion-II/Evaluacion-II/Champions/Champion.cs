using Evaluacion_II.Enums;
using Evaluacion_II.Items;

namespace Evaluacion_II.Champions;
[Serializable]
public class Champion
{
    public string Name { get; set; }
    public float CurrentHealth { get; set; }
    public BaseStats Stats { get; set; }
    public Role PrimaryRole { get; set; }
    
    public List<Item> inventory { get; set; }

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
        this.inventory = new List<Item>() { new Weapon("Trinity's Force", 33.3f, 
            33.3f, 0.33f, 1.033f) };
    }
    public void AutoAttack(Champion target, AttackType attackType, ref bool isCritical)
    {
        float effectiveCritRate = this.Stats.CriticalRate;
        foreach (Item item in this.inventory)
        {
            if (item is Weapon) effectiveCritRate += ((item as Weapon)!).BonusCriticalRate;
        }

        float effectiveAttackDmg = this.Stats.AttackDamage;
        foreach (Item item in inventory)
        {
            if (item is Weapon) effectiveAttackDmg += (item as Weapon)!.BonusDamage;
        }

        if (isCritical)
        {
            Console.WriteLine("El golpe es critico!");
            effectiveAttackDmg *= effectiveCritRate;
        }

        float effectiveTargetDefense = target.Stats.Armor - this.Stats.ArmorPenetration;
        
        // todo: adicionar defensa bonus de los items
        float battleDamage = Math.Clamp(effectiveAttackDmg - effectiveTargetDefense, min: 0.0f, max: float.MaxValue);
        target.ReceiveDamage(battleDamage);

    }

    public bool IsAlive()
    {
        return this.CurrentHealth > 0.0f;
    }

    public void ReceiveDamage(float battleDamage)
    {
        if (CurrentHealth <= battleDamage) 
            CurrentHealth = 0f;
        else
            this.CurrentHealth -= battleDamage;
        
        Console.WriteLine($"{this.Name} recibio {battleDamage} daño. HP: {this.CurrentHealth.ToString("0.##")}/{this.Stats.MaxHealth}");
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Basic Stats: \n{this.Stats}");
    }
}

