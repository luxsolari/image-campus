using Evaluacion_II.Champions;

namespace Evaluacion_II;

public class Game
{
    private int timer = 0;
    private bool gameRunning = true;
    private Champion player1;
    private Champion player2;

    public Game(Champion player1, Champion player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }

    private void Start()
    {
        // initial game setup
        Console.Clear();
    }
    
    private void Update()
    {
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("                 ");
        Console.SetCursorPosition(0, 0);
        Console.WriteLine($"Timer: {timer}");
        timer++;
        Thread.Sleep(1000);
    }

    private void Finish()
    {
        // final actions before game end
        Console.WriteLine("Finished!");
        Console.ReadKey(true);
    }
    public void Play()
    {
        Start();
        while (gameRunning)
        {
            Update();
        }
        Finish();
    }

}