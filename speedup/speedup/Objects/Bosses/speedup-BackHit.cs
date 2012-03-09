//==========================================================================
// speedup-BackHit.cs  
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
    public class BackHit : Alien {

        #region Constructor
        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------

        internal BackHit() {
            m_restitution = 1.2f;
        }


        public BackHit( GameWorld world, Texture2D texture, Vector2 position, float size,
            AlienType type, String texturename = TNames.plated_alien )
            : base( world, texture, position, size,
            type, texturename: texturename, ai: AlienController.AIType.BOSS ) {

            m_restitution = 1.2f;
            m_alien_color = Color.Aquamarine;
        }

        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------


        public bool collision( GameObject collider ) {
            float contact_body_speed = collider.m_body.LinearVelocity.Length();

            if ( contact_body_speed > m_destroy_threshold ) {
                Vector2 dir = collider.m_body.Position - m_body.Position;
                double angle = Math.Atan2( dir.Y, dir.X ) - m_rotation;
                if ( angle < -Math.PI ) angle += 2 * Math.PI;
                else if ( angle > Math.PI ) angle -= 2 * Math.PI;

                if ( angle < -0.785 && angle > -2.356 ) {
                    Vector2 death_force = 40 * contact_body_speed * 5 *
                                          Vector2.Normalize( m_position - collider.m_position );
                    m_body.ApplyLinearImpulse( death_force );
                    alien_death_force = death_force;
                    m_body.Enabled = false;
                    return false;

                }
                else {

                    if ( collider is Ninja ) {

                        ( (Ninja)collider ).m_cooldown = Ninja.NINJA_COLLISION_COOLDOWN;
                    }
                    return true;
                }


            }
            else if ( contact_body_speed < m_kill_under_speed
                && collider is Ninja ) {

                ( (Ninja)collider ).m_cooldown = 30;
                ( (Ninja)collider ).m_is_killed = true;
                return true;
            }
            else {

                if ( collider is Ninja ) {

                    ( (Ninja)collider ).m_cooldown = Ninja.NINJA_COLLISION_COOLDOWN;
                }
                return true;
            }

        }


        public override void draw( SpriteBatch sprite_batch, Camera eye ) {


            base.draw( sprite_batch, eye );

            var origin = new Vector2( TestWorld.egg_texture.Width, TestWorld.egg_texture.Height ) / 2;
            Matrix r = Matrix.CreateRotationZ( m_rotation );

            sprite_batch.Draw( TestWorld.egg_texture, GameWorld.SCALE * ( m_body.Position + Vector2.Transform( new Vector2( 0, -m_size * 0.7f ), r ) ), null,
                                 Color.White, m_body.Rotation, origin, m_size_scale * 0.5f,
                                  0.0f, 0 );

        }

        #endregion


    }
}