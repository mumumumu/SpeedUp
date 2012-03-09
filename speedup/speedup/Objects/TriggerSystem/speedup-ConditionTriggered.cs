using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace speedup {

    public class ConditionTriggered : Trigger {
        public enum ConditionType {
            DEATH,
            NINJA_HAS_ITEM,
            EVADE_ALIENS
        }
        [ContentSerializer( SharedResource = true )]
        public SharedResourceList trigger_list;

        public ConditionType m_condition_type { get; set; }

        [ContentSerializerIgnore]
        public bool m_all_true { get; private set; }

        [ContentSerializerIgnore]
        public int num_cond_objects {
            get {
                if ( trigger_list == null ) {
                    return 0;

                }
                else {
                    return trigger_list.Count;
                }
            }
        }

        internal ConditionTriggered() {

        }

        public ConditionTriggered( GameWorld world, Texture2D texture,
            Vector2 pos, float rotation, SharedResourceList triglist, String name = "ConditionTrigger",
            String texture_name = TNames.ground_switch_inactive, float cooldown = -1,
            SharedResourceList<TriggerableObject> t_objects = null,
            ConditionType c_type = ConditionType.DEATH ) // Needs to change this
            : base( world, texture, texture, pos, null, TriggerType.NO_COLLISION, cooldown,
                 rotation, texture_name: texture_name, t_obj_list: t_objects ) {
            m_condition_type = c_type;
            if ( trigger_list != null ) {
                trigger_list = triglist;
            }
            else {
                trigger_list = new SharedResourceList( m_world );
            }

        }

        public override void update( GameWorld world, float time_step ) {
            base.update( world, time_step );
            //WOAH linq expressions are really useful
            bool all_true = true;

            //Check Conditions
            if ( m_condition_type == ConditionType.DEATH ) {
                all_true = trigger_list.All( go => go.m_is_dead );
            }

            else if ( m_condition_type == ConditionType.NINJA_HAS_ITEM &&
                trigger_list.OfType<Ninja>().Any( nin => nin.throwable_objects.Count == 0 ) ) {
                all_true = false;
            }

            else if ( m_condition_type == ConditionType.EVADE_ALIENS ) {
                all_true = trigger_list.OfType<Alien>().All(
                alien => alien.m_ai_state == AlienController.State.PATROLLING
                      || alien.m_ai_state == AlienController.State.SPAWNING
                      || alien.m_is_dead );
            }


            m_all_true = all_true;



            if ( all_true ) {

                activate();
                m_cooldown_timer = m_cooldown;
            }
            else {
                if ( m_active && m_cooldown_timer >= 0 && m_cooldown > 0 ) {
                    // Console.WriteLine(m_cooldown_timer);
                    if ( m_cooldown_timer == 0 ) {
                        m_deactivated = false;
                        m_active = false;
                        foreach ( TriggerableObject trig in m_attached_to ) {
                            trig.deactivate();
                        }
                        m_cooldown_timer = m_cooldown;
                    }
                    else {
                        m_cooldown_timer--;
                    }
                }
            }
        }


        public override void draw( SpriteBatch sprite_batch, Camera eye ) {
            if ( GameScreen.editor_mode ) {
                base.draw( sprite_batch, eye );
            }
        }

    }
}
