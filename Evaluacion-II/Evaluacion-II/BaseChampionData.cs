using Evaluacion_II.Enums;

namespace Evaluacion_II;

public struct BaseChampionData
{
    public string? Name;
    public float BaseHealth;
    public float CurrentHealth;
    
    public float BaseAtkDamage;
    public float BaseAbilityPower;
    public float BaseAtkSpeed;
    public float BaseArmor;
    public float BaseMagicResist;
    public float AttackRange;

    public float BaseCriticalChance;
    public float BaseCriticalRate;
    
    public bool IsRanged;
    public List<Role> Roles;
}