//==========================================================================
// speedup-TileCreator.cs  
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

namespace speedup
{



    public class TileCreator : GameObject
    {

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

        public int tile_num_x { get; set; }
        public int tile_num_y { get; set; }


        #endregion
        #region Constructor
        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------
        //
        internal TileCreator()
        {

        }

        //A constructor for background tiles
        public TileCreator(GameWorld world, Texture2D texture,
         Vector2 position, Vector2 size, String name = "background_tile", String texturename = TNames.ground
            , int tile_x = 1, int tile_y = 1)
            : base(world, texture, 0, 0,
            0,
            name: name, texture_name: texturename, radius: 1)
        {
            m_buffered_position = position;
            m_size = size;
            m_scale = Vector2.One; //new Vector2(size.X / texture.Width, size.Y / texture.Height) * GameWorld.SCALE;
            m_tint = Color.White;
            tile_num_x = tile_x;
            tile_num_y = tile_y;

        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------
        protected override Body create_physics()
        {

            Body the_body = BodyFactory.CreateRectangle(m_world.m_world,
            m_size.X, m_size.Y, m_rotation);
            the_body.IsSensor = true;
            return the_body;

        }

        public override void draw(SpriteBatch sprite_batch, Camera eye)
        {
            var origin = new Vector2(m_texture.Width, m_texture.Height) / 2;
            float width_ratio = m_texture.Width/GameWorld.SCALE;
            float height_ratio = GameWorld.SCALE/m_texture.Height;
            Vector2 draw_pos = m_body.Position;

            for(int i = 0; i<tile_num_x;i++)
            {
                draw_pos.X = m_body.Position.X + i*m_size.X*width_ratio;
                for(int j = 0; j<tile_num_y;j++)
                {
                    draw_pos.Y = m_body.Position.Y + j * m_size.Y * height_ratio;

                    draw_at_pos(sprite_batch,draw_pos);
                }
            }

        }

        public void draw_at_pos(SpriteBatch sprite_batch, Vector2 pos)
        {
            var origin = new Vector2(m_texture.Width, m_texture.Height) / 2;

            sprite_batch.Draw(m_texture, GameWorld.SCALE *
                pos, null, m_tint,
                m_body.Rotation, origin, m_scale, 0.0f, 0); 
        }

        #endregion
    }

}
