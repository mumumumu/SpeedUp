//==========================================================================
// TwinNova.cs  
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
    public class TwinNova : Alien {
        [ContentSerializer( SharedResource = true )]
        public TwinNova twin;
        public int cooldown;
        public int m_deathtime;
        public int max_hit;
        public int hit_counter;
        private int num_killed = 0;

        #region Constructor
        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------

        internal TwinNova() {

        }

        public TwinNova( GameWorld world, Texture2D texture, Vector2 position, float size,
            AlienType type, int deathtime, int hits, String texturename = TNames.blue_nova )
            : base( world, texture, position, size, type ) {
            cooldown = deathtime;
            m_deathtime = deathtime;
            max_hit = hits;
            hit_counter = hits;
            m_restitution = 1.5f;
            m_texture_name = texturename;
            m_texture = texture;
        }

        #endregion

        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------

        //Specify the twin. It is reciprocal, so the method only needs to be called once
        public void addTwin( TwinNova nova ) {
            twin = nova;
            nova.twin = this;
        }


        public override void update( GameWorld world, float time_step ) {



            if ( !m_body.Enabled && m_animation_frame >= m_death_anim_frames - 1 && twin.m_body.Enabled ) {
                m_animation_frame = m_death_anim_frames - 1;
                cooldown--;


                if ( cooldown <= 0 && num_killed<max_hit )
                {

                    revive();
                    num_killed++;
                    hit_counter = max_hit-num_killed;
                }

            }

            base.update( world, time_step );
        }

        public void revive() {
            m_body.Enabled = true;
            cooldown = m_deathtime + num_killed;
            m_animation_frame = 2;
            m_alien_color = Color.White;
        }


        public bool collision( GameObject collider ) {
            float contact_body_speed = collider.m_body.LinearVelocity.Length();

            if ( contact_body_speed > m_destroy_threshold ) {

                m_animation_frame = 0;
                if ( hit_counter > 0 ) {
                    //* constant because of the movement of the AI
                    Vector2 hit_vec = hit_counter * ( Math.Max( 0.4f, collider.get_weight() / get_weight() ) ) * ( collider.m_body.LinearVelocity - m_body.LinearVelocity ).Length() *
                                                         Vector2.Normalize( m_position - collider.m_position );
                    m_body.LinearVelocity = hit_vec;
                    m_body.ApplyLinearImpulse( 60 * hit_vec );
                    cooldown = m_deathtime;
                    hit_counter--;
                    float col = ( 1f + 2f * hit_counter / (float)max_hit ) / 3f;
                    m_alien_color = new Color( col, col, col );
                    if ( collider is Ninja ) {
                        collider.m_body.ApplyLinearImpulse( contact_body_speed / 1.5f *
                                                        Vector2.Normalize( collider.m_position - m_position ) );
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