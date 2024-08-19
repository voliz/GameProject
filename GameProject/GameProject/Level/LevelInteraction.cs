using GameProject.Objects.Non_Playable_Characters;
using GameProject.Objects.Playable_Characters;
using GameProject.Objects;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Level
{
    public class LevelInteraction
    {
        public void GetPlayerToNextZone(Player Player, Rectangle EndZone, Game1 Game, int DesiredLVL)
        {
            if (EndZone.Intersects(Player.Hitbox))
            {
                switch (DesiredLVL)
                {
                    case 0:
                        Game.StateOfPlayer = Menu.currentPlayerState.Win;
                        Game.StateOfGame = Menu.currentGameState.GameOver;
                        break;
                    case 1:
                        Game.StateOfGame = Menu.currentGameState.level1;
                        break;
                    case 2:
                        Game.StateOfGame = Menu.currentGameState.level2;
                        break;
                    case 3:
                        Game.StateOfGame = Menu.currentGameState.level3;
                        break;
                    default:
                        break;
                }
            }

        }
        public void GetEndzone(Player Player, Rectangle EndZone, Game1 Game)
        {
            if (EndZone.Intersects(Player.Hitbox)) { Game.StateOfGame = Menu.currentGameState.GameOver; }

        }
        public Vector2 GetEnemyPosition(List<Enemy> EnemyList, Vector2 enemyInitPost)
        {
            if (EnemyList.Count > 0) { return EnemyList.Last().Position; }
            else { return new Vector2(); }


        }
        public void GetPlayerLifeCondition(Player Player, List<Enemy> EnemyList, GameTime gameTime)
        {
            foreach (var Enemy in EnemyList)
            {
                Enemy.Update(gameTime);

                if (Player.TouchedEnemy(EnemyList))
                {
                    Player.TimeXAttacking++;
                    if (Player.TimeXAttacking > Player.Time_x_hurt)
                    {
                        Player.Health--;
                        if (Player.Health == 0) Player.IsAlive = false;

                        Player.TimeXAttacking = 0;
                    }
                }
            }
        }
        public void GetPlayerCollides(Player Player, List<Rectangle> _collisionTiles, Vector2 PlayerInitPosition)
        {
            foreach (var rectangle in _collisionTiles)
            {
                if (rectangle.Intersects(Player.Hitbox))
                {
                    Player.Position.X = PlayerInitPosition.X;
                    Player.Position.Y = PlayerInitPosition.Y;
                    break;
                }

            }

        }
        public void GetProjectileCollides(Player player, List<Projectile> projectiles, List<Enemy> EnemyList, List<Rectangle> CollisionTiles, GameTime GameTime)
        {
            foreach (var projectile in projectiles.ToArray())
            {
                projectile.Update(GameTime);

                foreach (var rect in CollisionTiles)
                {
                    if (rect.Intersects(projectile.Hitbox))
                    {
                        projectiles.Remove(projectile);
                        break;
                    }
                }
                foreach (var enemy in EnemyList.ToArray())
                {
                    if (projectile.Hitbox.Intersects(enemy.Hitbox))
                    {
                        EnemyList.Remove(enemy);
                        projectiles.Remove(projectile);
                        player.Points++;
                        break;
                    }
                }

            }
        }
        public void GetEnemyCollides(List<Rectangle> _collisionTiles, List<Enemy> _enemyList, Vector2 EnemyInitPos)
        {
            foreach (var rect in _collisionTiles)
            {
                foreach (var enemy in _enemyList)
                {

                    if (rect.Intersects(enemy.Hitbox))
                    {
                        if (enemy.IsInteligent)
                        {
                            if (enemy.IsAlive)
                            {
                                enemy.Position.X = EnemyInitPos.X;
                                enemy.Position.Y = EnemyInitPos.Y;
                            }
                        }
                        break;
                    }
                }
            }

        }

        public void GetProjectiles(List<Projectile> _projectiles, Player Player, int _time_x_projectile, Texture2D _projectileTexture, LevelMaker lvl)
        {
            if (Player.IsShooting && _projectiles.ToArray().Length < 20)
            {
                if (_time_x_projectile > 5)
                {
                    if (Player.SpriteMoveDirection == SpriteEffects.None)
                    {
                        _projectiles.Add(new Projectile(_projectileTexture, new Vector2((int)Player.Position.X + 13, (int)Player.Position.Y + 16), 4));
                        lvl._projectiles.Add(new Projectile(_projectileTexture, new Vector2((int)Player.Position.X + 13, (int)Player.Position.Y + 16), 4));
                    }
                    else if (Player.SpriteMoveDirection == SpriteEffects.FlipHorizontally)
                    {
                        _projectiles.Add(new Projectile(_projectileTexture, new Vector2((int)Player.Position.X + 13, (int)Player.Position.Y + 16), -4));
                    }
                    lvl._time_x_projectile = 0;
                }
                else
                {
                    lvl._time_x_projectile++;
                }

            }



        }

        public void GetItemBuff(List<BuffItem> _buffItemList, Player Player, int buff)
        {
            foreach (var item in _buffItemList.ToArray())
            {
                if (Player.Hitbox.Intersects(item.Hitbox))
                {
                    Player.Speed += buff;
                    Player._touchedBuff = true;
                    _buffItemList.Remove(item);
                }

            }
        }

        public void GetPlayerGameState(Player player, Game1 Game)
        {
            if (!player.IsAlive)
            {
                Game.StateOfGame = Menu.currentGameState.GameOver;
                Game.StateOfPlayer = Menu.currentPlayerState.Lost;
            }

            if (player.Points == 3)
            {
                Game.StateOfGame = Menu.currentGameState.GameOver;
                Game.StateOfPlayer = Menu.currentPlayerState.Win;
            }
        }

    }
}
