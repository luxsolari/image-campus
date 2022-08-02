using GameFinal.Handlers;
using GameFinal.UI;
using SFML.Graphics;
using SFML.System;

namespace GameFinal.States
{
    class MainMenuState : LoopState
    {
        private Font titleFont;
        private Text titleText;
        private Button playButton;
        private Button quitButton;

        public event Action OnPlayPressed;
        public event Action OnQuitPressed;


        public MainMenuState (WindowHandler window) : base(window) { }

        private void OnPressPlay () => OnPlayPressed?.Invoke();
        private void OnPressQuit () => OnQuitPressed?.Invoke();

        protected override void Start ()
        {
            string fontFilePath = "assets/Fonts/Last Ninja.ttf";
            string buttonImageFilePath = "assets/Images/Button.png";
            float firstButtonOffset = 100f;
            float buttonSpacing = 120f;

            titleFont = new Font(fontFilePath);
            titleText = new Text("One More Snake", titleFont);

            titleText.CharacterSize = 80;
            titleText.FillColor = Color.Blue;
            titleText.OutlineColor = Color.White;
            titleText.OutlineThickness = 2f;

            FloatRect titleRect = titleText.GetLocalBounds();

            titleText.Origin = new Vector2f(titleRect.Width / 2f, titleRect.Height / 2f);
            titleText.Position = new Vector2f(Globals.WindowWidthResolution / 2f, Globals.WindowHeightResolution / 2f - buttonSpacing);

            Vector2f playButtonPosition = new Vector2f(Globals.WindowWidthResolution / 2f, Globals.WindowHeightResolution / 2f + firstButtonOffset);
            Vector2f quitButtonPosition = new Vector2f(Globals.WindowWidthResolution / 2f, Globals.WindowHeightResolution / 2f + firstButtonOffset + buttonSpacing);

            playButton = new Button(this.WindowHandler.GetRenderWindow(), buttonImageFilePath, fontFilePath, playButtonPosition, "Play");
            quitButton = new Button(this.WindowHandler.GetRenderWindow(), buttonImageFilePath, fontFilePath, quitButtonPosition, "Quit");

            playButton.SetColor(Color.Green);
            quitButton.SetColor(Color.Green);

            playButton.FormatText(fillColor: Color.White, outlineColor: Color.Black, size: 30, outline: true, outlineThickness: 2f);
            quitButton.FormatText(fillColor: Color.White, outlineColor: Color.Black, size: 30, outline: true, outlineThickness: 2f);

            View view = new View(this.WindowHandler.GetRenderWindow().GetView());

            view.Center = new Vector2f(Globals.WindowWidthResolution / 2f, Globals.WindowHeightResolution / 2f);

            this.WindowHandler.GetRenderWindow().SetView(view);

            playButton.OnPressed += OnPressPlay;
            quitButton.OnPressed += OnPressQuit;
            this.WindowHandler.GetRenderWindow().Closed += OnCloseWindow;
        }

        protected override void Update (float deltaTime) { }

        protected override void Draw ()
        {
            this.WindowHandler.GetRenderWindow().Draw(titleText);
            playButton.Draw();
            quitButton.Draw();
        }

        protected override void Finish ()
        {
            playButton.OnPressed -= OnPressPlay;
            quitButton.OnPressed -= OnPressQuit;
            this.WindowHandler.GetRenderWindow().Closed -= OnCloseWindow;
        }
    }
}