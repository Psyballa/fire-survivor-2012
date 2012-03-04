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
    public class Player : Body
    {
        Game1 game;
        Fixture playerFixture;
        Texture2D playerTexture;
        int Speed = 5;


        public Player(World gameWorld, Game1 game, GameWindow Window, Texture2D playerTexture, Vector2 offset) : base(gameWorld)
        {
            this.game = game;
            Position = Vector2.Zero;
            this.playerTexture = playerTexture;
            playerFixture = FixtureFactory.AttachCircle((playerTexture.Width / 2), 1, this);
            playerFixture.Body.BodyType = BodyType.Dynamic;
            playerFixture.CollisionCategories = Category.Cat1;
            playerFixture.CollidesWith = Category.Cat2;
            playerFixture.OnCollision += _OnCollision;
            Position = new Vector2(game.Window.ClientBounds.Width/2, 0);
        }

        public bool _OnCollision(Fixture fix1, Fixture fix2, Contact con)
        {
            if (fix2.CollisionCategories == Category.Cat2)
            {
                return true;
            }
            return false;
        }
        public void Update(GameTime gameTime)
        {
            Vector2 tempLinearVelocity = new Vector2(0, 0);
            tempLinearVelocity = new Vector2(((float)8.53 * GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X), ((float)8.53 * GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y) );
          

            if (Position.X > game.Window.ClientBounds.Width  - playerTexture.Width) Position = new Vector2(game.Window.ClientBounds.Width - playerTexture.Width, Position.Y);
            if (Position.X  < 0) Position = new Vector2(0, Position.Y);
            if (Position.Y  > game.Window.ClientBounds.Height - playerTexture.Height) Position = new Vector2(Position.X, game.Window.ClientBounds.Height - playerTexture.Height);
            if (Position.Y < 0) Position = new Vector2(Position.X, 0);
            LinearVelocity = tempLinearVelocity;
        }


        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playerTexture, Position, Color.White);
        }
    }
}
