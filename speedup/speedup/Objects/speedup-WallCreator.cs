//==========================================================================
// speedup-WallCreator.cs  
//========================================================================

// Author: Sanford Johnson

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace speedup {
    class WallCreator {
        //--------------------------------------------------------------------
        // Member variables
        //--------------------------------------------------------------------





        //Create a Wall Line using 2 points, and adds it to the game world
        //Make texture null if you want to just use the default texture
        /// <summary>
        /// 
        /// </summary>
        /// <param name="use_gameworld"></param>
        /// <param name="top_left_point">top left point of wall</param>
        /// <param name="x_offset">how far right top right point is</param>
        /// <param name="y_offset">how far up top right point is</param>
        /// <param name="use_texture">texture used</param>
        /// <param name="thickness">thickness of the wall</param>
        /// <param name="use_density">density of the wall (force required to move, intertia)</param>
        /// <param name="use_friction">friction of the wall</param>
        /// <param name="use_restitution">restitution (bounciness) of the wall</param>
        public static void create_wall_line( GameWorld use_gameworld, Texture2D use_texture, Vector2 top_left_point, float x_right_offset, float y_up_offset, float thickness,
                                     float use_density = 1, float use_friction = 0, float use_restitution = 0.7f,
                                        bool if_breakable = false, float speed_required_to_break = 30 ) {

            Vector2 thickness_vector = new Vector2( 0, thickness );
            Vector2 top_right_point = top_left_point + new Vector2( x_right_offset, -y_up_offset );
            Vector2[] vertices = new Vector2[]
                                     {
                                         top_left_point, top_right_point,
                                         top_right_point + thickness_vector, 
                                         top_left_point + thickness_vector
                                     };





            use_gameworld.add_queued_object( new PolygonObject( use_gameworld, vertices, use_texture,
                                             use_density, use_friction, use_restitution ) );

        }
        public static void create_quad_shape( GameWorld use_gameworld, Texture2D use_texture,
                                        Vector2 top_left_point, Vector2 top_right_point, Vector2 bottom_right_point, Vector2 bottom_left_point,
                                     float use_density = 1, float use_friction = 0, float use_restitution = 0.7f,
                                        bool if_breakable = false, float speed_required_to_break = 30 ) {


            Vector2[] vertices = new Vector2[]
                                     {
                                         top_left_point, top_right_point,
                                         bottom_right_point, 
                                         bottom_left_point
                                     };





            use_gameworld.add_queued_object( new PolygonObject( use_gameworld, vertices, use_texture,
                                             use_density, use_friction, use_restitution ) );

        }
    }
}
