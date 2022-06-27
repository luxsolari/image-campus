using Evaluacion_2.Utils;

namespace Evaluacion_2.Armaments.Weapons;

public class Spear : Weapon
{
    private float ArmorPenetrationBonus { get; }

    public Spear(string name, float baseDmg, float weight, float baseCriticalChance, float baseCriticalMultiplier, float armorPenetrationBonus) 
        : base(name, baseDmg, weight, baseCriticalChance, baseCriticalMultiplier, true)
    {
        this.ArmorPenetrationBonus = armorPenetrationBonus;
    }

    public override float GetTotalAtkDamage(ref AttackType attackType, ref bool isCritical)
    {
        return 0.0f;
    }

    public void GetSpearInfo()
    {
        Console.WriteLine($"Sword information:");
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Base DMG: {this.BaseDmg}");
        Console.WriteLine($"Weight: {this.Weight} kg.");
        Console.WriteLine($"Base critical DMG Chance: {this.BaseCriticalChance * 100 }%");
        Console.WriteLine($"Base critical DMG Multiplier: {this.BaseCriticalMultiplier * 100 }%");
        Console.WriteLine($"Is Two-handed: {(IsTwoHanded ? "Yes" : "No")}");
        Console.WriteLine($"Bonus Armor Penetration: {this.ArmorPenetrationBonus * 100 }%");
    }
}