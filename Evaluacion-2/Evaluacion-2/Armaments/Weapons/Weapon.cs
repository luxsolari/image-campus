using Evaluacion_2.Utils;

namespace Evaluacion_2.Armaments.Weapons;

public abstract class Weapon
{
    protected string name;
    protected float baseDmg;
    protected float weight;
    
    protected float criticalChance;
    protected float criticalMultiplier;

    protected Weapon(string name, float baseDmg, float weight, float criticalChance, float criticalMultiplier)
    {
        this.name = name;
        this.baseDmg = baseDmg;
        this.weight = weight;
        this.criticalChance = criticalChance;
        this.criticalMultiplier = criticalMultiplier;
    }

    public abstract float GetTotalAtkDamage(ref AttackType attackType, ref bool isCritical);
}