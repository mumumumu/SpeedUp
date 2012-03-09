#region Using Statements
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

#endregion

//Code by Rajiv Puvvada

namespace speedup {
    /// <summary>
    /// Base class for screens that contain a menu of options. The user can
    /// move up and down to select an entry, or cancel to back out of the screen.
    /// </summary>
    abstract class MenuScreen : Screen {
        #region Fields

        List<string> menuEntries = new List<string>();
        List<Vector2> entryPositions = new List<Vector2>();

        public int selectedEntry = 0;
        public Vector2 position = Vector2.Zero;
        private float leftBorder = 100;
        private float topBorder = 100;
        #endregion

        #region Properties


        /// <summary>
        /// Gets the list of menu entry strings, so derived classes can add
        /// or change the menu contents.
        /// </summary>
        protected IList<string> MenuEntries {
            get { return menuEntries; }
        }

        protected IList<Vector2> EntryPositions {
            get { return entryPositions; }
        }

        public float LeftBorder {
            get { return leftBorder; }
            set { leftBorder = value; }
        }

        public float TopBorder {
            get { return topBorder; }
            set { topBorder = value; }
        }



        #endregion

        /// <summary>
        /// Constructor.
        /// </summary>
        public MenuScreen() {

        }

        /// <summary>
        /// Responds to user input, changing the selected entry and accepting
        /// or cancelling the menu.
        /// </summary>
        public override void HandleInput( InputState input ) {
            // Move to the previous menu entry?
            if ( input.MenuUp ) {
                selectedEntry--;

                if ( selectedEntry < 0 )
                    selectedEntry = menuEntries.Count - 1;
            }

            // Move to the next menu entry?
            if ( input.MenuDown ) {
                selectedEntry++;

                if ( selectedEntry >= menuEntries.Count )
                    selectedEntry = 0;
            }

            // Accept or cancel the menu?
            if ( input.MenuSelect ) {
                OnSelectEntry( selectedEntry );
            }
            else if ( input.MenuCancel ) {
                OnCancel();
            }

            if ( input.LeftMouseClick ) {
                for ( int i = 0; i < menuEntries.Count; i++ ) {
                    if ( input.LastMouseState.Y > entryPositions[i].Y &&
                        input.LastMouseState.Y < entryPositions[i].Y + menuSpriteFont.LineSpacing ) {
                        OnSelectEntry( i );
                    }
                }
            }

            for ( int i = 0; i < menuEntries.Count; i++ ) {
                if ( input.LastMouseState.Y > entryPositions[i].Y &&
                    input.LastMouseState.Y < entryPositions[i].Y + menuSpriteFont.LineSpacing ) {
                    selectedEntry = i;
                }
            }
        }


        /// <summary>
        /// Notifies derived classes that a menu entry has been chosen.
        /// </summary>
        protected abstract void OnSelectEntry( int entryIndex );


        /// <summary>
        /// Notifies derived classes that the menu has been cancelled.
        /// </summary>
        protected abstract void OnCancel();

        public override void Initialize() {
            base.Initialize();
        }

        public override void LoadContent() {
            base.LoadContent();
            CalculatePosition();
        }

        public virtual void CalculatePosition() {
            float totalHeight;
            totalHeight = menuSpriteFont.MeasureString( "T" ).Y;
            //totalHeight += ScreenManager.MenuSpriteFont.LineSpacing;
            totalHeight *= menuEntries.Count;

            position.Y = ( ScreenManager.GraphicsDevice.Viewport.Height + topBorder/*+ totalHeight*/) / 2;
            position.X = leftBorder;
            Console.WriteLine( position );
        }

        /// <summary>
        /// Draws the menu.
        /// </summary>
        public override void Draw() {
            ScreenManager.SpriteBatch.End();
            ScreenManager.SpriteBatch.Begin();
            ScreenManager.SpriteBatch.Draw( backgroundTexture, new Rectangle( 0, 0, ScreenManager.GraphicsDevice.Viewport.Width, ScreenManager.GraphicsDevice.Viewport.Height ), Color.White );
            ScreenManager.SpriteBatch.End();

            ScreenManager.SpriteBatch.Begin();
            Vector2 itemPosition = position;

            // Draw each menu entry in turn.
            //ScreenManager.SpriteBatch.Begin();

            for ( int i = 0; i < menuEntries.Count; i++ ) {
                Color color;
                float scale;
                entryPositions[i] = itemPosition;

                if ( State == ScreenState.Active && ( i == selectedEntry ) ) {
                    //// The selected entry is yellow, and has an animating size.

                    color = Color.White;
                    scale = 1;

                }
                else {
                    // Other entries are white.
                    color = Color.DarkGray;
                    scale = 1;
                }

                // Draw text, centered on the middle of each line.
                Vector2 origin = new Vector2( 0, menuSpriteFont.LineSpacing / 2 );

                ScreenManager.SpriteBatch.DrawString( menuSpriteFont, menuEntries[i],
                                                     itemPosition, color, 0, origin, scale,
                                                     SpriteEffects.None, 0 );
                // itemPosition.Y += ScreenManager.MenuSpriteFont.MeasureString("T").Y;
                itemPosition.Y += menuSpriteFont.LineSpacing;
            }

            // ScreenManager.SpriteBatch.End();
        }
    }
}
