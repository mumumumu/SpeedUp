using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace speedup {
    public class LevelManager {

        public List<FileInfo> levels;
        public int current_level;
        public String background_texture;
        public readonly string HighScoresFilename = "highscores.lst";
        public HighScoreData high_scores;
        [Serializable]
        public struct HighScoreData {
            public int[] Score;
            public int Level;

            public HighScoreData( int level ) {
                Score = new int[level];
                Level = level;
            }
        }

        public LevelManager() {

            levels = new List<FileInfo>();
            DirectoryInfo dir = new DirectoryInfo( Directory.GetCurrentDirectory() + "/Levels" );
            Console.WriteLine( Directory.GetCurrentDirectory() + "/Levels" );
            try {
                levels.AddRange( dir.GetFiles( "Level*.*" ) );
            }
            catch {
                Console.WriteLine( "ERROR LOADING LEVELS" );
            }
            current_level = 0;
            foreach ( FileInfo name in levels ) {
                Console.WriteLine( name.Name );
                current_level++;
            }

            string fullpath = Path.Combine( Directory.GetCurrentDirectory(), HighScoresFilename );
            if ( !File.Exists( fullpath ) ) {
                //If the file doesn't exist, make a fake one...
                // Create the data to save
                HighScoreData data = new HighScoreData( current_level );
                for ( int i = 0; i < current_level; i++ )
                    data.Score[i] = 0;

                SaveHighScores( data, HighScoresFilename );
            }
            else {
                high_scores = LoadHighScores( HighScoresFilename );
            }
            current_level = 0;
        }

        public void next_level()
        {
            current_level++;
            if ( current_level >= levels.Count )
                current_level = -1;
        }

        public void previous_level()
        {
            current_level--;
            if ( current_level < 0 )
                current_level = levels.Count - 1;
        }

        public String get_current_level()
        {
            if ( current_level == -1 )
            {
                return "end";
            }
            else
            {
                return Directory.GetCurrentDirectory() + "/Levels/" + levels[current_level].Name;
            }
        }

        public void reload_scores() {
            high_scores = LoadHighScores( HighScoresFilename );
        }

        public int get_current_high_score() {
            try{ 
                return high_scores.Score[current_level];
            }catch{
                return 0;
            }
        }

        public void song_select() {
            switch ( current_level ) {
                case 0:
                    GameEngine.AudioManager.Play( AudioManager.MusicSelection.level1 );
                    break;
                case 1:
                    GameEngine.AudioManager.Play( AudioManager.MusicSelection.level1 );
                    break;
                case 2:
                    GameEngine.AudioManager.Play( AudioManager.MusicSelection.level1 );
                    break;
                case 3:
                    GameEngine.AudioManager.Play( AudioManager.MusicSelection.level1 );
                    break;
                case 4:
                    GameEngine.AudioManager.Play( AudioManager.MusicSelection.ninjawarrior );
                    break;
                case 5:
                    GameEngine.AudioManager.Play( AudioManager.MusicSelection.ninjawarrior );
                    break;
                default:
                    GameEngine.AudioManager.Play( AudioManager.MusicSelection.ninjawarrior );
                    break;
            }
        }

        public void background_select() {
            switch ( current_level ) {
                case 0:
                    background_texture = "Art/speedup-Background";
                    break;
                case 1:
                    background_texture = "Art/speedup-Background";
                    break;
                case 2:
                    background_texture = "Art/speedup-GoldGroundbackground";
                    break;
                case 3:
                    background_texture = "Art/speedup-GoldGroundbackground";
                    break;
                case 4:
                    background_texture = "Art/speedup-IceClouds";
                    break;
                case 5:
                    background_texture = "Art/experimentalbackground";
                    break;
                default:
                    background_texture = "Art/speedup-Background";
                    break;
            }
        }

        public float timer_select() {
            switch ( current_level ) {
                case 0:
                    return 480f;    // Tutorial
                case 1:
                    return 240f;    // Bowling!
                case 2:
                    return 180f;     // Basement
                case 3:
                    return 240f;    // "Old Tutorial"
                case 4:
                    return 240f;    // Main Floor
                case 5:
                    return 480f;    // Maze!
                case 6:
                    return 320f;    // Escape!
                default:
                    return 240f;
            }
        }

        public static void SaveHighScores( HighScoreData data, string filename ) {
            // Get the path of the save game
            string fullpath = Path.Combine( Directory.GetCurrentDirectory(), filename );

            // Open the file, creating it if necessary
            FileStream stream = File.Open( fullpath, FileMode.OpenOrCreate );
            try {
                // Convert the object to XML data and put it in the stream
                XmlSerializer serializer = new XmlSerializer( typeof( HighScoreData ) );
                serializer.Serialize( stream, data );
            }
            finally {
                // Close the file
                stream.Close();
            }
        }

        public static HighScoreData LoadHighScores( string filename ) {
            HighScoreData data;

            // Get the path of the save game
            string fullpath = Path.Combine( Directory.GetCurrentDirectory(), filename );

            // Open the file
            FileStream stream = File.Open( fullpath, FileMode.OpenOrCreate,
            FileAccess.Read );
            try {
                // Read the data from the file
                XmlSerializer serializer = new XmlSerializer( typeof( HighScoreData ) );
                data = (HighScoreData)serializer.Deserialize( stream );
            }
            finally {
                // Close the file
                stream.Close();
            }

            return ( data );
        }

        public void SaveHighScore( int score ) {
            // Create the data to save
            HighScoreData data = LoadHighScores( HighScoresFilename );

            if ( score > data.Score[current_level] ) {
                data.Score[current_level] = score;
            }
            SaveHighScores( data, HighScoresFilename );
        }
    }
}
