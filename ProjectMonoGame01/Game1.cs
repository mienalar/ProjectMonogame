using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProjectMonoGame01.Armory;
using ProjectMonoGame01.Controllers;
using ProjectMonoGame01.Engine;
using ProjectMonoGame01.Geometry;
using ProjectMonoGame01.KeyboardLayouts;
using ProjectMonoGame01.Units;
using System.IO;

namespace ProjectMonoGame01
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        protected GraphicsDeviceManager graphics;
        protected SpriteBatch spriteBatch;

        protected Texture2D texA;
        protected Texture2D tex1, tex2, tex3, texCursor, tex4;
        protected GameEngine engine;
        protected GeometryManager geometry;
        protected GeometryLine line;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            GlobalsItems.Graphics = graphics;
            engine = new GameEngine(this);
            geometry = new GeometryManager(this);

            // FullHD
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferredBackBufferHeight = 1080;
            // полноэкранный режим
            // graphics.IsFullScreen = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic 
            base.Initialize();
            line = new GeometryLine(new Vector2(10, 10), new Vector2(600, 50));
            line.LineWidth = 2;
            line.Color = Color.LightGreen;
            geometry.AddFigure( line );

           
            var anim = new GameUnitAnimate(texA, 9, 9, 80);
            anim.SetPosition(150,150);
            anim.Rotate(0);
            anim.SetScale(2);
            anim.FrameInterval = 40;
            engine.AddObject(anim);


            var spaceship1 = new GameUnit(tex1);
            spaceship1.ShowBoundingBox = true;
            spaceship1.SetPosition(1200, 500);
            spaceship1.SetVelocity(0, 0);
            engine.AddObject(spaceship1, new KeyboardControllerRotate());
            
            var spaceship2 = new GameUnit(tex2);
            spaceship2.ShowBoundingBox = true;
            spaceship2.SetPosition(300, 850);
            spaceship2.SetVelocity(0, 0);
            engine.AddObject(spaceship2, new KeyboardController(new KeyboardLayoutWasd()));

            var spaceship3 = new GameUnitShooter(tex3);
            spaceship3.ShowBoundingBox = true;
            spaceship3.SetPosition(650, 500);
            spaceship3.SetVelocity(0, 0);
            spaceship3.SetScale(0.4f);

            var mouseWatch = new MouseControllerWatch();
            mouseWatch.LeftButtonClick += spaceship3.Shoot;
            engine.AddObject(spaceship3/*, mouseWatch*/);

            var spaceship4 = new GameUnit(tex4);
            spaceship4.ShowBoundingBox = true;
            spaceship4.SetPosition(200, 500);
            spaceship4.SetVelocity(0, 0);
            engine.AddObject(spaceship4/*, new MouseControllerPursuit()*/);

            var mouseCursor = new GameObject(texCursor);
            mouseCursor.ShowBoundingBox = true;
            mouseCursor.SetPosition(100,100);
            var mouseController = new MouseController();
            engine.AddObject(mouseCursor, mouseController);
            mouseController.MouseMove += MouseControllerMouseMove;
            mouseController.LeftButtonClick += MouseControllerLeftButtonClick;
            
        }

        private void MouseControllerLeftButtonClick(Vector2 mousePosition)
        {
            line.StartDot = mousePosition;
        }

        private void MouseControllerMouseMove(Vector2 mousePosition)
        {
            line.EndDot = mousePosition;
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            using (var fs = new FileStream("anim4.png", FileMode.Open))
            {
                texA = Texture2D.FromStream(GraphicsDevice, fs);
            }

            using (var fs = new FileStream("spaceship.png", FileMode.Open))
            {
                tex1 = Texture2D.FromStream(GraphicsDevice, fs);
            }
            using (var fs = new FileStream("redship4.png", FileMode.Open))
            {
                tex2 = Texture2D.FromStream(GraphicsDevice, fs);
            }
            using (var fs = new FileStream("alienspaceship.png", FileMode.Open))
            {
                tex3 = Texture2D.FromStream(GraphicsDevice, fs);
            }
            using (var fs = new FileStream("blueshuttle.png", FileMode.Open))
            {
                tex4 = Texture2D.FromStream(GraphicsDevice, fs);
            }
            using (var fs = new FileStream("cursor.png", FileMode.Open))
            {
                texCursor = Texture2D.FromStream(GraphicsDevice, fs);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
