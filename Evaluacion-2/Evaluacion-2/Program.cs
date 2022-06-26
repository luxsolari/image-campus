using System;
using Evaluacion_2.Armaments.Weapons;

public class Program
{
    public static void Main(string[] args)
    {
        Weapon sword1 = new Sword("TeAndal", 125, 7, 0.75f, 1.25f, true);
        Weapon sword2 = new Sword("Eclipse", 75, 5, 0.65f, 1.75f, false);
        
        Console.WriteLine();
        ((sword1 as Sword)!).GetSwordInfo();
        Console.WriteLine();
        ((sword2 as Sword)!).GetSwordInfo();

        Console.ReadKey(true);
    }
}