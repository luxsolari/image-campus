namespace Evaluacion_II.Items;

public class Weapon : Item
{
    public float BonusDamage { get; set; }
    public float BonusAgility { get; set;}
    public float BonusCriticalChance { get; set; }
    public float BonusCriticalRate { get; set; }

    public Weapon(string? name, float bonusDamage, float bonusAgility, float bonusCriticalChance, float bonusCriticalRate) : base(name)
    {
        this.BonusDamage = bonusDamage;
        this.BonusAgility = bonusAgility;
        this.BonusCriticalChance = bonusCriticalChance;
        this.BonusCriticalRate = bonusCriticalRate;
    }
}
