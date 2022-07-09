namespace Evaluacion_II.Champions;

public class Skill
{
    public string Name { get; }
    public float BaseDamage { get; }

    public Skill(string name, float baseDamage)
    {
        Name = name;
        BaseDamage = baseDamage;
    }
}