using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Peli.Objects;
using Peli.Engine;
using Uppercut.Components;
using Peli.Scenes;

namespace Peli
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        ContentManager cont;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite isku_sprite;
        public static Camera camera;
        public static Rectangle screen_size
        {
            get;
            private set;
        }

        float ship_speed = 5;
   
        SpriteFont font;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            screen_size = new Rectangle(0, 0, 
                graphics.GraphicsDevice.Viewport.Width, 
                graphics.GraphicsDevice.Viewport.Height
                );
            // TODO: Add your initialization logic here
          
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            camera = new Camera(graphics);
            Resources.Init(Content);
            DrawSys.InitSpriteBatch(spriteBatch);
            // Create a new SpriteBatch, which can be used to draw textures.
            Resources.LoadTexture2D("Ship");
            Resources.LoadTexture2D("Bullet");
            Resources.LoadTexture2D("hp");
            Resources.LoadTexture2D("enemy");
            Resources.LoadTexture2D("boss");
            Resources.LoadTexture2D("isku");
            Resources.LoadFont("font");
            Resources.LoadTexture2D("sky");
            Resources.LoadTexture2D("boss_bullet");
            Resources.LoadTexture2D("random");
            isku_sprite = new Sprite(Resources.GetTexture("isku"), 193, 500, 10, 100f);
            SceneSys.ChangeScene(new GameScene());
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            float dT = gameTime.ElapsedGameTime.Milliseconds * 0.001f;

            Input.UpdateState();


            // Allows the game to exit
            if (Input.IsKeyDown(Keys.Escape))
                this.Exit();
            if(Input.IsKeyDown(Keys.P))
                camera.addZoom(dT);
            if (Input.IsKeyDown(Keys.K))
                camera.addZoom(-dT);
            SceneSys.Update(dT);

            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
           // GraphicsDevice.Clear(Color.AliceBlue);
            float dT = gameTime.ElapsedGameTime.Milliseconds * 0.001f;
            spriteBatch.Begin(SpriteSortMode.Immediate,
                BlendState.AlphaBlend,
                SamplerState.LinearClamp,
                DepthStencilState.None,
                RasterizerState.CullCounterClockwise,
                null,
                camera.update()
                );
            SceneSys.Draw(dT);
           //GraphicsDevice.Clear(väri);
            //isku_sprite.Draw(player.Position);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
