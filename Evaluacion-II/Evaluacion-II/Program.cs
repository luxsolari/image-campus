using System.Text.Json;
using Evaluacion_II.Champions;

namespace Evaluacion_II;
public static class Program
{
    public static void Main(string[] args)
    {
        Champion player1Champion = ChampionGenerator.CreateNewChampion();
        Champion player2Champion = ChampionGenerator.CreateNewChampion();
        Game game = new Game(player1Champion, player2Champion);
        game.Play();

    }
}