using System.Text.Json;
using Evaluacion_II.Champions;

namespace Evaluacion_II;
public static class Program
{
    public static void Main(string[] args)
    {
        string fileName = "playerChampions.json";
        string fileText = File.Exists(fileName) ? File.ReadAllText(fileName) : "";
        List<Champion>? champions = File.Exists(fileName) ? JsonSerializer.Deserialize<List<Champion>>(fileText) : new List<Champion>();

        Champion player1Champion = ChampionGenerator.CreateNewChampion();
        Champion player2Champion = ChampionGenerator.CreateNewChampion();

        champions?.Add(player1Champion);
        champions?.Add(player2Champion);
        string jsonString = JsonSerializer.Serialize(champions);
        File.WriteAllText(fileName, jsonString);

        fileText = File.ReadAllText(fileName);
        champions = File.Exists(fileName) ? JsonSerializer.Deserialize<List<Champion>>(fileText) : new List<Champion>();
        if (champions != null)
            foreach (Champion champion in champions)
            {
                champion.PrintInfo();
                Console.WriteLine("------------------------------------------------------");
            }

        Console.ReadKey();
    }
}