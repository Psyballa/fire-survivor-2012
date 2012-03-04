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
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Factories;

namespace WindowsGame5
{
    public class Ball : Body
    {
        public Fixture ballFixture;
        Texture2D ball;
        float velocityX;
        float velocityY;

        int x, y, radius;
        Vector2 ballPosition = Vector2.Zero;
        int ballCollisionRectOffset = 10;
        public Boolean collided = false;
        Body playerBody;
        Fixture playerFix;
        CircleShape playerBodyShape;

<<<<<<< .mine

        public Ball(int x, int y, int radius)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
            ballFixture = FixtureFactory.AttachCircle(radius, 1, this);
            ballFixture.Body.BodyType = BodyType.Dynamic;
            ballFixture.CollisionCategories = Category.Cat1;
            ballFixture.CollidesWith = Category.Cat2;
            ballFixture.OnCollision += _ballOnCollision;
        }

        public bool _ballOnCollision(Fixture fix1, Fixture fix2, Contact con)
        {
            if (fix2.CollisionCategories == Category.Cat2)
            {
                return true;
            }
            return false;
        }

=======
        public Ball(int BallStartX, int BallStartY)
        {
            playerBody.BodyType = BodyType.Dynamic;
            playerBodyShape = new CircleShape(1.0f, 1.0f);
            playerFix = playerBody.CreateFixture(playerBodyShape);
            //gameWorld.AddBody(playerBody);
        }

>>>>>>> .r6
        public void Update(GameTime gameTime)
        {
            velocityX = (float)8.53 * GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            //this creates gravity
            if (!collided)
            {
                velocityY = (float)(velocityY + 0.5);
            }
            if (collided)
            {
                velocityY = 0;
            }

            if (collided)
            {
                if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
                {
                    //this is where we need to jump
                    velocityY = (float)-8.32;
                }
            }

            //so the ball moves left and right.
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X > 0)
            {
                ballPosition.X += velocityX;
            }
            if (GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X < 0)
            {
                ballPosition.X += velocityX;
            }
            ballPosition.Y += velocityY;
            
            //so the ball doesn't go off the face of the earth
            //actually let's change this to mean max settings;
            if (ballPosition.X < 0)
                ballPosition.X = 0;
            if (ballPosition.Y < 0)
                ballPosition.Y = 0;
            if (ballPosition.X > 1280 - ball.Width)
                ballPosition.X = 1280 - ball.Width;
            if (ballPosition.Y > 720 - ball.Height)
                ballPosition.Y = 720 - ball.Height;
        }

        public bool Collide(Rectangle ballRect, Rectangle wallRect)
        {
            return ballRect.Intersects(wallRect);
        }

        public Rectangle ballRect()
        {
            Rectangle ballRect = new Rectangle(
                (int)ballPosition.X + ballCollisionRectOffset,
                (int)ballPosition.Y + ballCollisionRectOffset,
                ball.Width - (ballCollisionRectOffset * 2),
                ball.Height - (ballCollisionRectOffset * 2));

            return ballRect;
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(ball,
                new Vector2(
                    ballPosition.X,
                    ballPosition.Y),
                    Color.White);

            spriteBatch.End();
        }

        public void loadContent(Game game)
        {
            ball = game.Content.Load<Texture2D>("ball");
        }
    }

}
