using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameDIGDIG
{
    class Enemy
    {
        Texture2D texture;
        Rectangle rectangle;
        Vector2 moveDir;
        Vector2 position;
        Vector2 scale;
        Vector2 offset;
        Color color;
        float speed;
        float rotation;
        float health;
        bool alive;



        public Enemy(Texture2D enemyTexture, Vector2 enemyStartPos, float enemySpeed, Vector2 enemyScale, float enemyRotation, Color enemyColor, float enemyHealth)
        {
            texture = enemyTexture;
            position = enemyStartPos;
            speed = enemySpeed;
            moveDir = Vector2.Zero;
            scale = enemyScale;
            offset = (enemyTexture.Bounds.Size.ToVector2() / 2.0f) * scale;
            rectangle = new Rectangle((enemyStartPos).ToPoint(), (enemyTexture.Bounds.Size.ToVector2() * enemyScale).ToPoint());
            color = enemyColor;
            rotation = enemyRotation;
            health = enemyHealth;
            alive = true;
        }

        public void Update(GameTime gameTime, Player player, int windowHeight)
        {

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float pixelsToMove = speed * deltaTime;
            moveDir.Y = 1;
            moveDir.Normalize();
            position += moveDir * pixelsToMove;
            rectangle.Location = position.ToPoint();
            rectangle.Offset(-offset);

            if(rectangle.Intersects(player.GetRectangle()) == true)
            {
                player.Damage(10f);
            }


        }

        public void ChangeHealth(float healthMod)
        {
            health += healthMod;
            if (health <= 0)
            {
                alive = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, color, rotation, offset, scale, SpriteEffects.None, 0);
        }

        public Rectangle GetRectangle()
        {
            return rectangle;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public bool GetIsAlive()
        {
            return alive;
        }

        public void SetAlive(bool isAlive)
        {
            alive = isAlive;
        }

    }
}
