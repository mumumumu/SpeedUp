//==========================================================================
// speedup-DeathTouch.cs  
//========================================================================

// Author: Wen Hao Lui


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics.Joints;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace speedup {


    //Creates an object that kills the player upon contact

    public class DeathTouch : GameObject {

        #region Member Variables
        //--------------------------------------------------------------------
        // Member Variables
        //--------------------------------------------------------------------
        //Series of Parameters that define the Object
        // Current position defined at the center
        // Might not need this due to the use of using the body position
        // private float m_facing_angle;

        [ContentSerializer]
        public Vector2 m_size;

        [ContentSerializer]
        public Vector2 m_scale;

        [ContentSerializer]
        public Vector2 m_saved_scale;


        [ContentSerializer]
        public int m_pit_num;

        #endregion
        #region Constructor
        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------
        //
        internal DeathTouch() {

        }
        // The DeathTouch Constructor
        //
        // <param name="world"> The World this object would be contained inside </param>
        // <param name="texture"> The image that governs the shape of this object</param>
        // <param name="velocity"> The initial velocity from throwing</param>
        // <param name="density"> The object's mass per unit area </param>
        // <param name="friction"> Usually set to 0 for throwable objects, but sliding factor </param>
        // <param name="restitution"> Bounciness </param>
        public DeathTouch( GameWorld world, Texture2D texture,
            Vector2 position, float radius, String name = "Ball", String texturename = TNames.plated_alien, float dense = 0 )
            : base( world, texture, dense, 0,
            0, radius: radius,
            name: name, texture_name: texturename ) {
            m_buffered_position = position;
            m_size = Vector2.Zero;
            m_tint = Color.White;
        }

        // Another constructor, for squareish objects
        public DeathTouch( GameWorld world, Texture2D texture,
    Vector2 position, Vector2 size, String name = "Floor", String texturename = TNames.tile, int pit_num = 0 )
            : base( world, texture, 0, 0,
            0,
            name: name, texture_name: texturename ) {
            m_buffered_position = position;
            m_size = size;
            m_scale = new Vector2( size.X / texture.Width, size.Y / texture.Height ) * GameWorld.SCALE;
            m_saved_scale = m_scale;
            m_pit_num = pit_num - 1;
            m_tint = Color.White;
        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------
        protected override Body create_physics() {
            if ( m_size == Vector2.Zero )
                return base.create_physics();
            else {
                return BodyFactory.CreateRectangle( m_world.m_world,
                m_size.X, m_size.Y, m_rotation );
            }
        }


        public override void update( GameWorld world, float time_step ) {
            base.update( world, time_step );

        }

        public void activate() {
            m_tint = Color.Black;
            m_body.Enabled = true;
            Vector2 pos = m_world.m_ninja.m_body.Position;
            if ( m_body.FixtureList.Any( fixture => fixture.TestPoint( ref pos ) ) ) {
                m_world.m_ninja.m_is_killed = true;
            }
        }

        public void deactivate() {
            m_tint = Color.White;
            m_body.Enabled = false;

        }


        public override void draw( SpriteBatch sprite_batch, Camera eye ) {
            var origin = new Vector2( m_texture.Width, m_texture.Height ) / 2;
            if ( m_size == Vector2.Zero ) {
                if ( m_radius != 0 ) {
                    float scale = m_radius / m_texture.Width * GameWorld.SCALE * 2;
                    sprite_batch.Draw( m_texture, GameWorld.SCALE * m_body.Position, null,
                    m_tint, m_body.Rotation, origin, scale, 0.0f, 0 );
                }
            }
            else {


                sprite_batch.Draw( m_texture, GameWorld.SCALE *
                    m_body.Position, null, m_tint,
                    m_body.Rotation, origin, m_scale, 0.0f, 0
                );
            }
        }




        #endregion
    }

}
