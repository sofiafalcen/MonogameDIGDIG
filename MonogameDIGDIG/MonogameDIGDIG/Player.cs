using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonogameDIGDIG
{
    class Player
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
        bool alive = true;
        MouseState prevMouseState;

        public Player (Texture2D playerTexture, Vector2 playerStartPos, float playerSpeed, Vector2 playerScale, float playerRotation, Color playerColor, float playerHealth)
        {
            texture = playerTexture;
            position = playerStartPos;
            speed = playerSpeed;
            moveDir = Vector2.Zero;
            scale = playerScale;
            offset = (playerTexture.Bounds.Size.ToVector2() / 2.0f) * scale;
            rectangle = new Rectangle((position - offset).ToPoint(), (playerTexture.Bounds.Size.ToVector2() * scale).ToPoint());
            color = playerColor;
            rotation = playerRotation;
            health = playerHealth;
            alive = true;
            prevMouseState = Mouse.GetState();
        }

        public void Update(float deltaTime, KeyboardState keyboardState, MouseState mouseState, Point windowSize)
        {
            if (alive)
            {
                //float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
                //KeyboardState keyboardState = Keyboard.GetState();
                moveDir = new Vector2();
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    moveDir.X = 1;
                }
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    moveDir.X = -1;
                }
                if (moveDir != Vector2.Zero)
                {
                    moveDir.Normalize();

                    position += moveDir * speed * deltaTime;
                }

                if (mouseState.LeftButton == ButtonState.Pressed && prevMouseState.LeftButton == ButtonState.Released)
                {
                    Vector2 bulletDir = mouseState.Position.ToVector2() - position;
                    BulletManager.AddBullet(TextureLibrary.GetTexture("bullet"), position, bulletDir, 400, new Vector2(0.2f, 0.2f), Bullet.Owner.Player, color);
                }
            }
            else
            {
                color = Color.Black;
            }

            prevMouseState = mouseState;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, null, color, rotation, offset, scale, SpriteEffects.None, 0);

        }
    }
}
