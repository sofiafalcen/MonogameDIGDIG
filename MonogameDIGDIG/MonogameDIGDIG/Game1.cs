using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace MonogameDIGDIG
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D triangleTexture;
        Rectangle triangleRectangle;
        Vector2 moveDir;
        Player player;
        Random random;
        float speed;

        int numEnemies;
        List<Enemy> enemies;
        Dictionary<string, Texture2D> textures;

     
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

      
        protected override void Initialize()
        {
            base.Initialize();
            IsMouseVisible = true;
            speed = 300;
            triangleRectangle = triangleTexture.Bounds;
            player = new Player(triangleTexture);
          
      
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            triangleTexture = Content.Load<Texture2D>("triangle");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            base.Update(gameTime);

        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
