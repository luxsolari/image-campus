using System;
using GameFinal.Handlers;
using GameFinal.States;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameFinal
{
    public class Program
    {
        static void Main(string[] args)
        {
            WindowHandler windowHandler = new WindowHandler("One More Snake", new Vector2u(Globals.WindowWidthResolution, Globals.WindowHeightResolution));
            StatesController statesController = new StatesController(windowHandler);
        }
    }
}
