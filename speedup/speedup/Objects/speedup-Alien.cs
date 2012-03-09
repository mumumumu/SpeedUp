//==========================================================================
// speedup-Alien.cs  
//========================================================================

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
    // Alien is a subclass of CreatureObject, 
    // a file from the Farseer Physics Lab.
    // Alien is directly controlled by the user, but that will be handles by the controller.
    // The Object class helps define all the variables to be used by the controller

    [Serializable]
    public class Alien : GameObject {
        #region Enums
        //--------------------------------------------------------------------
        // Enums
        //--------------------------------------------------------------------
        public enum AlienType {
            EASY,
            MEDIUM,
            HARD,
            PLATED,
            SPIKED,
            TWINNOVA,
            QUEEN,
            SPAWNER,
            CHASER,
            TURRET,
            DEFAULT
        };
        public enum AlienCollisionType {
            NORMAL,
            SPIKED,
            PLATED
        };
        #endregion


        #region Constants
        //--------------------------------------------------------------------
        // Constants
        //--------------------------------------------------------------------
        //
        // Speed Requirements to destroy object
        // NEW OCT 14
        // Higher collision weight means higher collision threshold
        // Experimental value of 1.0f for now
        public const float ALIEN_COLLISION_WEIGHT = 1.0f;
        public const float DESTROY_HARD = 50.0f;
        public const float DESTROY_MEDIUM = 40.0f;
        public const float DESTROY_EASY = 30.0f;

        private const float TUTORIAL_MAX_RANGE = 40.0f;
        private const float TUTORIAL_MAX_CHASE = 20.0f;
        private const float ALIEN_PATROL_SPEED = 0.12f;
        private const float TUTORIAL_ATTACK_RANGE = 20.0f;

        // Initial throw speed constant.
        // Throw speed will be affected by this as well as the Alien and object's physics.
        public static float ALIEN_THROW_POWER = 60.0f;
        // Force needed to get the Alien moving
        public static float ALIEN_FORCE = 10.0f;
        // How hard the brakes are applied to decellerate
        public static float ALIEN_DAMPING = 3.0f;
        // Alien spawning coefficients
        // Alien's starting density
        public const float ALIEN_DENSITY = 0.02f;
        // Alien's bounciness factor
        public const float ALIEN_RESTITUTION = 1f;
        // Alien's Friction
        public const float ALIEN_FRICTION = 0.9f;
        #endregion
        #region Member Variables
        //--------------------------------------------------------------------
        // Member Variables
        //--------------------------------------------------------------------
        // Series of Parameters that define the Object
        // Current position defined at the center
        // Might not need this due to the use of using the body position
        // private float m_facing_angle;

        // Body Variables
        [ContentSerializerIgnore]
        public Texture2D m_laser_texture {
            get;
            private set;
        }

        [ContentSerializer( Optional = true )]
        private int m_attack_rate;

        [ContentSerializerIgnore]
        public int m_attack_rate_change {
            get {
                return m_attack_rate;
            }
            set {
                m_attack_rate = value;
            }
        }

        [ContentSerializer( Optional = true )]
        public float m_attack_speed {
            get;
            set;
        }

        [ContentSerializer( Optional = true )]
        public float m_attack_power {
            get;
            set;
        }
        [ContentSerializer( Optional = true )]
        public float m_laser_slowdown {
            get;
            set;
        }

        [ContentSerializerIgnore]
        public Texture2D m_death_texture {
            get;
            set;
        }

        [ContentSerializerIgnore]
        public Texture2D m_attack_texture {
            get;
            set;
        }

        [ContentSerializer( Optional = true )]
        public float m_move_step {
            get;
            set;
        }  // Movement step time, smaller is faster
        [ContentSerializer( Optional = true )]
        public float m_range {
            get;
            set;
        }     // Range before alien gives up
        [ContentSerializer( Optional = true )]
        public float m_chase_dist {
            get;
            set;
        } // Max chase distance
        [ContentSerializer( Optional = true )]
        public float m_attack_dist {
            get;
            set;
        } // Max chase distance
        private bool m_is_attacking {
            get;
            set;
        }
        [ContentSerializer( Optional = true )]
        public int m_attack_cooldown {
            get;
            set;
        }
        private Texture2D m_texture_death;
        private Texture2D m_texture_attack;
        [ContentSerializerIgnore]
        public float m_animation_frame;
        // Alien's Animation variables
        [ContentSerializer( Optional = true )]
        public int m_death_anim_frames;
        [ContentSerializer( Optional = true )]
        public int m_attack_anim_frames;

        public float m_size {
            get;
            set;
        }
        // Radius defined from the center
        public float m_width {
            get;
            set;
        }
        public float m_height {
            get;
            set;
        }

        [ContentSerializerIgnore]
        public bool m_alien_dying;
        [ContentSerializerIgnore]
        public Vector2 alien_death_force;

        [ContentSerializerIgnore]
        private bool death_sound_played;

        // Scale for the draw Size
        [ContentSerializer( Optional = true )]
        public float m_size_scale {
            get;
            set;
        }


        [ContentSerializerIgnore]
        public AlienController m_ai_control {
            get;
            set;
        }

        [ContentSerializerIgnore]
        public AlienController m_ai_change {
            get {
                return m_ai_control;
            }
            set {
                if ( m_world.m_world.ControllerList.Contains( m_ai_control ) ) {
                    m_world.m_world.RemoveController( m_ai_control );
                }
                m_ai_control = value;
                m_world.m_world.AddController( m_ai_control );
            }

        }

        public override void remove_from_world() {
            /* if ( m_ai_control != null )
             {
                 m_world.m_world.RemoveController(m_ai_control);
             }  */
            base.remove_from_world();

        }

        public AlienController.State m_ai_state {
            get {
                if ( m_ai_control == null ) {
                    return AlienController.State.SPAWNING;
                }
                else {
                    return m_ai_control.m_state;
                }
            }
            set {
                if ( m_ai_control != null ) {
                    m_ai_control.m_state = value;
                }
            }
        }
        [ContentSerializer( Optional = true )]
        public AlienController.AIType m_ai_type;
        [ContentSerializerIgnore]
        public AlienController.AIType m_ai_type_change {
            get {
                return m_ai_type;
            }
            set {
                m_ai_type = value;
                m_ai_change = new AlienController( m_world, this, m_ai_type, m_world.m_ninja
                    , patrol_speed: m_move_step, max_range: m_range,
                    attack_dist: m_attack_dist, chase_dist: m_chase_dist );
            }
        }
        [ContentSerializerIgnore]
        public bool has_controller {
            get {
                return ( m_ai_control != null );
            }
            set {
                has_controller = value;
            }
        }

        public AlienType m_type {
            get;
            set;
        }

        [ContentSerializerIgnore]
        public AlienType m_type_change {
            get {
                return m_type;
            }
            set {
                m_type = value;
                set_textures();
            }
        }

        //overwrites GameObject's
        [ContentSerializer( Optional = true )]
        public float m_kill_under_speed {
            get;
            set;
        }

        //Overwrites GameObject change size that uses radius
        //Because Alien uses Ellipses
        [ContentSerializer( Optional = true )]
        public float m_change_size {
            get {
                return m_size_scale;
            }
            set {
                //Set to base width/height, then multiply by ratio
                m_width /= m_size_scale;
                m_height /= m_size_scale;
                m_size /= m_size_scale;

                m_size_scale = value;

                m_width *= m_size_scale;
                m_height *= m_size_scale;
                m_size *= m_size_scale;
                m_radius = m_size;

                m_width_height = new Vector2( m_width, m_height );

                if ( m_body != null ) {
                    m_body.DestroyFixture( m_body.FixtureList[0] );


                    FixtureFactory.AttachEllipse( m_width / 2, m_height / 2,
                                                 8, m_density, m_body );
                }
            }
        }

        public AlienCollisionType m_collision_type {
            get;
            set;
        }

        //color of the drawn alien
        [ContentSerializer( Optional = true )]
        public Color m_alien_color;

        [ContentSerializerIgnore]
        public Color m_alien_color_change {
            get {
                return m_alien_color;
            }
            set {
                m_alien_color = value;
            }
        }
        [ContentSerializerIgnore]
        public byte m_alien_color_red_change {
            get {
                return m_alien_color.R;
            }
            set {
                m_alien_color.R = value;
            }
        }
        [ContentSerializerIgnore]
        public byte m_alien_color_blue_change {
            get {
                return m_alien_color.B;
            }
            set {
                m_alien_color.B = value;
            }
        }
        [ContentSerializerIgnore]
        public byte m_alien_color_green_change {
            get {
                return m_alien_color.G;
            }
            set {
                m_alien_color.G = value;
            }
        }
        [ContentSerializerIgnore]
        public byte m_alien_color_alpha_change {
            get {
                return m_alien_color.A;
            }
            set {
                m_alien_color.A = value;
            }
        }

        #endregion
        #region Constructor
        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------
        //
        internal Alien() {

        }
        // The Alien Constructor
        //
        // <param name="world"> The World this object would be contained inside </param>
        // <param name="texture"> The image that governs the shape of this object</param>
        // <param name="velocity"> The initial velocity from throwing</param>
        // <param name="density"> The object's mass per unit area </param>
        // <param name="friction"> Usually set to 0 for throwable objects, but sliding factor </param>
        // <param name="restitution"> Bounciness </param>
        public Alien( GameWorld world, Texture2D texture, Vector2 position, float size,

            AlienType type, AlienCollisionType collision_type = AlienCollisionType.NORMAL,
            String name = "Alien", String texturename = TNames.easy_alien, AlienController.AIType ai = AlienController.AIType.PEON,

            int attack_rate = 50, float attack_power = 10, int attack_cooldown = 120,
            float laser_slowdown = 0.8f,

            float patrol_speed = ALIEN_PATROL_SPEED, float max_range = TUTORIAL_MAX_RANGE,
            float attack_dist = TUTORIAL_ATTACK_RANGE, float chase_dist = TUTORIAL_MAX_CHASE,

            float destroy_threshold = 30,

            float rotation = 0.0f, float density = ALIEN_DENSITY, float friction = ALIEN_FRICTION,
            float restitution = ALIEN_RESTITUTION, float attack_speed = 1.0f )
            : base( world, texture, position, density, friction,
            restitution, ALIEN_DAMPING, rotation: rotation, name: name,
            is_destructible: true, radius: size ) {
            m_laser_slowdown = laser_slowdown;
            m_ai_type = ai;
            m_destroy_threshold = destroy_threshold;

            m_move_step = patrol_speed;
            m_range = max_range;
            m_attack_dist = attack_dist;
            m_chase_dist = chase_dist;
            m_attack_speed = attack_speed;

            m_size_scale = (float)Math.Sqrt( size );
            m_laser_texture = TestWorld.laser_texture;
            m_attack_rate = attack_rate;                    // Will likely change
            m_attack_power = attack_power;                    // Will likely change
            m_is_attacking = false;
            m_attack_cooldown = attack_cooldown;
            m_width = ( m_size_scale ) * (float)texture.Width / ( GameWorld.SCALE );
            m_height = ( m_size_scale ) * (float)texture.Height / ( GameWorld.SCALE );

            m_radius = Math.Min( m_width, m_height ) / 2;
            m_size = m_radius;
            m_texture_name = texturename;
            m_width_height = new Vector2( m_width, m_height );
            m_type = type;
            m_collision_type = collision_type;
            m_animation_frame = 1;
            m_last_destroy_frame = false;
            m_ai_control = new AlienController( m_world, this, m_ai_type, m_world.m_ninja
                    , patrol_speed: m_move_step, max_range: m_range,
                    attack_dist: m_attack_dist, chase_dist: m_chase_dist );
            m_alien_color = Color.White;
            set_textures();
        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------
        public void attack() {
            if ( m_laser_slowdown == 0 ) {
                m_laser_slowdown = 0.8f;
            }
            if ( !m_alien_dying ) {

                m_is_attacking = true;
                m_attack_cooldown = m_attack_rate;
                float angle = m_body.Rotation - (float)Math.PI / 2;
                if ( m_attack_speed == 0.0f )
                    m_attack_speed = 1.0f;
                Vector2 launch_velocity = ( -10.0f * m_attack_speed - m_body.LinearVelocity.Length() ) *
                                          new Vector2( (float)Math.Cos( angle ), (float)Math.Sin( angle ) );


                Vector2 origin = m_body.Position -
                                 m_size * ( new Vector2( (float)Math.Cos( angle ),
                                                     (float)Math.Sin( angle ) ) ) / 3;
                Laser laser = new Laser( this, m_laser_texture, origin,
                                        launch_velocity, (int)m_attack_power, angle,
                                        Math.Max( 0.5f, m_attack_power / 50 ),
                                        m_laser_slowdown );
                /*switch ( m_type )
                {
                    case AlienType.EASY :
                        laser.m_power = 15;
                        break;
                    case AlienType.MEDIUM:
                        laser.m_power = 30;
                        break;
                    case AlienType.HARD:
                        laser.m_power = 50;
                        break;
                }   */
                // laser.m_power = (int) m_attack_power;

                if ( m_texture_name == TNames.red_nova ) {
                    laser.color_change = Color.OrangeRed;
                }
                else if ( m_texture_name == TNames.blue_nova ) {
                    laser.color_change = Color.CornflowerBlue;
                }
                else if ( m_texture_name == TNames.queen_alien ) {
                    laser.color_change = new Color( 0, 255, 255 );
                }
                m_world.add_queued_object( laser );
            }
        }

        protected override Body create_physics() {

            var new_body = BodyFactory.CreateEllipse( m_world.m_world, m_width / 2,
                m_height / 2, 6, m_density );
            death_sound_played = false;

            new_body.BodyType = BodyType.Dynamic;
            new_body.IsBullet = true;
            new_body.Rotation = m_rotation;
            new_body.Restitution = m_restitution;
            new_body.Friction = m_friction;
            new_body.FixedRotation = true;
            new_body.LinearDamping = m_damping;
            new_body.Mass = m_mass;
            return new_body;
        }

        public override void add_to_world() {
            base.add_to_world();
            if ( m_ai_control != null ) {
                m_world.m_world.AddController( m_ai_control );
            }
        }

        public virtual void set_textures() {


            //Aura Setting
            switch ( m_collision_type ) {
                case AlienCollisionType.NORMAL:
                    m_tint = new Color( 10 * m_kill_under_speed, 0,
                                         0, 10 );
                    break;
                case AlienCollisionType.PLATED:
                    m_tint = new Color( 20, 10, 0, 100 );
                    break;
                case AlienCollisionType.SPIKED:
                    m_tint = new Color( 255, 0, 150, 100 );
                    break;
            }
            m_tint = Color.Lerp( m_alien_color, m_tint, 0.7f );


            //Change texture and animation/death based on type
            switch ( m_type ) {
                case AlienType.DEFAULT:
                    m_texture_name_change = m_texture_name;
                    m_texture_death = Statics.get_texture( TNames.easy_alien_death );
                    m_death_anim_frames = 8;
                    m_texture_attack = Statics.get_texture( TNames.easy_alien_attack );
                    m_attack_anim_frames = 4;
                    break;
                case AlienType.EASY:
                    m_texture_name_change = TNames.easy_alien;
                    m_texture_death = Statics.get_texture( TNames.easy_alien_death );
                    m_death_anim_frames = 8;
                    m_texture_attack = Statics.get_texture( TNames.easy_alien_attack );
                    m_attack_anim_frames = 4;
                    break;
                case AlienType.MEDIUM:
                    m_texture_name_change = TNames.medium_alien;
                    m_texture_death = Statics.get_texture( TNames.medium_alien_death );
                    m_death_anim_frames = 8;
                    m_texture_attack = Statics.get_texture( TNames.medium_alien_attack );
                    m_attack_anim_frames = 4;
                    break;
                case AlienType.HARD:
                    m_texture_name_change = TNames.hard_alien;
                    m_texture_death = Statics.get_texture( TNames.hard_alien_death );
                    m_death_anim_frames = 8;
                    m_texture_attack = Statics.get_texture( TNames.hard_alien_attack );
                    m_attack_anim_frames = 4;
                    break;
                case AlienType.CHASER:
                    m_texture_name_change = TNames.chaser_alien;
                    m_texture_death = Statics.get_texture( TNames.easy_alien_death );
                    m_death_anim_frames = 8;
                    m_texture_attack = Statics.get_texture( TNames.easy_alien_attack );
                    m_attack_anim_frames = 4;
                    break;
                case AlienType.SPAWNER:
                    m_texture_name_change = TNames.spawner_alien;
                    m_texture_death = Statics.get_texture( TNames.easy_alien_death );
                    m_death_anim_frames = 8;
                    break;
                case AlienType.TURRET:
                    m_texture_name_change = TNames.alien_turret;
                    m_texture_death = Statics.get_texture( TNames.easy_alien_death );
                    m_death_anim_frames = 8;
                    break;
                case AlienType.SPIKED:
                    m_texture_name_change = TNames.spiked_alien;
                    m_texture_death = Statics.get_texture( TNames.spiked_alien_death );
                    m_death_anim_frames = 7;
                    m_texture_attack = Statics.get_texture( TNames.spiked_alien_attack );
                    m_attack_anim_frames = 6;
                    break;
                case AlienType.PLATED:
                    m_texture_name_change = TNames.plated_alien;
                    m_texture_death = Statics.get_texture( TNames.plated_alien_death );
                    m_death_anim_frames = 8;
                    break;
                case AlienType.TWINNOVA:
                    m_texture_name_change = m_texture_name;
                    m_texture_death = Statics.get_texture( TNames.plated_alien_death );
                    m_death_anim_frames = 8;
                    if ( m_texture_name == TNames.red_nova ) {
                        m_tint = Color.Red;
                        m_attack_anim_frames = 6;
                        m_texture_attack = Statics.get_texture( TNames.red_nova_attack );
                    }
                    else if ( m_texture_name == TNames.blue_nova ) {
                        m_tint = Color.CornflowerBlue;
                        m_attack_anim_frames = 6;
                        m_texture_attack = Statics.get_texture( TNames.blue_nova_attack );

                    }
                    break;
                case AlienType.QUEEN:
                    m_texture_name_change = TNames.queen_alien;
                    m_texture_death = Statics.get_texture( TNames.alien_queen_death );
                    m_death_anim_frames = 7;
                    m_texture_attack = Statics.get_texture( TNames.alien_queen_attack );
                    m_attack_anim_frames = 6;
                    break;
                default: break;

            }

        }

        public override void update( GameWorld world, float time_step ) {
            if ( m_body.Mass < .15f ) { m_body.Mass = 0.4f; }
            if ( m_body.Restitution < .1f ) { m_body.Restitution = 1; }
            if ( m_attack_cooldown > 0 ) {
                m_attack_cooldown--;
            }
            base.update( world, time_step );
        }

        public override void draw( SpriteBatch sprite_batch, Camera eye ) {

            if ( m_collision_type != AlienCollisionType.SPIKED ) {
                draw_destroyable( sprite_batch, eye );
            }

            if ( m_disabled ) {
                m_tint = Color.Lerp( m_alien_color, m_tint, 0.5f );
            }
            // Block for alien playing dying animation
            if ( m_alien_dying || !m_body.Enabled ) {
                if ( m_alien_dying ) {
                    m_body.LinearDamping = 0;
                }

                m_tint = Color.Lerp( m_alien_color, m_tint, 0.5f );
                m_body.ApplyForce( alien_death_force / Math.Max( 1, m_animation_frame / 2 ) );
                int image_size = m_texture_death.Width / m_death_anim_frames;
                int frame = (int)m_animation_frame;

                Vector2 origin = new Vector2( image_size,
                        m_texture_death.Height ) / 2;

                // Draw the alien rectangle
                Rectangle src = new Rectangle( frame * image_size,  //get the frame to display
                                              0,                    //the image only has 1 row of frames
                                              image_size, m_texture_death.Height );    //image height and width

                sprite_batch.Draw( m_texture_death, GameWorld.SCALE * m_body.Position, src,
                             m_alien_color, m_body.Rotation, origin, m_size_scale,
                             0.0f, 0
                );


                m_animation_frame += (float)0.0005f * image_size;
                if ( frame >= m_death_anim_frames ) {
                    if(!death_sound_played){
                        GameEngine.AudioManager.Play( AudioManager.SFXSelection.alien_death );
                        death_sound_played = true;
                    }
                    m_last_destroy_frame = true;
                    m_body.Enabled = false;
                    destroy();
                }
            }
            // Plays animation for attacking
            else if ( m_is_attacking && m_texture_attack != null ) {

                int image_size = m_texture_attack.Width / m_attack_anim_frames;
                int frame = (int)m_animation_frame;
                Vector2 origin = new Vector2( image_size,
                        m_texture_attack.Height ) / 2;

                // Draw the alien rectangle
                Rectangle src = new Rectangle( frame * image_size,  //get the frame to display
                                              0,                    //the image only has 1 row of frames
                                              image_size, m_texture_attack.Height );    //image height and width

                sprite_batch.Draw( m_texture_attack, GameWorld.SCALE * m_body.Position, src,
                             m_alien_color, m_body.Rotation, origin, m_size_scale,
                             0.0f, 0
                );
                m_animation_frame += 0.0002f * image_size;
                m_animation_frame %= m_attack_anim_frames;
                if ( frame == m_attack_anim_frames ) {
                    m_is_attacking = false;
                    m_animation_frame = 0.0f;
                }
            }
            else {
                var origin = new Vector2( m_texture.Width, m_texture.Height ) / 2;
                sprite_batch.Draw( m_texture, GameWorld.SCALE * m_body.Position, null,
                                 m_alien_color, m_body.Rotation, origin, m_size_scale,
                                  0.0f, 0
                                );
            }
            //Aura drawings
            if ( m_alien_dying ) {
                var origin = new Vector2( TestWorld.highlight_texture.Width, TestWorld.highlight_texture.Height ) / 2;


                sprite_batch.Draw(TestWorld.highlight_texture, GameWorld.SCALE * m_body.Position, null,
                   Color.CornflowerBlue, m_body.Rotation, origin,
                    // Number next to max is the minimum size, number next to min is the maximum size
                    m_width_height / 5 * Math.Max( 0.8f, Math.Min( 1.5f, 200 / (float)Math.Pow( ( m_position - m_world.m_ninja.m_position ).Length(), 2 ) ) ), 0.0f, 1 );


            }
            else if ( m_world.m_ninja.m_speed < m_kill_under_speed
                || m_collision_type != AlienCollisionType.NORMAL ) {

                var origin = new Vector2( TestWorld.highlight_texture.Width, TestWorld.highlight_texture.Height ) / 2;


                sprite_batch.Draw( TestWorld.highlight_texture, GameWorld.SCALE * m_body.Position, null,
                   m_tint, m_body.Rotation, origin,
                    // Number next to max is the minimum size, number next to min is the maximum size
                    m_width_height / 5 * Math.Max( 0.8f, Math.Min( 1.5f, 200 / (float)Math.Pow( ( m_position - m_world.m_ninja.m_position ).Length(), 2 ) ) ), 0.0f, 1 );

            }
            else if ( m_world.m_ninja.m_speed < m_destroy_threshold && m_world.m_ninja.m_speed > m_kill_under_speed ) {
                var origin = new Vector2( TestWorld.highlight_texture.Width, TestWorld.highlight_texture.Height ) / 2;


                sprite_batch.Draw( TestWorld.highlight_texture, GameWorld.SCALE * m_body.Position, null,
                   Color.Lerp( m_tint, Color.Silver, .6f ), m_body.Rotation, origin,
                    // Number next to max is the minimum size, number next to min is the maximum size
                    m_width_height / 5 * 1.1f, 0.0f, 1 );

            }
        }
        #endregion
    }

}
