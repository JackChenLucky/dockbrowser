using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ScWebBrowser.entity;

namespace ScWebBrowser
{
    public partial class SettingForm : Form
    {
        #region Private Fields
        private int NodeCount, FolderCount;
        private string NodeMap;
        private System.Windows.Forms.Button btnAddNode;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.Button btnEnable;
        private const int MAPSIZE = 128;
        private StringBuilder NewNodeMap = new StringBuilder(MAPSIZE);
        #endregion

        private string file = System.AppDomain.CurrentDomain.BaseDirectory + "\\application.ini";

        private List<ScSystem> sysList = new List<ScSystem>();

        private IniFileHelper ini;

        public SettingForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cb_update.Checked&&string.IsNullOrEmpty(tb_udpateserver.Text.Trim()))
            {
                Global.ShowWarning("自动更新启用时，更新服务地址不能为空!");
                return;
            }
            writeVal("window", "main", txt_main.Text.Trim());
            writeVal("window", "title", txt_title.Text.Trim());
            writeVal("window", "width", txt_width.Text.Trim());
            writeVal("window", "height", txt_height.Text.Trim());
            writeVal("window", "toolbar", cb_toolbar.Checked.ToString());
            writeVal("window", "statusbar", cb_status.Checked.ToString());
            writeVal("window", "resizable", cb_resize.Checked.ToString());
            writeVal("window", "fullscreen", cb_max.Checked.ToString());
            writeVal("window", "show_in_taskbar", cb_task.Checked.ToString());
            writeVal("window", "frame", cb_frame.Checked.ToString());
            writeVal("window", "position", "center");
            writeVal("window", "min_width", txt_min_width.Text.Trim());
            writeVal("window", "min_height", txt_min_height.Text.Trim());
            writeVal("window", "max_width", txt_max_width.Text.Trim());
            writeVal("window", "max_height", txt_max_height.Text.Trim());
            writeVal("window", "show", cb_show.Checked.ToString());
            writeVal("window", "kiosk", cb_kiosk.Checked.ToString());
            writeVal("window", "fixtitle", cb_fixtitle.Checked.ToString());
            writeVal("window", "showerror", cb_error.Checked.ToString());

            savePage2();
            savePage3();
            MessageBox.Show("保存成功","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void savePage3()
        {
            ConfigureHelper.SaveWebapp(sysList);
        }

        private void savePage2()
        {
            writeVal("application", "version", tb_version.Text.Trim());
            writeVal("application", "update", cb_update.Checked.ToString());
            writeVal("application", "update_server", tb_udpateserver.Text.Trim());
        }


        private void writeVal(string pSection,string pKey,string pVal)
        {

            ini.IniWriteValue(pSection, pKey, pVal);
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            ini = new IniFileHelper(file);
            txt_main.Text = getIniVal("window", "main", "");
            txt_title.Text = getIniVal("window","title", ""); ;
            txt_width.Text = getIniVal("window", "width", "");
            txt_height.Text = getIniVal("window", "height", "");
            cb_toolbar.Checked = bool.Parse(getIniVal("window", "toolbar", "false"));
            cb_status.Checked = bool.Parse(getIniVal("window", "statusbar", "true"));
            cb_resize.Checked = bool.Parse(getIniVal("window", "resizable", "true"));
            cb_max.Checked = bool.Parse(getIniVal("window", "fullscreen", "false"));
            cb_task.Checked = bool.Parse(getIniVal("window", "show_in_taskbar", "true"));
            cb_frame.Checked = bool.Parse(getIniVal("window", "frame", "true"));
            txt_min_width.Text = getIniVal("window", "min_width", "");
            txt_min_height.Text = getIniVal("window", "min_height", "");
            txt_max_width.Text = getIniVal("window", "max_width", "");
            txt_max_height.Text = getIniVal("window", "max_height", "");
            cb_show.Checked = bool.Parse(getIniVal("window", "show", "true"));
            cb_kiosk.Checked = bool.Parse(getIniVal("window", "kiosk", "false"));
            cb_fixtitle.Checked = bool.Parse(getIniVal("window", "fixtitle", "false"));
            cb_error.Checked = bool.Parse(getIniVal("window", "showerror", "false"));
            InitPage2();
            InitPage3();
        }

        private void InitPage2()
        {
            cb_update.Checked = bool.Parse(getIniVal("application", "update", "false"));
            tb_udpateserver.Text = getIniVal("application", "update_server", "");
            tb_version.Text = getIniVal("application", "version", "0.0.0");
        }

        private void InitPage3()
        {
            //初始化菜单
            int count = int.Parse(ini.IniReadValue("webapp", "webcount", "5"));//默认5个系统
            int gIndex = 1;
            while (gIndex <= count)
            {
                ScSystem si = null;
                if (gIndex <= 5)
                {
                    si = ScSystem.GetScSystem(ini.IniReadValue("webapp", "weburl" + gIndex, ConfigureHelper.getDfltUrl(gIndex.ToString())));
                }
                else
                {
                    si = ScSystem.GetScSystem(ini.IniReadValue("webapp", "weburl" + gIndex, ""));
                }
                if (si != null)
                {
                    sysList.Add(si);
                }
                gIndex++;
            }

            InitMenu(sysList);
        }

        private void InitMenu(List<ScSystem> sysList)
        {
            TreeNode rootNode = new TreeNode();
            rootNode.Text = "系统列表";
            foreach(ScSystem ss in sysList){
                if(ss.Pid=="0"){
                    TreeNode Node = new TreeNode();
                    Node.Text = ss.Name;
                    Node.Tag = ss;
                    if(ss.Deflt=="Y"){
                        Node.ForeColor = Color.Blue;
                    }
                    Node.ImageIndex = 10;
                    FillSubMenu(sysList, Node);
                    rootNode.Nodes.Add(Node);
                }
            }
            tv_fav.Nodes.Add(rootNode);
            tv_fav.ExpandAll();
        }

        private void FillSubMenu(List<ScSystem> sysList,TreeNode pNode)
        {
            string pId = (pNode.Tag as ScSystem).Id;
            foreach(ScSystem ss in sysList){
                if (ss.Pid == pId)
                {
                    TreeNode Node = new TreeNode();
                    Node.Text = ss.Name;
                    Node.Tag = ss;
                    Node.ImageIndex = 10;
                    if (ss.Deflt == "Y")
                    {
                        Node.ForeColor = Color.Blue;
                    }
                    pNode.Nodes.Add(Node);
                }
            }
        }

        private string getIniVal(string pSection,string pKey,string pDeflt)
        {
            return ini.IniReadValue(pSection, pKey, pDeflt);
        }

        private void btnIgnore_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tv_fav_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if(e.Node.Level>0){
                FillData(e.Node.Tag as ScSystem);
            }
            
        }

        private void FillData(ScSystem pSys)
        {
            dgv_sys.Rows.Clear();
            foreach(ScSystem sys in sysList){
                if(sys.Pid==pSys.Id || sys.Id == pSys.Id){
                    FillDataRow(sys);
                }
            }
        }

        private void FillDataRow(ScSystem pSys)
        {
            DataGridViewRow row = new DataGridViewRow();
            DataGridViewCheckBoxCell cbcell = new DataGridViewCheckBoxCell();
            cbcell.Value = pSys.Deflt == "Y" ? true : false;
            row.Cells.Add(cbcell);

            DataGridViewTextBoxCell tbnmcell = new DataGridViewTextBoxCell();
            tbnmcell.Value = pSys.Name;
            row.Cells.Add(tbnmcell);

            DataGridViewTextBoxCell tburlcell = new DataGridViewTextBoxCell();
            tburlcell.Value = pSys.Url;
            row.Cells.Add(tburlcell);

            DataGridViewComboBoxCell comboxcell = new DataGridViewComboBoxCell();
            comboxcell.Items.Add("IE7");
            comboxcell.Items.Add("IE8");
            comboxcell.Items.Add("IE9");
            comboxcell.Items.Add("IE10");
            comboxcell.Items.Add("IE11");
            comboxcell.Items.Add("Chrome");
            comboxcell.Value = string.IsNullOrEmpty(pSys.Viewmodel) ? "IE7" : pSys.Viewmodel;
            row.Cells.Add(comboxcell);
            row.Tag = pSys;
            dgv_sys.Rows.Add(row);
        }

        private void dgv_sys_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0){
                updateList(e.RowIndex,e.ColumnIndex);
            }
        }

        private void dgv_sys_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0&&e.ColumnIndex==0)
            {
                updateListDeflt(e.RowIndex,e.ColumnIndex);
            }
        }
        private void updateListDeflt(int rowindex, int colindex)
        {
            DataGridViewRow row = dgv_sys.Rows[rowindex];
            if(!bool.Parse(row.Cells[0].Value.ToString())){
                foreach (ScSystem ss in sysList)
                {
                    if (ss.Id == (row.Tag as ScSystem).Id)
                    {
                        ss.Deflt = "Y";
                        setDfltColor(ss.Id, tv_fav.Nodes[0]);
                    }
                    else
                    {
                        ss.Deflt = "N";
                    }
                }
            }
        }

        private void setDfltColor(string pId,TreeNode nodes)
        {
            foreach (TreeNode node in nodes.Nodes)
            {
                if ((node.Tag as ScSystem).Id == pId)
                {
                    node.ForeColor = Color.Blue;
                }
                else
                {
                    node.ForeColor = SystemColors.WindowText;
                }
                if(node.Nodes.Count>0){
                    setDfltColor(pId,node);
                }
            }
        }


        private void updateList(int rowindex,int colindex)
        {
            DataGridViewRow row = dgv_sys.Rows[rowindex];
            ScSystem ssy = row.Tag as ScSystem;
            foreach (ScSystem ss in sysList)
            {
                if (ss.Id == ssy.Id)
                {
                    ss.Deflt = bool.Parse(row.Cells[0].Value.ToString()) ? "Y" : "N";
                    ss.Name = (row.Cells[1].Value == null) ? "" : row.Cells[1].Value.ToString();
                    ss.Url = (row.Cells[2].Value==null)?"":row.Cells[2].Value.ToString();
                    ss.Viewmodel = (row.Cells[3].Value == null) ? "" : row.Cells[3].Value.ToString();
                    break;
                }
            }

        }

        #region 拖拽功能
        private Point Position = new Point(0, 0);

        #endregion

        private void tv_fav_ItemDrag(object sender, ItemDragEventArgs e)
        {
            DoDragDrop(e.Item, DragDropEffects.Move);
        }

        private void tv_fav_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void tv_fav_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("System.Windows.Forms.TreeNode", false) && this.NodeMap != "")
            {
                TreeNode MovingNode = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");
                string[] NodeIndexes = this.NodeMap.Split('|');
                TreeNodeCollection InsertCollection = this.tv_fav.Nodes;
                for (int i = 0; i < NodeIndexes.Length - 1; i++)
                {
                    InsertCollection = InsertCollection[Int32.Parse(NodeIndexes[i])].Nodes;
                }

                if (InsertCollection != null)
                {
                    InsertCollection.Insert(Int32.Parse(NodeIndexes[NodeIndexes.Length - 1]), (TreeNode)MovingNode.Clone());
                    this.tv_fav.SelectedNode = InsertCollection[Int32.Parse(NodeIndexes[NodeIndexes.Length - 1])];
                    MovingNode.Remove();
                }
                updateListOrder();
            }
        }

        int nodeindex = 1;
        /// <summary>
        /// 更新节点排序
        /// </summary>
        private void updateListOrder()
        {
            sysList = new List<ScSystem>();
            nodeindex =1;
            foreach(TreeNode node in tv_fav.Nodes[0].Nodes){
                ScSystem ss = node.Tag as ScSystem;
                ss.Id = nodeindex.ToString();
                ss.Pid = "0";
                sysList.Add(ss);
                if(node.Nodes.Count>0){
                    updateListOrderSub(ss.Id,node);
                }
                nodeindex++;
            }
        }

        private void updateListOrderSub(string pId,TreeNode nodes)
        {
            foreach(TreeNode node in nodes.Nodes){
                ScSystem ss = node.Tag as ScSystem;
                ss.Id = nodeindex.ToString();
                ss.Pid = pId;
                sysList.Add(ss);
                if (node.Nodes.Count > 0)
                {
                    updateListOrderSub(ss.Id, node);
                }
                nodeindex++;
            }
        }

        private void tv_fav_DragOver(object sender, DragEventArgs e)
        {
            TreeNode NodeOver = this.tv_fav.GetNodeAt(this.tv_fav.PointToClient(Cursor.Position));
			TreeNode NodeMoving = (TreeNode)e.Data.GetData("System.Windows.Forms.TreeNode");


			// A bit long, but to summarize, process the following code only if the nodeover is null
			// and either the nodeover is not the same thing as nodemoving UNLESSS nodeover happens
			// to be the last node in the branch (so we can allow drag & drop below a parent branch)
            if (NodeOver != null && (NodeOver != NodeMoving || (NodeOver.Parent != null && NodeOver.Index == (NodeOver.Parent.Nodes.Count - 1))))
            {
                int OffsetY = this.tv_fav.PointToClient(Cursor.Position).Y - NodeOver.Bounds.Top;
                int NodeOverImageWidth = this.tv_fav.ImageList.Images[NodeOver.ImageIndex].Size.Width + 8;
                Graphics g = this.tv_fav.CreateGraphics();

                // Image index of 1 is the non-folder icon
                if (NodeOver.ImageIndex == 1)
                {
                    #region Standard Node
                    if (OffsetY < (NodeOver.Bounds.Height / 2))
                    {
                        //this.lblDebug.Text = "top";

                        #region If NodeOver is a child then cancel
                        TreeNode tnParadox = NodeOver;
                        while (tnParadox.Parent != null)
                        {
                            if (tnParadox.Parent == NodeMoving)
                            {
                                this.NodeMap = "";
                                return;
                            }

                            tnParadox = tnParadox.Parent;
                        }
                        #endregion
                        #region Store the placeholder info into a pipe delimited string
                        SetNewNodeMap(NodeOver, false);
                        if (SetMapsEqual() == true)
                            return;
                        #endregion
                        #region Clear placeholders above and below
                        this.Refresh();
                        #endregion
                        #region Draw the placeholders
                        this.DrawLeafTopPlaceholders(NodeOver);
                        #endregion
                    }
                    else
                    {
                        //this.lblDebug.Text = "bottom";

                        #region If NodeOver is a child then cancel
                        TreeNode tnParadox = NodeOver;
                        while (tnParadox.Parent != null)
                        {
                            if (tnParadox.Parent == NodeMoving)
                            {
                                this.NodeMap = "";
                                return;
                            }

                            tnParadox = tnParadox.Parent;
                        }
                        #endregion
                        #region Allow drag drop to parent branches
                        TreeNode ParentDragDrop = null;
                        // If the node the mouse is over is the last node of the branch we should allow
                        // the ability to drop the "nodemoving" node BELOW the parent node
                        if (NodeOver.Parent != null && NodeOver.Index == (NodeOver.Parent.Nodes.Count - 1))
                        {
                            int XPos = this.tv_fav.PointToClient(Cursor.Position).X;
                            if (XPos < NodeOver.Bounds.Left)
                            {
                                ParentDragDrop = NodeOver.Parent;

                                if (XPos < (ParentDragDrop.Bounds.Left - this.tv_fav.ImageList.Images[ParentDragDrop.ImageIndex].Size.Width))
                                {
                                    if (ParentDragDrop.Parent != null)
                                        ParentDragDrop = ParentDragDrop.Parent;
                                }
                            }
                        }
                        #endregion
                        #region Store the placeholder info into a pipe delimited string
                        // Since we are in a special case here, use the ParentDragDrop node as the current "nodeover"
                        SetNewNodeMap(ParentDragDrop != null ? ParentDragDrop : NodeOver, true);
                        if (SetMapsEqual() == true)
                            return;
                        #endregion
                        #region Clear placeholders above and below
                        this.Refresh();
                        #endregion
                        #region Draw the placeholders
                        DrawLeafBottomPlaceholders(NodeOver, ParentDragDrop);
                        #endregion
                    }
                    #endregion
                }
                else
                {
                    #region Folder Node
                    if (OffsetY < (NodeOver.Bounds.Height / 3))
                    {
                        //this.lblDebug.Text = "folder top";

                        #region If NodeOver is a child then cancel
                        TreeNode tnParadox = NodeOver;
                        while (tnParadox.Parent != null)
                        {
                            if (tnParadox.Parent == NodeMoving)
                            {
                                this.NodeMap = "";
                                return;
                            }

                            tnParadox = tnParadox.Parent;
                        }
                        #endregion
                        #region Store the placeholder info into a pipe delimited string
                        SetNewNodeMap(NodeOver, false);
                        if (SetMapsEqual() == true)
                            return;
                        #endregion
                        #region Clear placeholders above and below
                        this.Refresh();
                        #endregion
                        #region Draw the placeholders
                        this.DrawFolderTopPlaceholders(NodeOver);
                        #endregion
                    }
                    else if ((NodeOver.Parent != null && NodeOver.Index == 0) && (OffsetY > (NodeOver.Bounds.Height - (NodeOver.Bounds.Height / 3))))
                    {
                        //this.lblDebug.Text = "folder bottom";

                        #region If NodeOver is a child then cancel
                        TreeNode tnParadox = NodeOver;
                        while (tnParadox.Parent != null)
                        {
                            if (tnParadox.Parent == NodeMoving)
                            {
                                this.NodeMap = "";
                                return;
                            }

                            tnParadox = tnParadox.Parent;
                        }
                        #endregion
                        #region Store the placeholder info into a pipe delimited string
                        SetNewNodeMap(NodeOver, true);
                        if (SetMapsEqual() == true)
                            return;
                        #endregion
                        #region Clear placeholders above and below
                        this.Refresh();
                        #endregion
                        #region Draw the placeholders
                        DrawFolderTopPlaceholders(NodeOver);
                        #endregion
                    }
                    else
                    {
                        //this.lblDebug.Text = "folder over";

                        if (NodeOver.Nodes.Count > 0)
                        {
                            NodeOver.Expand();
                            //this.Refresh();
                        }
                        else
                        {
                            #region Prevent the node from being dragged onto itself
                            if (NodeMoving == NodeOver)
                                return;
                            #endregion
                            #region If NodeOver is a child then cancel
                            TreeNode tnParadox = NodeOver;
                            while (tnParadox.Parent != null)
                            {
                                if (tnParadox.Parent == NodeMoving)
                                {
                                    this.NodeMap = "";
                                    return;
                                }

                                tnParadox = tnParadox.Parent;
                            }
                            #endregion
                            #region Store the placeholder info into a pipe delimited string
                            SetNewNodeMap(NodeOver, false);
                            NewNodeMap = NewNodeMap.Insert(NewNodeMap.Length, "|0");

                            if (SetMapsEqual() == true)
                                return;
                            #endregion
                            #region Clear placeholders above and below
                            this.Refresh();
                            #endregion
                            #region Draw the "add to folder" placeholder
                            DrawAddToFolderPlaceholder(NodeOver);
                            #endregion
                        }
                    }
                    #endregion
                }
            }
        }

        #region Helper Methods
        private void DrawLeafTopPlaceholders(TreeNode NodeOver)
        {
            Graphics g = this.tv_fav.CreateGraphics();

            int NodeOverImageWidth = this.tv_fav.ImageList.Images[NodeOver.ImageIndex].Size.Width + 8;
            int LeftPos = NodeOver.Bounds.Left - NodeOverImageWidth;
            int RightPos = this.tv_fav.Width - 4;

            Point[] LeftTriangle = new Point[5]{
												   new Point(LeftPos, NodeOver.Bounds.Top - 4),
												   new Point(LeftPos, NodeOver.Bounds.Top + 4),
												   new Point(LeftPos + 4, NodeOver.Bounds.Y),
												   new Point(LeftPos + 4, NodeOver.Bounds.Top - 1),
												   new Point(LeftPos, NodeOver.Bounds.Top - 5)};

            Point[] RightTriangle = new Point[5]{
													new Point(RightPos, NodeOver.Bounds.Top - 4),
													new Point(RightPos, NodeOver.Bounds.Top + 4),
													new Point(RightPos - 4, NodeOver.Bounds.Y),
													new Point(RightPos - 4, NodeOver.Bounds.Top - 1),
													new Point(RightPos, NodeOver.Bounds.Top - 5)};


            g.FillPolygon(System.Drawing.Brushes.Black, LeftTriangle);
            g.FillPolygon(System.Drawing.Brushes.Black, RightTriangle);
            g.DrawLine(new System.Drawing.Pen(Color.Black, 2), new Point(LeftPos, NodeOver.Bounds.Top), new Point(RightPos, NodeOver.Bounds.Top));

        }//eom

        private void DrawLeafBottomPlaceholders(TreeNode NodeOver, TreeNode ParentDragDrop)
        {
            Graphics g = this.tv_fav.CreateGraphics();

            int NodeOverImageWidth = this.tv_fav.ImageList.Images[NodeOver.ImageIndex].Size.Width + 8;
            // Once again, we are not dragging to node over, draw the placeholder using the ParentDragDrop bounds
            int LeftPos, RightPos;
            if (ParentDragDrop != null)
                LeftPos = ParentDragDrop.Bounds.Left - (this.tv_fav.ImageList.Images[ParentDragDrop.ImageIndex].Size.Width + 8);
            else
                LeftPos = NodeOver.Bounds.Left - NodeOverImageWidth;
            RightPos = this.tv_fav.Width - 4;

            Point[] LeftTriangle = new Point[5]{
												   new Point(LeftPos, NodeOver.Bounds.Bottom - 4),
												   new Point(LeftPos, NodeOver.Bounds.Bottom + 4),
												   new Point(LeftPos + 4, NodeOver.Bounds.Bottom),
												   new Point(LeftPos + 4, NodeOver.Bounds.Bottom - 1),
												   new Point(LeftPos, NodeOver.Bounds.Bottom - 5)};

            Point[] RightTriangle = new Point[5]{
													new Point(RightPos, NodeOver.Bounds.Bottom - 4),
													new Point(RightPos, NodeOver.Bounds.Bottom + 4),
													new Point(RightPos - 4, NodeOver.Bounds.Bottom),
													new Point(RightPos - 4, NodeOver.Bounds.Bottom - 1),
													new Point(RightPos, NodeOver.Bounds.Bottom - 5)};


            g.FillPolygon(System.Drawing.Brushes.Black, LeftTriangle);
            g.FillPolygon(System.Drawing.Brushes.Black, RightTriangle);
            g.DrawLine(new System.Drawing.Pen(Color.Black, 2), new Point(LeftPos, NodeOver.Bounds.Bottom), new Point(RightPos, NodeOver.Bounds.Bottom));
        }//eom

        private void DrawFolderTopPlaceholders(TreeNode NodeOver)
        {
            Graphics g = this.tv_fav.CreateGraphics();
            int NodeOverImageWidth = this.tv_fav.ImageList.Images[NodeOver.ImageIndex].Size.Width + 8;

            int LeftPos, RightPos;
            LeftPos = NodeOver.Bounds.Left - NodeOverImageWidth;
            RightPos = this.tv_fav.Width - 4;

            Point[] LeftTriangle = new Point[5]{
												   new Point(LeftPos, NodeOver.Bounds.Top - 4),
												   new Point(LeftPos, NodeOver.Bounds.Top + 4),
												   new Point(LeftPos + 4, NodeOver.Bounds.Y),
												   new Point(LeftPos + 4, NodeOver.Bounds.Top - 1),
												   new Point(LeftPos, NodeOver.Bounds.Top - 5)};

            Point[] RightTriangle = new Point[5]{
													new Point(RightPos, NodeOver.Bounds.Top - 4),
													new Point(RightPos, NodeOver.Bounds.Top + 4),
													new Point(RightPos - 4, NodeOver.Bounds.Y),
													new Point(RightPos - 4, NodeOver.Bounds.Top - 1),
													new Point(RightPos, NodeOver.Bounds.Top - 5)};


            g.FillPolygon(System.Drawing.Brushes.Black, LeftTriangle);
            g.FillPolygon(System.Drawing.Brushes.Black, RightTriangle);
            g.DrawLine(new System.Drawing.Pen(Color.Black, 2), new Point(LeftPos, NodeOver.Bounds.Top), new Point(RightPos, NodeOver.Bounds.Top));

        }//eom
        private void DrawAddToFolderPlaceholder(TreeNode NodeOver)
        {
            Graphics g = this.tv_fav.CreateGraphics();
            int RightPos = NodeOver.Bounds.Right + 6;
            Point[] RightTriangle = new Point[5]{
													new Point(RightPos, NodeOver.Bounds.Y + (NodeOver.Bounds.Height / 2) + 4),
													new Point(RightPos, NodeOver.Bounds.Y + (NodeOver.Bounds.Height / 2) + 4),
													new Point(RightPos - 4, NodeOver.Bounds.Y + (NodeOver.Bounds.Height / 2)),
													new Point(RightPos - 4, NodeOver.Bounds.Y + (NodeOver.Bounds.Height / 2) - 1),
													new Point(RightPos, NodeOver.Bounds.Y + (NodeOver.Bounds.Height / 2) - 5)};

            this.Refresh();
            g.FillPolygon(System.Drawing.Brushes.Black, RightTriangle);
        }//eom

        private void SetNewNodeMap(TreeNode tnNode, bool boolBelowNode)
        {
            NewNodeMap.Length = 0;

            if (boolBelowNode)
                NewNodeMap.Insert(0, (int)tnNode.Index + 1);
            else
                NewNodeMap.Insert(0, (int)tnNode.Index);
            TreeNode tnCurNode = tnNode;

            while (tnCurNode.Parent != null)
            {
                tnCurNode = tnCurNode.Parent;

                if (NewNodeMap.Length == 0 && boolBelowNode == true)
                {
                    NewNodeMap.Insert(0, (tnCurNode.Index + 1) + "|");
                }
                else
                {
                    NewNodeMap.Insert(0, tnCurNode.Index + "|");
                }
            }
        }//oem

        private bool SetMapsEqual()
        {
            if (this.NewNodeMap.ToString() == this.NodeMap)
                return true;
            else
            {
                this.NodeMap = this.NewNodeMap.ToString();
                return false;
            }
        }

        private void btnAddSys_Click(object sender, EventArgs e)
        {
            frm.frmAddSys fas = new ScWebBrowser.frm.frmAddSys("");
            if (fas.ShowDialog() == DialogResult.OK)
            {
                if (MessageBox.Show("配置保存成功，需要重新启动才能生效，是否立即重启？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
            }
        }
        #endregion
    }
}