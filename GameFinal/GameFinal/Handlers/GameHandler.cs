using GameFinal.Entities;
using SFML.System;
using SFML.Window;

namespace GameFinal.Handlers
{
    internal class GameHandler
    {
        public WindowHandler WindowHandler { get; }
        private World world;
        private Snake snake;
        public Clock Clock { get; } = new Clock();
        public Time DeltaTime { get; set; }

        public GameHandler()
        {
            this.WindowHandler = new WindowHandler("One More Snake", new Vector2u(640, 480));
            this.world = new World(new Vector2u(640, 480), 20);
            this.snake = new Snake(this.world.GetBlocksSize(), this.world.GetWindowSize());
        }

        public void ProcessInput()
        {
            this.WindowHandler.DispatchEvents();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Up) && this.snake.GetPhysicalDirection() != Direction.Down)
            {
                this.snake.SetDirection(Direction.Up);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Down) && this.snake.GetPhysicalDirection() != Direction.Up)
            {
                this.snake.SetDirection(Direction.Down);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Left) && this.snake.GetPhysicalDirection() != Direction.Right)
            {
                this.snake.SetDirection(Direction.Left);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.Right) && this.snake.GetPhysicalDirection() != Direction.Left)
            {
                this.snake.SetDirection(Direction.Right);
            }
        }

        public void Update()
        {
            this.WindowHandler.Update();
            float timestep = 1.0f / this.snake.GetSpeed();
            if (this.DeltaTime.AsSeconds() >= timestep)
            {
                this.snake.Tick();
                this.world.Update(ref this.snake);
                this.DeltaTime = Time.FromSeconds(this.DeltaTime.AsSeconds() - timestep) ;
                if (this.snake.HasLost())
                {
                    this.snake.Reset();
                }
            }

        }

        public void Render()
        {
            this.WindowHandler.StartDraw();
            this.world.Render(this.WindowHandler.GetRenderWindow());
            this.snake.Render(this.WindowHandler.GetRenderWindow());
            this.WindowHandler.FinishDraw();
        }

        public void RestartClock()
        {
            this.DeltaTime += this.Clock.Restart();
        }
        
        

        ~GameHandler()
        {
            
        }

    }
}
