using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using FarseerPhysics.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;
using SysWinForms = System.Windows.Forms;

/*** Code by Rajiv Puvvada and Ara Yessayan **/
/*** Modification code to work with MP3's by Sam Dannemiller **/


namespace speedup {
    /// <summary>
    /// //Screen that will run the actual game
    /// </summary>
    public class GameScreen : Screen {

        //----------------------------------------------------------------
        // Member Variables
        //----------------------------------------------------------------
        //
        public GameWorld m_current_world;          // Current World instance
        public static ContentManager GAME_CONTENT;

        public static int FORM_OFFSET;
        public Panel form_surface;
        public Thread form_thread;
        public static bool editor_mode {
            get;
            set;
        }
        Editor editor;
        Vector2 editor_camera_movement;

        public static Camera m_curr_view;              // Camera
        public Camera m_edit_view;              // Camera
        public Camera m_play_view;              // Camera
        public static Polygondrawer m_polygon_drawer;     // Manages polygon drawing
        SpriteBatch m_sprite_batch;
        public static int GAME_WIDTH;
        public static int GAME_HEIGHT;
        GraphicsDevice m_graphics_device;
        public static Texture2D m_background;

        public static Timer m_timer;        // Timer
        public static PowerBar m_power_bar;
        private bool first_effect_played;
        private bool second_effect_played;
        private bool score_saved;
        private int win_text_delay;
        private int m_display_score;
        private bool m_paused;
        private bool m_editor_focused;
        public static bool m_halted;
        public static int checkpoint_countdown;
        public static int m_checkpoint_timer;
        //For distance from center of current view
        public static float dist_to_screen_edge {
            get {
                return ( ( ( m_curr_view.m_view_height +
                    m_curr_view.m_view_width ) / 2 )
                    / m_curr_view.m_camera_zoom )
                    / GameWorld.SCALE;
            }
        }

        private Texture2D m_blank_texture;

        public static bool within_screen_bounds( Vector2 pos,
            float bounds = 0, Vertices vertices = null ) {
            float boundary = bounds;
            Vector2 game_camera_pos =
                m_curr_view.m_camera_position / GameWorld.SCALE;

            if ( boundary <= 0 ) {
                boundary = dist_to_screen_edge * 1.2f;

            }
            if ( vertices == null ) {

                //Console.WriteLine(boundary);
                return ( pos - game_camera_pos ).Length() < boundary;
            }
            else {
                return true;

                //Checks all throughout the polygon
                /* float poly_radius = Math.Abs( vertices.GetRadius() );
                bool if_center_in = Vector2.Distance( pos, 
                    game_camera_pos ) < boundary + poly_radius;
                return if_center_in ||
                       vertices.Any(
                           vec =>
                           Vector2.Distance( pos + vec, 
                           game_camera_pos ) < boundary + poly_radius )
                       ||
                       vertices.Any(
                           vec =>
                           Vector2.Distance( pos - vec, 
                           game_camera_pos ) < boundary + poly_radius )
                       ||
                       vertices.Any(
                           vec =>
                           Vector2.Distance( pos + vec / 2 - vec, 
                           game_camera_pos ) < boundary + poly_radius )
                       ||
                        vertices.Any(
                           vec =>
                           Vector2.Distance( pos - vec / 2, 
                           game_camera_pos ) < boundary + poly_radius )
                       ||
                       vertices.Any(
                           vec =>
                           ( pos + vec / 4 - game_camera_pos ).Length() <
                           boundary + poly_radius )
                       ||
                       vertices.Any(
                           vec =>
                           ( pos - vec / 4 - game_camera_pos ).Length() <
                           boundary + poly_radius );

                                          */


            }
        }

        // NEEDS TO BE REWORKED
        Type[] m_worlds = new Type[] { // Type array of all our worlds
            typeof( speedup.GameWorld ),
            typeof( speedup.TestWorld )
        };

        // would like to get rid of this
        private static GameScreen instance;
        public static GameScreen Instance {
            get {
                if ( instance == null )
                    instance = new GameScreen();
                return instance;
            }
        }

        public GameScreen() {
            State = ScreenState.Active;
            GameEngine.LevelManager.current_level = 0;
        }

        public GameScreen(int level)
        {
            State = ScreenState.Active;
            GameEngine.LevelManager.current_level = level;
        }
        
        public override void Initialize() {
            m_sprite_batch = ScreenManager.SpriteBatch;
            m_graphics_device = ScreenManager.GraphicsDevice;
            GAME_CONTENT = ScreenManager.ContentManager;

            m_timer = new Timer();
            // m_power_bar = new PowerBar();

            m_paused = false;

            //Create the form to which we will add the editor panel
            form_surface = new Panel();

            //Create an instance of the level editor and put it on the main screen
            editor = new Editor( this );
            editor.MouseHover += new EventHandler( editor_MouseHover );
            Control.FromHandle( ( GameEngine.GameWindow.Handle ) ).VisibleChanged
                += new EventHandler( GameScreen_VisibleChanged );
            form_surface.Width = 300;
            form_surface.Height = Form.FromHandle( GameEngine.GameWindow.Handle ).Height;
            Form.FromHandle( GameEngine.GameWindow.Handle ).Click
                += new System.EventHandler( gameControl_Click );
            Form.FromHandle( GameEngine.GameWindow.Handle ).MouseHover
                += new EventHandler( GameScreen_MouseHover );
            Form.FromHandle( GameEngine.GameWindow.Handle ).MouseLeave
                += new EventHandler( GameScreen_MouseLeave );
            editor_camera_movement = Vector2.Zero;
            FORM_OFFSET = 0;
            editor_mode = false;

            GAME_WIDTH = GameEngine.GraphicsDeviceManager.PreferredBackBufferWidth;
            GAME_HEIGHT = GameEngine.GraphicsDeviceManager.PreferredBackBufferHeight;
            GameEngine.GraphicsDeviceManager.ApplyChanges();

            //m_play_view = new Camera(m_graphics_device.Viewport);
            m_curr_view = new Camera( m_graphics_device.Viewport, 0 );
            // m_curr_view = m_edit_view;

            m_polygon_drawer = new Polygondrawer( m_graphics_device,
                   GAME_WIDTH, GAME_HEIGHT, m_curr_view, BlendState.AlphaBlend );
            LoadContent();
        }

        void GameScreen_MouseLeave( object sender, EventArgs e ) {
            if ( editor_mode ) {
                editor.Focus();
                m_editor_focused = true;
            }
        }

        void GameScreen_MouseHover( object sender, EventArgs e ) {
            Form.FromHandle( ( GameEngine.GameWindow.Handle ) ).Focus();
            m_editor_focused = false;
        }

        void editor_MouseHover( object sender, EventArgs e ) {
            editor.Focus();
            m_editor_focused = true;
        }

        void GameScreen_VisibleChanged( object sender, EventArgs e ) {
            if ( Control.FromHandle( ( GameEngine.GameWindow.Handle ) ).Visible )
                Control.FromHandle( ( GameEngine.GameWindow.Handle ) ).Visible = false;
        }

        public override void LoadContent() {


            // Load world assets
            TestWorld.load_content( GAME_CONTENT );
            //m_power_bar.m_texture =
            //     GAME_CONTENT.Load<Texture2D>( "Art/speedup-Powerbar" );
            //m_power_bar.m_bar_texture =
            //   GAME_CONTENT.Load<Texture2D>( "Art/speedup-Bar" );
            m_blank_texture = GAME_CONTENT.Load<Texture2D>( "blank" );
            base.LoadContent();
        }


        private void gameControl_Click( object sender, EventArgs e ) {
            Form.FromHandle( GameEngine.GameWindow.Handle ).Focus();
            editor.gameControl_Click( sender, e );
        }

        /// <summary>
        /// When the user cancels the main menu, ask if they want to exit the sample.
        /// </summary>
        protected void OnCancel() {
            GameEngine.AudioManager.Stop();
            GameEngine.AudioManager.Play( AudioManager.MusicSelection.ninjawarrior );
            
            //ScreenManager.AddScreen( new MainMenu() );
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

        public override void HandleInput( InputState input ) {
            // Move to the previous level?
            /*  if (input.PreviousLevel) {
                  m_current_level--;

                  if (m_current_level < 0)
                      m_current_level = m_worlds.Length - 1;
              }
            */
            // Move to the next level?

            //Disables inputs if editor has focus
            if ( !m_editor_focused ) {
                if ( input.NextLevel && m_current_world.m_succeeded )
                {
                    GameEngine.LevelManager.next_level();
                    if ( GameEngine.LevelManager.get_current_level().Equals( "end" ) )
                    {
                        GameEngine.AudioManager.Stop();
                        ScreenManager.AddScreen( new EndScreen() );
                        ScreenManager.RemoveScreen( this );
                    }
                    else
                    {
                        float time = GameEngine.LevelManager.timer_select();
                        m_timer.set( time );
                        m_checkpoint_timer = (int)Math.Ceiling( time );
                        m_current_world = new TestWorld( GameScreen.m_curr_view, editor,
                                                        GameEngine.LevelManager.get_current_level() );
                        m_background =
                            GAME_CONTENT.Load<Texture2D>( GameEngine.LevelManager.background_texture );
                    }
                }
                if ( input.PauseGame ) {
                    m_paused = !m_paused;
                }
                if ( input.HaltControllers ) {
                    m_halted = !m_halted;
                }

                if ( input.ResetLevel ) {
                    float time = GameEngine.LevelManager.timer_select();
                    m_timer.set( time );
                    m_paused = false;
                    if ( m_current_world.curr_filename != null
                        && m_current_world.curr_filename != "" ) {
                        try {
                            m_current_world =
                                new TestWorld( GameScreen.m_curr_view, editor,
                                               m_current_world.curr_filename, teleport_camera: false );
                            m_background =
                                GAME_CONTENT.Load<Texture2D>(
                                GameEngine.LevelManager.background_texture
                                );
                            m_timer.set( m_checkpoint_timer );
                        }
                        catch {
                            m_current_world =
                                new TestWorld( GameScreen.m_curr_view, editor,
                                               GameEngine.LevelManager.get_current_level(), teleport_camera: false);
                           
                            m_background =
                                GAME_CONTENT.Load<Texture2D>(
                                GameEngine.LevelManager.background_texture
                                );
                            m_checkpoint_timer = (int)Math.Ceiling( time );
                            Console.WriteLine(
                                "ERROR when loading level. Aborting to the beginning"
                                );
                        }
                    }
                    else {
                        m_checkpoint_timer = (int)Math.Ceiling( time );
                        m_current_world =
                            new TestWorld( GameScreen.m_curr_view, editor,
                                           GameEngine.LevelManager.get_current_level(), teleport_camera: false);
                       
                        m_background = GAME_CONTENT.Load<Texture2D>(
                            GameEngine.LevelManager.background_texture
                            );
                    }
                }

                if ( input.RestartLevel && m_paused ) {
                    float time = GameEngine.LevelManager.timer_select();
                    m_checkpoint_timer = (int)Math.Ceiling( time );
                    m_timer.set( time );
                    m_paused = false;
                    m_current_world =
                        new TestWorld( GameScreen.m_curr_view, editor,
                                       GameEngine.LevelManager.get_current_level() );
                    m_background = GAME_CONTENT.Load<Texture2D>(
                        GameEngine.LevelManager.background_texture
                        );
                }


                if ( input.ToggleEditMode ) {
                    editor.clearLine();
                    System.Drawing.Point loc =
                        Form.FromHandle( GameEngine.GameWindow.Handle ).Location;
                    if ( !editor_mode ) {
                        editor.Show();
                        editor.TopMost = true;
                    }
                    else {
                        FORM_OFFSET = 0;
                        editor.Hide();
                    }
                    editor_mode = !editor_mode;
                }

                if ( editor_mode ) {
                    if ( input.editor_hide_show ) {
                        editor.Visible = !editor.Visible;
                    }
                    //BLAH
                    editor_camera_movement = Vector2.Zero;
                    if ( input.MoveUp )
                        editor_camera_movement.Y--;
                    if ( input.MoveDown )
                        editor_camera_movement.Y++;
                    if ( input.MoveLeft )
                        editor_camera_movement.X--;
                    if ( input.MoveRight )
                        editor_camera_movement.X++;
                    if ( input.ZoomIn )
                        m_curr_view.m_camera_zoom =
                            Math.Min( m_curr_view.m_camera_zoom + 0.1f, 0.8f );
                    if ( input.ZoomOut )
                        m_curr_view.m_camera_zoom =
                            Math.Max( m_curr_view.m_camera_zoom - 0.1f, 0.15f );
                    m_curr_view.m_camera_position +=
                        editor_camera_movement * 30 / m_curr_view.m_camera_zoom;

                    if ( editor.currentTool == Editor.EditorTool.Selection
                        && editor.current_selector != null ) {
                        if ( input.LeftMouseClick
                            && editor.current_selector.m_body != null
                            && editor.current_selector.m_body.FixtureList != null ) {
                            editor.current_selector.m_body.Position = editor.getMouse();
                        }
                    }
                }
                else {
                    if ( m_current_world != null ) {
                        m_current_world.m_ninja_controller.HandleInput( input );
                    }
                }

            }
            // Accept or cancel the menu?
            if ( input.MenuCancel ) {
                OnCancel();
            }

            base.HandleInput( input );
        }

        public override void Update( GameTime game_time ) {
            if ( editor_mode ) {
                editor.Update2();
                //Update ninja bindings
                editor.ninjaBindingSource.EndEdit();
                editor.alienBindingSource.EndEdit();
                editor.floorTileBindingSource.EndEdit();
                editor.gameObjectBindingSource.EndEdit();
                editor.polygonObjectBindingSource.EndEdit();
                editor.triggerBindingSource.EndEdit();
                editor.triggerableObjectBindingSource.EndEdit();
                editor.m_pointsBindingSource.EndEdit();
            }

            if ( m_current_world != null ) {
                if ( !m_current_world.m_succeeded &&
                    !m_current_world.m_failed && !m_paused ) {
                    //------------------------------------------------------------
                    // Logic for Timer
                    //------------------------------------------------------------
                    if ( m_timer.m_is_active == false ) {
                        m_timer.set( 121 );
                    }
                    else if ( !m_halted ) {
                        m_timer.check_timer( game_time );
                    }

                    //if ( m_current_world.m_ninja != null )
                    //{
                    //    m_power_bar.m_ninja = m_current_world.m_ninja;
                    //}
                    //m_power_bar.update( game_time );

                    m_current_world.simulate( (float)game_time.ElapsedGameTime.TotalSeconds );

                }
            }
            else {
                float time = GameEngine.LevelManager.timer_select();
                m_checkpoint_timer = (int)Math.Ceiling( time );
                m_timer.set( time );

                m_current_world =
                    new TestWorld( GameScreen.m_curr_view, editor,
                        GameEngine.LevelManager.get_current_level() );
                m_background =
                    GAME_CONTENT.Load<Texture2D>(
                    GameEngine.LevelManager.background_texture
                    );
            }
        }

        public override void Draw() {

            if ( m_current_world != null ) {
                m_current_world.Draw( m_sprite_batch, m_curr_view );
                if ( m_current_world.m_succeeded && !m_current_world.m_failed ) {
                    m_sprite_batch.Draw( m_blank_texture,
                             new Rectangle( 0, 0, GAME_WIDTH, GAME_HEIGHT ),
                             Color.Black * .75f );
                    GameEngine.AudioManager.Stop();
                    float level_score = 1000 +
                        ( ( m_current_world.m_enemy_slain * 1000 ) / m_current_world.m_enemy_count ) +
                        10 * m_timer.m_end_count;
                    string levelComplete = "Level Complete!";
                    Vector2 levelCompleteSize = menuSpriteFont.MeasureString(
                        levelComplete
                        );
                    m_sprite_batch.DrawString( menuSpriteFont, levelComplete,
                        new Vector2( GAME_WIDTH / 2, ( GAME_HEIGHT - 10 *
                            menuSpriteFont.LineSpacing ) / 2 ), Color.White, 0,
                        new Vector2( levelCompleteSize.X / 2, levelCompleteSize.Y / 2 ),
                        1.5f, 0, 0 );
                    if ( win_text_delay > 60 ) {
                        if ( !first_effect_played ) {
                            GameEngine.AudioManager.Play(
                                AudioManager.SFXSelection.throw_sfx
                                );
                            first_effect_played = true;
                        }
                        string timeRemaining = "Time remaining: "
                            + m_timer.m_display_value + " seconds";
                        Vector2 timeRemainingSize = menuSpriteFont.MeasureString(
                            timeRemaining
                            );
                        m_sprite_batch.DrawString( menuSpriteFont, timeRemaining,
                            new Vector2( GAME_WIDTH / 2, ( GAME_HEIGHT -
                                8 * menuSpriteFont.LineSpacing ) / 2 ), Color.White, 0,
                            new Vector2( timeRemainingSize.X / 2, timeRemainingSize.Y / 2 ),
                            1.5f, 0, 0 );
                    }
                    if ( win_text_delay > 120 ) {
                        if ( !second_effect_played ) {
                            GameEngine.AudioManager.Play(
                                AudioManager.SFXSelection.throw_sfx
                                );
                            second_effect_played = true;
                        }
                        string alienSlain = "Aliens Slain: "
                            + m_current_world.m_enemy_slain + "/"
                            + m_current_world.m_enemy_count;
                        Vector2 alienSlainSize =
                            menuSpriteFont.MeasureString( alienSlain );
                        m_sprite_batch.DrawString( menuSpriteFont, alienSlain,
                            new Vector2( GAME_WIDTH / 2, ( GAME_HEIGHT -
                                6 * menuSpriteFont.LineSpacing ) / 2 ),
                                Color.White, 0,
                            new Vector2( alienSlainSize.X / 2,
                                alienSlainSize.Y / 2 ), 1.5f, 0, 0 );
                    }
                    if ( win_text_delay > 180 ) {
                        string totalScore = "Total Score: " + m_display_score;
                        Vector2 totalScoreSize = menuSpriteFont.MeasureString( totalScore );
                        m_sprite_batch.DrawString( menuSpriteFont, totalScore,
                            new Vector2( GAME_WIDTH / 2, ( GAME_HEIGHT -
                                4 * menuSpriteFont.LineSpacing ) / 2 ), Color.White, 0,
                            new Vector2( totalScoreSize.X / 2, totalScoreSize.Y / 2 ),
                            1.5f, 0, 0 );
                        if ( m_display_score < level_score ) {
                            GameEngine.AudioManager.Play(
                                AudioManager.SFXSelection.point_count
                                );
                            m_display_score = m_display_score + 50;
                        }
                        else {
                            if ( !score_saved ) {
                                GameEngine.LevelManager.SaveHighScore( m_display_score );
                                GameEngine.LevelManager.reload_scores();
                                score_saved = true;
                            }
                            string continueString = "Hit 'N' to continue. . .";
                            Vector2 continueStringSize =
                                menuSpriteFont.MeasureString( continueString );
                            m_sprite_batch.DrawString( menuSpriteFont, continueString,
                                new Vector2( GAME_WIDTH / 2, ( GAME_HEIGHT -
                                    2 * menuSpriteFont.LineSpacing ) / 2 ), Color.White, 0,
                                new Vector2( continueStringSize.X / 2, continueStringSize.Y / 2 ),
                                1.5f, 0, 0 );
                        }
                    }

                    win_text_delay++;
                }
                else {
                    win_text_delay = 0;
                    m_display_score = 0;
                    first_effect_played = false;
                    second_effect_played = false;
                    score_saved = false;
                }
                if ( !m_current_world.m_succeeded && m_current_world.m_failed ) {
                    m_sprite_batch.Draw( m_blank_texture,
                             new Rectangle( 0, 0, GAME_WIDTH, GAME_HEIGHT ),
                             Color.DarkRed * .35f );
                    string LostString = "GAME OVER MAN, GAME OVER!";
                    Vector2 LostSize = menuSpriteFont.MeasureString( LostString );
                    string TryAgainString = "PRESS R TO TRY AGAIN";
                    Vector2 TryAgainSize =
                        menuSpriteFont.MeasureString( TryAgainString );

                    m_sprite_batch.DrawString( menuSpriteFont, LostString,
                       new Vector2( ( FORM_OFFSET + GAME_WIDTH ) / 2,
                           ( GAME_HEIGHT - menuSpriteFont.LineSpacing ) / 2 ),
                           Color.White, 0,
                       new Vector2( LostSize.X / 2, LostSize.Y / 2 ), 1.5f, 0, 0 );
                    m_sprite_batch.DrawString( menuSpriteFont, TryAgainString,
                       new Vector2( ( FORM_OFFSET + GAME_WIDTH ) / 2,
                           ( GAME_HEIGHT + 2 * menuSpriteFont.LineSpacing ) / 2 ),
                           Color.White, 0,
                       new Vector2( TryAgainSize.X / 2, TryAgainSize.Y / 2 ), 1.5f, 0, 0 );
                }
            }
            //------------------------------------------------------------
            // draw power bar
            //------------------------------------------------------------
            //m_sprite_batch.Draw( m_power_bar.m_texture,
            //    new Vector2( FORM_OFFSET, 0 ),
            //    Color.White );
            //m_sprite_batch.Draw( m_power_bar.m_bar_texture,
            //    new Vector2( FORM_OFFSET + 35, m_power_bar.m_texture.Height / 5 ),
            //    m_power_bar.m_bar, Color.White );

            //------------------------------------------------------------
            // draw Timer
            //------------------------------------------------------------
            //
            // Should be moved to game world? wach world could have different time

            m_sprite_batch.DrawString( menuSpriteFont, "HIGH SCORE: " + GameEngine.LevelManager.get_current_high_score().ToString(),
                   new Vector2( 20, 0 ), Color.Red, 0,
                   Vector2.Zero, 1.5f, 0, 0 );

            if ( m_timer.m_is_active && !m_timer.m_is_complete ) {
                m_sprite_batch.DrawString( menuSpriteFont, m_timer.m_display_value,
                    new Vector2( FORM_OFFSET + GAME_WIDTH - 80, 0 ), Color.Red, 0,
                    Vector2.Zero, 1.5f, 0, 0 );
            }
            else if ( m_timer.m_is_complete ) {
                m_current_world.m_ninja.destroy();
                m_current_world.m_ninja.remove_from_world();
                m_current_world.Fail();
                m_timer.reset();
            }

            if ( m_paused ) {
                m_sprite_batch.Draw( m_blank_texture,
                             new Rectangle( 0, 0, GAME_WIDTH, GAME_HEIGHT ),
                             Color.Black * .75f );
                string PausedString = "PAUSED";
                Vector2 PausedSize = menuSpriteFont.MeasureString( PausedString );
                m_sprite_batch.DrawString( menuSpriteFont, "PAUSED",
                    new Vector2( ( FORM_OFFSET + GAME_WIDTH ) / 2,
                        ( GAME_HEIGHT - menuSpriteFont.LineSpacing ) / 3 ),
                        Color.Red, 0,
                    new Vector2( PausedSize.X / 2, PausedSize.Y / 2 ),
                    1.5f, 0, 0 );

                string ResetString = "'R': RESET to CHECKPOINT." + "\n"
                    + " 'T': RESET to RESTART while paused";
                Vector2 ResetSize = menuSpriteFont.MeasureString( ResetString );
                m_sprite_batch.DrawString( menuSpriteFont, ResetString,
                    new Vector2( ( FORM_OFFSET + GAME_WIDTH ) / 2,
                        ( GAME_HEIGHT - menuSpriteFont.LineSpacing ) / 2 ),
                        Color.LightGoldenrodYellow, 0,
                    new Vector2( ResetSize.X / 2, ResetSize.Y / 2 ), 1.5f, 0, 0 );
            }

            if ( checkpoint_countdown > 0 ) {

                m_sprite_batch.DrawString( menuSpriteFont,
                    "Checkpoint Reached!",
                    new Vector2( ( GAME_WIDTH - 100 ) / 2,
                        ( GAME_HEIGHT - menuSpriteFont.LineSpacing ) / 2 ),
                        Color.YellowGreen );
                checkpoint_countdown--;
            }

        }
    }

}

