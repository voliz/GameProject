using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace GameProject.Menu
{
    public class MenuState : GameScreen
    {
        private List<MenuComponent> _components;
        public SpriteBatch _spriteBatch;
        private new Game1 Game => (Game1)base.Game;

        public MenuState(Game game) : base(game)
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var buttonTexture = game.Content.Load<Texture2D>("Controls/ButtonImage");
            var buttonFont = game.Content.Load<SpriteFont>("Fonts/Font");

            var Level1button = new MenuButton(buttonTexture, buttonFont) { Position = new Vector2(300, 150), Text = "START LVL 1", };
            var Level2button = new MenuButton(buttonTexture, buttonFont) { Position = new Vector2(300, 200), Text = "START LVL 2", };
            var level3button = new MenuButton(buttonTexture, buttonFont) { Position = new Vector2(300, 250), Text = "START LVL 3", };

            Level1button.Click += Level1Button_click;
            Level2button.Click += Level2Button_click;
            level3button.Click += Level3button_Click;

            _components = new List<MenuComponent> { Level1button, Level2button, level3button };

        }
        private void Level1Button_click(object sender, EventArgs e) { this.Game.StateOfGame = currentGameState.level1; }
        private void Level2Button_click(object sender, EventArgs e) { this.Game.StateOfGame = currentGameState.level2; }
        private void Level3button_Click(object sender, EventArgs e) { this.Game.StateOfGame = currentGameState.level3; }

        public override void Draw(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Draw(_spriteBatch, gameTime);
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}
