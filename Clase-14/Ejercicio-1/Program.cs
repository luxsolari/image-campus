using System;

class Program
{
    static void Main()
    {
        int consoleHeight = Console.WindowHeight;
        int consoleWidth = Console.WindowWidth;
        Console.SetCursorPosition(consoleWidth / 2, consoleHeight / 2);
        Console.WriteLine("Hello World!");
        Console.Write("La dimension de la consola es: " + consoleWidth + "x" + consoleHeight);

    }
}


