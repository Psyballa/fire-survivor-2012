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

using FarseerPhysics.DebugViews;

namespace WindowsGame5
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        DebugViewXNA debugView;
        World world;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D playerTexture, floorTexture;
        Player Jerry;
        Floor Tom;

        Vector2 offset;

        private Matrix _view;
        private Vector2 _cameraPosition;
        private Vector2 _screenCenter;
        private const float MeterInPixels = 64f;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            Content.RootDirectory = "Content";
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
            offset = new Vector2(Window.ClientBounds.Width / 2 - (16 * 15), Window.ClientBounds.Height / 2 - (16 * 15));
            _view = Matrix.Identity;
            _cameraPosition = Vector2.Zero;
            _screenCenter = new Vector2(graphics.GraphicsDevice.Viewport.Width / 2f, graphics.GraphicsDevice.Viewport.Height / 2f);
            world = new World(Vector2.Zero);
            debugView = new DebugViewXNA(world);
            debugView.AppendFlags(FarseerPhysics.DebugViewFlags.AABB);
            debugView.LoadContent(GraphicsDevice, Content);
            world.Gravity = new Vector2(0f, 20f);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerTexture = Content.Load<Texture2D>(@"ball");
            floorTexture = Content.Load<Texture2D>(@"floor");
            Jerry = new Player(world, this, Window, playerTexture, offset);
            Tom = new Floor(world, this, floorTexture, floorTexture.Height, floorTexture.Width, 0, Window.ClientBounds.Height/2, offset);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                this.Exit();
            }
            world.Step(1);
            Jerry.Update(gameTime);
            Tom.Update(gameTime);
            base.Update(gameTime);
        }
        
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Matrix projection = Matrix.CreateOrthographicOffCenter(0f, graphics.GraphicsDevice.Viewport.Width / MeterInPixels,
                graphics.GraphicsDevice.Viewport.Height / MeterInPixels, 0f, 0f, 1f);
            Matrix view = Matrix.CreateTranslation(new Vector3((_cameraPosition / MeterInPixels) - (_screenCenter/MeterInPixels), 0f)) * Matrix.CreateTranslation(new Vector3((_screenCenter / MeterInPixels), 0f));
            debugView.RenderDebugData(ref projection, ref view);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            Jerry.draw(spriteBatch);
            Tom.draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
