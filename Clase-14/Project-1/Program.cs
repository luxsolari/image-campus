namespace Project_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Chair[] chairs = new Chair[3];

            chairs[0] = new Chair();
            chairs[1] = new Chair(4, Material.Wood, 3000, 90000, 300, false);
            chairs[2] = new Chair(4, Material.Metal, 4000, 120000, 400, false);

            Console.WriteLine("Chair 1: " + chairs[0].ToString());

        }
    }
}