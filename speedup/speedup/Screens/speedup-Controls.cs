using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;

/*** Code by Rajiv Puvvada and Ara Yessayan **/
/*** Modification code to work with MP3's by Sam Dannemiller **/

namespace speedup {
    class Controls : MenuScreen {
        /// <summary>
        /// Options menu allows users to change various game parameters
        /// </summary>
        public Controls() {
            State = ScreenState.Active;
            MenuEntries.Add( "" );
            EntryPositions.Add( Vector2.Zero );
            MenuEntries.Add( "Back" );
            EntryPositions.Add( Vector2.Zero );
            LeftBorder = 100;
            TopBorder = 540;
        }

        /// <summary>
        /// Responds to user menu selections.
        /// *******************************************************
        /// </summary>
        protected override void OnSelectEntry( int entryIndex ) {
            AudioManager audio = GameEngine.AudioManager;
            switch ( entryIndex ) {
                /**********************************************
                 * YOUR CODE HERE. Call your functions through the "audio" object.
                 *********************************************/
                case 0:
                    break;
                case 1: //SFX Volume Up
                    GameEngine.AudioManager.Play( AudioManager.SFXSelection.menu_select );
                    OnCancel();
                    break;
            }

            /******** END YOUR CODE **********/
        }


        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected override void OnCancel() {
            ScreenManager.AddScreen(new MainMenu());
            ScreenManager.RemoveScreen( this );
        }


        /// <summary>
        /// Event handler for when the user selects ok on the "are you sure
        /// you want to exit" message b3ox.
        /// </summary>
        void ExitMessageBoxAccepted( object sender, EventArgs e ) {
            // ScreenManager.Game.Exit();
        }


        /// <summary>
        /// Loading screen callback for activating the gameplay screen.
        /// </summary>
        void LoadGameplayScreen( object sender, EventArgs e ) {
            //ScreenManager.AddScreen(new GameplayScreen());
        }

        public override void Draw() {
            base.Draw();
            float leftBorder = 100;
            float topBorder = 400;
            Vector2 wPos = new Vector2( leftBorder, topBorder );
            Vector2 sPos = new Vector2( leftBorder, topBorder + menuSpriteFont.LineSpacing );
            Vector2 aPos = new Vector2( leftBorder, topBorder + 2 * menuSpriteFont.LineSpacing );
            Vector2 dPos = new Vector2( leftBorder, topBorder + 3 * menuSpriteFont.LineSpacing );
            Vector2 pickupPos = new Vector2( leftBorder, topBorder + 4 * menuSpriteFont.LineSpacing );
            Vector2 throwPos = new Vector2( leftBorder, topBorder + 5 * menuSpriteFont.LineSpacing );
            Vector2 boostPos = new Vector2( leftBorder, topBorder + 7 * menuSpriteFont.LineSpacing );
            Vector2 pausePos = new Vector2( leftBorder, topBorder + 8 * menuSpriteFont.LineSpacing );
            Vector2 resetPos = new Vector2( leftBorder, topBorder + 9 * menuSpriteFont.LineSpacing );

            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "Move Up : W", wPos, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0 );
            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "Move Down : S", sPos, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0 );
            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "Move Left : A", aPos, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0 );
            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "Move Right : D", dPos, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0 );
            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "Pick Up Objects : Right Mouse Click", pickupPos, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0 );
            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "Throw Objects : Left Mouse Click \nAlternative Throw: Space", throwPos, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0 );
            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "Boost Control : Left Shift", boostPos, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0 );
            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "Pause : P", pausePos, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0 );
            //ScreenManager.SpriteBatch.DrawString(menuSpriteFont, "Options", new Vector2(20, 20), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
        }
    }
}
