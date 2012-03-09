//========================================================================
// speedup-Timer.cs : The in-game timer for level completion
//========================================================================

using System;
using Microsoft.Xna.Framework;

namespace speedup {
    public class Timer {
        #region Member Variables
        //----------------------------------------------------------------
        // Member Variables
        //----------------------------------------------------------------

        public float m_end_count { get; private set; }        // Final count value for timer
        public string m_display_value   // The value currently being displayed
        {
            get;
            private set;
        }
        public bool m_is_active      // Whether or not timer is active
        {
            get;
            private set;
        }
        public bool m_is_complete    // Whether or not timer is complete
        {
            get;
            private set;
        }
        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        //
        // Sets the default value of the timers

        public Timer() {
            m_is_active = false;
            m_is_complete = false;
            m_display_value = "None";
            m_end_count = 0;
        }
        #endregion
        #region Public Methods
        //----------------------------------------------------------------
        // Public Methods
        //----------------------------------------------------------------

        // Sets the current timer to display the indicated time
        public void set( float seconds ) {
            m_end_count = seconds;
            m_is_active = true;
            m_display_value = m_end_count.ToString();
        }

        // Checks the current value at the timer
        public Boolean check_timer( GameTime gameTime ) {
            if ( !m_is_complete ) {
                m_end_count -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                try {
                    m_display_value = m_end_count > 100 ?
                    m_end_count.ToString().Substring( 0, 3 ) : m_end_count.ToString().Substring( 0, 4 );
                }
                catch ( ArgumentOutOfRangeException ) {
                    m_display_value = m_end_count.ToString().Substring( 0, 2 );
                }
                if ( m_end_count < 0 ) {
                    // End count finished, timer count complete
                    m_end_count = 0;
                    m_is_complete = true;
                }
            }
            else {
                m_display_value = "000";
            }
            return m_is_complete;
        }

        // Adds the indicated amount of time to the timer
        public void add_time( int time ) {
            m_end_count += time;
        }

        // Resets the current timer
        public void reset() {
            m_is_active = false;
            m_is_complete = false;
            m_display_value = "None";
            m_end_count = 0;
        }
        #endregion
    }
}