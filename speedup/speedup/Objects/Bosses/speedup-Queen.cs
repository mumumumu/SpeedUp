//==========================================================================
// speedup-Queen.cs  
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
    public class Queen : Spawner {

        public struct Egg {
            public Vector2 pos;   // relative position.
            public float angle;      // angle of the egg
            public bool intact;
        }

        Egg[] eggs = new Egg[4];

        #region Constructor
        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------

        internal Queen() {
            m_alien_color = Color.White;
            m_restitution = 2f;
            for ( int i = 0; i < 4; i++ ) {
                eggs[i] = new Egg();
                eggs[i].intact = true;
                eggs[i].pos = Vector2.Zero;
            }

            eggs[0].pos += new Vector2( 9, -4 );
            eggs[0].angle = 1.35f;
            eggs[1].pos += new Vector2( 7, -10 );
            eggs[1].angle = 0.65f;

            eggs[2].pos += new Vector2( -9, -4 );
            eggs[2].angle = -1.35f;
            eggs[3].pos += new Vector2( -7, -10 );
            eggs[3].angle = -0.65f;
        }


        public Queen( GameWorld world, Texture2D texture, Vector2 position, float size,
            AlienType type, int cooldown, String texturename = TNames.queen_alien, int max_spawn = 10 )
            : base( world, texture, position, size,
            type, cooldown, texturename: texturename, max_spawn: max_spawn, ai: AlienController.AIType.BOSS, patrol: 0.03f ) {
            m_alien_color = Color.White;
            m_restitution = 2f;
            for ( int i = 0; i < 4; i++ ) {
                eggs[i] = new Egg();
                eggs[i].intact = true;
                eggs[i].pos = Vector2.Zero;
            }

            eggs[0].pos += new Vector2( 9, -4 );
            eggs[0].angle = 1.35f;
            eggs[1].pos += new Vector2( 7, -10 );
            eggs[1].angle = 0.65f;

            eggs[2].pos += new Vector2( -9, -4 );
            eggs[2].angle = -1.35f;
            eggs[3].pos += new Vector2( -7, -10 );
            eggs[3].angle = -0.65f;

        }

        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------

        public override void spawn_alien() {
            if ( !m_disabled )
            {
                Vector2 offset = new Vector2( (float)Math.Sin( m_rotation ), -(float)Math.Cos( m_rotation ) ) * 11;
                Alien alien = new Alien( m_world, TestWorld.easy_alien_texture, m_body.Position + offset, .5f,
                                              Alien.AlienType.MEDIUM, patrol_speed: 0.025f, ai: AlienController.AIType.CHASER );

                alien.m_destroy_threshold = m_destroy_threshold;
                alien.m_kill_under_speed = m_kill_under_speed / 1.5f;
                alien.m_alien_color = m_alien_color;
                alien.m_chase_dist = m_chase_dist;
                alien.m_range = m_range;

                m_world.add_queued_object( alien );
                spawn.Add( alien );

                m_cooldown = max_cool;
            }

        }

        public override void draw( SpriteBatch sprite_batch, Camera eye ) {

            m_size_scale *= 2f;
            base.draw( sprite_batch, eye );
            m_size_scale /= 2f;

            m_size_scale *= 1.4f;
            var origin = new Vector2( TestWorld.egg_texture.Width, TestWorld.egg_texture.Height ) / 2;
            Matrix r = Matrix.CreateRotationZ( m_rotation );
            foreach ( Egg egg in eggs ) {
                if ( egg.intact ) {
                    sprite_batch.Draw( TestWorld.egg_texture, GameWorld.SCALE * ( m_body.Position + Vector2.Transform( egg.pos, r ) ), null,
                                         Color.White, m_body.Rotation + egg.angle, origin, m_size_scale,
                                          0.0f, 0
                                        );
                }
            }
            m_size_scale /= 1.4f;
        }

        public bool collision( GameObject collider ) {
            float contact_body_speed = collider.m_body.LinearVelocity.Length();

            if ( contact_body_speed > m_destroy_threshold ) {
                if ( eggs.Any( egg => egg.intact ) ) {
                    Vector2 dir = collider.m_body.Position - m_body.Position;
                    double angle = Math.Atan2( dir.Y, dir.X ) - m_rotation;
                    if ( angle < -Math.PI ) angle += 2 * Math.PI;
                    else if ( angle > Math.PI ) angle -= 2 * Math.PI;

                    double angle1 = angle + Math.PI;
                    if ( angle1 > Math.PI ) angle1 -= 2 * Math.PI;

                    if ( angle < 0 && angle > -0.6 ) eggs[0].intact = false;
                    if ( angle > -1.25 && angle < -0.6 ) eggs[1].intact = false;
                    if ( angle1 > 0 && angle1 < 0.6 ) eggs[2].intact = false;
                    if ( angle1 < 1.25 && angle1 > 0.6 ) eggs[3].intact = false;


                    ////* constant because of the movement of the AI
                    //m_body.ApplyForce( 60 * ( Math.Max( 0.4f, collider.get_weight() / get_weight() ) ) * ( collider.m_body.LinearVelocity - m_body.LinearVelocity ).Length() *
                    //                                     Vector2.Normalize( m_position - collider.m_position ) );

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

        #endregion


    }
}