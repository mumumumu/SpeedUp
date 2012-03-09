using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using FarseerPhysics.Common.Decomposition;
using FarseerPhysics.Common.PolygonManipulation;
using Microsoft.Xna.Framework.Input;
using button = System.Windows.Forms.ButtonState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using xna = Microsoft.Xna.Framework.Input;
using FarseerPhysics.Factories;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Common;
using alien = speedup.Alien;


using Microsoft.Xna.Framework.Content;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using DrawPoint = System.Drawing.Point;
using XnaPoint = Microsoft.Xna.Framework.Point;
using DrawRect = System.Drawing.Rectangle;

using XnaRectangle = Microsoft.Xna.Framework.Rectangle;


namespace speedup
{
    public partial class Editor : Form
    {

        //An enum representing the current state of the editor.
        public enum State
        {
            NO_EDITS, //Used when we don't have anything in the level editor
            EDITING_WORLD, //Used when we have a world loaded, as opposed to a room.
            EDITING_ROOM //Used when we have a single room loaded.
        }

        public enum EditorTool
        {
            Insertion,
            Selection
        }

        public enum InsertObject
        {
            WALL,
            THROWABLE,
            NINJA,
            SWITCH,
            DOOR,
            ALIEN

        }


        public State currentState = State.NO_EDITS;
        public EditorTool currentTool;
        public GameScreen screen;
        public TestWorld world { get; set; }
        public xna.MouseState mouse, prevmouse;
        public KeyboardState ks = new KeyboardState();
        public String current_filename { get; set; }
        private XML_Manager copier = new XML_Manager();
        private String current_copy_file_name;

        

        public InsertObject insert_object;
        public List<Vector2> wall_list = new List<Vector2>();
        public List<FloorTile> line_list = new List<FloorTile>();
        //private List<Selector> selector_list = new List<Selector>();
        public Selector current_selector;
        public SelectBox selectbox;


        public GameObject selected { get; set; }
        public GameObject prior_selected { get; set; }

        public static GameObject m_game_object;
        public static Ninja m_game_ninja;

        public Editor( GameScreen gameScreen )
        {
            screen = gameScreen;
            InitializeComponent();

        }
        public Editor()
        {

            InitializeComponent();

        }
        /* public IntPtr get_draw_surface()
         {
             return pictureBox1.Handle;
         }   */
        public void Form1_Load( object sender, EventArgs e )
        {


        }

        public Panel getMainPanel()
        {
            return panel_Main;
        }



        public void formMain_FormClosed( object sender, FormClosedEventArgs e )
        {
            Application.Exit();
        }

        public void pctSurface_Click( object sender, EventArgs e )
        {

        }

        public void addBall()
        {
            Ball adding = new Ball( screen.m_current_world, TestWorld.ball_texture, getMouse(), 2.0f );
            screen.m_current_world.add_queued_object( adding );

            gameObjectBindingSource.DataSource = adding;

        }

        public void addWall()
        {
            wall_list.Add( getMouse() );

            if ( wall_list.Count >= 2 )
            {
                int i = wall_list.Count - 2;

                Vector2 vec1, vec2;
                if ( wall_list[i].X < wall_list[i + 1].X )
                {
                    vec1 = wall_list[i];
                    vec2 = wall_list[i + 1];
                }
                else
                {
                    vec2 = wall_list[i];
                    vec1 = wall_list[i + 1];
                }

                Vector2 diff = vec2 - vec1;
                diff.Normalize();
                Vector2 offset = new Vector2( diff.Y * 0.04f, -diff.X * 0.04f );

                Vector2[] new_wall = new[] {
                       vec1 - offset,vec1 + offset,
                       vec2 + offset, 
                        vec2 - offset 
                        };

                FloorTile b = new FloorTile( screen.m_current_world, new_wall, TestWorld.floor_texture, 1.0f, 0.0f, 0.7f );
                screen.m_current_world.add_queued_object( b );
                line_list.Add( b );

            }

        }

        public void addAlien()
        {
            Alien adding = new Alien( screen.m_current_world, TestWorld.easy_alien_texture, getMouse(), .5f, alien.AlienType.EASY );
            screen.m_current_world.add_queued_object( adding );
        }

        public void addTrigger()
        {
            Trigger adding = new Trigger( screen.m_current_world, TestWorld.ground_switch_active_texture,
                TestWorld.ground_switch_inactive_texture, getMouse(), null,
                Trigger.TriggerType.FLOOR, 1, 0 );
            screen.m_current_world.add_queued_object( adding );
        }

        public void addConditionTrigger()
        {
            ConditionTriggered adding = 
                new ConditionTriggered(screen.m_current_world,
                                        TestWorld.ground_switch_active_texture,
                                        getMouse(), 0, null);
               
            screen.m_current_world.add_queued_object( adding );
        }

        public void addTriggerable()
        {
            Vector2 pos = getMouse();
            TriggerableObject adding = new TriggerableObject( screen.m_current_world, TestWorld.door_texture, pos, pos, 0 );
            screen.m_current_world.add_queued_object( adding );
        }

        public void addBackgroundTile()
        {
            Vector2 pos = getMouse();
            BackgroundTile adding = new BackgroundTile(screen.m_current_world,TestWorld.m_background, pos, Vector2.One);
            //TileCreator adding = new TileCreator(screen.m_current_world,TestWorld.m_background,pos,Vector2.One);
            screen.m_current_world.add_queued_object(adding);
        }

        /* Central method called when the game screen is clicked. Decides the correct method to call for each action 
         */
        public void gameControl_Click( object sender, EventArgs e )
        {
            if ( currentTool == Editor.EditorTool.Insertion )
            {
                if ( m_rb_throwing.Checked )
                {
                    addBall();
                }
                else if ( m_rb_Wall.Checked || m_rb_tile.Checked || m_rb_poly_trigger.Checked )
                {
                    addWall();
                }
                else if ( m_rb_alien.Checked )
                {
                    addAlien();
                }
                else if ( m_rb_trigger.Checked )
                {
                    addTrigger();
                   
                }
                else if ( m_rb_condition_trigger.Checked )
                {
                    addConditionTrigger();
                }
                else if ( m_rb_triggerable_object.Checked )
                {
                    addTriggerable();
                }
                else if (m_rb_background_tile.Checked)
                {
                    addBackgroundTile();
                }

            }
            else if ( currentTool == Editor.EditorTool.Selection )
            {
                if ( current_selector != null )
                {
                    current_selector.destroy();

                }
                Selector s = new Selector( screen.m_current_world, TestWorld.pix_texture, getMouse(), 0.1f, this );


                screen.m_current_world.add_queued_object( s );
                current_selector = s;


            }

        }

        public Vector2 getMouse()
        {
            //temp offset added
            Vector2 mouse_pos = new Vector2( mouse.X, mouse.Y );
            Matrix m = ( Matrix.Invert( GameScreen.m_curr_view.get_transformation() ) );
            return Vector2.Transform( mouse_pos, m ) / 50;
                                   

        }




        /// <summary>
        /// Set all tool squares to "unchecked."
        /// </summary>
        public void ClearToolMenu()
        {
            tool_Insertion.Checked = false;
            tool_Selection.Checked = false;
            if (selectbox != null) {
                selectbox.destroy();
                selectbox = null;
            }
            /* foreach ( Selector s in selector_list )
                 {
                 if ( s != null )
                     {
                     s.destroy();
                     s.remove_from_world();
                     }
                 }
             selector_list = new List<Selector>();*/

        }




        public void gb_game_object_Click( object sender, EventArgs e )
        {
            //gameObjectBindingSource.Add(m_game_object);

            // gameObjectBindingSource.DataSource
        }


        public void clearLine()
        {
            wall_list = new List<Vector2>();

            foreach ( FloorTile b in line_list )
            {
                b.destroy();

            }
            line_list = new List<FloorTile>();

        }

        public void tool_Insertion_Click_1( object sender, EventArgs e )
        {
            ClearToolMenu();
            tool_Insertion.Checked = true;

            currentTool = EditorTool.Insertion;
            clearLine();
        }



        private void createPos_TextChanged( object sender, EventArgs e )
        {

        }

        private void tool_Selection_Click( object sender, EventArgs e )
        {
            ClearToolMenu();
            tool_Selection.Checked = true;

            currentTool = EditorTool.Selection;
            clearLine();
        }

        public void Update2()
        {

            prevmouse = mouse;
            mouse = xna.Mouse.GetState();
            if ( selected != null && currentTool == EditorTool.Selection )
            {

                
                gameObjectBindingSource.DataSource = selected;
                if ( selected.m_body != null )
                {

                    if ( selected is Alien )
                    {
                        alienBindingSource.DataSource = selected;
                    }
                    else if ( selected is Trigger )
                    {
                        triggerBindingSource.DataSource = selected;
                        if ( selected is ConditionTriggered )
                        {
                            conditionTriggeredBindingSource.DataSource = selected;
                        }
                    }
                    else if ( selected is TriggerableObject )
                    {
                        triggerableObjectBindingSource.DataSource = selected;
                    }

                    if ( ( selected is PolygonObject ) )
                    {
                        polygonObjectBindingSource.DataSource = selected;
                        if ( selected is FloorTile )
                        {
                            floorTileBindingSource.DataSource = selected;
                        }


                    }


                    // If a new object is selected, create a new selectbox
                    if ( selected != prior_selected )
                    {


                        clearLine();
                        if ( !( selected is PolygonObject ) && !(selected is CompoundPolygonObject) )
                        {
                            if ( selectbox == null )
                            {
                                selectbox = new SelectBox( screen.m_current_world, TestWorld.floor_texture, selected.m_body.Position, selected.m_radius, target:selected);
                                screen.m_current_world.add_queued_object( selectbox );
                            }
                            else
                            {
                                if ( selected.m_radius != 0 )
                                {
                                    selectbox.m_radius = selected.m_radius;
                                }
                                else
                                {
                                    selectbox.m_radius = 1;
                                }
                                selectbox.m_target = selected;
                                selectbox.m_body.Position = selected.m_body.Position;
                            }
                        }
                        else
                        {
                            if ( selectbox == null )
                            {
                                selectbox = new SelectBox( screen.m_current_world, TestWorld.floor_texture,
                                    selected.m_body.Position, 0.25f, target: selected );
                                screen.m_current_world.add_queued_object( selectbox );
                            }
                            else
                            {

                                selectbox.m_radius = 0.25f;
                                //selectbox.m_draw_location = selected.m_body.Position;
                                selectbox.m_target = selected;
                                selectbox.m_body.Position = selected.m_body.Position;
                            }
                        }

                        prior_selected = selected;
                    }

                }

                // If the mouse is clicked and dragged, move the object the same distance
                if ( screen.m_current_world != null && selected.m_body != null && mouse.LeftButton == ButtonState.Pressed )
                {
                    Vector2 shift = screen.m_current_world.get_transform( new Vector2( mouse.X, mouse.Y ) ) - screen.m_current_world.get_transform( new Vector2( prevmouse.X, prevmouse.Y ) );
                    if ( shift != Vector2.Zero && selected != selectbox )
                    {
                        selected.m_body.Position += shift;
                        if ( selectbox != null )
                        {
                            selectbox.m_draw_location = selected.m_body.Position;
                            selectbox.m_body.Position = selected.m_body.Position;
                        }
                        if ( selected is PolygonObject )
                        {
                            PolygonObject wall = (PolygonObject)selected;
                            wall.pos += shift;
                        }
                    }
                }

            }


        }

        private void m_rb_alien_CheckedChanged_1( object sender, EventArgs e )
        {



        }

        private void tool_Selection_Click_1( object sender, EventArgs e )
        {
            ClearToolMenu();
            tool_Selection.Checked = true;

            currentTool = EditorTool.Selection;
        }

        private void tab_insert_Click( object sender, EventArgs e )
        {

        }



        private void apply_Click( object sender, EventArgs e )
        {
            ninjaBindingSource.ResetCurrentItem();
            alienBindingSource.ResetCurrentItem();
            floorTileBindingSource.ResetCurrentItem();
            gameObjectBindingSource.ResetCurrentItem();
            polygonObjectBindingSource.ResetCurrentItem();
            triggerBindingSource.ResetCurrentItem();
            triggerableObjectBindingSource.ResetCurrentItem();
            m_pointsBindingSource.ResetCurrentItem();
            conditionTriggeredBindingSource.ResetCurrentItem();
            try
            {
                if ( m_rb_Wall.Checked && wall_list.Count == 2 )
                {
                    Vector2 vec1 = wall_list[0];
                    Vector2 vec2 = wall_list[1];

                    Vector2 diff = vec2 - vec1;
                    diff.Normalize();
                    Vector2 offset = new Vector2( diff.Y * 0.25f, -diff.X * 0.25f );

                    Vector2[] new_wall = new[] {
                       vec1 - offset,vec1 + offset,
                       vec2 + offset, 
                        vec2 - offset 
                        };

                    screen.m_current_world.add_queued_object( new PolygonObject( screen.m_current_world, new_wall, TestWorld.wall_texture, 1.0f, 0.0f, 0.7f ) );


                    clearLine();
                }

                if ( m_rb_Wall.Checked && wall_list.Count >= 3 )
                {
                    screen.m_current_world.add_queued_object( new PolygonObject( screen.m_current_world, wall_list.ToArray(), TestWorld.wall_texture, 1.0f, 0.0f, 0.7f ) );


                    clearLine();


                }
                else if ( m_rb_tile.Checked && wall_list.Count >= 3 )
                {

                    screen.m_current_world.add_queued_object( new FloorTile( screen.m_current_world, wall_list.ToArray(), TestWorld.floor_texture, 1.0f, 0.0f, 0.7f ) );

                    clearLine();

                }
                if ( m_rb_poly_trigger.Checked && wall_list.Count >= 3 )
                {
                    screen.m_current_world.add_queued_object( new PolygonTrigger( screen.m_current_world,TestWorld.wall_texture,
                        TestWorld.ground_switch_active_texture,
                    wall_list.ToArray() ) );


                    clearLine();


                }

            }
            catch ( Exception o )
            {
                Console.WriteLine( "Error, incorrect order of vertices" );
            }
        }

        private void m_rb_Wall_CheckedChanged( object sender, EventArgs e )
        {
            clearLine();
        }

        private void m_rb_tile_CheckedChanged( object sender, EventArgs e )
        {
            clearLine();
        }

        private void m_is_throwableCheckBox2_CheckedChanged( object sender, EventArgs e )
        {

        }

        private void delete_Click( object sender, EventArgs e )
        {
            if ( selected != null )
            {
                selected.destroy();

                selected = null;
            }
        }



        public void vertices_to_polygon_add( Vertices verts )
        {
            Texture2D poly_texture;
            if ( current_selector != null )
            {
                if ( Statics.fname_to_texture.ContainsKey( m_cb_poly_tex_name.Text ) )
                {
                    poly_texture = Statics.fname_to_texture[m_cb_poly_tex_name.Text];
                }
                else
                {
                    poly_texture = GameScreen.GAME_CONTENT.Load<Texture2D>( m_cb_poly_tex_name.Text );
                    Statics.fname_to_texture.Add( m_cb_poly_tex_name.Text, poly_texture );


                }

                Vector2[] new_points = new Vector2[verts.Count];
                for ( int i = 0; i < new_points.Length; i++ )
                {
                    new_points[i] = verts[i] + current_selector.m_position;
                }

                PolygonObject new_poly =
                    new PolygonObject(
                        screen.m_current_world,
                        new_points,
                        poly_texture,
                        texture_name: m_cb_poly_tex_name.Text );
                screen.m_current_world.add_queued_object( new_poly );
            }
        }
        private void m_poly_create_circle_Click( object sender, EventArgs e )
        {

            Vertices circle_vertices = PolygonTools.CreateCircle( (float)m_poly_radius.Value, (int)m_poly_num_edges.Value );
            vertices_to_polygon_add( circle_vertices );
            /*Texture2D poly_texture;
            if ( current_selector != null )
            {
                if ( Statics.fname_to_texture.ContainsKey( m_cb_poly_tex_name.Text ) )
                {
                    poly_texture = Statics.fname_to_texture[m_cb_poly_tex_name.Text];
                }
                else
                {
                    poly_texture = GameScreen.GAME_CONTENT.Load<Texture2D>( m_cb_poly_tex_name.Text );
                    Statics.fname_to_texture.Add( m_cb_poly_tex_name.Text, poly_texture );


                }

                Vertices circle_vertices = PolygonTools.CreateCircle((float)m_poly_radius.Value, (int)m_poly_num_edges.Value);
                Vector2[] new_points = new Vector2[circle_vertices.Count];
                for ( int i = 0; i < new_points.Length; i++ )
                {                                                                  
                    new_points[i] = circle_vertices[i] + current_selector.m_position;
                }

                PolygonObject new_circle = new PolygonObject( screen.m_current_world,new_points,poly_texture);
                screen.m_current_world.add_queued_object(new_circle);
            }       */
        }

        private void m_poly_create_ellipse_Click( object sender, EventArgs e )
        {
            Vertices ellipse_vertices =
                PolygonTools.CreateEllipse(
                (float)m_poly_x_radius.Value,
                (float)m_poly_y_radius.Value,
                (int)m_poly_num_edges.Value );
            vertices_to_polygon_add( ellipse_vertices );
        }



        private void m_poly_create_rectangle_Click( object sender, EventArgs e )
        {

            Vertices rectangle_vertices =
                PolygonTools.CreateRectangle(
                    (float)m_poly_x_radius.Value,
                    (float)m_poly_y_radius.Value );
            /*current_selector.m_position,
            (float) m_poly_angle.Value); */
            vertices_to_polygon_add( rectangle_vertices );

        }

        private void button2_Click( object sender, EventArgs e )
        {
            Texture2D poly_texture;
            if ( current_selector != null )
            {
                if ( Statics.fname_to_texture.ContainsKey( m_cb_poly_tex_name.Text ) )
                {
                    poly_texture = Statics.fname_to_texture[m_cb_poly_tex_name.Text];
                }
                else
                {
                    poly_texture = GameScreen.GAME_CONTENT.Load<Texture2D>( m_cb_poly_tex_name.Text );
                    Statics.fname_to_texture.Add( m_cb_poly_tex_name.Text, poly_texture );


                }

                CompoundPolygonObject cmp_obj =
                    new CompoundPolygonObject(
                        screen.m_current_world,
                        poly_texture, current_selector.m_position,
                        texture_name: m_cb_poly_tex_name.Text,
                        scaleX: (float)m_poly_x_scale.Value,scaleY: (float)m_poly_y_scale.Value );
                screen.m_current_world.add_queued_object( cmp_obj );

            }
        }

        private void m_attach_triggerable_object_button_Click( object sender, EventArgs e )
        {
            if ( triggerBindingSource.DataSource != null && triggerableObjectBindingSource.DataSource != null )
            {
                Trigger temp_trigger = (Trigger)triggerBindingSource.DataSource;
                TriggerableObject t_obj = (TriggerableObject)triggerableObjectBindingSource.DataSource;
                if ( !temp_trigger.m_attached_to.Contains( t_obj ) )
                {

                    temp_trigger.m_attached_to.Add( t_obj );
                    triggerBindingSource.DataSource = temp_trigger;
                }

            }
        }

        private void m_remove_TriggerableObject_Click( object sender, EventArgs e )
        {
            if ( triggerBindingSource.DataSource != null && triggerableObjectBindingSource.DataSource != null )
            {
                Trigger temp_trigger = (Trigger)triggerBindingSource.DataSource;
                TriggerableObject t_obj = (TriggerableObject)triggerableObjectBindingSource.DataSource;
                if ( temp_trigger.m_attached_to.Contains( t_obj ) )
                {

                    temp_trigger.m_attached_to.Remove( t_obj );
                    triggerBindingSource.DataSource = temp_trigger;
                }

            }
        }

        private void m_trigger_items_clear_Click( object sender, EventArgs e )
         {
             if ( triggerBindingSource.DataSource != null && triggerableObjectBindingSource.DataSource != null )
             {
                 Trigger temp_trigger = (Trigger)triggerBindingSource.DataSource;
                 temp_trigger.m_attached_to.Clear();
                 triggerBindingSource.DataSource = temp_trigger;
             }
         }

        private void saveAsToolStripMenuItem_Click( object sender, EventArgs e )
        {
              
                        Thread saveFileDialog = new Thread(new ThreadStart(open_save_dialog));
                        saveFileDialog.SetApartmentState(ApartmentState.STA);
                        saveFileDialog.Start();
                          
            
        }


         private void open_save_dialog()
         {
             //Allow the user to choose a name and a location
             SaveFileDialog dialog = new SaveFileDialog();


             dialog.Filter = "Level File(xml) | *.xml";




             dialog.InitialDirectory = ".";
             dialog.Title = "Choose the xml file to save.";


             //DialogResult result = dialog.ShowDialog();

             //If the result was ok, load the resultant file, otherwise, just return.
             if ( dialog.ShowDialog() == DialogResult.OK )
             {
                 screen.m_current_world.save_state( dialog.FileName );

                 current_filename = dialog.FileName;
             }
         }
         //Event that calls the load
         private void mi_Load_Level_Click( object sender, EventArgs e )
         {
             Thread openFileDialog = new Thread( new ThreadStart( open_file_dialog ) );
             openFileDialog.SetApartmentState( ApartmentState.STA );
             openFileDialog.Start();
         }

         private void open_file_dialog( )
         {
             //First, choose the file we want to load.
             OpenFileDialog dialog = new OpenFileDialog();
             dialog.Filter = "Level File(xml) | *.xml";
             dialog.InitialDirectory = ".";
             dialog.Title = "Choose the xml file to load.";

             DialogResult result = dialog.ShowDialog();

             //If the result was ok, load the resultant file, otherwise, just return.
             if ( result == DialogResult.OK )
             {
                screen.m_current_world = new TestWorld(GameScreen.m_curr_view,this,dialog.FileName);
             }
         }

         private void m_create_poly_from_texture_Click( object sender, EventArgs e )
         {

         }

         private void m_cb_poly_tex_name_SelectedIndexChanged( object sender, EventArgs e )
         {

         }

         private void copy_Click( object sender, EventArgs e )
         {
             if ( current_copy_file_name == null )
             {
                 current_copy_file_name = "current_copy.xml";
             }
             if ( selected != null )
             {
                 String copy_file_name = "current_copy.xml";
                 copier.save_game_object( selected, copy_file_name );

                 GameObject copy = copier.load_game_object( copy_file_name );
                 copy.m_world = screen.m_current_world;
                 copy.m_rotation = selected.m_body.Rotation;
                 screen.m_current_world.add_queued_object( copy );
                 current_copy_file_name = copy_file_name;
             }
             else if ( current_copy_file_name != null )
             {
                 try
                 {
                     GameObject copy = copier.load_game_object( current_copy_file_name );
                     copy.m_world = screen.m_current_world;
                     
                     screen.m_current_world.add_queued_object( copy );
                     if ( current_selector != null )
                     {
                         copy.m_buffered_position = current_selector.m_position;
                         copy.m_position = current_selector.m_position;
                     }
                 }
                 catch
                 {
                     Console.WriteLine("Error copying object");
                 }
             }
             

             
             /*if ( selected != null && selected is PolygonObject )
             {

                 PolygonObject obj = (PolygonObject)selected;
                 Vector2[] new_wall = (Vector2[]) obj.m_points.Clone();
                 for (int i =0; i<new_wall.Count(); i++)
                 {
                     new_wall[i] += obj.pos;
                 }

                 PolygonObject copy = new PolygonObject( screen.m_current_world, new_wall, obj.m_texture );
                 copy.m_rotation = selected.m_body.Rotation;
                 screen.m_current_world.add_queued_object( copy );
                 
             }
             if ( selected != null && selected is Alien )
             {

                 copier.save_game_object(selected,"Alien_copy.xml");

                 Alien copy = (Alien)copier.load_game_object("Alien_copy.xml");
                 copy.m_world = selected.m_world;
                 copy.m_rotation = selected.m_body.Rotation;
                 screen.m_current_world.add_queued_object( copy );

             }  */
         }

         private void m_condition_add_obj_Click( object sender, EventArgs e )
         {
             if ( conditionTriggeredBindingSource.DataSource != null && gameObjectBindingSource.DataSource != null )
             {
                 ConditionTriggered temp_trigger = (ConditionTriggered)conditionTriggeredBindingSource.DataSource;
                 GameObject t_obj = (GameObject)gameObjectBindingSource.DataSource;
                 if ( !temp_trigger.trigger_list.Contains( t_obj ) && t_obj!=temp_trigger )
                 {

                     temp_trigger.trigger_list.Add( t_obj );
                     conditionTriggeredBindingSource.DataSource = temp_trigger;
                 }

             }  
         }

         private void m_cond_remove_obj_Click( object sender, EventArgs e )
         {
             if ( conditionTriggeredBindingSource.DataSource != null && gameObjectBindingSource.DataSource != null )
             {
                 ConditionTriggered temp_trigger = (ConditionTriggered)conditionTriggeredBindingSource.DataSource;
                 GameObject t_obj = (GameObject)gameObjectBindingSource.DataSource;
                 if ( temp_trigger.trigger_list.Contains( t_obj ) )
                 {

                     temp_trigger.trigger_list.Remove( t_obj );
                     conditionTriggeredBindingSource.DataSource = temp_trigger;
                 }

             }
         }

         private void m_trig_objs_clear_Click( object sender, EventArgs e )
         {
             if ( conditionTriggeredBindingSource.DataSource != null && gameObjectBindingSource.DataSource != null )
             {
                 ConditionTriggered temp_trigger = (ConditionTriggered)conditionTriggeredBindingSource.DataSource;
                 
                 temp_trigger.trigger_list.Clear();
                 conditionTriggeredBindingSource.DataSource = temp_trigger;

             }
         }

         private void save_object_to_name_Click( object sender, EventArgs e )
         {
             
             if(selected != null)
             {
                 try
                 {
                     current_copy_file_name = Directory.GetCurrentDirectory() + "/Objects/" + selected.m_name + ".xml";
                     copier.save_game_object( selected, current_copy_file_name );
                 }
                 catch
                 {
                     Console.WriteLine("Error Saving Object.");
                 }


                

             }
         }

         private void load_object_Click( object sender, EventArgs e )
         {
             try
             {
                 GameObject loaded_obj = copier.load_game_object( Directory.GetCurrentDirectory() + "/Objects/" + (String)load_items_listbox.SelectedItem );
                 loaded_obj.m_world = screen.m_current_world;

                 screen.m_current_world.add_queued_object( loaded_obj );
                
                 if ( current_selector != null )
                 {
                    
                     //Added offset so aliens don't crash
                     loaded_obj.m_buffered_position = current_selector.m_position;
                     loaded_obj.m_position = current_selector.m_position + Vector2.One;

                 }

                 if ( loaded_obj is Alien )
                 {
                     ((Alien) loaded_obj).m_ai_control.m_target = screen.m_current_world.m_ninja;
                 }
                
             }
             catch
             {
                 Console.WriteLine( "Error copying object" );
             }
         }

         private void update_object_list_Click( object sender, EventArgs e )
         {
             List<FileInfo> object_names = new List<FileInfo>();
             DirectoryInfo dir = new DirectoryInfo( Directory.GetCurrentDirectory() + "/Objects" );
             Console.WriteLine( Directory.GetCurrentDirectory() + "/Objects" );
             try { object_names.AddRange( dir.GetFiles() ); }
             catch { Console.WriteLine( "ERROR LOADING Objects" ); }

             foreach ( FileInfo name in object_names )
             {
                 load_items_listbox.Items.Add( name.Name );
             }
         }

         private void m_poly_create_arc_Click( object sender, EventArgs e )
         {
             Vertices arc_vert = PolygonTools.CreateArc(
                 (float)m_poly_angle.Value, 
                 (int)m_poly_num_edges.Value, 
                 (float)m_poly_radius.Value
                 );
           vertices_to_polygon_add(arc_vert);
             
         }

         private void m_poly_create_lines_Click( object sender, EventArgs e )
         {
             try
             {
                 if ( m_rb_Wall.Checked && wall_list.Count >= 2 )
                 {
                     for ( int i = 0; i < wall_list.Count - 1; i++ )
                     {
                         Vector2 vec1 = wall_list[i];
                         Vector2 vec2 = wall_list[i+1];

                         Vector2 diff = vec2 - vec1;
                         diff.Normalize();
                         Vector2 offset = new Vector2(diff.Y*0.25f, -diff.X*0.25f);

                         Vector2[] new_wall = new[]
                                                  {
                                                      vec1 - offset, vec1 + offset,
                                                      vec2 + offset,
                                                      vec2 - offset
                                                  };

                         screen.m_current_world.add_queued_object(new PolygonObject(screen.m_current_world, new_wall,
                                                                                    TestWorld.wall_texture, 1.0f, 0.0f,
                                                                                    0.7f));
                     }
                     clearLine();
                 }
             }
             catch
             {
                 
             }
         }

         private void copy_advanced_button_Click(object sender, EventArgs e)
         {
             if (current_copy_file_name == null)
             {
                 current_copy_file_name = "current_copy.xml";
             }
             if (selected != null)
             {
                 String copy_file_name = "current_copy.xml";
                 copier.save_game_object(selected, copy_file_name);

                 GameObject copy = copier.load_game_object(copy_file_name);
                 copy.m_world = screen.m_current_world;
                 copy.m_rotation = selected.m_body.Rotation;
                 screen.m_current_world.add_queued_object(copy);
                 current_copy_file_name = copy_file_name;
             }
             else if (current_copy_file_name != null)
             {
                 try
                 {
                     GameObject copy = copier.load_game_object(current_copy_file_name);
                     copy.m_world = screen.m_current_world;

                     screen.m_current_world.add_queued_object(copy);
                     if (current_selector != null)
                     {
                         copy.m_buffered_position = current_selector.m_position;
                         copy.m_position = current_selector.m_position;
                     }
                 }
                 catch
                 {
                     Console.WriteLine("Error copying object");
                 }
             }
         }

         private void button_trigobj_add_object_Click(object sender, EventArgs e)
         {
             if (triggerableObjectBindingSource.DataSource != null && gameObjectBindingSource.DataSource != null)
             {
                 TriggerableObject temp_trig = (TriggerableObject)triggerableObjectBindingSource.DataSource;
                 GameObject t_obj = (GameObject)gameObjectBindingSource.DataSource;
                 if(temp_trig.m_objects==null)
                 {
                     temp_trig.m_objects = new SharedResourceList<GameObject>();
                 }
                 if (!temp_trig.m_objects.Contains(t_obj) && t_obj != temp_trig)
                 {

                     temp_trig.m_objects.Add(t_obj);
                     triggerableObjectBindingSource.DataSource = temp_trig;
                 }

             }
         }

         private void button_trigobj_clear_Click(object sender, EventArgs e)
         {
             if (triggerableObjectBindingSource.DataSource != null)
             {
                 TriggerableObject temp_trig = (TriggerableObject)triggerableObjectBindingSource.DataSource;
                 if (temp_trig.m_objects == null)
                 {
                     temp_trig.m_objects = new SharedResourceList<GameObject>();
                 }
                 temp_trig.m_objects.Clear();
                 triggerableObjectBindingSource.DataSource = temp_trig;
             }
         }

         

        

        

      
        

        
       

        

        

         

         



        

    }
}
