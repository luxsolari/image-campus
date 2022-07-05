using Evaluacion_II.Champions;
using Evaluacion_II.Enums;

namespace Evaluacion_II;

public class Game
{
    public bool IsRunning = true;
    private int counter = 0;
    private Input? inputHandler;

    private void Start()
    {
        Console.Clear();
        Console.WriteLine("Started!");
        Console.SetCursorPosition(0, Console.WindowHeight);
        Console.Write("Press R to reset timer, press Q to quit.");
    }

    private void Update()
    {
        Console.SetCursorPosition(0,0);
        Console.Write("                     ");
        Console.SetCursorPosition(0,0);
        Console.Write($"Running... {counter}");
        if (inputHandler?.GetReadInput() is { Key: ConsoleKey.R })
        {
            counter = -1;
            Console.SetCursorPosition(0,0);
            Console.Write("Timer Reset!");
            inputHandler.ResetReadInput();
        }
        counter++;
        Thread.Sleep(1000);
    }

    private void Finish()
    {
        Console.SetCursorPosition(0, 0);
        Console.Write("                     ");
        Console.SetCursorPosition(0, 0);
        Console.WriteLine("Finished!");
        
    }
    public void Play()
    {
        this.Start();
        while (IsRunning)
        {
            this.Update();
        }
        this.Finish();
    }

    public void AddInput(Input input)
    {
        this.inputHandler = input;
    }
}