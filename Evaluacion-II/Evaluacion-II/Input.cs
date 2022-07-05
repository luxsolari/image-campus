namespace Evaluacion_II;

public class Input
{
    private ConsoleKeyInfo? readkey;
    private bool isRunnning = true;
    private readonly Game gameTarget;
    public Input(Game gameTarget)
    {
        this.gameTarget = gameTarget;
    }

    public void ReadInput()
    {
        while (this.isRunnning)
        {
            this.readkey = Console.ReadKey(true);
            if (this.readkey.Value.Key == ConsoleKey.Q)
            {
                this.isRunnning = false;
                gameTarget.IsRunning = false;
            }
            else
            {
                Console.SetCursorPosition(0,1);
                Console.WriteLine($"Key pressed: {this.readkey.Value.Key}");
            }
        }
    }

    public ConsoleKeyInfo? GetReadInput() => this.readkey;

    public void ResetReadInput()
    {
        this.readkey = null;
    }

}