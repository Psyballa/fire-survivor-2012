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

<<<<<<< .mine
using FarseerPhysics.Collision;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Factories;

=======
using FarseerPhysics.Collision;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;

>>>>>>> .r6
namespace WindowsGame5
{
    class Floor : Body
    {
        Fixture floorFixture;
        Texture2D floor;
        int Height, Width, floorPosX, floorPosY;
        int floorCollisionRectOffset = -10;

        public Floor(int Height, int Width, int floorPosX, int floorPosY)
        {
            this.Height = Height;
            this.Width = Width;
            this.floorPosX = floorPosX;
            this.floorPosY = floorPosY;
            floorFixture = FixtureFactory.AttachRectangle(Width, Height, 1, new Vector2(), this);
            floorFixture.Body.BodyType = BodyType.Static;
            floorFixture.CollisionCategories = Category.Cat2;
            floorFixture.CollidesWith = Category.Cat1;
            floorFixture.OnCollision += _floorOnCollision;
        
        }

        public bool _floorOnCollision(Fixture fix1, Fixture fix2, Contact con)
        {
            if (fix2.CollisionCategories == Category.Cat1)
            {
                return true;
            }
            return false;

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
