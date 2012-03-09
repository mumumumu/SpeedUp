//==========================================================================
// speedup-FloorTile.cs  
//========================================================================
//
// Author: Wen Hao Lui


using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Controllers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace speedup {

    // Tiles the floor with a specified texture
    public class FloorTile : PolygonObject {

        #region Member Variables
        //----------------------------------------------------------------
        // Member Variables
        //----------------------------------------------------------------
        //
        // drawable vertices

        #endregion


        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        // Creates a new polygon object.
        // Uses a divide-and-conquer algorithm
        // to triangulate the polygon, since triangles
        // are guaranteed to be convex, a Box2D
        // requirement.  Colinear consecutive points
        // are okay, but the polygon must be simple -
        // i.e. no crossing edges.
        public FloorTile( GameWorld world, Vector2[] points, Texture2D texture,
            float density = 0.1f, float friction = 0.1f, float restitution = 0.0f, String name = TNames.tile )
            : base( world, points, texture, density, friction, restitution, density, "FloorTile", name ) {
            m_is_destructible = false;
        }

        #endregion

        internal FloorTile() {
        }

        protected override Body create_physics() {

            m_body = base.create_physics();
            m_body.IsSensor = true;
            m_body.Awake = false;
            return m_body;
        }
    }
}