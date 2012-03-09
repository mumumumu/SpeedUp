//========================================================================
// speedup-TestWorld.cs : Test level for our gameplay prototype.
//========================================================================
//
// Author: Jeff Mu

using System;
using System.Collections.Generic;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace speedup {
    public class TestWorldContent {
    }
    public class TestWorld : GameWorld {
        #region Constants
        //----------------------------------------------------------------
        // Constants
        //----------------------------------------------------------------
        //
        // Dimensions of the game world
        // Width/Height don't really work, they just represent the 
        // Game Width and height each / SCALE (which is 50 at the moment)
        private const float WIDTH = 16.0f;
        private const float HEIGHT = 12.0f;
        private const float GRAVITY = 0.0f;
        #endregion
        #region Static Variables
        //----------------------------------------------------------------
        // Static Variables
        //----------------------------------------------------------------
        private static float GAME_WIDTH;
        private static float GAME_HEIGHT;
        private static float move_camera_x;
        private static float move_camera_y;
        private static float scroll_x;
        private static float scroll_y;
        public static SpriteFont game_font;
        private static Texture2D ninja_texture;
        public static Texture2D ninja_animate_texture;
        public static Texture2D shuriken;
        public static Texture2D alien_bomb;
        public static Texture2D boulder_texture;
        public static Texture2D laser_texture;
        public static Texture2D ground_texture;
        public static Texture2D ball_texture;
        public static Texture2D easy_alien_texture;
        public static Texture2D easy_alien_death;
        public static Texture2D easy_alien_attack;
        public static Texture2D medium_alien_texture;
        public static Texture2D medium_alien_death;
        public static Texture2D medium_alien_attack;
        public static Texture2D hard_alien_texture;
        public static Texture2D hard_alien_death;
        public static Texture2D hard_alien_attack;
        public static Texture2D plated_alien_texture;
        public static Texture2D plated_alien_death;
        public static Texture2D spiked_alien_texture;
        public static Texture2D spiked_alien_death;
        public static Texture2D spiked_alien_attack;
        public static Texture2D chaser_alien_texture;
        public static Texture2D spawner_alien_texture;
        public static Texture2D wall_texture;
        public static Texture2D floor_texture;
        public static Texture2D breakwall_texture;
        public static Texture2D[] breakwall_texture_animate;
        public static Texture2D win_texture;
        public static Texture2D lose_texture;
        public static Texture2D ground_switch_active_texture;
        public static Texture2D ground_switch_inactive_texture;
        public static Texture2D ground_switch_animate_texture;
        public static Texture2D wall_switch_active_texture;
        public static Texture2D wall_switch_inactive_texture;
        public static Texture2D door_texture;
        public static Texture2D trail_texture;
        public static Texture2D sonic_texture;
        public static Texture2D pix_texture;
        public static Texture2D bluenova_texture;
        public static Texture2D rednova_texture;
        public static Texture2D bluenova_attack_texture;
        public static Texture2D rednova_attack_texture;
        public static Texture2D flame_texture;
        public static Texture2D m_background;
        public static Texture2D space_texture;
        public static Texture2D highlight_texture;
        public static Texture2D queen_texture;
        public static Texture2D queen_attack_texture;
        public static Texture2D queen_death_texture;
        public static Texture2D egg_texture;
        public static Texture2D alien_turret;

        private static Camera eye;
        private static float wall_width = 0.5f;
        // private static readonly Vector2 ninja_position = new Vector2( -11f, 132 );
        private static readonly Vector2 ninja_position = new Vector2( -11, 132 );
        private static readonly Vector2[][] walls = new[]
        {                                               
            #region Endpoint
		    new[]
            {
                new Vector2( 2, 2 ), new Vector2( wall_width, 8 )
            },
           /* new[]
            {
                new Vector2( 2, 2 ), new Vector2( 4, wall_width )
            },*/
            new[]
            {
                new Vector2( 6, 2 ), new Vector2( wall_width, 8 )
            },
            new[]
            {
                new Vector2( 6, 10 ), new Vector2( 6, wall_width )
            },
            new[]
            {
                new Vector2( 11.5f, 10 ), new Vector2( wall_width, 4 )
            },
            new[]
            {
                new Vector2(6, 14), new Vector2( 6, wall_width )
            },
            new[]
            {
                new Vector2(-3.5f, 10), new Vector2( 6, wall_width )
            },
            new[]
            {
                new Vector2(-3.5f, 10), new Vector2( wall_width, 4 )
            },
            new[]
            {
                new Vector2(-3.5f, 14), new Vector2( 6, wall_width )
            },
            new[]
            {
                new Vector2(2, 14), new Vector2( wall_width, 4 )
            },
            new[]
            {
                new Vector2(6, 14), new Vector2( wall_width, 4 )
            },
	        #endregion
            #region Billards
            //------------------------------------------------------------
            //  Billards area
            //------------------------------------------------------------
            new[]
            {
                new Vector2( 6, 18 ), new Vector2( 9, wall_width )
            },

            new[]
            {
                new Vector2( 15, 18 ), new Vector2( wall_width, 20.5f )
            },
            new[]
            {
                new Vector2( 6.5f, 38 ), new Vector2( 8.5f, wall_width )
            },
            new[]
            {
                new Vector2(-6.5f, 18), new Vector2( 9, wall_width )
            },
            new[]
            {
                new Vector2(-6.5f, 18), new Vector2(wall_width, 20.5f)
            },

            new[]
            {
                new Vector2(-6.5f, 38), new Vector2(8.5f, wall_width)
            },

            #endregion
            #region Maze
            //------------------------------------------------------------
            // Maze Area
            //------------------------------------------------------------
            new[]
            {
                new Vector2(-6.5f, 38), new Vector2(-6.5f + wall_width*1.2f, 38),
                new Vector2(-10.5f + wall_width*1.2f, 42), new Vector2(-10.5f,42)
            },
            new[]
            {
                new Vector2(-6f, 42), new Vector2(8.5f, wall_width)
            },

            new[]
            {
                new Vector2(-6f, 42), new Vector2(wall_width, 3.5f)
            },

           new[]
            {
                new Vector2(-6f, 45.5f), new Vector2(-3f, 42.5f),
                new Vector2(-3f + wall_width*1.2f, 42.5f), new Vector2(-6f,45.5f + wall_width*1.2f)
            },

            new[]
            {
                new Vector2(-10.5f,42), new Vector2(wall_width, 7)
            },

            new[]
            {
                new Vector2(-10f, 49f), new Vector2(-10f, 49f + wall_width*1.2f),
                new Vector2(-17f , 42f + wall_width*1.2f), new Vector2(-17f, 42f)
            },  


            new[]
            {
                new Vector2(-10f, 54.5f), new Vector2(-10f, 54.5f + wall_width*1.2f),
                new Vector2(-17f , 47.5f + wall_width*1.2f), new Vector2(-17f, 47.5f)
            },

             new[]
            {
                new Vector2(-19f,49.5f), new Vector2(4f, wall_width)
            },


             new[]
            {
                new Vector2(-19.5f, 50f),new Vector2(-17f, 47.5f),
                new Vector2(-17f , 47.5f + wall_width*1.2f),   new Vector2(-19.5f + wall_width*1.2f, 50f )
            },

                
            new[]
            {
                new Vector2(-25f + wall_width*1.2f, 50f ), new Vector2(-25f, 50f), 
                new Vector2(-17f, 42f), new Vector2(-17f , 42f + wall_width*1.2f)
            },
                

            new[]
            {
                new Vector2(-25f, 50f), new Vector2(-25f + wall_width*1.2f, 50f ), 
                new Vector2(-20.5f, 54.5f), new Vector2(-20.5f , 54.5f + wall_width*1.2f)
            },
 

             new[]
            {
                new Vector2(-20.5f,54.5f), new Vector2(4f, wall_width)
            },

             new[]
            {
                new Vector2(6.5f, 38), new Vector2(6.5f + wall_width*1.2f, 38),
                new Vector2(-14.5f + wall_width*1.2f, 59), new Vector2(-14.5f,59)
            },

            new[]
            {
                new Vector2(-19f,58.5f), new Vector2(5f, wall_width)
            },

            new[]
            {
                   
                new Vector2(-20.5f, 54.5f), new Vector2(-20.5f , 54.5f + wall_width*1.2f),
                 new Vector2(-25f + wall_width*1.2f, 58.5f), new Vector2(-25f , 58.5f ), 
            },

            new[]
            {
                new Vector2(-25f, 58.5f), new Vector2(wall_width, 4)
            },

            new[]
            {
                new Vector2(-19.5f, 58.5f), new Vector2(wall_width, 4)
            },
                #endregion
            #region SwitchRoom
            new[]
            {
                new Vector2(-25f, 62.5f), new Vector2(wall_width, 16)
            },

            new[]
            {
                new Vector2(-19.5f,62.5f), new Vector2(20.5f, wall_width)
            },

            new[]
            {
                new Vector2(-25f,78f), new Vector2(10f, wall_width)
            },

             new[]
            {
                new Vector2(-9f,78f), new Vector2(10f, wall_width)
            },

            new[]
            {
                new Vector2(1f, 62.5f), new Vector2(wall_width, 16)
            },

            new[]
            {
                new Vector2(-9f, 78f), new Vector2(wall_width, 4)
            },

             new[]
            {
                new Vector2(-15f, 78f), new Vector2(wall_width, 4)
            },

                #endregion
            #region AlienRoom
            new[]
            {
                new Vector2(-14.5f, 82f - wall_width*1.2f ), new Vector2(-14.5f, 82f),
                new Vector2(-26.5f, 94 ), new Vector2(-26.5f, 94 - wall_width*1.2f)
            },

             new[]
            {
                new Vector2(-26.5f, 93.5f ), new Vector2(wall_width, 25)
            },

            new[]
            {
                new Vector2(-26.5f, 118.5f), new Vector2(-26.5f, 118.5f - wall_width*1.2f ), 
                new Vector2(-14f, 130.5f), new Vector2(-14f, 130.5f+ wall_width*1.2f ), 
            },

            new[]
            {
                new Vector2(-14.5f, 130.5f), new Vector2(wall_width, 14)
            },

            new[]
            {
                new Vector2(-14.5f, 144.5f), new Vector2(6, wall_width)
            },

             new[]
            {
                new Vector2(-9f, 82f), new Vector2(-9f, 82f  - wall_width*1.2f ),
                new Vector2(3f, 94 - wall_width*1.2f ), new Vector2(3f, 94)
            },

             new[]
            {
                new Vector2(2.5f, 93.5f ), new Vector2(wall_width, 25)
            },

            new[]
            {
                new Vector2(3f, 118.5f - wall_width*1.2f ), new Vector2(3f, 118.5f), 
                new Vector2(-9f, 130.5f+ wall_width*1.2f), new Vector2(-9f, 130.5f ), 
            },

            new[]
                {
                    new Vector2(-9, 130.5f), new Vector2(wall_width, 14)
            },
                #endregion
        };
        private static readonly Vector2[][] break_walls = new[]
            {
                 new[]
                 {
                     new Vector2(-14.5f, 130.5f ), new Vector2( 6 , wall_width )
                 },

            };

        private static readonly Vector2[][] floor_tiles = new[]
            {
                 new[]
                 {
                     new Vector2( -34, 100 ), new Vector2( 30 , 20 )
                 },

            };

        #endregion
        #region Member Variables
        //---------------------------------------------------------------
        // Member Variables
        //---------------------------------------------------------------
        private readonly Alien m_alien_easy;
        private readonly Alien m_alien_hard;
        private readonly Alien m_alien_medium;
        private readonly Alien m_alien_spiked;
        private readonly Alien m_alien_plated;
        private List<PolygonObject> m_breakable = new List<PolygonObject>();



        Path alien_path = new Path( new[]
                 {
                     new Vector2( -15, 105 ), new Vector2( -20 , 110 )
                 } );


        #region Aliens
        // AlienRoom
        private readonly Alien alien1;
        private static readonly Vector2 alien1_pos = new Vector2( -18, 100 );
        private readonly Alien alien2;
        private static readonly Vector2 alien2_pos = new Vector2( -12, 100 );
        private readonly Alien alien3;
        private static readonly Vector2 alien3_pos = new Vector2( -6, 100 );
        private readonly Alien alien4;
        private static readonly Vector2 alien4_pos = new Vector2( -18, 110 );
        private readonly Alien alien5;
        private static readonly Vector2 alien5_pos = new Vector2( -12, 110 );
        private readonly Alien alien6;
        private static readonly Vector2 alien6_pos = new Vector2( -6, 110 );
        private readonly Alien alien18;
        private static readonly Vector2 alien18_pos = new Vector2( -16, 105 );
        private readonly Alien alien19;
        private static readonly Vector2 alien19_pos = new Vector2( -10, 105 );
        private readonly Alien alien20;
        private static readonly Vector2 alien20_pos = new Vector2( -4, 105 );

        // Maze
        private readonly Alien alien7;
        private static readonly Vector2 alien7_pos = new Vector2( -22, 59 );
        private readonly Alien alien8;
        private static readonly Vector2 alien8_pos = new Vector2( -20, 52 );
        private readonly Alien alien9;
        private static readonly Vector2 alien9_pos = new Vector2( -11, 52 );
        private readonly Alien alien10;
        private static readonly Vector2 alien10_pos = new Vector2( -8, 42 );

        // Billiards Room
        private readonly Alien alien11;
        private static readonly Vector2 alien11_pos = new Vector2( -2, 35 );
        private readonly Alien alien12;
        private static readonly Vector2 alien12_pos = new Vector2( -2, 28 );
        private readonly Alien alien13;
        private static readonly Vector2 alien13_pos = new Vector2( -2, 21 );
        private readonly Alien alien14;
        private static readonly Vector2 alien14_pos = new Vector2( 4, 21 );
        private readonly Alien alien15;
        private static readonly Vector2 alien15_pos = new Vector2( 12, 21 );
        private readonly Alien alien16;
        private static readonly Vector2 alien16_pos = new Vector2( 12, 28 );
        private readonly Alien alien17;
        private static readonly Vector2 alien17_pos = new Vector2( 12, 35 );
        #endregion
        #region Balls
        // BALLS
        private readonly Ball ball1;
        private static readonly Vector2 ball1_pos = new Vector2( -11.5f, 80 );
        private readonly Ball ball2;
        private static readonly Vector2 ball2_pos = new Vector2( -17, 45 );
        private readonly Ball ball3;
        private static readonly Vector2 ball3_pos = new Vector2( 4.5f, 25 );
        private readonly Ball ball4;
        private static readonly Vector2 ball4_pos = new Vector2( 6, 28 );
        private readonly Ball ball5;
        private static readonly Vector2 ball5_pos = new Vector2( 3, 28 );
        private readonly Ball ball6;
        private static readonly Vector2 ball6_pos = new Vector2( 3.75f, 29 );
        private readonly Ball ball7;
        private static readonly Vector2 ball7_pos = new Vector2( 5.25f, 29 );
        private readonly Ball ball8;
        private static readonly Vector2 ball8_pos = new Vector2( 4.5f, 30 );
        #endregion
        #region Switches
        private readonly Trigger floor_switch1;
        private static readonly Vector2 floor_switch1_pos = new Vector2( -11f, 86 );
        private readonly Trigger wall_switch1;
        private static readonly Vector2 wall_switch1_pos = new Vector2( -2.5f, 63.2f );
        private readonly Trigger wall_switch2;
        private static readonly Vector2 wall_switch2_pos = new Vector2( -.58f, 42.8f );
        private readonly Trigger floor_switch2;
        private static readonly Vector2 floor_switch2_pos = new Vector2( 4.2f, 12.1f );
        private readonly Trigger wall_switch3;
        private static readonly Vector2 wall_switch3_pos = new Vector2( -2.6f, 12 );
        private readonly Trigger wall_switch4;
        private static readonly Vector2 wall_switch4_pos = new Vector2( 11.15f, 12 );
        private readonly Trigger win_switch;
        private static readonly Vector2 win_switch_pos = new Vector2( 4.2f, 5 );
        #endregion
        #region Doors
        private readonly ConditionTriggered door0;
        private static readonly Vector2 door0_pos = new Vector2( -20f, 80 );
        private readonly TriggerableObject door00;
        private static readonly Vector2 door00_vertex1 = new Vector2( -15f, 81 );
        private static readonly Vector2 door00_vertex2 = new Vector2( -8.4f, 81 );
        private readonly TriggerableObject door1;
        private static readonly Vector2 door1_vertex1 = new Vector2( -15f, 80 );
        private static readonly Vector2 door1_vertex2 = new Vector2( -8.4f, 80 );
        private readonly TriggerableObject door2;
        private static readonly Vector2 door2_vertex1 = new Vector2( -25.3f, 61.9f );
        private static readonly Vector2 door2_vertex2 = new Vector2( -18.7f, 61.9f );
        private readonly TriggerableObject door3;
        private static readonly Vector2 door3_vertex1 = new Vector2( 0.03f, 38.8f );
        private static readonly Vector2 door3_vertex2 = new Vector2( 0.03f, 41.5f );
        private readonly TriggerableObject door4;
        private static readonly Vector2 door4_vertex1 = new Vector2( 1.7f, 10.85f );
        private static readonly Vector2 door4_vertex2 = new Vector2( 1.7f, 13.85f );
        private readonly TriggerableObject door5;
        private static readonly Vector2 door5_vertex1 = new Vector2( 6.75f, 10.85f );
        private static readonly Vector2 door5_vertex2 = new Vector2( 6.75f, 13.85f );
        private readonly TriggerableObject door6;
        private static readonly Vector2 door6_vertex1 = new Vector2( 2.05f, 9.81f );
        private static readonly Vector2 door6_vertex2 = new Vector2( 6.7f, 9.81f );
        private readonly TriggerableObject door7;
        private static readonly Vector2 door7_vertex1 = new Vector2( 2.05f, 2 );
        private static readonly Vector2 door7_vertex2 = new Vector2( 6.7f, 2 );
        #endregion

        #endregion
        #region Constructor
        //---------------------------------------------------------------
        // Constructor
        //---------------------------------------------------------------
        //
        // TODO: add collision_detection_position as argument to constructor?
        public TestWorld( Camera view, Editor editor, String filename, bool teleport_camera = true )
            : base( ground_texture.Width, ground_texture.Height,
            new Vector2( 0, GRAVITY ) ) {
            // play bgm

            GameEngine.LevelManager.background_select();
            GameEngine.LevelManager.song_select();

            eye = view;
            eye.m_zoom_mult = 1;
            mouse_control = new MouseController( GameScreen.GAME_WIDTH, GameScreen.GAME_HEIGHT );

            create_world( this, filename );


            editor.ninjaBindingSource.DataSource = m_ninja;
            editor.gameObjectBindingSource.DataSource = m_ninja;
            eye.m_curr_target = m_ninja;

            if (teleport_camera)
            {
                eye.m_camera_position = (m_ninja.m_position + new Vector2(0, -12)) * SCALE;
            }

            m_world.ContactManager.BeginContact += m_collision_manager.contact_started;
            m_world.ContactManager.EndContact += m_collision_manager.contact_ended;

            //Queen lisa = new Queen( this, queen_texture, m_ninja.m_position + new Vector2( 0, -50 ), 3, Alien.AlienType.QUEEN, 300 );
            //add_object( lisa );
        }

        public TestWorld( Camera view, Editor editor )
            : base( ground_texture.Width, ground_texture.Height,
            new Vector2( 0, GRAVITY ) ) {
            // play bgm

            GameEngine.LevelManager.background_select();
            GameEngine.AudioManager.Play( AudioManager.MusicSelection.tut );


            eye = view;
            //mouse_control = new MouseController( GameEngine.GAME_WIDTH, GameEngine.GAME_HEIGHT );

            //create_world( this, "World_objects.xml" );

            //editor.ninjaBindingSource.DataSource = m_ninja;

            m_world.ContactManager.BeginContact += m_collision_manager.contact_started;
            m_world.ContactManager.EndContact += m_collision_manager.contact_ended;

            Vector2[] new_wall;

            // Create ninja
            m_ninja = new Ninja( this, ninja_animate_texture,
                ninja_position, 1.0f );

            // Add floor tiles
            // Must be created first, so that other objects can be on top of it
            /*  foreach ( var tile in floor_tiles )
              {
                  // Convert dimensions in the other format
                  if ( tile.Length < 4 )
                  {
                      new_wall = new[] {
                          tile[0], new Vector2(tile[0].X + tile[1].X, tile[0].Y),
                          new Vector2(tile[0].X + tile[1].X, tile[0].Y + tile[1].Y), 
                          new Vector2(tile[0].X, tile[0].Y + tile[1].Y)  
                      };
                  }
                  else new_wall = (Vector2[])tile.Clone();
                  FloorTile b = new FloorTile( this, new_wall, floor_texture, 1.0f, 0.0f, 0.7f );
                  // add_object( b );

              }

              // Create Aliens
              m_alien_easy = new Alien( this, hard_alien_texture,
                  new Vector2( 20, 11 ), 4.0f, Alien.AlienType.EASY,
                  Alien.AlienCollisionType.NORMAL );
              add_object( m_alien_easy );
              m_alien_spiked = new Alien( this, spiked_alien_texture,
                  new Vector2( 24, 2 ), 6.0f, Alien.AlienType.SPIKED,
                  Alien.AlienCollisionType.SPIKED );
              add_object( m_alien_spiked );
              m_alien_plated = new Alien( this, plated_alien_texture,
                  new Vector2( -15, 7 ), 8.0f, Alien.AlienType.PLATED,
                  Alien.AlienCollisionType.PLATED );
              add_object( m_alien_plated );


              // Create Aliens
              alien1 = new Alien( this, easy_alien_texture, alien1_pos, .5f, Alien.AlienType.EASY );
              add_object( alien1 );
              alien2 = new Alien( this, easy_alien_texture, alien2_pos, .5f, Alien.AlienType.EASY );
              add_object( alien2 );
              AlienController alien_controller1 = new AlienController( this, alien1, AlienController.AIType.PEON, m_ninja );
              m_world.AddController( alien_controller1 );
              AlienController alien_controller2 = new AlienController( this, alien1, AlienController.AIType.PEON, m_ninja );
              m_world.AddController( alien_controller2 );
              alien7 = new Alien( this, easy_alien_texture, alien7_pos, .5f, Alien.AlienType.EASY );
              add_object( alien7 );
              AlienController alien_controller7 = new AlienController( this, alien7, AlienController.AIType.ATTACKER, m_ninja );
              m_world.AddController( alien_controller7 );
              alien8 = new Alien( this, easy_alien_texture, alien8_pos, .5f, Alien.AlienType.EASY, rotation: -1.57f );
              add_object( alien8 );
              AlienController alien_controller8 = new AlienController( this, alien8, AlienController.AIType.ATTACKER, m_ninja );
              m_world.AddController( alien_controller8 );
              alien9 = new Alien( this, easy_alien_texture, alien9_pos, .5f, Alien.AlienType.EASY, rotation: 2.33f );
              add_object( alien9 );
              AlienController alien_controller9 = new AlienController( this, alien9, AlienController.AIType.ATTACKER, m_ninja );
              m_world.AddController( alien_controller9 );
              alien10 = new Alien( this, easy_alien_texture, alien10_pos, .5f, Alien.AlienType.EASY );
              add_object( alien10 );
              AlienController alien_controller10 = new AlienController( this, alien10, AlienController.AIType.ATTACKER, m_ninja );
              m_world.AddController( alien_controller10 );
              alien11 = new Alien( this, easy_alien_texture, alien11_pos, .5f, Alien.AlienType.EASY );
              add_object( alien11 );
              AlienController alien_controller11 = new AlienController( this, alien11, AlienController.AIType.CHASER, m_ninja );
              m_world.AddController( alien_controller11 );
              alien12 = new Alien( this, easy_alien_texture, alien12_pos, .5f, Alien.AlienType.EASY );
              add_object( alien12 );
              AlienController alien_controller12 = new AlienController( this, alien12, AlienController.AIType.CHASER, m_ninja );
              m_world.AddController( alien_controller12 );
              alien13 = new Alien( this, easy_alien_texture, alien13_pos, .5f, Alien.AlienType.EASY );
              add_object( alien13 );
              AlienController alien_controller13 = new AlienController( this, alien13, AlienController.AIType.CHASER, m_ninja );
              m_world.AddController( alien_controller13 );
              alien14 = new Alien( this, spiked_alien_texture, alien14_pos, .5f, Alien.AlienType.EASY );
              add_object( alien14 );
              AlienController alien_controller14 = new AlienController( this, alien14, AlienController.AIType.CHASER, m_ninja );
              m_world.AddController( alien_controller14 );
              alien15 = new Alien( this, plated_alien_texture, alien15_pos, .5f, Alien.AlienType.EASY );
              add_object( alien15 );
              AlienController alien_controller15 = new AlienController( this, alien15, AlienController.AIType.CHASER, m_ninja );
              m_world.AddController( alien_controller15 );
              alien16 = new Alien( this, easy_alien_texture, alien16_pos, .5f, Alien.AlienType.EASY );
              add_object( alien16 );
              AlienController alien_controller16 = new AlienController( this, alien16, AlienController.AIType.CHASER, m_ninja );
              m_world.AddController( alien_controller16 );
              alien17 = new Alien( this, easy_alien_texture, alien17_pos, .5f, Alien.AlienType.EASY );
              add_object( alien17 );
              AlienController alien_controller17 = new AlienController( this, alien17, AlienController.AIType.CHASER, m_ninja );
              m_world.AddController( alien_controller17 );
              //alien18 = new Alien( m_world, easy_alien_texture, alien18_pos, .5f, Alien.AlienType.EASY );
              //add_object( alien18 );
              alien19 = new Alien( this, easy_alien_texture, alien19_pos, .5f, Alien.AlienType.MEDIUM );
              add_object( alien19 );
              AlienController alien_controller19 = new AlienController( this, alien19, AlienController.AIType.PATROL, m_ninja );
              m_world.AddController( alien_controller19 );
              //alien20 = new Alien( m_world, easy_alien_texture, alien20_pos, .5f, Alien.AlienType.EASY );
              //add_object( alien20 );

              SharedResourceList alist = new SharedResourceList();
              alist.Add( alien1 );
              alist.Add( alien2 );
              Vector2 offset = new Vector2( 0, 1 );
              SharedResourceList nlist = new SharedResourceList();
              nlist.Add(m_ninja);
              eye.m_curr_target = m_ninja;

              // Create Doors
              door00 = new TriggerableObject( this, door_texture, door00_vertex1, door00_vertex2, 0 );
              add_object( door00 );
              SharedResourceList<TriggerableObject> tlist = new SharedResourceList<TriggerableObject>();
              tlist.Add(door00);
              door0 = new ConditionTriggered( this, door_texture, door0_pos, 0,alist,t_objects:tlist,
                  c_type: ConditionTriggered.ConditionType.EVADE_ALIENS);
              add_object( door0 );
              door1 = new TriggerableObject( this, door_texture, door1_vertex1, door1_vertex2, 0 );
              add_object( door1 );
              door2 = new TriggerableObject( this, door_texture, door2_vertex1, door2_vertex2, 0 );
              add_object( door2 );
              door3 = new TriggerableObject( this, door_texture, door3_vertex1, door3_vertex2, ( (float)Math.PI / 2 ) );
              add_object( door3 );
              door4 = new TriggerableObject( this, door_texture, door4_vertex1, door4_vertex2, ( (float)Math.PI / 2 ) );
              add_object( door4 );
              door5 = new TriggerableObject( this, door_texture, door5_vertex1, door5_vertex2, ( (float)Math.PI / 2 ) );
              add_object( door5 );
              door6 = new TriggerableObject( this, door_texture, door6_vertex1, door6_vertex2, 0 );
              add_object( door6 );
              door7 = new TriggerableObject( this, door_texture, Vector2.Zero, TriggerableObject.TriggerType.GOAL, 0 );
              // add_object( door7 );

            Vector2[] vec = new Vector2[] {
                new Vector2(-20,88), new Vector2(-20,80),new Vector2(2,80),new Vector2(2,88)
            };

            PolygonTrigger poly = new PolygonTrigger( this, pix_texture, ground_switch_inactive_texture, vec, door1, Trigger.TriggerType.FLOOR, 1, 0 );
            add_object( poly );

            //Add Switches
            floor_switch1 = new Trigger( this, ground_switch_active_texture,
                ground_switch_inactive_texture, floor_switch1_pos, door1,
                Trigger.TriggerType.FLOOR, 1, 0 );
            add_object( floor_switch1 );
            wall_switch1 = new Trigger( this, wall_switch_active_texture,
                wall_switch_inactive_texture, wall_switch1_pos, door2,
                Trigger.TriggerType.WALL, 1, (float)Math.PI, texture_name:TNames.wall_switch_inactive );
            add_object( wall_switch1 );
              wall_switch2 = new Trigger( this, wall_switch_active_texture, 
                  wall_switch_inactive_texture, wall_switch2_pos, door3,
                  Trigger.TriggerType.WALL, .8f, (float)Math.PI, texture_name: TNames.wall_switch_inactive );
              add_object( wall_switch2 );
              floor_switch2 = new Trigger( this, ground_switch_active_texture, 
                  ground_switch_inactive_texture, floor_switch2_pos, door4, 
                  Trigger.TriggerType.FLOOR, 1f, 0 );
              add_object( floor_switch2 );
              wall_switch3 = new Trigger( this, wall_switch_active_texture, 
                  wall_switch_inactive_texture, wall_switch3_pos, door5,
                  Trigger.TriggerType.WALL, 2, (float)Math.PI / 2, texture_name: TNames.wall_switch_inactive );
              add_object( wall_switch3 );
              wall_switch4 = new Trigger( this, wall_switch_active_texture, 
                  wall_switch_inactive_texture, wall_switch4_pos, door6,
                  Trigger.TriggerType.WALL, 2, (float)( 3 * Math.PI / 2 ), texture_name: TNames.wall_switch_inactive );
              add_object( wall_switch4 );
              win_switch = new Trigger( this, ground_switch_active_texture, 
                  ground_switch_inactive_texture, win_switch_pos, door7, 
                  Trigger.TriggerType.FLOOR, 300, 0 );
              add_object( win_switch );

              // Create Ball
              ball1 = new Ball( this, ball_texture, ball1_pos, 2.0f );
              add_object( ball1 );
              ball2 = new Ball( this, ball_texture, ball2_pos, 2.0f );
              add_object( ball2 );
              ball3 = new Ball( this, ball_texture, ball3_pos, 2.0f );
              add_object( ball3 );
              ball4 = new Ball( this, ball_texture, ball4_pos, 2.0f );
              add_object( ball4 );
              ball5 = new Ball( this, ball_texture, ball5_pos, 2.0f );
              add_object( ball5 );
              ball6 = new Ball( this, ball_texture, ball6_pos, 2.0f );
              add_object( ball6 );
              ball7 = new Ball( this, ball_texture, ball7_pos, 2.0f );
              add_object( ball7 );
              ball8 = new Ball( this, ball_texture, ball8_pos, 2.0f );
              add_object( ball8 );

              var ball_2 = new Ball( this, ball_texture,
                  ninja_position, 1.0f );

              //Add ninja to the world
              add_object( m_ninja );
              add_object( ball_2 );
            
              */
            editor.ninjaBindingSource.DataSource = m_ninja;
            editor.gameObjectBindingSource.DataSource = m_ninja;

            // Create ninja controller
            m_ninja_controller = new NinjaController( this, m_ninja );
            m_world.AddController( m_ninja_controller );

            // Create mouse controller
            mouse_control = new MouseController( GameScreen.GAME_WIDTH, GameScreen.GAME_HEIGHT );

            /*
            // Create walls
            foreach ( var wall in walls )
            {
                // Convert dimensions in the other format
                if ( wall.Length < 4 )
                {
                    new_wall = new[] {
                        wall[0], new Vector2(wall[0].X + wall[1].X, wall[0].Y),
                        new Vector2(wall[0].X + wall[1].X, wall[0].Y + wall[1].Y), 
                        new Vector2(wall[0].X, wall[0].Y + wall[1].Y)  
                    };
                }
                else new_wall = (Vector2[]) wall.Clone();

                add_object( new PolygonObject( this, new_wall, wall_texture, 1.0f, 0.0f, 0.7f ) );
            }

            // Create breakable walls
            foreach ( var wall in break_walls )
            {
                // Convert dimensions in the other format
                if ( wall.Length < 4 )
                {
                    new_wall = new[] {
                        wall[0], new Vector2(wall[0].X + wall[1].X, wall[0].Y),
                        new Vector2(wall[0].X + wall[1].X, wall[0].Y + wall[1].Y), 
                        new Vector2(wall[0].X, wall[0].Y + wall[1].Y)  
                    };
                }
                else new_wall = (Vector2[])wall.Clone();
                PolygonObject b = new PolygonObject( this, new_wall,
                    breakwall_texture_animate[0], 1.0f, 0.0f, 0.7f, 30.0f );
                add_object( b );
            } 
            */

            //save_state();

        }
        #endregion
        #region Methods
        //---------------------------------------------------------------
        // Methods
        //---------------------------------------------------------------
        public static void load_content( ContentManager content ) {

            ninja_texture = Statics.get_texture( TNames.ninja );
            ninja_animate_texture = Statics.get_texture( TNames.ninja_animate );
            shuriken = Statics.get_texture( TNames.shuriken );
            laser_texture = Statics.get_texture( TNames.laser );
            bluenova_texture = Statics.get_texture( TNames.blue_nova );
            rednova_texture = Statics.get_texture( TNames.red_nova );
            bluenova_attack_texture = Statics.get_texture( TNames.blue_nova_attack );
            rednova_attack_texture = Statics.get_texture( TNames.red_nova_attack );
            alien_bomb = Statics.get_texture( "Art/speedup-alien-bomb-animate" );
            ground_texture = Statics.get_texture( "Art/speedup-Background" );
            wall_texture = Statics.get_texture( "Art/speedup-Wall" );
            egg_texture = Statics.get_texture("Art/speedup-queen-egg-1");
            breakwall_texture = Statics.get_texture( "Art/speedup-BreakableWall" );
            breakwall_texture_animate = new[] { Statics.get_texture( "Art/speedup-Break1" ), Statics.get_texture( "Art/speedup-Break2" ),
                  Statics.get_texture( "Art/speedup-Break3" ),Statics.get_texture( "Art/speedup-Break4" ),Statics.get_texture( "Art/speedup-Break5" )
                  };

            ball_texture = Statics.get_texture( "Art/speedup-BallSmall" );
            alien_turret = Statics.get_texture( "Art/speedup-AlienTurret" );
            easy_alien_texture = Statics.get_texture( "Art/speedup-AlienEasy" );
            easy_alien_death = Statics.get_texture( "Art/speedup-AlienEasy-death-animate" );
            easy_alien_attack = Statics.get_texture( "Art/speedup-AlienEasy-attack-animate" );
            medium_alien_texture = Statics.get_texture( "Art/speedup-AlienMedium" );
            medium_alien_death = Statics.get_texture( "Art/speedup-AlienMedium-death-animate" );
            medium_alien_attack = Statics.get_texture( "Art/speedup-AlienMedium-attack-animate" );
            hard_alien_texture = Statics.get_texture( "Art/speedup-AlienHard" );
            hard_alien_death = Statics.get_texture( "Art/speedup-AlienHard-death-animate" );
            hard_alien_attack = Statics.get_texture( "Art/speedup-AlienHard-attack-animate" );
            plated_alien_texture = Statics.get_texture( "Art/speedup-AlienPlated" );
            plated_alien_death = Statics.get_texture( "Art/speedup-AlienPlated-death-animate" );
            spiked_alien_texture = Statics.get_texture( "Art/speedup-AlienSpiky" );
            spiked_alien_death = Statics.get_texture( "Art/speedup-AlienSpiky-death-animate" );
            spiked_alien_attack = Statics.get_texture( "Art/speedup-AlienSpiky-attack-animate" );
            chaser_alien_texture = Statics.get_texture( "Art/speedup-AlienChaser" );
            spawner_alien_texture = Statics.get_texture( "Art/speedup-AlienSpawner" );
            queen_texture = Statics.get_texture("Art/speedup-QueenAlien");
            queen_attack_texture = Statics.get_texture("Art/speedup-QueenAlien-attack-animate");
            queen_death_texture = Statics.get_texture("Art/speedup-QueenAlien-death-animate");
            win_texture = Statics.get_texture( "Art/speedup-WinMessage" );
            lose_texture = Statics.get_texture( "Art/speedup-LoseMessage" );
            ground_switch_active_texture = Statics.get_texture( "Art/speedup-groundswitch" );
            ground_switch_inactive_texture = Statics.get_texture( "Art/speedup-groundswitch-depressed" );
            ground_switch_animate_texture = Statics.get_texture( "Art/speedup-groundswitch-animate" );
            wall_switch_active_texture = Statics.get_texture( "Art/speedup-Button" );
            wall_switch_inactive_texture = Statics.get_texture( "Art/speedup-Button" );
            door_texture = Statics.get_texture( "Art/speedup-Door" );
            trail_texture = Statics.get_texture( "Art/speedup-Photon" );
            sonic_texture = Statics.get_texture( "Art/speedup-SonicBoom" );
            pix_texture = Statics.get_texture( "Art/speedup-Pix" );
            boulder_texture = Statics.get_texture( "Art/speedup-Boulder" );
            flame_texture = Statics.get_texture( "Art/speedup-Flame" );
            space_texture = Statics.get_texture( TNames.space );
            highlight_texture = Statics.get_texture( "Art/speedup-Highlight" );
            floor_texture = Statics.get_texture( "Art/speedup-Floor" );

            game_font = content.Load<SpriteFont>( "gameFont" );

            //font = content.Load<SpriteFont> ( "Lucidia" );
        }

        public override Vector2 get_transform( Vector2 v ) {
            Matrix m = ( Matrix.Invert( eye.get_transformation() ) );
            return Vector2.Transform( v, m ) / 50;
        }

        public override void Draw( SpriteBatch sprite_batch, Camera eye ) {
            if ( eye.m_curr_target != null && eye.m_curr_target.m_body != null ) { eye.Update(); }
            sprite_batch.End();
            MouseState ms = Mouse.GetState();
            if ( !m_ninja.m_is_killed ) {
                // set the mousecontroller's field
                mouse_control.m_center = m_ninja.m_position;
            }

//            m_background = GameScreen.m_background;
//            Vector2 origin = new Vector2( m_background.Width,
//                m_background.Height ) / 2;
//            Color background_tint = Color.WhiteSmoke;

//            if (m_background == Statics.get_texture("Art/speedup-RedSquarebackground"))
//            {
//                background_tint = new Color(70,255,255);
//            }
//            else if (m_background == Statics.get_texture("Art/speedup-IceClouds"))
//            {
//               background_tint = new Color(50,50,50); 
//            }
//            else if ( m_background != TestWorld.ground_texture ) 
//            {
//                background_tint = new Color(120,120,120);
//            }
            
            
//           /* sprite_batch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend,
//=======
//            if ( m_background != TestWorld.ground_texture && m_background != Statics.get_texture( "Art/speedup-RedSquarebackground" ) ) {
//                background_tint = new Color( 120, 120, 120 );
//            }
//            else if ( m_background == Statics.get_texture( "Art/speedup-RedSquarebackground" ) ) {
//                background_tint = new Color( 70, 255, 255 );
//            }
//            else if ( m_background == Statics.get_texture( "Art/speedup-IceClouds" ) ) {
//                background_tint = new Color( 50, 50, 100 );
//            }
//            sprite_batch.Begin( SpriteSortMode.BackToFront, BlendState.AlphaBlend,
//>>>>>>> 0d56fc3fc89fef40509bd59baafb8122e2700b5f
//                null,
//                              null, null, null, eye.get_background_transformation() );
//            {
//                foreach ( GameObject tile in m_background_tiles ) {
//                    tile.draw( sprite_batch, eye );
//                }
//            }

//            sprite_batch.End();*/
            
           

//            sprite_batch.Begin( SpriteSortMode.BackToFront, null,
//                 SamplerState.LinearWrap,
//                               null, null, null, eye.get_background_transformation() );

//            sprite_batch.Draw( m_background,
//               eye.m_camera_position - new Vector2( GameScreen.GAME_WIDTH * 6f,
//               GameScreen.GAME_HEIGHT * 5f ),
//               new Rectangle( (int)( eye.m_camera_position.X / 7 ),
//               (int)( eye.m_camera_position.Y / 7 ),
//               (int)( m_background.Width * 2.5 / eye.m_camera_zoom ),
//                (int)( m_background.Height * 1 / eye.m_camera_zoom ) ),
//               background_tint, 0, origin, 7f, 0, 0 );

//            sprite_batch.End();



            //test camera control
            //zoom out when going fast
            //pans direction towards velocity
            if ( !m_ninja.m_is_dead ) {
                if ( !GameScreen.editor_mode && eye.m_curr_target is Ninja ) {

                    if ( m_ninja.m_speed > 110 ) {
                        eye.m_zoom_change = 0.2f;
                    }
                    else if ( m_ninja.m_speed < 80 && m_ninja.m_speed > 70 ) {
                        eye.m_zoom_change = 0.25f;
                    }
                    else if ( m_ninja.m_speed < 40 && m_ninja.m_speed > 20 ) {
                        eye.m_zoom_change = 0.3f;
                    }
                    else if ( m_ninja.m_speed < 0.001f ) {
                        eye.m_zoom_change = 0.45f;
                    }
                    else if ( m_ninja.m_speed < 0.0001f ) {
                        eye.m_zoom_change = 0.6f;
                    }
                }
            }



            sprite_batch.Begin( SpriteSortMode.Texture,
                BlendState.AlphaBlend,
                              null, null, null, null,
                              eye.get_transformation() );

            //Draws all the GameObjects
            base.Draw( sprite_batch, eye );

            sprite_batch.End();

            sprite_batch.Begin( SpriteSortMode.BackToFront,
              BlendState.Additive, null, null, null, null,
              eye.get_transformation() );

            // Draw the photon trail
            m_ninja.m_speed_trail.draw( sprite_batch, eye );
            m_ninja.m_sonicboom.Draw( sprite_batch, eye );

            sprite_batch.End();

            sprite_batch.Begin();
        }
        #endregion
    }
}