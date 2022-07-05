namespace Evaluacion_II.Champions;

public struct BaseStats
{
    // Offensive stats
    public float AbilityPower { get; set; }
    public float AttackDamage { get; set; } //

    public float ArmorPenetration { get; set; }
    public float MagicPenetration { get; set; }
    
    public float AttackSpeed    { get; set; } //
    public float CriticalChance { get; set; }
    public float CriticalRate   { get; set; }
    
    // Defensive stats
    public float MaxHealth   { get; set; }  //
    public float Armor       { get; set; }  //
    public float MagicResist { get; set; }  //
    
    // Other
    public float HealthRegen { get; set; } //
    public Resource Resource { get; set; } //

    public BaseStats(float attackDamage, float attackSpeed, float maxHealth, float armor, float magicResist, float healthRegen, Resource resource) : this()
    {
        AttackDamage = attackDamage;
        AttackSpeed = attackSpeed;
        MaxHealth = maxHealth;
        Armor = armor;
        MagicResist = magicResist;
        HealthRegen = healthRegen;
        Resource = resource;
        
        CriticalChance = 0.0f;
        CriticalRate = 0.75f;
        ArmorPenetration = 0.0f;
        MagicPenetration = 0.0f;
        AbilityPower = 0.0f;
    }

    public override string ToString()
    {
        string statsString = $"\tAttack Damage: {this.AttackDamage}" +
                             $"\tAttack Speed: {this.AttackSpeed}\n" +
                             $"\tMax Health: {this.MaxHealth}\t" +
                             $"\tHealth Regen: {this.HealthRegen}\n" +
                             $"\tArmor: {this.Armor}\t" +
                             $"\tMagic Resist: {this.MagicResist}\n" +
                             $"\tMax {this.Resource.Type}: {this.Resource.MaxResourceAmount}\t" +
                             $"\t{this.Resource.Type} Regen: {this.Resource.ResourceRegenAmount}";
        return statsString;
    }
}