using System;
using SFML.System;
using SFML.Graphics;

namespace Game
{
    class GameLoop
    {
        private RenderWindow window;
        private bool isRunning;
        private Player player;

        public GameLoop (RenderWindow window)
        {
            this.window = window;
        }

        private void Start()
        {
            Console.WriteLine("Se inicio el loop");
            Vector2u windowSize = window.Size;
            Vector2f playerPosition = new Vector2f(windowSize.X / 2f, windowSize.Y / 2f);

            // Instanciamos un player de ejemplo
            player = new Player(playerPosition, Color.Red, Color.White, 1.5f, 150f, 128f);
            player.Graphic.Position = new Vector2f(playerPosition.X - player.Graphic.Radius, playerPosition.Y - player.Graphic.Radius);

            // Suscripcion a evento
            window.Closed += OnCloseWindow;
        }


        // 1. Capturar input ProcessInput
        private void ProcessInput()
        {
            window.DispatchEvents();
        }

        // 2. Update() actualizar frame
        private void Update(Time deltaTime)
        {
            player.Update(deltaTime.AsSeconds());
            Console.WriteLine("Delta time: " + deltaTime.AsMilliseconds() + " ms.");
        }

        // 3. Draw() dibujar frame en pantalla
        private void Draw()
        {
            window.Clear(Color.Black);
            window.Draw(player.Graphic);
            window.Display();
        }

        private void Finish()
        {
            Console.WriteLine("Se termino el loop");

            // Des-Suscripcion de un evento
            window.Closed -= OnCloseWindow;
        }

        private void OnCloseWindow(Object sender, EventArgs e)
        {
            isRunning = false;
            window.Close();
        }

        public void Play()
        {
            Clock clock = new Clock();
            isRunning = true;
            
            Start();

            while (isRunning)
            {
                Time deltaTime = clock.Restart();
                
                ProcessInput();
                Update(deltaTime);
                Draw();

            }

            Finish();
        }
    }
}
