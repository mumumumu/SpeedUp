//==========================================================================
// MultiHit.cs  
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
    public class MultiHit : Alien {

        public int max_hit;
        public int hit_counter;


        #region Constructor
        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------

        internal MultiHit() {

        }

        public MultiHit( GameWorld world, Texture2D texture, Vector2 position, float size,
            AlienType type, int hits, String texturename = TNames.plated_alien )
            : base( world, texture, position, size, type, ai: AlienController.AIType.CHASER ) {

            max_hit = hits;
            hit_counter = hits;
            m_restitution = 1;
            m_texture_name = texturename;
            m_texture = texture;
        }

        #endregion

        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------




        public bool collision( GameObject collider ) {
            float contact_body_speed = collider.m_body.LinearVelocity.Length();

            if ( contact_body_speed > m_destroy_threshold ) {


                if ( hit_counter > 0 ) {

                    hit_counter--;
                    float col = ( 1f + 2f * hit_counter / (float)max_hit ) / 3f;
                    m_alien_color = new Color( col, col, col );
                    if ( collider is Ninja ) {

                        m_world.m_ninja.m_cooldown = Ninja.NINJA_COLLISION_COOLDOWN;
                    }
                    return true;
                }
                else {
                    Vector2 death_force = 40 * contact_body_speed * 5 *
                                          Vector2.Normalize( m_position - collider.m_position );
                    m_body.ApplyLinearImpulse( death_force );
                    alien_death_force = death_force;
                    m_body.Enabled = false;
                    return false;

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



        public override void set_textures() {
            base.set_textures();
            m_texture_name_change = m_texture_name;
            m_texture_name = m_texture_name;
        }

        #endregion


    }

}