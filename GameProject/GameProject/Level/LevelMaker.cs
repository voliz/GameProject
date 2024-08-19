using GameProject.Map;
using GameProject.Objects.Non_Playable_Characters;
using GameProject.Objects;
using GameProject.Objects.Playable_Characters;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TiledSharp;
using MonoGame.Extended.Screens;
using System.Diagnostics;

namespace GameProject.Level
{
    public abstract class LevelMaker : GameScreen, IPlayerConditionCheck
    {
        public LevelMaker(Game game) : base(game) { }
        public SpriteBatch _spriteBatch { get; set; }


        public Texture2D _projectileTexture { get; set; }
        public List<Projectile> _projectiles { get; set; } = new List<Projectile>();
        public int _time_x_projectile { get; set; } = 0;


        public Player Player { get; set; }
        public Vector2 PlayerInitPosition { get; set; }

        public Vector2 EnemyInitPos { get; set; }

        public Enemy npc1 { get; set; }
        public Enemy npc2 { get; set; }
        public Enemy npc3 { get; set; }
        public List<Rectangle> EnemyPathWay { get; set; } = new List<Rectangle>();
        public List<Enemy> _enemyList { get; set; } = new List<Enemy>();

        public TmxMap _map { get; set; }
        public Texture2D _tileset { get; set; }
        public MapDrawer _mapMaker { get; set; }

        public List<Rectangle> CollisionTiles { get; set; } = new List<Rectangle>();
        public List<Rectangle> RespawnZone { get; set; } = new List<Rectangle>();

        public Rectangle EndZone { get; set; } = new Rectangle();
        public MapCollision _collisionController { get; set; } = new MapCollision();
        public LevelInteraction LevelCollisionControler { get; set; } = new LevelInteraction();

        public List<BuffItem> _buffItemList { get; set; } = new List<BuffItem>();
        public BuffItem _buffItem { get; set; }


        public bool PlayerIsAlive { get; set; }
        public bool GameIsOver { get; set; }



        public void GetCollisionOfMap()
        {
            CollisionTiles = _collisionController.GetTilesCollision(_map, CollisionTiles);
            EnemyPathWay = _collisionController.GetEnemyPathWayCollision(_map, EnemyPathWay);
            RespawnZone = _collisionController.GetRespawnCollision(_map, RespawnZone);
            EndZone = _collisionController.GetEndCollision(_map, EndZone);
        }

        public void DrawTheLevel(GameTime gameTime, Vector2 hpPos, Vector2 score, Color color, bool showpoints)
        {
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _collisionController.DrawLevelMap(_spriteBatch, _mapMaker); 

            _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"HP: {Player.Health}", score, color);
            if (showpoints)
                _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"POINTS: {Player.Points}", hpPos, color);

            if (_buffItemList.Count > 0)
                _spriteBatch.DrawString(Content.Load<SpriteFont>("Fonts\\Font"), $"Item", new Vector2(RespawnZone[1].X - 10, RespawnZone[1].Y - 20), Color.White);

            Player.Draw(_spriteBatch, gameTime);
            
            foreach (var enemy in _enemyList) { enemy.Draw(_spriteBatch, gameTime); }           
            foreach (var projectile in _projectiles.ToArray()) { projectile.Draw(_spriteBatch, gameTime); }
            foreach (var buffitem in _buffItemList) { buffitem.Draw(_spriteBatch, gameTime); }

            _spriteBatch.End();
        }

        public void UpdateTheLevel(GameTime gameTime, Game1 Game, int NextState, int buffSpeed)
        {
            LevelCollisionControler.GetPlayerToNextZone(Player, EndZone, Game, NextState);
            LevelCollisionControler.GetItemBuff(_buffItemList, Player, buffSpeed);
            EnemyInitPos = LevelCollisionControler.GetEnemyPosition(_enemyList, EnemyInitPos);
            PlayerInitPosition = Player.Position;

            Player.Update(gameTime);
            LevelCollisionControler.GetPlayerLifeCondition(Player, _enemyList, gameTime);

            LevelCollisionControler.GetPlayerCollides(Player, CollisionTiles, PlayerInitPosition);
            LevelCollisionControler.GetProjectileCollides(Player, _projectiles, _enemyList, CollisionTiles, gameTime);
            LevelCollisionControler.GetEnemyCollides(CollisionTiles, _enemyList, EnemyInitPos);
            LevelCollisionControler.GetProjectiles(_projectiles, Player, _time_x_projectile, _projectileTexture, this);

            LevelCollisionControler.GetPlayerGameState(Player, Game);
        }
    }
}
