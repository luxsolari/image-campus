using GameFinal.Handlers;
using SFML.Graphics;
using SFML.System;

namespace GameFinal.States
{
    abstract class LoopState
    {
        public WindowHandler WindowHandler { get; set; }
        private bool isRunning;


        public LoopState (WindowHandler window)
        {
            this.WindowHandler = window;
        }

        protected virtual void OnCloseWindow (object sender, EventArgs e)
        {
            isRunning = false;
            this.WindowHandler.GetRenderWindow().Close();
        }

        protected abstract void Start ();
        protected abstract void Update (float deltaTime);
        protected abstract void Draw ();
        protected abstract void Finish ();

        public void Play ()
        {
            Clock clock = new Clock();

            isRunning = true;

            Start();

            while (isRunning)
            {
                Time deltaTime = clock.Restart();

                this.WindowHandler.GetRenderWindow().DispatchEvents();

                Update(deltaTime.AsSeconds());

                this.WindowHandler.GetRenderWindow().Clear(new Color(36, 36, 36));
                Draw();
                this.WindowHandler.GetRenderWindow().Display();
            }

            Finish();
        }

        public void Stop ()
        {
            if (!isRunning)
            {
                Console.WriteLine("Cannot stop a state that is not running.");
                return;
            }

            isRunning = false;

            Finish();
        }
    }
}