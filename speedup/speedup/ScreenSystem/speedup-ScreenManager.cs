using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

//Code by Rajiv Puvvada

namespace speedup {
    /// <summary>
    /// //Manages what is displayed to the screen by controlling a series of Screens, each of 
    /// //which represents a mode of the game (The Game, Options, Main Menu, etc.)
    /// 
    /// //The ScreenManager is exposed in all Screens
    /// </summary>
    public class ScreenManager : DrawableGameComponent {
        List<Screen> Screens = new List<Screen>();

        IGraphicsDeviceService graphicsDeviceService;
        ContentManager content;

        SpriteBatch spriteBatch;
        Texture2D blank;

        InputState input = new InputState();

        public Game current_game;

        public ScreenManager( Game game )
            : base( game ) {
            graphicsDeviceService = (IGraphicsDeviceService)game.Services.GetService(
                                                        typeof( IGraphicsDeviceService ) );
            content = new ContentManager( game.Services );
            content.RootDirectory = "Content";
            current_game = game;
        }

        /// <summary>
        /// //Returns the game's graphics device, can be used to modify visual parameters
        /// </summary>
        new public GraphicsDevice GraphicsDevice {
            get { return base.GraphicsDevice; }
        }

        /// <summary>
        /// //Returns an active ContentManager to load assets
        /// </summary>
        public ContentManager ContentManager {
            get { return content; }
        }

        /// <summary>
        /// //Creates Sprite Batch that can be used within all Screens
        /// </summary>
        public SpriteBatch SpriteBatch {
            get { return spriteBatch; }
            set { spriteBatch = value; }
        }

        /// <summary>
        /// //A simple 1x1 white pixel that can be stretched and colored for whatever purpose
        /// </summary>
        public Texture2D Blank {
            get { return blank; }
        }

        /// <summary>
        /// //Initializes game to the Main Menu
        /// </summary>
        public override void Initialize() {
            base.Initialize();
            AddScreen( new MainMenu() );
        }

        /// <summary>
        /// //Creates Sprite Batch
        /// </summary>
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch( base.GraphicsDevice );
            blank = content.Load<Texture2D>( "blank" );
            base.LoadContent();
        }

        /// <summary>
        /// //Gets updated input information and updates needed Screens
        /// </summary>
        public override void Update( GameTime gameTime ) {
            input.Update();
            if ( Screens.Count == 1 )
                Screens[0].State = Screen.ScreenState.Active;
            for ( int i = 0; i < Screens.Count; i++ ) {
                if ( Screens[i].State == Screen.ScreenState.Active || Screens[i].State == Screen.ScreenState.Transition ) {
                    Screens[i].Update( gameTime );
                    Screens[i].HandleInput( input );

                }
            }

            base.Update( gameTime );
        }

        /// <summary>
        /// //Draws visible screens
        /// </summary>
        public override void Draw( GameTime gameTime ) {
            for ( int i = 0; i < Screens.Count; i++ ) {
                if ( Screens[i].State == Screen.ScreenState.Hidden )
                    continue;

                if ( Screens[i] is GameScreen ) {
                    current_game.IsMouseVisible = false;
                }
                else if ( !current_game.IsMouseVisible ) {
                    current_game.IsMouseVisible = true;
                }

                Screens[i].Draw();
            }
        }

        /// <summary>
        /// //Adds a screen to the top of the manager
        /// </summary>
        public void AddScreen( Screen screen ) {
            screen.ScreenManager = this;
            screen.Initialize();

            // If we have a graphics device, tell the screen to load content.
            if ( ( graphicsDeviceService != null ) &&
                ( graphicsDeviceService.GraphicsDevice != null ) ) {
                screen.LoadContent();
            }

            Screens.Add( screen );
        }

        /// <summary>
        /// //Removes a screen from the ScreenManager
        /// </summary>
        public void RemoveScreen( Screen screen ) {
            // If we have a graphics device, tell the screen to unload content.
            if ( ( graphicsDeviceService != null ) &&
                ( graphicsDeviceService.GraphicsDevice != null ) ) {
                screen.UnloadContent();
            }
            screen.State = Screen.ScreenState.Inactive;
            Screens.Remove( screen );
        }

        /// <summary>
        /// Expose an array holding all the screens. We return a copy rather
        /// than the real master list, because screens should only ever be added
        /// or removed using the AddScreen and RemoveScreen methods.
        /// </summary>
        public Screen[] GetScreens() {
            return Screens.ToArray();
        }

    }
}
