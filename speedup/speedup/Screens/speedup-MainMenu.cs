#region Using Statements
using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;

#endregion

//Code by Rajiv Puvvada and Ara Yessayan

namespace speedup {
    /// <summary>
    /// The main menu screen is the first thing displayed when the game starts up.
    /// </summary>
    class MainMenu : MenuScreen {
        /// <summary>
        /// Constructor fills in the menu contents.
        /// </summary>
        public MainMenu() {
            State = ScreenState.Active;
            MenuEntries.Add( "Play" );
            EntryPositions.Add( Vector2.Zero );
            MenuEntries.Add( "Level Select" );
            EntryPositions.Add( Vector2.Zero );
            MenuEntries.Add( "Options" );
            EntryPositions.Add( Vector2.Zero );
            MenuEntries.Add( "Controls" );
            EntryPositions.Add( Vector2.Zero );
            MenuEntries.Add( "Credits" );
            EntryPositions.Add( Vector2.Zero );
            MenuEntries.Add( "Exit" );
            EntryPositions.Add( Vector2.Zero );
            LeftBorder = 100;
        }

        /// <summary>
        /// Responds to user menu selections.
        /// </summary>
        protected override void OnSelectEntry( int entryIndex ) {
            switch ( entryIndex ) {
                case 0:
                    GameEngine.AudioManager.Stop();
                    LoadingScreen.Load( ScreenManager, true,
                               new GameScreen() );
                    // ScreenManager.AddScreen(new GameScreen());
                    ScreenManager.RemoveScreen( this );
                    break;
                case 1:
                    GameEngine.AudioManager.Play( AudioManager.SFXSelection.menu_select );
                    ScreenManager.AddScreen( new LevelSelect() );
                    //ScreenManager.RemoveScreen( this );
                    State = ScreenState.Inactive;
                    break;
                case 2:
                    GameEngine.AudioManager.Play( AudioManager.SFXSelection.menu_select );
                    //Replace this screen with an Options Screen
                    ScreenManager.AddScreen( new Options() );
                    State = ScreenState.Inactive;
                    //ScreenManager.RemoveScreen(this);
                    break;
                case 3:
                    GameEngine.AudioManager.Play( AudioManager.SFXSelection.menu_select );
                    //Replace this screen with an Controls Screen
                    ScreenManager.AddScreen( new Controls() );
                    State = ScreenState.Inactive;
                    //ScreenManager.RemoveScreen(this);
                    break;
                case 4:
                    GameEngine.AudioManager.Play( AudioManager.SFXSelection.menu_select );
                    //Replace this screen with an Controls Screen
                    ScreenManager.AddScreen( new Credits() );
                    State = ScreenState.Inactive;
                    //ScreenManager.RemoveScreen(this);
                    break;
                case 5:
                    // Exit the sample.

                    OnCancel();
                    break;
            }
        }


        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected override void OnCancel() {
            ScreenManager.Game.Exit();
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
        }
    }
}
