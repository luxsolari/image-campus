namespace Evaluacion_II;
public static class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        Thread thread1 = new Thread(game.Play);
        thread1.Name = "Game Thread";

        Input input = new Input(game);
        Thread thread2 = new Thread(input.ReadInput);
        thread2.Name = "Input Thread";
        
        game.AddInput(input);
        
        thread1.Start();
        thread2.Start();

    }
}