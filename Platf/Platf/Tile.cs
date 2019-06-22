using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tainicom.Aether.Physics2D.Collision;

namespace Platf
{
    public class Tile
    {
        public Tile()
        {
            ShowCollisionBox = false;
        }

        public Texture2D Texture2D { get; set; }
        public Rectangle Rectangle { get; set; }

        public Vector2 Vector2
        {
            get
            {
                return new Vector2(Rectangle.X, Rectangle.Y);
            }
        }
        
        public void Colliding(Player player)
        {
            if (CollisionLeft(player))
            {
                player.Rectangle = new Rectangle(player.Rectangle.X - player.Speed, player.Rectangle.Y, Rectangle.Width, Rectangle.Height);
                Console.WriteLine("Collision left");
            }
        }

        public bool CollisionLeft(Player player)
        {

            

            return false;
        }

        public void Control()
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                ShowCollisionBox = true;
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.F))
            {
                ShowCollisionBox = false;
            }
        }

        private Texture2D BoxTexture;

        public void Load(GraphicsDevice graphics)
        {
            BoxTexture = new Texture2D(graphics, Rectangle.Width, Rectangle.Height);

            Color[] data = new Color[Rectangle.Width * Rectangle.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Chocolate;
            BoxTexture.SetData(data);
        }

        public bool ShowCollisionBox { get; set; }

        public void PaintCollisionBox(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(BoxTexture, Vector2, Color.White);
            spriteBatch.End();
        }

        public void Paint(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(Texture2D, Vector2);
            spriteBatch.End();
        }
    }
}
