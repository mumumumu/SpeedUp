//==========================================================================
// speedup-BackgroundMaker.cs  
//========================================================================

// Author: Sanford Johnson


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



    public class BackgroundTile : GameObject {

        #region Member Variables
        //--------------------------------------------------------------------
        // Member Variables
        //--------------------------------------------------------------------
        //Series of Parameters that define the Object
        // Current position defined at the center
        // Might not need this due to the use of using the body position
        // private float m_facing_angle;

        [ContentSerializer]
        public Vector2 m_size { get; set; }

        [ContentSerializer]
        public Vector2 m_scale { get; set; }


        #endregion
        #region Constructor
        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------
        //
        internal BackgroundTile() {

        }

        //A constructor for background tiles
        public BackgroundTile( GameWorld world, Texture2D texture,
         Vector2 position, Vector2 size, String name = "background_tile", String texturename = TNames.ground )
            : base( world, texture, 0, 0,
            0,
            name: name, texture_name: texturename, radius: 1 ) {
            m_buffered_position = position;
            m_size = size;
            m_scale = Vector2.One; //new Vector2(size.X / texture.Width, size.Y / texture.Height) * GameWorld.SCALE;
            m_tint = Color.White;

        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------
        protected override Body create_physics() {

            Body the_body = BodyFactory.CreateRectangle( m_world.m_world,
            m_size.X, m_size.Y, m_rotation );
            the_body.IsSensor = true;
            return the_body;

        }

        public override void draw( SpriteBatch sprite_batch, Camera eye ) {
            var origin = new Vector2( m_texture.Width, m_texture.Height ) / 2;

            sprite_batch.Draw( m_texture, GameWorld.SCALE *
                m_body.Position, null, m_tint,
                m_body.Rotation, origin, m_scale * 7, 0.0f, 0 );

        }

        #endregion
    }

}
