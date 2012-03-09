using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Storage;

namespace speedup
{
    class LevelSelect : MenuScreen
    {
        public LevelSelect()
        {
            MenuEntries.Add( "" );
            EntryPositions.Add( Vector2.Zero );
            State = ScreenState.Active;
            for ( int i = 0; i < GameEngine.LevelManager.levels.Count; i++ )
            {
                MenuEntries.Add( "Level: " + i );
                EntryPositions.Add( Vector2.Zero );
            }
            MenuEntries.Add( "Back" );
            EntryPositions.Add( Vector2.Zero );
            LeftBorder = 100;
        }

        protected override void OnSelectEntry( int entryIndex )
        {
            switch ( entryIndex )
            {
                case 0:
                    break;
                case 1:
                    GameEngine.AudioManager.Stop();
                    LoadingScreen.Load( ScreenManager, true,
                    new GameScreen(0) );
                    // ScreenManager.AddScreen(new GameScreen());
                    ScreenManager.RemoveScreen( this );
                    break;
                case 2:
                    GameEngine.AudioManager.Stop();
                    LoadingScreen.Load( ScreenManager, true,
                    new GameScreen(1) );
                    // ScreenManager.AddScreen(new GameScreen());
                    ScreenManager.RemoveScreen( this );
                    break;
                case 3:
                    GameEngine.AudioManager.Stop();
                    LoadingScreen.Load( ScreenManager, true,
                    new GameScreen(2) );
                    // ScreenManager.AddScreen(new GameScreen());
                    ScreenManager.RemoveScreen( this );
                    break;
                case 4:
                    GameEngine.AudioManager.Stop();
                    LoadingScreen.Load( ScreenManager, true,
                    new GameScreen(3) );
                    // ScreenManager.AddScreen(new GameScreen());
                    ScreenManager.RemoveScreen( this );
                    break;
                case 5:
                    GameEngine.AudioManager.Stop();
                    LoadingScreen.Load( ScreenManager, true,
                    new GameScreen(4) );
                    // ScreenManager.AddScreen(new GameScreen());
                    ScreenManager.RemoveScreen( this );
                    break;
                case 6:
                    GameEngine.AudioManager.Stop();
                    LoadingScreen.Load( ScreenManager, true,
                    new GameScreen(5) );
                    // ScreenManager.AddScreen(new GameScreen());
                    ScreenManager.RemoveScreen( this );
                    break;
                case 7:
                    GameEngine.AudioManager.Stop();
                    LoadingScreen.Load( ScreenManager, true,
                    new GameScreen(6) );
                    // ScreenManager.AddScreen(new GameScreen());
                    ScreenManager.RemoveScreen( this );
                    break;
                case 8:
                    GameEngine.AudioManager.Play( AudioManager.SFXSelection.menu_select );
                    OnCancel();
                    break;

            }

            /******** END YOUR CODE **********/
        }
        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected override void OnCancel()
        {
            ScreenManager.AddScreen(new MainMenu());
            ScreenManager.RemoveScreen( this );
        }
    }
}
