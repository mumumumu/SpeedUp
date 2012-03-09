//========================================================================
// speedup-TrapTrigger.cs
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
    class TrapTrigger : PolygonTrigger {

        [ContentSerializer( SharedResource = true )]
        DeathTouch death;
        [ContentSerializer( Optional = true )]
        Trap m_trap;
        [ContentSerializer( Optional = true )]
        Vector2 m_impulse;
        [ContentSerializer( Optional = true )]
        Vector2 m_spawn;
        [ContentSerializer( Optional = true )]
        float obj_radius;

        public enum Trap {
            BOULDER,
            FLAME
        }

        internal TrapTrigger() {

        }


        public TrapTrigger( GameWorld world, Texture2D active_texture,
          Texture2D inactive_texture, Vector2[] points, Vector2 spawn, Vector2 impulse, float boul_radius, TriggerableObject triggered_object = null,
          String t_name = "Trigger", Trap type = Trap.BOULDER )
            : base( world, active_texture,
          inactive_texture, points, type: TriggerType.FLOOR, cooldown: 4, name: t_name,
          texture_name: TNames.ground_switch_inactive ) {
            m_trap = type;
            m_impulse = impulse;
            m_spawn = spawn;
            obj_radius = boul_radius;
        }


        public override void activate() {

            if ( !m_active ) {
                if ( m_trap == Trap.BOULDER ) {
                    death = new DeathTouch( m_world, TestWorld.boulder_texture, m_spawn, obj_radius, "Boulder", TNames.boulder, 0.1f );
                    death.m_pit_num = -1;

                }
                else if ( m_trap == Trap.FLAME ) {
                    death = new MovingDeath( m_world, TestWorld.flame_texture, new Vector2( 97, 100 ), new Vector2( 53, 8 ), new Vector2( 0, -250 ), 0.4f, texturename: TNames.flame );
                }


                m_world.add_queued_object( death );
                m_active = true;
            }


        }

        public override void update( GameWorld world, float time_step ) {
            base.update( world, time_step );
            if ( m_cooldown_timer <= 0 && death != null && death.m_body != null ) {
                if ( m_trap == Trap.BOULDER ) {
                    death.m_body.ApplyLinearImpulse( m_impulse * death.m_body.Mass );
                }
                this.destroy();
            }
        }

    }

}

