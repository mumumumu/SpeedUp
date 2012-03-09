#region File Description
//-----------------------------------------------------------------------------
// InputState.cs
//
// Microsoft XNA Community Game Platform
// Copyright (C) Microsoft Corporation. All rights reserved.
//-----------------------------------------------------------------------------
#endregion

#region Using Statements
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
#endregion

//Code by Rajiv Puvvada

namespace speedup {
    /// <summary>
    /// Helper for reading input from keyboard and gamepad. This class tracks both
    /// the current and previous state of both input devices, and implements query
    /// properties for high level input actions such as "move up through the menu"
    /// or "pause the game".
    /// </summary>
    public class InputState {
        #region Fields

        public KeyboardState CurrentKeyboardState;
        public GamePadState CurrentGamePadState;
        public MouseState CurrentMouseState;


        public KeyboardState LastKeyboardState;
        public GamePadState LastGamePadState;
        public MouseState LastMouseState;

        #endregion

        #region Properties


        /// <summary>
        /// Checks for a "menu up" input action (on either keyboard or gamepad).
        /// </summary>
        public bool MenuUp {
            get {
                return IsNewKeyPress( Keys.W ) || IsNewKeyPress( Keys.Up ) ||
                       ( CurrentGamePadState.DPad.Up == ButtonState.Pressed &&
                        LastGamePadState.DPad.Up == ButtonState.Released ) ||
                       ( CurrentGamePadState.ThumbSticks.Left.Y > 0 &&
                        LastGamePadState.ThumbSticks.Left.Y <= 0 );
            }
        }


        /// <summary>
        /// Checks for a "menu down" input action (on either keyboard or gamepad).
        /// </summary>
        public bool MenuDown {
            get {
                return IsNewKeyPress( Keys.S ) || IsNewKeyPress( Keys.Down ) ||
                       ( CurrentGamePadState.DPad.Down == ButtonState.Pressed &&
                        LastGamePadState.DPad.Down == ButtonState.Released ) ||
                       ( CurrentGamePadState.ThumbSticks.Left.Y < 0 &&
                        LastGamePadState.ThumbSticks.Left.Y >= 0 );
            }
        }

        /// <summary>
        /// Checks for a "menu up" input action (on either keyboard or gamepad).
        /// </summary>
        public bool MenuRight {
            get {
                return IsNewKeyPress( Keys.D ) || IsNewKeyPress( Keys.Right ) ||
                       ( CurrentGamePadState.DPad.Right == ButtonState.Pressed &&
                        LastGamePadState.DPad.Right == ButtonState.Released ) ||
                       ( CurrentGamePadState.ThumbSticks.Left.X > 0 &&
                        LastGamePadState.ThumbSticks.Left.X <= 0 );
            }
        }


        /// <summary>
        /// Checks for a "menu down" input action (on either keyboard or gamepad).
        /// </summary>
        public bool MenuLeft {
            get {
                return IsNewKeyPress( Keys.A ) || IsNewKeyPress( Keys.Left ) ||
                       ( CurrentGamePadState.DPad.Left == ButtonState.Pressed &&
                        LastGamePadState.DPad.Left == ButtonState.Released ) ||
                       ( CurrentGamePadState.ThumbSticks.Left.X < 0 &&
                        LastGamePadState.ThumbSticks.Left.X >= 0 );
            }
        }


        /// <summary>
        /// Checks for a "menu select" input action (on either keyboard or gamepad).
        /// </summary>
        public bool MenuSelect {
            get {
                return IsNewKeyPress( Keys.Space ) ||
                       IsNewKeyPress( Keys.Enter ) ||
                       ( CurrentGamePadState.Buttons.A == ButtonState.Pressed &&
                        LastGamePadState.Buttons.A == ButtonState.Released ) ||
                       ( CurrentGamePadState.Buttons.Start == ButtonState.Pressed &&
                        LastGamePadState.Buttons.Start == ButtonState.Released );
            }
        }


        /// <summary>
        /// Checks for a "menu cancel" input action (on either keyboard or gamepad).
        /// </summary>
        public bool MenuCancel {
            get {
                return IsNewKeyPress( Keys.Escape ) ||
                       ( CurrentGamePadState.Buttons.B == ButtonState.Pressed &&
                        LastGamePadState.Buttons.B == ButtonState.Released ) ||
                       ( CurrentGamePadState.Buttons.Back == ButtonState.Pressed &&
                        LastGamePadState.Buttons.Back == ButtonState.Released );
            }
        }

        /// <summary>
        /// Checks for a "menu edit" input action (on either keyboard or gamepad).
        /// </summary>
        public bool MenuEdit {
            get {
                return IsNewKeyPress( Keys.RightShift ) ||
                       ( CurrentGamePadState.Buttons.X == ButtonState.Pressed &&
                        LastGamePadState.Buttons.X == ButtonState.Released );
            }
        }


        /// <summary>
        /// Checks for a "pause the game" input action (on either keyboard or gamepad).
        /// </summary>
        public bool PauseGame {
            get {
                return IsNewKeyPress( Keys.P ) ||
                       ( CurrentGamePadState.Buttons.Start == ButtonState.Pressed &&
                        LastGamePadState.Buttons.Start == ButtonState.Released );
            }
        }

        /// <summary>
        /// Halts the controllers so the player can add things
        /// </summary>
        public bool HaltControllers {
            get { return IsNewKeyPress( Keys.Home ); }
        }

        public bool MuteToggle {
            get {
                return IsNewKeyPress( Keys.M );
            }
        }

        /// <summary>
        /// Checks for a "pause the game" input action (on either keyboard or gamepad).
        /// </summary>
        public bool NextLevel {
            get {
                return IsNewKeyPress( Keys.N );
            }
        }

        /// <summary>
        /// Checks for a "pause the game" input action (on either keyboard or gamepad).
        /// </summary>
        public bool PreviousLevel {
            get {
                return IsNewKeyPress( Keys.P );
            }
        }

        public bool ResetLevel {
            get {
                return IsNewKeyPress( Keys.R );
            }
        }
        public bool RestartLevel {
            get {
                return IsNewKeyPress( Keys.T );
            }
        }

        public bool ToggleEditMode {
            get {
                return IsNewKeyPress( Keys.Insert );
            }
        }

        public bool MoveUp {
            get {
                return CurrentKeyboardState.IsKeyDown( Keys.W ) || CurrentKeyboardState.IsKeyDown( Keys.Up );
            }
        }

        public bool MoveDown {
            get {
                return CurrentKeyboardState.IsKeyDown( Keys.S ) || CurrentKeyboardState.IsKeyDown( Keys.Down );
            }
        }

        public bool MoveLeft {
            get {
                return CurrentKeyboardState.IsKeyDown( Keys.A ) || CurrentKeyboardState.IsKeyDown( Keys.Left );
            }
        }

        public bool MoveRight {
            get {
                return CurrentKeyboardState.IsKeyDown( Keys.D ) || CurrentKeyboardState.IsKeyDown( Keys.Right );
            }
        }

        public bool NinjaPickUp {
            get {
                return RightMouseClick;
            }
        }


        public bool NinjaThrow {
            get {
                return IsNewKeyPress( Keys.Space ) || LeftMouseClick;
            }
        }

        public bool NinjaBoost {
            get {
                return IsNewKeyPress( Keys.Delete );
            }
        }


        public bool NinjaToggle {
            get {
                return IsNewKeyPress( Keys.LeftShift );
            }
        }

        public bool ZoomIn {
            get {
                return CurrentKeyboardState.IsKeyDown( Keys.X );
            }
        }

        public bool ZoomOut {
            get {
                return CurrentKeyboardState.IsKeyDown( Keys.Z );
            }
        }

        public bool LeftMouseClick {
            get {
                return ( CurrentMouseState.LeftButton == ButtonState.Released &&
                    LastMouseState.LeftButton == ButtonState.Pressed );
            }
        }

        public bool RightMouseClick {
            get {
                return ( CurrentMouseState.RightButton == ButtonState.Released &&
                    LastMouseState.RightButton == ButtonState.Pressed );
            }
        }

        /// <summary>
        /// Temporarily hides/shows the editor
        /// </summary>
        public bool editor_hide_show {
            get { return IsNewKeyPress( Keys.H ); }
        }
        #endregion

        #region Methods


        /// <summary>
        /// Reads the latest state of the keyboard and gamepad.
        /// </summary>
        public void Update() {
            LastKeyboardState = CurrentKeyboardState;
            LastGamePadState = CurrentGamePadState;
            LastMouseState = CurrentMouseState;


            CurrentKeyboardState = Keyboard.GetState();
            CurrentGamePadState = GamePad.GetState( PlayerIndex.One );
            CurrentMouseState = Mouse.GetState();
        }


        /// <summary>
        /// Helper for checking if a key was newly pressed during this update.
        /// </summary>
        bool IsNewKeyPress( Keys key ) {
            return ( CurrentKeyboardState.IsKeyDown( key ) &&
                    LastKeyboardState.IsKeyUp( key ) );
        }

        #endregion
    }
}
