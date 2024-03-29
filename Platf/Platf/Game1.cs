﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using tainicom.Aether.Physics2D.Collision;

namespace Platf
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        List<Tile> grass = new List<Tile>();
        List<Tile> building = new List<Tile>();

        Player player = new Player();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        /// 

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            for(int i = 0; i < 50; i++)
            {
                for(var j = 0; j < 50; j++)
                {
                    Texture2D texture = Content.Load<Texture2D>("grass");
                    Rectangle rect = new Rectangle(i*40, j*35, 40, 35);
                    grass.Add(new Tile()
                    {
                        Texture2D = texture,
                        Rectangle = rect
                    });
                }
            }

            Texture2D tex = Content.Load<Texture2D>("building");
            Rectangle rec = new Rectangle(5 * 40 + 25, 5 * 35 + 5, 40, 35);
            building.Add(new Tile()
            {
                Texture2D = tex,
                Rectangle = rec
            });

            player.Rectangle = new Rectangle(0, 0, 50, 50);
            player.Texture2D = Content.Load<Texture2D>("hamtaro");

            // TODO: use this.Content to load your game content here
            foreach(Tile t in building)
            {
                t.Load(GraphicsDevice);
            }

            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
        /// 

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Movement();
            foreach (Tile t in building)
            {
                t.Colliding(player);
                t.Control();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            foreach (Tile t in grass)
            {
                t.Paint(spriteBatch);
            }

            foreach (Tile t in building)
            {
                t.Paint(spriteBatch);
                if (t.ShowCollisionBox)
                {
                    t.PaintCollisionBox(spriteBatch);
                }
            }

            player.Paint(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
