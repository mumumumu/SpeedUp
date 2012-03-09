//==========================================================================
// speedup-SelectBox.cs  - SelectBox
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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace speedup {
    // Ball is a subclass of ThrowableObject
    public class SelectBox : GameObject {

        public Vector2 m_draw_location;
        public VertexPositionTexture[] m_vertices;
        private float _radius;
        public override float m_radius {
            get { return _radius; }
            set {
                _radius = value;
                create_vertices();
            }
        }

        public GameObject m_target { get; set; }

        #region Constructor
        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------
        // 
        internal SelectBox() {

        }
        // The Ball Constructor
        // <param name="world"> The World this object would be contained inside
        // </param>
        // <param name="texture"> The image that governs the shape of this 
        // object</param>
        // <param name="velocity"> The initial velocity upon spawning</param>
        // <param name="density"> The object's mass per unit area </param>
        // <param name="friction"> Usually set to 0 for throwable objects, 
        // but sliding factor </param>
        // <param name="restitution"> Bounciness </param>
        public SelectBox( GameWorld world, Texture2D texture,
            Vector2 position, float radius, String name = "Ball", String texturename = TNames.tile, GameObject target = null )
            : base( world, texture, 0, 0,
            0,
            radius: radius,
            name: name, texture_name: texturename ) {

            m_buffered_position = Vector2.Zero;
            m_draw_location = position;
            m_tint = new Color( 255, 255, 255, 150 );
            m_texture = TestWorld.floor_texture;
            m_radius = radius;

            m_target = target;

        }
        /* public SelectBox(GameWorld world, Texture2D texture, GameObject obj)
         {
            
         }*/
        #endregion
        #region Methods

        // Physics body does not affect draw location. 
        protected override Body create_physics() {
            // create the box from our superclass
            Body bod = base.create_physics();

            bod.IsSensor = true;
            bod.Awake = false;
            return bod;
        }

        public void create_vertices() {
            Vector2[] directions = new[] { new Vector2( 1, 1 ), new Vector2( -1, 1 ), new Vector2( -1, -1 ), new Vector2( -1, -1 ), new Vector2( 1, -1 ), new Vector2( 1, 1 ) };
            m_vertices = new VertexPositionTexture[6];
            for ( int i = 0; i < 6; i++ ) {
                Vector3 v = new Vector3( directions[i] * m_radius * 3, 0 );

                // Generate texture coordinate around the center of the texture
                Vector2 t = GameWorld.SCALE * directions[i] * m_radius / new Vector2( 500, 500 );

                m_vertices[i] = new VertexPositionTexture( v, t );

            }

        }


        // Uses the PolygonObject Draw
        public override void draw( SpriteBatch sprite_batch, Camera eye ) {

            var drawer = GameScreen.m_polygon_drawer;
            //drawer.drawPolygons( GameWorld.SCALE * m_draw_location, 0, GameWorld.SCALE, m_texture,
            //                    m_vertices,
            //                    BlendState.AlphaBlend, eye );
        }

        public override void update( GameWorld world, float time_step ) {
            if ( m_target != null ) {
                m_draw_location = m_target.m_position;
            }
            base.update( world, time_step );

        }
        #endregion
    }

}
