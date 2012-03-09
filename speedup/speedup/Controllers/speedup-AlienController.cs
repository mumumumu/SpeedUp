//========================================================================
// speedup-AlienController.cs : Contains AI behaviors for Aliens in game
//========================================================================

using System;
using System.Collections.Generic;
using FarseerPhysics.Controllers;
using FarseerPhysics.Factories;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace speedup {
    public class AlienController : Controller {
        #region Enums
        //----------------------------------------------------------------
        // Enums
        //----------------------------------------------------------------
        public enum State {
            SPAWNING,
            PATROLLING,
            CHASING,
            ATTACKING,
            DEFENDING,
            DYING
        }
        public enum AIType {
            PEON,
            PATROL,
            TURRET,
            CHASER,
            DEFENDER,
            ATTACKER,
            BOSS
        }
        #endregion
        #region Constants
        //----------------------------------------------------------------
        // Constants
        //----------------------------------------------------------------
        private const float TUTORIAL_MAX_RANGE = 40.0f;
        private const float TUTORIAL_MAX_CHASE = 20.0f;
        private const float ALIEN_PATROL_SPEED = 0.12f;
        private const float TUTORIAL_ATTACK_RANGE = 20.0f;

        private const float QUEEN_TURN_COOLDOWN = 150.0f;
        private float turn_cooldown;
        private bool increasing;


        private float m_ai_move_step;
        private float m_ai_range;
        private float m_ai_chase_dist;
        private float m_ai_attack_dist;
        #endregion
        #region Member Variables
        //----------------------------------------------------------------
        // Member Variables
        //----------------------------------------------------------------
        private GameWorld m_world;  // The current gameworld
        public State m_state {
            get;
            set;
        }      // Current State Alien is in
        public AIType m_type;       // AI type of alien
        public Alien m_self       // Alien belonging to this controller
        {
            get;
            set;
        }
        public Ninja m_target      // Enemy Target
        {
            get;
            set;
        }
        private Alien[] m_allies;   // Allies to this alien, if applicable
        public Vector2 m_origin   // The original location the alien spawned.
        {
            get;
            set;
        }
        private Vector2 m_dest;     // Alien's next destination
        private Vector2 m_enemy_position;   // Enemy ninja's current position
        private Vector2 m_source;   // Alien's current location
        private Vector2 m_prev_src; // Alien's previous location
        public float m_start_rotation  // Original direction alien is facing.
        {
            get;
            set;
        }
        public Random rand = new Random();
        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        //
        // Creates a new AlienController with the given parameters
        public AlienController( GameWorld world, Alien alien, AIType type,
            Ninja target, float patrol_speed = ALIEN_PATROL_SPEED, float max_range = TUTORIAL_MAX_RANGE,
            float attack_dist = TUTORIAL_ATTACK_RANGE, float chase_dist = TUTORIAL_MAX_CHASE )
            : base( ControllerType.AlienController ) {



            m_world = world;
            m_self = alien;
            m_type = type;
            m_self.m_ai_type = m_type;

            if ( patrol_speed == 0 ) {
                m_self.m_move_step = ALIEN_PATROL_SPEED;

            }
            if ( max_range == 0 ) {
                m_self.m_range = TUTORIAL_MAX_RANGE;

            }
            if ( attack_dist == 0 ) {
                m_self.m_attack_dist = TUTORIAL_ATTACK_RANGE;

            }
            if ( chase_dist == 0 ) {
                m_self.m_chase_dist = TUTORIAL_MAX_CHASE;

            }

            m_start_rotation = alien.m_rotation;



            if ( alien is TwinNova ) {
                /*m_ai_move_step = m_self.m_move_step *= 0.75f;
                m_ai_range = m_self.m_range *= 1.5f;
                m_ai_attack_dist= m_self.m_attack_dist *= 0.75f;
                m_ai_chase_dist = m_self.m_chase_dist *= 1.5f; */
                m_type = AIType.BOSS;
            }
            m_ai_move_step = m_self.m_move_step;
            m_ai_range = m_self.m_range;
            m_ai_attack_dist = m_self.m_attack_dist;
            m_ai_chase_dist = m_self.m_chase_dist;


            //keep in line with the multiplier from before
            m_ai_move_step *= 0.67f;


            m_target = target;
            m_state = State.SPAWNING;
            m_origin = m_self.m_buffered_position.Value;
        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------
        public override void Update( float time_step ) {
            if ( GameScreen.within_screen_bounds( m_self.m_position ) && !m_self.m_alien_dying &&
                !m_self.m_is_dead && !GameScreen.m_halted ) {
                Path path;
                m_prev_src = m_source;
                m_source = m_self.m_body.Position;
                m_enemy_position = m_target.m_body.Position + m_target.m_body.LinearVelocity / 10;
                int x_or_y;

                // What happens in the current state
                switch ( m_state ) {
                    case State.SPAWNING:
                        // Randomly choose a destination
                        m_dest = m_origin;
                        if ( Vector2.Distance( m_source, m_dest ) > 2f ) {
                            Vector2[] vertices0 = { m_source, m_dest };
                            path = new Path( vertices0 );
                            PathManager.MoveBodyOnPath( path, m_self.m_body, 1.0f, 0.5f, ALIEN_PATROL_SPEED, if_type2:false );
                        }
                        else if ( m_self.m_body.Rotation != m_start_rotation )
                            rotate();

                        break;
                    case State.PATROLLING:
                        // If close to destination, randomly choose another destination
                        if ( Vector2.Distance( m_source, m_dest ) <= .15f ) {
                            if ( Vector2.Distance( m_source, m_origin ) <= .15f ) {
                                x_or_y = rand.Next( 2 );
                                if ( x_or_y == 0 ) {
                                    int pos_or_neg = rand.Next( 2 );
                                    if ( pos_or_neg == 0 )
                                        m_dest = m_source + ( new Vector2( 8, 0 ) );
                                    else if ( pos_or_neg == 1 )
                                        m_dest = m_source + ( new Vector2( -8, 0 ) );
                                }
                                else if ( x_or_y == 1 ) {
                                    int pos_or_neg = rand.Next( 2 );
                                    if ( pos_or_neg == 0 )
                                        m_dest = m_source + ( new Vector2( 0, 8 ) );
                                    else if ( pos_or_neg == 1 )
                                        m_dest = m_source + ( new Vector2( 0, -8 ) );
                                }
                            }
                            else
                                m_dest = m_origin;
                        }
                        // If path is obstructed, go back to origin
                        if ( Vector2.Distance( m_source, m_prev_src ) <= 0.1f ) {
                            if ( Vector2.Distance( m_source, m_origin ) <= 0.1f ) {
                                x_or_y = rand.Next( 2 );
                                if ( x_or_y == 0 ) {
                                    int pos_or_neg = rand.Next( 2 );
                                    if ( pos_or_neg == 0 )
                                        m_dest = m_source + ( new Vector2( 8, 0 ) );
                                    else if ( pos_or_neg == 1 )
                                        m_dest = m_source + ( new Vector2( -8, 0 ) );
                                }
                                else if ( x_or_y == 1 ) {
                                    int pos_or_neg = rand.Next( 2 );
                                    if ( pos_or_neg == 0 )
                                        m_dest = m_source + ( new Vector2( 0, 8 ) );
                                    else if ( pos_or_neg == 1 )
                                        m_dest = m_source + ( new Vector2( 0, -8 ) );
                                }
                            }
                            else
                                m_dest = m_origin;
                        }
                        Vector2[] vertices = { m_source, m_dest };
                        path = new Path( vertices );
                        PathManager.MoveBodyOnPath( path, m_self.m_body, 1.0f, 1.0f,
                            ALIEN_PATROL_SPEED, if_type2: false );
                        break;
                    case State.CHASING:
                        if ( !m_target.m_is_killed && !m_target.m_is_dead ) {


                            Vector2[] vertices2 = { m_source, m_enemy_position };
                            path = new Path( vertices2 );
                            PathManager.MoveBodyOnPath( path, m_self.m_body, 1.0f,
                                                       1.0f, m_self.m_move_step, if_type2: false );



                        }
                        if ( m_self.m_attack_cooldown == 0 && m_type == AIType.PATROL ) {
                            m_self.attack();
                        }
                        break;
                    case State.ATTACKING:

                        if ( m_self.m_attack_cooldown == 0 && m_self.m_body.Enabled ) {


                            if ( !( m_self is Queen ) ) {
                                m_self.attack();
                            }

                            else if ( turn_cooldown <= QUEEN_TURN_COOLDOWN / 2 ) {
                                m_self.attack();
                            }


                        }
                        if ( m_type == AIType.BOSS && !m_target.m_is_killed && !m_target.m_is_dead ) {
                            if ( m_self is Queen || m_self is BackHit ) {
                                if ( turn_cooldown <= QUEEN_TURN_COOLDOWN / 2 ) {

                                    Vector2[] vertices2 = { m_source, m_enemy_position };
                                    path = new Path( vertices2 );
                                    PathManager.MoveBodyOnPath( path, m_self.m_body, 1.0f,
                                                               1.0f, m_self.m_move_step );
                                    if ( m_self.m_body.LinearVelocity.Length() != 0 )
                                        m_self.m_body.Rotation +=
                                            ( (float)Math.Atan2( ( m_enemy_position.Y - m_source.Y ),
                                                               ( m_enemy_position.X - m_source.X ) ) - (float)Math.PI / 2 - m_self.m_body.Rotation ) / 1.5f;



                                }
                                if ( increasing ) {
                                    turn_cooldown++;
                                    if ( turn_cooldown >= QUEEN_TURN_COOLDOWN ) {
                                        increasing = false;
                                    }
                                }
                                else {
                                    turn_cooldown--;
                                    if ( turn_cooldown <= 0 ) {
                                        increasing = true;
                                    }
                                }


                            }
                            else {
                                Vector2[] vertices2 = { m_source, m_enemy_position };
                                path = new Path( vertices2 );
                                PathManager.MoveBodyOnPath( path, m_self.m_body, 1.0f,
                                                           1.0f, m_self.m_move_step );
                            }

                        }
                        else if ( Vector2.Distance( m_source, m_dest ) > 5f && m_type == AIType.ATTACKER ) {
                            Vector2[] vertices0 = { m_source, m_dest };
                            path = new Path( vertices0 );
                            PathManager.MoveBodyOnPath( path, m_self.m_body, 1.0f, 0.1f, m_ai_move_step, if_type2:false );
                        }

                        break;
                    case State.DEFENDING:
                        break;
                    case State.DYING:
                        //Pretty much do nothing
                        break;
                }
                //--------------------------------------------------------
                // State Transition
                //--------------------------------------------------------
                if ( m_self.m_alien_dying ) {
                    m_state = State.DYING;
                }
                else if ( m_self.m_disabled ) {
                    switch ( m_type ) {

                        case AIType.PATROL:
                            m_state = State.PATROLLING;
                            break;
                        case AIType.BOSS:
                            m_state = State.PATROLLING;
                            break;
                        default:
                            m_state = State.SPAWNING;
                            break;

                    }
                    
                    if (m_self.m_body.LinearVelocity.Length() != 0)

                        m_self.m_body.Rotation +=
                            ( (float)Math.Atan2( m_self.m_body.LinearVelocity.Y,
                                               m_self.m_body.LinearVelocity.X ) - (float)Math.PI / 2 - m_self.m_body.Rotation ) / 1.5f;
                }
                else {
                    switch ( m_state ) {
                        case State.SPAWNING:
                            if ( !m_target.m_is_killed && !m_target.m_is_dead ) {
                                switch ( m_type ) {
                                    case AIType.PEON:
                                        m_state = State.SPAWNING;
                                        break;
                                    case AIType.PATROL:
                                        m_state = State.PATROLLING;
                                        break;
                                    case AIType.CHASER:
                                        if ( Vector2.Distance( m_enemy_position, m_source ) <= m_self.m_chase_dist
                                            && Vector2.Distance( m_enemy_position, m_origin ) <= m_self.m_range && !m_self.m_disabled )
                                            m_state = State.CHASING;
                                        else
                                            m_state = State.SPAWNING;
                                        break;
                                    case AIType.ATTACKER:
                                        if ( Vector2.Distance( m_enemy_position, m_source ) <= m_self.m_attack_dist && !m_self.m_disabled )
                                            m_state = State.ATTACKING;
                                        else
                                            m_state = State.SPAWNING;
                                        break;
                                    case AIType.BOSS:
                                        m_state = State.PATROLLING;
                                        break;
                                }
                            }

                            break;
                        case State.PATROLLING:
                            if ( !m_target.m_is_killed && !m_target.m_is_dead && m_target.m_body != null ) {
                                switch ( m_type ) {
                                    case AIType.PATROL:
                                        if ( Vector2.Distance( m_enemy_position, m_source ) <= m_self.m_chase_dist
                                            && Vector2.Distance( m_enemy_position, m_origin ) <= m_self.m_range && !m_self.m_disabled )
                                            m_state = State.CHASING;
                                        else
                                            m_state = State.PATROLLING;
                                        break;
                                    case AIType.BOSS:
                                        if ( Vector2.Distance( m_enemy_position, m_source ) <= m_self.m_chase_dist
                                            && Vector2.Distance( m_enemy_position, m_origin ) <= m_self.m_range && !m_self.m_disabled )
                                            m_state = State.CHASING;
                                        else
                                            m_state = State.PATROLLING;
                                        break;
                                }
                            }
                            break;
                        case State.CHASING:
                            if ( !m_target.m_is_killed && !m_target.m_is_dead ) {
                                switch ( m_type ) {
                                    case AIType.PATROL:
                                        if ( Vector2.Distance( m_enemy_position, m_source ) <= m_self.m_chase_dist
                                            && Vector2.Distance( m_enemy_position, m_origin ) <= m_self.m_range )
                                            m_state = State.CHASING;
                                        else
                                            m_state = State.PATROLLING;
                                        break;
                                    case AIType.CHASER:
                                        if ( Vector2.Distance( m_enemy_position, m_source ) <= m_self.m_chase_dist
                                            && Vector2.Distance( m_enemy_position, m_origin ) <= m_self.m_range )
                                            m_state = State.CHASING;
                                        else
                                            m_state = State.SPAWNING;
                                        break;
                                    case AIType.BOSS:
                                        if ( Vector2.Distance( m_enemy_position, m_source ) <= m_self.m_attack_dist
                                            && Vector2.Distance( m_enemy_position, m_origin ) <= m_self.m_range )
                                            m_state = State.ATTACKING;
                                        else if ( Vector2.Distance( m_enemy_position, m_source ) <= m_self.m_chase_dist
                                                 && Vector2.Distance( m_enemy_position, m_origin ) <= m_self.m_range )
                                            m_state = State.CHASING;
                                        else
                                            m_state = State.PATROLLING;
                                        break;
                                }
                            }
                            break;
                        case State.ATTACKING:
                            switch ( m_type ) {
                                case AIType.ATTACKER:
                                    if ( Vector2.Distance( m_enemy_position, m_source ) <= m_self.m_attack_dist )
                                        m_state = State.ATTACKING;
                                    else
                                        m_state = State.SPAWNING;
                                    break;
                                case AIType.BOSS:
                                    if ( Vector2.Distance( m_enemy_position, m_source ) <= m_self.m_attack_dist )
                                        m_state = State.ATTACKING;
                                    else if ( Vector2.Distance( m_enemy_position, m_source ) <= m_self.m_chase_dist
                                             && Vector2.Distance( m_enemy_position, m_origin ) <= m_self.m_range )
                                        m_state = State.CHASING;
                                    else
                                        m_state = State.PATROLLING;
                                    break;
                            }
                            if ( m_self.m_body.Rotation != m_start_rotation )
                                rotate();
                            break;
                        case State.DEFENDING:
                            break;
                    }
                    if ( m_self.m_body.LinearVelocity.Length() != 0 )
                        m_self.m_body.Rotation +=
                            ( (float)Math.Atan2( m_self.m_body.LinearVelocity.Y,
                                               m_self.m_body.LinearVelocity.X ) - (float)Math.PI / 2 - m_self.m_body.Rotation ) / 1.5f;
                }
            }
        }


        public void rotate() {
            m_self.m_body.Rotation += ( m_start_rotation - m_self.m_body.Rotation ) / 100;
        }
        #endregion
    }
}
