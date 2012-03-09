//========================================================================
// speedup-PowerBar.cs : Displays the Ninja's current speed
//========================================================================
//
// Author: Matheus Ogleari

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace speedup {
    public class PowerBar {
        #region Member Variables
        //----------------------------------------------------------------
        // Member Variables
        //----------------------------------------------------------------
        public Ninja m_ninja {
            get;
            set;
        }
        public Texture2D m_texture {
            get;
            set;
        }
        public Rectangle m_bar {
            get;
            private set;
        }
        public Texture2D m_bar_texture {
            get;
            set;
        }
        private float m_amount_full;
        private float m_game_width;
        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        //
        // Initializes the power bar

        public PowerBar() {
            m_amount_full = 0;
            m_bar = new Rectangle();
        }
        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Methods
        //----------------------------------------------------------------
        //
        // TODO: FINISH THIS

        public void update( GameTime time_step ) {
            if ( m_ninja != null ) {
                m_amount_full = m_ninja.m_speed / m_ninja.m_maxspeed;
                m_bar = new Rectangle( m_bar.X, m_bar.Y,
                    (int)( m_amount_full * m_bar_texture.Width ),
                    m_bar_texture.Height );
            }
        }

        #endregion
    }
}
