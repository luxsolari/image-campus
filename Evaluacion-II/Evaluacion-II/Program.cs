namespace Evaluacion_II;
public static class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        Thread thread1 = new Thread(game.Play);
        

    }
}