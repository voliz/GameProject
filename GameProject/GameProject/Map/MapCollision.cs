using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TiledSharp;

namespace GameProject.Map
{
    public class MapCollision
    {
        public void DrawLevelMap(SpriteBatch spriteBatch, MapDrawer _desiredMap)
        {
            _desiredMap.Draw(spriteBatch);
        }

        public List<Rectangle> GetTilesCollision(TmxMap _map, List<Rectangle> _collisionTiles)
        {
            foreach (var CollisionRect in _map.ObjectGroups["Collisions"].Objects)
            {
                if (CollisionRect.Name == "")
                {
                    _collisionTiles.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width - 10, (int)CollisionRect.Height - 10));
                }
            }
            return _collisionTiles;
        }

        public List<Rectangle> GetRespawnCollision(TmxMap _map, List<Rectangle> _collisionTiles)
        {
            foreach (var CollisionRect in _map.ObjectGroups["Collisions"].Objects)
            {
                if (CollisionRect.Name == "Respawn")
                {
                    _collisionTiles.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width - 10, (int)CollisionRect.Height));
                }
            }
            return _collisionTiles;
        }

        public List<Rectangle> GetEnemyPathWayCollision(TmxMap _map, List<Rectangle> _enemyPathway)
        {
            foreach (var CollisionRect in _map.ObjectGroups["EnemyPathWay"].Objects)
            {
                _enemyPathway.Add(new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width, (int)CollisionRect.Height));
            }

            return _enemyPathway;
        }
        public Rectangle GetEndCollision(TmxMap _map, Rectangle _endRect)
        {
            foreach (var CollisionRect in _map.ObjectGroups["Collisions"].Objects)
            {
                if (CollisionRect.Name == "END")
                {
                    _endRect = new Rectangle((int)CollisionRect.X, (int)CollisionRect.Y, (int)CollisionRect.Width - 10, (int)CollisionRect.Height);
                }
            }
            return _endRect;
        }
    }
}
