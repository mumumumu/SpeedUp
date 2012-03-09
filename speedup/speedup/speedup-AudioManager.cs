using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;

namespace speedup {
    public class AudioManager {

        #region Enums
        //This is an enum that speeds up coding and reduces errors.
        //Specifying SFX by enum takes advantage of Intellisense and reduces 
        //the chance of a spelling mistake.
        public enum SFXSelection {
            VictoryTrumpets,
            throw_sfx,
            door_activate,
            pickup_sfx,
            alien_death,
            laser,
            point_count,
            menu_select,
            /*AlienDeathSFX,
			PlayerDeathSFX,
			ThrowSFX(Hadoken),
			PickUpSFX,
			WallBreakSFX,
			SonicBoomSFX*/
        }

        //This is an enum that speeds up coding and reduces errors.
        //Specifying songs by enum takes advantage of Intellisense and reduces 
        //the chance of a spelling mistake.
        public enum MusicSelection {
            triumph,
            tut,
            creepy,
            ninjawarrior,
            loading_sound,
            last_stretch,
            level1,
            boss2,
            boss1
            /*TitleSong,
			LevelSong*/
        }
        #endregion
        #region Member Variables
        private Dictionary<MusicSelection, Song> songs;
        private Dictionary<SFXSelection, SoundEffect> soundEffects;
        private float SFXVolume;     //Value between 0.0 and 1.0.
        #endregion
        #region Constructor
        public AudioManager() {
            //Initializes the dictionaries.
            soundEffects = new Dictionary<SFXSelection, SoundEffect>();
            songs = new Dictionary<MusicSelection, Song>();
            SFXVolume = 0.5f;
            MediaPlayer.Volume = 0.2f;

            //Make MediaPlayer repeat all songs that it plays.
            MediaPlayer.IsRepeating = true;
        }


        #endregion
        #region Methods
        public void LoadContent( ContentManager content ) {
            //Uses relative pathfiles from your project (i.e. your mp3 files 
            //should be located in the Music folder for this demo).

            //Music
            songs.Add( MusicSelection.triumph, content.Load<Song>( "Music/triumph" ) );
            songs.Add( MusicSelection.tut, content.Load<Song>( "Music/tut" ) );
            songs.Add( MusicSelection.creepy, content.Load<Song>( "Music/creepy" ) );
            songs.Add( MusicSelection.ninjawarrior, content.Load<Song>( "Music/ninjawarrior" ) );
            songs.Add( MusicSelection.loading_sound, content.Load<Song>( "Music/loading_sound" ) );
            songs.Add( MusicSelection.last_stretch, content.Load<Song>( "Music/last_stretch" ) );
            songs.Add( MusicSelection.level1, content.Load<Song>( "Music/level1" ) );
            songs.Add( MusicSelection.boss2, content.Load<Song>( "Music/epic_boss" ) );
            songs.Add( MusicSelection.boss1, content.Load<Song>( "Music/boss_mode" ) );

            //Sound Effects
            try {
                soundEffects.Add( SFXSelection.VictoryTrumpets, content.Load<SoundEffect>( "SFX/VictoryTrumpets" ) );
                soundEffects.Add( SFXSelection.throw_sfx, content.Load<SoundEffect>( "SFX/throw" ) );
                soundEffects.Add( SFXSelection.door_activate, content.Load<SoundEffect>( "SFX/door_activate" ) );
                soundEffects.Add( SFXSelection.pickup_sfx, content.Load<SoundEffect>( "SFX/pickup" ) );
                soundEffects.Add( SFXSelection.alien_death, content.Load<SoundEffect>( "SFX/alien_death_effect" ) );
                soundEffects.Add( SFXSelection.menu_select, content.Load<SoundEffect>( "SFX/menu_select_sfx" ) );
                soundEffects.Add( SFXSelection.point_count, content.Load<SoundEffect>( "SFX/point_count_sfx" ) );
                soundEffects.Add( SFXSelection.laser, content.Load<SoundEffect>( "SFX/laser_sfx" ) );
            }
            catch {
                Console.WriteLine( "No speakers detected. Disabling sound effects" );
            }

            /*NOTE: This sound effect file is not included initially in the correct directory.
                    We want you to move this file to the correct location. If you do not do so, and uncomment the above line you will get
                    an error.  Make sure you add VictoryTrumpets.mp3 file to the SFX directory in the Content folder.
                    Once you add the file, make sure you right click it in the solution explorer (on the right hand side of 
                    your screen) and select properties.  Under the "Content Processor" field select "SoundEffect - XNA Framework"
                    Not doing this second step will result in XNA treating you SoundEffect as a song, which causes an error.
             */
        }


        //Plays music.  This should be done through using the MediaPlayer static class.
        /* It also stops the previous song if it was playing or paused.
         *
         * You typically don't want multiple songs to be playing at once, so make
         * sure to stop the previous song.
         *
         * Trying to play a song already playing may crash your game.
         * 
         */

        public void Play( MusicSelection selection ) {
            this.Stop();
            Song song;
            if ( songs.TryGetValue( selection, out song ) ) {
                try { MediaPlayer.Play( song ); }
                catch {
                    Console.WriteLine( "No speakers installed, not playing" );
                }
            }
            else {
                Console.WriteLine( "Could not find song: " + selection.ToString() );
            }

        }

        //Plays a sound effect.  I have done this one for you.
        public void Play( SFXSelection selection ) {
            /* Because you typically want to be able to play a sound effect again
             * before the first sound ends (i.e. gunfire, footsteps), 
             * and you typically won't need to pause or stop them, you probably
             * want to just call sound.Play() as this allows multiple
             * instances of a sound effect to play at the same time with no consequences.
             * 
             * Relatively straightforward, but you need to know the name of the sfx when called.
             * I've done this one for you.
             */

            SoundEffect sfx;
            if ( soundEffects.TryGetValue( selection, out sfx ) ) {
                SoundEffectInstance sound = sfx.CreateInstance();
                sound.Volume = SFXVolume;
                sound.Play();
            }
            else {
                Console.WriteLine( "Could not find sound effect: " + selection.ToString() );
            }
        }


        //This function will pause the currently playing song, and resume it if it is playing.
        //Be sure to check that it is valid to try and pause/resume the song at a given time.
        public void Pause() {
            if ( MediaPlayer.State.Equals( MediaState.Playing ) ) {
                MediaPlayer.Pause();
            }
            else if ( MediaPlayer.State.Equals( MediaState.Paused ) ) {
                MediaPlayer.Resume();
            }

        }

        //Stops the song. Be sure to check that it is valid to stop the song here.
        public void Stop() {
            if ( MediaPlayer.State.Equals( MediaState.Playing ) || MediaPlayer.State.Equals( MediaState.Paused ) ) {
                MediaPlayer.Stop();
            }
        }

        //Make sure volume does not go above 1.0.  Hint: Look at MathHelper.Clamp for a quick function to use.
        public void IncreaseSFXVolume( float increment ) {
            SFXVolume = MathHelper.Clamp( SFXVolume += increment, 0.0f, 1.0f );
            Play( SFXSelection.menu_select );
        }

        //Make sure volume does not go below 0.0.
        public void DecreaseSFXVolume( float decrement ) {
            SFXVolume = MathHelper.Clamp( SFXVolume -= decrement, 0.0f, 1.0f );
            Play( SFXSelection.menu_select );
        }

        //Make sure volume does not go above 1.0.  
        public void IncreaseMusicVolume( float increment ) {
            MathHelper.Clamp( MediaPlayer.Volume += increment, 0.0f, 1.0f );
        }

        //Make sure volume does not go below 0.0.  
        public void DecreaseMusicVolume( float decrement ) {
            MathHelper.Clamp( MediaPlayer.Volume -= decrement, 0.0f, 1.0f );
        }

        public void MuteToggle() {
            if ( MediaPlayer.Volume == 0 )
                MediaPlayer.Volume = .5f;
            else
                MediaPlayer.Volume = 0;
        }

        public float getSFXVolume() {
            return SFXVolume;
        }

        public float getMusicVolume() {
            return MediaPlayer.Volume;
        }

        public MediaState getMediaPlayerState() {
            return MediaPlayer.State;
        }

        protected void Update( GameTime gameTime ) {
            //Nothing to update.
        }

        protected void Draw( GameTime gameTime ) {
            //Nothing to draw..
        }
        #endregion
    }
}
