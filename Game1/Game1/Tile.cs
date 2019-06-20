using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    public class Tile
    {
        public Texture2D Texture2D { get; set; }
        public Vector2 Vector { get; set; }
        public long Id { get; set; }
        public int Z { get; set; }
    }
}
