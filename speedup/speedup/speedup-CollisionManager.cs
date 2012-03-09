//========================================================================
// speedup-CollisionManager.cs : handles different types of collisions 
//                               the game
//========================================================================
//
// Author: Matheus Ogleari

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Contacts;
using FarseerPhysics.Common;
using FarseerPhysics.Controllers;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Graphics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace speedup {
    public class CollisionManager {
        #region Member Variables

        //----------------------------------------------------------------
        // Member Variables
        //----------------------------------------------------------------
        // private readonly HashSet<Fixture> m_sensor_fixtures;

        #endregion

        #region Constructor

        /*public CollisionManager()
        {
            m_sensor_fixtures = new HashSet<Fixture>();
        }*/

        #endregion

        #region Methods

        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------
        public bool contact_started( Contact contact ) {
            GameObject obj1 = (GameObject)contact.FixtureA.Body.UserData;
            GameObject obj2 = (GameObject)contact.FixtureB.Body.UserData;

            // Pointer collides with object, return gameobject for selection
            if ( obj1 is Selector && obj2 is GameObject ||
                obj2 is Selector && obj1 is GameObject ) {
                GameObject obj = obj1 is GameObject ? (GameObject)obj1 : (GameObject)obj2;
                Selector objS = obj1 is Selector ? (Selector)obj1 : (Selector)obj2;

                if ( !( obj is Selector ) &&
                    ( ( objS.editor.selectbox == null ) || objS.editor.selectbox != null && objS.editor.selectbox != obj ) ) {
                    objS.editor.selected = obj;


                }


                objS.destroy();
                objS.remove_from_world();


                return false;

            }

            // Ninja or throwing item collides with destructible walls
            if ( obj2 is PolygonObject && obj2.m_is_destructible && ( obj1 is Ninja || obj1.m_is_throwable )
                || obj1 is PolygonObject && obj1.m_is_destructible && ( obj2 is Ninja || obj2.m_is_throwable ) ) {
                PolygonObject wall = obj1 is PolygonObject ? (PolygonObject)obj1 : (PolygonObject)obj2;
                GameObject collider = ( obj1 is PolygonObject ) ? obj2 : obj1;
                if ( collider.m_body.LinearVelocity.Length() > wall.m_destroy_threshold ) {
                    wall.destroy();
                    wall.remove_from_world();
                    return false;
                }
                else {
                    if ( collider is Ninja && ( (Ninja)collider ).m_cooldown <= 0 ) {
                        ( (Ninja)collider ).m_cooldown =
                            Math.Min( (int)( (Ninja)collider ).m_speed / 5,
                                     Ninja.NINJA_COLLISION_COOLDOWN );
                    }
                    // return true;
                }
            }


            // Alien on Alien collision
            if ( obj1 is Alien && obj2 is Alien ) {
                float obj1_speed = obj1.m_body.LinearVelocity.Length();
                float obj2_speed = obj2.m_body.LinearVelocity.Length();
                Alien alien1 = (Alien)obj1;
                Alien alien2 = (Alien)obj2;

                float alien1weight = alien1.get_weight();
                float alien2weight = alien2.get_weight();


                if ( !( alien1 is Queen || alien2 is Queen || alien1 is BackHit || alien2 is BackHit ) ) {
                    if ( ( alien1.m_alien_dying && !alien2.m_alien_dying && obj1_speed > Math.Min( 119, obj2.m_destroy_threshold * 1.5f / ( alien1weight / alien2weight ) ) ) ) {

                        alien2.m_alien_dying = true;
                        alien2.m_alien_color = Color.DarkCyan;
                        alien2.m_animation_frame = 2;
                        Vector2 death_force =
                           ( alien1weight / alien2weight ) * ( alien1.m_body.LinearVelocity - alien2.m_body.LinearVelocity ).Length() *
                                              Vector2.Normalize( alien2.m_position - alien1.m_position );
                        alien2.alien_death_force = death_force;
                        alien2.m_body.ApplyLinearImpulse( death_force / 5 );
                    }
                    if ( ( alien2.m_alien_dying && !alien1.m_alien_dying && obj2_speed > Math.Min( 119, obj1.m_destroy_threshold * 1.5f / ( alien2weight / alien1weight ) ) ) ) {

                        alien1.m_alien_dying = true;
                        alien1.m_alien_color = Color.DarkCyan;
                        alien1.m_animation_frame = 2;
                        Vector2 death_force =
                            ( alien2weight / alien1weight ) * ( alien2.m_body.LinearVelocity - alien1.m_body.LinearVelocity ).Length() *
                                               Vector2.Normalize( alien1.m_position - alien2.m_position );
                        alien1.alien_death_force = death_force;
                        alien1.m_body.ApplyLinearImpulse( death_force / 5 );
                    }
                }


                return true;
            }

            if ( obj1 is Laser || obj2 is Laser ) {
                if ( obj1 is Laser && obj2 is Laser )
                    return false;
                Laser laser = obj1 is Laser ? (Laser)obj1 : (Laser)obj2;
                GameObject target = obj1 is Laser ? obj2 : obj1;
                if ( laser.m_owner == target )
                    return false;
                if ( target is TwinNova )
                    return false;
                else {
                    if ( target is Ninja ) {
                        if ( laser.m_power > target.m_body.LinearVelocity.Length() )
                            ( (Ninja)target ).m_is_killed = true;
                        else
                            target.m_body.LinearVelocity *= laser.m_slowdown;
                    }
                    laser.destroy();

                }
            }

            // Ninja collide with walls, receive cooldown
            if ( obj1 is Ninja && obj2 is PolygonObject ||
                obj2 is Ninja && obj1 is PolygonObject ) {
                Ninja ninja = obj1 is Ninja ? (Ninja)obj1 : (Ninja)obj2;
                if ( ninja.m_cooldown <= 0 ) {
                    ninja.m_cooldown =
                        Math.Min( (int)ninja.m_speed / 5,
                                 Ninja.NINJA_COLLISION_COOLDOWN );
                }
                else {
                    ninja.m_cooldown /= 2;
                }
            }

            // Ninja collide with triggerable objects, receive cooldown against doors
            if ( obj1 is Ninja && obj2 is TriggerableObject ||
                obj2 is Ninja && obj1 is TriggerableObject ) {
                Ninja ninja = obj1 is Ninja ? (Ninja)obj1 : (Ninja)obj2;
                TriggerableObject t_obj = obj1 is TriggerableObject
                                              ? (TriggerableObject)obj1
                                              : (TriggerableObject)obj2;
                if ( ninja.m_cooldown <= 0 && t_obj.m_type == TriggerableObject.TriggerType.DOOR ) {
                    ninja.m_cooldown =
                        Math.Min( (int)ninja.m_speed / 5,
                                 Ninja.NINJA_COLLISION_COOLDOWN );
                }
            }

            // Ninja contact with throwable Object.
            // Pick up if in pickup mode
            if ( obj1 is Ninja && obj2.m_is_throwable
                && ( (Ninja)obj1 ).m_picking_up ||
                obj2 is Ninja && obj1.m_is_throwable
                && ( (Ninja)obj2 ).m_picking_up ) {
                Ninja ninja = obj1 is Ninja ? (Ninja)obj1 : (Ninja)obj2;
                GameObject item = obj1.m_is_throwable ? obj1 : obj2;
                ninja.pick_up( item );
            }

            // Ninja contact with DeathTouch.
            // Instant Death
            if ( obj1 is Ninja && obj2 is DeathTouch ||
                obj2 is Ninja && obj1 is DeathTouch ) {
                Ninja ninja = obj1 is Ninja ? (Ninja)obj1 : (Ninja)obj2;
                ninja.m_is_killed = true;
            }

            // Ninja contact with DeathTouch.
            // Instant Death
            if ( obj1.m_is_throwable && obj2 is DeathTouch ||
                obj2.m_is_throwable && obj1 is DeathTouch ||
                obj1 is Alien && obj2 is DeathTouch ||
                obj2 is Alien && obj1 is DeathTouch ) {
                return false;
            }


            // Ninja/Projectile collision with alien
            if ( obj2 is Alien && ( obj1 is Ninja || obj1.m_is_throwable ) ||
                obj1 is Alien && ( obj2 is Ninja || obj2.m_is_throwable ) ) {
                Alien alien = obj1 is Alien ? (Alien)obj1 : (Alien)obj2;

                GameObject collider = obj1 is Alien ? obj2 : obj1;
                /* m_sensor_fixtures.Add( collider.Equals( obj1 ) ?
                    contact.FixtureB : contact.FixtureA );*/

                if ( alien is TwinNova ) return ( (TwinNova)alien ).collision( collider );

                if ( alien is Queen ) return ( (Queen)alien ).collision( collider );
                if ( alien is BackHit ) return ( (BackHit)alien ).collision( collider );
                if ( alien is MultiHit ) return ( (MultiHit)alien ).collision( collider );

                float contact_body_speed = collider.m_body.LinearVelocity.Length();
                if ( collider is Ninja &&
                    alien.m_collision_type == Alien.AlienCollisionType.SPIKED && !alien.m_alien_dying ) {
                    ( (Ninja)collider ).m_is_killed = true;
                }
                else if ( alien.m_alien_dying ) {
                    alien.m_body.ApplyLinearImpulse( ( Math.Min( contact_body_speed,
                         Math.Max( 0.5f, collider.get_weight() / alien.get_weight() ) * ( collider.m_body.LinearVelocity - alien.m_body.LinearVelocity ).Length() ) *
                                           Vector2.Normalize( alien.m_position - collider.m_position ) ) / 4 );
                    return false;
                }
                else if ( contact_body_speed > alien.m_destroy_threshold ) {
                    alien.m_alien_dying = true;
                    alien.m_alien_color = Color.DarkCyan;
                    alien.m_animation_frame = 2;
                    Vector2 death_force = Math.Min( contact_body_speed,
                        Math.Max( 0.5f, collider.get_weight() / alien.get_weight() ) * ( collider.m_body.LinearVelocity - alien.m_body.LinearVelocity ).Length() ) *
                                          Vector2.Normalize( alien.m_position - collider.m_position );
                    alien.alien_death_force = death_force * 1.5f;
                    alien.m_body.LinearVelocity = ( death_force / 1.5f );
                    alien.m_body.ApplyTorque( contact_body_speed );
                    return false;
                }
                else if ( contact_body_speed < alien.m_kill_under_speed
                         && collider is Ninja ) {
                    ( (Ninja)collider ).m_cooldown = 30;
                    ( (Ninja)collider ).m_is_killed = true;
                }
                else {
                    alien.m_body.ApplyForce( ( collider.get_weight() / alien.get_weight() ) * ( collider.m_body.LinearVelocity - alien.m_body.LinearVelocity ).Length() *
                                                         Vector2.Normalize( alien.m_position - collider.m_position ) );

                    if ( collider is Ninja ) {
                        ( (Ninja)collider ).m_cooldown = Ninja.NINJA_COLLISION_COOLDOWN;
                        collider.m_body.ApplyLinearImpulse( ( ( contact_body_speed / 3.5f ) * alien.get_weight() ) *
                                                        Vector2.Normalize( collider.m_position - alien.m_position ) );

                        //alien.m_body.ApplyLinearImpulse(((Ninja)collider).m_speed*((Ninja)collider).m_speed*(alien.m_position-((Ninja)collider).m_position));
                    }
                }
            }
            // Ninja/Projectile Collision with switches
            if ( obj2 is Trigger && ( obj1 is Ninja || obj1.m_is_throwable ) ||
                obj1 is Trigger && ( obj2 is Ninja || obj2.m_is_throwable ) ) {
                Trigger trigger = obj1 is Trigger ? (Trigger)obj1 : (Trigger)obj2;
                GameObject collider = obj1 is Trigger ? obj2 : obj1;

                if ( trigger.can_be_activated_by( collider ) ) {

                    /*m_sensor_fixtures.Add( collider.Equals( obj1 ) ?
                     contact.FixtureB : contact.FixtureA );*/
                    trigger.activate();
                    //trigger.m_body.RestoreCollisionWith(collider.m_body);
                }
            }

            return true;
        }

        public void contact_ended( Contact contact ) {
            GameObject obj1 = (GameObject)contact.FixtureA.Body.UserData;
            GameObject obj2 = (GameObject)contact.FixtureB.Body.UserData;


            // Ninja/Projectile collision with alien
            if ( obj2 is Alien && ( obj1 is Ninja || obj1.m_is_throwable ) ||
                obj1 is Alien && ( obj2 is Ninja || obj2.m_is_throwable ) ) {
                Alien alien = obj1 is Alien ? (Alien)obj1 : (Alien)obj2;
                GameObject collider = obj1 is Alien ? obj2 : obj1;
                /* m_sensor_fixtures.Add( collider.Equals( obj1 ) ?
                    contact.FixtureB : contact.FixtureA );*/



                float contact_body_speed = collider.m_body.LinearVelocity.Length();
                if ( !alien.m_alien_dying ) {
                    if ( collider is Ninja && !( (Ninja)collider ).m_is_killed ) {
                        alien.m_body.ApplyLinearImpulse( ( (Ninja)collider ).m_speed *
                                                      Vector2.Normalize( alien.m_position - ( (Ninja)collider ).m_position ) );

                    }
                    else {
                        alien.m_body.ApplyLinearImpulse( contact_body_speed *
                                                       Vector2.Normalize( alien.m_position - collider.m_position ) );
                    }
                }

            }


            if ( obj2 is Trigger && ( obj1 is Ninja || obj1.m_is_throwable ) ||
                         obj1 is Trigger && ( obj2 is Ninja || obj2.m_is_throwable ) ) {
                Trigger trigger = obj1 is Trigger ? (Trigger)obj1 : (Trigger)obj2;
                GameObject collider = obj1 is Trigger ? obj2 : obj1;
                if ( trigger.can_be_activated_by( collider ) ) {
                    /*m_sensor_fixtures.Add( collider.Equals( obj1 ) ?
                    contact.FixtureB : contact.FixtureA );*/
                    Vector2 obj_pos = collider.m_position;
                    if ( trigger.m_body != null && trigger.m_body.FixtureList.Any( fixture => fixture.TestPoint( ref obj_pos ) ) ) {
                        if ( trigger is BallSpawner ) {
                            BallSpawner spawn = (BallSpawner)trigger;
                            if ( !spawn.ball_list.Contains( collider ) ) {
                                spawn.ball_list.AddLast( collider );
                            }
                        }
                        trigger.activate();
                    }
                    else if ( trigger is BallSpawner ) {
                        BallSpawner spawn = (BallSpawner)trigger;
                        if ( spawn.ball_list.Contains( collider ) ) {
                            spawn.ball_list.Remove( collider );
                            if ( spawn.ball_list.Count == 0 ) {
                                spawn.deactivate();
                            }
                        }
                    }
                    else {
                        trigger.deactivate();
                    }


                }
            }
        }

        #endregion
    }
}
