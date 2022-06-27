using Evaluacion_2.Armaments.Weapons;

namespace Evaluacion_2;

public class Game
{
    public static bool isRunning = true;
    public void Play()
    {
        Weapon aSword = new Sword("Excalibur", 100f, 3f, 0.2f, 1.75f, true);
        Console.WriteLine("Hello from Game.cs!");
        while (isRunning)
        {
            var key = Console.ReadKey(true).Key;
            if (key != ConsoleKey.Escape)
            {
                Console.WriteLine($"Key pressed: {key} {Thread.CurrentThread.Name}");
            }
            else
            {
                Console.WriteLine("Game Thread stopped!");
                isRunning = false;
            }
        }
    }
}