using GameFinal.Entities;
using SFML.Graphics;
using SFML.System;

namespace GameFinal.UI
{
    class HUD
    {
        private readonly RenderWindow window;
        private readonly Snake player;
        private Font font;
        private Text livesText;
        private Text scoreText;

        private const string LivesLabel = "Lives: ";
        private const string ScoreLabel = "Score: ";
        private const float MarginSize = 25f;


        public HUD (RenderWindow window, Snake player, string fontFilePath)
        {
            this.window = window;
            this.player = player;
            
            font = new Font(fontFilePath);

            livesText = new Text(LivesLabel + player.GetLives(), font);
            scoreText = new Text(ScoreLabel + player.GetScore(), font);

            livesText.FillColor = Color.White;
            livesText.OutlineColor = Color.Red;
            livesText.OutlineThickness = 3f;            
            
            scoreText.FillColor = Color.White;
            scoreText.OutlineColor = Color.Blue;
            scoreText.OutlineThickness = 3f;
        }

        public void Update ()
        {
            View view = window.GetView();
            float scoreWidth = scoreText.GetGlobalBounds().Width;
            Vector2f center = view.Center;
            Vector2f windowHalfSize = new Vector2f(Globals.WindowWidthResolution / 2f, Globals.WindowHeightResolution / 2f);
            Vector2f livesOffset = new Vector2f(-windowHalfSize.X + MarginSize, -windowHalfSize.Y + MarginSize);
            Vector2f scoreOffset = new Vector2f(windowHalfSize.X - MarginSize - scoreWidth, -windowHalfSize.Y + MarginSize);

            livesText.Position = center + livesOffset;
            scoreText.Position = center + scoreOffset;

            livesText.DisplayedString = LivesLabel + player.GetLives();
            scoreText.DisplayedString = ScoreLabel + player.GetScore();
        }

        public void Draw ()
        {
            window.Draw(livesText);
            window.Draw(scoreText);
        }
    }
}
