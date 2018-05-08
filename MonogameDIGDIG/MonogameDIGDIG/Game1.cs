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

        Texture2D bulletTexture;
        Rectangle bulletRectangle;
        Texture2D enemyTexture;

        Vector2 moveDir;
        Player player;
        Enemy enemy;
        Random random;
        float speed;


        int numEnemies;
        List<Enemy> enemies;
        Dictionary<string, Texture2D> textures;

     
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            TextureLibrary.Init(Content);
        }

      
        protected override void Initialize()
        {
            base.Initialize();

            Randomizer.Init();

            player = new Player(triangleTexture, new Vector2(400, 415), 500, new Vector2(0.1f, 0.15f), 0, Color.White, 100, 100);
            enemy = new Enemy(TextureLibrary.GetTexture("enemy"), new Vector2(Randomizer.GetRandom(Window.ClientBounds.Width), -TextureLibrary.GetTexture("enemy").Height), 300, new Vector2(0.5f, 0.5f), 0, Color.White);

            IsMouseVisible = true;
            speed = 300;
            triangleRectangle = triangleTexture.Bounds;

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            triangleTexture = Content.Load<Texture2D>("triangle");


            TextureLibrary.LoadTexture("triangle");

        
            TextureLibrary.LoadTexture("bullet");

             
            TextureLibrary.LoadTexture("enemy");
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
        
        protected override void Update(GameTime gameTime)
        {
            player.Update((float)gameTime.ElapsedGameTime.TotalSeconds, Keyboard.GetState(), Mouse.GetState(), Window.ClientBounds.Size);
            enemy.Update(gameTime, player);
            base.Update(gameTime);

        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);

            BulletManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
