//==========================================================================
// speedup-CameraController.cs  
//========================================================================

// Author: Sanford Johnson
//Credit for framework of this class:
// http://adambruenderman.wordpress.com/2011/04/05/create-a-2d-camera-in-xna-gs-4-0/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FarseerPhysics.Dynamics;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics.Contacts;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace speedup {
    public class CameraController {
        #region Member Variables
        //--------------------------------------------------------------------
        // Member variables
        //--------------------------------------------------------------------
        // 
        // I am just going to put a bunch of things I learn online, both 3D and 2D.
        private Camera m_camera;
        private Vector2 m_target_position;
        private float m_zoom_upperbound;
        private float m_zoom_lowerbound;
        #endregion
        #region Constructor
        //--------------------------------------------------------------------
        // Member variables
        //--------------------------------------------------------------------
        public CameraController( Camera camera, Vector2 target_position ) {
            m_camera = camera;
        }
        #endregion
    }
}
