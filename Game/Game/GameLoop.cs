using System;
using SFML.System;
using SFML.Graphics;

namespace Game
{
    class GameLoop
    {
        private RenderWindow window;
        private bool isRunning;
        private Entity player;

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
            //player = new Player(playerPosition, Color.Red, Color.White, 1.5f, 150f, 100f);
            //player.Graphic.Position = new Vector2f(playerPosition.X - player.Graphic.Radius, playerPosition.Y - player.Graphic.Radius);

            player = new Entity("assets/images/player.png");
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
            Thread.Sleep(12); 
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
            int framesRendered = 0;
            float elapsedTime = 0;
            
            Start();

            while (isRunning)
            {
                Time deltaTime = clock.Restart();
                ProcessInput();
                Update(deltaTime);
                Draw();
                framesRendered ++;
                elapsedTime += deltaTime.AsSeconds();

                if (elapsedTime >= 1.0f) // un segundo pasó, mostramos el conteo de FPS.
                {
                    Console.SetCursorPosition(0, 1);
                    Console.Write($"FPS: {(int)(framesRendered / elapsedTime)}");
                    Console.WriteLine();
                    elapsedTime = 0;
                    framesRendered = 0;
                }
                
            }

            Finish();
        }
    }
}
