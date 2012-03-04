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

using FarseerPhysics.Collision;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Factories;

namespace WindowsGame5
{
    class Floor : Body
    {
        Game1 game;
        Fixture floorFixture;
        Texture2D floor;
        int Height, Width, floorPosX, floorPosY;
        int floorCollisionRectOffset = -10;

        public Floor(World gameWorld, Game1 game, Texture2D floorTexture, int Height, int Width, int floorPosX, int floorPosY, Vector2 offset)
            : base(gameWorld)
        {
            this.game = game;
            this.floor = floorTexture;
            this.Height = Height;
            this.Width = Width;
            this.floorPosX = floorPosX;
            this.floorPosY = floorPosY;

            floorFixture = FixtureFactory.AttachRectangle(Width/64f, Height/64f, 1, new Vector2(), this);
            floorFixture.Body.BodyType = BodyType.Static;
            floorFixture.CollisionCategories = Category.Cat2;
            floorFixture.CollidesWith = Category.Cat1;
            floorFixture.OnCollision += _OnCollision;

            Position = new Vector2(game.Window.ClientBounds.Width / 2, game.Window.ClientBounds.Height / 2);

        }

        public Boolean _OnCollision(Fixture fix1, Fixture fix2, Contact con)
        {
            if (fix2.CollisionCategories == Category.Cat1)
            {
                return true;
            }
            return false;
        }


        public void Update(GameTime gameTime)
        {
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(floor,
                new Vector2(floorPosX, floorPosY),
                    Color.White);
        }
    }
}
