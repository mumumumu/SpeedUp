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

namespace speedup {
    public class Selector : Ball {

        public Editor editor { get; private set; }

        internal Selector() {

        }
        public Selector( GameWorld world, Texture2D texture,
            Vector2 position, float radius, Editor edit )
            : base( world, texture,
                position, radius ) {
            editor = edit;
        }
        protected override Body create_physics() {
            // create the box from our superclass
            var bod = base.create_physics();

            //box.FixedRotation = true;
            bod.Awake = true;
            bod.IsSensor = true;

            return bod;
        }
    }


}
