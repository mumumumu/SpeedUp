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
    class Options : MenuScreen {
        /// <summary>
        /// Options menu allows users to change various game parameters
        /// </summary>
        public Options() {
            State = ScreenState.Active;

            MenuEntries.Add( "SFX Volume UP" );
            EntryPositions.Add( Vector2.Zero );
            MenuEntries.Add( "SFX Volume DOWN" );
            EntryPositions.Add( Vector2.Zero );
            MenuEntries.Add( "MUSIC Volume UP" );
            EntryPositions.Add( Vector2.Zero );
            MenuEntries.Add( "MUSIC Volume DOWN" );
            EntryPositions.Add( Vector2.Zero );
            MenuEntries.Add( "Back" );
            EntryPositions.Add( Vector2.Zero );
            LeftBorder = 100;
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
                case 0: //SFX Volume Up
                    audio.IncreaseSFXVolume( .1f );
                    break;

                case 1: //SFX Volume Down
                    audio.DecreaseSFXVolume( .1f );
                    break;

                case 2: //Music volume up
                    audio.IncreaseMusicVolume( .1f );
                    break;

                case 3: //Music volume down
                    audio.DecreaseMusicVolume( .1f );
                    break;

                case 4:
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
            int sfxVol = (int)( Math.Round( GameEngine.AudioManager.getSFXVolume(), 2 ) * 100 );
            int musicVol = (int)( Math.Round( GameEngine.AudioManager.getMusicVolume(), 2 ) * 100 );
            Vector2 sfxPos = new Vector2( 400, ( EntryPositions[0].Y + EntryPositions[1].Y ) / 2 - menuSpriteFont.LineSpacing );
            Vector2 musicPos = new Vector2( 400, ( EntryPositions[2].Y + EntryPositions[3].Y ) / 2 - menuSpriteFont.LineSpacing );
            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, sfxVol.ToString() + "%", sfxPos, Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0 );
            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, musicVol.ToString() + "%", musicPos, Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0 );
            //ScreenManager.SpriteBatch.DrawString(menuSpriteFont, "Options", new Vector2(20, 20), Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
        }
    }
}
