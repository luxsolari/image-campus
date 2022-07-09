namespace Evaluacion_II.Items;

public class Weapon : Item
{
    private float bonusDamage;
    private float bonusAgility;
    private float bonusCriticalChance;
    private float bonusCriticalRate;

    public Weapon(string? name, float bonusDamage, float bonusAgility, float bonusCriticalChance, float bonusCriticalRate) : base(name)
    {
        this.bonusDamage = bonusDamage;
        this.bonusAgility = bonusAgility;
        this.bonusCriticalChance = bonusCriticalChance;
        this.bonusCriticalRate = bonusCriticalRate;
    }
}