using System;

class Program
{
    static void Main()
    {
        Star miEstrella = new Star(0, 0);
        Star miEstrella2 = new Star(2, 2);
        Console.WriteLine("Estrella 1: " + Star.miNumerito);
        Console.WriteLine("Estrella 2: " + Star.miNumerito);

        Console.Title = "Mi programa genial";
        int consoleWidth = Console.BufferWidth;   //120 caracteres
        int consoleHeight = Console.BufferHeight; //30  caracteres

        Console.WriteLine("Dimensiones de consola: " + consoleWidth + "x" + consoleHeight);
        Console.WriteLine();


        for (int i = 0; i <= Console.BufferHeight / 2; i++)
        {
            Console.SetCursorPosition((consoleWidth / 2) - 15, i + 1);
            Console.Write("-");
            for (int j = 0; j < 30; j++)
            {
                if (i == 0 || i == consoleHeight / 2) Console.Write('*');
                else Console.Write(' ');
            }
            Console.Write("-");
        }

        Console.ReadKey();
    }
}


