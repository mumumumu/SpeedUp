using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.Common.PolygonManipulation;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace speedup {
    class CompoundPolygonObject : GameObject {
        #region Member Variables
        //----------------------------------------------------------------
        // Member Variables
        //----------------------------------------------------------------
        //
        //origin based on the centroid
        public Vector2 m_origin { get; set; }

        public SharedResourceList<Vertices> m_vertices_list { get; set; }



        private List<VertexPositionTexture[]> m_vertices;


        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        internal CompoundPolygonObject() {


        }
        // Creates a new polygon object.
        // Creates the shape based on the texture
        public CompoundPolygonObject( GameWorld world, Texture2D texture, Vector2 position,
            float density = 0.2f, float friction = 0, float restitution = 0.7f,
            float destroy_threshold = 0.0f, String name = "CompoundPolygonObject",
            String texture_name = TNames.wall, float scaleX = 1, float scaleY = 1 )
            : base( world, texture, density, friction, restitution,
            is_destructible: ( destroy_threshold > 0 ),
            destroy_threshold: destroy_threshold, name: name, texture_name: texture_name ) {

            m_vertices = new List<VertexPositionTexture[]>();
            m_buffered_position = position;
            //Create an array to hold the data from the texture
            uint[] data = new uint[texture.Width * texture.Height];

            //Transfer the texture data to the array
            texture.GetData( data );

            //Find the vertices that makes up the outline of the shape in the texture
            Vertices textureVertices = PolygonTools.CreatePolygon( data, texture.Width, false );

            //Console.WriteLine("texturevertices are " + textureVertices);

            //The tool return vertices as they were found in the texture.
            //We need to find the real center (centroid) of the vertices for 2 reasons:

            //1. To translate the vertices so the polygon is centered around the centroid.
            Vector2 centroid = -textureVertices.GetCentroid();
            textureVertices.Translate( ref centroid );

            //2. To draw the texture the correct place.
            m_origin = -centroid;

            //We simplify the vertices found in the texture.
            textureVertices = SimplifyTools.ReduceByDistance( textureVertices, 4f );


            Vertices scaledVerts = new Vertices( textureVertices.Capacity ); //now that we have list of the texture vertices we have to format it
            //in this case I'm just  making a new list for simplicity
            for ( int i = 0; i < textureVertices.Count; i++ ) {
                //Going step by step for Clarity
                Vector2 tempVert = new Vector2(); //create the temporary variable to store the new vertice before we add it to the list

                tempVert = textureVertices[i];    //set it the vert we are currently modifying

                //the verts are currently in texture coordinates, which means the Y value is inverted
                tempVert.Y *= -1; // booyah, fixed that problem

                //right now the vertices are the size of the texture, definately not what we want.
                tempVert.X /= texture.Width;
                tempVert.Y /= texture.Height;

                tempVert.X *= scaleX;
                tempVert.Y *= scaleY;
                //units are scaled to scale

                //now we need to scale the verts up to match the FRB sprite

                //tempVert.X *= this.sprite.ScaleX * 2;
                //tempVert.Y *= this.sprite.ScaleY * 2;

                //add that sucker to the list
                scaledVerts.Add( tempVert );




            }

            //Since it is a concave polygon, we need to partition it into several smaller convex polygons
            List<Vertices> vert_list = EarclipDecomposer.ConvexPartition( scaledVerts );

            m_vertices_list = new SharedResourceList<Vertices>( m_world );

            //Transfer to serializable list
            //Console.WriteLine("vert_list is " + vert_list);
            foreach ( Vertices vert in vert_list ) {
                m_vertices_list.Add( vert );
            }

            // m_vertices_list.Add( scaledVerts );

        }
        // Creates a new polygon object.
        //This takes in an array of points
        public CompoundPolygonObject( GameWorld world, Vertices verts, Texture2D texture,
            float density = 0.2f, float friction = 0, float restitution = 0.7f,
            float destroy_threshold = 0.0f, String name = "CompoundPolygonObject",
            String texture_name = TNames.wall )
            : base( world, texture, density, friction, restitution,
            is_destructible: ( destroy_threshold > 0 ),
            destroy_threshold: destroy_threshold, name: name, texture_name: texture_name ) {
            m_vertices = new List<VertexPositionTexture[]>();


            //We simplify the vertices found in the texture.
            verts = SimplifyTools.ReduceByDistance( verts, 4f );

            //Since it is a concave polygon, we need to partition it into several smaller convex polygons
            List<Vertices> vert_list = EarclipDecomposer.ConvexPartition( verts );


            //Transfer to serializable list
            foreach ( Vertices vert in vert_list ) {
                m_vertices_list.Add( vert );
            }
        }

        #endregion

        #region Methods

        /* public override void add_to_world()
        {
            base.add_to_world();
            
            foreach(PolygonObject poly in m_polygon_object_list)
            {
                poly.add_to_world();
            }
        }*/
        /*protected override Body create_physics()
        {
            Body new_body = BodyFactory.CreateCompoundPolygon( m_world.m_world, m_vertices_list, m_density);
            new_body.Restitution = m_restitution;
            new_body.Friction = m_friction;
            new_body.LinearDamping = m_damping;
            if ( m_density != 0f )
            {
                new_body.BodyType = BodyType.Kinematic;
                new_body.IsBullet = true;
                new_body.Awake = false;
                //new_body.IsSensor = true;
            }
            return new_body;
        }   */


        protected override Body create_physics() {
            var body = BodyFactory.CreateBody( m_world.m_world, this );

            foreach ( Vertices vert in m_vertices_list ) {

                Debug.Assert( vert.ToArray().Length >= 3 );

                var polygon_l = new LinkedList<int>();
                for ( int i = 0; i < vert.ToArray().Length; i++ ) {
                    polygon_l.AddLast( i );
                }
                /*
                var polygon = new PolygonShape( new Vertices( vert ),
                                                   m_density ); 
                body.CreateFixture( polygon );              */
                // create_drawable( EarclipDecomposer.TriangulatePolygon(vert) );

                // Triangles generated
                /*List<Triangle>point_triangles = EarclipDecomposer.TriangulatePolygon(vert);
                create_drawable(point_triangles);
                foreach ( Triangle triangle in point_triangles )
                {
                     Vector2[] tri_pt_list = new Vector2[3];
                    tri_pt_list[0] = new Vector2(triangle.X[0],triangle.Y[0]);
                    tri_pt_list[1] = new Vector2( triangle.X[1], triangle.Y[1] );
                    tri_pt_list[2] = new Vector2( triangle.X[2], triangle.Y[1] );
                    var polygon = new PolygonShape( new Vertices( tri_pt_list ),
                                                   m_density );
                    body.CreateFixture( polygon );
                } */
                List<Vector2[]> m_triangles = new List<Vector2[]>();



                Split( polygon_l, vert.ToArray(), m_triangles );
                create_drawable( m_triangles );

                foreach ( Vector2[] triangle in m_triangles ) {
                    var polygon = new PolygonShape( new Vertices( triangle ),
                                                   m_density );
                    body.CreateFixture( polygon );
                }
            }
            body.Friction = m_friction;
            body.Restitution = m_restitution;
            //body.Position = m_position;
            //body.Awake = false;

            body.BodyType = BodyType.Kinematic;

            //body.Position = m_position;
            body.Rotation = m_rotation;

            return body;
        }
        public override void draw( SpriteBatch sprite_batch, Camera eye ) {

            //scale is 1 for now, need to change
            /* sprite_batch.Draw( m_texture, GameWorld.SCALE * m_body.Position,
                                            null, Color.White, m_rotation, m_origin, 1f, SpriteEffects.None, 0 ); */

            var drawer = GameScreen.m_polygon_drawer;
            foreach ( VertexPositionTexture[] the_vert in m_vertices ) {
                //drawer.drawPolygons( GameWorld.SCALE * m_body.Position, m_body.Rotation, GameWorld.SCALE, TestWorld.wall_texture,
                //                    the_vert,
                //                    BlendState.AlphaBlend, eye );
            }

        }
        public void Split( LinkedList<int> polygon, Vector2[] points, List<Vector2[]> triangles ) {
            // It's a triangle - make it and terminate recursion
            if ( polygon.Count == 3 ) {
                Vector2[] v = new Vector2[3];
                v[0] = points[polygon.First.Value];
                v[1] = points[polygon.First.Next.Value];
                v[2] = points[polygon.First.Next.Next.Value];
                triangles.Add( v );
                return;
            }

            float smallestColinearity = float.MaxValue; // Colinearity measure for best diagonal
            LinkedListNode<int> diag1 = null; // Points in the diagonal
            LinkedListNode<int> diag2 = null;

            // Look at all diagonals in the polygon
            for ( LinkedListNode<int> i1 = polygon.First; i1.Next != null; i1 = i1.Next ) {
                Vector3 testEdge1 = new Vector3( points[i1.Next.Value] - points[i1.Value], 0 );
                LinkedListNode<int> prev = i1.Previous;
                if ( prev == null )
                    prev = polygon.Last;
                Vector3 testEdge2 = new Vector3( points[prev.Value] - points[i1.Value], 0 );

                for ( LinkedListNode<int> i2 = i1.Next.Next; i2 != null; i2 = i2.Next ) {
                    Vector2 p1 = points[i1.Value];
                    Vector2 p2 = points[i2.Value];

                    // Indicates that the segment travels through
                    //   some empty space, so it's not a diagonal edge
                    Vector3 edge = new Vector3( p2 - p1, 0 );
                    if ( Vector3.Cross( testEdge1, edge ).Z <= 0 )
                        continue;
                    if ( Vector3.Cross( edge, testEdge2 ).Z <= 0 )
                        continue;

                    // If no polygon edge intersects our edge, 
                    //   then our edge is guaranteed to be a diagonal
                    //   find out whether or not this is a diagonal
                    bool isDiagonal = true;
                    for ( LinkedListNode<int> i3 = polygon.First; isDiagonal && i3 != null; i3 = i3.Next ) {
                        LinkedListNode<int> i4 = i3.Next;
                        if ( i4 == null )
                            i4 = polygon.First;

                        // Ignore edges eminating from one of our vertices
                        if ( i3 == i1 || i3 == i2 || i4 == i1 || i4 == i2 )
                            continue;

                        Vector2 p3 = points[i3.Value];
                        Vector2 p4 = points[i4.Value];

                        // Test for intersection
                        Vector2 d1 = p2 - p1;
                        Vector2 d2 = p4 - p3;

                        Vector2 b = p3 - p1;
                        float d = d1.X * d2.Y - d2.X * d1.Y;
                        if ( Math.Abs( d ) < 0.001f )
                            continue;
                        d = 1.0f / d;

                        float t = d2.Y * b.X - d2.X * b.Y;
                        float s = d1.Y * b.X - d1.X * b.Y;
                        t *= d;
                        s *= d;

                        // Just found an intersection - this is not a diagonal!
                        if ( s > 0 && s < 1 && t > 0 && t < 1 )
                            isDiagonal = false;
                    }

                    // Don't consider it if it's not a diagonal
                    if ( !isDiagonal )
                        continue;

                    Vector2 dir = p1 - p2;
                    dir.Normalize();

                    // Measure colinearity with nearby points
                    float ourColinearity = 0;

                    LinkedListNode<int> t1 = i1.Previous;
                    if ( t1 == null ) t1 = polygon.Last;
                    ourColinearity = Math.Max( ourColinearity, Math.Abs( GetColinearity( points[t1.Value], p1, dir ) ) );

                    LinkedListNode<int> t2 = i1.Next;
                    if ( t2 == null ) t2 = polygon.First;
                    ourColinearity = Math.Max( ourColinearity, GetColinearity( points[t2.Value], p1, dir ) );

                    LinkedListNode<int> t3 = i2.Previous;
                    if ( t3 == null ) t3 = polygon.Last;
                    ourColinearity = Math.Max( ourColinearity, GetColinearity( points[t3.Value], p2, dir ) );

                    LinkedListNode<int> t4 = i2.Next;
                    if ( t4 == null ) t4 = polygon.First;
                    ourColinearity = Math.Max( ourColinearity, GetColinearity( points[t4.Value], p2, dir ) );

                    // If our colinearity is smaller than our best bet, make
                    //   us into the new best bet!
                    if ( ourColinearity < smallestColinearity ) {
                        smallestColinearity = ourColinearity;
                        diag1 = i1;
                        diag2 = i2;
                    }
                }
            }

            Debug.Assert( diag1 != null );

            LinkedList<int> left = new LinkedList<int>();
            for ( LinkedListNode<int> i = diag1; i != diag2; i = ( i.Next != null ) ? i.Next : polygon.First )
                left.AddLast( i.Value );
            left.AddLast( diag2.Value );

            LinkedList<int> right = new LinkedList<int>();
            for ( LinkedListNode<int> i = diag2; i != diag1; i = ( i.Next != null ) ? i.Next : polygon.First )
                right.AddLast( i.Value );
            right.AddLast( diag1.Value );

            Split( left, points, triangles );
            Split( right, points, triangles );
        }

        private float GetColinearity( Vector2 testPoint, Vector2 origin, Vector2 direction ) {
            Vector2 dir = testPoint - origin;
            dir.Normalize();

            return Math.Abs( Vector2.Dot( dir, direction ) );
        }

        /**
         * Creates vertices that can be sent to the
         * graphics card for drawing
         */

        private void create_drawable( List<Triangle> triangles ) {
            // Loop over triangles to create vertices
            VertexPositionTexture[] vpt = new VertexPositionTexture[triangles.Count * 3];
            for ( int i = 0; i < triangles.Count; i++ ) {
                Triangle tri = triangles[i];


                // Loop over points in triangle to create vertices
                for ( int j = 0; j < 3; j++ ) {
                    Vector2 pt = new Vector2( tri.X[j], tri.Y[j] );
                    Vector3 v = new Vector3( pt, 0 );

                    // Generate texture coordinate around the center of the texture
                    Vector2 t = GameWorld.SCALE * pt / new Vector2( m_texture.Width, m_texture.Height ) +
                                new Vector2( 0.5f );
                    vpt[i + j] = new VertexPositionTexture( v, t );
                }
            }
            m_vertices.Add( vpt );
        }
        private void create_drawable( Vertices verts ) {
            // Loop over triangles to create vertices
            VertexPositionTexture[] vpt = new VertexPositionTexture[verts.Count];

            // Loop over points in triangle to create vertices
            for ( int j = 0; j < verts.Count; j++ ) {
                Vector3 v = new Vector3( verts[j], 0 );

                // Generate texture coordinate around the center of the texture
                Vector2 t = verts[j] * GameWorld.SCALE / new Vector2( m_texture.Width, m_texture.Height ) +
                            new Vector2( 0.5f );

                vpt[j] = new VertexPositionTexture( v, t );

            }
            m_vertices.Add( vpt );
        }
        private void create_drawable( List<Vector2[]> triangles ) {
            // Loop over triangles to create vertices
            VertexPositionTexture[] vpt = new VertexPositionTexture[triangles.Count * 3];
            for ( int i = 0; i < triangles.Count; i++ ) {
                Vector2[] points = triangles[i];

                // Loop over points in triangle to create vertices
                for ( int j = 0; j < 3; j++ ) {
                    Vector3 v = new Vector3( points[j], 0 );

                    // Generate texture coordinate around the center of the texture
                    Vector2 t = points[j] * GameWorld.SCALE / new Vector2( m_texture.Width, m_texture.Height ) +
                                new Vector2( 0.5f );

                    vpt[3 * i + j] = new VertexPositionTexture( v, t );
                }
            }
            m_vertices.Add( vpt );
        }
        #endregion
    }
}
