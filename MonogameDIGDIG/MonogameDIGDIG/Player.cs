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
 
        Texture2D triangleTexture;
        Rectangle triangleRectangle;
        Vector2 moveDir;
        Vector2 position;
        Vector2 scale;
        Vector2 offset;
        Color triangleColor;
        float speed;
        float rotation;

        public Player (Texture2D playerTexture)
        {
            triangleTexture = playerTexture;
            position = new Vector2(100, 100);
            moveDir = new Vector2(1, 1);
            speed = 300;
            rotation = 0;
            scale = new Vector2(1, 1);
            triangleColor = Color.White;
            offset = (triangleTexture.Bounds.Size.ToVector2() / 2.0f) * scale;
            triangleRectangle = new Rectangle((position - offset).ToPoint(), (triangleTexture.Bounds.Size.ToVector2() * scale).ToPoint());
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            MouseState mouseState = Mouse.GetState();
            Vector2 mousePos = mouseState.Position.ToVector2();
            moveDir = mousePos - position;
            float pixelsToMove = speed * deltaTime;
            if (moveDir != Vector2.Zero)
            {
                moveDir.Normalize();
                rotation = (float)Math.Atan2(moveDir.Y, moveDir.X);
                if (Vector2.Distance(position, mousePos) < pixelsToMove)
                {
                    position = mousePos;
                }
                else
                {
                    position += moveDir * pixelsToMove;
                }
                triangleRectangle.Location = (position - offset).ToPoint();
            }


            triangleColor = Color.White;

        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
        
            spriteBatch.Draw(triangleTexture, position, null, triangleColor, rotation, offset, scale, SpriteEffects.None, 0);

        }
    }
}
