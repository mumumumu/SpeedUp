//==========================================================================
// speedup-Camera.cs  
//========================================================================

// Author: Sanford Johnson
//Credit for framework of this class:
// http://adambruenderman.wordpress.com/2011/04/05/create-a-2d-camera-in-xna-gs-4-0/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace speedup {
    public class Camera {
        #region Constants
        //--------------------------------------------------------------------
        // Constants
        //--------------------------------------------------------------------
        public const float CAMERA_MAX_ZOOM = 0.8f;
        public const float CAMERA_MIN_ZOOM = 0.25f;

        public const int DEFAULT_WIDTH = 1280;
        public const int DEFAULT_HEIGHT = 800;

        public static float global_zoom_mult =
            ( GameScreen.GAME_HEIGHT + GameScreen.GAME_WIDTH )
            / ( DEFAULT_HEIGHT + DEFAULT_WIDTH );
        #endregion
        #region Member Variables
        //--------------------------------------------------------------------
        // Member Variables
        //--------------------------------------------------------------------
        //
        public GameObject m_curr_target { get; set; }
        // I am just going to put a bunch of things I learn online, 3D and 2D.
        public Vector3 m_3D_camera_position;
        public Rectangle m_camera_view_area;
        public Matrix m_matrix_translation;
        public float m_aspect_ratio;
        public Matrix m_matrix_transform;
        public Vector2 m_camera_origin;
        // private Viewport m_eye;
        private Matrix m_matrix_transform_background;
        // private int m_world_width;
        // private int m_world_height;

        public Vector2 m_position_velocity_shift { get; set; }

        public float m_zoom_mult { get; set; }

        public Vector2 m_camera_position {
            get;
            set;
        }
        public Matrix m_matrix_view {
            get;
            set;
        }
        public Vector3 m_camera_look_at {
            get;
            set;
        }
        public Matrix m_matrix_projection {
            get;
            private set;
        }
        public int m_view_width {
            get;
            set;
        }
        public int m_view_height {
            get;
            set;
        }
        public float m_matrix_rotation {
            get;
            set;
        }
        public float m_camera_zoom {
            get;
            set; // Negative zoom will flip image
        }

        public float m_zoom_change {
            get;
            set;
        }

        public bool move_scroll { get; set; }
        #endregion
        #region Constructor
        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------
        public Camera( Viewport viewport, int offset, GameObject curr_target = null ) {
            if ( curr_target != null ) {
                curr_target = m_curr_target;
            }
            m_camera_zoom = CAMERA_MIN_ZOOM;
            m_zoom_change = m_camera_zoom;
            m_zoom_mult = 1;

            this.m_aspect_ratio = ( (float)viewport.Width ) /
                ( (float)viewport.Height );
            this.m_matrix_projection = Matrix.CreatePerspectiveFieldOfView(
                                        MathHelper.ToRadians( 40.0f ),
                                        this.m_aspect_ratio,
                                        1.0f,
                                        10000.0f );
            /*this.m_camera_origin = new Vector2( viewport.Width / 2, 
                viewport.Height / 2 );  */
            this.m_camera_origin = new Vector2( GameScreen.GAME_WIDTH / 2 + offset,
               GameScreen.GAME_HEIGHT / 2 );
            this.m_camera_view_area = new Rectangle( (int)m_camera_position.X,
                (int)m_camera_position.Y, viewport.Width, viewport.Height );
            m_view_height = GameScreen.GAME_HEIGHT;
            m_view_width = GameScreen.GAME_WIDTH;


            /* m_view_height = viewport.Height;
            m_view_width = viewport.Width; */

        }
        public Camera( float width, float height, float offset = 0 ) {
            m_camera_zoom = 1.0f;
            this.m_aspect_ratio = ( width ) /
                ( height );
            this.m_matrix_projection = Matrix.CreatePerspectiveFieldOfView(
                                        MathHelper.ToRadians( 40.0f ),
                                        this.m_aspect_ratio,
                                        1.0f,
                                        10000.0f );

            this.m_camera_origin = new Vector2( GameScreen.GAME_WIDTH / 2 + offset,
               GameScreen.GAME_HEIGHT / 2 );
            this.m_camera_view_area = new Rectangle( (int)m_camera_position.X,
                (int)m_camera_position.Y, (int)width, (int)height );
            m_view_height = GameScreen.GAME_HEIGHT;
            m_view_width = GameScreen.GAME_WIDTH;
        }
        #endregion
        #region Public Methods
        //--------------------------------------------------------------------
        // Public Methods
        //--------------------------------------------------------------------
        public void Move( Vector2 amount ) {
            m_camera_position += amount;
        }

        public Matrix get_transformation() {
         
            return m_matrix_transform;

        }
        public Matrix get_background_transformation() {
          
            return m_matrix_transform_background;
        }

        //Some 3D view. Weird
        public void Update() {
            //Camera loosely follows object. Moves quicker based on object speed.

            if ( !GameScreen.editor_mode && m_curr_target != null && m_curr_target.m_body != null ) {
                float dist = Vector2.Distance( m_curr_target.m_body.Position * GameWorld.SCALE, m_camera_position );
                float curr_speed = m_curr_target.m_body.LinearVelocity.Length();

                m_position_velocity_shift += (m_curr_target.m_body.LinearVelocity - m_position_velocity_shift)/
                    Math.Max( 10, Math.Min(100, 1000 /  curr_speed ) );

                if(move_scroll)
                {
                    m_camera_position += (m_curr_target.m_body.Position*GameWorld.SCALE - m_camera_position)
                        / Math.Max( 10, Math.Min(55,700 /curr_speed ) );
                    if ( dist < 25f )
                    {
                        move_scroll = false;
                    }
                }
                else if (dist > 4000 / (global_zoom_mult * m_zoom_mult))
                {
                    m_camera_position = m_curr_target.m_body.Position*GameWorld.SCALE;

                }
                else {
                    m_camera_position +=
                        (m_curr_target.m_body.Position * GameWorld.SCALE
                        + m_position_velocity_shift * 12f * 1 / (m_zoom_mult * global_zoom_mult)
                        - m_camera_position) / Math.Max(10, Math.Min(55f, 700 / curr_speed));

                }

            }

            if ( m_camera_zoom != m_zoom_change * (m_zoom_mult*global_zoom_mult) && !GameScreen.editor_mode )
            {
                m_camera_zoom += (m_zoom_change * (m_zoom_mult * global_zoom_mult) - m_camera_zoom) / 15;

            }


            m_matrix_transform =
          Matrix.CreateTranslation(new Vector3(-m_camera_position.X,
              -m_camera_position.Y, 0)) *
          Matrix.CreateRotationZ(m_matrix_rotation) *
          Matrix.CreateScale(new Vector3(m_camera_zoom, m_camera_zoom, 1)) *
          Matrix.CreateTranslation(new Vector3(m_camera_origin, 0));

            //translation, rotation, scale, then recenter.
            //Applied in the spritebatch
            m_matrix_transform_background =
            Matrix.CreateTranslation(new Vector3(-m_camera_position.X, -m_camera_position.Y, 0)) *
            Matrix.CreateRotationZ(0) *
            Matrix.CreateScale(new Vector3(m_camera_zoom, m_camera_zoom, 1)) *
            Matrix.CreateTranslation(new Vector3(m_camera_origin, 0));

        }
        #endregion
    }
}
