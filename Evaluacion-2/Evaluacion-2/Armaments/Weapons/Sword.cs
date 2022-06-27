using Evaluacion_2.Utils;

namespace Evaluacion_2.Armaments.Weapons;

public class Sword : Weapon
{
    public AttackType[] AllowedAttackTypes { get; } = { AttackType.Normal, AttackType.Charged, AttackType.Heavy };

    public Sword(string name, float baseDmg, float weight, float baseCriticalChance, float baseCriticalMultiplier, bool isTwoHanded) : 
        base(name, baseDmg, weight, baseCriticalChance, baseCriticalMultiplier, isTwoHanded) { }

    public override float GetTotalAtkDamage(ref AttackType attackType, ref bool isCritical)
    {
        float totalDamage = 0.0f;
        switch (attackType)
        {
            case AttackType.Normal:
                totalDamage = (isCritical ? this.BaseDmg * BaseCriticalChance : this.BaseDmg);
                break;
            case AttackType.Heavy:
                totalDamage = this.BaseDmg * 1.25f + (isCritical ? this.BaseDmg * (BaseCriticalMultiplier * 1.5f): 0f);
                break;
            case AttackType.Charged:
                totalDamage = this.BaseDmg * 1.5f  + (isCritical ? this.BaseDmg * (BaseCriticalMultiplier * 2f): 0f);
                break;
        }

        return totalDamage;
    }

    public void GetSwordInfo()
    {
        Console.WriteLine($"Sword information:");
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Base DMG: {this.BaseDmg}");
        Console.WriteLine($"Weight: {this.Weight} kg.");
        Console.WriteLine($"Base critical DMG Chance: {this.BaseCriticalChance * 100 }%");
        Console.WriteLine($"Base critical DMG Multiplier: {this.BaseCriticalMultiplier * 100 }%");
        Console.WriteLine($"Is Two-handed: {(IsTwoHanded ? "Yes" : "No")}");
    }
}