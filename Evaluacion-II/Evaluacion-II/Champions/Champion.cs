using Evaluacion_II.Enums;
using Evaluacion_II.Items;

namespace Evaluacion_II.Champions;
[Serializable]
public class Champion
{
    public string Name { get; set; }
    public float CurrentHealth { get; set; }
    public BaseStats Stats { get; set; }
    public Role Role { get; set; }
    public List<Item> Inventory { get; set; } = new List<Item>();
    public bool IsChargingAttack { get; set; }

    public Champion()
    {
        CurrentHealth = this.Stats.MaxHealth;
    }

    public Champion(string name, BaseStats stats, Role role)
    {
        Name = name;
        Stats = stats;
        CurrentHealth = Stats.MaxHealth;
        Role = role;
    }
    public void AutoAttack(Champion target, AttackType attackType, ref bool isCritical)
    {
        float attackerEffectiveAD = Stats.AttackDamage;
        float attackerEffectiveAP = Stats.AbilityPower;
        float attackerEffectiveCritRate = this.Stats.CriticalRate;
        float targetEffectiveArmor = target.Stats.Armor;
        float targetEffectiveMR = target.Stats.MagicResist;

        foreach (Item item in this.Inventory)
        {
            if (item is Weapon weapon)
            {
                attackerEffectiveAD += weapon.BonusDamage;
                attackerEffectiveAP += weapon.BonusAbilityPower;
                attackerEffectiveCritRate += weapon.BonusCriticalRate;
            }
        }
        
        foreach (Item item in target.Inventory)
        {
            if (item is Armor armor)
            {
                targetEffectiveArmor += armor.BonusArmor;
                targetEffectiveMR    += armor.BonusMagicResist;
            }
        }

        bool magicDamage = attackerEffectiveAD <= attackerEffectiveAP;

        if (attackType == AttackType.Fast)
            attackerEffectiveCritRate *= 0.70f;
        
        if (this.Stats.CriticalChance > 0f && isCritical)
        {
            if (magicDamage) attackerEffectiveAP *= attackerEffectiveCritRate;
            attackerEffectiveAD *= attackerEffectiveCritRate;
        }

        targetEffectiveArmor = Math.Clamp(targetEffectiveArmor - (attackerEffectiveAD * 0.2f), 0.0f, float.PositiveInfinity);
        targetEffectiveMR    = Math.Clamp(targetEffectiveMR - (attackerEffectiveAP * 0.2f), 0.0f, float.PositiveInfinity);

        float battleDamage = 0.0f;
        if (magicDamage) 
            battleDamage = Math.Clamp(attackerEffectiveAP - (targetEffectiveMR), min: 0.0f, max: float.PositiveInfinity);
        else 
            battleDamage = Math.Clamp(attackerEffectiveAD - (targetEffectiveArmor), min: 0.0f, max: float.PositiveInfinity);

        if (attackType == AttackType.Charged)
            battleDamage *= 3f;
        
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
        
        Console.WriteLine($"{this.Name} recibio {battleDamage:0} daño. HP: {this.CurrentHealth:0}/{this.Stats.MaxHealth:0}");
        Console.WriteLine();
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Basic Stats: \n{this.Stats}");
    }
}

