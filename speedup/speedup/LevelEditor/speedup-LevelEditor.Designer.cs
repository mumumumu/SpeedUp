using System.Windows.Forms;

namespace speedup
{
    partial class Editor
    {

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        public void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label m_typeLabel;
            System.Windows.Forms.Label m_nameLabel6;
            System.Windows.Forms.Label m_texture_nameLabel4;
            System.Windows.Forms.Label m_radiusLabel4;
            System.Windows.Forms.Label m_nameLabel3;
            System.Windows.Forms.Label m_buffered_angleLabel3;
            System.Windows.Forms.Label m_nameLabel;
            System.Windows.Forms.Label m_is_throwableLabel3;
            System.Windows.Forms.Label m_is_destructibleLabel3;
            System.Windows.Forms.Label m_is_deadLabel;
            System.Windows.Forms.Label sleepingAllowedLabel;
            System.Windows.Forms.Label restitutionLabel;
            System.Windows.Forms.Label isStaticLabel;
            System.Windows.Forms.Label isDisposedLabel;
            System.Windows.Forms.Label isBulletLabel;
            System.Windows.Forms.Label ignoreGravityLabel;
            System.Windows.Forms.Label ignoreCCDLabel;
            System.Windows.Forms.Label frictionLabel;
            System.Windows.Forms.Label fixedRotationLabel;
            System.Windows.Forms.Label enabledLabel;
            System.Windows.Forms.Label awakeLabel;
            System.Windows.Forms.Label m_texture_nameLabel2;
            System.Windows.Forms.Label bodyTypeLabel;
            System.Windows.Forms.Label massLabel;
            System.Windows.Forms.Label linearDampingLabel;
            System.Windows.Forms.Label inertiaLabel;
            System.Windows.Forms.Label m_destroy_thresholdLabel4;
            System.Windows.Forms.Label m_change_sizeLabel;
            System.Windows.Forms.Label m_collision_typeLabel;
            System.Windows.Forms.Label m_kill_under_speedLabel1;
            System.Windows.Forms.Label m_texture_name_changeLabel;
            System.Windows.Forms.Label isSensorLabel;
            System.Windows.Forms.Label densityLabel;
            System.Windows.Forms.Label shapeTypeLabel;
            System.Windows.Forms.Label fixtureIdLabel;
            System.Windows.Forms.Label frictionLabel1;
            System.Windows.Forms.Label isDisposedLabel1;
            System.Windows.Forms.Label isSensorLabel1;
            System.Windows.Forms.Label restitutionLabel1;
            System.Windows.Forms.Label childCountLabel;
            System.Windows.Forms.Label densityLabel1;
            System.Windows.Forms.Label radiusLabel;
            System.Windows.Forms.Label shapeTypeLabel1;
            System.Windows.Forms.Label collidesWithLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label rotationLabel;
            System.Windows.Forms.Label num_triggerable_objectsLabel;
            System.Windows.Forms.Label m_activeLabel;
            System.Windows.Forms.Label m_cooldownLabel;
            System.Windows.Forms.Label m_deactivatedLabel;
            System.Windows.Forms.Label m_typeLabel2;
            System.Windows.Forms.Label m_ai_type_changeLabel;
            System.Windows.Forms.Label m_nameLabel2;
            System.Windows.Forms.Label m_lengthLabel;
            System.Windows.Forms.Label num_cond_objectsLabel;
            System.Windows.Forms.Label m_condition_typeLabel;
            System.Windows.Forms.Label m_ai_stateLabel;
            System.Windows.Forms.Label m_attack_cooldownLabel;
            System.Windows.Forms.Label m_attack_powerLabel;
            System.Windows.Forms.Label m_attack_distLabel;
            System.Windows.Forms.Label m_chase_distLabel;
            System.Windows.Forms.Label m_move_stepLabel;
            System.Windows.Forms.Label m_rangeLabel;
            System.Windows.Forms.Label m_invisibleLabel;
            System.Windows.Forms.Label m_timer_checkpoint_setLabel;
            System.Windows.Forms.Label m_alien_color_green_changeLabel;
            System.Windows.Forms.Label m_alien_color_red_changeLabel;
            System.Windows.Forms.Label m_alien_color_blue_changeLabel;
            System.Windows.Forms.Label m_alien_color_alpha_changeLabel;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label m_change_size_xLabel;
            System.Windows.Forms.Label m_change_size_yLabel;
            System.Windows.Forms.Label m_follow_meLabel;
            System.Windows.Forms.Label m_set_zoomLabel;
            System.Windows.Forms.Label m_zoom_multLabel;
            System.Windows.Forms.Label m_laser_slowdownLabel;
            System.Windows.Forms.Label m_textLabel;
            System.Windows.Forms.Label m_textbox_widthLabel;
            System.Windows.Forms.Label m_attack_speedLabel;
            System.Windows.Forms.Label if_deactivatorLabel;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label m_disabledLabel;
            System.Windows.Forms.Label m_continuous_checkLabel;
            System.Windows.Forms.Label obj_countLabel;
            this.fixtureListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.m_throw_powerLabel = new System.Windows.Forms.Label();
            this.m_speedLabel = new System.Windows.Forms.Label();
            this.m_picking_upLabel = new System.Windows.Forms.Label();
            this.m_nameLabel1 = new System.Windows.Forms.Label();
            this.m_movement_accelLabel = new System.Windows.Forms.Label();
            this.m_maxspeedLabel = new System.Windows.Forms.Label();
            this.m_max_throwable_capacityLabel = new System.Windows.Forms.Label();
            this.m_is_killedLabel = new System.Windows.Forms.Label();
            this.panel_Main = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel_EditOptions = new System.Windows.Forms.Panel();
            this.object_tabs = new System.Windows.Forms.TabControl();
            this.saveLoadObject = new System.Windows.Forms.TabPage();
            this.update_object_list = new System.Windows.Forms.Button();
            this.load_items_listbox = new System.Windows.Forms.ListBox();
            this.load_object = new System.Windows.Forms.Button();
            this.save_object_to_name = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.gameObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.m_game_object_page = new System.Windows.Forms.TabPage();
            this.m_disabledCheckBox = new System.Windows.Forms.CheckBox();
            this.rotationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.shapeTypeComboBox = new System.Windows.Forms.ComboBox();
            this.densityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.isSensorCheckBox = new System.Windows.Forms.CheckBox();
            this.m_texture_name_changeComboBox = new System.Windows.Forms.ComboBox();
            this.m_change_sizeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_destroy_thresholdNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.inertiaNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.linearDampingNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.massNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.restitutionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bodyTypeComboBox = new System.Windows.Forms.ComboBox();
            this.frictionTextBox = new System.Windows.Forms.TextBox();
            this.m_nameTextBox = new System.Windows.Forms.TextBox();
            this.awakeCheckBox = new System.Windows.Forms.CheckBox();
            this.enabledCheckBox = new System.Windows.Forms.CheckBox();
            this.fixedRotationCheckBox = new System.Windows.Forms.CheckBox();
            this.ignoreCCDCheckBox = new System.Windows.Forms.CheckBox();
            this.ignoreGravityCheckBox = new System.Windows.Forms.CheckBox();
            this.isBulletCheckBox = new System.Windows.Forms.CheckBox();
            this.isDisposedCheckBox = new System.Windows.Forms.CheckBox();
            this.isStaticCheckBox = new System.Windows.Forms.CheckBox();
            this.sleepingAllowedCheckBox = new System.Windows.Forms.CheckBox();
            this.m_is_deadCheckBox = new System.Windows.Forms.CheckBox();
            this.m_is_destructibleCheckBox3 = new System.Windows.Forms.CheckBox();
            this.m_is_throwableCheckBox3 = new System.Windows.Forms.CheckBox();
            this.m_ninja_page = new System.Windows.Forms.TabPage();
            this.m_max_throwable_capacityTextBox = new System.Windows.Forms.TextBox();
            this.ninjaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.m_maxspeedTextBox = new System.Windows.Forms.TextBox();
            this.m_movement_accelTextBox = new System.Windows.Forms.TextBox();
            this.m_nameTextBox1 = new System.Windows.Forms.TextBox();
            this.m_speedTextBox = new System.Windows.Forms.TextBox();
            this.m_throw_powerTextBox = new System.Windows.Forms.TextBox();
            this.m_is_killedCheckBox = new System.Windows.Forms.CheckBox();
            this.m_picking_upCheckBox = new System.Windows.Forms.CheckBox();
            this.PolygonObject = new System.Windows.Forms.TabPage();
            this.m_change_size_yNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.polygonObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.m_change_size_xNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_create_poly_from_texture = new System.Windows.Forms.TabPage();
            this.m_poly_create_arc = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.m_poly_create_rectangle = new System.Windows.Forms.Button();
            this.m_poly_create_ellipse = new System.Windows.Forms.Button();
            this.m_poly_angle = new System.Windows.Forms.NumericUpDown();
            this.m_poly_create_circle = new System.Windows.Forms.Button();
            this.m_poly_y_scale = new System.Windows.Forms.NumericUpDown();
            this.m_poly_x_scale = new System.Windows.Forms.NumericUpDown();
            this.m_poly_num_edges = new System.Windows.Forms.NumericUpDown();
            this.m_poly_y_radius = new System.Windows.Forms.NumericUpDown();
            this.m_poly_x_radius = new System.Windows.Forms.NumericUpDown();
            this.m_poly_radius = new System.Windows.Forms.NumericUpDown();
            this.m_cb_poly_tex_name = new System.Windows.Forms.ComboBox();
            this.m_tile_page = new System.Windows.Forms.TabPage();
            this.m_pointsListBox = new System.Windows.Forms.ListBox();
            this.m_pointsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.m_buffered_angleTextBox3 = new System.Windows.Forms.TextBox();
            this.m_nameTextBox3 = new System.Windows.Forms.TextBox();
            this.m_radiusTextBox4 = new System.Windows.Forms.TextBox();
            this.m_texture_nameTextBox4 = new System.Windows.Forms.TextBox();
            this.Alien = new System.Windows.Forms.TabPage();
            this.m_attack_speedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.alienBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.m_laser_slowdownNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_alien_color_alpha_changeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_alien_color_blue_changeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_alien_color_red_changeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_alien_color_green_changeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_rangeNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_move_stepNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_chase_distNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_attack_distNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_attack_powerNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_attack_rateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_ai_stateComboBox = new System.Windows.Forms.ComboBox();
            this.m_ai_type_changeComboBox = new System.Windows.Forms.ComboBox();
            this.m_kill_under_speedNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_collision_typeComboBox = new System.Windows.Forms.ComboBox();
            this.m_nameTextBox6 = new System.Windows.Forms.TextBox();
            this.m_typeComboBox1 = new System.Windows.Forms.ComboBox();
            this.m_trigger_page = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.m_continuous_checkCheckBox = new System.Windows.Forms.CheckBox();
            this.triggerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.if_deactivatorCheckBox = new System.Windows.Forms.CheckBox();
            this.m_trigger_items_clear = new System.Windows.Forms.Button();
            this.m_typeComboBox2 = new System.Windows.Forms.ComboBox();
            this.m_deactivatedCheckBox = new System.Windows.Forms.CheckBox();
            this.m_cooldownNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_activeCheckBox = new System.Windows.Forms.CheckBox();
            this.num_triggerable_objectsTextBox = new System.Windows.Forms.TextBox();
            this.m_remove_TriggerableObject = new System.Windows.Forms.Button();
            this.m_attach_triggerable_object_button = new System.Windows.Forms.Button();
            this.m_nameLabel4 = new System.Windows.Forms.Label();
            this.m_nameTextBox4 = new System.Windows.Forms.TextBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.m_tab_condition_trigger = new System.Windows.Forms.TabPage();
            this.m_condition_typeComboBox = new System.Windows.Forms.ComboBox();
            this.conditionTriggeredBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.num_cond_objectsTextBox = new System.Windows.Forms.TextBox();
            this.m_trig_objs_clear = new System.Windows.Forms.Button();
            this.m_cond_remove_obj = new System.Windows.Forms.Button();
            this.m_condition_add_obj = new System.Windows.Forms.Button();
            this.m_nameTextBox2 = new System.Windows.Forms.TextBox();
            this.m_triggerable_obj_tab = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button_trigobj_clear = new System.Windows.Forms.Button();
            this.button_trigobj_add_object = new System.Windows.Forms.Button();
            this.m_textbox_widthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.triggerableObjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.m_textTextBox = new System.Windows.Forms.TextBox();
            this.m_zoom_multNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_set_zoomNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_follow_meCheckBox = new System.Windows.Forms.CheckBox();
            this.m_timer_checkpoint_setNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_invisibleCheckBox = new System.Windows.Forms.CheckBox();
            this.m_lengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.m_is_activeLabel = new System.Windows.Forms.Label();
            this.m_is_activeCheckBox = new System.Windows.Forms.CheckBox();
            this.m_nameLabel5 = new System.Windows.Forms.Label();
            this.m_nameTextBox5 = new System.Windows.Forms.TextBox();
            this.m_typeLabel1 = new System.Windows.Forms.Label();
            this.m_typeComboBox = new System.Windows.Forms.ComboBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.button5 = new System.Windows.Forms.Button();
            this.m_fixture_tab = new System.Windows.Forms.TabPage();
            this.collidesWithComboBox = new System.Windows.Forms.ComboBox();
            this.childCountTextBox = new System.Windows.Forms.TextBox();
            this.densityNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.radiusNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.shapeTypeComboBox1 = new System.Windows.Forms.ComboBox();
            this.fixtureIdTextBox = new System.Windows.Forms.TextBox();
            this.frictionNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.isDisposedCheckBox1 = new System.Windows.Forms.CheckBox();
            this.isSensorCheckBox1 = new System.Windows.Forms.CheckBox();
            this.restitutionNumericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.copy_tab = new System.Windows.Forms.TabPage();
            this.copy_advanced_button = new System.Windows.Forms.Button();
            this.rb_copy_loc_same = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.rb_copy_loc_right = new System.Windows.Forms.RadioButton();
            this.rb_copy_loc_up = new System.Windows.Forms.RadioButton();
            this.rb_copy_loc_Left = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewLevelToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_Save = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mi_Load_Level = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tool_Insertion = new System.Windows.Forms.ToolStripButton();
            this.tool_Selection = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.copy = new System.Windows.Forms.ToolStripButton();
            this.panel_TextureList = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_rb_background_tile = new System.Windows.Forms.RadioButton();
            this.m_poly_create_lines = new System.Windows.Forms.Button();
            this.m_rb_poly_trigger = new System.Windows.Forms.RadioButton();
            this.m_rb_condition_trigger = new System.Windows.Forms.RadioButton();
            this.m_rb_tile = new System.Windows.Forms.RadioButton();
            this.m_rb_throwing = new System.Windows.Forms.RadioButton();
            this.apply = new System.Windows.Forms.Button();
            this.m_rb_gameObject = new System.Windows.Forms.RadioButton();
            this.m_rb_triggerable_object = new System.Windows.Forms.RadioButton();
            this.m_rb_trigger = new System.Windows.Forms.RadioButton();
            this.m_rb_Ninja = new System.Windows.Forms.RadioButton();
            this.m_rb_alien = new System.Windows.Forms.RadioButton();
            this.m_rb_Wall = new System.Windows.Forms.RadioButton();
            this.stateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tNamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.texture_namesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.staticsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.floorTileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.obj_countTextBox = new System.Windows.Forms.TextBox();
            m_typeLabel = new System.Windows.Forms.Label();
            m_nameLabel6 = new System.Windows.Forms.Label();
            m_texture_nameLabel4 = new System.Windows.Forms.Label();
            m_radiusLabel4 = new System.Windows.Forms.Label();
            m_nameLabel3 = new System.Windows.Forms.Label();
            m_buffered_angleLabel3 = new System.Windows.Forms.Label();
            m_nameLabel = new System.Windows.Forms.Label();
            m_is_throwableLabel3 = new System.Windows.Forms.Label();
            m_is_destructibleLabel3 = new System.Windows.Forms.Label();
            m_is_deadLabel = new System.Windows.Forms.Label();
            sleepingAllowedLabel = new System.Windows.Forms.Label();
            restitutionLabel = new System.Windows.Forms.Label();
            isStaticLabel = new System.Windows.Forms.Label();
            isDisposedLabel = new System.Windows.Forms.Label();
            isBulletLabel = new System.Windows.Forms.Label();
            ignoreGravityLabel = new System.Windows.Forms.Label();
            ignoreCCDLabel = new System.Windows.Forms.Label();
            frictionLabel = new System.Windows.Forms.Label();
            fixedRotationLabel = new System.Windows.Forms.Label();
            enabledLabel = new System.Windows.Forms.Label();
            awakeLabel = new System.Windows.Forms.Label();
            m_texture_nameLabel2 = new System.Windows.Forms.Label();
            bodyTypeLabel = new System.Windows.Forms.Label();
            massLabel = new System.Windows.Forms.Label();
            linearDampingLabel = new System.Windows.Forms.Label();
            inertiaLabel = new System.Windows.Forms.Label();
            m_destroy_thresholdLabel4 = new System.Windows.Forms.Label();
            m_change_sizeLabel = new System.Windows.Forms.Label();
            m_collision_typeLabel = new System.Windows.Forms.Label();
            m_kill_under_speedLabel1 = new System.Windows.Forms.Label();
            m_texture_name_changeLabel = new System.Windows.Forms.Label();
            isSensorLabel = new System.Windows.Forms.Label();
            densityLabel = new System.Windows.Forms.Label();
            shapeTypeLabel = new System.Windows.Forms.Label();
            fixtureIdLabel = new System.Windows.Forms.Label();
            frictionLabel1 = new System.Windows.Forms.Label();
            isDisposedLabel1 = new System.Windows.Forms.Label();
            isSensorLabel1 = new System.Windows.Forms.Label();
            restitutionLabel1 = new System.Windows.Forms.Label();
            childCountLabel = new System.Windows.Forms.Label();
            densityLabel1 = new System.Windows.Forms.Label();
            radiusLabel = new System.Windows.Forms.Label();
            shapeTypeLabel1 = new System.Windows.Forms.Label();
            collidesWithLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            rotationLabel = new System.Windows.Forms.Label();
            num_triggerable_objectsLabel = new System.Windows.Forms.Label();
            m_activeLabel = new System.Windows.Forms.Label();
            m_cooldownLabel = new System.Windows.Forms.Label();
            m_deactivatedLabel = new System.Windows.Forms.Label();
            m_typeLabel2 = new System.Windows.Forms.Label();
            m_ai_type_changeLabel = new System.Windows.Forms.Label();
            m_nameLabel2 = new System.Windows.Forms.Label();
            m_lengthLabel = new System.Windows.Forms.Label();
            num_cond_objectsLabel = new System.Windows.Forms.Label();
            m_condition_typeLabel = new System.Windows.Forms.Label();
            m_ai_stateLabel = new System.Windows.Forms.Label();
            m_attack_cooldownLabel = new System.Windows.Forms.Label();
            m_attack_powerLabel = new System.Windows.Forms.Label();
            m_attack_distLabel = new System.Windows.Forms.Label();
            m_chase_distLabel = new System.Windows.Forms.Label();
            m_move_stepLabel = new System.Windows.Forms.Label();
            m_rangeLabel = new System.Windows.Forms.Label();
            m_invisibleLabel = new System.Windows.Forms.Label();
            m_timer_checkpoint_setLabel = new System.Windows.Forms.Label();
            m_alien_color_green_changeLabel = new System.Windows.Forms.Label();
            m_alien_color_red_changeLabel = new System.Windows.Forms.Label();
            m_alien_color_blue_changeLabel = new System.Windows.Forms.Label();
            m_alien_color_alpha_changeLabel = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            m_change_size_xLabel = new System.Windows.Forms.Label();
            m_change_size_yLabel = new System.Windows.Forms.Label();
            m_follow_meLabel = new System.Windows.Forms.Label();
            m_set_zoomLabel = new System.Windows.Forms.Label();
            m_zoom_multLabel = new System.Windows.Forms.Label();
            m_laser_slowdownLabel = new System.Windows.Forms.Label();
            m_textLabel = new System.Windows.Forms.Label();
            m_textbox_widthLabel = new System.Windows.Forms.Label();
            m_attack_speedLabel = new System.Windows.Forms.Label();
            if_deactivatorLabel = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            m_disabledLabel = new System.Windows.Forms.Label();
            m_continuous_checkLabel = new System.Windows.Forms.Label();
            obj_countLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fixtureListBindingSource)).BeginInit();
            this.panel_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel_EditOptions.SuspendLayout();
            this.object_tabs.SuspendLayout();
            this.saveLoadObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectBindingSource)).BeginInit();
            this.m_game_object_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_change_sizeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_destroy_thresholdNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inertiaNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearDampingNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.massNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restitutionNumericUpDown)).BeginInit();
            this.m_ninja_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ninjaBindingSource)).BeginInit();
            this.PolygonObject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_change_size_yNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.polygonObjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_change_size_xNumericUpDown)).BeginInit();
            this.m_create_poly_from_texture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_angle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_y_scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_x_scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_num_edges)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_y_radius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_x_radius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_radius)).BeginInit();
            this.m_tile_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pointsBindingSource)).BeginInit();
            this.Alien.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_attack_speedNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alienBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_laser_slowdownNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_alien_color_alpha_changeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_alien_color_blue_changeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_alien_color_red_changeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_alien_color_green_changeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_rangeNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_move_stepNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_chase_distNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_attack_distNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_attack_powerNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_attack_rateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_kill_under_speedNumericUpDown)).BeginInit();
            this.m_trigger_page.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.triggerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_cooldownNumericUpDown)).BeginInit();
            this.m_tab_condition_trigger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conditionTriggeredBindingSource)).BeginInit();
            this.m_triggerable_obj_tab.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_textbox_widthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.triggerableObjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_zoom_multNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_set_zoomNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_timer_checkpoint_setNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_lengthNumericUpDown)).BeginInit();
            this.m_fixture_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.densityNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.frictionNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.restitutionNumericUpDown1)).BeginInit();
            this.copy_tab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel_TextureList.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNamesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture_namesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.staticsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorTileBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // m_typeLabel
            // 
            m_typeLabel.AutoSize = true;
            m_typeLabel.Location = new System.Drawing.Point(7, 145);
            m_typeLabel.Name = "m_typeLabel";
            m_typeLabel.Size = new System.Drawing.Size(41, 13);
            m_typeLabel.TabIndex = 16;
            m_typeLabel.Text = "m type:";
            // 
            // m_nameLabel6
            // 
            m_nameLabel6.AutoSize = true;
            m_nameLabel6.Location = new System.Drawing.Point(6, 42);
            m_nameLabel6.Name = "m_nameLabel6";
            m_nameLabel6.Size = new System.Drawing.Size(47, 13);
            m_nameLabel6.TabIndex = 10;
            m_nameLabel6.Text = "m name:";
            // 
            // m_texture_nameLabel4
            // 
            m_texture_nameLabel4.AutoSize = true;
            m_texture_nameLabel4.Location = new System.Drawing.Point(6, 101);
            m_texture_nameLabel4.Name = "m_texture_nameLabel4";
            m_texture_nameLabel4.Size = new System.Drawing.Size(82, 13);
            m_texture_nameLabel4.TabIndex = 6;
            m_texture_nameLabel4.Text = "m texture name:";
            // 
            // m_radiusLabel4
            // 
            m_radiusLabel4.AutoSize = true;
            m_radiusLabel4.Location = new System.Drawing.Point(6, 75);
            m_radiusLabel4.Name = "m_radiusLabel4";
            m_radiusLabel4.Size = new System.Drawing.Size(49, 13);
            m_radiusLabel4.TabIndex = 4;
            m_radiusLabel4.Text = "m radius:";
            // 
            // m_nameLabel3
            // 
            m_nameLabel3.AutoSize = true;
            m_nameLabel3.Location = new System.Drawing.Point(6, 49);
            m_nameLabel3.Name = "m_nameLabel3";
            m_nameLabel3.Size = new System.Drawing.Size(47, 13);
            m_nameLabel3.TabIndex = 2;
            m_nameLabel3.Text = "m name:";
            // 
            // m_buffered_angleLabel3
            // 
            m_buffered_angleLabel3.AutoSize = true;
            m_buffered_angleLabel3.Location = new System.Drawing.Point(6, 23);
            m_buffered_angleLabel3.Name = "m_buffered_angleLabel3";
            m_buffered_angleLabel3.Size = new System.Drawing.Size(89, 13);
            m_buffered_angleLabel3.TabIndex = 0;
            m_buffered_angleLabel3.Text = "m buffered angle:";
            // 
            // m_nameLabel
            // 
            m_nameLabel.AutoSize = true;
            m_nameLabel.Location = new System.Drawing.Point(3, 171);
            m_nameLabel.Name = "m_nameLabel";
            m_nameLabel.Size = new System.Drawing.Size(47, 13);
            m_nameLabel.TabIndex = 12;
            m_nameLabel.Text = "m name:";
            // 
            // m_is_throwableLabel3
            // 
            m_is_throwableLabel3.AutoSize = true;
            m_is_throwableLabel3.Location = new System.Drawing.Point(3, 143);
            m_is_throwableLabel3.Name = "m_is_throwableLabel3";
            m_is_throwableLabel3.Size = new System.Drawing.Size(77, 13);
            m_is_throwableLabel3.TabIndex = 10;
            m_is_throwableLabel3.Text = "m is throwable:";
            // 
            // m_is_destructibleLabel3
            // 
            m_is_destructibleLabel3.AutoSize = true;
            m_is_destructibleLabel3.Location = new System.Drawing.Point(3, 113);
            m_is_destructibleLabel3.Name = "m_is_destructibleLabel3";
            m_is_destructibleLabel3.Size = new System.Drawing.Size(85, 13);
            m_is_destructibleLabel3.TabIndex = 8;
            m_is_destructibleLabel3.Text = "m is destructible:";
            // 
            // m_is_deadLabel
            // 
            m_is_deadLabel.AutoSize = true;
            m_is_deadLabel.Location = new System.Drawing.Point(3, 83);
            m_is_deadLabel.Name = "m_is_deadLabel";
            m_is_deadLabel.Size = new System.Drawing.Size(55, 13);
            m_is_deadLabel.TabIndex = 6;
            m_is_deadLabel.Text = "m is dead:";
            // 
            // sleepingAllowedLabel
            // 
            sleepingAllowedLabel.AutoSize = true;
            sleepingAllowedLabel.Location = new System.Drawing.Point(3, 785);
            sleepingAllowedLabel.Name = "sleepingAllowedLabel";
            sleepingAllowedLabel.Size = new System.Drawing.Size(91, 13);
            sleepingAllowedLabel.TabIndex = 54;
            sleepingAllowedLabel.Text = "Sleeping Allowed:";
            // 
            // restitutionLabel
            // 
            restitutionLabel.AutoSize = true;
            restitutionLabel.Location = new System.Drawing.Point(3, 705);
            restitutionLabel.Name = "restitutionLabel";
            restitutionLabel.Size = new System.Drawing.Size(60, 13);
            restitutionLabel.TabIndex = 48;
            restitutionLabel.Text = "Restitution:";
            // 
            // isStaticLabel
            // 
            isStaticLabel.AutoSize = true;
            isStaticLabel.Location = new System.Drawing.Point(3, 625);
            isStaticLabel.Name = "isStaticLabel";
            isStaticLabel.Size = new System.Drawing.Size(48, 13);
            isStaticLabel.TabIndex = 42;
            isStaticLabel.Text = "Is Static:";
            // 
            // isDisposedLabel
            // 
            isDisposedLabel.AutoSize = true;
            isDisposedLabel.Location = new System.Drawing.Point(3, 595);
            isDisposedLabel.Name = "isDisposedLabel";
            isDisposedLabel.Size = new System.Drawing.Size(65, 13);
            isDisposedLabel.TabIndex = 40;
            isDisposedLabel.Text = "Is Disposed:";
            // 
            // isBulletLabel
            // 
            isBulletLabel.AutoSize = true;
            isBulletLabel.Location = new System.Drawing.Point(3, 565);
            isBulletLabel.Name = "isBulletLabel";
            isBulletLabel.Size = new System.Drawing.Size(47, 13);
            isBulletLabel.TabIndex = 38;
            isBulletLabel.Text = "Is Bullet:";
            // 
            // ignoreGravityLabel
            // 
            ignoreGravityLabel.AutoSize = true;
            ignoreGravityLabel.Location = new System.Drawing.Point(3, 509);
            ignoreGravityLabel.Name = "ignoreGravityLabel";
            ignoreGravityLabel.Size = new System.Drawing.Size(76, 13);
            ignoreGravityLabel.TabIndex = 34;
            ignoreGravityLabel.Text = "Ignore Gravity:";
            // 
            // ignoreCCDLabel
            // 
            ignoreCCDLabel.AutoSize = true;
            ignoreCCDLabel.Location = new System.Drawing.Point(3, 479);
            ignoreCCDLabel.Name = "ignoreCCDLabel";
            ignoreCCDLabel.Size = new System.Drawing.Size(65, 13);
            ignoreCCDLabel.TabIndex = 32;
            ignoreCCDLabel.Text = "Ignore CCD:";
            // 
            // frictionLabel
            // 
            frictionLabel.AutoSize = true;
            frictionLabel.Location = new System.Drawing.Point(3, 451);
            frictionLabel.Name = "frictionLabel";
            frictionLabel.Size = new System.Drawing.Size(44, 13);
            frictionLabel.TabIndex = 30;
            frictionLabel.Text = "Friction:";
            // 
            // fixedRotationLabel
            // 
            fixedRotationLabel.AutoSize = true;
            fixedRotationLabel.Location = new System.Drawing.Point(3, 423);
            fixedRotationLabel.Name = "fixedRotationLabel";
            fixedRotationLabel.Size = new System.Drawing.Size(78, 13);
            fixedRotationLabel.TabIndex = 28;
            fixedRotationLabel.Text = "Fixed Rotation:";
            // 
            // enabledLabel
            // 
            enabledLabel.AutoSize = true;
            enabledLabel.Location = new System.Drawing.Point(3, 393);
            enabledLabel.Name = "enabledLabel";
            enabledLabel.Size = new System.Drawing.Size(49, 13);
            enabledLabel.TabIndex = 26;
            enabledLabel.Text = "Enabled:";
            // 
            // awakeLabel
            // 
            awakeLabel.AutoSize = true;
            awakeLabel.Location = new System.Drawing.Point(3, 337);
            awakeLabel.Name = "awakeLabel";
            awakeLabel.Size = new System.Drawing.Size(43, 13);
            awakeLabel.TabIndex = 22;
            awakeLabel.Text = "Awake:";
            // 
            // m_texture_nameLabel2
            // 
            m_texture_nameLabel2.AutoSize = true;
            m_texture_nameLabel2.Location = new System.Drawing.Point(6, 61);
            m_texture_nameLabel2.Name = "m_texture_nameLabel2";
            m_texture_nameLabel2.Size = new System.Drawing.Size(82, 13);
            m_texture_nameLabel2.TabIndex = 26;
            m_texture_nameLabel2.Text = "m texture name:";
            // 
            // bodyTypeLabel
            // 
            bodyTypeLabel.AutoSize = true;
            bodyTypeLabel.Location = new System.Drawing.Point(4, 256);
            bodyTypeLabel.Name = "bodyTypeLabel";
            bodyTypeLabel.Size = new System.Drawing.Size(61, 13);
            bodyTypeLabel.TabIndex = 55;
            bodyTypeLabel.Text = "Body Type:";
            // 
            // massLabel
            // 
            massLabel.AutoSize = true;
            massLabel.Location = new System.Drawing.Point(2, 650);
            massLabel.Name = "massLabel";
            massLabel.Size = new System.Drawing.Size(35, 13);
            massLabel.TabIndex = 74;
            massLabel.Text = "Mass:";
            // 
            // linearDampingLabel
            // 
            linearDampingLabel.AutoSize = true;
            linearDampingLabel.Location = new System.Drawing.Point(1, 676);
            linearDampingLabel.Name = "linearDampingLabel";
            linearDampingLabel.Size = new System.Drawing.Size(84, 13);
            linearDampingLabel.TabIndex = 75;
            linearDampingLabel.Text = "Linear Damping:";
            // 
            // inertiaLabel
            // 
            inertiaLabel.AutoSize = true;
            inertiaLabel.Location = new System.Drawing.Point(11, 535);
            inertiaLabel.Name = "inertiaLabel";
            inertiaLabel.Size = new System.Drawing.Size(39, 13);
            inertiaLabel.TabIndex = 76;
            inertiaLabel.Text = "Inertia:";
            // 
            // m_destroy_thresholdLabel4
            // 
            m_destroy_thresholdLabel4.AutoSize = true;
            m_destroy_thresholdLabel4.Location = new System.Drawing.Point(2, 45);
            m_destroy_thresholdLabel4.Name = "m_destroy_thresholdLabel4";
            m_destroy_thresholdLabel4.Size = new System.Drawing.Size(101, 13);
            m_destroy_thresholdLabel4.TabIndex = 80;
            m_destroy_thresholdLabel4.Text = "m destroy threshold:";
            // 
            // m_change_sizeLabel
            // 
            m_change_sizeLabel.AutoSize = true;
            m_change_sizeLabel.Location = new System.Drawing.Point(3, 202);
            m_change_sizeLabel.Name = "m_change_sizeLabel";
            m_change_sizeLabel.Size = new System.Drawing.Size(78, 13);
            m_change_sizeLabel.TabIndex = 81;
            m_change_sizeLabel.Text = "m change size:";
            // 
            // m_collision_typeLabel
            // 
            m_collision_typeLabel.AutoSize = true;
            m_collision_typeLabel.Location = new System.Drawing.Point(7, 180);
            m_collision_typeLabel.Name = "m_collision_typeLabel";
            m_collision_typeLabel.Size = new System.Drawing.Size(81, 13);
            m_collision_typeLabel.TabIndex = 17;
            m_collision_typeLabel.Text = "m collision type:";
            // 
            // m_kill_under_speedLabel1
            // 
            m_kill_under_speedLabel1.AutoSize = true;
            m_kill_under_speedLabel1.Location = new System.Drawing.Point(7, 111);
            m_kill_under_speedLabel1.Name = "m_kill_under_speedLabel1";
            m_kill_under_speedLabel1.Size = new System.Drawing.Size(95, 13);
            m_kill_under_speedLabel1.TabIndex = 18;
            m_kill_under_speedLabel1.Text = "m kill under speed:";
            // 
            // m_texture_name_changeLabel
            // 
            m_texture_name_changeLabel.AutoSize = true;
            m_texture_name_changeLabel.Location = new System.Drawing.Point(2, 291);
            m_texture_name_changeLabel.Name = "m_texture_name_changeLabel";
            m_texture_name_changeLabel.Size = new System.Drawing.Size(121, 13);
            m_texture_name_changeLabel.TabIndex = 82;
            m_texture_name_changeLabel.Text = "m texture name change:";
            // 
            // isSensorLabel
            // 
            isSensorLabel.AutoSize = true;
            isSensorLabel.Location = new System.Drawing.Point(3, 811);
            isSensorLabel.Name = "isSensorLabel";
            isSensorLabel.Size = new System.Drawing.Size(54, 13);
            isSensorLabel.TabIndex = 83;
            isSensorLabel.Text = "Is Sensor:";
            // 
            // densityLabel
            // 
            densityLabel.AutoSize = true;
            densityLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fixtureListBindingSource, "Shape.ShapeType", true));
            densityLabel.Location = new System.Drawing.Point(2, 836);
            densityLabel.Name = "densityLabel";
            densityLabel.Size = new System.Drawing.Size(45, 13);
            densityLabel.TabIndex = 84;
            densityLabel.Text = "Density:";
            // 
            // fixtureListBindingSource
            // 
            this.fixtureListBindingSource.DataSource = typeof(FarseerPhysics.Dynamics.Fixture);
            // 
            // shapeTypeLabel
            // 
            shapeTypeLabel.AutoSize = true;
            shapeTypeLabel.Location = new System.Drawing.Point(3, 860);
            shapeTypeLabel.Name = "shapeTypeLabel";
            shapeTypeLabel.Size = new System.Drawing.Size(68, 13);
            shapeTypeLabel.TabIndex = 85;
            shapeTypeLabel.Text = "Shape Type:";
            // 
            // fixtureIdLabel
            // 
            fixtureIdLabel.AutoSize = true;
            fixtureIdLabel.Location = new System.Drawing.Point(38, 64);
            fixtureIdLabel.Name = "fixtureIdLabel";
            fixtureIdLabel.Size = new System.Drawing.Size(53, 13);
            fixtureIdLabel.TabIndex = 2;
            fixtureIdLabel.Text = "Fixture Id:";
            // 
            // frictionLabel1
            // 
            frictionLabel1.AutoSize = true;
            frictionLabel1.Location = new System.Drawing.Point(38, 87);
            frictionLabel1.Name = "frictionLabel1";
            frictionLabel1.Size = new System.Drawing.Size(44, 13);
            frictionLabel1.TabIndex = 4;
            frictionLabel1.Text = "Friction:";
            // 
            // isDisposedLabel1
            // 
            isDisposedLabel1.AutoSize = true;
            isDisposedLabel1.Location = new System.Drawing.Point(38, 118);
            isDisposedLabel1.Name = "isDisposedLabel1";
            isDisposedLabel1.Size = new System.Drawing.Size(65, 13);
            isDisposedLabel1.TabIndex = 6;
            isDisposedLabel1.Text = "Is Disposed:";
            // 
            // isSensorLabel1
            // 
            isSensorLabel1.AutoSize = true;
            isSensorLabel1.Location = new System.Drawing.Point(38, 148);
            isSensorLabel1.Name = "isSensorLabel1";
            isSensorLabel1.Size = new System.Drawing.Size(54, 13);
            isSensorLabel1.TabIndex = 8;
            isSensorLabel1.Text = "Is Sensor:";
            // 
            // restitutionLabel1
            // 
            restitutionLabel1.AutoSize = true;
            restitutionLabel1.Location = new System.Drawing.Point(38, 173);
            restitutionLabel1.Name = "restitutionLabel1";
            restitutionLabel1.Size = new System.Drawing.Size(60, 13);
            restitutionLabel1.TabIndex = 10;
            restitutionLabel1.Text = "Restitution:";
            // 
            // childCountLabel
            // 
            childCountLabel.AutoSize = true;
            childCountLabel.Location = new System.Drawing.Point(38, 236);
            childCountLabel.Name = "childCountLabel";
            childCountLabel.Size = new System.Drawing.Size(64, 13);
            childCountLabel.TabIndex = 12;
            childCountLabel.Text = "Child Count:";
            // 
            // densityLabel1
            // 
            densityLabel1.AutoSize = true;
            densityLabel1.Location = new System.Drawing.Point(38, 259);
            densityLabel1.Name = "densityLabel1";
            densityLabel1.Size = new System.Drawing.Size(45, 13);
            densityLabel1.TabIndex = 14;
            densityLabel1.Text = "Density:";
            // 
            // radiusLabel
            // 
            radiusLabel.AutoSize = true;
            radiusLabel.Location = new System.Drawing.Point(38, 285);
            radiusLabel.Name = "radiusLabel";
            radiusLabel.Size = new System.Drawing.Size(43, 13);
            radiusLabel.TabIndex = 16;
            radiusLabel.Text = "Radius:";
            // 
            // shapeTypeLabel1
            // 
            shapeTypeLabel1.AutoSize = true;
            shapeTypeLabel1.Location = new System.Drawing.Point(38, 314);
            shapeTypeLabel1.Name = "shapeTypeLabel1";
            shapeTypeLabel1.Size = new System.Drawing.Size(68, 13);
            shapeTypeLabel1.TabIndex = 18;
            shapeTypeLabel1.Text = "Shape Type:";
            // 
            // collidesWithLabel
            // 
            collidesWithLabel.AutoSize = true;
            collidesWithLabel.Location = new System.Drawing.Point(38, 36);
            collidesWithLabel.Name = "collidesWithLabel";
            collidesWithLabel.Size = new System.Drawing.Size(71, 13);
            collidesWithLabel.TabIndex = 19;
            collidesWithLabel.Text = "Collides With:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 146);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(99, 13);
            label1.TabIndex = 85;
            label1.Text = "radius(Circles,Arcs):";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 183);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(91, 13);
            label2.TabIndex = 87;
            label2.Text = "xRadius or Width:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(10, 196);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(96, 13);
            label3.TabIndex = 89;
            label3.Text = "yRadius or Length:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(10, 106);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(122, 13);
            label4.TabIndex = 91;
            label4.Text = "Number of Edges(round)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(10, 271);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(103, 13);
            label5.TabIndex = 95;
            label5.Text = "PolyTexture Y Scale";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(10, 258);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(103, 13);
            label6.TabIndex = 93;
            label6.Text = "PolyTexture X Scale";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(10, 302);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(77, 13);
            label7.TabIndex = 98;
            label7.Text = "Angle(radians):";
            // 
            // rotationLabel
            // 
            rotationLabel.AutoSize = true;
            rotationLabel.Location = new System.Drawing.Point(2, 744);
            rotationLabel.Name = "rotationLabel";
            rotationLabel.Size = new System.Drawing.Size(50, 13);
            rotationLabel.TabIndex = 86;
            rotationLabel.Text = "Rotation:";
            // 
            // num_triggerable_objectsLabel
            // 
            num_triggerable_objectsLabel.AutoSize = true;
            num_triggerable_objectsLabel.Location = new System.Drawing.Point(30, 147);
            num_triggerable_objectsLabel.Name = "num_triggerable_objectsLabel";
            num_triggerable_objectsLabel.Size = new System.Drawing.Size(119, 13);
            num_triggerable_objectsLabel.TabIndex = 15;
            num_triggerable_objectsLabel.Text = "num triggerable objects:";
            // 
            // m_activeLabel
            // 
            m_activeLabel.AutoSize = true;
            m_activeLabel.Location = new System.Drawing.Point(30, 121);
            m_activeLabel.Name = "m_activeLabel";
            m_activeLabel.Size = new System.Drawing.Size(50, 13);
            m_activeLabel.TabIndex = 16;
            m_activeLabel.Text = "m active:";
            // 
            // m_cooldownLabel
            // 
            m_cooldownLabel.AutoSize = true;
            m_cooldownLabel.Location = new System.Drawing.Point(30, 170);
            m_cooldownLabel.Name = "m_cooldownLabel";
            m_cooldownLabel.Size = new System.Drawing.Size(67, 13);
            m_cooldownLabel.TabIndex = 17;
            m_cooldownLabel.Text = "m cooldown:";
            // 
            // m_deactivatedLabel
            // 
            m_deactivatedLabel.AutoSize = true;
            m_deactivatedLabel.Location = new System.Drawing.Point(33, 227);
            m_deactivatedLabel.Name = "m_deactivatedLabel";
            m_deactivatedLabel.Size = new System.Drawing.Size(77, 13);
            m_deactivatedLabel.TabIndex = 18;
            m_deactivatedLabel.Text = "m deactivated:";
            // 
            // m_typeLabel2
            // 
            m_typeLabel2.AutoSize = true;
            m_typeLabel2.Location = new System.Drawing.Point(51, 281);
            m_typeLabel2.Name = "m_typeLabel2";
            m_typeLabel2.Size = new System.Drawing.Size(41, 13);
            m_typeLabel2.TabIndex = 19;
            m_typeLabel2.Text = "m type:";
            // 
            // m_ai_type_changeLabel
            // 
            m_ai_type_changeLabel.AutoSize = true;
            m_ai_type_changeLabel.Location = new System.Drawing.Point(6, 207);
            m_ai_type_changeLabel.Name = "m_ai_type_changeLabel";
            m_ai_type_changeLabel.Size = new System.Drawing.Size(91, 13);
            m_ai_type_changeLabel.TabIndex = 19;
            m_ai_type_changeLabel.Text = "m ai type change:";
            // 
            // m_nameLabel2
            // 
            m_nameLabel2.AutoSize = true;
            m_nameLabel2.Location = new System.Drawing.Point(32, 136);
            m_nameLabel2.Name = "m_nameLabel2";
            m_nameLabel2.Size = new System.Drawing.Size(47, 13);
            m_nameLabel2.TabIndex = 0;
            m_nameLabel2.Text = "m name:";
            // 
            // m_lengthLabel
            // 
            m_lengthLabel.AutoSize = true;
            m_lengthLabel.Location = new System.Drawing.Point(0, 117);
            m_lengthLabel.Name = "m_lengthLabel";
            m_lengthLabel.Size = new System.Drawing.Size(50, 13);
            m_lengthLabel.TabIndex = 19;
            m_lengthLabel.Text = "m length:";
            // 
            // num_cond_objectsLabel
            // 
            num_cond_objectsLabel.AutoSize = true;
            num_cond_objectsLabel.Location = new System.Drawing.Point(11, 177);
            num_cond_objectsLabel.Name = "num_cond_objectsLabel";
            num_cond_objectsLabel.Size = new System.Drawing.Size(94, 13);
            num_cond_objectsLabel.TabIndex = 22;
            num_cond_objectsLabel.Text = "num cond objects:";
            // 
            // m_condition_typeLabel
            // 
            m_condition_typeLabel.AutoSize = true;
            m_condition_typeLabel.Location = new System.Drawing.Point(22, 240);
            m_condition_typeLabel.Name = "m_condition_typeLabel";
            m_condition_typeLabel.Size = new System.Drawing.Size(87, 13);
            m_condition_typeLabel.TabIndex = 23;
            m_condition_typeLabel.Text = "m condition type:";
            // 
            // m_ai_stateLabel
            // 
            m_ai_stateLabel.AutoSize = true;
            m_ai_stateLabel.Location = new System.Drawing.Point(32, 230);
            m_ai_stateLabel.Name = "m_ai_stateLabel";
            m_ai_stateLabel.Size = new System.Drawing.Size(55, 13);
            m_ai_stateLabel.TabIndex = 20;
            m_ai_stateLabel.Text = "m ai state:";
            // 
            // m_attack_cooldownLabel
            // 
            m_attack_cooldownLabel.AutoSize = true;
            m_attack_cooldownLabel.Location = new System.Drawing.Point(6, 277);
            m_attack_cooldownLabel.Name = "m_attack_cooldownLabel";
            m_attack_cooldownLabel.Size = new System.Drawing.Size(117, 13);
            m_attack_cooldownLabel.TabIndex = 21;
            m_attack_cooldownLabel.Text = "m attack rate in frames:";
            // 
            // m_attack_powerLabel
            // 
            m_attack_powerLabel.AutoSize = true;
            m_attack_powerLabel.Location = new System.Drawing.Point(23, 335);
            m_attack_powerLabel.Name = "m_attack_powerLabel";
            m_attack_powerLabel.Size = new System.Drawing.Size(83, 13);
            m_attack_powerLabel.TabIndex = 22;
            m_attack_powerLabel.Text = "m attack power:";
            // 
            // m_attack_distLabel
            // 
            m_attack_distLabel.AutoSize = true;
            m_attack_distLabel.Location = new System.Drawing.Point(36, 363);
            m_attack_distLabel.Name = "m_attack_distLabel";
            m_attack_distLabel.Size = new System.Drawing.Size(70, 13);
            m_attack_distLabel.TabIndex = 23;
            m_attack_distLabel.Text = "m attack dist:";
            // 
            // m_chase_distLabel
            // 
            m_chase_distLabel.AutoSize = true;
            m_chase_distLabel.Location = new System.Drawing.Point(40, 389);
            m_chase_distLabel.Name = "m_chase_distLabel";
            m_chase_distLabel.Size = new System.Drawing.Size(69, 13);
            m_chase_distLabel.TabIndex = 24;
            m_chase_distLabel.Text = "m chase dist:";
            // 
            // m_move_stepLabel
            // 
            m_move_stepLabel.AutoSize = true;
            m_move_stepLabel.Location = new System.Drawing.Point(40, 421);
            m_move_stepLabel.Name = "m_move_stepLabel";
            m_move_stepLabel.Size = new System.Drawing.Size(70, 13);
            m_move_stepLabel.TabIndex = 25;
            m_move_stepLabel.Text = "m move step:";
            // 
            // m_rangeLabel
            // 
            m_rangeLabel.AutoSize = true;
            m_rangeLabel.Location = new System.Drawing.Point(61, 449);
            m_rangeLabel.Name = "m_rangeLabel";
            m_rangeLabel.Size = new System.Drawing.Size(48, 13);
            m_rangeLabel.TabIndex = 26;
            m_rangeLabel.Text = "m range:";
            // 
            // m_invisibleLabel
            // 
            m_invisibleLabel.AutoSize = true;
            m_invisibleLabel.Location = new System.Drawing.Point(8, 56);
            m_invisibleLabel.Name = "m_invisibleLabel";
            m_invisibleLabel.Size = new System.Drawing.Size(58, 13);
            m_invisibleLabel.TabIndex = 20;
            m_invisibleLabel.Text = "m invisible:";
            // 
            // m_timer_checkpoint_setLabel
            // 
            m_timer_checkpoint_setLabel.AutoSize = true;
            m_timer_checkpoint_setLabel.Location = new System.Drawing.Point(10, 281);
            m_timer_checkpoint_setLabel.Name = "m_timer_checkpoint_setLabel";
            m_timer_checkpoint_setLabel.Size = new System.Drawing.Size(87, 13);
            m_timer_checkpoint_setLabel.TabIndex = 21;
            m_timer_checkpoint_setLabel.Text = "timer reset value:";
            // 
            // m_alien_color_green_changeLabel
            // 
            m_alien_color_green_changeLabel.AutoSize = true;
            m_alien_color_green_changeLabel.Location = new System.Drawing.Point(32, 497);
            m_alien_color_green_changeLabel.Name = "m_alien_color_green_changeLabel";
            m_alien_color_green_changeLabel.Size = new System.Drawing.Size(138, 13);
            m_alien_color_green_changeLabel.TabIndex = 27;
            m_alien_color_green_changeLabel.Text = "m alien color green change:";
            // 
            // m_alien_color_red_changeLabel
            // 
            m_alien_color_red_changeLabel.AutoSize = true;
            m_alien_color_red_changeLabel.Location = new System.Drawing.Point(44, 472);
            m_alien_color_red_changeLabel.Name = "m_alien_color_red_changeLabel";
            m_alien_color_red_changeLabel.Size = new System.Drawing.Size(126, 13);
            m_alien_color_red_changeLabel.TabIndex = 28;
            m_alien_color_red_changeLabel.Text = "m alien color red change:";
            // 
            // m_alien_color_blue_changeLabel
            // 
            m_alien_color_blue_changeLabel.AutoSize = true;
            m_alien_color_blue_changeLabel.Location = new System.Drawing.Point(32, 522);
            m_alien_color_blue_changeLabel.Name = "m_alien_color_blue_changeLabel";
            m_alien_color_blue_changeLabel.Size = new System.Drawing.Size(131, 13);
            m_alien_color_blue_changeLabel.TabIndex = 29;
            m_alien_color_blue_changeLabel.Text = "m alien color blue change:";
            // 
            // m_alien_color_alpha_changeLabel
            // 
            m_alien_color_alpha_changeLabel.AutoSize = true;
            m_alien_color_alpha_changeLabel.Location = new System.Drawing.Point(36, 550);
            m_alien_color_alpha_changeLabel.Name = "m_alien_color_alpha_changeLabel";
            m_alien_color_alpha_changeLabel.Size = new System.Drawing.Size(137, 13);
            m_alien_color_alpha_changeLabel.TabIndex = 30;
            m_alien_color_alpha_changeLabel.Text = "m alien color alpha change:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(31, 25);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(47, 13);
            label8.TabIndex = 14;
            label8.Text = "m name:";
            // 
            // m_change_size_xLabel
            // 
            m_change_size_xLabel.AutoSize = true;
            m_change_size_xLabel.Location = new System.Drawing.Point(30, 59);
            m_change_size_xLabel.Name = "m_change_size_xLabel";
            m_change_size_xLabel.Size = new System.Drawing.Size(86, 13);
            m_change_size_xLabel.TabIndex = 0;
            m_change_size_xLabel.Text = "m change size x:";
            // 
            // m_change_size_yLabel
            // 
            m_change_size_yLabel.AutoSize = true;
            m_change_size_yLabel.Location = new System.Drawing.Point(30, 100);
            m_change_size_yLabel.Name = "m_change_size_yLabel";
            m_change_size_yLabel.Size = new System.Drawing.Size(86, 13);
            m_change_size_yLabel.TabIndex = 2;
            m_change_size_yLabel.Text = "m change size y:";
            // 
            // m_follow_meLabel
            // 
            m_follow_meLabel.AutoSize = true;
            m_follow_meLabel.Location = new System.Drawing.Point(153, 56);
            m_follow_meLabel.Name = "m_follow_meLabel";
            m_follow_meLabel.Size = new System.Drawing.Size(65, 13);
            m_follow_meLabel.TabIndex = 22;
            m_follow_meLabel.Text = "m follow me:";
            // 
            // m_set_zoomLabel
            // 
            m_set_zoomLabel.AutoSize = true;
            m_set_zoomLabel.Location = new System.Drawing.Point(105, 304);
            m_set_zoomLabel.Name = "m_set_zoomLabel";
            m_set_zoomLabel.Size = new System.Drawing.Size(63, 13);
            m_set_zoomLabel.TabIndex = 23;
            m_set_zoomLabel.Text = "m set zoom:";
            // 
            // m_zoom_multLabel
            // 
            m_zoom_multLabel.AutoSize = true;
            m_zoom_multLabel.Location = new System.Drawing.Point(27, 328);
            m_zoom_multLabel.Name = "m_zoom_multLabel";
            m_zoom_multLabel.Size = new System.Drawing.Size(68, 13);
            m_zoom_multLabel.TabIndex = 24;
            m_zoom_multLabel.Text = "m zoom mult:";
            // 
            // m_laser_slowdownLabel
            // 
            m_laser_slowdownLabel.AutoSize = true;
            m_laser_slowdownLabel.Location = new System.Drawing.Point(30, 306);
            m_laser_slowdownLabel.Name = "m_laser_slowdownLabel";
            m_laser_slowdownLabel.Size = new System.Drawing.Size(93, 13);
            m_laser_slowdownLabel.TabIndex = 32;
            m_laser_slowdownLabel.Text = "m laser slowdown:";
            // 
            // m_textLabel
            // 
            m_textLabel.AutoSize = true;
            m_textLabel.Location = new System.Drawing.Point(27, 227);
            m_textLabel.Name = "m_textLabel";
            m_textLabel.Size = new System.Drawing.Size(75, 13);
            m_textLabel.TabIndex = 25;
            m_textLabel.Text = "Hint Message:";
            // 
            // m_textbox_widthLabel
            // 
            m_textbox_widthLabel.AutoSize = true;
            m_textbox_widthLabel.Location = new System.Drawing.Point(17, 257);
            m_textbox_widthLabel.Name = "m_textbox_widthLabel";
            m_textbox_widthLabel.Size = new System.Drawing.Size(83, 13);
            m_textbox_widthLabel.TabIndex = 26;
            m_textbox_widthLabel.Text = "m textbox width:";
            // 
            // m_attack_speedLabel
            // 
            m_attack_speedLabel.AutoSize = true;
            m_attack_speedLabel.Location = new System.Drawing.Point(4, 253);
            m_attack_speedLabel.Name = "m_attack_speedLabel";
            m_attack_speedLabel.Size = new System.Drawing.Size(115, 13);
            m_attack_speedLabel.TabIndex = 34;
            m_attack_speedLabel.Text = "Laser Launch Velocity:";
            // 
            // if_deactivatorLabel
            // 
            if_deactivatorLabel.AutoSize = true;
            if_deactivatorLabel.Location = new System.Drawing.Point(133, 330);
            if_deactivatorLabel.Name = "if_deactivatorLabel";
            if_deactivatorLabel.Size = new System.Drawing.Size(71, 13);
            if_deactivatorLabel.TabIndex = 21;
            if_deactivatorLabel.Text = "if deactivator:";
            // 
            // label9
            // 
            label9.AllowDrop = true;
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(3, 35);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(91, 13);
            label9.TabIndex = 93;
            label9.Text = "Number of Copies";
            // 
            // label10
            // 
            label10.AllowDrop = true;
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(12, 85);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(75, 13);
            label10.TabIndex = 99;
            label10.Text = "Copy Location";
            // 
            // m_disabledLabel
            // 
            m_disabledLabel.AutoSize = true;
            m_disabledLabel.Location = new System.Drawing.Point(5, 233);
            m_disabledLabel.Name = "m_disabledLabel";
            m_disabledLabel.Size = new System.Drawing.Size(60, 13);
            m_disabledLabel.TabIndex = 87;
            m_disabledLabel.Text = "m disabled:";
            // 
            // m_continuous_checkLabel
            // 
            m_continuous_checkLabel.AutoSize = true;
            m_continuous_checkLabel.Location = new System.Drawing.Point(4, 250);
            m_continuous_checkLabel.Name = "m_continuous_checkLabel";
            m_continuous_checkLabel.Size = new System.Drawing.Size(106, 13);
            m_continuous_checkLabel.TabIndex = 22;
            m_continuous_checkLabel.Text = "m continuous check:";
            // 
            // m_throw_powerLabel
            // 
            this.m_throw_powerLabel.AutoSize = true;
            this.m_throw_powerLabel.Location = new System.Drawing.Point(0, 157);
            this.m_throw_powerLabel.Name = "m_throw_powerLabel";
            this.m_throw_powerLabel.Size = new System.Drawing.Size(79, 13);
            this.m_throw_powerLabel.TabIndex = 26;
            this.m_throw_powerLabel.Text = "m throw power:";
            // 
            // m_speedLabel
            // 
            this.m_speedLabel.AutoSize = true;
            this.m_speedLabel.Location = new System.Drawing.Point(-2, 228);
            this.m_speedLabel.Name = "m_speedLabel";
            this.m_speedLabel.Size = new System.Drawing.Size(50, 13);
            this.m_speedLabel.TabIndex = 22;
            this.m_speedLabel.Text = "m speed:";
            // 
            // m_picking_upLabel
            // 
            this.m_picking_upLabel.AutoSize = true;
            this.m_picking_upLabel.Location = new System.Drawing.Point(0, 192);
            this.m_picking_upLabel.Name = "m_picking_upLabel";
            this.m_picking_upLabel.Size = new System.Drawing.Size(70, 13);
            this.m_picking_upLabel.TabIndex = 18;
            this.m_picking_upLabel.Text = "m picking up:";
            // 
            // m_nameLabel1
            // 
            this.m_nameLabel1.AutoSize = true;
            this.m_nameLabel1.Location = new System.Drawing.Point(3, 127);
            this.m_nameLabel1.Name = "m_nameLabel1";
            this.m_nameLabel1.Size = new System.Drawing.Size(47, 13);
            this.m_nameLabel1.TabIndex = 16;
            this.m_nameLabel1.Text = "m name:";
            // 
            // m_movement_accelLabel
            // 
            this.m_movement_accelLabel.AutoSize = true;
            this.m_movement_accelLabel.Location = new System.Drawing.Point(3, 101);
            this.m_movement_accelLabel.Name = "m_movement_accelLabel";
            this.m_movement_accelLabel.Size = new System.Drawing.Size(99, 13);
            this.m_movement_accelLabel.TabIndex = 14;
            this.m_movement_accelLabel.Text = "m movement accel:";
            // 
            // m_maxspeedLabel
            // 
            this.m_maxspeedLabel.AutoSize = true;
            this.m_maxspeedLabel.Location = new System.Drawing.Point(3, 75);
            this.m_maxspeedLabel.Name = "m_maxspeedLabel";
            this.m_maxspeedLabel.Size = new System.Drawing.Size(69, 13);
            this.m_maxspeedLabel.TabIndex = 12;
            this.m_maxspeedLabel.Text = "m maxspeed:";
            // 
            // m_max_throwable_capacityLabel
            // 
            this.m_max_throwable_capacityLabel.AutoSize = true;
            this.m_max_throwable_capacityLabel.Location = new System.Drawing.Point(3, 49);
            this.m_max_throwable_capacityLabel.Name = "m_max_throwable_capacityLabel";
            this.m_max_throwable_capacityLabel.Size = new System.Drawing.Size(132, 13);
            this.m_max_throwable_capacityLabel.TabIndex = 10;
            this.m_max_throwable_capacityLabel.Text = "m max throwable capacity:";
            // 
            // m_is_killedLabel
            // 
            this.m_is_killedLabel.AutoSize = true;
            this.m_is_killedLabel.Location = new System.Drawing.Point(3, 21);
            this.m_is_killedLabel.Name = "m_is_killedLabel";
            this.m_is_killedLabel.Size = new System.Drawing.Size(55, 13);
            this.m_is_killedLabel.TabIndex = 8;
            this.m_is_killedLabel.Text = "m is killed:";
            // 
            // panel_Main
            // 
            this.panel_Main.Controls.Add(this.splitContainer2);
            this.panel_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Main.Location = new System.Drawing.Point(0, 0);
            this.panel_Main.Name = "panel_Main";
            this.panel_Main.Size = new System.Drawing.Size(332, 573);
            this.panel_Main.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel_EditOptions);
            this.splitContainer2.Panel1.Controls.Add(this.menuStrip1);
            this.splitContainer2.Panel1.Controls.Add(this.toolStrip1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel_TextureList);
            this.splitContainer2.Size = new System.Drawing.Size(332, 573);
            this.splitContainer2.SplitterDistance = 439;
            this.splitContainer2.TabIndex = 1;
            // 
            // panel_EditOptions
            // 
            this.panel_EditOptions.Controls.Add(this.object_tabs);
            this.panel_EditOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_EditOptions.Location = new System.Drawing.Point(0, 49);
            this.panel_EditOptions.Name = "panel_EditOptions";
            this.panel_EditOptions.Size = new System.Drawing.Size(328, 386);
            this.panel_EditOptions.TabIndex = 12;
            // 
            // object_tabs
            // 
            this.object_tabs.Controls.Add(this.saveLoadObject);
            this.object_tabs.Controls.Add(this.m_game_object_page);
            this.object_tabs.Controls.Add(this.m_ninja_page);
            this.object_tabs.Controls.Add(this.PolygonObject);
            this.object_tabs.Controls.Add(this.m_create_poly_from_texture);
            this.object_tabs.Controls.Add(this.m_tile_page);
            this.object_tabs.Controls.Add(this.Alien);
            this.object_tabs.Controls.Add(this.m_trigger_page);
            this.object_tabs.Controls.Add(this.m_tab_condition_trigger);
            this.object_tabs.Controls.Add(this.m_triggerable_obj_tab);
            this.object_tabs.Controls.Add(this.m_fixture_tab);
            this.object_tabs.Controls.Add(this.copy_tab);
            this.object_tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.object_tabs.Location = new System.Drawing.Point(0, 0);
            this.object_tabs.Name = "object_tabs";
            this.object_tabs.SelectedIndex = 0;
            this.object_tabs.Size = new System.Drawing.Size(328, 386);
            this.object_tabs.TabIndex = 1;
            // 
            // saveLoadObject
            // 
            this.saveLoadObject.Controls.Add(this.update_object_list);
            this.saveLoadObject.Controls.Add(this.load_items_listbox);
            this.saveLoadObject.Controls.Add(this.load_object);
            this.saveLoadObject.Controls.Add(this.save_object_to_name);
            this.saveLoadObject.Controls.Add(this.textBox1);
            this.saveLoadObject.Controls.Add(label8);
            this.saveLoadObject.Location = new System.Drawing.Point(4, 22);
            this.saveLoadObject.Name = "saveLoadObject";
            this.saveLoadObject.Padding = new System.Windows.Forms.Padding(3);
            this.saveLoadObject.Size = new System.Drawing.Size(320, 360);
            this.saveLoadObject.TabIndex = 17;
            this.saveLoadObject.Text = "save/load object";
            this.saveLoadObject.UseVisualStyleBackColor = true;
            // 
            // update_object_list
            // 
            this.update_object_list.Location = new System.Drawing.Point(232, 68);
            this.update_object_list.Name = "update_object_list";
            this.update_object_list.Size = new System.Drawing.Size(82, 39);
            this.update_object_list.TabIndex = 19;
            this.update_object_list.Text = "Update Object List";
            this.update_object_list.UseVisualStyleBackColor = true;
            this.update_object_list.Click += new System.EventHandler(this.update_object_list_Click);
            // 
            // load_items_listbox
            // 
            this.load_items_listbox.FormattingEnabled = true;
            this.load_items_listbox.Location = new System.Drawing.Point(27, 140);
            this.load_items_listbox.Name = "load_items_listbox";
            this.load_items_listbox.Size = new System.Drawing.Size(239, 134);
            this.load_items_listbox.TabIndex = 18;
            // 
            // load_object
            // 
            this.load_object.Location = new System.Drawing.Point(127, 68);
            this.load_object.Name = "load_object";
            this.load_object.Size = new System.Drawing.Size(82, 39);
            this.load_object.TabIndex = 17;
            this.load_object.Text = "Load Object";
            this.load_object.UseVisualStyleBackColor = true;
            this.load_object.Click += new System.EventHandler(this.load_object_Click);
            // 
            // save_object_to_name
            // 
            this.save_object_to_name.Location = new System.Drawing.Point(27, 68);
            this.save_object_to_name.Name = "save_object_to_name";
            this.save_object_to_name.Size = new System.Drawing.Size(82, 39);
            this.save_object_to_name.TabIndex = 16;
            this.save_object_to_name.Text = "Save Object to name.xml";
            this.save_object_to_name.UseVisualStyleBackColor = true;
            this.save_object_to_name.Click += new System.EventHandler(this.save_object_to_name_Click);
            // 
            // textBox1
            // 
            this.textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gameObjectBindingSource, "m_name", true));
            this.textBox1.Location = new System.Drawing.Point(137, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(104, 20);
            this.textBox1.TabIndex = 15;
            // 
            // gameObjectBindingSource
            // 
            this.gameObjectBindingSource.AllowNew = true;
            this.gameObjectBindingSource.DataSource = typeof(speedup.GameObject);
            // 
            // m_game_object_page
            // 
            this.m_game_object_page.AutoScroll = true;
            this.m_game_object_page.Controls.Add(m_disabledLabel);
            this.m_game_object_page.Controls.Add(this.m_disabledCheckBox);
            this.m_game_object_page.Controls.Add(rotationLabel);
            this.m_game_object_page.Controls.Add(this.rotationNumericUpDown);
            this.m_game_object_page.Controls.Add(shapeTypeLabel);
            this.m_game_object_page.Controls.Add(this.shapeTypeComboBox);
            this.m_game_object_page.Controls.Add(densityLabel);
            this.m_game_object_page.Controls.Add(this.densityNumericUpDown);
            this.m_game_object_page.Controls.Add(isSensorLabel);
            this.m_game_object_page.Controls.Add(this.isSensorCheckBox);
            this.m_game_object_page.Controls.Add(m_texture_name_changeLabel);
            this.m_game_object_page.Controls.Add(this.m_texture_name_changeComboBox);
            this.m_game_object_page.Controls.Add(m_change_sizeLabel);
            this.m_game_object_page.Controls.Add(this.m_change_sizeNumericUpDown);
            this.m_game_object_page.Controls.Add(m_destroy_thresholdLabel4);
            this.m_game_object_page.Controls.Add(this.m_destroy_thresholdNumericUpDown1);
            this.m_game_object_page.Controls.Add(inertiaLabel);
            this.m_game_object_page.Controls.Add(this.inertiaNumericUpDown);
            this.m_game_object_page.Controls.Add(linearDampingLabel);
            this.m_game_object_page.Controls.Add(this.linearDampingNumericUpDown);
            this.m_game_object_page.Controls.Add(massLabel);
            this.m_game_object_page.Controls.Add(this.massNumericUpDown);
            this.m_game_object_page.Controls.Add(this.restitutionNumericUpDown);
            this.m_game_object_page.Controls.Add(bodyTypeLabel);
            this.m_game_object_page.Controls.Add(this.bodyTypeComboBox);
            this.m_game_object_page.Controls.Add(this.frictionTextBox);
            this.m_game_object_page.Controls.Add(this.m_nameTextBox);
            this.m_game_object_page.Controls.Add(awakeLabel);
            this.m_game_object_page.Controls.Add(this.awakeCheckBox);
            this.m_game_object_page.Controls.Add(enabledLabel);
            this.m_game_object_page.Controls.Add(this.enabledCheckBox);
            this.m_game_object_page.Controls.Add(fixedRotationLabel);
            this.m_game_object_page.Controls.Add(this.fixedRotationCheckBox);
            this.m_game_object_page.Controls.Add(frictionLabel);
            this.m_game_object_page.Controls.Add(ignoreCCDLabel);
            this.m_game_object_page.Controls.Add(this.ignoreCCDCheckBox);
            this.m_game_object_page.Controls.Add(ignoreGravityLabel);
            this.m_game_object_page.Controls.Add(this.ignoreGravityCheckBox);
            this.m_game_object_page.Controls.Add(isBulletLabel);
            this.m_game_object_page.Controls.Add(this.isBulletCheckBox);
            this.m_game_object_page.Controls.Add(isDisposedLabel);
            this.m_game_object_page.Controls.Add(this.isDisposedCheckBox);
            this.m_game_object_page.Controls.Add(isStaticLabel);
            this.m_game_object_page.Controls.Add(this.isStaticCheckBox);
            this.m_game_object_page.Controls.Add(restitutionLabel);
            this.m_game_object_page.Controls.Add(sleepingAllowedLabel);
            this.m_game_object_page.Controls.Add(this.sleepingAllowedCheckBox);
            this.m_game_object_page.Controls.Add(m_is_deadLabel);
            this.m_game_object_page.Controls.Add(this.m_is_deadCheckBox);
            this.m_game_object_page.Controls.Add(m_is_destructibleLabel3);
            this.m_game_object_page.Controls.Add(this.m_is_destructibleCheckBox3);
            this.m_game_object_page.Controls.Add(m_is_throwableLabel3);
            this.m_game_object_page.Controls.Add(this.m_is_throwableCheckBox3);
            this.m_game_object_page.Controls.Add(m_nameLabel);
            this.m_game_object_page.Location = new System.Drawing.Point(4, 22);
            this.m_game_object_page.Name = "m_game_object_page";
            this.m_game_object_page.Padding = new System.Windows.Forms.Padding(3);
            this.m_game_object_page.Size = new System.Drawing.Size(320, 360);
            this.m_game_object_page.TabIndex = 10;
            this.m_game_object_page.Text = "GameObject";
            this.m_game_object_page.UseVisualStyleBackColor = true;
            this.m_game_object_page.Click += new System.EventHandler(this.gb_game_object_Click);
            // 
            // m_disabledCheckBox
            // 
            this.m_disabledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameObjectBindingSource, "m_disabled", true));
            this.m_disabledCheckBox.Location = new System.Drawing.Point(71, 228);
            this.m_disabledCheckBox.Name = "m_disabledCheckBox";
            this.m_disabledCheckBox.Size = new System.Drawing.Size(104, 24);
            this.m_disabledCheckBox.TabIndex = 88;
            this.m_disabledCheckBox.Text = "checkBox1";
            this.m_disabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // rotationNumericUpDown
            // 
            this.rotationNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.gameObjectBindingSource, "m_body.Rotation", true));
            this.rotationNumericUpDown.DecimalPlaces = 2;
            this.rotationNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.rotationNumericUpDown.Location = new System.Drawing.Point(91, 744);
            this.rotationNumericUpDown.Maximum = new decimal(new int[] {
            315,
            0,
            0,
            131072});
            this.rotationNumericUpDown.Minimum = new decimal(new int[] {
            315,
            0,
            0,
            -2147352576});
            this.rotationNumericUpDown.Name = "rotationNumericUpDown";
            this.rotationNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.rotationNumericUpDown.TabIndex = 87;
            // 
            // shapeTypeComboBox
            // 
            this.shapeTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fixtureListBindingSource, "Shape.ShapeType", true));
            this.shapeTypeComboBox.FormattingEnabled = true;
            this.shapeTypeComboBox.Location = new System.Drawing.Point(100, 857);
            this.shapeTypeComboBox.Name = "shapeTypeComboBox";
            this.shapeTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.shapeTypeComboBox.TabIndex = 86;
            // 
            // densityNumericUpDown
            // 
            this.densityNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.fixtureListBindingSource, "Shape.Density", true));
            this.densityNumericUpDown.DecimalPlaces = 2;
            this.densityNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.densityNumericUpDown.Location = new System.Drawing.Point(100, 829);
            this.densityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.densityNumericUpDown.Name = "densityNumericUpDown";
            this.densityNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.densityNumericUpDown.TabIndex = 85;
            this.densityNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // isSensorCheckBox
            // 
            this.isSensorCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.fixtureListBindingSource, "Shape.Density", true));
            this.isSensorCheckBox.Location = new System.Drawing.Point(100, 806);
            this.isSensorCheckBox.Name = "isSensorCheckBox";
            this.isSensorCheckBox.Size = new System.Drawing.Size(104, 24);
            this.isSensorCheckBox.TabIndex = 84;
            this.isSensorCheckBox.Text = "checkBox1";
            this.isSensorCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_texture_name_changeComboBox
            // 
            this.m_texture_name_changeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gameObjectBindingSource, "m_texture_name_change", true));
            this.m_texture_name_changeComboBox.DropDownWidth = 160;
            this.m_texture_name_changeComboBox.FormattingEnabled = true;
            this.m_texture_name_changeComboBox.Items.AddRange(new object[] {
            "Art/speedup-Background",
            "Art/speedup-Wall",
            "Art/speedup-Floor",
            "Art/speedup-Break1",
            "Art/speedup-NinjaSmall",
            "Art/speedup-Shuriken",
            "Art/speedup-BallSmall",
            "Art/speedup-AlienEasy",
            "Art/speedup-AlienMedium",
            "Art/speedup-AlienHard",
            "Art/speedup-AlienSpiky",
            "Art/speedup-AlienChaser",
            "Art/speedup-AlienSpawner",
            "Art/speedup-AlienTurret",
            "Art/speedup-AlienPlated",
            "Art/speedup-WinMessage",
            "Art/speedup-LoseMessage",
            "Art/speedup-groundswitch",
            "Art/speedup-groundswitch-depressed",
            "Art/speedup-Button",
            "Art/speedup-Button",
            "Art/speedup-Door",
            "Art/speedup-Photon",
            "Art/speedup-SonicBoom",
            "Art/speedup-Pix",
            "Art/speedup-Space"});
            this.m_texture_name_changeComboBox.Location = new System.Drawing.Point(129, 288);
            this.m_texture_name_changeComboBox.Name = "m_texture_name_changeComboBox";
            this.m_texture_name_changeComboBox.Size = new System.Drawing.Size(121, 21);
            this.m_texture_name_changeComboBox.TabIndex = 83;
            // 
            // m_change_sizeNumericUpDown
            // 
            this.m_change_sizeNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.gameObjectBindingSource, "m_change_size", true));
            this.m_change_sizeNumericUpDown.DecimalPlaces = 2;
            this.m_change_sizeNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_change_sizeNumericUpDown.Location = new System.Drawing.Point(109, 204);
            this.m_change_sizeNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_change_sizeNumericUpDown.Name = "m_change_sizeNumericUpDown";
            this.m_change_sizeNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_change_sizeNumericUpDown.TabIndex = 82;
            this.m_change_sizeNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_destroy_thresholdNumericUpDown1
            // 
            this.m_destroy_thresholdNumericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.gameObjectBindingSource, "m_destroy_threshold", true));
            this.m_destroy_thresholdNumericUpDown1.Location = new System.Drawing.Point(109, 45);
            this.m_destroy_thresholdNumericUpDown1.Maximum = new decimal(new int[] {
            118,
            0,
            0,
            0});
            this.m_destroy_thresholdNumericUpDown1.Name = "m_destroy_thresholdNumericUpDown1";
            this.m_destroy_thresholdNumericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.m_destroy_thresholdNumericUpDown1.TabIndex = 81;
            this.m_destroy_thresholdNumericUpDown1.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // inertiaNumericUpDown
            // 
            this.inertiaNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.gameObjectBindingSource, "m_body.Inertia", true));
            this.inertiaNumericUpDown.Location = new System.Drawing.Point(100, 534);
            this.inertiaNumericUpDown.Name = "inertiaNumericUpDown";
            this.inertiaNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.inertiaNumericUpDown.TabIndex = 77;
            // 
            // linearDampingNumericUpDown
            // 
            this.linearDampingNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.gameObjectBindingSource, "m_body.LinearDamping", true));
            this.linearDampingNumericUpDown.DecimalPlaces = 2;
            this.linearDampingNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.linearDampingNumericUpDown.Location = new System.Drawing.Point(100, 676);
            this.linearDampingNumericUpDown.Name = "linearDampingNumericUpDown";
            this.linearDampingNumericUpDown.Size = new System.Drawing.Size(104, 20);
            this.linearDampingNumericUpDown.TabIndex = 76;
            // 
            // massNumericUpDown
            // 
            this.massNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.gameObjectBindingSource, "m_change_mass", true));
            this.massNumericUpDown.DecimalPlaces = 2;
            this.massNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.massNumericUpDown.Location = new System.Drawing.Point(100, 650);
            this.massNumericUpDown.Name = "massNumericUpDown";
            this.massNumericUpDown.Size = new System.Drawing.Size(104, 20);
            this.massNumericUpDown.TabIndex = 75;
            this.massNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // restitutionNumericUpDown
            // 
            this.restitutionNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.gameObjectBindingSource, "change_restitution", true));
            this.restitutionNumericUpDown.DecimalPlaces = 2;
            this.restitutionNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.restitutionNumericUpDown.Location = new System.Drawing.Point(100, 702);
            this.restitutionNumericUpDown.Name = "restitutionNumericUpDown";
            this.restitutionNumericUpDown.Size = new System.Drawing.Size(104, 20);
            this.restitutionNumericUpDown.TabIndex = 74;
            this.restitutionNumericUpDown.ThousandsSeparator = true;
            this.restitutionNumericUpDown.Value = new decimal(new int[] {
            7,
            0,
            0,
            65536});
            // 
            // bodyTypeComboBox
            // 
            this.bodyTypeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gameObjectBindingSource, "m_body.BodyType", true));
            this.bodyTypeComboBox.FormattingEnabled = true;
            this.bodyTypeComboBox.Items.AddRange(new object[] {
            "Dynamic",
            "Kinematic",
            "Static"});
            this.bodyTypeComboBox.Location = new System.Drawing.Point(127, 256);
            this.bodyTypeComboBox.Name = "bodyTypeComboBox";
            this.bodyTypeComboBox.Size = new System.Drawing.Size(121, 21);
            this.bodyTypeComboBox.TabIndex = 56;
            this.bodyTypeComboBox.Text = "Dynamic";
            // 
            // frictionTextBox
            // 
            this.frictionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gameObjectBindingSource, "m_body.Friction", true));
            this.frictionTextBox.Location = new System.Drawing.Point(100, 448);
            this.frictionTextBox.Name = "frictionTextBox";
            this.frictionTextBox.Size = new System.Drawing.Size(104, 20);
            this.frictionTextBox.TabIndex = 31;
            // 
            // m_nameTextBox
            // 
            this.m_nameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.gameObjectBindingSource, "m_name", true));
            this.m_nameTextBox.Location = new System.Drawing.Point(109, 171);
            this.m_nameTextBox.Name = "m_nameTextBox";
            this.m_nameTextBox.Size = new System.Drawing.Size(104, 20);
            this.m_nameTextBox.TabIndex = 13;
            // 
            // awakeCheckBox
            // 
            this.awakeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameObjectBindingSource, "m_body.Awake", true));
            this.awakeCheckBox.Location = new System.Drawing.Point(100, 332);
            this.awakeCheckBox.Name = "awakeCheckBox";
            this.awakeCheckBox.Size = new System.Drawing.Size(104, 24);
            this.awakeCheckBox.TabIndex = 23;
            this.awakeCheckBox.Text = "checkBox1";
            this.awakeCheckBox.UseVisualStyleBackColor = true;
            // 
            // enabledCheckBox
            // 
            this.enabledCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameObjectBindingSource, "m_body.Enabled", true));
            this.enabledCheckBox.Location = new System.Drawing.Point(100, 388);
            this.enabledCheckBox.Name = "enabledCheckBox";
            this.enabledCheckBox.Size = new System.Drawing.Size(104, 24);
            this.enabledCheckBox.TabIndex = 27;
            this.enabledCheckBox.Text = "checkBox1";
            this.enabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // fixedRotationCheckBox
            // 
            this.fixedRotationCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameObjectBindingSource, "m_body.FixedRotation", true));
            this.fixedRotationCheckBox.Location = new System.Drawing.Point(100, 418);
            this.fixedRotationCheckBox.Name = "fixedRotationCheckBox";
            this.fixedRotationCheckBox.Size = new System.Drawing.Size(104, 24);
            this.fixedRotationCheckBox.TabIndex = 29;
            this.fixedRotationCheckBox.Text = "checkBox1";
            this.fixedRotationCheckBox.UseVisualStyleBackColor = true;
            // 
            // ignoreCCDCheckBox
            // 
            this.ignoreCCDCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameObjectBindingSource, "m_body.IgnoreCCD", true));
            this.ignoreCCDCheckBox.Location = new System.Drawing.Point(100, 474);
            this.ignoreCCDCheckBox.Name = "ignoreCCDCheckBox";
            this.ignoreCCDCheckBox.Size = new System.Drawing.Size(104, 24);
            this.ignoreCCDCheckBox.TabIndex = 33;
            this.ignoreCCDCheckBox.Text = "checkBox1";
            this.ignoreCCDCheckBox.UseVisualStyleBackColor = true;
            // 
            // ignoreGravityCheckBox
            // 
            this.ignoreGravityCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameObjectBindingSource, "m_body.IgnoreGravity", true));
            this.ignoreGravityCheckBox.Location = new System.Drawing.Point(100, 504);
            this.ignoreGravityCheckBox.Name = "ignoreGravityCheckBox";
            this.ignoreGravityCheckBox.Size = new System.Drawing.Size(104, 24);
            this.ignoreGravityCheckBox.TabIndex = 35;
            this.ignoreGravityCheckBox.Text = "checkBox1";
            this.ignoreGravityCheckBox.UseVisualStyleBackColor = true;
            // 
            // isBulletCheckBox
            // 
            this.isBulletCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameObjectBindingSource, "m_body.IsBullet", true));
            this.isBulletCheckBox.Location = new System.Drawing.Point(100, 560);
            this.isBulletCheckBox.Name = "isBulletCheckBox";
            this.isBulletCheckBox.Size = new System.Drawing.Size(104, 24);
            this.isBulletCheckBox.TabIndex = 39;
            this.isBulletCheckBox.Text = "checkBox1";
            this.isBulletCheckBox.UseVisualStyleBackColor = true;
            // 
            // isDisposedCheckBox
            // 
            this.isDisposedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameObjectBindingSource, "m_body.IsDisposed", true));
            this.isDisposedCheckBox.Location = new System.Drawing.Point(100, 590);
            this.isDisposedCheckBox.Name = "isDisposedCheckBox";
            this.isDisposedCheckBox.Size = new System.Drawing.Size(104, 24);
            this.isDisposedCheckBox.TabIndex = 41;
            this.isDisposedCheckBox.Text = "checkBox1";
            this.isDisposedCheckBox.UseVisualStyleBackColor = true;
            // 
            // isStaticCheckBox
            // 
            this.isStaticCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameObjectBindingSource, "m_body.IsStatic", true));
            this.isStaticCheckBox.Location = new System.Drawing.Point(100, 620);
            this.isStaticCheckBox.Name = "isStaticCheckBox";
            this.isStaticCheckBox.Size = new System.Drawing.Size(104, 24);
            this.isStaticCheckBox.TabIndex = 43;
            this.isStaticCheckBox.Text = "checkBox1";
            this.isStaticCheckBox.UseVisualStyleBackColor = true;
            // 
            // sleepingAllowedCheckBox
            // 
            this.sleepingAllowedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameObjectBindingSource, "m_body.SleepingAllowed", true));
            this.sleepingAllowedCheckBox.Location = new System.Drawing.Point(100, 780);
            this.sleepingAllowedCheckBox.Name = "sleepingAllowedCheckBox";
            this.sleepingAllowedCheckBox.Size = new System.Drawing.Size(104, 24);
            this.sleepingAllowedCheckBox.TabIndex = 55;
            this.sleepingAllowedCheckBox.Text = "checkBox1";
            this.sleepingAllowedCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_is_deadCheckBox
            // 
            this.m_is_deadCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameObjectBindingSource, "m_is_dead", true));
            this.m_is_deadCheckBox.Location = new System.Drawing.Point(110, 78);
            this.m_is_deadCheckBox.Name = "m_is_deadCheckBox";
            this.m_is_deadCheckBox.Size = new System.Drawing.Size(104, 24);
            this.m_is_deadCheckBox.TabIndex = 7;
            this.m_is_deadCheckBox.Text = "checkBox1";
            this.m_is_deadCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_is_destructibleCheckBox3
            // 
            this.m_is_destructibleCheckBox3.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameObjectBindingSource, "m_is_destructible", true));
            this.m_is_destructibleCheckBox3.Location = new System.Drawing.Point(110, 108);
            this.m_is_destructibleCheckBox3.Name = "m_is_destructibleCheckBox3";
            this.m_is_destructibleCheckBox3.Size = new System.Drawing.Size(104, 24);
            this.m_is_destructibleCheckBox3.TabIndex = 9;
            this.m_is_destructibleCheckBox3.Text = "checkBox1";
            this.m_is_destructibleCheckBox3.UseVisualStyleBackColor = true;
            // 
            // m_is_throwableCheckBox3
            // 
            this.m_is_throwableCheckBox3.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.gameObjectBindingSource, "m_is_throwable", true));
            this.m_is_throwableCheckBox3.Location = new System.Drawing.Point(110, 138);
            this.m_is_throwableCheckBox3.Name = "m_is_throwableCheckBox3";
            this.m_is_throwableCheckBox3.Size = new System.Drawing.Size(104, 24);
            this.m_is_throwableCheckBox3.TabIndex = 11;
            this.m_is_throwableCheckBox3.Text = "checkBox1";
            this.m_is_throwableCheckBox3.UseVisualStyleBackColor = true;
            // 
            // m_ninja_page
            // 
            this.m_ninja_page.AutoScroll = true;
            this.m_ninja_page.Controls.Add(this.m_max_throwable_capacityTextBox);
            this.m_ninja_page.Controls.Add(this.m_maxspeedTextBox);
            this.m_ninja_page.Controls.Add(this.m_movement_accelTextBox);
            this.m_ninja_page.Controls.Add(this.m_nameTextBox1);
            this.m_ninja_page.Controls.Add(this.m_speedTextBox);
            this.m_ninja_page.Controls.Add(this.m_throw_powerTextBox);
            this.m_ninja_page.Controls.Add(this.m_is_killedLabel);
            this.m_ninja_page.Controls.Add(this.m_is_killedCheckBox);
            this.m_ninja_page.Controls.Add(this.m_max_throwable_capacityLabel);
            this.m_ninja_page.Controls.Add(this.m_maxspeedLabel);
            this.m_ninja_page.Controls.Add(this.m_movement_accelLabel);
            this.m_ninja_page.Controls.Add(this.m_nameLabel1);
            this.m_ninja_page.Controls.Add(this.m_picking_upLabel);
            this.m_ninja_page.Controls.Add(this.m_picking_upCheckBox);
            this.m_ninja_page.Controls.Add(this.m_speedLabel);
            this.m_ninja_page.Controls.Add(this.m_throw_powerLabel);
            this.m_ninja_page.Location = new System.Drawing.Point(4, 22);
            this.m_ninja_page.Name = "m_ninja_page";
            this.m_ninja_page.Padding = new System.Windows.Forms.Padding(3);
            this.m_ninja_page.Size = new System.Drawing.Size(320, 360);
            this.m_ninja_page.TabIndex = 9;
            this.m_ninja_page.Text = "Ninja";
            this.m_ninja_page.UseVisualStyleBackColor = true;
            // 
            // m_max_throwable_capacityTextBox
            // 
            this.m_max_throwable_capacityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ninjaBindingSource, "m_max_throwable_capacity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.m_max_throwable_capacityTextBox.Location = new System.Drawing.Point(141, 46);
            this.m_max_throwable_capacityTextBox.Name = "m_max_throwable_capacityTextBox";
            this.m_max_throwable_capacityTextBox.Size = new System.Drawing.Size(104, 20);
            this.m_max_throwable_capacityTextBox.TabIndex = 11;
            // 
            // ninjaBindingSource
            // 
            this.ninjaBindingSource.DataSource = typeof(speedup.Ninja);
            // 
            // m_maxspeedTextBox
            // 
            this.m_maxspeedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ninjaBindingSource, "m_maxspeed", true));
            this.m_maxspeedTextBox.Location = new System.Drawing.Point(141, 72);
            this.m_maxspeedTextBox.Name = "m_maxspeedTextBox";
            this.m_maxspeedTextBox.Size = new System.Drawing.Size(104, 20);
            this.m_maxspeedTextBox.TabIndex = 13;
            // 
            // m_movement_accelTextBox
            // 
            this.m_movement_accelTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ninjaBindingSource, "m_movement_accel", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.m_movement_accelTextBox.Location = new System.Drawing.Point(141, 98);
            this.m_movement_accelTextBox.Name = "m_movement_accelTextBox";
            this.m_movement_accelTextBox.Size = new System.Drawing.Size(104, 20);
            this.m_movement_accelTextBox.TabIndex = 15;
            // 
            // m_nameTextBox1
            // 
            this.m_nameTextBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ninjaBindingSource, "m_name", true));
            this.m_nameTextBox1.Location = new System.Drawing.Point(141, 124);
            this.m_nameTextBox1.Name = "m_nameTextBox1";
            this.m_nameTextBox1.Size = new System.Drawing.Size(104, 20);
            this.m_nameTextBox1.TabIndex = 17;
            // 
            // m_speedTextBox
            // 
            this.m_speedTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ninjaBindingSource, "m_speed", true));
            this.m_speedTextBox.Location = new System.Drawing.Point(136, 225);
            this.m_speedTextBox.Name = "m_speedTextBox";
            this.m_speedTextBox.Size = new System.Drawing.Size(104, 20);
            this.m_speedTextBox.TabIndex = 23;
            // 
            // m_throw_powerTextBox
            // 
            this.m_throw_powerTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ninjaBindingSource, "m_throw_power", true));
            this.m_throw_powerTextBox.Location = new System.Drawing.Point(138, 154);
            this.m_throw_powerTextBox.Name = "m_throw_powerTextBox";
            this.m_throw_powerTextBox.Size = new System.Drawing.Size(104, 20);
            this.m_throw_powerTextBox.TabIndex = 27;
            // 
            // m_is_killedCheckBox
            // 
            this.m_is_killedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.ninjaBindingSource, "m_is_killed", true));
            this.m_is_killedCheckBox.Location = new System.Drawing.Point(141, 16);
            this.m_is_killedCheckBox.Name = "m_is_killedCheckBox";
            this.m_is_killedCheckBox.Size = new System.Drawing.Size(104, 24);
            this.m_is_killedCheckBox.TabIndex = 9;
            this.m_is_killedCheckBox.Text = "checkBox1";
            this.m_is_killedCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_picking_upCheckBox
            // 
            this.m_picking_upCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.ninjaBindingSource, "m_picking_up", true));
            this.m_picking_upCheckBox.Location = new System.Drawing.Point(138, 187);
            this.m_picking_upCheckBox.Name = "m_picking_upCheckBox";
            this.m_picking_upCheckBox.Size = new System.Drawing.Size(104, 24);
            this.m_picking_upCheckBox.TabIndex = 19;
            this.m_picking_upCheckBox.Text = "checkBox1";
            this.m_picking_upCheckBox.UseVisualStyleBackColor = true;
            // 
            // PolygonObject
            // 
            this.PolygonObject.AutoScroll = true;
            this.PolygonObject.Controls.Add(m_change_size_yLabel);
            this.PolygonObject.Controls.Add(this.m_change_size_yNumericUpDown);
            this.PolygonObject.Controls.Add(m_change_size_xLabel);
            this.PolygonObject.Controls.Add(this.m_change_size_xNumericUpDown);
            this.PolygonObject.Location = new System.Drawing.Point(4, 22);
            this.PolygonObject.Name = "PolygonObject";
            this.PolygonObject.Padding = new System.Windows.Forms.Padding(3);
            this.PolygonObject.Size = new System.Drawing.Size(320, 360);
            this.PolygonObject.TabIndex = 18;
            this.PolygonObject.Text = "Polygon Object";
            this.PolygonObject.UseVisualStyleBackColor = true;
            // 
            // m_change_size_yNumericUpDown
            // 
            this.m_change_size_yNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.polygonObjectBindingSource, "m_change_size_y", true));
            this.m_change_size_yNumericUpDown.DecimalPlaces = 2;
            this.m_change_size_yNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_change_size_yNumericUpDown.Location = new System.Drawing.Point(122, 100);
            this.m_change_size_yNumericUpDown.Name = "m_change_size_yNumericUpDown";
            this.m_change_size_yNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_change_size_yNumericUpDown.TabIndex = 3;
            this.m_change_size_yNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // polygonObjectBindingSource
            // 
            this.polygonObjectBindingSource.DataSource = typeof(speedup.PolygonObject);
            // 
            // m_change_size_xNumericUpDown
            // 
            this.m_change_size_xNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.polygonObjectBindingSource, "m_change_size_x", true));
            this.m_change_size_xNumericUpDown.DecimalPlaces = 2;
            this.m_change_size_xNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_change_size_xNumericUpDown.Location = new System.Drawing.Point(122, 59);
            this.m_change_size_xNumericUpDown.Name = "m_change_size_xNumericUpDown";
            this.m_change_size_xNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_change_size_xNumericUpDown.TabIndex = 1;
            this.m_change_size_xNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_create_poly_from_texture
            // 
            this.m_create_poly_from_texture.AutoScroll = true;
            this.m_create_poly_from_texture.Controls.Add(this.m_poly_create_arc);
            this.m_create_poly_from_texture.Controls.Add(this.button2);
            this.m_create_poly_from_texture.Controls.Add(this.m_poly_create_rectangle);
            this.m_create_poly_from_texture.Controls.Add(this.m_poly_create_ellipse);
            this.m_create_poly_from_texture.Controls.Add(label7);
            this.m_create_poly_from_texture.Controls.Add(this.m_poly_angle);
            this.m_create_poly_from_texture.Controls.Add(this.m_poly_create_circle);
            this.m_create_poly_from_texture.Controls.Add(label5);
            this.m_create_poly_from_texture.Controls.Add(this.m_poly_y_scale);
            this.m_create_poly_from_texture.Controls.Add(label6);
            this.m_create_poly_from_texture.Controls.Add(this.m_poly_x_scale);
            this.m_create_poly_from_texture.Controls.Add(label4);
            this.m_create_poly_from_texture.Controls.Add(this.m_poly_num_edges);
            this.m_create_poly_from_texture.Controls.Add(label3);
            this.m_create_poly_from_texture.Controls.Add(this.m_poly_y_radius);
            this.m_create_poly_from_texture.Controls.Add(label2);
            this.m_create_poly_from_texture.Controls.Add(this.m_poly_x_radius);
            this.m_create_poly_from_texture.Controls.Add(label1);
            this.m_create_poly_from_texture.Controls.Add(this.m_poly_radius);
            this.m_create_poly_from_texture.Controls.Add(this.m_cb_poly_tex_name);
            this.m_create_poly_from_texture.Controls.Add(m_texture_nameLabel2);
            this.m_create_poly_from_texture.Location = new System.Drawing.Point(4, 22);
            this.m_create_poly_from_texture.Name = "m_create_poly_from_texture";
            this.m_create_poly_from_texture.Padding = new System.Windows.Forms.Padding(3);
            this.m_create_poly_from_texture.Size = new System.Drawing.Size(320, 360);
            this.m_create_poly_from_texture.TabIndex = 2;
            this.m_create_poly_from_texture.Text = "Wall";
            this.m_create_poly_from_texture.UseVisualStyleBackColor = true;
            this.m_create_poly_from_texture.Click += new System.EventHandler(this.m_create_poly_from_texture_Click);
            // 
            // m_poly_create_arc
            // 
            this.m_poly_create_arc.Location = new System.Drawing.Point(184, 318);
            this.m_poly_create_arc.Name = "m_poly_create_arc";
            this.m_poly_create_arc.Size = new System.Drawing.Size(67, 39);
            this.m_poly_create_arc.TabIndex = 103;
            this.m_poly_create_arc.Text = "Arc";
            this.m_poly_create_arc.UseVisualStyleBackColor = true;
            this.m_poly_create_arc.Click += new System.EventHandler(this.m_poly_create_arc_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(254, 318);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 39);
            this.button2.TabIndex = 102;
            this.button2.Text = "Texture";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // m_poly_create_rectangle
            // 
            this.m_poly_create_rectangle.Location = new System.Drawing.Point(116, 318);
            this.m_poly_create_rectangle.Name = "m_poly_create_rectangle";
            this.m_poly_create_rectangle.Size = new System.Drawing.Size(67, 39);
            this.m_poly_create_rectangle.TabIndex = 101;
            this.m_poly_create_rectangle.Text = "Rectangle";
            this.m_poly_create_rectangle.UseVisualStyleBackColor = true;
            this.m_poly_create_rectangle.Click += new System.EventHandler(this.m_poly_create_rectangle_Click);
            // 
            // m_poly_create_ellipse
            // 
            this.m_poly_create_ellipse.Location = new System.Drawing.Point(59, 318);
            this.m_poly_create_ellipse.Name = "m_poly_create_ellipse";
            this.m_poly_create_ellipse.Size = new System.Drawing.Size(57, 39);
            this.m_poly_create_ellipse.TabIndex = 100;
            this.m_poly_create_ellipse.Text = "Ellipse";
            this.m_poly_create_ellipse.UseVisualStyleBackColor = true;
            this.m_poly_create_ellipse.Click += new System.EventHandler(this.m_poly_create_ellipse_Click);
            // 
            // m_poly_angle
            // 
            this.m_poly_angle.DecimalPlaces = 2;
            this.m_poly_angle.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_poly_angle.Location = new System.Drawing.Point(116, 300);
            this.m_poly_angle.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            65536});
            this.m_poly_angle.Minimum = new decimal(new int[] {
            32,
            0,
            0,
            -2147418112});
            this.m_poly_angle.Name = "m_poly_angle";
            this.m_poly_angle.Size = new System.Drawing.Size(120, 20);
            this.m_poly_angle.TabIndex = 99;
            // 
            // m_poly_create_circle
            // 
            this.m_poly_create_circle.Location = new System.Drawing.Point(6, 318);
            this.m_poly_create_circle.Name = "m_poly_create_circle";
            this.m_poly_create_circle.Size = new System.Drawing.Size(54, 39);
            this.m_poly_create_circle.TabIndex = 97;
            this.m_poly_create_circle.Text = "Circle";
            this.m_poly_create_circle.UseVisualStyleBackColor = true;
            this.m_poly_create_circle.Click += new System.EventHandler(this.m_poly_create_circle_Click);
            // 
            // m_poly_y_scale
            // 
            this.m_poly_y_scale.DecimalPlaces = 2;
            this.m_poly_y_scale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_poly_y_scale.Location = new System.Drawing.Point(116, 273);
            this.m_poly_y_scale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_poly_y_scale.Name = "m_poly_y_scale";
            this.m_poly_y_scale.Size = new System.Drawing.Size(120, 20);
            this.m_poly_y_scale.TabIndex = 96;
            this.m_poly_y_scale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_poly_x_scale
            // 
            this.m_poly_x_scale.DecimalPlaces = 2;
            this.m_poly_x_scale.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_poly_x_scale.Location = new System.Drawing.Point(116, 251);
            this.m_poly_x_scale.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_poly_x_scale.Name = "m_poly_x_scale";
            this.m_poly_x_scale.Size = new System.Drawing.Size(120, 20);
            this.m_poly_x_scale.TabIndex = 94;
            this.m_poly_x_scale.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_poly_num_edges
            // 
            this.m_poly_num_edges.Location = new System.Drawing.Point(139, 106);
            this.m_poly_num_edges.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_poly_num_edges.Name = "m_poly_num_edges";
            this.m_poly_num_edges.Size = new System.Drawing.Size(120, 20);
            this.m_poly_num_edges.TabIndex = 92;
            this.m_poly_num_edges.Value = new decimal(new int[] {
            7,
            0,
            0,
            0});
            // 
            // m_poly_y_radius
            // 
            this.m_poly_y_radius.DecimalPlaces = 2;
            this.m_poly_y_radius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_poly_y_radius.Location = new System.Drawing.Point(116, 198);
            this.m_poly_y_radius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_poly_y_radius.Name = "m_poly_y_radius";
            this.m_poly_y_radius.Size = new System.Drawing.Size(120, 20);
            this.m_poly_y_radius.TabIndex = 90;
            this.m_poly_y_radius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_poly_x_radius
            // 
            this.m_poly_x_radius.DecimalPlaces = 2;
            this.m_poly_x_radius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_poly_x_radius.Location = new System.Drawing.Point(116, 176);
            this.m_poly_x_radius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_poly_x_radius.Name = "m_poly_x_radius";
            this.m_poly_x_radius.Size = new System.Drawing.Size(120, 20);
            this.m_poly_x_radius.TabIndex = 88;
            this.m_poly_x_radius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_poly_radius
            // 
            this.m_poly_radius.DecimalPlaces = 2;
            this.m_poly_radius.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_poly_radius.Location = new System.Drawing.Point(116, 144);
            this.m_poly_radius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_poly_radius.Name = "m_poly_radius";
            this.m_poly_radius.Size = new System.Drawing.Size(120, 20);
            this.m_poly_radius.TabIndex = 86;
            this.m_poly_radius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_cb_poly_tex_name
            // 
            this.m_cb_poly_tex_name.DropDownWidth = 160;
            this.m_cb_poly_tex_name.FormattingEnabled = true;
            this.m_cb_poly_tex_name.Items.AddRange(new object[] {
            "Art/speedup-Background",
            "Art/speedup-Wall",
            "Art/speedup-Floor",
            "Art/speedup-Break1",
            "Art/speedup-NinjaSmall",
            "Art/speedup-Shuriken",
            "Art/speedup-BallSmall",
            "Art/speedup-AlienEasy",
            "Art/speedup-AlienMedium",
            "Art/speedup-AlienHard",
            "Art/speedup-AlienSpiky",
            "Art/speedup-WinMessage",
            "Art/speedup-LoseMessage",
            "Art/speedup-groundswitch",
            "Art/speedup-groundswitch-depressed",
            "Art/speedup-Button",
            "Art/speedup-Button",
            "Art/speedup-Door",
            "Art/speedup-Photon",
            "Art/speedup-SonicBoom",
            "Art/speedup-Pix"});
            this.m_cb_poly_tex_name.Location = new System.Drawing.Point(94, 61);
            this.m_cb_poly_tex_name.Name = "m_cb_poly_tex_name";
            this.m_cb_poly_tex_name.Size = new System.Drawing.Size(121, 21);
            this.m_cb_poly_tex_name.TabIndex = 84;
            this.m_cb_poly_tex_name.Text = "Art/speedup-Wall";
            this.m_cb_poly_tex_name.SelectedIndexChanged += new System.EventHandler(this.m_cb_poly_tex_name_SelectedIndexChanged);
            // 
            // m_tile_page
            // 
            this.m_tile_page.AutoScroll = true;
            this.m_tile_page.Controls.Add(this.m_pointsListBox);
            this.m_tile_page.Controls.Add(m_buffered_angleLabel3);
            this.m_tile_page.Controls.Add(this.m_buffered_angleTextBox3);
            this.m_tile_page.Controls.Add(this.m_nameTextBox3);
            this.m_tile_page.Controls.Add(this.m_radiusTextBox4);
            this.m_tile_page.Controls.Add(this.m_texture_nameTextBox4);
            this.m_tile_page.Controls.Add(m_nameLabel3);
            this.m_tile_page.Controls.Add(m_radiusLabel4);
            this.m_tile_page.Controls.Add(m_texture_nameLabel4);
            this.m_tile_page.Location = new System.Drawing.Point(4, 22);
            this.m_tile_page.Name = "m_tile_page";
            this.m_tile_page.Padding = new System.Windows.Forms.Padding(3);
            this.m_tile_page.Size = new System.Drawing.Size(320, 360);
            this.m_tile_page.TabIndex = 13;
            this.m_tile_page.Text = "Floor Tile";
            this.m_tile_page.UseVisualStyleBackColor = true;
            // 
            // m_pointsListBox
            // 
            this.m_pointsListBox.DataSource = this.m_pointsBindingSource;
            this.m_pointsListBox.FormattingEnabled = true;
            this.m_pointsListBox.Location = new System.Drawing.Point(6, 169);
            this.m_pointsListBox.Name = "m_pointsListBox";
            this.m_pointsListBox.Size = new System.Drawing.Size(195, 121);
            this.m_pointsListBox.TabIndex = 8;
            // 
            // m_buffered_angleTextBox3
            // 
            this.m_buffered_angleTextBox3.Location = new System.Drawing.Point(101, 20);
            this.m_buffered_angleTextBox3.Name = "m_buffered_angleTextBox3";
            this.m_buffered_angleTextBox3.Size = new System.Drawing.Size(100, 20);
            this.m_buffered_angleTextBox3.TabIndex = 1;
            // 
            // m_nameTextBox3
            // 
            this.m_nameTextBox3.Location = new System.Drawing.Point(101, 46);
            this.m_nameTextBox3.Name = "m_nameTextBox3";
            this.m_nameTextBox3.Size = new System.Drawing.Size(100, 20);
            this.m_nameTextBox3.TabIndex = 3;
            // 
            // m_radiusTextBox4
            // 
            this.m_radiusTextBox4.Location = new System.Drawing.Point(101, 72);
            this.m_radiusTextBox4.Name = "m_radiusTextBox4";
            this.m_radiusTextBox4.Size = new System.Drawing.Size(100, 20);
            this.m_radiusTextBox4.TabIndex = 5;
            // 
            // m_texture_nameTextBox4
            // 
            this.m_texture_nameTextBox4.Location = new System.Drawing.Point(101, 98);
            this.m_texture_nameTextBox4.Name = "m_texture_nameTextBox4";
            this.m_texture_nameTextBox4.Size = new System.Drawing.Size(100, 20);
            this.m_texture_nameTextBox4.TabIndex = 7;
            // 
            // Alien
            // 
            this.Alien.AutoScroll = true;
            this.Alien.Controls.Add(m_attack_speedLabel);
            this.Alien.Controls.Add(this.m_attack_speedNumericUpDown);
            this.Alien.Controls.Add(m_laser_slowdownLabel);
            this.Alien.Controls.Add(this.m_laser_slowdownNumericUpDown);
            this.Alien.Controls.Add(m_alien_color_alpha_changeLabel);
            this.Alien.Controls.Add(this.m_alien_color_alpha_changeNumericUpDown);
            this.Alien.Controls.Add(m_alien_color_blue_changeLabel);
            this.Alien.Controls.Add(this.m_alien_color_blue_changeNumericUpDown);
            this.Alien.Controls.Add(m_alien_color_red_changeLabel);
            this.Alien.Controls.Add(this.m_alien_color_red_changeNumericUpDown);
            this.Alien.Controls.Add(m_alien_color_green_changeLabel);
            this.Alien.Controls.Add(this.m_alien_color_green_changeNumericUpDown);
            this.Alien.Controls.Add(m_rangeLabel);
            this.Alien.Controls.Add(this.m_rangeNumericUpDown);
            this.Alien.Controls.Add(m_move_stepLabel);
            this.Alien.Controls.Add(this.m_move_stepNumericUpDown);
            this.Alien.Controls.Add(m_chase_distLabel);
            this.Alien.Controls.Add(this.m_chase_distNumericUpDown);
            this.Alien.Controls.Add(m_attack_distLabel);
            this.Alien.Controls.Add(this.m_attack_distNumericUpDown);
            this.Alien.Controls.Add(m_attack_powerLabel);
            this.Alien.Controls.Add(this.m_attack_powerNumericUpDown);
            this.Alien.Controls.Add(m_attack_cooldownLabel);
            this.Alien.Controls.Add(this.m_attack_rateNumericUpDown);
            this.Alien.Controls.Add(m_ai_stateLabel);
            this.Alien.Controls.Add(this.m_ai_stateComboBox);
            this.Alien.Controls.Add(m_ai_type_changeLabel);
            this.Alien.Controls.Add(this.m_ai_type_changeComboBox);
            this.Alien.Controls.Add(m_kill_under_speedLabel1);
            this.Alien.Controls.Add(this.m_kill_under_speedNumericUpDown);
            this.Alien.Controls.Add(m_collision_typeLabel);
            this.Alien.Controls.Add(this.m_collision_typeComboBox);
            this.Alien.Controls.Add(this.m_nameTextBox6);
            this.Alien.Controls.Add(m_nameLabel6);
            this.Alien.Controls.Add(m_typeLabel);
            this.Alien.Controls.Add(this.m_typeComboBox1);
            this.Alien.Location = new System.Drawing.Point(4, 22);
            this.Alien.Name = "Alien";
            this.Alien.Padding = new System.Windows.Forms.Padding(3);
            this.Alien.Size = new System.Drawing.Size(320, 360);
            this.Alien.TabIndex = 14;
            this.Alien.Text = "Alien";
            this.Alien.UseVisualStyleBackColor = true;
            // 
            // m_attack_speedNumericUpDown
            // 
            this.m_attack_speedNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.alienBindingSource, "m_attack_speed", true));
            this.m_attack_speedNumericUpDown.DecimalPlaces = 3;
            this.m_attack_speedNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.m_attack_speedNumericUpDown.Location = new System.Drawing.Point(121, 251);
            this.m_attack_speedNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.m_attack_speedNumericUpDown.Name = "m_attack_speedNumericUpDown";
            this.m_attack_speedNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_attack_speedNumericUpDown.TabIndex = 35;
            this.m_attack_speedNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // alienBindingSource
            // 
            this.alienBindingSource.DataSource = typeof(speedup.Alien);
            // 
            // m_laser_slowdownNumericUpDown
            // 
            this.m_laser_slowdownNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.alienBindingSource, "m_laser_slowdown", true));
            this.m_laser_slowdownNumericUpDown.DecimalPlaces = 2;
            this.m_laser_slowdownNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_laser_slowdownNumericUpDown.Location = new System.Drawing.Point(129, 306);
            this.m_laser_slowdownNumericUpDown.Name = "m_laser_slowdownNumericUpDown";
            this.m_laser_slowdownNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_laser_slowdownNumericUpDown.TabIndex = 33;
            this.m_laser_slowdownNumericUpDown.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            // 
            // m_alien_color_alpha_changeNumericUpDown
            // 
            this.m_alien_color_alpha_changeNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.alienBindingSource, "m_alien_color_alpha_change", true));
            this.m_alien_color_alpha_changeNumericUpDown.Location = new System.Drawing.Point(179, 550);
            this.m_alien_color_alpha_changeNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_alien_color_alpha_changeNumericUpDown.Name = "m_alien_color_alpha_changeNumericUpDown";
            this.m_alien_color_alpha_changeNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_alien_color_alpha_changeNumericUpDown.TabIndex = 31;
            // 
            // m_alien_color_blue_changeNumericUpDown
            // 
            this.m_alien_color_blue_changeNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.alienBindingSource, "m_alien_color_blue_change", true));
            this.m_alien_color_blue_changeNumericUpDown.Location = new System.Drawing.Point(176, 520);
            this.m_alien_color_blue_changeNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_alien_color_blue_changeNumericUpDown.Name = "m_alien_color_blue_changeNumericUpDown";
            this.m_alien_color_blue_changeNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_alien_color_blue_changeNumericUpDown.TabIndex = 30;
            // 
            // m_alien_color_red_changeNumericUpDown
            // 
            this.m_alien_color_red_changeNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.alienBindingSource, "m_alien_color_red_change", true));
            this.m_alien_color_red_changeNumericUpDown.Location = new System.Drawing.Point(176, 472);
            this.m_alien_color_red_changeNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_alien_color_red_changeNumericUpDown.Name = "m_alien_color_red_changeNumericUpDown";
            this.m_alien_color_red_changeNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_alien_color_red_changeNumericUpDown.TabIndex = 29;
            // 
            // m_alien_color_green_changeNumericUpDown
            // 
            this.m_alien_color_green_changeNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.alienBindingSource, "m_alien_color_green_change", true));
            this.m_alien_color_green_changeNumericUpDown.Location = new System.Drawing.Point(176, 497);
            this.m_alien_color_green_changeNumericUpDown.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.m_alien_color_green_changeNumericUpDown.Name = "m_alien_color_green_changeNumericUpDown";
            this.m_alien_color_green_changeNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_alien_color_green_changeNumericUpDown.TabIndex = 28;
            // 
            // m_rangeNumericUpDown
            // 
            this.m_rangeNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.alienBindingSource, "m_range", true));
            this.m_rangeNumericUpDown.DecimalPlaces = 2;
            this.m_rangeNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_rangeNumericUpDown.Location = new System.Drawing.Point(115, 449);
            this.m_rangeNumericUpDown.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
            this.m_rangeNumericUpDown.Name = "m_rangeNumericUpDown";
            this.m_rangeNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_rangeNumericUpDown.TabIndex = 27;
            this.m_rangeNumericUpDown.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // m_move_stepNumericUpDown
            // 
            this.m_move_stepNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.alienBindingSource, "m_move_step", true));
            this.m_move_stepNumericUpDown.DecimalPlaces = 3;
            this.m_move_stepNumericUpDown.Location = new System.Drawing.Point(116, 421);
            this.m_move_stepNumericUpDown.Name = "m_move_stepNumericUpDown";
            this.m_move_stepNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_move_stepNumericUpDown.TabIndex = 26;
            this.m_move_stepNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_chase_distNumericUpDown
            // 
            this.m_chase_distNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.alienBindingSource, "m_chase_dist", true));
            this.m_chase_distNumericUpDown.DecimalPlaces = 2;
            this.m_chase_distNumericUpDown.Increment = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.m_chase_distNumericUpDown.Location = new System.Drawing.Point(115, 389);
            this.m_chase_distNumericUpDown.Name = "m_chase_distNumericUpDown";
            this.m_chase_distNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_chase_distNumericUpDown.TabIndex = 25;
            this.m_chase_distNumericUpDown.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // m_attack_distNumericUpDown
            // 
            this.m_attack_distNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.alienBindingSource, "m_attack_dist", true));
            this.m_attack_distNumericUpDown.DecimalPlaces = 2;
            this.m_attack_distNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_attack_distNumericUpDown.Location = new System.Drawing.Point(112, 363);
            this.m_attack_distNumericUpDown.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.m_attack_distNumericUpDown.Name = "m_attack_distNumericUpDown";
            this.m_attack_distNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_attack_distNumericUpDown.TabIndex = 24;
            this.m_attack_distNumericUpDown.Value = new decimal(new int[] {
            40,
            0,
            0,
            0});
            // 
            // m_attack_powerNumericUpDown
            // 
            this.m_attack_powerNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.alienBindingSource, "m_attack_power", true));
            this.m_attack_powerNumericUpDown.DecimalPlaces = 2;
            this.m_attack_powerNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_attack_powerNumericUpDown.Location = new System.Drawing.Point(112, 335);
            this.m_attack_powerNumericUpDown.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.m_attack_powerNumericUpDown.Name = "m_attack_powerNumericUpDown";
            this.m_attack_powerNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_attack_powerNumericUpDown.TabIndex = 23;
            this.m_attack_powerNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // m_attack_rateNumericUpDown
            // 
            this.m_attack_rateNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.alienBindingSource, "m_attack_rate_change", true));
            this.m_attack_rateNumericUpDown.Location = new System.Drawing.Point(129, 275);
            this.m_attack_rateNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.m_attack_rateNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_attack_rateNumericUpDown.Name = "m_attack_rateNumericUpDown";
            this.m_attack_rateNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_attack_rateNumericUpDown.TabIndex = 22;
            this.m_attack_rateNumericUpDown.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // m_ai_stateComboBox
            // 
            this.m_ai_stateComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alienBindingSource, "m_ai_state", true));
            this.m_ai_stateComboBox.FormattingEnabled = true;
            this.m_ai_stateComboBox.Location = new System.Drawing.Point(93, 227);
            this.m_ai_stateComboBox.Name = "m_ai_stateComboBox";
            this.m_ai_stateComboBox.Size = new System.Drawing.Size(121, 21);
            this.m_ai_stateComboBox.TabIndex = 21;
            // 
            // m_ai_type_changeComboBox
            // 
            this.m_ai_type_changeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alienBindingSource, "m_ai_type_change", true));
            this.m_ai_type_changeComboBox.FormattingEnabled = true;
            this.m_ai_type_changeComboBox.Items.AddRange(new object[] {
            "PEON",
            "PATROL",
            "TURRET",
            "CHASER",
            "DEFENDER",
            "ATTACKER",
            "BOSS"});
            this.m_ai_type_changeComboBox.Location = new System.Drawing.Point(103, 204);
            this.m_ai_type_changeComboBox.Name = "m_ai_type_changeComboBox";
            this.m_ai_type_changeComboBox.Size = new System.Drawing.Size(121, 21);
            this.m_ai_type_changeComboBox.TabIndex = 20;
            // 
            // m_kill_under_speedNumericUpDown
            // 
            this.m_kill_under_speedNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.alienBindingSource, "m_kill_under_speed", true));
            this.m_kill_under_speedNumericUpDown.Location = new System.Drawing.Point(114, 104);
            this.m_kill_under_speedNumericUpDown.Name = "m_kill_under_speedNumericUpDown";
            this.m_kill_under_speedNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_kill_under_speedNumericUpDown.TabIndex = 19;
            this.m_kill_under_speedNumericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // m_collision_typeComboBox
            // 
            this.m_collision_typeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alienBindingSource, "m_collision_type", true));
            this.m_collision_typeComboBox.FormattingEnabled = true;
            this.m_collision_typeComboBox.Items.AddRange(new object[] {
            "NORMAL",
            "SPIKED",
            "PLATED"});
            this.m_collision_typeComboBox.Location = new System.Drawing.Point(114, 177);
            this.m_collision_typeComboBox.Name = "m_collision_typeComboBox";
            this.m_collision_typeComboBox.Size = new System.Drawing.Size(121, 21);
            this.m_collision_typeComboBox.TabIndex = 18;
            // 
            // m_nameTextBox6
            // 
            this.m_nameTextBox6.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alienBindingSource, "m_name", true));
            this.m_nameTextBox6.Location = new System.Drawing.Point(113, 39);
            this.m_nameTextBox6.Name = "m_nameTextBox6";
            this.m_nameTextBox6.Size = new System.Drawing.Size(121, 20);
            this.m_nameTextBox6.TabIndex = 11;
            // 
            // m_typeComboBox1
            // 
            this.m_typeComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.alienBindingSource, "m_type_change", true));
            this.m_typeComboBox1.FormattingEnabled = true;
            this.m_typeComboBox1.Items.AddRange(new object[] {
            "EASY",
            "MEDIUM",
            "HARD",
            "CHASER",
            "SPAWNER",
            "TURRET",
            "PLATED",
            "SPIKED"});
            this.m_typeComboBox1.Location = new System.Drawing.Point(114, 142);
            this.m_typeComboBox1.Name = "m_typeComboBox1";
            this.m_typeComboBox1.Size = new System.Drawing.Size(121, 21);
            this.m_typeComboBox1.TabIndex = 17;
            // 
            // m_trigger_page
            // 
            this.m_trigger_page.Controls.Add(this.groupBox3);
            this.m_trigger_page.Controls.Add(this.checkBox2);
            this.m_trigger_page.Controls.Add(this.button1);
            this.m_trigger_page.Location = new System.Drawing.Point(4, 22);
            this.m_trigger_page.Name = "m_trigger_page";
            this.m_trigger_page.Padding = new System.Windows.Forms.Padding(3);
            this.m_trigger_page.Size = new System.Drawing.Size(320, 360);
            this.m_trigger_page.TabIndex = 11;
            this.m_trigger_page.Text = "Trigger/Switch";
            this.m_trigger_page.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(m_continuous_checkLabel);
            this.groupBox3.Controls.Add(this.m_continuous_checkCheckBox);
            this.groupBox3.Controls.Add(if_deactivatorLabel);
            this.groupBox3.Controls.Add(this.if_deactivatorCheckBox);
            this.groupBox3.Controls.Add(this.m_trigger_items_clear);
            this.groupBox3.Controls.Add(m_typeLabel2);
            this.groupBox3.Controls.Add(this.m_typeComboBox2);
            this.groupBox3.Controls.Add(m_deactivatedLabel);
            this.groupBox3.Controls.Add(this.m_deactivatedCheckBox);
            this.groupBox3.Controls.Add(m_cooldownLabel);
            this.groupBox3.Controls.Add(this.m_cooldownNumericUpDown);
            this.groupBox3.Controls.Add(m_activeLabel);
            this.groupBox3.Controls.Add(this.m_activeCheckBox);
            this.groupBox3.Controls.Add(num_triggerable_objectsLabel);
            this.groupBox3.Controls.Add(this.num_triggerable_objectsTextBox);
            this.groupBox3.Controls.Add(this.m_remove_TriggerableObject);
            this.groupBox3.Controls.Add(this.m_attach_triggerable_object_button);
            this.groupBox3.Controls.Add(this.m_nameLabel4);
            this.groupBox3.Controls.Add(this.m_nameTextBox4);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(314, 354);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Object Types";
            // 
            // m_continuous_checkCheckBox
            // 
            this.m_continuous_checkCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.triggerBindingSource, "m_continuous_check", true));
            this.m_continuous_checkCheckBox.Location = new System.Drawing.Point(116, 245);
            this.m_continuous_checkCheckBox.Name = "m_continuous_checkCheckBox";
            this.m_continuous_checkCheckBox.Size = new System.Drawing.Size(104, 24);
            this.m_continuous_checkCheckBox.TabIndex = 23;
            this.m_continuous_checkCheckBox.Text = "checkBox1";
            this.m_continuous_checkCheckBox.UseVisualStyleBackColor = true;
            // 
            // triggerBindingSource
            // 
            this.triggerBindingSource.DataSource = typeof(speedup.Trigger);
            // 
            // if_deactivatorCheckBox
            // 
            this.if_deactivatorCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.triggerBindingSource, "m_if_deactivator", true));
            this.if_deactivatorCheckBox.Location = new System.Drawing.Point(210, 325);
            this.if_deactivatorCheckBox.Name = "if_deactivatorCheckBox";
            this.if_deactivatorCheckBox.Size = new System.Drawing.Size(104, 24);
            this.if_deactivatorCheckBox.TabIndex = 22;
            this.if_deactivatorCheckBox.Text = "checkBox1";
            this.if_deactivatorCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_trigger_items_clear
            // 
            this.m_trigger_items_clear.Location = new System.Drawing.Point(-1, 318);
            this.m_trigger_items_clear.Name = "m_trigger_items_clear";
            this.m_trigger_items_clear.Size = new System.Drawing.Size(120, 36);
            this.m_trigger_items_clear.TabIndex = 21;
            this.m_trigger_items_clear.Text = "Clear all TriggerableObjects";
            this.m_trigger_items_clear.UseVisualStyleBackColor = true;
            this.m_trigger_items_clear.Click += new System.EventHandler(this.m_trigger_items_clear_Click);
            // 
            // m_typeComboBox2
            // 
            this.m_typeComboBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.triggerBindingSource, "m_change_type", true));
            this.m_typeComboBox2.FormattingEnabled = true;
            this.m_typeComboBox2.Items.AddRange(new object[] {
            "WALL",
            "FLOOR",
            "NO_COLLISION"});
            this.m_typeComboBox2.Location = new System.Drawing.Point(98, 278);
            this.m_typeComboBox2.Name = "m_typeComboBox2";
            this.m_typeComboBox2.Size = new System.Drawing.Size(121, 21);
            this.m_typeComboBox2.TabIndex = 20;
            this.m_typeComboBox2.Text = "FLOOR";
            // 
            // m_deactivatedCheckBox
            // 
            this.m_deactivatedCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.triggerBindingSource, "m_deactivated", true));
            this.m_deactivatedCheckBox.Location = new System.Drawing.Point(116, 222);
            this.m_deactivatedCheckBox.Name = "m_deactivatedCheckBox";
            this.m_deactivatedCheckBox.Size = new System.Drawing.Size(104, 24);
            this.m_deactivatedCheckBox.TabIndex = 19;
            this.m_deactivatedCheckBox.Text = "checkBox1";
            this.m_deactivatedCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_cooldownNumericUpDown
            // 
            this.m_cooldownNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.triggerBindingSource, "m_cooldown", true));
            this.m_cooldownNumericUpDown.Location = new System.Drawing.Point(151, 172);
            this.m_cooldownNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.m_cooldownNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.m_cooldownNumericUpDown.Name = "m_cooldownNumericUpDown";
            this.m_cooldownNumericUpDown.Size = new System.Drawing.Size(108, 20);
            this.m_cooldownNumericUpDown.TabIndex = 18;
            // 
            // m_activeCheckBox
            // 
            this.m_activeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.triggerBindingSource, "m_active", true));
            this.m_activeCheckBox.Location = new System.Drawing.Point(155, 116);
            this.m_activeCheckBox.Name = "m_activeCheckBox";
            this.m_activeCheckBox.Size = new System.Drawing.Size(104, 24);
            this.m_activeCheckBox.TabIndex = 17;
            this.m_activeCheckBox.Text = "checkBox1";
            this.m_activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // num_triggerable_objectsTextBox
            // 
            this.num_triggerable_objectsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.triggerBindingSource, "num_triggerable_objects", true));
            this.num_triggerable_objectsTextBox.Location = new System.Drawing.Point(155, 144);
            this.num_triggerable_objectsTextBox.Name = "num_triggerable_objectsTextBox";
            this.num_triggerable_objectsTextBox.Size = new System.Drawing.Size(100, 20);
            this.num_triggerable_objectsTextBox.TabIndex = 16;
            // 
            // m_remove_TriggerableObject
            // 
            this.m_remove_TriggerableObject.Location = new System.Drawing.Point(151, 37);
            this.m_remove_TriggerableObject.Name = "m_remove_TriggerableObject";
            this.m_remove_TriggerableObject.Size = new System.Drawing.Size(120, 73);
            this.m_remove_TriggerableObject.TabIndex = 15;
            this.m_remove_TriggerableObject.Text = "Remove Current TriggerableObject Source";
            this.m_remove_TriggerableObject.UseVisualStyleBackColor = true;
            this.m_remove_TriggerableObject.Click += new System.EventHandler(this.m_remove_TriggerableObject_Click);
            // 
            // m_attach_triggerable_object_button
            // 
            this.m_attach_triggerable_object_button.Location = new System.Drawing.Point(11, 37);
            this.m_attach_triggerable_object_button.Name = "m_attach_triggerable_object_button";
            this.m_attach_triggerable_object_button.Size = new System.Drawing.Size(120, 73);
            this.m_attach_triggerable_object_button.TabIndex = 14;
            this.m_attach_triggerable_object_button.Text = "Add Current TriggerableObject Source";
            this.m_attach_triggerable_object_button.UseVisualStyleBackColor = true;
            this.m_attach_triggerable_object_button.Click += new System.EventHandler(this.m_attach_triggerable_object_button_Click);
            // 
            // m_nameLabel4
            // 
            this.m_nameLabel4.AutoSize = true;
            this.m_nameLabel4.Location = new System.Drawing.Point(33, 198);
            this.m_nameLabel4.Name = "m_nameLabel4";
            this.m_nameLabel4.Size = new System.Drawing.Size(47, 13);
            this.m_nameLabel4.TabIndex = 12;
            this.m_nameLabel4.Text = "m name:";
            // 
            // m_nameTextBox4
            // 
            this.m_nameTextBox4.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.triggerBindingSource, "m_name", true));
            this.m_nameTextBox4.Location = new System.Drawing.Point(153, 195);
            this.m_nameTextBox4.Name = "m_nameTextBox4";
            this.m_nameTextBox4.Size = new System.Drawing.Size(104, 20);
            this.m_nameTextBox4.TabIndex = 13;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(9, 299);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(91, 17);
            this.checkBox2.TabIndex = 11;
            this.checkBox2.Text = "Kinetic Body?";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(125, 277);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 39);
            this.button1.TabIndex = 8;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // m_tab_condition_trigger
            // 
            this.m_tab_condition_trigger.AutoScroll = true;
            this.m_tab_condition_trigger.Controls.Add(m_condition_typeLabel);
            this.m_tab_condition_trigger.Controls.Add(this.m_condition_typeComboBox);
            this.m_tab_condition_trigger.Controls.Add(num_cond_objectsLabel);
            this.m_tab_condition_trigger.Controls.Add(this.num_cond_objectsTextBox);
            this.m_tab_condition_trigger.Controls.Add(this.m_trig_objs_clear);
            this.m_tab_condition_trigger.Controls.Add(this.m_cond_remove_obj);
            this.m_tab_condition_trigger.Controls.Add(this.m_condition_add_obj);
            this.m_tab_condition_trigger.Controls.Add(m_nameLabel2);
            this.m_tab_condition_trigger.Controls.Add(this.m_nameTextBox2);
            this.m_tab_condition_trigger.Location = new System.Drawing.Point(4, 22);
            this.m_tab_condition_trigger.Name = "m_tab_condition_trigger";
            this.m_tab_condition_trigger.Size = new System.Drawing.Size(320, 360);
            this.m_tab_condition_trigger.TabIndex = 16;
            this.m_tab_condition_trigger.Text = "Condition Trigger";
            this.m_tab_condition_trigger.UseVisualStyleBackColor = true;
            // 
            // m_condition_typeComboBox
            // 
            this.m_condition_typeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conditionTriggeredBindingSource, "m_condition_type", true));
            this.m_condition_typeComboBox.FormattingEnabled = true;
            this.m_condition_typeComboBox.Items.AddRange(new object[] {
            "DEATH",
            "NINJA_HAS_ITEM",
            "EVADE_ALIENS"});
            this.m_condition_typeComboBox.Location = new System.Drawing.Point(115, 237);
            this.m_condition_typeComboBox.Name = "m_condition_typeComboBox";
            this.m_condition_typeComboBox.Size = new System.Drawing.Size(121, 21);
            this.m_condition_typeComboBox.TabIndex = 24;
            this.m_condition_typeComboBox.Text = "DEATH";
            // 
            // conditionTriggeredBindingSource
            // 
            this.conditionTriggeredBindingSource.DataSource = typeof(speedup.ConditionTriggered);
            // 
            // num_cond_objectsTextBox
            // 
            this.num_cond_objectsTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conditionTriggeredBindingSource, "num_cond_objects", true));
            this.num_cond_objectsTextBox.Location = new System.Drawing.Point(111, 174);
            this.num_cond_objectsTextBox.Name = "num_cond_objectsTextBox";
            this.num_cond_objectsTextBox.Size = new System.Drawing.Size(100, 20);
            this.num_cond_objectsTextBox.TabIndex = 23;
            // 
            // m_trig_objs_clear
            // 
            this.m_trig_objs_clear.Location = new System.Drawing.Point(20, 311);
            this.m_trig_objs_clear.Name = "m_trig_objs_clear";
            this.m_trig_objs_clear.Size = new System.Drawing.Size(120, 36);
            this.m_trig_objs_clear.TabIndex = 22;
            this.m_trig_objs_clear.Text = "Clear all Condition Objects";
            this.m_trig_objs_clear.UseVisualStyleBackColor = true;
            this.m_trig_objs_clear.Click += new System.EventHandler(this.m_trig_objs_clear_Click);
            // 
            // m_cond_remove_obj
            // 
            this.m_cond_remove_obj.Location = new System.Drawing.Point(160, 27);
            this.m_cond_remove_obj.Name = "m_cond_remove_obj";
            this.m_cond_remove_obj.Size = new System.Drawing.Size(120, 73);
            this.m_cond_remove_obj.TabIndex = 17;
            this.m_cond_remove_obj.Text = "Remove Current GameObjectSource from condition";
            this.m_cond_remove_obj.UseVisualStyleBackColor = true;
            this.m_cond_remove_obj.Click += new System.EventHandler(this.m_cond_remove_obj_Click);
            // 
            // m_condition_add_obj
            // 
            this.m_condition_add_obj.Location = new System.Drawing.Point(20, 27);
            this.m_condition_add_obj.Name = "m_condition_add_obj";
            this.m_condition_add_obj.Size = new System.Drawing.Size(120, 73);
            this.m_condition_add_obj.TabIndex = 16;
            this.m_condition_add_obj.Text = "Add GameObjectSource for condition";
            this.m_condition_add_obj.UseVisualStyleBackColor = true;
            this.m_condition_add_obj.Click += new System.EventHandler(this.m_condition_add_obj_Click);
            // 
            // m_nameTextBox2
            // 
            this.m_nameTextBox2.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.conditionTriggeredBindingSource, "m_name", true));
            this.m_nameTextBox2.Location = new System.Drawing.Point(85, 133);
            this.m_nameTextBox2.Name = "m_nameTextBox2";
            this.m_nameTextBox2.Size = new System.Drawing.Size(100, 20);
            this.m_nameTextBox2.TabIndex = 1;
            // 
            // m_triggerable_obj_tab
            // 
            this.m_triggerable_obj_tab.Controls.Add(this.groupBox4);
            this.m_triggerable_obj_tab.Controls.Add(this.checkBox4);
            this.m_triggerable_obj_tab.Controls.Add(this.button5);
            this.m_triggerable_obj_tab.Location = new System.Drawing.Point(4, 22);
            this.m_triggerable_obj_tab.Name = "m_triggerable_obj_tab";
            this.m_triggerable_obj_tab.Padding = new System.Windows.Forms.Padding(3);
            this.m_triggerable_obj_tab.Size = new System.Drawing.Size(320, 360);
            this.m_triggerable_obj_tab.TabIndex = 12;
            this.m_triggerable_obj_tab.Text = "Triggerable Object";
            this.m_triggerable_obj_tab.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(obj_countLabel);
            this.groupBox4.Controls.Add(this.obj_countTextBox);
            this.groupBox4.Controls.Add(this.button_trigobj_clear);
            this.groupBox4.Controls.Add(this.button_trigobj_add_object);
            this.groupBox4.Controls.Add(m_textbox_widthLabel);
            this.groupBox4.Controls.Add(this.m_textbox_widthNumericUpDown);
            this.groupBox4.Controls.Add(m_textLabel);
            this.groupBox4.Controls.Add(this.m_textTextBox);
            this.groupBox4.Controls.Add(m_zoom_multLabel);
            this.groupBox4.Controls.Add(this.m_zoom_multNumericUpDown);
            this.groupBox4.Controls.Add(m_set_zoomLabel);
            this.groupBox4.Controls.Add(this.m_set_zoomNumericUpDown);
            this.groupBox4.Controls.Add(m_follow_meLabel);
            this.groupBox4.Controls.Add(this.m_follow_meCheckBox);
            this.groupBox4.Controls.Add(m_timer_checkpoint_setLabel);
            this.groupBox4.Controls.Add(this.m_timer_checkpoint_setNumericUpDown);
            this.groupBox4.Controls.Add(m_invisibleLabel);
            this.groupBox4.Controls.Add(this.m_invisibleCheckBox);
            this.groupBox4.Controls.Add(m_lengthLabel);
            this.groupBox4.Controls.Add(this.m_lengthNumericUpDown);
            this.groupBox4.Controls.Add(this.m_is_activeLabel);
            this.groupBox4.Controls.Add(this.m_is_activeCheckBox);
            this.groupBox4.Controls.Add(this.m_nameLabel5);
            this.groupBox4.Controls.Add(this.m_nameTextBox5);
            this.groupBox4.Controls.Add(this.m_typeLabel1);
            this.groupBox4.Controls.Add(this.m_typeComboBox);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(314, 354);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Object Types";
            // 
            // button_trigobj_clear
            // 
            this.button_trigobj_clear.Location = new System.Drawing.Point(232, 73);
            this.button_trigobj_clear.Name = "button_trigobj_clear";
            this.button_trigobj_clear.Size = new System.Drawing.Size(79, 36);
            this.button_trigobj_clear.TabIndex = 29;
            this.button_trigobj_clear.Text = "Clear all Objects";
            this.button_trigobj_clear.UseVisualStyleBackColor = true;
            this.button_trigobj_clear.Click += new System.EventHandler(this.button_trigobj_clear_Click);
            // 
            // button_trigobj_add_object
            // 
            this.button_trigobj_add_object.Location = new System.Drawing.Point(152, 72);
            this.button_trigobj_add_object.Name = "button_trigobj_add_object";
            this.button_trigobj_add_object.Size = new System.Drawing.Size(82, 39);
            this.button_trigobj_add_object.TabIndex = 28;
            this.button_trigobj_add_object.Text = "Add Current GameObject";
            this.button_trigobj_add_object.UseVisualStyleBackColor = true;
            this.button_trigobj_add_object.Click += new System.EventHandler(this.button_trigobj_add_object_Click);
            // 
            // m_textbox_widthNumericUpDown
            // 
            this.m_textbox_widthNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.triggerableObjectBindingSource, "m_textbox_width", true));
            this.m_textbox_widthNumericUpDown.DecimalPlaces = 2;
            this.m_textbox_widthNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_textbox_widthNumericUpDown.Location = new System.Drawing.Point(106, 255);
            this.m_textbox_widthNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.m_textbox_widthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_textbox_widthNumericUpDown.Name = "m_textbox_widthNumericUpDown";
            this.m_textbox_widthNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_textbox_widthNumericUpDown.TabIndex = 27;
            this.m_textbox_widthNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // triggerableObjectBindingSource
            // 
            this.triggerableObjectBindingSource.DataSource = typeof(speedup.TriggerableObject);
            // 
            // m_textTextBox
            // 
            this.m_textTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.triggerableObjectBindingSource, "m_text", true));
            this.m_textTextBox.Location = new System.Drawing.Point(108, 224);
            this.m_textTextBox.Name = "m_textTextBox";
            this.m_textTextBox.Size = new System.Drawing.Size(100, 20);
            this.m_textTextBox.TabIndex = 26;
            // 
            // m_zoom_multNumericUpDown
            // 
            this.m_zoom_multNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.triggerableObjectBindingSource, "m_zoom_mult", true));
            this.m_zoom_multNumericUpDown.DecimalPlaces = 3;
            this.m_zoom_multNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.m_zoom_multNumericUpDown.Location = new System.Drawing.Point(101, 328);
            this.m_zoom_multNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.m_zoom_multNumericUpDown.Name = "m_zoom_multNumericUpDown";
            this.m_zoom_multNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_zoom_multNumericUpDown.TabIndex = 25;
            this.m_zoom_multNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // m_set_zoomNumericUpDown
            // 
            this.m_set_zoomNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.triggerableObjectBindingSource, "m_set_zoom", true));
            this.m_set_zoomNumericUpDown.DecimalPlaces = 3;
            this.m_set_zoomNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.m_set_zoomNumericUpDown.Location = new System.Drawing.Point(174, 304);
            this.m_set_zoomNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.m_set_zoomNumericUpDown.Name = "m_set_zoomNumericUpDown";
            this.m_set_zoomNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_set_zoomNumericUpDown.TabIndex = 24;
            this.m_set_zoomNumericUpDown.Value = new decimal(new int[] {
            4,
            0,
            0,
            65536});
            // 
            // m_follow_meCheckBox
            // 
            this.m_follow_meCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.triggerableObjectBindingSource, "m_follow_me", true));
            this.m_follow_meCheckBox.Location = new System.Drawing.Point(224, 51);
            this.m_follow_meCheckBox.Name = "m_follow_meCheckBox";
            this.m_follow_meCheckBox.Size = new System.Drawing.Size(104, 24);
            this.m_follow_meCheckBox.TabIndex = 23;
            this.m_follow_meCheckBox.Text = "checkBox1";
            this.m_follow_meCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_timer_checkpoint_setNumericUpDown
            // 
            this.m_timer_checkpoint_setNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.triggerableObjectBindingSource, "m_timer_checkpoint_set", true));
            this.m_timer_checkpoint_setNumericUpDown.Location = new System.Drawing.Point(132, 281);
            this.m_timer_checkpoint_setNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.m_timer_checkpoint_setNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.m_timer_checkpoint_setNumericUpDown.Name = "m_timer_checkpoint_setNumericUpDown";
            this.m_timer_checkpoint_setNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_timer_checkpoint_setNumericUpDown.TabIndex = 22;
            this.m_timer_checkpoint_setNumericUpDown.Value = new decimal(new int[] {
            120,
            0,
            0,
            0});
            // 
            // m_invisibleCheckBox
            // 
            this.m_invisibleCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.triggerableObjectBindingSource, "m_invisible", true));
            this.m_invisibleCheckBox.Location = new System.Drawing.Point(72, 51);
            this.m_invisibleCheckBox.Name = "m_invisibleCheckBox";
            this.m_invisibleCheckBox.Size = new System.Drawing.Size(104, 24);
            this.m_invisibleCheckBox.TabIndex = 21;
            this.m_invisibleCheckBox.Text = "checkBox1";
            this.m_invisibleCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_lengthNumericUpDown
            // 
            this.m_lengthNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.triggerableObjectBindingSource, "m_length", true));
            this.m_lengthNumericUpDown.DecimalPlaces = 2;
            this.m_lengthNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_lengthNumericUpDown.Location = new System.Drawing.Point(56, 117);
            this.m_lengthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.m_lengthNumericUpDown.Name = "m_lengthNumericUpDown";
            this.m_lengthNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.m_lengthNumericUpDown.TabIndex = 20;
            this.m_lengthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // m_is_activeLabel
            // 
            this.m_is_activeLabel.AutoSize = true;
            this.m_is_activeLabel.Location = new System.Drawing.Point(6, 82);
            this.m_is_activeLabel.Name = "m_is_activeLabel";
            this.m_is_activeLabel.Size = new System.Drawing.Size(60, 13);
            this.m_is_activeLabel.TabIndex = 4;
            this.m_is_activeLabel.Text = "m is active:";
            // 
            // m_is_activeCheckBox
            // 
            this.m_is_activeCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.triggerableObjectBindingSource, "m_is_active", true));
            this.m_is_activeCheckBox.Location = new System.Drawing.Point(72, 77);
            this.m_is_activeCheckBox.Name = "m_is_activeCheckBox";
            this.m_is_activeCheckBox.Size = new System.Drawing.Size(121, 24);
            this.m_is_activeCheckBox.TabIndex = 5;
            this.m_is_activeCheckBox.Text = "checkBox5";
            this.m_is_activeCheckBox.UseVisualStyleBackColor = true;
            // 
            // m_nameLabel5
            // 
            this.m_nameLabel5.AutoSize = true;
            this.m_nameLabel5.Location = new System.Drawing.Point(6, 200);
            this.m_nameLabel5.Name = "m_nameLabel5";
            this.m_nameLabel5.Size = new System.Drawing.Size(47, 13);
            this.m_nameLabel5.TabIndex = 12;
            this.m_nameLabel5.Text = "m name:";
            // 
            // m_nameTextBox5
            // 
            this.m_nameTextBox5.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.triggerableObjectBindingSource, "m_name", true));
            this.m_nameTextBox5.Location = new System.Drawing.Point(113, 197);
            this.m_nameTextBox5.Name = "m_nameTextBox5";
            this.m_nameTextBox5.Size = new System.Drawing.Size(121, 20);
            this.m_nameTextBox5.TabIndex = 13;
            // 
            // m_typeLabel1
            // 
            this.m_typeLabel1.AutoSize = true;
            this.m_typeLabel1.Location = new System.Drawing.Point(6, 173);
            this.m_typeLabel1.Name = "m_typeLabel1";
            this.m_typeLabel1.Size = new System.Drawing.Size(41, 13);
            this.m_typeLabel1.TabIndex = 18;
            this.m_typeLabel1.Text = "m type:";
            // 
            // m_typeComboBox
            // 
            this.m_typeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.triggerableObjectBindingSource, "m_type", true));
            this.m_typeComboBox.FormattingEnabled = true;
            this.m_typeComboBox.Items.AddRange(new object[] {
            "DOOR",
            "GOAL",
            "CHECKPOINT",
            "CAMERA_CONTROL",
            "CAMERA_RESET",
            "ZOOM_CONTROL",
            "FLAME",
            "TEXTBOX",
            "BODY_ENABLER"});
            this.m_typeComboBox.Location = new System.Drawing.Point(113, 170);
            this.m_typeComboBox.Name = "m_typeComboBox";
            this.m_typeComboBox.Size = new System.Drawing.Size(121, 21);
            this.m_typeComboBox.TabIndex = 19;
            this.m_typeComboBox.Text = "DOOR";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(9, 299);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(91, 17);
            this.checkBox4.TabIndex = 11;
            this.checkBox4.Text = "Kinetic Body?";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(125, 277);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(82, 39);
            this.button5.TabIndex = 8;
            this.button5.Text = "Apply";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // m_fixture_tab
            // 
            this.m_fixture_tab.Controls.Add(collidesWithLabel);
            this.m_fixture_tab.Controls.Add(this.collidesWithComboBox);
            this.m_fixture_tab.Controls.Add(childCountLabel);
            this.m_fixture_tab.Controls.Add(this.childCountTextBox);
            this.m_fixture_tab.Controls.Add(densityLabel1);
            this.m_fixture_tab.Controls.Add(this.densityNumericUpDown1);
            this.m_fixture_tab.Controls.Add(radiusLabel);
            this.m_fixture_tab.Controls.Add(this.radiusNumericUpDown);
            this.m_fixture_tab.Controls.Add(shapeTypeLabel1);
            this.m_fixture_tab.Controls.Add(this.shapeTypeComboBox1);
            this.m_fixture_tab.Controls.Add(fixtureIdLabel);
            this.m_fixture_tab.Controls.Add(this.fixtureIdTextBox);
            this.m_fixture_tab.Controls.Add(frictionLabel1);
            this.m_fixture_tab.Controls.Add(this.frictionNumericUpDown);
            this.m_fixture_tab.Controls.Add(isDisposedLabel1);
            this.m_fixture_tab.Controls.Add(this.isDisposedCheckBox1);
            this.m_fixture_tab.Controls.Add(isSensorLabel1);
            this.m_fixture_tab.Controls.Add(this.isSensorCheckBox1);
            this.m_fixture_tab.Controls.Add(restitutionLabel1);
            this.m_fixture_tab.Controls.Add(this.restitutionNumericUpDown1);
            this.m_fixture_tab.Location = new System.Drawing.Point(4, 22);
            this.m_fixture_tab.Name = "m_fixture_tab";
            this.m_fixture_tab.Padding = new System.Windows.Forms.Padding(3);
            this.m_fixture_tab.Size = new System.Drawing.Size(320, 360);
            this.m_fixture_tab.TabIndex = 15;
            this.m_fixture_tab.Text = "Fixture(Shape)";
            this.m_fixture_tab.UseVisualStyleBackColor = true;
            // 
            // collidesWithComboBox
            // 
            this.collidesWithComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fixtureListBindingSource, "CollidesWith", true));
            this.collidesWithComboBox.FormattingEnabled = true;
            this.collidesWithComboBox.Items.AddRange(new object[] {
            "Category.None",
            "Category.All",
            "Category.Cat1",
            "Category.Cat2",
            "Category.Cat3"});
            this.collidesWithComboBox.Location = new System.Drawing.Point(115, 33);
            this.collidesWithComboBox.Name = "collidesWithComboBox";
            this.collidesWithComboBox.Size = new System.Drawing.Size(121, 21);
            this.collidesWithComboBox.TabIndex = 20;
            // 
            // childCountTextBox
            // 
            this.childCountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fixtureListBindingSource, "Shape.ChildCount", true));
            this.childCountTextBox.Location = new System.Drawing.Point(112, 233);
            this.childCountTextBox.Name = "childCountTextBox";
            this.childCountTextBox.Size = new System.Drawing.Size(121, 20);
            this.childCountTextBox.TabIndex = 13;
            // 
            // densityNumericUpDown1
            // 
            this.densityNumericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.fixtureListBindingSource, "Shape.Density", true));
            this.densityNumericUpDown1.DecimalPlaces = 2;
            this.densityNumericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.densityNumericUpDown1.Location = new System.Drawing.Point(112, 259);
            this.densityNumericUpDown1.Name = "densityNumericUpDown1";
            this.densityNumericUpDown1.Size = new System.Drawing.Size(121, 20);
            this.densityNumericUpDown1.TabIndex = 15;
            this.densityNumericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // radiusNumericUpDown
            // 
            this.radiusNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.fixtureListBindingSource, "Shape.Radius", true));
            this.radiusNumericUpDown.DecimalPlaces = 2;
            this.radiusNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.radiusNumericUpDown.Location = new System.Drawing.Point(112, 285);
            this.radiusNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.radiusNumericUpDown.Name = "radiusNumericUpDown";
            this.radiusNumericUpDown.Size = new System.Drawing.Size(121, 20);
            this.radiusNumericUpDown.TabIndex = 17;
            this.radiusNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            // 
            // shapeTypeComboBox1
            // 
            this.shapeTypeComboBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fixtureListBindingSource, "Shape.ShapeType", true));
            this.shapeTypeComboBox1.FormattingEnabled = true;
            this.shapeTypeComboBox1.Items.AddRange(new object[] {
            "Circle",
            "Loop",
            "Edge",
            "TypeCount",
            "Unknown"});
            this.shapeTypeComboBox1.Location = new System.Drawing.Point(112, 311);
            this.shapeTypeComboBox1.Name = "shapeTypeComboBox1";
            this.shapeTypeComboBox1.Size = new System.Drawing.Size(121, 21);
            this.shapeTypeComboBox1.TabIndex = 19;
            // 
            // fixtureIdTextBox
            // 
            this.fixtureIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fixtureListBindingSource, "FixtureId", true));
            this.fixtureIdTextBox.Location = new System.Drawing.Point(115, 61);
            this.fixtureIdTextBox.Name = "fixtureIdTextBox";
            this.fixtureIdTextBox.Size = new System.Drawing.Size(120, 20);
            this.fixtureIdTextBox.TabIndex = 3;
            // 
            // frictionNumericUpDown
            // 
            this.frictionNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.fixtureListBindingSource, "Friction", true));
            this.frictionNumericUpDown.Location = new System.Drawing.Point(115, 87);
            this.frictionNumericUpDown.Name = "frictionNumericUpDown";
            this.frictionNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.frictionNumericUpDown.TabIndex = 5;
            // 
            // isDisposedCheckBox1
            // 
            this.isDisposedCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.fixtureListBindingSource, "IsDisposed", true));
            this.isDisposedCheckBox1.Location = new System.Drawing.Point(115, 113);
            this.isDisposedCheckBox1.Name = "isDisposedCheckBox1";
            this.isDisposedCheckBox1.Size = new System.Drawing.Size(120, 24);
            this.isDisposedCheckBox1.TabIndex = 7;
            this.isDisposedCheckBox1.Text = "checkBox1";
            this.isDisposedCheckBox1.UseVisualStyleBackColor = true;
            // 
            // isSensorCheckBox1
            // 
            this.isSensorCheckBox1.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.fixtureListBindingSource, "IsSensor", true));
            this.isSensorCheckBox1.Location = new System.Drawing.Point(115, 143);
            this.isSensorCheckBox1.Name = "isSensorCheckBox1";
            this.isSensorCheckBox1.Size = new System.Drawing.Size(120, 24);
            this.isSensorCheckBox1.TabIndex = 9;
            this.isSensorCheckBox1.Text = "checkBox1";
            this.isSensorCheckBox1.UseVisualStyleBackColor = true;
            // 
            // restitutionNumericUpDown1
            // 
            this.restitutionNumericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.fixtureListBindingSource, "Restitution", true));
            this.restitutionNumericUpDown1.Location = new System.Drawing.Point(115, 173);
            this.restitutionNumericUpDown1.Name = "restitutionNumericUpDown1";
            this.restitutionNumericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.restitutionNumericUpDown1.TabIndex = 11;
            // 
            // copy_tab
            // 
            this.copy_tab.Controls.Add(this.copy_advanced_button);
            this.copy_tab.Controls.Add(this.rb_copy_loc_same);
            this.copy_tab.Controls.Add(label10);
            this.copy_tab.Controls.Add(this.radioButton4);
            this.copy_tab.Controls.Add(this.rb_copy_loc_right);
            this.copy_tab.Controls.Add(this.rb_copy_loc_up);
            this.copy_tab.Controls.Add(this.rb_copy_loc_Left);
            this.copy_tab.Controls.Add(label9);
            this.copy_tab.Controls.Add(this.numericUpDown1);
            this.copy_tab.Location = new System.Drawing.Point(4, 22);
            this.copy_tab.Name = "copy_tab";
            this.copy_tab.Padding = new System.Windows.Forms.Padding(3);
            this.copy_tab.Size = new System.Drawing.Size(320, 360);
            this.copy_tab.TabIndex = 19;
            this.copy_tab.Text = "Advanced Copy";
            this.copy_tab.UseVisualStyleBackColor = true;
            // 
            // copy_advanced_button
            // 
            this.copy_advanced_button.Location = new System.Drawing.Point(106, 270);
            this.copy_advanced_button.Name = "copy_advanced_button";
            this.copy_advanced_button.Size = new System.Drawing.Size(82, 39);
            this.copy_advanced_button.TabIndex = 101;
            this.copy_advanced_button.Text = "Advanced Copy item";
            this.copy_advanced_button.UseVisualStyleBackColor = true;
            this.copy_advanced_button.Click += new System.EventHandler(this.copy_advanced_button_Click);
            // 
            // rb_copy_loc_same
            // 
            this.rb_copy_loc_same.AutoSize = true;
            this.rb_copy_loc_same.Location = new System.Drawing.Point(95, 153);
            this.rb_copy_loc_same.Name = "rb_copy_loc_same";
            this.rb_copy_loc_same.Size = new System.Drawing.Size(75, 17);
            this.rb_copy_loc_same.TabIndex = 100;
            this.rb_copy_loc_same.Text = "Same spot";
            this.rb_copy_loc_same.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(106, 206);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(53, 17);
            this.radioButton4.TabIndex = 98;
            this.radioButton4.Text = "Down";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // rb_copy_loc_right
            // 
            this.rb_copy_loc_right.AutoSize = true;
            this.rb_copy_loc_right.Location = new System.Drawing.Point(191, 153);
            this.rb_copy_loc_right.Name = "rb_copy_loc_right";
            this.rb_copy_loc_right.Size = new System.Drawing.Size(50, 17);
            this.rb_copy_loc_right.TabIndex = 97;
            this.rb_copy_loc_right.Text = "Right";
            this.rb_copy_loc_right.UseVisualStyleBackColor = true;
            // 
            // rb_copy_loc_up
            // 
            this.rb_copy_loc_up.AutoSize = true;
            this.rb_copy_loc_up.Location = new System.Drawing.Point(106, 117);
            this.rb_copy_loc_up.Name = "rb_copy_loc_up";
            this.rb_copy_loc_up.Size = new System.Drawing.Size(39, 17);
            this.rb_copy_loc_up.TabIndex = 96;
            this.rb_copy_loc_up.Text = "Up";
            this.rb_copy_loc_up.UseVisualStyleBackColor = true;
            // 
            // rb_copy_loc_Left
            // 
            this.rb_copy_loc_Left.AutoSize = true;
            this.rb_copy_loc_Left.Location = new System.Drawing.Point(15, 153);
            this.rb_copy_loc_Left.Name = "rb_copy_loc_Left";
            this.rb_copy_loc_Left.Size = new System.Drawing.Size(43, 17);
            this.rb_copy_loc_Left.TabIndex = 95;
            this.rb_copy_loc_Left.Text = "Left";
            this.rb_copy_loc_Left.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(132, 35);
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 94;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 25);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(328, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menu_Main";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewLevelToolStripMenuItem1,
            this.toolStripSeparator1,
            this.mi_Save,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator3,
            this.mi_Load_Level,
            this.toolStripSeparator2,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.fileToolStripMenuItem.Text = "World";
            // 
            // createNewLevelToolStripMenuItem1
            // 
            this.createNewLevelToolStripMenuItem1.Name = "createNewLevelToolStripMenuItem1";
            this.createNewLevelToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.createNewLevelToolStripMenuItem1.Size = new System.Drawing.Size(206, 22);
            this.createNewLevelToolStripMenuItem1.Text = "Create New Level";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // mi_Save
            // 
            this.mi_Save.Name = "mi_Save";
            this.mi_Save.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mi_Save.Size = new System.Drawing.Size(206, 22);
            this.mi_Save.Text = "Save";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(203, 6);
            // 
            // mi_Load_Level
            // 
            this.mi_Load_Level.Name = "mi_Load_Level";
            this.mi_Load_Level.Size = new System.Drawing.Size(206, 22);
            this.mi_Load_Level.Text = "Load Level...";
            this.mi_Load_Level.Click += new System.EventHandler(this.mi_Load_Level_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(203, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_Insertion,
            this.tool_Selection,
            this.delete,
            this.copy});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(328, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tool_Insertion
            // 
            this.tool_Insertion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tool_Insertion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_Insertion.Name = "tool_Insertion";
            this.tool_Insertion.Size = new System.Drawing.Size(40, 22);
            this.tool_Insertion.Text = "Insert";
            this.tool_Insertion.Click += new System.EventHandler(this.tool_Insertion_Click_1);
            // 
            // tool_Selection
            // 
            this.tool_Selection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tool_Selection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tool_Selection.Name = "tool_Selection";
            this.tool_Selection.Size = new System.Drawing.Size(42, 22);
            this.tool_Selection.Text = "Select";
            this.tool_Selection.Click += new System.EventHandler(this.tool_Selection_Click_1);
            // 
            // delete
            // 
            this.delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(44, 22);
            this.delete.Text = "Delete";
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // copy
            // 
            this.copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copy.Name = "copy";
            this.copy.Size = new System.Drawing.Size(39, 22);
            this.copy.Text = "Copy";
            this.copy.Click += new System.EventHandler(this.copy_Click);
            // 
            // panel_TextureList
            // 
            this.panel_TextureList.Controls.Add(this.groupBox2);
            this.panel_TextureList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_TextureList.Location = new System.Drawing.Point(0, 0);
            this.panel_TextureList.Name = "panel_TextureList";
            this.panel_TextureList.Size = new System.Drawing.Size(328, 126);
            this.panel_TextureList.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_rb_background_tile);
            this.groupBox2.Controls.Add(this.m_poly_create_lines);
            this.groupBox2.Controls.Add(this.m_rb_poly_trigger);
            this.groupBox2.Controls.Add(this.m_rb_condition_trigger);
            this.groupBox2.Controls.Add(this.m_rb_tile);
            this.groupBox2.Controls.Add(this.m_rb_throwing);
            this.groupBox2.Controls.Add(this.apply);
            this.groupBox2.Controls.Add(this.m_rb_gameObject);
            this.groupBox2.Controls.Add(this.m_rb_triggerable_object);
            this.groupBox2.Controls.Add(this.m_rb_trigger);
            this.groupBox2.Controls.Add(this.m_rb_Ninja);
            this.groupBox2.Controls.Add(this.m_rb_alien);
            this.groupBox2.Controls.Add(this.m_rb_Wall);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 126);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Object Types";
            // 
            // m_rb_background_tile
            // 
            this.m_rb_background_tile.AutoSize = true;
            this.m_rb_background_tile.Location = new System.Drawing.Point(215, 19);
            this.m_rb_background_tile.Name = "m_rb_background_tile";
            this.m_rb_background_tile.Size = new System.Drawing.Size(98, 17);
            this.m_rb_background_tile.TabIndex = 18;
            this.m_rb_background_tile.Text = "background tile";
            this.m_rb_background_tile.UseVisualStyleBackColor = true;
            // 
            // m_poly_create_lines
            // 
            this.m_poly_create_lines.Location = new System.Drawing.Point(231, 66);
            this.m_poly_create_lines.Name = "m_poly_create_lines";
            this.m_poly_create_lines.Size = new System.Drawing.Size(82, 39);
            this.m_poly_create_lines.TabIndex = 17;
            this.m_poly_create_lines.Text = "Create Lines";
            this.m_poly_create_lines.UseVisualStyleBackColor = true;
            this.m_poly_create_lines.Click += new System.EventHandler(this.m_poly_create_lines_Click);
            // 
            // m_rb_poly_trigger
            // 
            this.m_rb_poly_trigger.AutoSize = true;
            this.m_rb_poly_trigger.Location = new System.Drawing.Point(8, 106);
            this.m_rb_poly_trigger.Name = "m_rb_poly_trigger";
            this.m_rb_poly_trigger.Size = new System.Drawing.Size(99, 17);
            this.m_rb_poly_trigger.TabIndex = 16;
            this.m_rb_poly_trigger.Text = "Polygon Trigger";
            this.m_rb_poly_trigger.UseVisualStyleBackColor = true;
            // 
            // m_rb_condition_trigger
            // 
            this.m_rb_condition_trigger.AutoSize = true;
            this.m_rb_condition_trigger.Location = new System.Drawing.Point(8, 88);
            this.m_rb_condition_trigger.Name = "m_rb_condition_trigger";
            this.m_rb_condition_trigger.Size = new System.Drawing.Size(105, 17);
            this.m_rb_condition_trigger.TabIndex = 15;
            this.m_rb_condition_trigger.Text = "Condition Trigger";
            this.m_rb_condition_trigger.UseVisualStyleBackColor = true;
            // 
            // m_rb_tile
            // 
            this.m_rb_tile.AutoSize = true;
            this.m_rb_tile.Location = new System.Drawing.Point(89, 65);
            this.m_rb_tile.Name = "m_rb_tile";
            this.m_rb_tile.Size = new System.Drawing.Size(42, 17);
            this.m_rb_tile.TabIndex = 14;
            this.m_rb_tile.Text = "Tile";
            this.m_rb_tile.UseVisualStyleBackColor = true;
            this.m_rb_tile.CheckedChanged += new System.EventHandler(this.m_rb_tile_CheckedChanged);
            // 
            // m_rb_throwing
            // 
            this.m_rb_throwing.AutoSize = true;
            this.m_rb_throwing.Location = new System.Drawing.Point(6, 61);
            this.m_rb_throwing.Name = "m_rb_throwing";
            this.m_rb_throwing.Size = new System.Drawing.Size(76, 17);
            this.m_rb_throwing.TabIndex = 13;
            this.m_rb_throwing.Text = "Create Ball";
            this.m_rb_throwing.UseVisualStyleBackColor = true;
            // 
            // apply
            // 
            this.apply.Location = new System.Drawing.Point(143, 65);
            this.apply.Name = "apply";
            this.apply.Size = new System.Drawing.Size(82, 39);
            this.apply.TabIndex = 9;
            this.apply.Text = "Apply/Make Shape";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.apply_Click);
            // 
            // m_rb_gameObject
            // 
            this.m_rb_gameObject.AutoSize = true;
            this.m_rb_gameObject.Location = new System.Drawing.Point(62, 19);
            this.m_rb_gameObject.Name = "m_rb_gameObject";
            this.m_rb_gameObject.Size = new System.Drawing.Size(96, 17);
            this.m_rb_gameObject.TabIndex = 12;
            this.m_rb_gameObject.Text = "General Object";
            this.m_rb_gameObject.UseVisualStyleBackColor = true;
            // 
            // m_rb_triggerable_object
            // 
            this.m_rb_triggerable_object.AutoSize = true;
            this.m_rb_triggerable_object.Location = new System.Drawing.Point(131, 42);
            this.m_rb_triggerable_object.Name = "m_rb_triggerable_object";
            this.m_rb_triggerable_object.Size = new System.Drawing.Size(112, 17);
            this.m_rb_triggerable_object.TabIndex = 10;
            this.m_rb_triggerable_object.Text = "Triggerable Object";
            this.m_rb_triggerable_object.UseVisualStyleBackColor = true;
            // 
            // m_rb_trigger
            // 
            this.m_rb_trigger.AutoSize = true;
            this.m_rb_trigger.Location = new System.Drawing.Point(62, 42);
            this.m_rb_trigger.Name = "m_rb_trigger";
            this.m_rb_trigger.Size = new System.Drawing.Size(58, 17);
            this.m_rb_trigger.TabIndex = 9;
            this.m_rb_trigger.Text = "Trigger";
            this.m_rb_trigger.UseVisualStyleBackColor = true;
            // 
            // m_rb_Ninja
            // 
            this.m_rb_Ninja.AutoSize = true;
            this.m_rb_Ninja.Checked = true;
            this.m_rb_Ninja.Location = new System.Drawing.Point(7, 19);
            this.m_rb_Ninja.Name = "m_rb_Ninja";
            this.m_rb_Ninja.Size = new System.Drawing.Size(49, 17);
            this.m_rb_Ninja.TabIndex = 7;
            this.m_rb_Ninja.TabStop = true;
            this.m_rb_Ninja.Text = "Ninja";
            this.m_rb_Ninja.UseVisualStyleBackColor = true;
            // 
            // m_rb_alien
            // 
            this.m_rb_alien.AutoSize = true;
            this.m_rb_alien.Location = new System.Drawing.Point(167, 19);
            this.m_rb_alien.Name = "m_rb_alien";
            this.m_rb_alien.Size = new System.Drawing.Size(48, 17);
            this.m_rb_alien.TabIndex = 11;
            this.m_rb_alien.Text = "Alien";
            this.m_rb_alien.UseVisualStyleBackColor = true;
            // 
            // m_rb_Wall
            // 
            this.m_rb_Wall.AutoSize = true;
            this.m_rb_Wall.Location = new System.Drawing.Point(6, 42);
            this.m_rb_Wall.Name = "m_rb_Wall";
            this.m_rb_Wall.Size = new System.Drawing.Size(46, 17);
            this.m_rb_Wall.TabIndex = 8;
            this.m_rb_Wall.Text = "Wall";
            this.m_rb_Wall.UseVisualStyleBackColor = true;
            // 
            // stateBindingSource
            // 
            this.stateBindingSource.DataSource = typeof(speedup.AlienController.State);
            // 
            // tNamesBindingSource
            // 
            this.tNamesBindingSource.DataSource = typeof(speedup.TNames);
            // 
            // texture_namesBindingSource
            // 
            this.texture_namesBindingSource.DataMember = "texture_names";
            this.texture_namesBindingSource.DataSource = this.staticsBindingSource;
            // 
            // staticsBindingSource
            // 
            this.staticsBindingSource.DataSource = typeof(speedup.Statics);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "m_world";
            this.dataGridViewTextBoxColumn1.HeaderText = "m_world";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "m_density";
            this.dataGridViewTextBoxColumn2.HeaderText = "m_density";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "m_friction";
            this.dataGridViewTextBoxColumn3.HeaderText = "m_friction";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "m_restitution";
            this.dataGridViewTextBoxColumn4.HeaderText = "m_restitution";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "m_rotation";
            this.dataGridViewTextBoxColumn5.HeaderText = "m_rotation";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "m_damping";
            this.dataGridViewTextBoxColumn6.HeaderText = "m_damping";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "m_radius";
            this.dataGridViewTextBoxColumn7.HeaderText = "m_radius";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "m_linear_velocity";
            this.dataGridViewTextBoxColumn8.HeaderText = "m_linear_velocity";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "m_angular_velocity";
            this.dataGridViewTextBoxColumn9.HeaderText = "m_angular_velocity";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "m_position";
            this.dataGridViewTextBoxColumn10.HeaderText = "m_position";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "m_cooloff";
            this.dataGridViewTextBoxColumn11.HeaderText = "m_cooloff";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "m_name";
            this.dataGridViewTextBoxColumn12.HeaderText = "m_name";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "m_texture";
            this.dataGridViewTextBoxColumn13.HeaderText = "m_texture";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.DataPropertyName = "m_is_dead";
            this.dataGridViewCheckBoxColumn1.HeaderText = "m_is_dead";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "m_body";
            this.dataGridViewTextBoxColumn14.HeaderText = "m_body";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "m_buffered_position";
            this.dataGridViewTextBoxColumn15.HeaderText = "m_buffered_position";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "m_buffered_angle";
            this.dataGridViewTextBoxColumn16.HeaderText = "m_buffered_angle";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "m_buffered_linear_velocity";
            this.dataGridViewTextBoxColumn17.HeaderText = "m_buffered_linear_velocity";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.DataPropertyName = "m_is_throwable";
            this.dataGridViewCheckBoxColumn2.HeaderText = "m_is_throwable";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.DataPropertyName = "m_is_destructible";
            this.dataGridViewCheckBoxColumn3.HeaderText = "m_is_destructible";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "m_destroy_threshold";
            this.dataGridViewTextBoxColumn18.HeaderText = "m_destroy_threshold";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "m_texture_name";
            this.dataGridViewTextBoxColumn19.HeaderText = "m_texture_name";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "m_texture_name_helper";
            this.dataGridViewTextBoxColumn20.HeaderText = "m_texture_name_helper";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            // 
            // floorTileBindingSource
            // 
            this.floorTileBindingSource.DataSource = typeof(speedup.FloorTile);
            // 
            // obj_countLabel
            // 
            obj_countLabel.AutoSize = true;
            obj_countLabel.Location = new System.Drawing.Point(122, 140);
            obj_countLabel.Name = "obj_countLabel";
            obj_countLabel.Size = new System.Drawing.Size(54, 13);
            obj_countLabel.TabIndex = 29;
            obj_countLabel.Text = "obj count:";
            // 
            // obj_countTextBox
            // 
            this.obj_countTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.triggerableObjectBindingSource, "obj_count", true));
            this.obj_countTextBox.Location = new System.Drawing.Point(182, 137);
            this.obj_countTextBox.Name = "obj_countTextBox";
            this.obj_countTextBox.Size = new System.Drawing.Size(100, 20);
            this.obj_countTextBox.TabIndex = 30;
            // 
            // Editor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 573);
            this.Controls.Add(this.panel_Main);
            this.Location = new System.Drawing.Point(100, 100);
            this.Name = "Editor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Editor";
            ((System.ComponentModel.ISupportInitialize)(this.fixtureListBindingSource)).EndInit();
            this.panel_Main.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel_EditOptions.ResumeLayout(false);
            this.object_tabs.ResumeLayout(false);
            this.saveLoadObject.ResumeLayout(false);
            this.saveLoadObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gameObjectBindingSource)).EndInit();
            this.m_game_object_page.ResumeLayout(false);
            this.m_game_object_page.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rotationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.densityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_change_sizeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_destroy_thresholdNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inertiaNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.linearDampingNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.massNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restitutionNumericUpDown)).EndInit();
            this.m_ninja_page.ResumeLayout(false);
            this.m_ninja_page.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ninjaBindingSource)).EndInit();
            this.PolygonObject.ResumeLayout(false);
            this.PolygonObject.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_change_size_yNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.polygonObjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_change_size_xNumericUpDown)).EndInit();
            this.m_create_poly_from_texture.ResumeLayout(false);
            this.m_create_poly_from_texture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_angle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_y_scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_x_scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_num_edges)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_y_radius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_x_radius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_poly_radius)).EndInit();
            this.m_tile_page.ResumeLayout(false);
            this.m_tile_page.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pointsBindingSource)).EndInit();
            this.Alien.ResumeLayout(false);
            this.Alien.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_attack_speedNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alienBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_laser_slowdownNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_alien_color_alpha_changeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_alien_color_blue_changeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_alien_color_red_changeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_alien_color_green_changeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_rangeNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_move_stepNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_chase_distNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_attack_distNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_attack_powerNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_attack_rateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_kill_under_speedNumericUpDown)).EndInit();
            this.m_trigger_page.ResumeLayout(false);
            this.m_trigger_page.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.triggerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_cooldownNumericUpDown)).EndInit();
            this.m_tab_condition_trigger.ResumeLayout(false);
            this.m_tab_condition_trigger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.conditionTriggeredBindingSource)).EndInit();
            this.m_triggerable_obj_tab.ResumeLayout(false);
            this.m_triggerable_obj_tab.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_textbox_widthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.triggerableObjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_zoom_multNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_set_zoomNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_timer_checkpoint_setNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_lengthNumericUpDown)).EndInit();
            this.m_fixture_tab.ResumeLayout(false);
            this.m_fixture_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.densityNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radiusNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.frictionNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.restitutionNumericUpDown1)).EndInit();
            this.copy_tab.ResumeLayout(false);
            this.copy_tab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel_TextureList.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tNamesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.texture_namesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.staticsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.floorTileBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        

        #endregion

        public Panel panel_Main;
        // public SplitContainer splitContainer1;
        public BindingSource gameObjectBindingSource;
        public BindingSource alienBindingSource;
        public BindingSource ninjaBindingSource;
        public SplitContainer splitContainer2;
        public Panel panel_EditOptions;
        public MenuStrip menuStrip1;
        public ToolStripMenuItem fileToolStripMenuItem;
        public ToolStripMenuItem createNewLevelToolStripMenuItem1;
        public ToolStripSeparator toolStripSeparator1;
        public ToolStripMenuItem mi_Save;
        public ToolStripMenuItem saveAsToolStripMenuItem;
        public ToolStripSeparator toolStripSeparator3;
        public ToolStripMenuItem mi_Load_Level;
        public ToolStripSeparator toolStripSeparator2;
        public ToolStripMenuItem exitToolStripMenuItem;
        public ToolStrip toolStrip1;
        public ToolStripButton tool_Insertion;
        public ToolStripButton tool_Selection;
        public Panel panel_TextureList;
        public Button apply;
        public RadioButton m_rb_gameObject;
        public RadioButton m_rb_alien;
        public RadioButton m_rb_triggerable_object;
        public RadioButton m_rb_trigger;
        public RadioButton m_rb_Wall;
        public RadioButton m_rb_Ninja;
        public GroupBox groupBox2;
        public BindingSource triggerBindingSource;
        public BindingSource triggerableObjectBindingSource;
        public RadioButton m_rb_throwing;
        public BindingSource polygonObjectBindingSource;
        public BindingSource m_pointsBindingSource;
        public RadioButton m_rb_tile;
        private System.ComponentModel.IContainer components;
        public TabControl object_tabs;
        public TabPage m_create_poly_from_texture;
        public TabPage m_ninja_page;
        public TextBox m_max_throwable_capacityTextBox;
        public TextBox m_maxspeedTextBox;
        public TextBox m_movement_accelTextBox;
        public TextBox m_nameTextBox1;
        public TextBox m_speedTextBox;
        public TextBox m_throw_powerTextBox;
        public CheckBox m_is_killedCheckBox;
        public CheckBox m_picking_upCheckBox;
        public TabPage m_game_object_page;
        public TextBox frictionTextBox;
        public TextBox m_nameTextBox;
        public CheckBox awakeCheckBox;
        public CheckBox enabledCheckBox;
        public CheckBox fixedRotationCheckBox;
        public CheckBox ignoreCCDCheckBox;
        public CheckBox ignoreGravityCheckBox;
        public CheckBox isBulletCheckBox;
        public CheckBox isDisposedCheckBox;
        public CheckBox isStaticCheckBox;
        public CheckBox sleepingAllowedCheckBox;
        public CheckBox m_is_deadCheckBox;
        public CheckBox m_is_destructibleCheckBox3;
        public CheckBox m_is_throwableCheckBox3;
        public TabPage m_trigger_page;
        public GroupBox groupBox3;
        public Label m_nameLabel4;
        public TextBox m_nameTextBox4;
        public CheckBox checkBox2;
        public Button button1;
        public TabPage m_triggerable_obj_tab;
        public GroupBox groupBox4;
        public Label m_is_activeLabel;
        public CheckBox m_is_activeCheckBox;
        public Label m_nameLabel5;
        public TextBox m_nameTextBox5;
        public Label m_typeLabel1;
        public ComboBox m_typeComboBox;
        public CheckBox checkBox4;
        public Button button5;
        public TabPage m_tile_page;
        public ListBox m_pointsListBox;
        public TextBox m_buffered_angleTextBox3;
        public TextBox m_nameTextBox3;
        public TextBox m_radiusTextBox4;
        public TextBox m_texture_nameTextBox4;
        public TabPage Alien;
        private TextBox m_nameTextBox6;
        private ComboBox m_typeComboBox1;
        private Label m_throw_powerLabel;
        private Label m_speedLabel;
        private Label m_picking_upLabel;
        private Label m_nameLabel1;
        private Label m_movement_accelLabel;
        private Label m_maxspeedLabel;
        private Label m_max_throwable_capacityLabel;
        private Label m_is_killedLabel;
        private ComboBox bodyTypeComboBox;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private NumericUpDown restitutionNumericUpDown;
        private NumericUpDown linearDampingNumericUpDown;
        private NumericUpDown massNumericUpDown;
        private NumericUpDown inertiaNumericUpDown;
        private BindingSource tNamesBindingSource;
        private BindingSource staticsBindingSource;
        private NumericUpDown m_destroy_thresholdNumericUpDown1;
        private NumericUpDown m_change_sizeNumericUpDown;
        private ComboBox m_collision_typeComboBox;
        private NumericUpDown m_kill_under_speedNumericUpDown;
        private BindingSource texture_namesBindingSource;
        private ComboBox m_texture_name_changeComboBox;
        public BindingSource fixtureListBindingSource;
        private NumericUpDown densityNumericUpDown;
        private CheckBox isSensorCheckBox;
        private ComboBox shapeTypeComboBox;
        private TabPage m_fixture_tab;
        private ComboBox collidesWithComboBox;
        private TextBox childCountTextBox;
        private NumericUpDown densityNumericUpDown1;
        private NumericUpDown radiusNumericUpDown;
        private ComboBox shapeTypeComboBox1;
        private TextBox fixtureIdTextBox;
        private NumericUpDown frictionNumericUpDown;
        private CheckBox isDisposedCheckBox1;
        private CheckBox isSensorCheckBox1;
        private NumericUpDown restitutionNumericUpDown1;
        private NumericUpDown m_poly_num_edges;
        private NumericUpDown m_poly_y_radius;
        private NumericUpDown m_poly_x_radius;
        private NumericUpDown m_poly_radius;
        private ComboBox m_cb_poly_tex_name;
        private NumericUpDown m_poly_y_scale;
        private NumericUpDown m_poly_x_scale;
        public Button m_poly_create_circle;
        public Button m_poly_create_rectangle;
        public Button m_poly_create_ellipse;
        private NumericUpDown m_poly_angle;
        public Button button2;
        private NumericUpDown rotationNumericUpDown;
        public Button m_attach_triggerable_object_button;
        public Button m_remove_TriggerableObject;
        private CheckBox m_activeCheckBox;
        private TextBox num_triggerable_objectsTextBox;
        private NumericUpDown m_cooldownNumericUpDown;
        private ComboBox m_typeComboBox2;
        private CheckBox m_deactivatedCheckBox;
        public ToolStripButton delete;
        public ToolStripButton copy;
        public BindingSource floorTileBindingSource;
        private ComboBox m_ai_type_changeComboBox;
        public RadioButton m_rb_condition_trigger;
        public Button m_trigger_items_clear;
        private TabPage m_tab_condition_trigger;
        private TextBox m_nameTextBox2;
        public BindingSource conditionTriggeredBindingSource;
        private NumericUpDown m_lengthNumericUpDown;
        public Button m_trig_objs_clear;
        public Button m_cond_remove_obj;
        public Button m_condition_add_obj;
        private ComboBox m_condition_typeComboBox;
        private TextBox num_cond_objectsTextBox;
        public RadioButton m_rb_poly_trigger;
        private BindingSource stateBindingSource;
        private ComboBox m_ai_stateComboBox;
        private NumericUpDown m_attack_powerNumericUpDown;
        private NumericUpDown m_attack_rateNumericUpDown;
        private NumericUpDown m_attack_distNumericUpDown;
        private NumericUpDown m_rangeNumericUpDown;
        private NumericUpDown m_move_stepNumericUpDown;
        private NumericUpDown m_chase_distNumericUpDown;
        private CheckBox m_invisibleCheckBox;
        private NumericUpDown m_timer_checkpoint_setNumericUpDown;
        private NumericUpDown m_alien_color_red_changeNumericUpDown;
        private NumericUpDown m_alien_color_green_changeNumericUpDown;
        private NumericUpDown m_alien_color_alpha_changeNumericUpDown;
        private NumericUpDown m_alien_color_blue_changeNumericUpDown;
        private TabPage saveLoadObject;
        public Button load_object;
        public Button save_object_to_name;
        public TextBox textBox1;
        private ListBox load_items_listbox;
        public Button update_object_list;
        private TabPage PolygonObject;
        private NumericUpDown m_change_size_yNumericUpDown;
        private NumericUpDown m_change_size_xNumericUpDown;
        public Button m_poly_create_arc;
        public Button m_poly_create_lines;
        private NumericUpDown m_set_zoomNumericUpDown;
        private CheckBox m_follow_meCheckBox;
        private NumericUpDown m_zoom_multNumericUpDown;
        private NumericUpDown m_laser_slowdownNumericUpDown;
        private NumericUpDown m_attack_speedNumericUpDown;
        private NumericUpDown m_textbox_widthNumericUpDown;
        private TextBox m_textTextBox;
        private CheckBox if_deactivatorCheckBox;
        private TabPage copy_tab;
        public RadioButton rb_copy_loc_same;
        public RadioButton radioButton4;
        public RadioButton rb_copy_loc_right;
        public RadioButton rb_copy_loc_up;
        public RadioButton rb_copy_loc_Left;
        private NumericUpDown numericUpDown1;
        public Button copy_advanced_button;
        public RadioButton m_rb_background_tile;
        public Button button_trigobj_add_object;
        public Button button_trigobj_clear;
        private CheckBox m_disabledCheckBox;
        private CheckBox m_continuous_checkCheckBox;
        private TextBox obj_countTextBox;
    }
}