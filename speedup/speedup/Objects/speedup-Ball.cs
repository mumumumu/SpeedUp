//==========================================================================
// speedup-Ball.cs  - A simple Ball
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
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace speedup {
    // Ball is a subclass of ThrowableObject
    public class Ball : GameObject {
        #region Constants
        //--------------------------------------------------------------------
        // Constants
        //--------------------------------------------------------------------
        //
        public const float BALL_COLLISION_WEIGHT = 0.75f;
        // Max age of the ball
        public const int BALL_MAX_AGE = 100;
        // Scale for the draw Size  
        public const float BALL_SIZE_SCALE = 0.3f;
        // Force needed to get the Ball moving
        public const float BALL_FORCE = 30.0f * BALL_SIZE_SCALE *
            GameWorld.OBJECT_SCALE;
        // How hard the brakes are applied to decellerate
        public const float BALL_DAMPING = 0.1f * BALL_SIZE_SCALE *
            GameWorld.OBJECT_SCALE;
        // Upper limit on movement
        public const float BALL_MAXSPEED = 200.0f * BALL_SIZE_SCALE *
            GameWorld.OBJECT_SCALE;
        // Upper limit on Rotation
        public const float BALL_MAXROTATE_SPEED = 10.0f * BALL_SIZE_SCALE *
            GameWorld.OBJECT_SCALE;
        // Ball spawning coefficients
        // Ball's starting density
        public const float BALL_DENSITY = 0.2f * BALL_SIZE_SCALE *
            GameWorld.OBJECT_SCALE;
        // Ball's bounciness factor
        public const float BALL_RESTITUTION = 0.5f;
        // Ball's Friction
        public const float BALL_FRICTION = 0.0f;
        #endregion
        #region Constructor
        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------
        // 
        internal Ball() {

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
        public Ball( GameWorld world, Texture2D texture,
            Vector2 position, float radius, String name = "Ball", String texturename = TNames.ball )
            : base( world, texture, BALL_DENSITY, BALL_FRICTION,
            BALL_RESTITUTION, damping: BALL_DAMPING,
            radius: radius * BALL_SIZE_SCALE * GameWorld.OBJECT_SCALE,
            name: name, is_throwable: true, texture_name: texturename ) {
            m_buffered_position = position;
        }
        #endregion
        #region Methods
        // Creates the physics for the ball
        // Just uses the standard base physics
        protected override Body create_physics() {
            // create the box from our superclass
            var bod = base.create_physics();

            //box.FixedRotation = true;

            return bod;
        }

        // draws the ball
        // Uses the standard Throwable Object draw
        public override void draw( SpriteBatch sprite_batch, Camera eye ) {
            base.draw( sprite_batch, eye );
        }
        #endregion
    }

}
