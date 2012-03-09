//========================================================================
// speedup-PhotonTrailQueue.cs : contains code for speed trail of the Ninja
//      Based off PhotonQueue code in ShipDemo lab
//========================================================================
//
// Author: Wen Hao Lui

using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace speedup {

    // The class for managing our collection of Photons.
    public class PhotonTrailQueue {
        #region Structures
        //----------------------------------------------------------------
        // Structs
        //----------------------------------------------------------------
        public struct Photon {
            public Vector2 pos;   // Photon position.
            public int age;      // Photon age (for decay).
            public byte color_speed; // speed of ninja when photon was created
        }
        #endregion
        #region Constants
        //----------------------------------------------------------------
        // Constants
        //----------------------------------------------------------------
        //
        // Constants:  maximum age and number of photons
        public const int MAX_AGE = 30;
        public const int MAX_PHOTONS = 100;
        // Constant: photon image size; depends on image file.
        public const int PHOTON_SIZE = 60;


        #endregion
        #region Member Variables
        //----------------------------------------------------------------
        // Member Variables
        //----------------------------------------------------------------
        //
        // Array implementation of a circular queue.
        [ContentSerializer( SharedResource = true )]
        protected Photon[] m_queue;

        [ContentSerializer]
        protected int m_head;

        [ContentSerializer]
        protected int m_tail;

        [ContentSerializer]
        protected int m_size;
        // The geometric bounds of the system.
        public Rectangle m_bounds {
            get;
            set;
        }
        public float m_ninja_speed {
            get;
            set;
        }
        // Image representing a single photon.  Static since all photons are same.
        public static Texture2D m_texture = GameScreen.GAME_CONTENT.Load<Texture2D>( TNames.trail );
        // Predeclared Vector2 objects for drawing.
        private Vector2 m_position;
        private Vector2 m_origin;

        // A struct that represents a single Photon.  
        // Think of it as a Java inner class.
        // We use structs as they are simple and have low overhead.
        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        //
        // Constructs a new PhotonSet 
        internal PhotonTrailQueue() {

        }
        public PhotonTrailQueue( Texture2D texture, Vector2 position ) {
            m_texture = texture;
            // Construct the queue.
            m_queue = new Photon[MAX_PHOTONS];
            m_head = 0;
            m_tail = -1;
            m_size = 0;

            // "Predeclare" all the photons.
            for ( int ii = 0; ii < MAX_PHOTONS; ii++ ) {
                m_queue[ii] = new Photon();
            }

            // These variables are used in Draw.
            m_position = position;
            m_origin = new Vector2( 0.0f, 0.0f );
        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------
        //
        // Loads the texture information for the photons.
        // All photo queues use the same image, so this is a
        // static method.  This keeps us from loading the 
        // image multiple times for more than one PhotonQueue.
        //
        // Adds a photon to the list of particles.
        public void add_photon( Vector2 pos, float speed ) {
            // Check if any room in queue.  
            // If maximum is reached, remove the oldest photon.
            if ( m_size == MAX_PHOTONS ) {
                m_head = ( ( m_head + 1 ) % MAX_PHOTONS );
                m_size--;
            }

            // Add a new photon at the end.
            // Already declared, so just initialize.
            m_tail = ( ( m_tail + 1 ) % MAX_PHOTONS );
            m_queue[m_tail].pos = pos;
            m_queue[m_tail].age = Math.Max( MAX_AGE - (int)( speed * 2 ), 0 );
            m_queue[m_tail].color_speed = (byte)MathHelper.Clamp( 255 - speed * 10, 0, 255 );

            m_size++;
        }

        // Moves all the photons in the particle system.
        // The Photons are implemented as a very simple physics engine 
        // for a particle system.  Each particle is advanced according 
        // to its velocity. Particles out of bounds are rebounded into 
        // view.  Particles which are too old are deleted.

        public void update( Vector2 pos, float speed ) {
            //Add a new photon at the ninja position, if suitable

            if ( speed >= 0.3 ) {

                // fill the gap between the last two ninja positions with photons, spaced evenly across the distance
                Vector2 diff = m_position - pos;
                Vector2 inc = Vector2.Normalize( diff ) * m_texture.Width / GameWorld.SCALE / 2.2f;

                float mult = (float)Math.Floor( diff.Length() / inc.Length() );
                inc = diff / mult;

                m_position = pos;

                for ( int i = 0; i < mult; i++ ) {
                    add_photon( pos + inc * i, speed );

                }

            }



            // Delete all old photons.  
            // INVARIANT: Photons are in queue in decending age order.
            // That means we just remove the head until the photons are young enough.
            while ( m_size > 0 && m_queue[m_head].age > MAX_AGE ) {
                // As photons are predeclared, all we have to do is move head forward.
                m_head = ( ( m_head + 1 ) % MAX_PHOTONS );
                m_size--;
            }

            // Now, step through each active photon in the queue.
            for ( int ii = 0; ii < m_size; ii++ ) {
                // Find the position of this photon.
                int idx = ( ( m_head + ii ) % MAX_PHOTONS );

                // Finally, advance the age of the photon.
                if ( m_queue[idx].age < MAX_AGE )
                    m_queue[idx].age++;
            }
        }

        /**
         * Draws the collection of photons to the given graphics context
         * (SpriteBatch).  Note that all objects have been predeclared
         * and are reused.
         */
        public void draw( SpriteBatch sprite_batch, Camera eye ) {


            Vector2 origin = new Vector2( 0.3f * PHOTON_SIZE );

            // Now, step through each active photon in the queue.
            for ( int ii = 0; ii < m_size; ii++ ) {
                // Find the position of this photon.
                int idx = ( ( m_head + ii ) % MAX_PHOTONS );

                // How big to make the photon.  Decreases with age.
                float scale = 2.0f - (float)m_queue[idx].age / (float)MAX_AGE;


                // How much to rotate the image
                float rotate = 0.0f;

                int R = 0;
                int G = 0;
                int B = 0; ;
                if ( m_ninja_speed < 50 ) {
                    // Color of the photon
                    R = 150;
                    G = 255;
                }
                else if ( m_ninja_speed < 100 ) {
                    R = 255;
                    G = 127;
                }
                else if ( m_ninja_speed >= 100 ) {
                    R = 255;
                }

                //m_queue[idx].color_speed
                Color tint = new Color( R, G,
                      B, (byte)MathHelper.Clamp( ( 1 - m_queue[idx].age /
                      (float)MAX_AGE ) * 255f, 0, 255 ) );
                // Use this information to draw.
                // The last 0 instructs this to draw on top (not underneath)
                sprite_batch.Draw( m_texture, m_queue[idx].pos *
                    GameWorld.SCALE, null, tint, rotate, origin,
                    scale, SpriteEffects.None, 0 );
            }

        }
        #endregion
    }
}
