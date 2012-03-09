using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace speedup {
    public class Trigger : GameObject {
        #region Enum
        //--------------------------------------------------------------------
        // Enum
        //--------------------------------------------------------------------
        public enum TriggerType {
            WALL,
            FLOOR,
            NO_COLLISION
        }
        #endregion
        #region Static Constants
        //--------------------------------------------------------------------
        // Static Constants
        //--------------------------------------------------------------------	
        public const float WIDTH = .5f;
        public const float HEIGHT = .05f;
        public const float RADIUS = .2f;
        public const float DENSITY = .05f;
        #endregion
        #region Member Variables
        //--------------------------------------------------------------------
        // Member Variables
        //--------------------------------------------------------------------
        [ContentSerializerIgnore]
        public Texture2D m_active_texture;
        [ContentSerializerIgnore]
        public Texture2D m_inactive_texture;

        [ContentSerializer( SharedResource = true )]
        public SharedResourceList<TriggerableObject> m_attached_to { get; set; }

        [ContentSerializer]
        public float m_cooldown { get; set; }

        //does not need to be serialized
        [ContentSerializerIgnore]
        public float m_cooldown_timer { get; set; }

        [ContentSerializer]
        public bool m_deactivated { get; set; }

        [ContentSerializer]
        public bool m_active { get; set; }

        [ContentSerializer( Optional = true )]
        public bool m_continuous_check { get; set; }

        public TriggerType m_type { get; set; }

        [ContentSerializer( Optional = true )]
        public float m_size_scale { get; set; }

        [ContentSerializer( Optional = true )]
        public bool m_if_deactivator { get; set; }

        [ContentSerializerIgnore]
        public TriggerType m_change_type {
            get { return m_type; }
            set {
                m_type = value;
                m_body.FixtureList[0].Dispose();
                m_body.FixtureList[0] = ( m_type == TriggerType.WALL || m_type == TriggerType.NO_COLLISION ) ?
                FixtureFactory.AttachEllipse( WIDTH, HEIGHT, 7, DENSITY, m_body ) :
                FixtureFactory.AttachCircle( RADIUS, DENSITY, m_body );
                if ( m_type == TriggerType.FLOOR || m_type == TriggerType.NO_COLLISION )
                    m_body.IsSensor = true;
                else {
                    m_body.IsSensor = false;
                }

            }
        }

        [ContentSerializerIgnore]
        public int num_triggerable_objects {
            get {
                if ( m_attached_to != null ) {
                    return m_attached_to.Count;
                }
                else return 0;
            }
        }

        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        internal Trigger() {

        }
        public Trigger( GameWorld world, Texture2D active_texture,
            Texture2D inactive_texture, Vector2 position,
            TriggerableObject triggered_object, TriggerType type,
            float cooldown, float rotation, String name = "Trigger",
            String texture_name = TNames.ground_switch_animate, SharedResourceList<TriggerableObject> t_obj_list = null,
            float scale = 1, float density = DENSITY )
            : base( world, inactive_texture, position, name: name, texture_name: texture_name, density: density ) {
            m_texture_name = texture_name;
            m_texture_name_helper = texture_name;
            m_active_texture = active_texture;
            m_inactive_texture = inactive_texture;
            m_buffered_position = position;
            m_size_scale = scale;
            m_radius = m_size_scale * ( m_texture.Width ) / ( GameWorld.SCALE * 2 );
            if ( t_obj_list == null ) {
                m_attached_to = new SharedResourceList<TriggerableObject>( world );
            }
            else {
                m_attached_to = t_obj_list;
            }
            if ( triggered_object != null ) {
                m_attached_to.Add( triggered_object );
            }
            m_type = type;
            m_cooldown = cooldown * 60;
            m_cooldown_timer = 0;
            m_deactivated = false;
            m_active = false;
            m_rotation = rotation;
            //m_radius = 0.2f * 5;
        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Public Methods
        //----------------------------------------------------------------
        public virtual void activate() {
            foreach ( TriggerableObject trig in m_attached_to ) {
                if ( !m_if_deactivator ) {
                    trig.activate();
                }

                else {
                    trig.deactivate();
                }

            }
            m_active = true;

        }

        public virtual void deactivate() {
            m_deactivated = true;
            m_cooldown_timer = m_cooldown;

        }

        public virtual bool can_be_activated_by( GameObject obj ) {
            return ( obj is Ninja &&
                ( m_type == TriggerType.FLOOR || m_type == TriggerType.WALL ) )
                || ( obj.m_is_throwable && m_type == TriggerType.WALL );
        }

        protected override Body create_physics() {
            if ( m_size_scale == 0 ) {
                m_size_scale = 0.2f;
                m_radius = m_size_scale * m_texture.Width / ( GameWorld.SCALE * 2 );
            }
            var new_body = ( m_type == TriggerType.WALL || m_type == TriggerType.NO_COLLISION ) ?
                BodyFactory.CreateEllipse( m_world.m_world, m_radius, m_radius / 10, 7, m_density ) :
                BodyFactory.CreateCircle( m_world.m_world, m_radius, m_density );
            if ( m_type == TriggerType.FLOOR || m_type == TriggerType.NO_COLLISION )
                new_body.IsSensor = true;
            else {
                new_body.IsSensor = false;
            }
            new_body.BodyType = BodyType.Kinematic;
            new_body.Rotation = m_rotation;


            //m_attached_to.update_body(m_world);
            return new_body;

        }

        [ContentSerializerIgnore]
        public float m_change_size {
            get { return m_size_scale; }
            set {
                m_radius /= m_size_scale;

                m_size_scale = value;

                m_radius *= m_size_scale;

                if ( m_body != null ) {
                    //m_body.FixtureList[0].Shape.Radius = value;
                    m_body.DestroyFixture( m_body.FixtureList[0] );

                    if ( this.m_type != TriggerType.WALL ) {
                        FixtureFactory.AttachCircle( m_radius, m_density, m_body );
                        m_body.IsSensor = true;
                    }
                    else {
                        FixtureFactory.AttachEllipse( m_radius, m_radius / 10, 7, m_density, m_body );
                    }
                }

            }
        }

        public override void update( GameWorld world, float time_step ) {
            base.update( world, time_step );
            if ( m_continuous_check ) {
                if ( m_active ) {
                    activate();
                }
                else {
                    m_deactivated = false;
                    m_active = false;
                    foreach ( TriggerableObject trig in m_attached_to ) {
                        if ( !m_if_deactivator ) {
                            trig.deactivate();
                        }

                        else {
                            trig.activate();
                        }
                    }
                }
            }
            if ( ( m_deactivated ) && m_cooldown_timer >= 0 && m_cooldown > 0 ) {
                // Console.WriteLine(m_cooldown_timer);
                if ( m_cooldown_timer == 0 ) {
                    m_deactivated = false;
                    m_active = false;
                    foreach ( TriggerableObject trig in m_attached_to ) {
                        if ( !m_if_deactivator ) {
                            trig.deactivate();
                        }

                        else {
                            trig.activate();
                        }
                    }
                    m_cooldown_timer = m_cooldown;
                }
                else {
                    m_cooldown_timer--;
                }
            }
        }

        public override void draw( SpriteBatch sprite_batch, Camera eye ) {

            // Pick out the right frame
            int image_size = m_texture.Width / 2;

            int frame = m_active ? 1 : 0;


            var origin = new Vector2( image_size, m_texture.Height ) / 2;

            // Draw the switch rectangle
            Rectangle src = new Rectangle( frame * image_size,  //get the frame to display
                                          0,                    //the image only has 1 row of frames
                                          image_size, m_texture.Height );    //image height and width

            sprite_batch.Draw( m_texture, GameWorld.SCALE * m_body.Position, src,
                             m_tint, m_body.Rotation, origin, m_size_scale,
                             0.0f, 0
                );

        }
        #endregion
    }
}
