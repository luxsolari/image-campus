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
        this.inventory = new List<Item>() { new Weapon("Trinity's Force", 333f, 
            333f, 0.33f, 0.033f) };
    }
    public void AutoAttack(Champion target, AttackType attackType, ref bool isCritical)
    {
        float bonusCriticalRate = 0.0f;
        foreach (Item item in this.inventory)
        {
            if (item is Weapon) bonusCriticalRate += ((item as Weapon)!).BonusCriticalRate;
        }
        float attackBaseDamage  = isCritical ? this.Stats.AttackDamage * (this.Stats.CriticalRate + bonusCriticalRate): 
            this.Stats.AttackDamage;
        float targetBaseDefense = target.Stats.Armor - this.Stats.ArmorPenetration;
        
        if (isCritical) 
            Console.WriteLine("El golpe es critico!");
        // adicionar daño bonus de los items
        // adicionar defensa bonus de los items

        float battleDamage = attackBaseDamage - targetBaseDefense;
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
        
        Console.WriteLine($"{this.Name} received {battleDamage} damage. HP: {this.CurrentHealth}/{this.Stats.MaxHealth}");
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Basic Stats: \n{this.Stats}");
    }
}

