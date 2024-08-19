using GameProject.Level;
using GameProject.Menu;
using GameProject.Objects;
using GameProject.Objects.Playable_Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Screens;
using MonoGame.Extended.Screens.Transitions;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameProject
{
    public class Game1 : Game, GameState
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ScreenManager _screenManager;

        public currentGameState StateOfGame { get; set; }
        public currentPlayerState StateOfPlayer { get; set; }
        public currentGameState PreviousStateOfGame { get; set; }
        public Player Player { get; set; }
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;


            _screenManager = new ScreenManager();
            Components.Add(_screenManager);
        }
        protected override void Initialize()
        {
            base.Initialize();
            StateOfGame = currentGameState.Menu;
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void Update(GameTime gameTime)
        {

            if (PreviousStateOfGame != StateOfGame)
                switch (StateOfGame)
                {
                    case currentGameState.level1:
                        _screenManager.LoadScreen(new Level1(this), new FadeTransition(GraphicsDevice, Color.Black));
                        break;
                    case currentGameState.level2:
                        _screenManager.LoadScreen(new Level2(this), new FadeTransition(GraphicsDevice, Color.Black));
                        break;
                    case currentGameState.level3:
                        _screenManager.LoadScreen(new Level3(this), new FadeTransition(GraphicsDevice, Color.Black));
                        break;
                    case currentGameState.Menu:
                        _screenManager.LoadScreen(new MenuState(this), new FadeTransition(GraphicsDevice, Color.Black));
                        break;
                    case currentGameState.GameOver:
                        _screenManager.LoadScreen(new GameOverPanel(this), new FadeTransition(GraphicsDevice, Color.Black));
                        break;
                    default:
                        break;
                }

            PreviousStateOfGame = StateOfGame;

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            if (StateOfGame == currentGameState.GameOver)
                if (StateOfPlayer == currentPlayerState.Win)
                    _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"You WIN", new Vector2(330, 150), Color.Green);
                else
                    _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"You Lost", new Vector2(330, 150), Color.Red);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
