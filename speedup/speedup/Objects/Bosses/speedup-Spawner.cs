//==========================================================================
// speedup-Spawner.cs  
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


namespace speedup
{
    public class Spawner : Alien
    {
        public const int DEFAULT_MAX_SPAWN = 5;
        [ContentSerializer( Optional = true )]
        public int max_cool;
        [ContentSerializer( Optional = true )]
        public int m_cooldown;

        [ContentSerializerIgnore]
        public List<Alien> spawn = new List<Alien>();

        [ContentSerializer( Optional = true )]
        public int m_max_spawn
        {
            get;
            set;
        }

        #region Constructor
        //--------------------------------------------------------------------
        // Constructor
        //--------------------------------------------------------------------

        internal Spawner()
        {
            if ( m_max_spawn == 0 )
            {
                m_max_spawn = DEFAULT_MAX_SPAWN;
            }
        }

        public Spawner( GameWorld world, Texture2D texture, Vector2 position, float size,
            AlienType type, int cooldown, String texturename = TNames.easy_alien, int max_spawn = DEFAULT_MAX_SPAWN, AlienController.AIType ai = AlienController.AIType.PATROL, float patrol = 0.05f )
            : base( world, texture, position, size, type, ai: ai, patrol_speed: patrol )
        {

            m_texture_name = texturename;
            max_cool = cooldown;
            m_cooldown = cooldown;
            m_alien_color = Color.Red;
            m_max_spawn = max_spawn;
        }

        #endregion

        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------


        public override void update( GameWorld world, float time_step )
        {
            if ( !GameScreen.m_halted )
            {
                Queue<Alien> to_remove = new Queue<Alien>();
                foreach ( Alien alien in spawn )
                {
                    to_remove.Enqueue( alien );
                }
                while ( to_remove.Count > 0 )
                {
                    spawn.Remove( to_remove.Dequeue() );
                }
                if ( m_cooldown <= 0 && m_body.Enabled && spawn.Count < m_max_spawn )
                {
                    spawn_alien();
                }
                else m_cooldown--;


                base.update( world, time_step );
            }

        }

        public virtual void spawn_alien()
        {
            if ( !m_disabled )
            {
                if ( m_body.Mass < 0.5 )
                {
                    m_body.Mass = 0.8f;
                }
                Alien alien = new Alien( m_world, TestWorld.easy_alien_texture, m_body.Position, .5f,
                                        Alien.AlienType.CHASER,
                                        chase_dist: m_chase_dist, patrol_speed: 0.05f, ai: AlienController.AIType.CHASER );
                alien.m_range = m_range;
                alien.m_move_step = m_move_step;

                alien.m_destroy_threshold = m_destroy_threshold / 1.5f;
                alien.m_kill_under_speed = m_kill_under_speed;
                alien.m_alien_color = m_alien_color;

                alien.m_mass = m_body.Mass;

                //alien.m_alien_color = m_alien_color;
                //alien.m_alien_color_alpha_change = 140;

                m_world.add_queued_object( alien );
                spawn.Add( alien );


                m_cooldown = max_cool;
            }
        }


        public override void set_textures()
        {
            base.set_textures();
            m_texture_name_change = m_texture_name;
            m_texture_name = m_texture_name;
        }


        #endregion


    }

}