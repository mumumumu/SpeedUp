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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

//Code by Rajiv Puvvada

namespace speedup {
    /// <summary>
    /// This is where the main execution of the game occurs
    /// </summary>
    public class GameEngine : Microsoft.Xna.Framework.Game {
        static GraphicsDeviceManager graphics;
        ScreenManager ScreenManager;
        static AudioManager audioManager;
        static GameWindow window;
        public static ContentManager engine_content;
        static LevelManager levelManager;

        public GameEngine() {
            graphics = new GraphicsDeviceManager( this );
            //Components.Add(new GamerServicesComponent(this));
            Content.RootDirectory = "Content";
            engine_content = Content;
            ScreenManager = new ScreenManager( this );
            audioManager = new AudioManager();
            audioManager.LoadContent( Content );
            //audioManager.Initialize();
            levelManager = new LevelManager();
            window = this.Window;
            //Adds ScreenManager as a component, making all of its calls done automatically
            Components.Add( ScreenManager );

            GameEngine.AudioManager.Play( AudioManager.MusicSelection.ninjawarrior );
            
        }

        public static AudioManager AudioManager {
            get { return audioManager; }
        }

        public static GraphicsDeviceManager GraphicsDeviceManager {
            get { return graphics; }
        }


        public static GameWindow GameWindow {
            get { return window; }
        }

        public static LevelManager LevelManager {
            get { return levelManager; }
        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize() {

            IsMouseVisible = true;
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent() {

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent() {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update( GameTime gameTime ) {
            base.Update( gameTime );
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw( GameTime gameTime ) {
            ScreenManager.GraphicsDevice.Clear( new Color( 0, 0, 20, 180 ) );
            ScreenManager.SpriteBatch.Begin( SpriteSortMode.BackToFront, BlendState.AlphaBlend );

            ScreenManager.Draw( gameTime );




            ScreenManager.SpriteBatch.End();
        }
    }
}
