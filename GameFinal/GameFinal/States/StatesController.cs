using GameFinal.Handlers;
using SFML.Graphics;

namespace GameFinal.States
{
    class StatesController
    {
        private WindowHandler window;
        private MainMenuState mainMenuState;
        private GameState gameState;


        public StatesController (WindowHandler window)
        {
            this.window = window;

            mainMenuState = new MainMenuState(window);
            gameState = new GameState(window);

            mainMenuState.OnPlayPressed += StartGame;
            mainMenuState.OnQuitPressed += QuitApplication;
            gameState.OnQuitPressed += QuitGame;

            mainMenuState.Play();
        }

        private void StartGame ()
        {
            mainMenuState.Stop();
            gameState.Play();
        }

        private void QuitGame ()
        {
            gameState.Stop();
            mainMenuState.Play();
        }

        private void QuitApplication ()
        {
            mainMenuState.Stop();
            window.GetRenderWindow().Close();
        }
    }
}