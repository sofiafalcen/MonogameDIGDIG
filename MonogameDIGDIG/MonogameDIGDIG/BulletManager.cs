using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameDIGDIG
{
    static class BulletManager
    {
        static List<Bullet> bullets = new List<Bullet>();
        static Point windowSize;

        public static void AddBullet(Texture2D texture, Vector2 startPosition, Vector2 dir, float speed, Vector2 scale, Owner owner, Color color)
        {
            bullets.Add(new Bullet(texture, startPosition, dir, speed, scale, owner, Color.White, windowSize));
        }

        public static void Update(float deltaTime, Player player, List<Enemy> enemies)
        {
            for(int i = bullets.Count - 1; i >= 0; i--)
            { 
                if (bullets[i].GetIsAlive())
                {
                    bullets[i].Update(deltaTime);
                    Owner owner = bullets[i].GetOwner();
                    float damage = 0;
                    switch(owner)
                    {
                        case Owner.Player:
                            for(int j = 0; j < enemies.Count; j++)
                            {
                                damage = bullets[i].Damage(enemies[j].GetRectangle());
                                if (damage > 0)
                                {
                                    enemies[i].SetAlive(false);
                                }
                            }
                        break;
                    }
                }
                else
                {
                    bullets.RemoveAt(i);
                }
            }
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Draw(spriteBatch);
            }
        }

        public static void SetWindowsize(Point aWindowSize)
        {
            windowSize = aWindowSize;
        }

    }
    
}
