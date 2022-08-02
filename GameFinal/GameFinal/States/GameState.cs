using GameFinal.Entities;
using GameFinal.Handlers;
using GameFinal.UI;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameFinal.States
{
    internal class GameState : LoopState
    {
        private World world;
        private Snake player;
        private HUD hud;
        public Clock Clock { get; } = new Clock();
        public Time DeltaTime { get; set; }

        public event Action OnQuitPressed;
        
        public GameState(WindowHandler window) : base(window) { }
        
        private void OnPressKey (object sender, KeyEventArgs keyEventArgs)
        {
            if (keyEventArgs.Code == Keyboard.Key.Escape)
                OnQuitPressed?.Invoke();
        }

        public void ProcessInput()
        {
            this.WindowHandler.DispatchEvents();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && this.player.GetPhysicalDirection() != Direction.Down)
            {
                this.player.SetDirection(Direction.Up);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Down) && this.player.GetPhysicalDirection() != Direction.Up)
            {
                this.player.SetDirection(Direction.Down);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && this.player.GetPhysicalDirection() != Direction.Right)
            {
                this.player.SetDirection(Direction.Left);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && this.player.GetPhysicalDirection() != Direction.Left)
            {
                this.player.SetDirection(Direction.Right);
            }
        }
        public void RestartClock()
        {
            this.DeltaTime += this.Clock.Restart();
        }

        protected override void Start()
        {
            this.world = new World(new Vector2u(Globals.GameFieldWidth, Globals.GameFieldHeight), Globals.BlockSize);
            this.player = new Snake(this.world.GetBlocksSize(), this.world.GetWindowSize());
            hud = new HUD(this.WindowHandler.GetRenderWindow(), this.player, "Assets/Fonts/Last Ninja.ttf");
            this.WindowHandler.GetRenderWindow().Closed += OnCloseWindow;
            this.WindowHandler.GetRenderWindow().KeyPressed += OnPressKey;
        }

        protected override void Update(float deltaTime)
        {
            this.WindowHandler.Update();
            this.ProcessInput();
            float timestep = 1.0f / this.player.GetSpeed();
            if (!this.player.HasLost() && (this.DeltaTime.AsSeconds() >= timestep))
            {
                this.player.Tick();
                this.world.Update(ref this.player);
                this.DeltaTime = Time.FromSeconds(this.DeltaTime.AsSeconds() - timestep) ;
                if (this.player.HasLost())
                {
                    this.player.Reset();
                }
                this.hud.Update();
            }

            this.RestartClock();
        }

        protected override void Draw()
        {
            this.world.Render(this.WindowHandler.GetRenderWindow());
            this.player.Render(this.WindowHandler.GetRenderWindow());
            hud.Draw();
        }

        protected override void Finish()
        {
            this.WindowHandler.GetRenderWindow().Closed -= OnCloseWindow;
            this.WindowHandler.GetRenderWindow().KeyPressed -= OnPressKey;
        }
    }
}
