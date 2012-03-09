using System;
using System.Collections.Generic;
using System.Linq;
//========================================================================
// speedup-PolygonTrigger.cs
//========================================================================
//
// Author: Wen Hao Lui

using System.Text;

using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using FarseerPhysics.Collision.Shapes;
using FarseerPhysics.Common;
using System.Diagnostics;
using FarseerPhysics.Common.PolygonManipulation;


namespace speedup {
    class PolygonTrigger : Trigger {

        #region Static Constants
        //--------------------------------------------------------------------
        // Static Constants
        //--------------------------------------------------------------------	
        public const float DENSITY = .05f;
        #endregion
        #region Member Variables
        //--------------------------------------------------------------------
        // Member Variables
        //--------------------------------------------------------------------
        [ContentSerializer( Optional = true )]
        private VertexPositionTexture[] m_vertices;
        // buffer for physics creation
        [ContentSerializer( Optional = true )]
        private List<Vector2[]> m_triangles;

        [ContentSerializer( Optional = true )]
        public Vector2[] m_points { get; set; }

        public Vector2 pos { get; set; }

        [ContentSerializerIgnore]
        public String m_texture_name_change {
            get { return m_texture_name; }
            set {
                m_texture_name = value;

                //Change size according to texture
                float original_area = m_texture.Width * m_texture.Height;

                if ( Statics.fname_to_texture.ContainsKey( value ) ) {
                    m_texture = Statics.fname_to_texture[value];
                }
                else {
                    m_texture = GameScreen.GAME_CONTENT.Load<Texture2D>( value );
                    Statics.fname_to_texture.Add( value, m_texture );



                }

                if ( m_triangles != null ) { create_drawable( m_triangles ); }


            }
        }

        [ContentSerializerIgnore]
        public Matrix worldeffect { get; set; }

        #endregion
        #region Constructor
        //----------------------------------------------------------------
        // Constructor
        //----------------------------------------------------------------
        internal PolygonTrigger() {

        }

        public PolygonTrigger( GameWorld world, Texture2D active_texture,
            Texture2D inactive_texture, Vector2[] points, TriggerableObject triggered_object = null,
            TriggerType type = TriggerType.FLOOR, float cooldown = -1, float rotation = 0, String name = "Trigger",
            String texture_name = TNames.ground_switch_inactive )
            : base( world, active_texture, inactive_texture, Vector2.Zero, triggered_object, type, cooldown, rotation, name, texture_name ) {

            Vector2 diff = points[0] - points[(int)Math.Ceiling( points.Length / 2f )];
            float multiplier = Math.Min( Math.Abs( diff.X ), Math.Abs( diff.Y ) );
            m_width_height = new Vector2( multiplier, multiplier ) * 2;


            Vector2 sum = Vector2.Zero;

            foreach ( Vector2 p in points ) {
                sum += p;
            }
            pos = sum / points.Length;
            m_position = pos;

            for ( int i = 0; i < points.Length; i++ ) {
                points[i] -= pos;

            }


            if ( texture_name == TNames.wall && m_is_destructible ) {

                m_texture_name_change = TNames.breakwall;
                //m_texture = GameScreen.GAME_CONTENT.Load<Texture2D>(m_texture_name);
            }
            else if ( texture_name == TNames.tile ) {
                m_texture_name_change = TNames.tile;
                //m_texture = GameScreen.GAME_CONTENT.Load<Texture2D>(m_texture_name);

            }
            m_points = points;

            Vertices verts = new Vertices( points );
            Vertices collinear_simplified = SimplifyTools.CollinearSimplify( verts );
            Vertices merge_simplified = SimplifyTools.MergeIdenticalPoints( collinear_simplified );
            //Since it is a concave polygon, we need to partition it into several smaller convex polygons
            //List<Vertices> vert_list = BayazitDecomposer.ConvexPartition(merge_simplified);


            verts = merge_simplified;
            verts.ForceCounterClockWise();
            m_points = verts.ToArray();



        }



        #endregion
        #region Methods
        //----------------------------------------------------------------
        // Public Methods
        //----------------------------------------------------------------

        private void Split( LinkedList<int> polygon, Vector2[] points, List<Vector2[]> triangles ) {
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

        private void create_drawable( List<Vector2[]> triangles ) {
            // Loop over triangles to create vertices
            m_vertices = new VertexPositionTexture[triangles.Count * 3];
            for ( int i = 0; i < triangles.Count; i++ ) {
                Vector2[] points = triangles[i];

                // Loop over points in triangle to create vertices
                for ( int j = 0; j < 3; j++ ) {
                    Vector3 v = new Vector3( points[j], 0 );

                    // Generate texture coordinate around the center of the texture
                    Vector2 t = GameWorld.SCALE * points[j] / new Vector2( TestWorld.ground_switch_active_texture.Width, TestWorld.ground_switch_active_texture.Height ) +
                                new Vector2( 0.5f );

                    m_vertices[3 * i + j] = new VertexPositionTexture( v, t );
                }
            }
        }


        public override void add_to_world() {
            base.add_to_world();
            m_body.Position = m_position;
        }

        protected override Body create_physics() {
            var body = BodyFactory.CreateBody( m_world.m_world, this );

            Debug.Assert( m_points.Length >= 3 );

            var polygon_l = new LinkedList<int>();
            for ( int i = 0; i < m_points.Length; i++ ) {
                polygon_l.AddLast( i );
            }

            // Triangles generated
            m_triangles = new List<Vector2[]>();

            Split( polygon_l, m_points, m_triangles );
            create_drawable( m_triangles );

            foreach ( Vector2[] triangle in m_triangles ) {
                var polygon = new PolygonShape( new Vertices( triangle ),
                                                             m_density );
                body.CreateFixture( polygon );
            }

            body.Friction = m_friction;
            body.Restitution = m_restitution;
            //body.Position = m_position;
            //body.Awake = false;

            body.BodyType = BodyType.Kinematic;
            body.IsSensor = true;
            body.Position = pos;

            worldeffect = Matrix.CreateRotationZ(body.Rotation) *
Matrix.CreateScale(GameWorld.SCALE) *
Matrix.CreateTranslation(new Vector3(GameWorld.SCALE * body.Position, 0));


            return body;
        }

        public override void draw( SpriteBatch sprite_batch, Camera eye ) {

            worldeffect = Matrix.CreateRotationZ(m_body.Rotation) *
            Matrix.CreateScale(GameWorld.SCALE) *
            Matrix.CreateTranslation(new Vector3(GameWorld.SCALE * m_body.Position, 0));
            if ( GameScreen.editor_mode ) {


                var drawer = GameScreen.m_polygon_drawer;
                drawer.drawPolygons( worldeffect, m_texture,
                                    m_vertices,
                                    BlendState.AlphaBlend, eye );
            }
        }

        #endregion
    }
}
