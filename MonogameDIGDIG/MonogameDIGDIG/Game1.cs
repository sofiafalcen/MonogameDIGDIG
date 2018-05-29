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
        float spawnTimer = 0;
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

            player = new Player(triangleTexture, new Vector2(0, 400), 500, new Vector2(0.1f, 0.1f), 0, Color.White, 100, 1);
            enemy = new Enemy(TextureLibrary.GetTexture("enemy"), new Vector2(Randomizer.GetRandom(Window.ClientBounds.Width), -TextureLibrary.GetTexture("enemy").Height), 300, new Vector2(0.5f, 0.5f), 0, Color.White, 100);
            enemies = new List<Enemy>();

            IsMouseVisible = true;
            speed = 300;
            triangleRectangle = triangleTexture.Bounds;

            BulletManager.SetWindowsize(Window.ClientBounds.Size);
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
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            spawnTimer += deltaTime;

            if(spawnTimer >= 2)
            {
                Enemy tempEnemy = new Enemy(TextureLibrary.GetTexture("enemy"), new Vector2(Randomizer.GetRandom(Window.ClientBounds.Width), -TextureLibrary.GetTexture("enemy").Height), 300, new Vector2(0.5f, 0.5f), 0, Color.White, 100);
                enemies.Add(tempEnemy);
                spawnTimer = 0;
            }

            player.Update(deltaTime, Keyboard.GetState(), Mouse.GetState(), Window.ClientBounds.Size);
            enemy.Update(gameTime, player, Window.ClientBounds.Height);

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Update(gameTime, player, Window.ClientBounds.Height);

                if(enemies[i].GetIsAlive() == false || enemies[i].GetPosition().Y >= Window.ClientBounds.Height)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
            }

            BulletManager.Update(deltaTime, player, enemies);
            base.Update(gameTime);
           
        }

      
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);

            for (int i = 0; i < enemies.Count; i++)
            {
                enemies[i].Draw(spriteBatch);
            }

            BulletManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
