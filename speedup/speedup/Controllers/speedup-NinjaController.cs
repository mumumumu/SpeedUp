//========================================================================
// speedup-NinjaController.cs : contains code for controlling the Ninja
//========================================================================
//
// Author: Matheus Ogleari

using System;
using System.Collections.Generic;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace speedup {
    // Controller for the Ninja object.  This contains all of the game 
    // logic for the ninja.
    public class NinjaController : Controller {
        #region Member Variables
        //----------------------------------------------------------------
        // Member Variables
        //----------------------------------------------------------------
        private Ninja m_ninja;
        private readonly GameWorld m_world;
        private int no_accel_timer;
        private int max_accel_cooldown;
        private float max_bounce_speed;

        //Animation toggle movement
        private int m_animation_toggle = 1;
        // Keyboard state
        private KeyboardState m_last_keyboard_state;
        // Mouse state
        private MouseState m_last_mouse_state;
        private bool up;
        private bool down;
        private bool left;
        private bool right;
        private bool throw_obj;
        private bool boost;
        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        //
        // Constructs a Ninja Controller for the given Ninja and World
        public NinjaController( GameWorld world, Ninja ninja )
            : base( ControllerType.NinjaController ) {
            m_world = world;
            m_ninja = ninja;
        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------
        public void HandleInput( InputState input ) {
            up = input.MoveUp;
            down = input.MoveDown;
            left = input.MoveLeft;
            right = input.MoveRight;
            if ( input.NinjaPickUp )
                m_ninja.m_picking_up = !m_ninja.m_picking_up;
            throw_obj = input.NinjaThrow;
            boost = input.NinjaBoost;
            if ( input.NinjaToggle ) {
                m_ninja.m_cruise = !m_ninja.m_cruise;
                //prevent ridiculous acceleration
                if ( m_ninja.m_cruise ) {
                    m_ninja.m_body.Restitution /= 1.7f;
                }
                else {
                    m_ninja.m_body.Restitution *= 1.7f;
                }
            }
        }

        public override void Update( float time_step ) {
            Body ninja = m_ninja.m_body;

            // Ninja cannot be dead
            if ( !m_ninja.m_is_dead ) {
                var move_force = new Vector2();
                // bool pick_up = false;
                //throw_obj = false;

                Vector2 velocity = ninja.LinearVelocity;
                MouseState mouse = Mouse.GetState();

                // If velocity is near zero, acceleration is greater
                // magnitudes of velocity
                float velocity_magnitude_X = Math.Abs( velocity.X );
                float velocity_magnitude_Y = Math.Abs( velocity.Y );
                float vel_turn_damping = 1f + Math.Min( 2, m_ninja.m_speed / 100 );


                float acceleration_multiplier_X = 1f;
                float acceleration_multiplier_Y = 1f;
                if ( velocity_magnitude_X < 20 ) {
                    acceleration_multiplier_X = Math.Max( 1.5f, Math.Min( 3f, 40 / m_ninja.m_speed ) );
                }
                if ( velocity_magnitude_Y < 20 ) {
                    acceleration_multiplier_Y = Math.Max( 1.5f, Math.Min( 3f, 40 / m_ninja.m_speed ) );
                }
                //Cannot move during cooldown
                //Receive no damping during cooldown
                KeyboardState ks = Keyboard.GetState();

                if ( no_accel_timer > 0 && m_ninja.m_speed > max_bounce_speed ) {
                    if ( m_ninja.m_cruise ) {
                        max_bounce_speed *= 1.01f;
                    }
                    ninja.LinearVelocity *= (float)Math.Sqrt( max_bounce_speed / m_ninja.m_speed );
                    m_ninja.m_speed = max_bounce_speed;
                    no_accel_timer--;
                    if ( no_accel_timer == 0 ) {
                        max_bounce_speed = 0;
                    }
                }

                #region cooldown

                //--------------------------------------------------------
                // Cooldown
                //--------------------------------------------------------     
                //
                // cooldown blocks you from moving AND from damping. 
                // Makes bouncing really good with higher cooldown
                if ( m_ninja.m_cooldown > 0 ) {
                    if ( m_ninja.m_cooldown > no_accel_timer ) {
                        max_accel_cooldown = (int)( m_ninja.m_cooldown * 2f );
                        if ( max_bounce_speed == 0 ) {
                            max_bounce_speed = m_ninja.m_speed;
                        }
                    }
                    //Testing no acceleration
                    no_accel_timer = max_accel_cooldown;
                    m_ninja.m_cooldown--;




                    // If the player changes the keyboard state after 
                    // bouncing, cooldown is cancelled
                    // Oct 16- Possibility: Hitstun vs wall collision 
                    // cooldown, maybe hitstun won't allow this
                    if ( ( m_last_keyboard_state != ks
                        || ks.GetPressedKeys().Length == 0 )
                        && !m_ninja.m_is_killed ) {
                        m_ninja.m_cooldown /= 2;
                    }

                    // While in cooldown, the ninja accelerates in the 
                    // direction he is currently facing by a constant
                    // Set this to 2x ninja force pretty much, since 
                    // the facing vector is not

                    if ( m_ninja.m_linear_velocity == Vector2.Zero ) {
                        ninja.ApplyForce( m_ninja.Facing_Vector * m_ninja.m_movement_accel * 2 );
                    }
                    else {
                        ninja.ApplyForce( Vector2.Normalize( m_ninja.m_linear_velocity ) * m_ninja.m_movement_accel * 2 );
                    }


                    if ( m_ninja.m_is_killed ) {
                        //change red if dead and during cooldown before destruction
                        m_ninja.m_tint = Color.Red;
                    }
                }
                else if ( m_ninja.m_is_killed && m_ninja.m_cooldown == 0 ) {
                    m_world.Fail();
                    m_ninja.destroy();
                    m_ninja.remove_from_world();
                }
                #endregion

                else if ( GameScreen.within_screen_bounds( m_ninja.m_position ) ) {
                    #region keyboard&movement


                    //--------------------------------------------------------
                    // Keyboard Controls
                    //--------------------------------------------------------

                    if ( !GameScreen.editor_mode ) {
                        // If in cruise mode, just skip this part
                        if ( !m_ninja.m_cruise ) {

                            if ( m_ninja.m_cruise_cooldown < 255 )
                                m_ninja.m_cruise_cooldown += 2;

                            m_ninja.m_tint = Color.White;
                            bool turn_horiz = false;
                            bool turn_vert = false;
                            bool high_vert_low_horiz = ( velocity_magnitude_X < velocity_magnitude_Y - 5 );
                            bool high_horiz_low_vert = velocity_magnitude_X > velocity_magnitude_Y + 5;


                            if ( ( right || left ) && high_vert_low_horiz ) {
                                turn_horiz = true;
                            }
                            if ( ( up || down ) && high_horiz_low_vert ) {
                                turn_vert = true;
                            }


                            // Facilitates turning by adding portion of current
                            // direction's velocity to the new turning direction
                            if ( left ) {
                                if ( velocity.X > 0 ) {
                                    move_force.X -= velocity_magnitude_X * 2;
                                }
                                if ( high_vert_low_horiz ) {
                                    move_force.X -= m_ninja.m_movement_accel + velocity_magnitude_Y * 1f;


                                }
                                else if ( turn_vert ) {
                                    move_force.X -= m_ninja.m_movement_accel /
                                                    vel_turn_damping;
                                }
                                else {
                                    move_force.X -= m_ninja.m_movement_accel;
                                }
                            }
                            if ( right ) {
                                if ( velocity.X < 0 ) {
                                    move_force.X += velocity_magnitude_X * 2;
                                }
                                if ( high_vert_low_horiz ) {
                                    move_force.X += m_ninja.m_movement_accel + velocity_magnitude_Y * 1f;
                                }
                                else if ( turn_vert ) {
                                    move_force.X += m_ninja.m_movement_accel /
                                                    vel_turn_damping;
                                }
                                else {
                                    move_force.X += m_ninja.m_movement_accel;
                                }
                            }
                            if ( up ) {
                                if ( velocity.Y > 0 ) {
                                    move_force.Y -= velocity_magnitude_Y * 2;
                                }
                                if ( high_horiz_low_vert ) {
                                    move_force.Y -= m_ninja.m_movement_accel +
                                                    velocity_magnitude_X * 1f;
                                }
                                else if ( turn_horiz ) {
                                    move_force.Y -= m_ninja.m_movement_accel /
                                                    vel_turn_damping;
                                }
                                else {
                                    move_force.Y -= m_ninja.m_movement_accel;
                                }
                            }

                            if ( down ) {
                                if ( velocity.Y < 0 ) {
                                    move_force.Y += velocity_magnitude_Y * 2;
                                }
                                if ( high_horiz_low_vert ) {
                                    move_force.Y += m_ninja.m_movement_accel +
                                                    velocity_magnitude_X * 1f;
                                }
                                else if ( turn_horiz ) {
                                    move_force.Y += m_ninja.m_movement_accel /
                                                    vel_turn_damping;
                                }
                                else {
                                    move_force.Y += m_ninja.m_movement_accel;
                                }
                            }




                            //Save data Test
                            //if (ks.IsKeyDown(Keys.M) && m_last_keyboard_state.IsKeyUp(Keys.M))
                            //{
                            //    XML_Manager xml_manager = new XML_Manager();


                            //    xml_manager.save_game_object(m_ninja, "ninja.xml");
                            //    Console.WriteLine("PRINT");
                            //}




                            move_force.X *= acceleration_multiplier_X;
                            move_force.Y *= acceleration_multiplier_Y;

                            // Even sharper turning controls when going at a decent speed
                            // Increase 1.5f to make even sharper turning
                            if ( Math.Abs( velocity.X ) > 10 && Math.Abs( velocity.Y ) > 10 ) {
                                Vector2 n_vel = Vector2.Normalize( velocity );
                                if ( Math.Abs( velocity.X ) > Math.Abs( velocity.Y ) ) {
                                    move_force.Y *= Math.Max( 1, Math.Sign( n_vel.X ) * n_vel.X * 1.5f );
                                    move_force.X *= Math.Max( 1, Math.Sign( n_vel.Y ) * n_vel.Y * 0.2f );
                                }
                                else {
                                    move_force.X *= Math.Max( 1, Math.Sign( n_vel.Y ) * n_vel.Y * 1.5f );
                                    move_force.Y *= Math.Max( 1, Math.Sign( n_vel.X ) * n_vel.X * 0.2f );
                                }
                            }

                            // nerf diagonal direction
                            if ( move_force.X != 0 && move_force.Y != 0 ) {
                                move_force.X /= 1.414f; // Square root of 2
                                move_force.Y /= 1.414f; // Square root of 2
                            }



                        }
                        else {
                            //Begin cruise

                            m_ninja.m_cruise_cooldown -= 2;

                            // check condition for exiting cruise
                            if ( ( m_last_keyboard_state != ks && m_last_keyboard_state.IsKeyUp( Keys.Q ) ||
                                  m_ninja.m_cruise_cooldown <= 0 || ks.GetPressedKeys().Length == 0 )
                                     && !m_ninja.m_is_killed ) {
                                m_ninja.m_cruise = false;
                            }

                            Vector2 dir;

                            if ( m_ninja.m_linear_velocity.Length() >= 0.3f ) {
                                dir = Vector2.Normalize( m_ninja.m_linear_velocity );
                            }
                            else {
                                dir = Vector2.Zero;
                            }


                            move_force += dir * m_ninja.m_movement_accel;

                            move_force.X *= acceleration_multiplier_X;
                            move_force.Y *= acceleration_multiplier_Y;




                        }



                    }
                    ///////////////////////////////////////////////////
                    // End of part that gets cut off in editor mode
                    ///////////////////////////////////////////////



                    // Don't want to be moving - damp out player motion
                    if ( move_force.X == 0f ||
                        Math.Sign( move_force.X ) != Math.Sign( velocity.X ) ) {
                        var damping_force =
                            new Vector2( -Ninja.NINJA_DAMPING * velocity.X, 0 );
                        //Increased damp force if moving against velocity
                        if ( Math.Sign( move_force.X ) != Math.Sign( velocity.X ) ) {
                            damping_force *= 1.8f;
                        }
                        ninja.ApplyForce( damping_force, ninja.Position );
                    }
                    if ( move_force.Y == 0f
                        || Math.Sign( move_force.Y ) != Math.Sign( velocity.Y ) ) {
                        var dampForce = new Vector2( 0, -Ninja.NINJA_DAMPING * velocity.Y );
                        //Increased damp force if moving against velocity
                        if ( Math.Sign( move_force.Y ) != Math.Sign( velocity.Y ) ) {
                            dampForce *= 1.8f;
                        }
                        ninja.ApplyForce( dampForce, ninja.Position );
                    }



                    // Test code for changing ninja's collision radius
                    m_ninja.m_body.FixtureList[0].Shape.Radius = m_ninja.m_radius * Math.Max( 1, 6.29f * (float)Math.Log10( m_ninja.m_speed * 0.0288 + 1 ) );


                    if ( boost ) {
                        Vector2 impulse = Vector2.Normalize( m_ninja.Facing_Vector );
                        impulse *= m_ninja.m_body.Mass * m_ninja.m_boost_amt;
                        m_ninja.m_body.ApplyLinearImpulse( impulse );

                    }

                    m_ninja.m_move_force = move_force;

                    m_last_keyboard_state = ks;

                    ninja.ApplyForce( move_force );



                    #endregion



                    #region MouseControls


                    //--------------------------------------------------------
                    // Mouse Controls
                    //--------------------------------------------------------


                    Vector2 m_mouse = m_world.get_transform( new Vector2( mouse.X, mouse.Y ) );
                    Vector2 norm_throw_angle = m_world.mouse_control.cursor_vector( m_mouse );

                    /*Bounds checking, commented out for now. Still need to do corner cases.
                    if ( mouse.X > m_world.mouse_control.m_bounds_width )
                    {
                        Mouse.SetPosition( m_world.mouse_control.m_bounds_width, mouse.Y );
                    }
                    else if ( mouse.X < 0 )
                    {
                        Mouse.SetPosition( 0, mouse.Y );
                    }
                    else if ( mouse.Y > m_world.mouse_control.m_bounds_height )
                    {
                        Mouse.SetPosition( mouse.X, m_world.mouse_control.m_bounds_height );
                    }
                    else if ( mouse.Y < 0 )
                    {
                        Mouse.SetPosition( mouse.X, 0 );
                    }

                    */

                    #endregion




                    //--------------------------------------------------------
                    // Speed clamping
                    //--------------------------------------------------------


                    if ( m_ninja.m_speed > m_ninja.m_maxspeed ) {
                        ninja.LinearVelocity *= (float)Math.Sqrt( m_ninja.m_maxspeed / m_ninja.m_speed );
                        m_ninja.m_speed = m_ninja.m_maxspeed;
                    }

                    //--------------------------------------------------------
                    // Throwing effect
                    //--------------------------------------------------------


                    //CHANGES
                    //Took off polar coordinate stuff. Too complicated. Vector2s work just fine, and has full class support

                    Vector2 norm_vel = Vector2.Zero;
                    Vector2 norm_move = Vector2.Zero;

                    if ( Math.Abs( velocity.X ) > 0 || Math.Abs( velocity.Y ) > 0 ) {
                        norm_vel = Vector2.Normalize( velocity );
                    }
                    if ( Math.Abs( move_force.X ) > 0 || Math.Abs( move_force.Y ) > 0 ) {
                        norm_move = Vector2.Normalize( move_force );
                    }
                    if ( norm_vel != Vector2.Zero || norm_move != Vector2.Zero ) {
                        //norm_throw_angle = Vector2.Normalize(norm_vel + norm_move*3);
                        m_ninja.Facing_Vector = norm_vel + norm_move * 3;

                    }

                    //If the ninja is abnormally far from his item, throw/drop it
                    if ( m_ninja.throwable_objects.Count > 0 ) {
                        //Creates any joints if the ninja has none (ex. loading)
                        if ( m_ninja.m_throwable_joint == null ) {
                            SliderJoint the_joint =
                                JointFactory.CreateSliderJoint( m_world.m_world,
                                                               m_ninja.m_body, m_ninja.throwable_objects.Peek().m_body,
                                                               Vector2.Zero,
                                                               Vector2.Zero, 0,
                                                               m_ninja.m_radius +
                                                               m_ninja.throwable_objects.Peek().m_radius
                                    );

                            m_ninja.m_throwable_joint = the_joint;
                        }

                        if ( !m_ninja.m_is_killed &&
                            Vector2.Distance( m_ninja.m_body.Position, m_ninja.throwable_objects.Peek().m_body.Position )
                            > m_ninja.m_throwable_joint.MaxLength * 2f ) {
                            m_ninja.throwable_objects.Peek().m_body.Position = m_ninja.m_body.Position;
                        }
                    }

                    if ( throw_obj && m_ninja.has_item() ) {

                        //Spacebar throws in the direction of the Ninja
                        //Divides by 4 so that the ninja doesn't throw very hard
                        if ( ks.IsKeyDown( Keys.Space ) ) {
                            norm_throw_angle = m_ninja.Facing_Vector / 4;

                        }
                        GameObject thrown_item = m_ninja.throw_item();

                        foreach ( GameObject item in m_ninja.throwable_objects ) {
                            item.m_body.Position = m_ninja.m_position - norm_throw_angle;
                            item.m_cooloff = 10;

                        }


                        float offset = m_ninja.m_radius;

                        Vector2 throw_offset = norm_throw_angle * offset;
                        Vector2 throw_vel = norm_throw_angle * m_ninja.m_throw_power;


                        Vector2 speed = throw_vel * ( velocity.Length() + 10 );

                        thrown_item.m_body.LinearVelocity = speed;
                        thrown_item.m_body.LinearDamping = 0f;
                        thrown_item.m_body.AngularDamping = 0f;

                        if ( Math.Abs( Vector2.Distance( Vector2.Zero, thrown_item.m_body.Position - ninja.Position ) ) <
                            ( m_ninja.m_radius + thrown_item.m_radius ) * 2.5f ) {
                            thrown_item.m_body.Position = ninja.Position + throw_offset;
                        }

                        thrown_item.m_body.JointList.Joint.Enabled = false;
                        World.RemoveJoint( thrown_item.m_body.JointList.Joint );


                        // activate the sonic boom
                        //   m_ninja.m_sonicboom.Activate( ninja.Position, norm_throw_angle, velocity.Length() + m_ninja.m_throw_power*3 );
                        GameEngine.AudioManager.Play( AudioManager.SFXSelection.throw_sfx );
                        m_ninja.m_sonicboom.Activate( ninja.Position, norm_throw_angle,
                                                     velocity.Length() + m_ninja.m_throw_power * 3 );
                    }

                    m_last_mouse_state = mouse;
                }
                m_ninja.m_speed = ninja.LinearVelocity.Length();

                m_ninja.m_facing_angle =
          Math.Atan2( ninja.LinearVelocity.Y,
                     ninja.LinearVelocity.X ) - Math.PI / 2;

                //--------------------------------------------------------
                // Animation Update
                //--------------------------------------------------------
                Ninja.ANIMATION_SPEED = Math.Max( .1f, 0.02f * (float)m_ninja.m_speed );
                m_ninja.m_is_moving = move_force.X != 0 || move_force.Y != 0;
                if ( m_ninja.m_is_moving ) {

                    m_ninja.m_animation_frame += ( m_animation_toggle ) * Ninja.ANIMATION_SPEED;
                    if ( m_ninja.m_animation_frame >= Ninja.NUM_ANIM_FRAMES ) {
                        m_ninja.m_animation_frame = Ninja.NUM_ANIM_FRAMES -
                                                    ( m_ninja.m_animation_frame - Ninja.NUM_ANIM_FRAMES );
                        m_animation_toggle *= -1;
                    }
                    else if ( m_ninja.m_animation_frame <= 0 ) {
                        m_ninja.m_animation_frame = ( -m_ninja.m_animation_frame );
                        m_animation_toggle *= -1;
                    }
                }

                else {
                    m_ninja.m_animation_frame = 2;

                }
                if ( m_ninja.m_body != null && m_ninja.m_body.LinearVelocity.Length() != 0.0f )
                    ninja.Rotation = (float)m_ninja.m_facing_angle;

                // Update the photon trail
                if ( m_ninja.m_speed_trail != null ) {
                    m_ninja.m_speed_trail.update( ninja.Position, (float)m_ninja.m_speed );
                }

                // Update sonic boom
                m_ninja.m_sonicboom.Update();


            }


        }

        #endregion
    }
}