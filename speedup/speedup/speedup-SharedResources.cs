//==========================================================================
// speedup-SharedResourceList.cs  
//========================================================================
// General template for saving a list of game Objects or anything similar
// Author: Sanford Johnson
// Credit to
// http://blogs.msdn.com/b/shawnhar/archive/2008/11/20/serializing-collections-of-shared-resources.aspx

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace speedup {

    public class SharedResourceLinkedList<T> : LinkedList<T> { }

    //List of objects to save
    public class SharedResourceList : List<GameObject> {
        //ResourceSerializer's GameWorld
        public GameWorld m_g_world {
            get;
            set;
        }

        public SharedResourceList( GameWorld g_world = null ) {
            m_g_world = g_world;
        }
    }

    //List of objects to save
    public class SharedResourceList<T> : List<T> {
        //ResourceSerializer's GameWorld
        public GameWorld m_g_world {
            get;
            set;
        }

        public SharedResourceList( GameWorld g_world = null ) {
            m_g_world = g_world;
        }
    }

    //List of objects to save
    public class SharedResourceStack : Stack<GameObject> {
        //ResourceSerializer's GameWorld
        public GameWorld m_g_world {
            get;
            set;
        }

        public SharedResourceStack( GameWorld g_world = null ) {
            m_g_world = g_world;
        }
    }



    [ContentTypeSerializer]
    class SharedResourceListSerializer : ContentTypeSerializer<SharedResourceList> {




        private HashSet<String> m_object_name_list = new HashSet<string>();
        private ContentSerializerAttribute itemFormat = new ContentSerializerAttribute() {
            ElementName = "Object"

        };

        #region saving

        //Saving
        protected override void Serialize( IntermediateWriter output,
                                          SharedResourceList resource_list,
                                          ContentSerializerAttribute format ) {
            foreach ( GameObject item in resource_list ) {

                if ( !m_object_name_list.Contains( item.m_name ) ) {
                    m_object_name_list.Add( item.m_name );
                }
                //itemFormat.ElementName = item.m_name;

                //output.WriteObject( item, itemFormat );
                output.WriteSharedResource( item, itemFormat );
            }
        }

        #endregion
        #region loading
        //Loading
        protected override SharedResourceList Deserialize( IntermediateReader input,
                                                             ContentSerializerAttribute format,
                                                             SharedResourceList existingInstance ) {
            if ( existingInstance == null )
                existingInstance = new SharedResourceList();

            //foreach ( String object_name in m_object_name_list )
            //{
            //  itemFormat.ElementName = object_name;
            while ( input.MoveToElement( itemFormat.ElementName ) ) {
                //existingInstance.Add(input.ReadObject<GameObject>( itemFormat ));
                input.ReadSharedResource( itemFormat, ( GameObject item ) => existingInstance.Add( item ) );
            }
            //  }

            return existingInstance;
        }
        #endregion


    }

    [ContentTypeSerializer]
    internal class SharedResourceStackSerializer : ContentTypeSerializer<SharedResourceStack> {




        private HashSet<String> m_object_name_list = new HashSet<string>();

        private ContentSerializerAttribute itemFormat = new ContentSerializerAttribute() {
            ElementName = "Object"

        };

        #region saving

        //Saving
        protected override void Serialize( IntermediateWriter output,
                                          SharedResourceStack resource_list,
                                          ContentSerializerAttribute format ) {
            foreach ( GameObject item in resource_list ) {

                if ( !m_object_name_list.Contains( item.m_name ) ) {
                    m_object_name_list.Add( item.m_name );
                }
                //itemFormat.ElementName = item.m_name;

                //output.WriteObject( item, itemFormat );
                output.WriteSharedResource( item, itemFormat );
            }
        }

        #endregion

        #region loading

        //Loading
        protected override SharedResourceStack Deserialize( IntermediateReader input,
                                                           ContentSerializerAttribute format,
                                                           SharedResourceStack existingInstance ) {
            if ( existingInstance == null )
                existingInstance = new SharedResourceStack();

            //foreach ( String object_name in m_object_name_list )
            //{
            //  itemFormat.ElementName = object_name;
            while ( input.MoveToElement( itemFormat.ElementName ) ) {
                //existingInstance.Add(input.ReadObject<GameObject>( itemFormat ));
                input.ReadSharedResource( itemFormat, ( GameObject item ) => existingInstance.Push( item ) );
            }
            //  }

            return existingInstance;
        }

        #endregion
    }

    //Generalized list
    [ContentTypeSerializer]
    class SharedResourceListSerializer<T> : ContentTypeSerializer<SharedResourceList<T>> {
        static ContentSerializerAttribute itemFormat = new ContentSerializerAttribute() {
            ElementName = "Item"
        };



        protected override void Serialize( IntermediateWriter output,
                                          SharedResourceList<T> value,
                                          ContentSerializerAttribute format ) {
            foreach ( T item in value ) {
                output.WriteSharedResource( item, itemFormat );
            }
        }


        protected override SharedResourceList<T> Deserialize( IntermediateReader input,
                                                             ContentSerializerAttribute format,
                                                             SharedResourceList<T> existingInstance ) {
            if ( existingInstance == null )
                existingInstance = new SharedResourceList<T>();

            while ( input.MoveToElement( itemFormat.ElementName ) ) {
                input.ReadSharedResource( itemFormat, ( T item ) => existingInstance.Add( item ) );
            }

            return existingInstance;
        }
    }

    //Generalized list
    [ContentTypeSerializer]
    class SharedResourceLinkedListSerializer<T> : ContentTypeSerializer<SharedResourceLinkedList<T>> {
        static ContentSerializerAttribute itemFormat = new ContentSerializerAttribute() {
            ElementName = "Object"
        };



        protected override void Serialize( IntermediateWriter output,
                                          SharedResourceLinkedList<T> value,
                                          ContentSerializerAttribute format ) {
            foreach ( T item in value ) {
                if ( !( item is SelectBox ) && !( item is Selector ) && !( item is Laser ) ) {
                    output.WriteSharedResource( item, itemFormat );
                }
            }
        }


        protected override SharedResourceLinkedList<T> Deserialize( IntermediateReader input,
                                                             ContentSerializerAttribute format,
                                                             SharedResourceLinkedList<T> existingInstance ) {
            if ( existingInstance == null )
                existingInstance = new SharedResourceLinkedList<T>();

            while ( input.MoveToElement( itemFormat.ElementName ) ) {
                input.ReadSharedResource( itemFormat, ( T item ) => existingInstance.AddLast( item ) );
            }

            return existingInstance;
        }
    }
}
