using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<Tile> tiles = new List<Tile>();
        Texture2D text,background;
        int varix = 70;
        int variy = 250;
        int variz = 0;
        SpriteFont font;
        private string texto = @"", texto2 = @"";
        bool jumping = false;
        bool switchjumpdown = false;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 500;
            graphics.PreferredBackBufferHeight = Window.ClientBounds.Height;
            graphics.ApplyChanges();
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
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            font = Content.Load<SpriteFont>("font");

            text = this.Content.Load<Texture2D>("mario");
            background = this.Content.Load<Texture2D>("eu");
            
            int k = -25, j = 280;
            for (var i = 0; i < 187; i++)
            {
                Vector2 vec2 = new Vector2()
                {
                    X = k,
                    Y = j
                };
                tiles.Add(new Tile()
                {
                    Texture2D = this.Content.Load<Texture2D>("tile"),
                    Vector = vec2,
                    Id = i,
                    Z = 0
                });
                k += 30;
                if (k > 500)
                {
                    j += 20;
                    k = -25;
                }
            }

            tiles[50].Z = 20;
            Vector2 vec = new Vector2()
            {
                X = tiles[50].Vector.X,
                Y = tiles[50].Vector.Y - 20
            };
            tiles[50].Vector = vec;
            tiles[50].Texture2D = this.Content.Load<Texture2D>("box");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                varix++;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                varix--;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                if(variy > 225)
                {
                    variy--;
                }
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                variy++;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                jumping = true;
            }

            if (jumping)
            {
                if(variz > 50)
                {
                    switchjumpdown = true;
                }
                if(variz <= 50)
                {
                    //sobe
                    if (!switchjumpdown)
                    {
                        variy-=2;
                        variz+=2;
                    }
                    else
                    {
                        //desce
                        if (variz <= 0)
                        {
                            jumping = false;
                            switchjumpdown = false;
                        }
                        else
                        {
                            variy += 2;
                            variz -= 2;
                        }
                        
                    }
                }
                else
                {
                    //desce
                    if (variz <= 0)
                    {
                        jumping = false;
                        switchjumpdown = false;
                    }
                    else
                    {
                        variy += 2;
                        variz -= 2;
                    }
                }
            }

            texto = "FPS: " + (1 / gameTime.ElapsedGameTime.TotalSeconds).ToString() + ", Mario X: " + varix.ToString() + ", Mario Y: " + variy.ToString() + ", Mario Z: " + variz.ToString();
            texto2 = "Cursor X: " + Mouse.GetState().X + ", Cursor Y: " + Mouse.GetState().Y;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DeepSkyBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            //spriteBatch.Draw(background, Vector2.Zero);
            
            foreach(Tile t in tiles.Where(x => x.Z == 0))
            {
                spriteBatch.Draw(t.Texture2D, t.Vector);
            }

            Vector2 vec = new Vector2()
            {
                X = varix,
                Y = variy
            };
            spriteBatch.Draw(text, vec, null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);

            foreach (Tile t in tiles.Where(x => x.Z != 0))
            {
                spriteBatch.Draw(t.Texture2D, t.Vector);
                if (variy+10 > t.Vector.Y)
                {
                    spriteBatch.Draw(text, vec, null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
                }
            }


            spriteBatch.DrawString(font, texto, new Vector2(0, 0), Color.Black);
            spriteBatch.DrawString(font, texto2, new Vector2(0, 20), Color.Black);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
