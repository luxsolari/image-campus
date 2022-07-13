using Evaluacion_II.Champions;
using Evaluacion_II.Enums;
using Evaluacion_II.Utils;

namespace Evaluacion_II;

public class Game
{
    private int turnCount = 1;
    private bool gameRunning = true;

    private Player player1;
    private Player player2;
    
    private Champion player1Champion;
    private Champion player2Champion;

    public Game(ref Player player1, ref Player player2)
    {
        this.player1 = player1;
        this.player2 = player2;
    }

    // Main game loop method
    public void Play()
    {
        Start();
        while (gameRunning)
        {
            Update();
        }
        Finish();
    }
    private void Start()
    {
        Console.Clear();
        // initial game setup
        // Pre-battle actions
        Console.WriteLine($"CREANDO UN NUEVO CAMPEON PARA EL JUGADOR {this.player1.Name}!");
        Console.WriteLine("--------------------------------------------------------------");
        this.player1Champion = GeneratorUtils.CreateNewChampion();
        
        Console.Clear();
        Console.WriteLine($"CREANDO UN NUEVO CAMPEON PARA EL JUGADOR {this.player2.Name}!");
        Console.WriteLine("--------------------------------------------------------------");
        this.player2Champion = GeneratorUtils.CreateNewChampion();
        
        this.player1.PlayerChampions.Add(player1Champion);
        this.player2.PlayerChampions.Add(player2Champion);
    }
    
    // Turn update method
    private void Update()
    {
        if (!player1Champion.IsAlive())
        {
            gameRunning = false;
            Console.WriteLine($"{player2Champion.Name} ha ganado la batalla!");
            Console.WriteLine($"{player2.Name}  consiguió 10 puntos y se lleva 300 de oro como premio!");
            player2.Gold += 300;
            player2.Score += 10;
        }
        else if (!player2Champion.IsAlive())
        {
            gameRunning = false;
            Console.WriteLine($"{player1Champion.Name} ha ganado la batalla1");
            Console.WriteLine($"{player1.Name}  consiguió 10 puntos y se lleva 300 de oro como premio!");
            player1.Gold += 300;
            player1.Score += 10;
        }
        else
        {
            Console.Clear();
            Console.WriteLine($"-------------------------");
            Console.WriteLine($"TURNO    {this.turnCount}");
            Console.WriteLine($"-------------------------");
            this.ProcessTurn(ref player1Champion, ref player2Champion);
            if (player2Champion.IsAlive())
            {
                this.ProcessTurn(ref player2Champion, ref player1Champion);
            }
            else
            {
                Console.WriteLine($"{player1Champion.Name} ha ganado la batalla!");
                Console.WriteLine($"{player1.Name}  consiguió 10 puntos y se lleva 300 de oro como premio!");
                player1.Gold += 300;
                player1.Score += 10;
                
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
        Console.WriteLine("Presiona una tecla para volver al menu principal...");
        Console.ReadKey(true);
    }

    public void ProcessTurn(ref Champion attacker, ref Champion defender)
    {
        Random random = new Random();
        
        Console.WriteLine($"{attacker.Name} - HP {attacker.CurrentHealth:0}/{attacker.Stats.MaxHealth:0}");
        if (attacker.IsDefending) attacker.IsDefending = false;
        
        if (attacker.IsChargingAttack)
        {
            attacker.IsChargingAttack = false;
            Console.WriteLine($"Libera un ataque cargado!");
            Thread.Sleep(1000);
            float effectiveCritChance = attacker.Stats.CriticalChance;
            
            bool isCritical = random.NextSingle() <= (1 - effectiveCritChance);
            attacker.AutoAttack(defender, AttackType.Charged, ref isCritical);
        }
        else
        {
            Console.WriteLine($"1-Auto-Ataque  2-Defender");
            int opcionPlayer;
            do
            {
                Console.Write("-> ");
                opcionPlayer = Convert.ToInt16(Console.ReadLine());
            } while (opcionPlayer is < 1 or > 2);
            
            switch (opcionPlayer)
            {
                case 1:
                    Console.WriteLine($"1-Ataque rapido  2-Ataque Normal  3-Ataque Cargado");
                    AttackType attackType;
                    do
                    {
                        Console.Write("-> ");
                        attackType = (AttackType) Convert.ToInt16(Console.ReadLine());
                    } while (attackType is < (AttackType) 1 or > (AttackType) 3);
                    
                    if (attackType == AttackType.Charged)
                    {
                        Console.WriteLine($"{attacker.Name} está preparando un ataque!");
                        attacker.IsChargingAttack = true;
                    }
                    else
                    {
                        float effectiveCritChance = attacker.Stats.CriticalChance;
                        if (attackType == AttackType.Fast)
                            effectiveCritChance *= 1.25f;
                
                        bool isCritical = random.NextSingle() >= (1 - effectiveCritChance);
                        attacker.AutoAttack(defender, attackType, ref isCritical);
                    }
                    break;
                case 2:
                    // Defend (buff temporal de defensa)
                    Console.WriteLine($"{attacker.Name} se prepara para defenderse!");
                    attacker.IsDefending = true;
                    break;
            }
        }
    }
}