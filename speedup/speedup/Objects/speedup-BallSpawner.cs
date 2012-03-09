
//========================================================================
// speedup-BallSpawner.cs
//========================================================================
//
// Author: Wen Hao Lui

using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using System.Diagnostics;


namespace speedup {
    class BallSpawner : PolygonTrigger {

        #region Static Constants
        //--------------------------------------------------------------------
        // Static Constants
        //--------------------------------------------------------------------	


        #endregion
        #region Member Variables

        [ContentSerializer( Optional = true )]
        public int ball_count;

        [ContentSerializer( Optional = true )]
        public SharedResourceLinkedList<GameObject> ball_list = new SharedResourceLinkedList<GameObject>();

        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        internal BallSpawner() {

        }

        public BallSpawner( GameWorld world, Texture2D active_texture,
            Texture2D inactive_texture, Vector2[] points,
            float cooldown = 1, float rotation = 0, String name = "Trigger",
            String texture_name = TNames.ground_switch_inactive )
            : base( world, active_texture, inactive_texture, points, cooldown: 1 ) {
            ball_count = 0;


        }



        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Public Methods
        //----------------------------------------------------------------

        public override bool can_be_activated_by( GameObject obj ) {
            return obj.m_is_throwable;
        }


        public override void update( GameWorld world, float time_step ) {

            if ( m_deactivated && m_cooldown_timer == 0 && m_cooldown > 0 ) {
                Ball ball = new Ball( world, TestWorld.ball_texture, m_body.Position, 2 );
                m_world.add_queued_object( ball );
                ball_list.AddLast( ball );
            }

            base.update( world, time_step );
        }
        #endregion
    }
}
