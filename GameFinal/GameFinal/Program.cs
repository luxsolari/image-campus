using System;
using GameFinal.Handlers;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameFinal
{
    public class Program
    {
        static void Main(string[] args)
        {
            GameHandler gameHandler = new GameHandler();
            while (!gameHandler.WindowHandler.IsDone)
            {
                gameHandler.ProcessInput();
                gameHandler.Update();
                gameHandler.Render();
                gameHandler.RestartClock();
            }
        }
    }
}
