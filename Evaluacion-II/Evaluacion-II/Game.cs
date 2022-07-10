using Evaluacion_II.Champions;
using Evaluacion_II.Enums;
using Evaluacion_II.Items;

namespace Evaluacion_II;

public class Game
{
    private int timer = 0;
    private bool gameRunning = true;
    private Champion player1;
    private Champion player2;

    public Game(Champion player1, Champion player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }

    private void Start()
    {
        // initial game setup
        Console.Clear();
    }
    
    private void Update()
    {

        bool isCritical = false;
        Random random = new Random();

        if (!player1.IsAlive())
        {
            gameRunning = false;
            Console.WriteLine($"{player2.Name} ha ganado la batalla.");
        }
        else if (!player2.IsAlive())
        {
            gameRunning = false;
            Console.WriteLine($"{player1.Name} ha ganado la batalla.");
        }
        else
        {
            Console.WriteLine($"----------------");
            Console.WriteLine($"{player1.Name} ataca!");
            float bonusCriticalChance = 0.0f;
            foreach (Item item in player1.inventory)
            {
                if (item is Weapon) bonusCriticalChance += ((item as Weapon)!).BonusCriticalChance;
            }
            if (random.NextSingle() >= 1 - (player1.Stats.CriticalChance + bonusCriticalChance)) 
                isCritical = true;
            this.player1.AutoAttack(player2, AttackType.Normal, isCritical: ref isCritical);
            
            if (player2.IsAlive())
            {
                isCritical = false;
                bonusCriticalChance = 0.0f;
                foreach (Item item in player2.inventory)
                {
                    if (item is Weapon) bonusCriticalChance += ((item as Weapon)!).BonusCriticalChance;
                }
                Console.WriteLine($"----------------");
                Console.WriteLine($"{player2.Name} ataca!");
                if (random.NextSingle() >= 1 - (player2.Stats.CriticalChance + bonusCriticalChance)) 
                    isCritical = true;
                this.player2.AutoAttack(player1, AttackType.Normal, isCritical: ref isCritical);    
            }
            else
            {
                gameRunning = false;
                Console.WriteLine($"{player1.Name} ha ganado la batalla.");
            }
            
            Console.WriteLine($"----------------");
        }

        timer++;
        Thread.Sleep(1000);
    }

    private void Finish()
    {
        // final actions before game end
        Console.WriteLine("Finished!");
        Console.ReadKey(true);
    }
    public void Play()
    {
        Start();
        while (gameRunning)
        {
            Update();
        }
        Finish();
    }

}