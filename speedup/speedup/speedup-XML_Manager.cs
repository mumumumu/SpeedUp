using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using speedup;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.IO;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization;
using Microsoft.Xna.Framework;
using FarseerPhysics.Dynamics;

namespace speedup {
    //Note: For now, things are saved in bin/x86/Debug.
    internal class XML_Manager {
        private ContentProcessorContext context;
        public void save_walls( Vector2[][] polygon ) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using ( XmlWriter writer = XmlWriter.Create( "superduper.xml", settings ) ) {

                IntermediateSerializer.Serialize( writer, polygon, null );

            }

        }

        public void save_Ninja( Ninja ninja ) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using ( XmlWriter writer = XmlWriter.Create( "ninja.xml", settings ) ) {


                IntermediateSerializer.Serialize( writer, ninja, null );


            }

        }
        public Ninja load_ninja() {

            using ( XmlReader reader = XmlReader.Create( "ninja.xml" ) ) {
                Ninja new_ninja = IntermediateSerializer.Deserialize<Ninja>( reader, "ninja.xml" );

                return new_ninja;

            }

        }
        public void save_Body( Body body ) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using ( XmlWriter writer = XmlWriter.Create( "body.xml", settings ) ) {
                IntermediateSerializer.Serialize( writer, body, null );

            }

        }
        public Body load_body() {

            using ( XmlReader reader = XmlReader.Create( "body.xml" ) ) {

                Body new_body = IntermediateSerializer.Deserialize<Body>( reader, "body.xml" );

                return new_body;

            }

        }


        //saves a game object
        //All of the data will be under body and its userdata if it has a body
        public void save_game_object( GameObject obj, String filename ) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;


            using ( XmlWriter writer = XmlWriter.Create( filename, settings ) ) {
                IntermediateSerializer.Serialize( writer, obj, null );
            }
        }

        public void save_resource_list( SharedResourceList objects, String filename ) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using ( XmlWriter writer = XmlWriter.Create( filename, settings ) ) {


                IntermediateSerializer.Serialize( writer, objects, null );


            }
        }
        public SharedResourceList load_resource_list( String filename ) {
            using ( XmlReader reader = XmlReader.Create( filename ) ) {
                SharedResourceList new_list = IntermediateSerializer.Deserialize<SharedResourceList>( reader, filename );

                return new_list;

            }
        }
        public SharedResourceLinkedList<GameObject> load_resource_linked_list( String filename ) {
            using ( XmlReader reader = XmlReader.Create( filename ) ) {
                SharedResourceLinkedList<GameObject> new_list = IntermediateSerializer.Deserialize<SharedResourceLinkedList<GameObject>>( reader, filename );

                return new_list;

            }
        }
        //loads a game object
        //The plan is to have whatever specific object = (typeof(object))gameobject.m_body.UserData
        public GameObject load_game_object( String filename ) {
            using ( XmlReader reader = XmlReader.Create( filename ) ) {
                GameObject new_obj = IntermediateSerializer.Deserialize<GameObject>( reader, filename );

                return new_obj;

            }
        }

        public void save_resource_linked_list( SharedResourceLinkedList<GameObject> objects, String filename ) {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

            using ( XmlWriter writer = XmlWriter.Create( filename, settings ) ) {


                IntermediateSerializer.Serialize( writer, objects, null );


            }
        }
    }
}