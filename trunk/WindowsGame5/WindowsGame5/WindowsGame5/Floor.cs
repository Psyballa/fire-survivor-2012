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

namespace WindowsGame5
{
    class Floor
    {
        Texture2D floor;
        int Height, Width, floorPosX, floorPosY;
        int floorCollisionRectOffset = -10;

        public Floor(int Height, int Width, int floorPosX, int floorPosY)
        {
            this.Height = Height;
            this.Width = Width;
            this.floorPosX = floorPosX;
            this.floorPosY = floorPosY;
        
        }
        public bool Collide(Rectangle floorRect, Rectangle ballRect)
        {
            return floorRect.Intersects(ballRect);
        }

        public Rectangle floorRect()
        {
           Rectangle floorRect = new Rectangle(
               (int)floorPosX + floorCollisionRectOffset,
               (int)floorPosY + floorCollisionRectOffset,
               Width - (floorCollisionRectOffset * 2),
               Height - (floorCollisionRectOffset * 2));

            return floorRect;
        }

        public void Update(GameTime gameTime)
        {
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(floor,
                new Rectangle(floorPosX, floorPosY,
                    Width,
                    Height),
                    Color.White);

            spriteBatch.End();
        }

        public void loadContent(Game game)
        {
            floor = game.Content.Load<Texture2D>("floor");
        }
    }
}
