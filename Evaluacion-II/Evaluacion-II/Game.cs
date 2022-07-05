using Evaluacion_II.Champions;
using Evaluacion_II.Enums;

namespace Evaluacion_II;

public class Game
{
    private Champion teemo;

    private void Start()
    {
        teemo = new("Teemo", new BaseStats
            (
                attackDamage: 54f,
                attackSpeed: 0.69f, 
                maxHealth: 580f, 
                armor: 24f, 
                magicResist:30f, 
                healthRegen:5.5f, 
                resource:new Resource(type: ResourceType.Mana, maxResourceAmount: 334f, resourceRegenAmount: 9.6f)
            ),
            roles: new List<Role> {Role.Marksman, Role.Assassin}
        );
    }

    private void Update()
    {
        
    }

    private void Finish()
    {
        
    }
    public void Play()
    {
        this.Start();
        this.Update();
        Console.ReadKey(true);
        this.Finish();
    }
}