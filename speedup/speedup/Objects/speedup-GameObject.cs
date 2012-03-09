//========================================================================
// speedup-GameObject.cs : Class for generic object to be used in game
//========================================================================
//
// Author: Matheus Ogleari

using System;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using System.Collections.Generic;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using FarseerPhysics.Collision;

namespace speedup {
    // A GameObject represents a body.  There should
    // be no game controlling logic code in a physics objects, that should reside
    // in controllers.
    [Serializable]
    public class GameObject {
        #region Member Variables
        //----------------------------------------------------------------
        // Member Variables
        //----------------------------------------------------------------
        //
        // The physics world of this object
        [ContentSerializerIgnore]
        public GameWorld m_world {
            get;
            set;
        }

        [ContentSerializer( Optional = true )]
        public float m_density {
            get;
            set;
        }      // Density defines the mass per volume

        [ContentSerializer( Optional = true )]
        public float m_mass { get; set; }


        [ContentSerializer( Optional = true )]
        public float m_friction {
            get;
            set;
        }      // Sliding factor observed along surfaces

        [ContentSerializer( Optional = true )]
        public float m_restitution {
            get;
            set;
        }   // range [0,1] decides 'bounciness.' Higher at 1

        [ContentSerializerIgnore]
        public float change_restitution {
            get { return m_restitution; }
            set {
                m_restitution = value;
                if ( m_body != null ) {
                    m_body.Restitution = value;
                }
            }
        }
        [ContentSerializer( Optional = true )]
        public virtual float m_rotation {
            get;
            set;
        }

        [ContentSerializer( Optional = true )]
        public float m_damping {
            get;
            set;
        }

        [ContentSerializer( Optional = true )]
        public virtual float m_radius {
            get;
            set;
        }

        [ContentSerializerIgnore]
        public float m_change_size {
            get {
                return m_radius;
            }
            set {
                m_radius = value;
                if ( m_body != null ) {
                    //m_body.FixtureList[0].Shape.Radius = value;

                    m_body.DestroyFixture( m_body.FixtureList[0] );
                    FixtureFactory.AttachCircle( m_radius, m_density, m_body );
                    m_body.Mass = m_mass;
                    m_body.Restitution = m_restitution;
                }


            }
        }

        [ContentSerializerIgnore]
        public float m_change_mass {
            get { return m_mass; }
            set {
                m_mass = value;

                m_body.Mass = value;

            }
        }




        [ContentSerializer( Optional = true )]
        public Vector2 m_width_height;

        [ContentSerializer( Optional = true )]
        public Vector2 m_linear_velocity {
            get;
            set;
        }

        [ContentSerializer( Optional = true )]
        public float m_angular_velocity {
            get;
            set;
        }

        [ContentSerializer( Optional = true )]
        public Vector2 m_position {
            get;
            set;
        }


        [ContentSerializerIgnore]
        public int m_cooloff {
            get;
            set;
        }

        // Used for quick traversal in serialization
        [ContentSerializer( Optional = true )]
        public String m_name {
            get;
            set;
        }
        [ContentSerializerIgnore]
        public Texture2D m_texture      // The texture for this object
        {
            get;
            set;
        }
        // If our object has been flagged for destruction
        [ContentSerializer( Optional = true )]
        public bool m_is_dead {
            get;
            set;
        }
        // If our object has been added to the physics world
        [ContentSerializer( Optional = true )]
        private bool m_is_added {
            get;
            set;
        }
        [ContentSerializerIgnore]
        public Body m_body          // This object's body, if we have one.
        {
            get;
            set;
        }
        //Spawn position
        [ContentSerializer( Optional = true )]
        public Vector2? m_buffered_position {
            get;
            set;
        }
        //spawn angle
        [ContentSerializer( Optional = true )]
        public float? m_buffered_angle {
            get;
            set;
        }
        [ContentSerializer( Optional = true )]
        public Vector2? m_buffered_linear_velocity {
            get;
            set;
        }
        [ContentSerializer( Optional = true )]
        public bool m_is_throwable {
            get;
            set;
        }
        [ContentSerializer( Optional = true )]
        public bool m_is_destructible {
            get;
            set;
        }
        [ContentSerializer( Optional = true )]
        public float m_destroy_threshold {
            get;
            set;
        }

        [ContentSerializer( Optional = true )]
        public bool m_last_destroy_frame {
            get;
            set;
        }

        //Here for adjustable colors
        [ContentSerializer( Optional = true )]
        public Color m_tint = Color.FloralWhite;

        [ContentSerializerIgnore]
        public Color color_change {
            get {
                return m_tint;
            }
            set {
                m_tint.R = value.R;
                m_tint.G = value.G;
                m_tint.B = value.B;
                m_tint.A = value.A;
            }
        }
        [ContentSerializer( Optional = true )]
        public String m_texture_name {
            get;
            set;
        }
        [ContentSerializer( Optional = true )]
        public String m_texture_name_helper {
            get {
                return m_texture_name;
            }
            set {

                if ( Statics.fname_to_texture.ContainsKey( value ) ) {
                    m_texture = Statics.fname_to_texture[value];
                    m_texture_name = value;
                }
                else {
                    if ( m_texture == null ) {
                        m_texture = GameScreen.GAME_CONTENT.Load<Texture2D>( value );
                        Statics.fname_to_texture.Add( value, m_texture );
                        m_texture_name = value;
                    }


                }
            }
        }


        //Purely for the level editor
        [ContentSerializerIgnore]
        public String m_texture_name_change {
            get {
                return m_texture_name;
            }
            set {
                m_texture_name = value;

                //Change size according to texture
                float original_area = m_texture.Width * m_texture.Height;

                if ( Statics.fname_to_texture.ContainsKey( value ) ) {
                    m_texture = Statics.fname_to_texture[value];
                }
                else {
                    m_texture = GameScreen.GAME_CONTENT.Load<Texture2D>( value );
                    Statics.fname_to_texture.Add( value, m_texture );


                }
                //Change size according to texture
                float new_area = m_texture.Width * m_texture.Height;

                //Resize the radius. m_radius only affects the draw scale
                m_change_size *= (float)( original_area / new_area );

            }
        }


        [ContentSerializer(Optional = true)]
        public bool m_disabled { get; set; }


        #endregion
        #region Constructors
        //----------------------------------------------------------------
        // Constructors
        //----------------------------------------------------------------
        //
        public GameObject( float density = 1.0f, float friction = 0, float restitution = 0.7f,
            float damping = 0, float radius = 0, bool is_throwable = false,
            bool is_destructible = false, float destroy_threshold = 0.0f,
            String name = "GameObject", String texture_name = "empty_constructor" ) {
            m_name = name;
            if ( !String.Equals( texture_name, "empty_constructor" ) ) {
                m_texture_name_helper = texture_name;
            }
            //AABB aabb = new AABB(); 
            //aabb.UpperBound = new Vector2(GameEngine.GAME_WIDTH,GameEngine.GAME_HEIGHT);
            //aabb.LowerBound = new Vector2(-GameEngine.GAME_WIDTH,-GameEngine.GAME_HEIGHT);
            //m_world = GameWorld.the_world; 

        }
        public GameObject( GameWorld world, Texture2D texture,
            float density = 1.0f, float friction = 0, float restitution = 0.7f,
            float damping = 0, float radius = 0, bool is_throwable = false,
            bool is_destructible = false, float destroy_threshold = 0.0f,
            float rotation = 0.0f, String name = "GameObject",
            String texture_name = "default" ) {
            m_rotation = rotation;
            m_world = world;
            m_density = density;
            m_friction = friction;
            m_restitution = restitution;
            m_damping = damping;
            m_name = name;
            m_is_throwable = is_throwable;
            m_radius = radius;
            m_is_destructible = is_destructible;
            m_destroy_threshold = destroy_threshold;
            m_is_dead = false;
            m_is_added = false;
            m_buffered_angle = null;
            m_buffered_position = null;
            m_buffered_linear_velocity = null;
            if ( !Statics.object_name_list.Contains( m_name ) ) {
                Statics.object_name_list.Add( m_name );
            }


            if ( m_texture == null && ( String.Equals( texture_name, "default" ) || texture_name == null ) ) {
                m_texture_name_helper = TNames.ball;
            }
            else {
                m_texture_name_helper = texture_name;
            }

        }

        public GameObject( GameWorld world, Texture2D texture, Vector2 position,
            float density = 1.0f, float friction = 0, float restitution = 0.7f,
            float damping = 0, float radius = 0, bool is_throwable = false,
            bool is_destructible = false, float destroy_threshold = 0.0f,
            float rotation = 0.0f, String name = "GameObject",
            String texture_name = "default" ) {
            m_rotation = rotation;
            m_world = world;
            m_density = density;
            m_friction = friction;
            m_restitution = restitution;
            m_buffered_position = position;
            m_texture = texture;
            m_damping = damping;
            m_name = name;
            m_is_throwable = is_throwable;
            m_radius = radius;
            m_is_destructible = is_destructible;
            m_destroy_threshold = destroy_threshold;
            m_is_dead = false;
            m_is_added = false;
            m_buffered_angle = null;
            m_buffered_linear_velocity = null;
            if ( !Statics.object_name_list.Contains( m_name ) ) {
                Statics.object_name_list.Add( m_name );
            }


            if ( m_texture == null && ( String.Equals( texture_name, "default" ) || texture_name == null ) ) {
                m_texture_name_helper = TNames.ball;
            }
            else {
                m_texture_name_helper = texture_name;
            }
        }

        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------

        // draws the physics object.  Default just calls draw in the children.
        public virtual void draw( SpriteBatch sprite_batch, Camera eye ) {
            var origin = new Vector2( m_texture.Width, m_texture.Height ) / 2;
            if ( m_radius != 0 ) {
                sprite_batch.Draw( m_texture, GameWorld.SCALE * m_body.Position, null,
                m_tint, m_body.Rotation, origin, m_radius, 0.0f, 0 );
            }


            if ( m_is_throwable && m_world.m_ninja.m_picking_up && !m_world.m_ninja.throwable_objects.Contains( this )
                && m_world.m_ninja.m_max_throwable_capacity > m_world.m_ninja.throwable_objects.Count ) {
                float dist = Vector2.Distance( m_position, m_world.m_ninja.m_position );
                float combined_radius = ( m_change_size + m_world.m_ninja.m_radius );

                Color m_throwable_aura = Color.DarkGray;


                if ( dist < 5 * combined_radius ) {
                    m_throwable_aura = Color.Gold;

                }
                else if ( dist < 15 * combined_radius ) {
                    m_throwable_aura = new Color( 255, 215, 150, 50 );

                }


                draw_throwable_aura( sprite_batch, eye, m_throwable_aura );
            }

        }

        public void draw_throwable_aura( SpriteBatch sprite_batch, Camera eye, Color aura_color ) {

            var origin = new Vector2( TestWorld.highlight_texture.Width,
                TestWorld.highlight_texture.Height ) / 2;

            sprite_batch.Draw( TestWorld.highlight_texture,
                GameWorld.SCALE * m_body.Position, null,
                aura_color,
                m_body.Rotation, origin, 0.7f * m_radius
               , 0.0f, 1 );



        }

        // Updates the object's game logic.  By default this does nothing, just calls the 
        // method on the children.
        public virtual void update( GameWorld world, float time_step ) {
            if ( !m_body.Enabled ) {
                if ( m_last_destroy_frame ) {
                    destroy();
                }
            }
            if ( m_cooloff > 0 ) {
                m_body.CollidesWith = Category.None;
                m_cooloff--;

                if ( m_cooloff == 0 ) {
                    m_body.CollidesWith = Category.All;
                }
            }
            if ( m_body != null && m_body.Enabled ) {
                m_position = m_body.Position;
                m_linear_velocity = m_body.LinearVelocity;
                m_angular_velocity = m_body.AngularVelocity;
                m_buffered_position = m_position;
                m_buffered_angle = m_body.Rotation;
                m_rotation = m_body.Rotation;
                m_mass = m_body.Mass;
                m_restitution = m_body.Restitution;

                if ( m_is_throwable && m_world.m_ninja.m_picking_up
                    && m_world.m_ninja.m_max_throwable_capacity > m_world.m_ninja.throwable_objects.Count ) {
                    if ( Vector2.Distance( m_position, m_world.m_ninja.m_position ) <
                     5 * ( m_change_size + m_world.m_ninja.m_radius )
                     && !m_world.m_ninja.throwable_objects.Contains( this ) ) {
                        Path path = new Path( new Vector2[] { m_position, m_world.m_ninja.m_position } );
                        PathManager.MoveBodyOnPath( path, m_body, 1,
                                                   0.01f * Math.Min( 50, Math.Max( 11, m_world.m_ninja.m_speed + m_body.LinearVelocity.Length() / 2 ) ), time_step, if_type2: false );
                    }


                }

            }
        }

        public void update_spawn() {
            m_buffered_position = m_position;
        }

        // Flags this object for death or destruction
        public void destroy() {
            m_is_dead = true;
        }

        // Calls the physics creation method of this body and all it's children.  Also
        // populates the buffered position + angle if applicable.
        public virtual void add_to_world() {
            //Resets body
            m_body = null;

            m_body = create_physics();

            if ( m_body != null ) {
                m_body.UserData = this;
                if ( m_buffered_position.HasValue ) m_body.Position = m_buffered_position.Value;
                if ( m_buffered_angle.HasValue ) m_body.Rotation = m_buffered_angle.Value;
                if ( m_buffered_linear_velocity.HasValue ) m_body.LinearVelocity = m_buffered_linear_velocity.Value;
            }

            m_is_added = true;
        }

        // Removes all of this body's physics and joints, along with it's children
        public virtual void remove_from_world() {
            destroy_physics();
        }

        // Creates the physics of this object.
        protected virtual Body create_physics() {

            Body new_body = BodyFactory.CreateCircle( m_world.m_world, m_radius,
                m_density );
            new_body.Restitution = m_restitution;
            new_body.Friction = m_friction;
            new_body.LinearDamping = m_damping;
            new_body.Rotation = m_rotation;
            if ( m_density != 0f ) {
                new_body.BodyType = BodyType.Dynamic;
                new_body.IsBullet = true;
                new_body.Awake = false;
            }
            if ( m_mass != 0 ) {
                new_body.Mass = m_mass;
            }
            return new_body;
        }

        // Destroys the body of this object if it exists.
        public virtual void destroy_physics() {
            if ( m_body != null && m_body.Enabled ) {
                m_body.Dispose();
                //m_body = null;


                m_body.Awake = false;
                m_body.Enabled = false;
                m_body.CollidesWith = Category.None;
                m_body.FixtureList.Clear();
            }
        }

        public float get_weight() {
            if ( this is Ninja || m_is_throwable ) {
                return (float)Math.Log( m_body.LinearVelocity.Length() + 1 + 1000 * m_body.Mass );
            }

            //return (float)Math.Log(m_body.Mass*10 + 1f);
            return 0.05f;
        }

        public void draw_destroyable( SpriteBatch sprite_batch, Camera eye ) {
            if ( m_is_destructible && m_world.m_ninja.m_speed > m_destroy_threshold ) {

                var origin = new Vector2( TestWorld.highlight_texture.Width,
                    TestWorld.highlight_texture.Height ) / 2;

                sprite_batch.Draw( TestWorld.highlight_texture,
                    GameWorld.SCALE * m_body.Position, null,
                    Color.Lerp( m_tint, new Color( 0, 255, 0, 1 ), 0.9f ),
                    m_body.Rotation, origin, 0.7f * m_width_height / 5 *
                    Math.Max( 1.2f, Math.Min( 1.8f, m_world.m_ninja.m_speed / m_destroy_threshold ) ), 0.0f, 1 );

            }

        }

        #endregion
    }
}