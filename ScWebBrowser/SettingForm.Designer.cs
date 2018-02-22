namespace ScWebBrowser
{
    partial class SettingForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIgnore = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_max = new System.Windows.Forms.CheckBox();
            this.cb_frame = new System.Windows.Forms.CheckBox();
            this.cb_error = new System.Windows.Forms.CheckBox();
            this.cb_kiosk = new System.Windows.Forms.CheckBox();
            this.cb_task = new System.Windows.Forms.CheckBox();
            this.cb_resize = new System.Windows.Forms.CheckBox();
            this.cb_fixtitle = new System.Windows.Forms.CheckBox();
            this.cb_show = new System.Windows.Forms.CheckBox();
            this.cb_status = new System.Windows.Forms.CheckBox();
            this.cb_toolbar = new System.Windows.Forms.CheckBox();
            this.txt_max_width = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_max_height = new System.Windows.Forms.TextBox();
            this.txt_min_width = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_min_height = new System.Windows.Forms.TextBox();
            this.txt_width = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_height = new System.Windows.Forms.TextBox();
            this.txt_title = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_main = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dgv_sys = new System.Windows.Forms.DataGridView();
            this.col_deflt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUrl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIEmodel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tv_fav = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.label24 = new System.Windows.Forms.Label();
            this.btnAddSys = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cb_update = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tb_udpateserver = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tb_version = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sys)).BeginInit();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnIgnore);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 464);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(879, 52);
            this.panel1.TabIndex = 0;
            // 
            // btnIgnore
            // 
            this.btnIgnore.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnIgnore.Location = new System.Drawing.Point(772, 10);
            this.btnIgnore.Name = "btnIgnore";
            this.btnIgnore.Size = new System.Drawing.Size(86, 30);
            this.btnIgnore.TabIndex = 0;
            this.btnIgnore.Text = "跳过(&C)";
            this.btnIgnore.UseVisualStyleBackColor = true;
            this.btnIgnore.Click += new System.EventHandler(this.btnIgnore_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(653, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 30);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存配置(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(358, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(313, 15);
            this.label9.TabIndex = 8;
            this.label9.Text = "Web服务地址，例 http://192.168.0.1:8080";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cb_max);
            this.groupBox1.Controls.Add(this.cb_frame);
            this.groupBox1.Controls.Add(this.cb_error);
            this.groupBox1.Controls.Add(this.cb_kiosk);
            this.groupBox1.Controls.Add(this.cb_task);
            this.groupBox1.Controls.Add(this.cb_resize);
            this.groupBox1.Controls.Add(this.cb_fixtitle);
            this.groupBox1.Controls.Add(this.cb_show);
            this.groupBox1.Controls.Add(this.cb_status);
            this.groupBox1.Controls.Add(this.cb_toolbar);
            this.groupBox1.Controls.Add(this.txt_max_width);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txt_max_height);
            this.groupBox1.Controls.Add(this.txt_min_width);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txt_min_height);
            this.groupBox1.Controls.Add(this.txt_width);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_height);
            this.groupBox1.Location = new System.Drawing.Point(38, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(608, 304);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "窗体设置";
            // 
            // cb_max
            // 
            this.cb_max.AutoSize = true;
            this.cb_max.Location = new System.Drawing.Point(382, 175);
            this.cb_max.Name = "cb_max";
            this.cb_max.Size = new System.Drawing.Size(104, 19);
            this.cb_max.TabIndex = 15;
            this.cb_max.Text = "最大化窗体";
            this.cb_max.UseVisualStyleBackColor = true;
            // 
            // cb_frame
            // 
            this.cb_frame.AutoSize = true;
            this.cb_frame.Location = new System.Drawing.Point(195, 175);
            this.cb_frame.Name = "cb_frame";
            this.cb_frame.Size = new System.Drawing.Size(119, 19);
            this.cb_frame.TabIndex = 15;
            this.cb_frame.Text = "显示窗体边框";
            this.cb_frame.UseVisualStyleBackColor = true;
            // 
            // cb_error
            // 
            this.cb_error.AutoSize = true;
            this.cb_error.Location = new System.Drawing.Point(21, 244);
            this.cb_error.Name = "cb_error";
            this.cb_error.Size = new System.Drawing.Size(224, 19);
            this.cb_error.TabIndex = 15;
            this.cb_error.Text = "启用控件安装及脚本错误提示";
            this.cb_error.UseVisualStyleBackColor = true;
            // 
            // cb_kiosk
            // 
            this.cb_kiosk.AutoSize = true;
            this.cb_kiosk.Location = new System.Drawing.Point(21, 209);
            this.cb_kiosk.Name = "cb_kiosk";
            this.cb_kiosk.Size = new System.Drawing.Size(129, 19);
            this.cb_kiosk.TabIndex = 15;
            this.cb_kiosk.Text = "使用Kiosk模式";
            this.cb_kiosk.UseVisualStyleBackColor = true;
            // 
            // cb_task
            // 
            this.cb_task.AutoSize = true;
            this.cb_task.Location = new System.Drawing.Point(21, 175);
            this.cb_task.Name = "cb_task";
            this.cb_task.Size = new System.Drawing.Size(119, 19);
            this.cb_task.TabIndex = 15;
            this.cb_task.Text = "显示在任务栏";
            this.cb_task.UseVisualStyleBackColor = true;
            // 
            // cb_resize
            // 
            this.cb_resize.AutoSize = true;
            this.cb_resize.Location = new System.Drawing.Point(382, 140);
            this.cb_resize.Name = "cb_resize";
            this.cb_resize.Size = new System.Drawing.Size(149, 19);
            this.cb_resize.TabIndex = 15;
            this.cb_resize.Text = "允许改变窗体大小";
            this.cb_resize.UseVisualStyleBackColor = true;
            // 
            // cb_fixtitle
            // 
            this.cb_fixtitle.AutoSize = true;
            this.cb_fixtitle.Location = new System.Drawing.Point(382, 210);
            this.cb_fixtitle.Name = "cb_fixtitle";
            this.cb_fixtitle.Size = new System.Drawing.Size(119, 19);
            this.cb_fixtitle.TabIndex = 15;
            this.cb_fixtitle.Text = "固定窗体标题";
            this.cb_fixtitle.UseVisualStyleBackColor = true;
            // 
            // cb_show
            // 
            this.cb_show.AutoSize = true;
            this.cb_show.Location = new System.Drawing.Point(195, 210);
            this.cb_show.Name = "cb_show";
            this.cb_show.Size = new System.Drawing.Size(89, 19);
            this.cb_show.TabIndex = 15;
            this.cb_show.Text = "显示窗体";
            this.cb_show.UseVisualStyleBackColor = true;
            // 
            // cb_status
            // 
            this.cb_status.AutoSize = true;
            this.cb_status.Location = new System.Drawing.Point(195, 140);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(104, 19);
            this.cb_status.TabIndex = 15;
            this.cb_status.Text = "显示状态栏";
            this.cb_status.UseVisualStyleBackColor = true;
            // 
            // cb_toolbar
            // 
            this.cb_toolbar.AutoSize = true;
            this.cb_toolbar.Location = new System.Drawing.Point(21, 140);
            this.cb_toolbar.Name = "cb_toolbar";
            this.cb_toolbar.Size = new System.Drawing.Size(104, 19);
            this.cb_toolbar.TabIndex = 15;
            this.cb_toolbar.Text = "显示工具栏";
            this.cb_toolbar.UseVisualStyleBackColor = true;
            // 
            // txt_max_width
            // 
            this.txt_max_width.Location = new System.Drawing.Point(97, 99);
            this.txt_max_width.Name = "txt_max_width";
            this.txt_max_width.Size = new System.Drawing.Size(133, 25);
            this.txt_max_width.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(349, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "最大高度:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 15);
            this.label8.TabIndex = 12;
            this.label8.Text = "最大宽度:";
            // 
            // txt_max_height
            // 
            this.txt_max_height.Location = new System.Drawing.Point(428, 99);
            this.txt_max_height.Name = "txt_max_height";
            this.txt_max_height.Size = new System.Drawing.Size(133, 25);
            this.txt_max_height.TabIndex = 13;
            // 
            // txt_min_width
            // 
            this.txt_min_width.Location = new System.Drawing.Point(97, 63);
            this.txt_min_width.Name = "txt_min_width";
            this.txt_min_width.Size = new System.Drawing.Size(133, 25);
            this.txt_min_width.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(349, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "最小高度:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "最小宽度:";
            // 
            // txt_min_height
            // 
            this.txt_min_height.Location = new System.Drawing.Point(428, 63);
            this.txt_min_height.Name = "txt_min_height";
            this.txt_min_height.Size = new System.Drawing.Size(133, 25);
            this.txt_min_height.TabIndex = 9;
            // 
            // txt_width
            // 
            this.txt_width.Location = new System.Drawing.Point(97, 24);
            this.txt_width.Name = "txt_width";
            this.txt_width.Size = new System.Drawing.Size(133, 25);
            this.txt_width.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(377, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "高度:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(563, 103);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(23, 15);
            this.label16.TabIndex = 4;
            this.label16.Text = "px";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(563, 68);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(23, 15);
            this.label15.TabIndex = 4;
            this.label15.Text = "px";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(563, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(23, 15);
            this.label14.TabIndex = 4;
            this.label14.Text = "px";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(231, 104);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(23, 15);
            this.label13.TabIndex = 4;
            this.label13.Text = "px";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(231, 68);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(23, 15);
            this.label12.TabIndex = 4;
            this.label12.Text = "px";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(231, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(23, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "px";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "宽度:";
            // 
            // txt_height
            // 
            this.txt_height.Location = new System.Drawing.Point(428, 24);
            this.txt_height.Name = "txt_height";
            this.txt_height.Size = new System.Drawing.Size(133, 25);
            this.txt_height.TabIndex = 5;
            // 
            // txt_title
            // 
            this.txt_title.Location = new System.Drawing.Point(117, 71);
            this.txt_title.Name = "txt_title";
            this.txt_title.Size = new System.Drawing.Size(235, 25);
            this.txt_title.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(358, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(127, 15);
            this.label10.TabIndex = 2;
            this.label10.Text = "系统启动默认标题";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "默认标题:";
            // 
            // txt_main
            // 
            this.txt_main.Location = new System.Drawing.Point(115, 27);
            this.txt_main.Name = "txt_main";
            this.txt_main.Size = new System.Drawing.Size(237, 25);
            this.txt_main.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "访问地址:";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(879, 464);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txt_title);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txt_main);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(871, 435);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "基础设置";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dgv_sys);
            this.tabPage3.Controls.Add(this.splitter1);
            this.tabPage3.Controls.Add(this.tv_fav);
            this.tabPage3.Controls.Add(this.panel2);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(10);
            this.tabPage3.Size = new System.Drawing.Size(871, 435);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "系统列表";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dgv_sys
            // 
            this.dgv_sys.AllowUserToAddRows = false;
            this.dgv_sys.AllowUserToResizeRows = false;
            this.dgv_sys.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_sys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_sys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_deflt,
            this.colName,
            this.colUrl,
            this.colIEmodel});
            this.dgv_sys.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_sys.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgv_sys.Location = new System.Drawing.Point(280, 58);
            this.dgv_sys.MultiSelect = false;
            this.dgv_sys.Name = "dgv_sys";
            this.dgv_sys.RowHeadersVisible = false;
            this.dgv_sys.RowTemplate.Height = 27;
            this.dgv_sys.Size = new System.Drawing.Size(581, 367);
            this.dgv_sys.TabIndex = 4;
            this.dgv_sys.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_sys_CellValueChanged);
            this.dgv_sys.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_sys_CellContentClick);
            // 
            // col_deflt
            // 
            this.col_deflt.HeaderText = "默认";
            this.col_deflt.Name = "col_deflt";
            this.col_deflt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.col_deflt.Width = 50;
            // 
            // colName
            // 
            this.colName.HeaderText = "名称";
            this.colName.Name = "colName";
            // 
            // colUrl
            // 
            this.colUrl.HeaderText = "访问地址";
            this.colUrl.Name = "colUrl";
            this.colUrl.Width = 250;
            // 
            // colIEmodel
            // 
            this.colIEmodel.HeaderText = "渲染模式";
            this.colIEmodel.Name = "colIEmodel";
            this.colIEmodel.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIEmodel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colIEmodel.Width = 70;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(277, 58);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 367);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // tv_fav
            // 
            this.tv_fav.AllowDrop = true;
            this.tv_fav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tv_fav.Dock = System.Windows.Forms.DockStyle.Left;
            this.tv_fav.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.tv_fav.FullRowSelect = true;
            this.tv_fav.HideSelection = false;
            this.tv_fav.ImageIndex = 10;
            this.tv_fav.ImageList = this.imageList1;
            this.tv_fav.Indent = 20;
            this.tv_fav.ItemHeight = 25;
            this.tv_fav.Location = new System.Drawing.Point(10, 58);
            this.tv_fav.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.tv_fav.Name = "tv_fav";
            this.tv_fav.SelectedImageKey = "文件夹.png";
            this.tv_fav.Size = new System.Drawing.Size(267, 367);
            this.tv_fav.TabIndex = 0;
            this.tv_fav.DragDrop += new System.Windows.Forms.DragEventHandler(this.tv_fav_DragDrop);
            this.tv_fav.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_fav_AfterSelect);
            this.tv_fav.DragEnter += new System.Windows.Forms.DragEventHandler(this.tv_fav_DragEnter);
            this.tv_fav.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tv_fav_ItemDrag);
            this.tv_fav.DragOver += new System.Windows.Forms.DragEventHandler(this.tv_fav_DragOver);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "clear.png");
            this.imageList1.Images.SetKeyName(1, "save.png");
            this.imageList1.Images.SetKeyName(2, "电子病历.png");
            this.imageList1.Images.SetKeyName(3, "放大.png");
            this.imageList1.Images.SetKeyName(4, "感染科.png");
            this.imageList1.Images.SetKeyName(5, "护士.png");
            this.imageList1.Images.SetKeyName(6, "绩效考核记录.png");
            this.imageList1.Images.SetKeyName(7, "快捷方式.png");
            this.imageList1.Images.SetKeyName(8, "医生.png");
            this.imageList1.Images.SetKeyName(9, "设置.png");
            this.imageList1.Images.SetKeyName(10, "文件夹 (1).png");
            this.imageList1.Images.SetKeyName(11, "文件夹.png");
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label24);
            this.panel2.Controls.Add(this.btnAddSys);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(10, 10);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(851, 48);
            this.panel2.TabIndex = 1;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(21, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(123, 19);
            this.label24.TabIndex = 0;
            this.label24.Text = "维护系统列表";
            // 
            // btnAddSys
            // 
            this.btnAddSys.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSys.Location = new System.Drawing.Point(724, 8);
            this.btnAddSys.Name = "btnAddSys";
            this.btnAddSys.Size = new System.Drawing.Size(106, 30);
            this.btnAddSys.TabIndex = 0;
            this.btnAddSys.Text = "添加系统(&A)";
            this.btnAddSys.UseVisualStyleBackColor = true;
            this.btnAddSys.Click += new System.EventHandler(this.btnAddSys_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.tb_version);
            this.tabPage2.Controls.Add(this.tb_udpateserver);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label17);
            this.tabPage2.Controls.Add(this.cb_update);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(871, 435);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "自动更新设置";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // cb_update
            // 
            this.cb_update.AutoSize = true;
            this.cb_update.Location = new System.Drawing.Point(42, 27);
            this.cb_update.Name = "cb_update";
            this.cb_update.Size = new System.Drawing.Size(119, 19);
            this.cb_update.TabIndex = 0;
            this.cb_update.Text = "启用自动更新";
            this.cb_update.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(86, 67);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(105, 15);
            this.label17.TabIndex = 1;
            this.label17.Text = "自动更新服务:";
            // 
            // tb_udpateserver
            // 
            this.tb_udpateserver.Location = new System.Drawing.Point(197, 61);
            this.tb_udpateserver.Name = "tb_udpateserver";
            this.tb_udpateserver.Size = new System.Drawing.Size(367, 25);
            this.tb_udpateserver.TabIndex = 2;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(585, 67);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(172, 15);
            this.label18.TabIndex = 3;
            this.label18.Text = "判断自动更新的服务地址";
            // 
            // tb_version
            // 
            this.tb_version.Location = new System.Drawing.Point(197, 107);
            this.tb_version.Name = "tb_version";
            this.tb_version.Size = new System.Drawing.Size(367, 25);
            this.tb_version.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(86, 110);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(105, 15);
            this.label19.TabIndex = 1;
            this.label19.Text = "当前软件版本:";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 516);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_sys)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnIgnore;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txt_main;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_height;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_width;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_max_width;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_max_height;
        private System.Windows.Forms.TextBox txt_min_width;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_min_height;
        private System.Windows.Forms.CheckBox cb_toolbar;
        private System.Windows.Forms.CheckBox cb_status;
        private System.Windows.Forms.CheckBox cb_resize;
        private System.Windows.Forms.CheckBox cb_task;
        private System.Windows.Forms.CheckBox cb_frame;
        private System.Windows.Forms.CheckBox cb_max;
        private System.Windows.Forms.CheckBox cb_kiosk;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox cb_show;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox cb_fixtitle;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TreeView tv_fav;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.DataGridView dgv_sys;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_deflt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUrl;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIEmodel;
        private System.Windows.Forms.Button btnAddSys;
        private System.Windows.Forms.CheckBox cb_error;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox cb_update;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tb_udpateserver;
        private System.Windows.Forms.TextBox tb_version;
        private System.Windows.Forms.Label label19;
    }
}