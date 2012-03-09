//========================================================================
// speedup-TriggerableObject.cs : Class of all objects that may be triggered
//========================================================================
//
// Author: Matheus Ogleari
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace speedup {
    public class TriggerableObject : GameObject {
        #region Enum
        //----------------------------------------------------------------
        // Enum
        //----------------------------------------------------------------	
        //
        // Contains all the different types of triggers
        public enum TriggerType {
            DOOR,
            GOAL,
            CHECKPOINT,
            CAMERA_CONTROL,
            ZOOM_CONTROL,
            CAMERA_RESET,
            FLAME,
            TEXTBOX,
            BOSS1,
            BOSS2,
            BODY_ENABLER,
        }
        #endregion
        #region Static Constants
        //----------------------------------------------------------------
        // Static Constants
        //----------------------------------------------------------------	
        public const float DOOR_WIDTH = 1.0f;
        public const float DOOR_HEIGHT = .5f;
        public const float DOOR_DENSITY = 1.0f;
        #endregion
        #region Member Variables
        //----------------------------------------------------------------
        // Member Variables
        //----------------------------------------------------------------

        public bool m_is_active {
            get;
            set;
        }
        public TriggerType m_type {
            get;
            set;
        }

        [ContentSerializer( Optional = true )]
        public string m_text { get; set; }

        [ContentSerializer( Optional = true )]
        public float m_textbox_width { get; set; }

        [ContentSerializer( Optional = true )]
        public bool m_follow_me { get; set; }

        [ContentSerializer( Optional = true )]
        public SharedResourceList<GameObject> m_objects { get; set; }

        [ContentSerializer( Optional = true )]
        public float m_set_zoom { get; set; }

        [ContentSerializer( Optional = true )]
        public float m_zoom_mult { get; set; }

        [ContentSerializer( Optional = true )]
        public int m_timer_checkpoint_set { get; set; }

        [ContentSerializer( Optional = true )]
        private Vector2 m_scale;
        [ContentSerializer( Optional = true )]
        public float m_width = DOOR_HEIGHT;    // Needs to change

        [ContentSerializer( Optional = true )]
        public float m_length {
            get { return _length; }
            set {
                _length = value;
                if ( m_texture == null ) {
                    m_scale.X = 0;
                }
                else {
                    m_scale.X = ( m_length / m_texture.Width ) * GameWorld.SCALE;
                }
                if ( m_world != null ) {
                    remove_from_world();
                    add_to_world();
                }
            }
        }

        [ContentSerializerIgnore]
        public int obj_count {
            get {
                if ( m_objects == null ) {
                    return 0;
                }

                return m_objects.Count;

            }

        }
        [ContentSerializer( Optional = true )]
        public bool m_invisible { get; set; }

        [ContentSerializer( Optional = true )]
        private float _length;

        [ContentSerializer(Optional = true)]
        public String parsedText { get; set; }


        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------
        internal TriggerableObject() {
        }

        public TriggerableObject( GameWorld world, Texture2D texture,
            Vector2 position, TriggerType type, float rotation = 0, bool invisible = false,
            String name = "TriggerableObject", String texture_name = TNames.bomb, int timer_set = 120 )
            : base( world, texture, position, name: name, texture_name: texture_name, density: DOOR_DENSITY ) {
            m_timer_checkpoint_set = timer_set;
            m_invisible = invisible;
            m_type = type;
            m_is_active = false;
            m_radius = m_scale.Y * 4;
        }

        public TriggerableObject( GameWorld world, Texture2D texture, Vector2 vertex1,
            Vector2 vertex2, float rotation = 0, String name = "TriggerableObject", bool invisible = false,
            String texture_name = TNames.door, int timer_set = 120 ) // Needs to change this
            : base( world, texture, name: name, texture_name: texture_name ) {
            m_timer_checkpoint_set = timer_set;
            m_invisible = invisible;
            m_length = ( Math.Abs( vertex1.X - vertex2.X ) >
                Math.Abs( vertex1.Y - vertex2.Y ) ) ?
                Math.Abs( vertex1.X - vertex2.X ) :
                Math.Abs( vertex1.Y - vertex2.Y );
            m_rotation = rotation;
            m_buffered_position = ( vertex1 + vertex2 ) / 2;
            float scale = ( m_length / m_texture.Width ) * GameWorld.SCALE;
            m_scale = new Vector2( scale, scale );
            m_radius = m_scale.Y * 4;
        }

        public TriggerableObject( GameWorld world, bool invisible = true, String name = "TriggerableObject",
            String texture_name = TNames.trail )
            : base( name: name, texture_name: texture_name ) {
            m_invisible = invisible;
            m_world = world;
        }

        public TriggerableObject( GameWorld world, String message, float width, Vector2 position, bool invisible = true, String name = "TriggerableObject",
                String texture_name = TNames.space )
            : base( name: name, texture_name: texture_name ) {
            m_invisible = invisible;
            m_world = world;
            m_text = message;
            m_buffered_position = position;
            m_textbox_width = width;
        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------

        public void activate() {

            switch ( m_type ) {
                case TriggerType.DOOR:
                    if ( m_body != null && m_body.Enabled && !m_invisible && !m_is_active ) {
                        GameEngine.AudioManager.Play( AudioManager.SFXSelection.door_activate );
                        m_invisible = true;
                        m_tint = Color.DarkGray;
                        // m_scale.X = 0;
                    }
                    break;
                case TriggerType.GOAL:
                    m_world.Win();
                    break;
                case TriggerType.TEXTBOX:
                    if ( !m_invisible ) {
                        m_invisible = true;
                    }
                    break;
                case TriggerType.CHECKPOINT:
                    if ( !m_is_active ) {
                        m_is_active = true;
                        GameScreen.checkpoint_countdown = 180;
                        GameScreen.m_checkpoint_timer = m_timer_checkpoint_set;
                        m_world.save_state( Directory.GetCurrentDirectory() + "/Levels/" + "checkpoint.xml" );
                    }
                    break;
                case TriggerType.CAMERA_CONTROL:
                    Camera eye = GameScreen.m_curr_view;
                    if ( eye != null ) {
                        if ( !m_is_active ) {
                            m_is_active = true;
                            eye.m_zoom_change = m_set_zoom;
                            if ( m_follow_me ) {
                                eye.m_curr_target = this;
                                GameScreen.m_curr_view.move_scroll = true;
                            }
                        }
                    }
                    break;
                case TriggerType.CAMERA_RESET:
                    if ( !m_is_active ) {
                        m_is_active = true;
                        GameScreen.m_curr_view.m_zoom_mult = 1;
                        GameScreen.m_curr_view.m_curr_target = m_world.m_ninja;
                    }
                    break;
                case TriggerType.ZOOM_CONTROL:
                    if ( !m_is_active ) {
                        m_is_active = true;
                        GameScreen.m_curr_view.m_zoom_mult = m_zoom_mult;
                    }
                    break;
                case TriggerType.FLAME:
                    MovingDeath death = new MovingDeath( m_world, TestWorld.flame_texture, new Vector2( 97, 100 ), new Vector2( 53, 8 ), new Vector2( 0, -250 ), 0.4f, texturename: TNames.flame );
                    m_world.add_queued_object( death );
                    break;
                case TriggerType.BOSS1:
                    if ( !m_is_active ) {
                        m_is_active = true;
                        GameEngine.AudioManager.Play( AudioManager.MusicSelection.boss1 );
                    }
                    break;
                case TriggerType.BOSS2:
                    if ( !m_is_active ) {
                        m_is_active = true;
                        GameEngine.AudioManager.Play( AudioManager.MusicSelection.boss2 );
                    }
                    break;
                case TriggerType.BODY_ENABLER: {
                        if ( m_objects == null ) {
                            m_objects = new SharedResourceList<GameObject>();
                        }
                        else {
                            foreach ( GameObject obj in m_objects ) {
                                obj.m_disabled = false;
                            }
                            m_is_active = true;
                        }
                    }
                    break;
            }
            m_is_active = true;
        }

        public void deactivate() {

            switch ( m_type ) {
                case TriggerType.DOOR:
                    if ( m_is_active ) {
                        m_invisible = false;
                        m_tint = Color.White;
                        m_is_active = false;
                        //m_scale.X = m_length / m_texture.Width * GameWorld.SCALE;
                    }
                    break;
                case TriggerType.GOAL:
                    if ( m_is_active ) {
                        //Do something here?   
                    }
                    break;
                case TriggerType.TEXTBOX:
                    if ( m_is_active ) {
                        m_invisible = false;
                        m_is_active = false;
                    }
                    break;
                case TriggerType.CAMERA_CONTROL:
                    if ( m_is_active ) {

                        if ( m_follow_me ) {
                            GameScreen.m_curr_view.move_scroll = true;

                        }
                        GameScreen.m_curr_view.m_curr_target = m_world.m_ninja;

                        m_is_active = false;
                    }
                    break;
                case TriggerType.ZOOM_CONTROL:
                    if ( m_is_active ) {
                        GameScreen.m_curr_view.m_zoom_mult = 1;
                        m_is_active = false;
                    }
                    break;
                case TriggerType.BODY_ENABLER: {
                        if ( m_objects == null ) {
                            m_objects = new SharedResourceList<GameObject>();
                        }
                        else {
                            foreach ( GameObject obj in m_objects ) {
                                obj.m_disabled = true;
                            }
                        }
                        m_is_active = false;
                    }
                    break;
                default:
                    m_is_active = false;
                    break;

            }

        }

        protected override Body create_physics() {
            var new_body = BodyFactory.CreateRectangle( m_world.m_world,
                m_length, m_width, m_rotation );
            new_body.BodyType = BodyType.Kinematic;
            new_body.Rotation = m_rotation;
            new_body.Restitution = m_restitution;
            new_body.Friction = m_friction;
            if (m_type == TriggerType.TEXTBOX)
            {
                parsedText = parseText(m_text);
            }
            return new_body;
        }

        public override void update( GameWorld world, float time_step ) {
            base.update( world, time_step );
            m_body.IsSensor = m_invisible || m_type == TriggerType.TEXTBOX;
        }

        public override void draw( SpriteBatch sprite_batch, Camera eye ) {
            if ( !m_invisible || ( m_invisible && GameScreen.editor_mode ) ) {
                if ( m_type == TriggerType.TEXTBOX ) {
                    if ( GameScreen.editor_mode ) {
                        var origin = new Vector2( m_texture.Width, m_texture.Height ) / 2;
                        sprite_batch.Draw( m_texture, GameWorld.SCALE * m_body.Position, null, m_tint,
                                      m_body.Rotation, origin, m_scale, 0.0f, 0 );
                    }
                    sprite_batch.DrawString(TestWorld.game_font, parsedText, new Vector2(m_position.X, m_position.Y) * GameWorld.SCALE, Color.White);
                }
                else {
                    var origin = new Vector2( m_texture.Width, m_texture.Height ) / 2;
                    sprite_batch.Draw( m_texture, GameWorld.SCALE * m_body.Position, null, m_tint,
                                      m_body.Rotation, origin, m_scale, 0.0f, 0 );
                }
            }
        }

        private String parseText( String text ) {
            String line = String.Empty;
            String returnString = String.Empty;
            String[] wordArray = text.Split( ' ' );
            foreach ( String word in wordArray ) {
                if ( TestWorld.game_font.MeasureString( line + word ).Length() > m_textbox_width ) {
                    returnString = returnString + line + '\n';
                    line = String.Empty;
                }
                line = line + word + ' ';
            }
            return returnString + line;
        }
        #endregion
    }
}
