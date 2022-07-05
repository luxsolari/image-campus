using System;
using Evaluacion_II.Enums;
using Evaluacion_II.Items;

namespace Evaluacion_II.Champions;

public class Champion
{
    // fields
    private string name;
    private BaseStats baseStats;
    private List<Role> roles;
    private List<Item> inventory = new List<Item>();

    // properties
    public string Name => name;
    public BaseStats Stats => baseStats;
    public List<Role> Roles => roles;

    public Champion(string name, BaseStats baseStats, List<Role> roles)
    {
        this.name = name;
        this.baseStats = baseStats;
        this.roles = roles;
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Name: {this.Name}");
        Console.WriteLine($"Basic Stats: \n{this.Stats}");
        Console.WriteLine($"Roles: ");
        foreach (Role role in Roles)
        {
            Console.WriteLine($"\t{role}");
        }
    }
}

