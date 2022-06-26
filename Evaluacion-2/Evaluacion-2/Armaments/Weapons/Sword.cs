using Evaluacion_2.Utils;

namespace Evaluacion_2.Armaments.Weapons;

public class Sword : Weapon
{
    private bool isTwoHanded;
    
    public Sword(string name, float baseDmg, float weight, float criticalChance, float criticalMultiplier, bool isTwoHanded) : 
        base(name, baseDmg, weight, criticalChance, criticalMultiplier)
    {
        this.isTwoHanded = isTwoHanded;
    }

    public override float GetTotalAtkDamage(ref AttackType attackType, ref bool isCritical)
    {
        return 0.0f;
    }

    public void GetSwordInfo()
    {
        Console.WriteLine($"Sword information:");
        Console.WriteLine($"Name: {this.name}");
        Console.WriteLine($"Base DMG: {this.baseDmg}");
        Console.WriteLine($"Weight: {this.weight} kg.");
        Console.WriteLine($"Critical DMG Chance: {this.criticalChance * 100 }%");
        Console.WriteLine($"Critical DMG Multiplier: {this.criticalMultiplier * 100 }%");
        Console.WriteLine($"Is Two-handed: {(isTwoHanded ? "Yes" : "No")}");
    }
}