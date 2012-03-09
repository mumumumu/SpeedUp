using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


//Code by Rajiv Puvvada

namespace speedup {
    public abstract class Screen {

        protected SpriteFont menuSpriteFont;
        protected Texture2D backgroundTexture;
        /// <summary>
        /// //States a Screen can be in
        /// //Active: Updating and Drawing
        /// //Inactive: Not Updating but Drawing, useful for overlaying a screen
        /// //Transition: Updating and Drawing but transitioning between this and a previous screen
        /// //Hidden: Not Updating and not Drawing 
        /// </summary>
        /// 
        public enum ScreenState {
            Active,
            Inactive,
            Transition,
            Hidden,
        }

        private ScreenState state;

        public ScreenState State {
            get { return state; }
            set { state = value; }
        }

        ScreenManager screenManager;

        public ScreenManager ScreenManager {
            get { return screenManager; }
            set { screenManager = value; }
        }

        public virtual void Initialize() { }

        public virtual void LoadContent() {
            menuSpriteFont = ScreenManager.ContentManager.Load<SpriteFont>( "menuFont" );
            backgroundTexture = ScreenManager.ContentManager.Load<Texture2D>( "menuBackground" );
        }

        public virtual void UnloadContent() { }

        public virtual void Update( GameTime game_time ) { }

        public virtual void HandleInput( InputState input ) {
            if ( input.MuteToggle ) {
                GameEngine.AudioManager.MuteToggle();
            }
            if ( input.MenuCancel )
            {
                ScreenManager.AddScreen(new MainMenu());
                ScreenManager.RemoveScreen( this );
            }
        }

        public virtual void Draw() { }
    }
}

