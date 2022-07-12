using Evaluacion_II.Champions;
using Evaluacion_II.Enums;
using Evaluacion_II.Items;

namespace Evaluacion_II;

public class Game
{
    private int turnCount = 1;
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
            Console.Clear();
            Console.WriteLine($"-------------------------");
            Console.WriteLine($"TURNO    {this.turnCount}");
            Console.WriteLine($"-------------------------");
            this.ProcessTurn(ref player1, ref player2);
            if (player2.IsAlive())
            {
                this.ProcessTurn(ref player2, ref player1);
            }
            else
            {
                Console.WriteLine($"{player1.Name} ha ganado la batalla!");
                gameRunning = false;
            }
            Console.WriteLine($"-------------------------");
            Console.WriteLine();
        }

        turnCount++;
        Thread.Sleep(2000);
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

    public void ProcessTurn(ref Champion turnPlayer, ref Champion target)
    {
        Random random = new Random();
        
        Console.WriteLine($"{turnPlayer.Name} - HP {turnPlayer.CurrentHealth:0}/{turnPlayer.Stats.MaxHealth:0}");
        if (turnPlayer.IsChargingAttack)
        {
            turnPlayer.IsChargingAttack = false;
            Console.WriteLine($"Libera un ataque cargado!");
            Thread.Sleep(1000);
            float effectiveCritChance = turnPlayer.Stats.CriticalChance;
            
            bool isCritical = random.NextSingle() <= (1 - effectiveCritChance);
            turnPlayer.AutoAttack(target, AttackType.Charged, ref isCritical);
        }
        else
        {
            Console.WriteLine($"1-Auto-Ataque 2-Habilidades  3-Objetos  4-Defender");
            Console.Write("->");
            int opcionPlayer = Convert.ToInt16(Console.ReadLine());
            switch (opcionPlayer)
            {
                case 1:
                    Console.WriteLine($"1-Ataque rapido  2-Ataque Normal  3-Ataque Cargado");
                    Console.Write("->");
                    AttackType attackType = (AttackType) Convert.ToInt16(Console.ReadLine());
                    if (attackType == AttackType.Charged)
                    {
                        Console.WriteLine($"{turnPlayer.Name} está preparando un ataque!");
                        turnPlayer.IsChargingAttack = true;
                    }
                    else
                    {
                        float effectiveCritChance = turnPlayer.Stats.CriticalChance;
                        if (attackType == AttackType.Fast)
                            effectiveCritChance *= 1.25f;
                
                        bool isCritical = random.NextSingle() <= (1 - effectiveCritChance);
                        turnPlayer.AutoAttack(target, attackType, ref isCritical);
                    }
                    break;
                case 2:
                    // Use skill
                    Console.WriteLine("Aca iria un skill.... si tuviera uno");
                    break;
                case 3:
                    // Use item
                    Console.WriteLine("Aca usaria un item.... si tuviera uno");
                    break;
                case 4:
                    // Defend
                    Console.WriteLine("Aca defenderia... si pudiera");
                    break;
            }
        }
    }
}