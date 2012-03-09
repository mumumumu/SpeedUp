//========================================================================
// speedup-Laser.cs : The laser shot by the aliens
//========================================================================
//
// Author: Matheus Ogleari

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
    class Laser : GameObject {
        #region Constants
        //----------------------------------------------------------------
        // Constants
        //----------------------------------------------------------------
        public const int LASER_MAX_AGE = 200;
        #endregion
        #region Member Variables
        //----------------------------------------------------------------
        // Member Variables
        //----------------------------------------------------------------
        public Alien m_owner {
            get;
            private set;
        }
        public int m_power {
            get;
            set;
        }

        public float m_slowdown { get; set; }
        private float m_width;
        private float m_height;
        private int m_age;
        private float m_scale;
        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        internal Laser() {
        }
        public Laser( Alien owner, Texture2D texture, Vector2 position,
            Vector2 launch_speed, float radius, int power )
            : base( owner.m_world, texture, radius: radius,
            texture_name: TNames.laser ) {
            m_buffered_linear_velocity = launch_speed;
            m_buffered_position = position;
            m_power = power;
            m_owner = owner;
            m_age = 0;
        }

        public Laser( Alien owner, Texture2D texture, Vector2 position,
            Vector2 launch_speed, int power, float rotation = 0.0f,
            float scale = 1.0f, float slowdown = 0.7f )
            : base( owner.m_world, texture,
            texture_name: TNames.laser, density: 0.0001f ) {
            m_buffered_linear_velocity = launch_speed;
            m_buffered_position = position;
            m_scale = scale;
            m_height = scale * m_texture.Width / GameWorld.SCALE;
            m_width = scale * m_texture.Height / GameWorld.SCALE;
            m_rotation = rotation;
            m_power = power;
            m_owner = owner;
            m_age = 0;
            m_slowdown = slowdown;
            m_tint = new Color( 200, 0, 150 - 150 * m_slowdown );
        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------
        protected override Body create_physics() {
            if ( m_radius != 0 )
                return base.create_physics();
            else {
                var new_body = BodyFactory.CreateRectangle( m_world.m_world,
                    m_width, m_height, m_density );

                new_body.BodyType = BodyType.Dynamic;
                new_body.Restitution = m_restitution;
                new_body.Friction = m_friction;
                new_body.FixedRotation = true;
                new_body.LinearVelocity = m_buffered_linear_velocity.Value;
                new_body.LinearDamping = m_damping;
                new_body.Rotation = m_rotation;
                return new_body;
            }
        }

        public override void update( GameWorld world, float time_step ) {
            if ( m_age++ >= LASER_MAX_AGE ) {
                destroy();
            }
            base.update( world, time_step );
        }

        public override void draw( SpriteBatch sprite_batch, Camera eye ) {
            var origin = new Vector2( m_texture.Width,
                m_texture.Height ) / 2;

            float diff = m_power - m_world.m_ninja.m_speed;
            float brightness = Math.Max( 0, -diff * 5 );

            sprite_batch.Draw( m_texture, GameWorld.SCALE *
                m_body.Position, null,
                Color.Lerp( m_tint, new Color( Math.Max( 0, diff * 10 ), brightness, brightness ), 0.5f ),
                m_body.Rotation - (float)Math.PI / 2, origin, m_scale, 0.0f, 0
            );
        }
        #endregion
    }
}
