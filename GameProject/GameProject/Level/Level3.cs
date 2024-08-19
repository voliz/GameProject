using GameProject.Map;
using GameProject.Objects.Non_Playable_Characters;
using GameProject.Objects.Playable_Characters;
using GameProject.Objects;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;

namespace GameProject.Level
{
    public class Level3 : LevelMaker
    {
        private new Game1 Game => (Game1)base.Game;
        public Level3(Game game) : base(game) { }

        public override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _map = new TmxMap("Content\\Level3.tmx");
            _tileset = Content.Load<Texture2D>("TileMap\\" + _map.Tilesets[0].Name.ToString());
            _mapMaker = new MapDrawer(_map, _tileset);

            GetCollisionOfMap();
            Player = new Player(new Vector2(RespawnZone[0].X, RespawnZone[0].Y),
            Content.Load<Texture2D>("Player\\wizardRunDown"), Content.Load<Texture2D>("Player\\wizardRunUp"),
              Content.Load<Texture2D>("Player\\wizardRunRight"), Content.Load<Texture2D>("Player\\wizardShootDown"), Content.Load<Texture2D>("Player\\wizardShootUp"), Content.Load<Texture2D>("Player\\wizardShootRight"), true);
            _projectileTexture = Content.Load<Texture2D>("Fire Missile");
            _enemyList.Add(new Enemy(Content.Load<Texture2D>("Enemy1"), EnemyPathWay[0], 1f, false, Player, new Vector2()));
            _enemyList.Add(new Enemy(Content.Load<Texture2D>("Enemy2"), new Rectangle(), 2f, true, Player, new Vector2(RespawnZone[1].X, RespawnZone[1].Y)));
            _enemyList.Add(new Enemy(Content.Load<Texture2D>("Enemy3"), EnemyPathWay[1], 1f, false, Player, new Vector2()));
            _buffItemList.Add(new BuffItem(Content.Load<Texture2D>("Health_Kit"), new Vector2(RespawnZone[1].X, RespawnZone[1].Y), 0));

        }

        public override void Draw(GameTime gameTime)
        {
            DrawTheLevel(gameTime, new Vector2(50, 180), new Vector2(50, 200), Color.Red, true);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateTheLevel(gameTime, this.Game, 4, 2);
        }
    }
}
