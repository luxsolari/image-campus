using System;

class Program
{
    static void Main()
    {
        // Creamos un objeto random para sacar numeros aleatorios de ahi.
        Random random = new Random();

        do
        {
            Console.WriteLine("Vamos a crear estrellas! Decime el nombre para tu estrella: ");
            String nombre = Console.ReadLine();
            Star star1 = new Star(nombre, random.Next() % 11 + 30, random.Next() % 11);
            star1.PrintCoordinates();
            star1.Show();
        } while (!Console.ReadKey(true).Key.Equals(ConsoleKey.Escape));

    }
}


