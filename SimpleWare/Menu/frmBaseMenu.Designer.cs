namespace SimpleWare.Menu
{
    partial class frmBaseMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBaseMenu));
            this.menuTree = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addModule = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.delemenu = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btncancel = new DevComponents.DotNetBar.ButtonX();
            this.btnsave = new DevComponents.DotNetBar.ButtonX();
            this.btnedit = new DevComponents.DotNetBar.ButtonX();
            this.pMenu = new DevComponents.DotNetBar.PanelEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.tbId = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbRemark = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbsortid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbPID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tbName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.pModule = new DevComponents.DotNetBar.PanelEx();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.tbMName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.textBoxX7 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.tbMID = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.tbMSortid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.contextMenuStrip1.SuspendLayout();
            this.panelEx1.SuspendLayout();
            this.pMenu.SuspendLayout();
            this.pModule.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuTree
            // 
            this.menuTree.ContextMenuStrip = this.contextMenuStrip1;
            this.menuTree.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuTree.ImageIndex = 1;
            this.menuTree.ImageList = this.imageList1;
            this.menuTree.Location = new System.Drawing.Point(0, 0);
            this.menuTree.Name = "menuTree";
            this.menuTree.SelectedImageIndex = 0;
            this.menuTree.Size = new System.Drawing.Size(382, 464);
            this.menuTree.TabIndex = 0;
            this.menuTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.menuTree_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addModule,
            this.toolStripSeparator1,
            this.addMenu,
            this.delemenu});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 76);
            // 
            // addModule
            // 
            this.addModule.Name = "addModule";
            this.addModule.Size = new System.Drawing.Size(124, 22);
            this.addModule.Text = "添加模块";
            this.addModule.Click += new System.EventHandler(this.addModule_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(121, 6);
            // 
            // addMenu
            // 
            this.addMenu.Name = "addMenu";
            this.addMenu.Size = new System.Drawing.Size(124, 22);
            this.addMenu.Text = "添加节点";
            this.addMenu.Click += new System.EventHandler(this.addMenu_Click);
            // 
            // delemenu
            // 
            this.delemenu.Name = "delemenu";
            this.delemenu.Size = new System.Drawing.Size(124, 22);
            this.delemenu.Text = "删除节点";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "openfolderHS.png");
            this.imageList1.Images.SetKeyName(1, "field.png");
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.pModule);
            this.panelEx1.Controls.Add(this.pMenu);
            this.panelEx1.Controls.Add(this.btncancel);
            this.panelEx1.Controls.Add(this.btnsave);
            this.panelEx1.Controls.Add(this.btnedit);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelEx1.Location = new System.Drawing.Point(382, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(523, 464);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // btncancel
            // 
            this.btncancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btncancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btncancel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btncancel.Image = global::SimpleWare.Properties.Resources.Folder_remove;
            this.btncancel.ImageFixedSize = new System.Drawing.Size(64, 64);
            this.btncancel.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btncancel.ImageTextSpacing = -15;
            this.btncancel.Location = new System.Drawing.Point(263, 264);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(57, 70);
            this.btncancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btncancel.TabIndex = 22;
            this.btncancel.Text = "取消";
            // 
            // btnsave
            // 
            this.btnsave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnsave.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnsave.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnsave.Image = global::SimpleWare.Properties.Resources.Folder_verified;
            this.btnsave.ImageFixedSize = new System.Drawing.Size(64, 64);
            this.btnsave.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnsave.ImageTextSpacing = -15;
            this.btnsave.Location = new System.Drawing.Point(196, 264);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(57, 70);
            this.btnsave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnsave.TabIndex = 21;
            this.btnsave.Text = "保存";
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnedit
            // 
            this.btnedit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnedit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnedit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnedit.Image = global::SimpleWare.Properties.Resources.Folder_syncronize;
            this.btnedit.ImageFixedSize = new System.Drawing.Size(64, 64);
            this.btnedit.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnedit.ImageTextSpacing = -15;
            this.btnedit.Location = new System.Drawing.Point(129, 264);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(57, 70);
            this.btnedit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnedit.TabIndex = 20;
            this.btnedit.Text = "编辑";
            // 
            // pMenu
            // 
            this.pMenu.CanvasColor = System.Drawing.SystemColors.Control;
            this.pMenu.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pMenu.Controls.Add(this.labelX5);
            this.pMenu.Controls.Add(this.tbId);
            this.pMenu.Controls.Add(this.labelX4);
            this.pMenu.Controls.Add(this.tbRemark);
            this.pMenu.Controls.Add(this.labelX3);
            this.pMenu.Controls.Add(this.tbsortid);
            this.pMenu.Controls.Add(this.labelX2);
            this.pMenu.Controls.Add(this.tbPID);
            this.pMenu.Controls.Add(this.labelX1);
            this.pMenu.Controls.Add(this.tbName);
            this.pMenu.DisabledBackColor = System.Drawing.Color.Empty;
            this.pMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMenu.Location = new System.Drawing.Point(0, 0);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(523, 141);
            this.pMenu.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pMenu.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pMenu.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pMenu.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pMenu.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pMenu.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pMenu.Style.GradientAngle = 90;
            this.pMenu.TabIndex = 23;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(9, 3);
            this.labelX5.Name = "labelX5";
            this.labelX5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 19;
            this.labelX5.Text = "ID";
            // 
            // tbId
            // 
            // 
            // 
            // 
            this.tbId.Border.Class = "TextBoxBorder";
            this.tbId.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbId.ButtonCustom.Tooltip = "";
            this.tbId.ButtonCustom2.Tooltip = "";
            this.tbId.Location = new System.Drawing.Point(90, 3);
            this.tbId.Name = "tbId";
            this.tbId.PreventEnterBeep = true;
            this.tbId.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tbId.Size = new System.Drawing.Size(230, 21);
            this.tbId.TabIndex = 18;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(9, 111);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(75, 23);
            this.labelX4.TabIndex = 17;
            this.labelX4.Text = "备注";
            // 
            // tbRemark
            // 
            // 
            // 
            // 
            this.tbRemark.Border.Class = "TextBoxBorder";
            this.tbRemark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbRemark.ButtonCustom.Tooltip = "";
            this.tbRemark.ButtonCustom2.Tooltip = "";
            this.tbRemark.Location = new System.Drawing.Point(90, 111);
            this.tbRemark.Name = "tbRemark";
            this.tbRemark.PreventEnterBeep = true;
            this.tbRemark.Size = new System.Drawing.Size(230, 21);
            this.tbRemark.TabIndex = 16;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(9, 55);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(75, 23);
            this.labelX3.TabIndex = 15;
            this.labelX3.Text = "顺序";
            // 
            // tbsortid
            // 
            // 
            // 
            // 
            this.tbsortid.Border.Class = "TextBoxBorder";
            this.tbsortid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbsortid.ButtonCustom.Tooltip = "";
            this.tbsortid.ButtonCustom2.Tooltip = "";
            this.tbsortid.Location = new System.Drawing.Point(90, 57);
            this.tbsortid.Name = "tbsortid";
            this.tbsortid.PreventEnterBeep = true;
            this.tbsortid.Size = new System.Drawing.Size(230, 21);
            this.tbsortid.TabIndex = 14;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(9, 84);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "上级ID";
            // 
            // tbPID
            // 
            // 
            // 
            // 
            this.tbPID.Border.Class = "TextBoxBorder";
            this.tbPID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbPID.ButtonCustom.Tooltip = "";
            this.tbPID.ButtonCustom2.Tooltip = "";
            this.tbPID.Location = new System.Drawing.Point(90, 84);
            this.tbPID.Name = "tbPID";
            this.tbPID.PreventEnterBeep = true;
            this.tbPID.Size = new System.Drawing.Size(230, 21);
            this.tbPID.TabIndex = 12;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(9, 28);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 11;
            this.labelX1.Text = "菜单名称";
            // 
            // tbName
            // 
            // 
            // 
            // 
            this.tbName.Border.Class = "TextBoxBorder";
            this.tbName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbName.ButtonCustom.Tooltip = "";
            this.tbName.ButtonCustom2.Tooltip = "";
            this.tbName.Location = new System.Drawing.Point(90, 30);
            this.tbName.Name = "tbName";
            this.tbName.PreventEnterBeep = true;
            this.tbName.Size = new System.Drawing.Size(230, 21);
            this.tbName.TabIndex = 10;
            // 
            // pModule
            // 
            this.pModule.CanvasColor = System.Drawing.SystemColors.Control;
            this.pModule.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pModule.Controls.Add(this.labelX9);
            this.pModule.Controls.Add(this.tbMSortid);
            this.pModule.Controls.Add(this.labelX8);
            this.pModule.Controls.Add(this.tbMName);
            this.pModule.Controls.Add(this.labelX7);
            this.pModule.Controls.Add(this.textBoxX7);
            this.pModule.Controls.Add(this.labelX6);
            this.pModule.Controls.Add(this.tbMID);
            this.pModule.DisabledBackColor = System.Drawing.Color.Empty;
            this.pModule.Dock = System.Windows.Forms.DockStyle.Top;
            this.pModule.Location = new System.Drawing.Point(0, 141);
            this.pModule.Name = "pModule";
            this.pModule.Size = new System.Drawing.Size(523, 117);
            this.pModule.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pModule.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pModule.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.pModule.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pModule.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pModule.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pModule.Style.GradientAngle = 90;
            this.pModule.TabIndex = 24;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(9, 62);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(75, 23);
            this.labelX8.TabIndex = 21;
            this.labelX8.Text = "名称";
            // 
            // tbMName
            // 
            // 
            // 
            // 
            this.tbMName.Border.Class = "TextBoxBorder";
            this.tbMName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbMName.ButtonCustom.Tooltip = "";
            this.tbMName.ButtonCustom2.Tooltip = "";
            this.tbMName.Location = new System.Drawing.Point(90, 62);
            this.tbMName.Name = "tbMName";
            this.tbMName.PreventEnterBeep = true;
            this.tbMName.Size = new System.Drawing.Size(230, 21);
            this.tbMName.TabIndex = 20;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(9, 33);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(75, 23);
            this.labelX7.TabIndex = 19;
            this.labelX7.Text = "编号";
            // 
            // textBoxX7
            // 
            // 
            // 
            // 
            this.textBoxX7.Border.Class = "TextBoxBorder";
            this.textBoxX7.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.textBoxX7.ButtonCustom.Tooltip = "";
            this.textBoxX7.ButtonCustom2.Tooltip = "";
            this.textBoxX7.Location = new System.Drawing.Point(90, 33);
            this.textBoxX7.Name = "textBoxX7";
            this.textBoxX7.PreventEnterBeep = true;
            this.textBoxX7.Size = new System.Drawing.Size(230, 21);
            this.textBoxX7.TabIndex = 18;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(9, 6);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 17;
            this.labelX6.Text = "ID";
            // 
            // tbMID
            // 
            // 
            // 
            // 
            this.tbMID.Border.Class = "TextBoxBorder";
            this.tbMID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbMID.ButtonCustom.Tooltip = "";
            this.tbMID.ButtonCustom2.Tooltip = "";
            this.tbMID.Location = new System.Drawing.Point(90, 6);
            this.tbMID.Name = "tbMID";
            this.tbMID.PreventEnterBeep = true;
            this.tbMID.Size = new System.Drawing.Size(230, 21);
            this.tbMID.TabIndex = 16;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(9, 89);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(75, 23);
            this.labelX9.TabIndex = 23;
            this.labelX9.Text = "顺序";
            // 
            // tbMSortid
            // 
            // 
            // 
            // 
            this.tbMSortid.Border.Class = "TextBoxBorder";
            this.tbMSortid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbMSortid.ButtonCustom.Tooltip = "";
            this.tbMSortid.ButtonCustom2.Tooltip = "";
            this.tbMSortid.Location = new System.Drawing.Point(90, 89);
            this.tbMSortid.Name = "tbMSortid";
            this.tbMSortid.PreventEnterBeep = true;
            this.tbMSortid.Size = new System.Drawing.Size(230, 21);
            this.tbMSortid.TabIndex = 22;
            // 
            // frmBaseMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(905, 464);
            this.Controls.Add(this.panelEx1);
            this.Controls.Add(this.menuTree);
            this.DoubleBuffered = true;
            this.Name = "frmBaseMenu";
            this.Text = "权限维护";
            this.Load += new System.EventHandler(this.frmBaseMenu_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.panelEx1.ResumeLayout(false);
            this.pMenu.ResumeLayout(false);
            this.pModule.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView menuTree;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.PanelEx panelEx1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addMenu;
        private System.Windows.Forms.ToolStripMenuItem delemenu;
        private System.Windows.Forms.ToolStripMenuItem addModule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        public DevComponents.DotNetBar.ButtonX btncancel;
        public DevComponents.DotNetBar.ButtonX btnsave;
        public DevComponents.DotNetBar.ButtonX btnedit;
        private DevComponents.DotNetBar.PanelEx pModule;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.TextBoxX tbMSortid;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.Controls.TextBoxX tbMName;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX tbMID;
        private DevComponents.DotNetBar.PanelEx pMenu;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.Controls.TextBoxX tbId;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbRemark;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbsortid;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbPID;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbName;
    }
}