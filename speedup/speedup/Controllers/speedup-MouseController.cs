//==========================================================================
// speedup-MouseController.cs  
//========================================================================

// Author: Sanford Johnson


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace speedup {
    public class MouseController {
        //--------------------------------------------------------------------
        // Member variables
        //--------------------------------------------------------------------


        public Vector2 m_center { get; set; }
        public float m_mouseX;
        public float m_mouseY;
        public int m_bounds_height;
        public int m_bounds_width;

        //Creates the mouse controller, which is just a mousestate and boundaries
        public MouseController( int bound_width, int bound_height ) {
            this.m_bounds_width = bound_width;
            this.m_bounds_height = bound_height;
        }

        public Vector2 cursor_vector( Vector2 mousepos ) {

            return Vector2.Normalize( mousepos - m_center );

        }

    }
}
