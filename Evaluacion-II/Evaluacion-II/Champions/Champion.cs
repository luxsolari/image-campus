using Evaluacion_II.Enums;

namespace Evaluacion_II.Champions;

public class Champion
{
    private BaseChampionData BaseChampionData;

    public Champion(BaseChampionData baseChampionData)
    {
        BaseChampionData = baseChampionData;
    }

    public void Attack()
    {
        
    }

    public void showChampionInfo()
    {
        // Mostrar datos del champ.
        Console.WriteLine(this.BaseChampionData.Name);
        Console.Write($"Roles: ");
        foreach (Role role in this.BaseChampionData.Roles)
        {
            Console.Write($"{role} ");
        }
        Console.WriteLine("");
        Console.WriteLine($"{this.BaseChampionData.AttackRange}");
    }

}