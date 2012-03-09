//========================================================================
// speedup-GameWorld.cs : Class for generic worlds to be used in game
//========================================================================
//
// Author: Jeff Mu

using System;
using System.IO;
using FarseerPhysics.Collision;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;

namespace speedup {

    // The GameWorld provides a basic facade for the physics world, keeping track
    // of common variables and faciliating physics object addition and removal.
    public abstract class GameWorld {
        #region Constants
        //----------------------------------------------------------------
        // Constants
        //----------------------------------------------------------------
        //
        // Scale from game space -> screen space
        public const float SCALE = 50.0f;
        public const float OBJECT_SCALE = 50 / SCALE;
        // Amount of offgame area covered by the world AABB
        protected const float MARGIN = 100.0f;
        private KeyboardState ks_prev = Keyboard.GetState();
        public static World the_world;
        #endregion
        #region Member Variables
        //----------------------------------------------------------------
        //  Members Variables
        //----------------------------------------------------------------

        public List<GameObject> m_background_tiles = new List<GameObject>();

        // Gets the Box2DX physics world
        public World m_world {
            get;
            set;
        }

        // Whether or not we've beaten this world
        public bool m_succeeded {
            get;
            private set;
        }
        public Texture2D m_background {
            get;
            set;
        }


        private float m_count = 0;

        // Whether or not we died trying
        public bool m_failed {
            get;
            private set;
        }

        public Ninja m_ninja {
            get;
            protected set;
        }


        public int m_enemy_count {
            get;
            protected set;
        }

        public int m_enemy_slain {
            get;
            protected set;
        }
        public String curr_filename { get; set; }

        protected CollisionManager m_collision_manager;

        // Mouse
        public MouseController mouse_control;
        public NinjaController m_ninja_controller;

        // All the objects in the world
        private SharedResourceLinkedList<GameObject> m_objects = new SharedResourceLinkedList<GameObject>();
        // queue for adding objects
        private Queue<GameObject> m_add_queue = new Queue<GameObject>();
        private AABB m_aabb;
        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        //
        // TODO: add Vector2 target_position as an argument??
        protected GameWorld( float width, float height, Vector2 gravity ) {
            // Create the world's axis-aligned bounding box
            m_aabb = new AABB();
            m_aabb.LowerBound = new Vector2( -GameScreen.GAME_WIDTH,
                -GameScreen.GAME_HEIGHT ) + new Vector2( -MARGIN - width,
                    -MARGIN - height );
            m_aabb.UpperBound = new Vector2( GameScreen.GAME_WIDTH,
                GameScreen.GAME_HEIGHT ) + new Vector2( width + MARGIN,
                    height + MARGIN );
            m_world = new World( gravity, m_aabb );
            GameWorld.the_world = m_world;
            m_succeeded = m_failed = false;
            m_enemy_count = 0;
            m_enemy_slain = 0;
            m_collision_manager = new CollisionManager();
            m_background = GameScreen.m_background;
        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Public Methods
        //----------------------------------------------------------------
        //
        // Puts the physics object in the add queue, to be added
        // before the next step.  This is required as objects
        // cannot be added during engine processing.
        // <param name="obj"></param>
        public void add_queued_object( GameObject obj ) {
            m_add_queue.Enqueue( obj );
        }

        // Adds the object to the physics world
        // <param name="obj"></param>
        protected void add_object( GameObject obj ) {

            if ( obj is Alien )
                m_enemy_count++;

            if ( obj is BackgroundTile ) {
                m_background_tiles.Add( obj );
            }

            obj.add_to_world();
            if ( ( obj is FloorTile ) || ( obj is SelectBox ) )
                m_objects.AddFirst( obj );
            else
                m_objects.AddLast( obj );


            // obj.add_joints_to_world();
        }

        public virtual void simulate( float time_step ) {
            KeyboardState ks = Keyboard.GetState();
            if ( ks.IsKeyDown( Keys.RightShift ) && ks_prev.IsKeyUp( Keys.RightShift ) ||
                ( ks.IsKeyDown( Keys.LeftControl ) && ks.IsKeyDown( Keys.Q ) && ks_prev.IsKeyUp( Keys.Q )
                || ks.IsKeyDown( Keys.Q ) && ks.IsKeyDown( Keys.LeftControl ) && ks_prev.IsKeyUp( Keys.LeftControl ) ) ) {
                m_ninja.update_spawn();
                foreach ( GameObject item in m_ninja.throwable_objects ) {
                    item.update_spawn();
                }
                Console.WriteLine( "SAVING to file" );
                save_state( Directory.GetCurrentDirectory() + "/Levels/" + "TempSave.xml" );
            }
            ks_prev = ks;
            // add any objects
            foreach ( var gameObject in m_add_queue ) {
                add_object( gameObject );
            }
            m_add_queue.Clear();

            m_world.Step( time_step );

            // iterate through the linked list and remove if needed.
            var node = m_objects.First;
            while ( node != null ) {
                var obj = node.Value;
                var next = node.Next;
                if ( obj is BackgroundTile ) {
                    if ( obj.m_body != null ) {
                        obj.remove_from_world();
                    }
                }
                if ( obj.m_is_dead ) {
                    if ( obj is Alien )
                        m_enemy_slain++;

                    node.Value.remove_from_world();
                    m_objects.Remove( node );

                }
                else {
                    if ( obj is MovingDeath && GameScreen.within_screen_bounds
                        ( obj.m_body.Position, GameScreen.dist_to_screen_edge * 2 ) ) {
                        obj.update( this, time_step );
                        // obj.m_body.IgnoreCCD = false;

                    }

                    else if ( GameScreen.within_screen_bounds( obj.m_body.Position ) ) {
                        obj.update( this, time_step );
                        // obj.m_body.IgnoreCCD = false;
                    }
                    // else{obj.m_body.IgnoreCCD = true;}
                }
                node = next;
            }
        }

        // Creates the world, sets the ninja
        public void create_world( GameWorld g_world, string filename ) {
            Ninja ninja = new Ninja();
            DeathPitController deathcontrol = new DeathPitController( g_world, 120 );
            XML_Manager xml_guy = new XML_Manager();
            g_world.curr_filename = filename;
            m_objects = xml_guy.load_resource_linked_list( filename );
            foreach ( GameObject g_obj in m_objects ) {
                g_obj.m_world = g_world;

                g_obj.add_to_world();   //Handles whether to load GameObjects if they have been destroyed
                if ( g_obj.m_is_dead ) {


                }
                if ( g_obj is FloorTile ) {
                    g_obj.remove_from_world();
                }

                if ( g_obj is Ninja ) {
                    m_ninja = (Ninja)g_obj;
                    NinjaController n_control = new NinjaController( g_obj.m_world, (Ninja)g_obj );
                    m_ninja_controller = n_control;
                    g_obj.m_world.m_world.AddController( n_control );
                    g_obj.m_body.Awake = true;
                    g_obj.m_body.Enabled = true;

                    //Makes sure to update target
                    foreach ( Controller control in m_world.ControllerList ) {
                        if ( control is AlienController ) {
                            AlienController alien_control = (AlienController)control;
                            alien_control.m_target = m_ninja;
                        }
                    }
                }
                else if ( g_obj is Alien ) {
                    Alien alien = (Alien)g_obj;
                    alien.set_textures();
                    alien.m_ai_type_change = alien.m_ai_type;
                    m_enemy_count++;
                }
                else if ( g_obj is DeathTouch && !( g_obj is MovingDeath ) ) {
                    deathcontrol.addPit( (DeathTouch)g_obj );
                }
                else if ( g_obj is ConditionTriggered ) {
                    ConditionTriggered ob = (ConditionTriggered)g_obj;
                    Color color;
                    switch ( ob.m_condition_type ) {
                        case ConditionTriggered.ConditionType.DEATH:
                            color = Color.CornflowerBlue;
                            break;
                        case ConditionTriggered.ConditionType.NINJA_HAS_ITEM:
                            color = Color.OrangeRed;
                            break;
                        default:
                            color = Color.White;
                            break;

                    }
                    foreach ( TriggerableObject to in ob.m_attached_to )
                        to.m_tint = color;


                }



            }

            g_world.m_world.AddController( deathcontrol );

        }

        public Vector2 m_mouse_pos_transform() {
            //temp offset added
            Vector2 mouse_pos = new Vector2( Mouse.GetState().X, Mouse.GetState().Y );
            Matrix m = ( Matrix.Invert( GameScreen.m_curr_view.get_transformation() ) );
            return Vector2.Transform( mouse_pos, m ) / GameWorld.SCALE;
        }

        // draws all objects in the physics world
        public virtual void Draw( SpriteBatch sprite_batch, Camera eye ) {
            m_count += 0.1f;
            Texture2D mouse_texture = TestWorld.shuriken;
            var origin = new Vector2( mouse_texture.Width, mouse_texture.Height ) / 2;

            sprite_batch.Draw( mouse_texture, GameWorld.SCALE * m_mouse_pos_transform(), null,
            Color.Gold, m_count, origin, 0.1f / GameScreen.m_curr_view.m_camera_zoom, 0.0f, 1 );

            foreach ( GameObject obj in m_objects )
                if ( obj is BackgroundTile ) {
                    //DO NOTHING
                }
                else if ( GameScreen.within_screen_bounds( obj.m_body.Position ) ) { obj.draw( sprite_batch, eye ); }

                else if ( obj is PolygonObject ) {

                    // if ( GameScreen.within_screen_bounds
                    //     ( obj.m_body.Position, vertices: ((PolygonObject)obj).m_verts ) )
                    { obj.draw( sprite_batch, eye ); }

                }

                else if ( obj is SelectBox ) { obj.draw( sprite_batch, eye ); }
        }

        public abstract Vector2 get_transform( Vector2 v );

        // Report that the player has won the level
        public void Win() {
            m_succeeded = true;
        }

        // Report that the player has died/lost
        public void Fail() {
            GameEngine.AudioManager.Play( AudioManager.MusicSelection.creepy );
            m_failed = true;
        }

        /*public void update_aabb()
        {
            m_aabb.LowerBound = target_position + new Vector2( -GameEngine.GAME_WIDTH, -GameEngine.GAME_HEIGHT ) + new Vector2( -MARGIN - width, -MARGIN - height );
            m_aabb.UpperBound = target_position + new Vector2( GameEngine.GAME_WIDTH, GameEngine.GAME_HEIGHT ) + new Vector2( width + MARGIN, height + MARGIN );
        }*/
        public void save_state( String filename ) {
            //Save data
            XML_Manager xml_manager = new XML_Manager();

            xml_manager.save_resource_linked_list( m_objects, filename );
            curr_filename = filename;
            Console.WriteLine( "Writing to " + filename );
        }
        #endregion
    }

}