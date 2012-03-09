using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace speedup {
    class Statics {
        public static Dictionary<String, Texture2D> fname_to_texture = new Dictionary<string, Texture2D>();
        public static HashSet<String> object_name_list = new HashSet<string>();

        public Dictionary<String, Texture2D> texture_names { get; set; }
        public HashSet<String> object_names { get; set; }

        public Statics() {
            texture_names = fname_to_texture;
            object_names = object_name_list;
        }


        public static Texture2D get_texture( string texture_filename ) {
            if ( fname_to_texture.ContainsKey( texture_filename ) ) {
                return fname_to_texture[texture_filename];

            }
            else {
                Texture2D tex = GameScreen.GAME_CONTENT.Load<Texture2D>( texture_filename );
                fname_to_texture.Add( texture_filename, tex );
                return tex;
            }


        }

    }
}
