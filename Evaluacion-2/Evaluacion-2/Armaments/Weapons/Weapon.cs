using Evaluacion_2.Utils;

namespace Evaluacion_2.Armaments.Weapons;

public abstract class Weapon
{
    protected string Name { get; }
    protected float BaseDmg { get; }
    protected float Weight { get; }

    protected float BaseCriticalChance { get; }
    protected float BaseCriticalMultiplier { get; }
    protected bool IsTwoHanded { get; }

    protected Weapon(string name, float baseDmg, float weight, float baseCriticalChance, float baseCriticalMultiplier, bool isTwoHanded)
    {
        this.Name = name;
        this.BaseDmg = baseDmg;
        this.Weight = weight;
        this.BaseCriticalChance = baseCriticalChance;
        this.BaseCriticalMultiplier = baseCriticalMultiplier;
        this.IsTwoHanded = isTwoHanded;
    }

    public abstract float GetTotalAtkDamage(ref AttackType attackType, ref bool isCritical);
}