namespace SimpleWare
{
    partial class frmGoods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGoods));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn7 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.GoodId = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.GoodName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.ItemNO = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.ModelNO = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.GoodMaterial = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.fImage = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.tbmodelno = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbitemno = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.tbgoodsname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbgoodid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("编号必须输入！");
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator4 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("名称必须输入");
            this.requiredFieldValidator3 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("编号必须输入");
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.expandableSplitter1 = new DevComponents.DotNetBar.ExpandableSplitter();
            this.toolbar1 = new SimpleWare.Toolbar();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
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
            this.panelEx1.Size = new System.Drawing.Size(473, 654);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // superGridControl1
            // 
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.Font = new System.Drawing.Font("宋体", 12F);
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
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn7);
            this.superGridControl1.PrimaryGrid.EnableColumnFiltering = true;
            this.superGridControl1.PrimaryGrid.EnableFiltering = true;
            this.superGridControl1.PrimaryGrid.EnableRowFiltering = true;
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.Filter.Visible = true;
            this.superGridControl1.PrimaryGrid.FrozenColumnCount = 2;
            this.superGridControl1.PrimaryGrid.ShowRowGridIndex = true;
            this.superGridControl1.Size = new System.Drawing.Size(473, 654);
            this.superGridControl1.TabIndex = 0;
            this.superGridControl1.Text = "superGridControl1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn1.DataPropertyName = "GoodId";
            this.gridColumn1.HeaderText = "编号";
            this.gridColumn1.Name = "GoodId";
            // 
            // gridColumn2
            // 
            this.gridColumn2.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn2.DataPropertyName = "GoodName";
            this.gridColumn2.HeaderText = "名称";
            this.gridColumn2.Name = "GoodName";
            // 
            // gridColumn3
            // 
            this.gridColumn3.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn3.DataPropertyName = "ItemNO";
            this.gridColumn3.HeaderText = "货号";
            this.gridColumn3.Name = "ItemNO";
            // 
            // gridColumn4
            // 
            this.gridColumn4.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn4.DataPropertyName = "ModelNO";
            this.gridColumn4.HeaderText = "器型编号";
            this.gridColumn4.Name = "ModelNO";
            // 
            // gridColumn7
            // 
            this.gridColumn7.AdjustSortImagePositionByMargin = true;
            this.gridColumn7.DataPropertyName = "FImagePath";
            this.gridColumn7.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridImageEditControl);
            this.gridColumn7.HeaderText = "图片";
            this.gridColumn7.Name = "FImagePath";
            // 
            // GoodId
            // 
            this.GoodId.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.GoodId.DataPropertyName = "GoodId";
            this.GoodId.HeaderText = "编号";
            this.GoodId.Name = "GoodId";
            // 
            // GoodName
            // 
            this.GoodName.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.GoodName.DataPropertyName = "GoodName";
            this.GoodName.HeaderText = "名称";
            this.GoodName.Name = "GoodName";
            // 
            // ItemNO
            // 
            this.ItemNO.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.ItemNO.DataPropertyName = "ItemNO";
            this.ItemNO.HeaderText = "货号";
            this.ItemNO.Name = "ItemNO";
            // 
            // ModelNO
            // 
            this.ModelNO.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.ModelNO.DataPropertyName = "ModelNO";
            this.ModelNO.HeaderText = "器型编号";
            this.ModelNO.Name = "ModelNO";
            // 
            // GoodMaterial
            // 
            this.GoodMaterial.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.GoodMaterial.DataPropertyName = "GoodMaterial";
            this.GoodMaterial.HeaderText = "瓷质";
            this.GoodMaterial.Name = "GoodMaterial";
            // 
            // fImage
            // 
            this.fImage.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.Fill;
            this.fImage.DataPropertyName = "fImage";
            this.fImage.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridImageEditControl);
            this.fImage.HeaderText = "图片";
            this.fImage.Name = "fImage";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.toolbar1);
            this.panelEx2.Controls.Add(this.tbmodelno);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.tbitemno);
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.tbgoodsname);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Controls.Add(this.tbgoodid);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.Controls.Add(this.pictureBox1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(473, 0);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(4);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(707, 654);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 1;
            // 
            // tbmodelno
            // 
            // 
            // 
            // 
            this.tbmodelno.Border.Class = "TextBoxBorder";
            this.tbmodelno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbmodelno.ButtonCustom.Tooltip = "";
            this.tbmodelno.ButtonCustom2.Tooltip = "";
            this.tbmodelno.Font = new System.Drawing.Font("宋体", 14F);
            this.tbmodelno.Location = new System.Drawing.Point(110, 238);
            this.tbmodelno.Margin = new System.Windows.Forms.Padding(4);
            this.tbmodelno.Name = "tbmodelno";
            this.tbmodelno.PreventEnterBeep = true;
            this.tbmodelno.Size = new System.Drawing.Size(296, 29);
            this.tbmodelno.TabIndex = 8;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX4.Location = new System.Drawing.Point(11, 236);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(103, 31);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "器型编号";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tbitemno
            // 
            // 
            // 
            // 
            this.tbitemno.Border.Class = "TextBoxBorder";
            this.tbitemno.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbitemno.ButtonCustom.Tooltip = "";
            this.tbitemno.ButtonCustom2.Tooltip = "";
            this.tbitemno.Font = new System.Drawing.Font("宋体", 14F);
            this.tbitemno.Location = new System.Drawing.Point(113, 164);
            this.tbitemno.Margin = new System.Windows.Forms.Padding(4);
            this.tbitemno.Name = "tbitemno";
            this.tbitemno.PreventEnterBeep = true;
            this.tbitemno.Size = new System.Drawing.Size(296, 29);
            this.tbitemno.TabIndex = 6;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX3.Location = new System.Drawing.Point(11, 163);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(103, 31);
            this.labelX3.TabIndex = 5;
            this.labelX3.Text = "货号";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // tbgoodsname
            // 
            // 
            // 
            // 
            this.tbgoodsname.Border.Class = "TextBoxBorder";
            this.tbgoodsname.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbgoodsname.ButtonCustom.Tooltip = "";
            this.tbgoodsname.ButtonCustom2.Tooltip = "";
            this.tbgoodsname.Font = new System.Drawing.Font("宋体", 14F);
            this.tbgoodsname.Location = new System.Drawing.Point(113, 90);
            this.tbgoodsname.Margin = new System.Windows.Forms.Padding(4);
            this.tbgoodsname.Name = "tbgoodsname";
            this.tbgoodsname.PreventEnterBeep = true;
            this.tbgoodsname.Size = new System.Drawing.Size(296, 29);
            this.tbgoodsname.TabIndex = 4;
            this.superValidator1.SetValidator1(this.tbgoodsname, this.requiredFieldValidator4);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX2.Location = new System.Drawing.Point(11, 90);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(103, 31);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "名称";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
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
            this.tbgoodid.Location = new System.Drawing.Point(113, 16);
            this.tbgoodid.Margin = new System.Windows.Forms.Padding(4);
            this.tbgoodid.Name = "tbgoodid";
            this.tbgoodid.PreventEnterBeep = true;
            this.tbgoodid.Size = new System.Drawing.Size(296, 29);
            this.tbgoodid.TabIndex = 2;
            this.superValidator1.SetValidator1(this.tbgoodid, this.requiredFieldValidator3);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX1.Location = new System.Drawing.Point(11, 17);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(103, 31);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "编号";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(414, 8);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(289, 260);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "Your error message here.";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "编号必须输入！";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // superValidator1
            // 
            this.superValidator1.ContainerControl = this;
            this.superValidator1.ErrorProvider = this.errorProvider1;
            this.superValidator1.Highlighter = this.highlighter1;
            // 
            // requiredFieldValidator4
            // 
            this.requiredFieldValidator4.ErrorMessage = "名称必须输入";
            this.requiredFieldValidator4.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator3
            // 
            this.requiredFieldValidator3.ErrorMessage = "编号必须输入";
            this.requiredFieldValidator3.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
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
            this.expandableSplitter1.Location = new System.Drawing.Point(473, 0);
            this.expandableSplitter1.Margin = new System.Windows.Forms.Padding(4);
            this.expandableSplitter1.Name = "expandableSplitter1";
            this.expandableSplitter1.Size = new System.Drawing.Size(5, 654);
            this.expandableSplitter1.Style = DevComponents.DotNetBar.eSplitterStyle.Office2007;
            this.expandableSplitter1.TabIndex = 16;
            this.expandableSplitter1.TabStop = false;
            // 
            // toolbar1
            // 
            this.toolbar1.btnEditEnabled = false;
            this.toolbar1.flag = 0;
            this.toolbar1.Font = new System.Drawing.Font("宋体", 12F);
            this.toolbar1.Location = new System.Drawing.Point(31, 291);
            this.toolbar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolbar1.Name = "toolbar1";
            this.toolbar1.Size = new System.Drawing.Size(544, 136);
            this.toolbar1.TabIndex = 13;
            // 
            // frmGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 654);
            this.Controls.Add(this.expandableSplitter1);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmGoods";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "产品维护";
            this.Load += new System.EventHandler(this.frmGoods_Load);
            this.Resize += new System.EventHandler(this.frmGoods_Resize);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn GoodId;
        private DevComponents.DotNetBar.SuperGrid.GridColumn GoodName;
        private DevComponents.DotNetBar.SuperGrid.GridColumn ItemNO;
        private DevComponents.DotNetBar.SuperGrid.GridColumn ModelNO;
        private DevComponents.DotNetBar.SuperGrid.GridColumn GoodMaterial;
        private DevComponents.DotNetBar.SuperGrid.GridColumn fImage;
        private DevComponents.DotNetBar.Controls.TextBoxX tbmodelno;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbitemno;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.TextBoxX tbgoodsname;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbgoodid;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator4;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator3;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn7;
        private DevComponents.DotNetBar.ExpandableSplitter expandableSplitter1;
        private Toolbar toolbar1;
    }
}