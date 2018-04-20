using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameDIGDIG
{
    class MOUSESTUFFTHINGSFOLLOW
    {
        //    {
        //GraphicsDeviceManager graphics;
        //SpriteBatch spriteBatch;
        //Texture2D triangleTexture;
        //Player player;
        //Random random;
        //Rectangle triangleRectangle;
        //Vector2 moveDir;
        //Vector2 position;
        //Vector2 scale;
        //Vector2 offset;
        //Color triangleColor;
        //float speed;
        //float rotation;



        //int numEnemies;
        //List<Enemy> enemies;
        //Dictionary<string, Texture2D> textures;


        //public Game1()
        //{
        //    graphics = new GraphicsDeviceManager(this);
        //    Content.RootDirectory = "Content";
        //}


        //protected override void Initialize()
        //{
        //    base.Initialize();
        //    IsMouseVisible = true;
        //    position = new Vector2(100, 100);
        //    moveDir = new Vector2(1, 1);
        //    speed = 300;
        //    rotation = 0;
        //    scale = new Vector2(1, 1);
        //    triangleColor = Color.White;
        //    offset = (triangleTexture.Bounds.Size.ToVector2() / 2.0f) * scale;
        //    triangleRectangle = new Rectangle((position - offset).ToPoint(), (triangleTexture.Bounds.Size.ToVector2() * scale).ToPoint());

        //}

        //protected override void LoadContent()
        //{
        //    spriteBatch = new SpriteBatch(GraphicsDevice);

        //    triangleTexture = Content.Load<Texture2D>("triangle");
        //}

        //protected override void UnloadContent()
        //{
        //    // TODO: Unload any non ContentManager content here
        //}

        //protected override void Update(GameTime gameTime)
        //{
        //    float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
        //    MouseState mouseState = Mouse.GetState();
        //    Vector2 mousePos = mouseState.Position.ToVector2();
        //    moveDir = mousePos - position;
        //    float pixelsToMove = speed * deltaTime;
        //    if (moveDir != Vector2.Zero)
        //    {
        //        moveDir.Normalize();
        //        rotation = (float)Math.Atan2(moveDir.Y, moveDir.X);
        //        if (Vector2.Distance(position, mousePos) < pixelsToMove)
        //        {
        //            position = mousePos;
        //        }
        //        else
        //        {
        //            position += moveDir * pixelsToMove;
        //        }
        //        triangleRectangle.Location = (position - offset).ToPoint();
        //    }


        //    triangleColor = Color.White;


        //    base.Update(gameTime);
        //}

        ///// <summary>
        ///// This is called when the game should draw itself.
        ///// </summary>
        ///// <param name="gameTime">Provides a snapshot of timing values.</param>
        //protected override void Draw(GameTime gameTime)
        //{
        //    GraphicsDevice.Clear(Color.CornflowerBlue);

        //    // TODO: Add your drawing code here
        //    spriteBatch.Begin();
        //    spriteBatch.Draw(triangleTexture, position, null, triangleColor, rotation, offset, scale, SpriteEffects.None, 0);
        //    spriteBatch.End();
        //    base.Draw(gameTime);
        //}
    }
}
