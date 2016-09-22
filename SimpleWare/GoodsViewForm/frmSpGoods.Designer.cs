namespace SimpleWare.GoodsViewForm
{
    partial class frmSpGoods
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.GoodMaterial = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.FTypeSteps1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn6 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn8 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn9 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.tbmqty = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.cmbMaterial = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tbgoodname = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tbfcolorsteps = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tbftypestep3 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tbftypestep2 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.tbftypestep1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cmbColor = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.ckbifstop = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.toolbar1 = new SimpleWare.Toolbar();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbmono = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbgoodid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("产品编号必须输入！");
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("名称必须输入!");
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("请输入花色名称！");
            this.gridColumn10 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.superGridControl1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(360, 689);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 1;
            // 
            // superGridControl1
            // 
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.Font = new System.Drawing.Font("宋体", 11F);
            this.superGridControl1.Location = new System.Drawing.Point(0, 0);
            this.superGridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.superGridControl1.Name = "superGridControl1";
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.AllowEdit = false;
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoHideDeletedRows = false;
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.GoodMaterial);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.FTypeSteps1);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn6);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn8);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn10);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn9);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.superGridControl1.PrimaryGrid.EnableColumnFiltering = true;
            this.superGridControl1.PrimaryGrid.EnableFiltering = true;
            this.superGridControl1.PrimaryGrid.EnableRowFiltering = true;
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.Filter.Visible = true;
            this.superGridControl1.PrimaryGrid.FrozenColumnCount = 2;
            this.superGridControl1.PrimaryGrid.ShowRowGridIndex = true;
            this.superGridControl1.Size = new System.Drawing.Size(360, 689);
            this.superGridControl1.TabIndex = 0;
            this.superGridControl1.Text = "superGridControl1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn1.DataPropertyName = "GoodId";
            this.gridColumn1.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn1.HeaderText = " 编号";
            this.gridColumn1.Name = "GoodId";
            // 
            // gridColumn3
            // 
            this.gridColumn3.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn3.DataPropertyName = "GoodName";
            this.gridColumn3.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn3.HeaderText = "器型名称";
            this.gridColumn3.Name = "GoodName";
            // 
            // gridColumn4
            // 
            this.gridColumn4.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn4.DataPropertyName = "ModelNO";
            this.gridColumn4.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn4.HeaderText = "器型编号";
            this.gridColumn4.Name = "ModelNO";
            // 
            // gridColumn5
            // 
            this.gridColumn5.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn5.DataPropertyName = "FColor";
            this.gridColumn5.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn5.HeaderText = "花色";
            this.gridColumn5.Name = "FColor";
            // 
            // GoodMaterial
            // 
            this.GoodMaterial.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.GoodMaterial.DataPropertyName = "GoodMaterial";
            this.GoodMaterial.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.GoodMaterial.HeaderText = " 瓷质";
            this.GoodMaterial.Name = "GoodMaterial";
            // 
            // FTypeSteps1
            // 
            this.FTypeSteps1.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.FTypeSteps1.DataPropertyName = "FTypeSteps1";
            this.FTypeSteps1.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.FTypeSteps1.HeaderText = "器型工序#1";
            this.FTypeSteps1.Name = "FTypeSteps1";
            // 
            // gridColumn6
            // 
            this.gridColumn6.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn6.DataPropertyName = "FTypeSteps2";
            this.gridColumn6.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn6.HeaderText = "器型工序#2";
            this.gridColumn6.Name = "FTypeSteps2";
            // 
            // gridColumn7
            // 
            this.gridColumn7.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn7.DataPropertyName = "FTypeSteps3";
            this.gridColumn7.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn7.HeaderText = "器型工序#3";
            this.gridColumn7.Name = "FTypeSteps3";
            // 
            // gridColumn8
            // 
            this.gridColumn8.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn8.DataPropertyName = "FColorSteps";
            this.gridColumn8.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn8.HeaderText = "花色工序";
            this.gridColumn8.Name = "FColorSteps";
            // 
            // gridColumn9
            // 
            this.gridColumn9.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleCenter;
            this.gridColumn9.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn9.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridCheckBoxXEditControl);
            this.gridColumn9.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn9.HeaderText = "停产";
            this.gridColumn9.Name = "FIsStop";
            // 
            // gridColumn2
            // 
            this.gridColumn2.DataPropertyName = "FImagePath";
            this.gridColumn2.HeaderText = "图片";
            this.gridColumn2.Name = "FImagePath";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.tbmqty);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Controls.Add(this.labelX10);
            this.panelEx2.Controls.Add(this.cmbMaterial);
            this.panelEx2.Controls.Add(this.tbgoodname);
            this.panelEx2.Controls.Add(this.tbfcolorsteps);
            this.panelEx2.Controls.Add(this.tbftypestep3);
            this.panelEx2.Controls.Add(this.tbftypestep2);
            this.panelEx2.Controls.Add(this.tbftypestep1);
            this.panelEx2.Controls.Add(this.cmbColor);
            this.panelEx2.Controls.Add(this.ckbifstop);
            this.panelEx2.Controls.Add(this.labelX9);
            this.panelEx2.Controls.Add(this.labelX8);
            this.panelEx2.Controls.Add(this.labelX7);
            this.panelEx2.Controls.Add(this.labelX6);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.toolbar1);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.tbmono);
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.tbgoodid);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.Controls.Add(this.pictureBox1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(360, 0);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(4);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(893, 689);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 2;
            // 
            // tbmqty
            // 
            // 
            // 
            // 
            this.tbmqty.Border.Class = "TextBoxBorder";
            this.tbmqty.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbmqty.ButtonCustom.Tooltip = "";
            this.tbmqty.ButtonCustom2.Tooltip = "";
            this.tbmqty.Font = new System.Drawing.Font("宋体", 14F);
            this.tbmqty.Location = new System.Drawing.Point(103, 337);
            this.tbmqty.Margin = new System.Windows.Forms.Padding(4);
            this.tbmqty.Name = "tbmqty";
            this.tbmqty.PreventEnterBeep = true;
            this.tbmqty.Size = new System.Drawing.Size(268, 29);
            this.tbmqty.TabIndex = 35;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX2.Location = new System.Drawing.Point(13, 338);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(81, 23);
            this.labelX2.TabIndex = 34;
            this.labelX2.Text = "瓷重";
            this.labelX2.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX10.Location = new System.Drawing.Point(12, 302);
            this.labelX10.Margin = new System.Windows.Forms.Padding(4);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(73, 23);
            this.labelX10.TabIndex = 33;
            this.labelX10.Text = "瓷质";
            this.labelX10.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cmbMaterial
            // 
            this.cmbMaterial.DisplayMember = "Text";
            this.cmbMaterial.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMaterial.Font = new System.Drawing.Font("宋体", 14F);
            this.cmbMaterial.FormattingEnabled = true;
            this.cmbMaterial.ItemHeight = 23;
            this.cmbMaterial.Location = new System.Drawing.Point(102, 301);
            this.cmbMaterial.Name = "cmbMaterial";
            this.cmbMaterial.Size = new System.Drawing.Size(269, 29);
            this.cmbMaterial.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbMaterial.TabIndex = 32;
            // 
            // tbgoodname
            // 
            this.tbgoodname.DisplayMember = "Text";
            this.tbgoodname.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tbgoodname.Font = new System.Drawing.Font("宋体", 14F);
            this.tbgoodname.FormattingEnabled = true;
            this.tbgoodname.ItemHeight = 23;
            this.tbgoodname.Location = new System.Drawing.Point(102, 49);
            this.tbgoodname.Name = "tbgoodname";
            this.tbgoodname.Size = new System.Drawing.Size(269, 29);
            this.tbgoodname.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tbgoodname.TabIndex = 31;
            this.tbgoodname.Leave += new System.EventHandler(this.tbmodelno_Leave);
            // 
            // tbfcolorsteps
            // 
            this.tbfcolorsteps.DisplayMember = "Text";
            this.tbfcolorsteps.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tbfcolorsteps.Font = new System.Drawing.Font("宋体", 14F);
            this.tbfcolorsteps.FormattingEnabled = true;
            this.tbfcolorsteps.ItemHeight = 23;
            this.tbfcolorsteps.Location = new System.Drawing.Point(102, 265);
            this.tbfcolorsteps.Name = "tbfcolorsteps";
            this.tbfcolorsteps.Size = new System.Drawing.Size(269, 29);
            this.tbfcolorsteps.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tbfcolorsteps.TabIndex = 30;
            // 
            // tbftypestep3
            // 
            this.tbftypestep3.DisplayMember = "Text";
            this.tbftypestep3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tbftypestep3.Font = new System.Drawing.Font("宋体", 14F);
            this.tbftypestep3.FormattingEnabled = true;
            this.tbftypestep3.ItemHeight = 23;
            this.tbftypestep3.Location = new System.Drawing.Point(102, 229);
            this.tbftypestep3.Name = "tbftypestep3";
            this.tbftypestep3.Size = new System.Drawing.Size(269, 29);
            this.tbftypestep3.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tbftypestep3.TabIndex = 29;
            // 
            // tbftypestep2
            // 
            this.tbftypestep2.DisplayMember = "Text";
            this.tbftypestep2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tbftypestep2.Font = new System.Drawing.Font("宋体", 14F);
            this.tbftypestep2.FormattingEnabled = true;
            this.tbftypestep2.ItemHeight = 23;
            this.tbftypestep2.Location = new System.Drawing.Point(102, 193);
            this.tbftypestep2.Name = "tbftypestep2";
            this.tbftypestep2.Size = new System.Drawing.Size(269, 29);
            this.tbftypestep2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tbftypestep2.TabIndex = 28;
            // 
            // tbftypestep1
            // 
            this.tbftypestep1.DisplayMember = "Text";
            this.tbftypestep1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.tbftypestep1.Font = new System.Drawing.Font("宋体", 14F);
            this.tbftypestep1.FormattingEnabled = true;
            this.tbftypestep1.ItemHeight = 23;
            this.tbftypestep1.Location = new System.Drawing.Point(102, 157);
            this.tbftypestep1.Name = "tbftypestep1";
            this.tbftypestep1.Size = new System.Drawing.Size(269, 29);
            this.tbftypestep1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.tbftypestep1.TabIndex = 27;
            // 
            // cmbColor
            // 
            this.cmbColor.DisplayMember = "Text";
            this.cmbColor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbColor.Font = new System.Drawing.Font("宋体", 14F);
            this.cmbColor.FormattingEnabled = true;
            this.cmbColor.ItemHeight = 23;
            this.cmbColor.Location = new System.Drawing.Point(102, 121);
            this.cmbColor.Name = "cmbColor";
            this.cmbColor.Size = new System.Drawing.Size(269, 29);
            this.cmbColor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbColor.TabIndex = 25;
            this.cmbColor.Leave += new System.EventHandler(this.cmbColor_Leave);
            // 
            // ckbifstop
            // 
            // 
            // 
            // 
            this.ckbifstop.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckbifstop.Font = new System.Drawing.Font("宋体", 14F);
            this.ckbifstop.Location = new System.Drawing.Point(376, 301);
            this.ckbifstop.Name = "ckbifstop";
            this.ckbifstop.Size = new System.Drawing.Size(83, 29);
            this.ckbifstop.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckbifstop.TabIndex = 23;
            this.ckbifstop.Text = "停用";
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX9.Location = new System.Drawing.Point(12, 266);
            this.labelX9.Margin = new System.Windows.Forms.Padding(4);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(73, 23);
            this.labelX9.TabIndex = 21;
            this.labelX9.Text = "花色工序";
            this.labelX9.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX8.Location = new System.Drawing.Point(12, 230);
            this.labelX8.Margin = new System.Windows.Forms.Padding(4);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(94, 23);
            this.labelX8.TabIndex = 19;
            this.labelX8.Text = "器型工序#3";
            this.labelX8.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX7.Location = new System.Drawing.Point(12, 194);
            this.labelX7.Margin = new System.Windows.Forms.Padding(4);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(90, 23);
            this.labelX7.TabIndex = 17;
            this.labelX7.Text = "器型工序#2";
            this.labelX7.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX6.Location = new System.Drawing.Point(12, 158);
            this.labelX6.Margin = new System.Windows.Forms.Padding(4);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(103, 23);
            this.labelX6.TabIndex = 15;
            this.labelX6.Text = "器型工序#1";
            this.labelX6.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX5.Location = new System.Drawing.Point(12, 122);
            this.labelX5.Margin = new System.Windows.Forms.Padding(4);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(103, 23);
            this.labelX5.TabIndex = 13;
            this.labelX5.Text = "花色名称";
            this.labelX5.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // toolbar1
            // 
            this.toolbar1.btnEditEnabled = false;
            this.toolbar1.flag = 0;
            this.toolbar1.Font = new System.Drawing.Font("宋体", 12F);
            this.toolbar1.Location = new System.Drawing.Point(24, 376);
            this.toolbar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolbar1.Name = "toolbar1";
            this.toolbar1.Size = new System.Drawing.Size(544, 136);
            this.toolbar1.TabIndex = 11;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX4.Location = new System.Drawing.Point(12, 50);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(103, 23);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "器型名称";
            this.labelX4.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbmono
            // 
            // 
            // 
            // 
            this.tbmono.Border.Class = "TextBoxBorder";
            this.tbmono.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbmono.ButtonCustom.Tooltip = "";
            this.tbmono.ButtonCustom2.Tooltip = "";
            this.tbmono.Font = new System.Drawing.Font("宋体", 14F);
            this.tbmono.Location = new System.Drawing.Point(102, 85);
            this.tbmono.Margin = new System.Windows.Forms.Padding(4);
            this.tbmono.Name = "tbmono";
            this.tbmono.PreventEnterBeep = true;
            this.tbmono.Size = new System.Drawing.Size(268, 29);
            this.tbmono.TabIndex = 6;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX3.Location = new System.Drawing.Point(12, 86);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(90, 23);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "器型编号";
            this.labelX3.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // tbgoodid
            // 
            // 
            // 
            // 
            this.tbgoodid.Border.Class = "TextBoxBorder";
            this.tbgoodid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbgoodid.ButtonCustom.Tooltip = "";
            this.tbgoodid.ButtonCustom2.Tooltip = "";
            this.tbgoodid.Font = new System.Drawing.Font("宋体", 14F);
            this.tbgoodid.Location = new System.Drawing.Point(102, 13);
            this.tbgoodid.Margin = new System.Windows.Forms.Padding(4);
            this.tbgoodid.Name = "tbgoodid";
            this.tbgoodid.PreventEnterBeep = true;
            this.tbgoodid.Size = new System.Drawing.Size(268, 29);
            this.tbgoodid.TabIndex = 2;
            this.tbgoodid.Leave += new System.EventHandler(this.tbgoodid_Leave);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX1.Location = new System.Drawing.Point(12, 14);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(103, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "编号";
            this.labelX1.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(376, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 274);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click_1);
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "产品编号必须输入！";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "名称必须输入!";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // expandableSplitter1
            // 
            this.expandableSplitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandableSplitter1.ExpandableControl = this.panelEx1;
            this.expandableSplitter1.ExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.ExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.ExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.ExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.GripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.GripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.GripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.HotBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(151)))), ((int)(((byte)(61)))));
            this.expandableSplitter1.HotBackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(184)))), ((int)(((byte)(94)))));
            this.expandableSplitter1.HotBackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground2;
            this.expandableSplitter1.HotBackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemPressedBackground;
            this.expandableSplitter1.HotExpandFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotExpandFillColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotExpandLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.expandableSplitter1.HotExpandLineColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandableSplitter1.HotGripDarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(147)))), ((int)(((byte)(207)))));
            this.expandableSplitter1.HotGripDarkColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandableSplitter1.HotGripLightColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            this.expandableSplitter1.HotGripLightColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.expandableSplitter1.Location = new System.Drawing.Point(360, 0);
            this.expandableSplitter1.Margin = new System.Windows.Forms.Padding(4);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(5, 689);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 15;
            this.expandableSplitter1.TabStop = false;
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ErrorMessage = "请输入花色名称！";
            this.requiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // gridColumn10
            // 
            this.gridColumn10.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn10.DataPropertyName = "FMaterialQty";
            this.gridColumn10.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn10.HeaderText = "瓷重";
            this.gridColumn10.Name = "FMaterialQty";
            // 
            // frmSpGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1253, 689);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "frmSpGoods";
            this.Text = "选瓷产品输入";
            this.Load += new System.EventHandler(this.frmSpGoods_Load);
            this.Resize += new System.EventHandler(this.frmSpGoods_Resize);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckbifstop;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX5;
        private Toolbar toolbar1;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbmono;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbgoodid;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn FTypeSteps1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn6;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn8;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn9;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbColor;
        private DevComponents.DotNetBar.Controls.ComboBoxEx tbftypestep3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx tbftypestep2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx tbftypestep1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx tbfcolorsteps;
        private DevComponents.DotNetBar.Controls.ComboBoxEx tbgoodname;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbMaterial;
        private DevComponents.DotNetBar.SuperGrid.GridColumn GoodMaterial;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbmqty;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn10;

    }
}