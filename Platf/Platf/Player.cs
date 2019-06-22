using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platf
{
    public class Player
    {
        public int Speed = 2;

        public Texture2D Texture2D { get; set; }
        public Rectangle Rectangle { get; set; }
        public Vector2 Vector2
        {
            get
            {
                return new Vector2(Rectangle.X, Rectangle.Y);
            }
        }

        public void Movement()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Rectangle = new Rectangle(Rectangle.X, (Rectangle.Y - Speed), Rectangle.Width, Rectangle.Height);
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Rectangle = new Rectangle(Rectangle.X, (Rectangle.Y + Speed), Rectangle.Width, Rectangle.Height);
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Rectangle = new Rectangle((Rectangle.X - Speed), Rectangle.Y, Rectangle.Width, Rectangle.Height);
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Rectangle = new Rectangle((Rectangle.X + Speed), Rectangle.Y, Rectangle.Width, Rectangle.Height);
            }
        }

        public void Paint(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture2D, Vector2, null, Color.White, 0f, Vector2.Zero, 0.1f, SpriteEffects.None, 0f);
            spriteBatch.End();
        }
    }
}
