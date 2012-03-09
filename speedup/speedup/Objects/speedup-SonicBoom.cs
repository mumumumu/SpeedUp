//==========================================================================
// speedup-SonicBoom.cs  
//========================================================================
//
// Author: Wen Hao Lui


using System;
using System.Collections.Generic;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Dynamics.Joints;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace speedup {

    // Ninja is a subclass of CreatureObject, 
    // a file from the Farseer Physics Lab.
    // Ninja is directly controlled by the user, but that will be handles by the controller.
    // The Object class helps define all the variables to be used by the controller


    public class SonicBoom {
        public const int NUM_ANIM_FRAMES = 7;
        public const int COOLDOWN = 2;

        public Vector2 m_position { get; set; }

        //Goes from 1 to NUM_ANIM_FRAMES
        public int m_animation_frame {
            get;
            set;
        }
        public float m_angle { get; set; }
        private Texture2D m_texture;
        private Color m_tint;
        private bool m_active;
        private int m_cooldown;
        private Vector2 m_direction;
        private Vector2 m_ninja_vel { get; set; }




        public SonicBoom( Texture2D texture ) {
            m_texture = texture;
        }

        public void Activate( Vector2 pos, Vector2 angle, float speed ) {
            m_position = pos;
            m_active = true;
            m_animation_frame = 1;
            m_cooldown = COOLDOWN;
            m_direction = angle * speed / GameWorld.SCALE;
            m_angle = (float)( Math.Atan2( angle.Y, angle.X ) + Math.PI / 2 );
        }


        public void Update() {
            if ( m_active ) {
                m_cooldown--;
                m_position += m_direction;

                if ( m_cooldown <= 0 ) {
                    m_animation_frame++;
                    m_cooldown = COOLDOWN;
                }

                if ( m_animation_frame == 7 ) {
                    m_active = false;
                }

            }
        }

        public void Draw( SpriteBatch sprite_batch, Camera eye ) {

            if ( m_active ) {

                // Pick out the right frame
                int image_size = m_texture.Width / NUM_ANIM_FRAMES;

                Vector2 origin = new Vector2( image_size,
                    m_texture.Height ) / 2;

                // Pick the color
                m_tint = new Color( 255, 255,
                       255, (byte)MathHelper.Clamp( ( 1 - m_animation_frame / (float)NUM_ANIM_FRAMES ) * 255f, 0, 255 ) );

                // Draw the source rectangle
                Rectangle src = new Rectangle( ( m_animation_frame - 1 ) * image_size,  //get the frame to display
                                              0,                    //the image only has 1 row of frames
                                              image_size, image_size );    //image height and width

                sprite_batch.Draw( m_texture, GameWorld.SCALE * m_position, src,
                                 m_tint, m_angle, origin, 0.2f,
                                 0.0f, 0
                    );

            }

        }


    }




}