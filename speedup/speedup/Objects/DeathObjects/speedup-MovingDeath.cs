//==========================================================================
// speedup-MovingDeath.cs  
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
using FarseerPhysics.Dynamics.Joints;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;

namespace speedup {


    //Creates an object that kills the player upon contact

    public class MovingDeath : DeathTouch {

        #region Member Variables
        //--------------------------------------------------------------------
        // Member Variables
        //--------------------------------------------------------------------
        //Series of Parameters that define the Object
        // Current position defined at the center
        // Might not need this due to the use of using the body position
        // private float m_facing_angle;

        [ContentSerializer]
        public Boolean returning;

        [ContentSerializer]
        public Vector2 direction;

        [ContentSerializer]
        public Vector2 starting_pos;

        [ContentSerializer]
        public float distance;

        [ContentSerializer( Optional = true )]
        public bool active = true;

        #endregion
        #region Constructor
        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------
        //
        internal MovingDeath() {

        }
        // The DeathTouch Constructor
        //
        // <param name="world"> The World this object would be contained inside </param>
        // <param name="texture"> The image that governs the shape of this object</param>
        // <param name="velocity"> The initial velocity from throwing</param>
        // <param name="density"> The object's mass per unit area </param>
        // <param name="friction"> Usually set to 0 for throwable objects, but sliding factor </param>
        // <param name="restitution"> Bounciness </param>
        public MovingDeath( GameWorld world, Texture2D texture,
            Vector2 position, float radius, Vector2 movedistance, float speed, String texturename = TNames.ball, bool starting = true, int density = 0 )
            : base( world, texture, position, radius, texturename: texturename, dense: density ) {
            returning = false;
            distance = movedistance.Length();
            movedistance.Normalize();
            direction = movedistance * speed;
            starting_pos = position;
            active = starting;
        }


        public MovingDeath( GameWorld world, Texture2D texture,
    Vector2 position, Vector2 size, Vector2 movedistance, float speed, String texturename = TNames.ball, bool starting = true )
            : base( world, texture, position, size, texturename: texturename ) {
            returning = false;
            distance = movedistance.Length();
            movedistance.Normalize();
            direction = movedistance * speed;
            starting_pos = position;
            active = starting;
        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------
        public override void update( GameWorld world, float time_step ) {
            if ( active ) {

                float dist = ( m_body.Position - starting_pos ).Length();


                // Decide on the direction to travel
                if ( dist <= 0 ) returning = false;
                else if ( dist >= distance ) returning = true;

                //Travel in the direction decided
                if ( returning ) {
                    m_body.Position -= direction;
                }
                else {
                    m_body.Position += direction;
                }

                base.update( world, time_step );
            }

        }

        #endregion
    }

}
