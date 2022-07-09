using System;
using Evaluacion_II.Enums;
using Evaluacion_II.Items;

namespace Evaluacion_II.Champions;
[Serializable]
public class Champion
{
    public string Name { get; set; }
    public BaseStats Stats { get; set; }
    public Role PrimaryRole { get; set; }

    public Champion()
    {
        
    }

    public Champion(string name, BaseStats stats, Role primaryRole)
    {
        Name = name;
        Stats = stats;
        PrimaryRole = primaryRole;
    }
    public void AutoAttack()
    {
        
    }
    
    public void PrintInfo()
    {
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Basic Stats: \n{this.Stats}");
    }
}

