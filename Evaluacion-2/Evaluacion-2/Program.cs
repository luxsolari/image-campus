using System;
using Evaluacion_2;
using Evaluacion_2.Armaments.Weapons;

public class Program
{
    public static void Main(string[] args)
    {
        Game game = new Game();
        Thread gameThread = new Thread(game.Play);
        gameThread.Name = "Game Thread";
        
        gameThread.Start();
    }
}
