//==========================================================================
// speedup-Ninja.cs  
//========================================================================
//
// Author: Sanford Johnson


using System;
using System.Collections.Generic;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace speedup {

    // Ninja is a subclass of CreatureObject, 
    // a file from the Farseer Physics Lab.
    // Ninja is directly controlled by the user, but that will be handles by the controller.
    // The Object class helps define all the variables to be used by the controller


    public class Ninja : GameObject {
        #region Constants
        //------------------------------------------------------------
        // Constants
        //------------------------------------------------------------
        //

        public const int NUM_ANIM_FRAMES = 5;
        // NEW: COLLISION COOLDOWN: COOLDOWN AFTER COLLISION
        public const int NINJA_COLLISION_COOLDOWN = 10;
        // Scale for the Draw Size
        public const float NINJA_SIZE_SCALE = 0.3f;
        // Initial throw speed staticant.
        // Throw speed will be affected by this as well as the ninja 
        // and object's physics.     
        public const float NINJA_THROW_POWER = 5.0f * NINJA_SIZE_SCALE *
            GameWorld.OBJECT_SCALE;
        // Force needed to get the Ninja moving  
        public const float NINJA_FORCE = 10.0f;
        // How hard the brakes are applied to decellerate 
        public const float NINJA_DAMPING = 1.3f;
        // Upper limit on movement   
        public const float NINJA_MAXSPEED = 150.0f;

        // Upper limit on amount of items able to be held  
        public const int NINJA_MAXTHROWABLE_CAPACITY = 2;

        // Ninja spawning coefficients 

        // Ninja's starting density 
        public const float NINJA_DENSITY = 0.36f;
        // Ninja's bounciness factor  
        public const float NINJA_RESTITUTION = 1.0f;
        // Ninja's Friction
        public const float NINJA_FRICTION = 0.2f;
        #endregion
        #region Static Variables
        //--------------------------------------------------------------------
        // Static variables
        //--------------------------------------------------------------------
        //
        // NEW 10-10-11 Animations
        public static float ANIMATION_SPEED = 0;
        #endregion
        #region Member Variables
        //--------------------------------------------------------------------
        // Member variables
        //--------------------------------------------------------------------
        //
        // Series of Parameters that define the Object
        // List of throwable objects the ninja has.
        // Implemented using a stack because of its Last In First Out structure.
        #region Serialized Variables

        //How hard the alien throws depending on speed
        public float m_throw_power { get; set; }

        //How quickly the ninja acelerates
        public float m_movement_accel { get; set; }

        //Maximum allowable speed
        public float m_maxspeed { get; set; }

        //How many throwable items one is able to carry at once
        public int m_max_throwable_capacity { get; set; }

        //Amount the ninja's speed increases by
        [ContentSerializer( Optional = true )]
        public float m_boost_amt { get; set; }

        //Ninja's Control mode
        [ContentSerializer( Optional = true )]
        public bool m_cruise { get; set; }

        //Ninja's cruise cooldown
        [ContentSerializer( Optional = true )]
        public int m_cruise_cooldown { get; set; }

        public float m_speed {
            get;
            set;
        }

        public bool m_picking_up {
            get;
            set;
        }

        public bool m_is_moving {
            get;
            set;
        }

        public double m_facing_angle {
            get;
            set;
        }

        [ContentSerializerIgnore]
        public Vector2 m_move_force {
            get;
            set;
        }


        [ContentSerializerIgnore]
        public bool m_is_killed {
            get;
            set;
        }

        [ContentSerializerIgnore]
        public int m_cooldown {
            get;
            set;
        }

        [ContentSerializerIgnore]
        public float m_animation_frame {
            get;
            set;
        }

        public Vector2 Facing_Vector {
            get;
            set;
        }

        //speed trail
        [ContentSerializerIgnore]
        public PhotonTrailQueue m_speed_trail {
            get;
            set;
        }

        //Sonic Boom
        [ContentSerializerIgnore]
        public SonicBoom m_sonicboom {
            get;
            set;
        }


        #endregion

        [ContentSerializerIgnore]
        private float aura_rotation = 0;

        [ContentSerializer]
        private bool m_has_item;

        private SharedResourceStack m_throwing_items =
            new SharedResourceStack();


        [ContentSerializerIgnore]
        public Fixture m_sensor_fixture {
            get;
            private set;
        }

        // Joint used for the Ninja to the throwable object
        [ContentSerializerIgnore]
        public SliderJoint m_throwable_joint {
            get;
            set;
        }

        //Added so the controller can access items
        [ContentSerializer]
        public SharedResourceStack throwable_objects {
            get { return m_throwing_items; }
            set { m_throwing_items = value; }
        }

        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        //


        internal Ninja()
            : this( name: "Ninja" ) {

            m_speed_trail = new PhotonTrailQueue( GameScreen.GAME_CONTENT.Load<Texture2D>( TNames.trail ), Vector2.Zero );
            m_sonicboom = new SonicBoom( GameScreen.GAME_CONTENT.Load<Texture2D>( TNames.sonic_boom ) );
        }

        public Ninja( float throw_power = NINJA_THROW_POWER, float move_force = NINJA_FORCE,
            float maxspeed = NINJA_MAXSPEED, int capacity = NINJA_MAXTHROWABLE_CAPACITY,
            String name = "Ninja", String texture_name = TNames.ninja_animate, float boost = 50 ) {
            m_throw_power = throw_power;
            m_movement_accel = move_force;
            m_maxspeed = maxspeed;
            m_max_throwable_capacity = capacity;
            throwable_objects = m_throwing_items;
            m_boost_amt = boost;
            m_cruise_cooldown = 255;

            m_has_item = m_throwing_items.Count > 0;
            m_facing_angle = (float)Math.PI / 2;
            m_picking_up = true;

            m_speed_trail = new PhotonTrailQueue( GameScreen.GAME_CONTENT.Load<Texture2D>( TNames.trail ), Vector2.Zero );
            m_sonicboom = new SonicBoom( GameScreen.GAME_CONTENT.Load<Texture2D>( TNames.sonic_boom ) );

        }

        // The Ninja Constructor
        // <param name="world"> The World this object would be contained 
        // inside </param>
        // <param name="texture"> The image that governs the shape of this 
        // object</param>
        // <param name="velocity"> The initial velocity from throwing</param>
        // <param name="density"> The object's mass per unit area </param>
        // <param name="friction"> Usually set to 0 for throwable objects, 
        // but sliding factor </param>
        // <param name="restitution"> Bounciness </param>
        public Ninja( GameWorld world, Texture2D texture, Vector2 position,
            float radius, float throw_power = NINJA_THROW_POWER, float move_force = NINJA_FORCE,
            float maxspeed = NINJA_MAXSPEED, int capacity = NINJA_MAXTHROWABLE_CAPACITY,
            String name = "Ninja", String texture_name = TNames.ninja_animate, float boost = 50 )
            : base( world, texture, NINJA_DENSITY, NINJA_FRICTION,
                    NINJA_RESTITUTION, name: name, texture_name: texture_name ) {

            m_throw_power = throw_power;
            m_movement_accel = move_force;
            m_maxspeed = maxspeed;
            m_max_throwable_capacity = capacity;
            throwable_objects = m_throwing_items;
            m_boost_amt = boost;

            m_buffered_position = position;
            m_radius = radius * NINJA_SIZE_SCALE;
            m_has_item = m_throwing_items.Count > 0;
            m_facing_angle = (float)Math.PI / 2;
            m_picking_up = true;
            m_cruise_cooldown = 255;

            m_speed_trail = new PhotonTrailQueue( GameScreen.GAME_CONTENT.Load<Texture2D>( TNames.trail ), position );
            m_sonicboom = new SonicBoom( GameScreen.GAME_CONTENT.Load<Texture2D>( TNames.sonic_boom ) );

        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------

        protected override Body create_physics() {

            Body new_body = BodyFactory.CreateCircle( m_world.m_world, m_radius,
                m_density * 2 );
            if ( m_density != 0 ) {
                new_body.BodyType = BodyType.Dynamic;
                //made the ninja a bullet for better hit detection
                new_body.IsBullet = true;
                //fixed rotation for now
                new_body.FixedRotation = true;
                //Damping
                new_body.LinearDamping = m_damping;
            }
            new_body.Restitution = m_restitution;
            new_body.Friction = m_friction;
            new_body.Mass = m_mass;


            return new_body;
        }

        public bool has_item() {
            return ( m_throwing_items.Count > 0 );
        }

        public override void draw( SpriteBatch sprite_batch, Camera eye ) {
            //Updates camera in ninja class since ninja is the focus of the camera
            //eye.Update();
            m_speed_trail.m_ninja_speed = m_speed;

            // Pick out the right frame
            int image_size = m_texture.Width / NUM_ANIM_FRAMES;
            int frame = (int)m_animation_frame;



            // Draw the ninja aura
            Vector2 origin = new Vector2( TestWorld.highlight_texture.Width,
                  TestWorld.highlight_texture.Height ) / 2;

            Color aura_color = new Color( m_cruise ? 255 : 128, 255 - m_cruise_cooldown, 255, 128 );

            aura_rotation += m_speed * 0.0025f;
            sprite_batch.Draw( TestWorld.highlight_texture,
                GameWorld.SCALE * m_body.Position, null, aura_color,
                aura_rotation, origin, m_radius * 6.29f * (float)Math.Log10( m_speed * 0.0288 + 1 ), 0.0f, 1 );



            origin = new Vector2( image_size,
               m_texture.Height ) / 2;

            // Draw the ninja rectangle
            Rectangle src = new Rectangle( frame * image_size,  //get the frame to display
                                          0,                    //the image only has 1 row of frames
                                          image_size, image_size );    //image height and width

            sprite_batch.Draw( m_texture, GameWorld.SCALE * m_body.Position, src,
                             m_tint, m_body.Rotation, origin, m_radius,
                             0.0f, 0
                );
        }

        public void pick_up( GameObject throwing_item ) {
            if ( m_throwing_items.Count < m_max_throwable_capacity
                && throwing_item.m_is_throwable ) {
                GameEngine.AudioManager.Play( AudioManager.SFXSelection.pickup_sfx );
                // Thinking about adding a weight, so Ninja doesn't have to move as fast to attain speeds..
                // Something like a *POWER* factor.
                // Ninja's power factor starts off at 1
                // A small ball would have a power factor of 0.7 or something
                // Add ~half or so of ball's weight to ninja when grabbing?

                //throwing_item.m_body.CollidesWith = Category.None;
                throwing_item.m_body.LinearDamping = 5;
                throwing_item.m_body.AngularVelocity = 0;
                throwing_item.m_body.Mass /= 3;
                m_throwing_items.Push( throwing_item );
                m_has_item = true;
                m_picking_up = false;


                //throwing_item.m_body.Mass *= 6;
                SliderJoint the_joint =
                    JointFactory.CreateSliderJoint( m_world.m_world,
                    m_body, throwing_item.m_body, Vector2.Zero,
                    Vector2.Zero, 0, m_radius + throwing_item.m_radius
                    );

                m_throwable_joint = the_joint;
            }
        }

        public GameObject throw_item() {
            m_picking_up = false;
            if ( m_throwing_items.Count > 0 ) {
                //m_throwable_joint = null;

                GameObject throwing_item = m_throwing_items.Pop();
                //throwing_item.m_body.CollidesWith = Category.All;
                throwing_item.m_body.AngularVelocity = 20.0f;

                return throwing_item;
            }
            return null;
        }
        #endregion
    }




}