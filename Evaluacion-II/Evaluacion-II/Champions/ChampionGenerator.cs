using Evaluacion_II.Enums;

namespace Evaluacion_II.Champions;

public static class ChampionGenerator
{
    public static Champion CreateNewChampion()
    {
        Console.Clear();
        Console.WriteLine("CREANDO NUEVO CAMPEON");

        Console.Write("Ingresa el nombre del campeon: ");
        string championName = Console.ReadLine() ?? "Unnamed";

        Console.WriteLine("Selecciona la clase de tu Campeon:");
        Console.WriteLine("1 - Luchador     (efectivo vs. Tiradores y Asesinos)");
        Console.WriteLine("2 - Mago         (efectivo vs. Luchadores y Tiradores)");
        Console.WriteLine("3 - Tirador      (efectivo vs. Magos, Tiradores y Soportes)");
        Console.WriteLine("4 - Asesino      (efectivo vs. Magos, Tiradores y Especialistas)");
        Console.WriteLine("5 - Tanque       (efectivo vs. Luchadores, Tiradores y Asesinos)");
        Console.WriteLine("6 - Soporte      (sin efectividad particular, provee utilidad)");
        Console.WriteLine("7 - Especialista (efectivo vs. tanaques y soportes)");
        Console.WriteLine("------------------------------------------------------");
        Console.Write    ("-> ");
        int opcionRol = Convert.ToInt16(Console.ReadLine());
        Role championRole = (Role)opcionRol;
        BaseStats baseStats = default;
        switch (championRole)
        {
            case Role.Fighter:
                baseStats = new BaseStats(modAttackDamage: 2f, modAgility: 1.1f, modMaxHealth: 1.2f, modArmor: 0.9f,
                    modMagicResist: 0.8f, modHealthRegen: 3f, modCritChance: 0.2f, modCritRate: 1.75f, 
                    new Resource(ResourceType.Energy, 100, 20));
                break;
            case Role.Mage:
                baseStats = new BaseStats(modAttackDamage: 0.65f, modAgility: 0.6f, modMaxHealth: 0.7f, modArmor: 0.6f,
                    modMagicResist: 0.9f, modHealthRegen: 1.25f, modCritChance: 0.0f, modCritRate: 0.0f,
                    new Resource(ResourceType.Energy, 100, 20));
                break;
            case Role.Marksman:
                baseStats = new BaseStats(modAttackDamage: 2.25f, modAgility: 1.25f, modMaxHealth: 0.5f, modArmor: 0.5f,
                    modMagicResist: 0.5f, modHealthRegen: 1.25f, modCritChance: 0.3f, modCritRate: 1.75f,
                    new Resource(ResourceType.Energy, 100, 20));
                break;
            case Role.Assassin:
                baseStats = new BaseStats(modAttackDamage: 2f, modAgility: 1.5f, modMaxHealth: 1f, modArmor: 1f,
                    modMagicResist: 1f, modHealthRegen: 1.2f, modCritChance: 0.3f, modCritRate: 1.85f,
                    new Resource(ResourceType.Energy, 100, 20));
                break;
            case Role.Tank:
                baseStats = new BaseStats(modAttackDamage: 0.6f, modAgility: 1f, modMaxHealth: 2f, modArmor: 2f,
                    modMagicResist: 1.5f, modHealthRegen: 5f, modCritChance: 0.0f, modCritRate: 0.0f,
                    new Resource(ResourceType.Energy, 100, 20));
                break;
            case Role.Support:
                baseStats = new BaseStats(modAttackDamage: 0.4f, modAgility: 0.8f, modMaxHealth: 1.2f, modArmor: 1.25f,
                    modMagicResist: 1.15f, modHealthRegen: 3f, modCritChance: 0.0f, modCritRate: 0.0f,
                    new Resource(ResourceType.Energy, 100, 20));
                break;
            case Role.Specialist:
                baseStats = new BaseStats(modAttackDamage: 1.75f, modAgility: 1.5f, modMaxHealth: 1.1f, modArmor: 1f,
                    modMagicResist: 1f, modHealthRegen: 1.1f, modCritChance: 0.25f, modCritRate: 1.75f,
                    new Resource(ResourceType.Energy, 100, 20));
                break;
        }

        Champion createdChampion = new Champion(championName, baseStats, (Role) opcionRol);
        Console.WriteLine("Creacion del Campeon completa!");
        Console.WriteLine("------------------------------------------------------");
        createdChampion.PrintInfo();
        Console.WriteLine("------------------------------------------------------");
        Console.Write    ("-> ");
        Console.ReadKey(true);
        return createdChampion;
    }
}