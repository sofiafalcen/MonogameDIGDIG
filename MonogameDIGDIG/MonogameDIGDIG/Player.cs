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
            position = new Vector2(100, 400);
            moveDir = new Vector2(1, 1);
            speed = 300;
            rotation = 0;
            scale = new Vector2(0.12f, 0.2f);
            triangleColor = Color.White;
            offset = (triangleTexture.Bounds.Size.ToVector2() / 2.0f) * scale;
            triangleRectangle = new Rectangle((position - offset).ToPoint(), (triangleTexture.Bounds.Size.ToVector2() * scale).ToPoint());
        }

        public void Update(GameTime gameTime)
        {
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
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
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Draw(triangleTexture, position, null, triangleColor, rotation, offset, scale, SpriteEffects.None, 0);

        }
    }
}
