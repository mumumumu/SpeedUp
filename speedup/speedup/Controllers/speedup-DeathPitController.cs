//========================================================================
// speedup-DeathPitController.cs : contains code for the pit of doom
//========================================================================
//
// Author: Wen Hao Lui

using System;
using System.Collections.Generic;
using System.Linq;
using FarseerPhysics.Controllers;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace speedup {

    public class DeathPitController : Controller {
        #region Member Variables
        //----------------------------------------------------------------
        // Member Variables
        //----------------------------------------------------------------


        public SharedResourceList[] pit_list = new[] {
            new SharedResourceList(),new SharedResourceList(),new SharedResourceList(),new SharedResourceList()
        };

        public int MAX_COOLDOWN;
        public int m_cooldown;
        public int pit_counter = 0;

        private readonly GameWorld m_world;

        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        //
        // Constructs a Controller for the given Pit and World
        public DeathPitController( GameWorld world, int cooldown )
            : base( ControllerType.DeathPitController ) {
            m_world = world;
            MAX_COOLDOWN = cooldown;
        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------
        public override void Update( float time_step ) {
            if ( pit_list.Any( pitsublist => pitsublist.Any
                ( pit => GameScreen.within_screen_bounds( pit.m_position ) ) )
                && !GameScreen.m_halted ) {
                if ( m_cooldown <= 0 ) {
                    foreach ( DeathTouch pit in pit_list[pit_counter] ) {
                        pit.activate();
                    }

                    foreach ( DeathTouch pit in pit_list[( pit_counter + 3 ) % 4] ) {
                        pit.m_tint = Color.Gray;
                    }


                    int nextcount = ( pit_counter + 2 ) % 4;

                    foreach ( DeathTouch pit in pit_list[nextcount] ) {
                        pit.deactivate();
                    }


                    pit_counter = ( pit_counter + 3 ) % 4;
                    m_cooldown = MAX_COOLDOWN;
                }
                else m_cooldown--;
            }

        }

        public void addPit( DeathTouch pit ) {
            if ( pit.m_pit_num >= 0 )
                pit_list[pit.m_pit_num].Add( pit );
        }

        #endregion
    }
}