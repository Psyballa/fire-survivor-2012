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
using FarseerPhysics;

=======
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;

>>>>>>> .r6
namespace WindowsGame5
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        World world = new World(Vector2.Zero);
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        Ball Jerry;
        Floor Tom, floor;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            Content.RootDirectory = "Content";
            Jerry = new Ball(0, 0);
            Tom = new Floor(100, 720, 0, 350);
            floor = new Floor(120, 1280, 0, 600);
            Window.AllowUserResizing = false;
            Window.ClientSizeChanged += new EventHandler<EventArgs>(Window_ClientSizeChanged);

        }

        void Window_ClientSizeChanged(object sender, EventArgs e)
        {
        }

        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Jerry.loadContent(this);
            Tom.loadContent(this);
            floor.loadContent(this);

        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            Jerry.Update(gameTime);
            Tom.Update(gameTime);

            if (Jerry.Collide(Jerry.ballRect(), Tom.floorRect()))
            {
                Jerry.collided = true;
            }
            else if (Jerry.Collide(Jerry.ballRect(), floor.floorRect()))
            {
                Jerry.collided = true;
            }
            else
            {
                Jerry.collided = false;
            }


            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Jerry.draw(spriteBatch);
            Tom.draw(spriteBatch);
            floor.draw(spriteBatch);
            base.Draw(gameTime);
        }
    }
}
