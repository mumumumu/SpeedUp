using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;

namespace speedup
{
    class Credits : MenuScreen
    {        
        public Credits() {
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

        public override void Draw()
        {
            base.Draw();

            float leftBorder = 100;
            float topBorder = 400;
            Vector2 a = new Vector2( leftBorder, topBorder );
            Vector2 b = new Vector2( leftBorder, topBorder + menuSpriteFont.LineSpacing );
            Vector2 c = new Vector2( leftBorder, topBorder + 2 * menuSpriteFont.LineSpacing );
            Vector2 d = new Vector2( leftBorder, topBorder + 4 * menuSpriteFont.LineSpacing );
            Vector2 e = new Vector2( leftBorder, topBorder + 6 * menuSpriteFont.LineSpacing );

            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "PROGRAMMERS: MATHEUS OGLEARI, SANFORD JOHNSON", a, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0 );

            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "ARTISTS: EDGAR MUNOZ, WEN HAO LUI", b, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0 );


            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "MUSICIAN: JEFF MU", c, Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0 );


            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "TWIN NOVA BOSS THEME - DEATH FROM ABOVE by MACHINAE SUPREMACY \n(http://www.machinaesupremacy.com)", d, Color.White, 0, Vector2.Zero, .8f, SpriteEffects.None, 0 );


            ScreenManager.SpriteBatch.DrawString( menuSpriteFont, "ALIEN QUEEN BOSS THEME - HEAVYARMS REMIX by DARKESWORD\n(http://ocremix.org/remix/OCR00758/)", e, Color.White, 0, Vector2.Zero, .8f, SpriteEffects.None, 0 );
        }
    }
}
