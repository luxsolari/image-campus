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
        Console.WriteLine($"Timer: {timer}  ");
        Console.SetCursorPosition(0, 1);
        Console.WriteLine($"----------------");

        bool isCritical = false;
        this.player1.AutoAttack(player2, isCritical: ref isCritical);
        this.player2.AutoAttack(player1, isCritical: ref isCritical);
        
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