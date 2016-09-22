namespace SimpleWare
{
    partial class frmWareHouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWareHouse));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.WareID = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.WareName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.toolbar1 = new SimpleWare.Toolbar();
            this.tbremark = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbwarename = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbwareid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.requiredFieldValidator2 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("仓库名称必须输入");
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("仓库编号必须输入！");
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.panelEx1.SuspendLayout();
            this.panelEx2.SuspendLayout();
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
            this.panelEx1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(560, 519);
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
            this.superGridControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.superGridControl1.Name = "superGridControl1";
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.AllowEdit = false;
            this.superGridControl1.PrimaryGrid.Columns.Add(this.WareID);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.WareName);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.superGridControl1.PrimaryGrid.ShowRowGridIndex = true;
            this.superGridControl1.PrimaryGrid.UseAlternateRowStyle = true;
            this.superGridControl1.Size = new System.Drawing.Size(560, 519);
            this.superGridControl1.TabIndex = 0;
            this.superGridControl1.Text = "superGridControl1";
            // 
            // WareID
            // 
            this.WareID.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.WareID.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WareID.DataPropertyName = "WareID";
            this.WareID.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F);
            this.WareID.HeaderText = "仓库编号";
            this.WareID.Name = "WareID";
            // 
            // WareName
            // 
            this.WareName.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.WareName.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WareName.DataPropertyName = "WareName";
            this.WareName.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F);
            this.WareName.HeaderText = "仓库名称";
            this.WareName.Name = "WareName";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn1.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn1.DataPropertyName = "Remark";
            this.gridColumn1.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F);
            this.gridColumn1.HeaderText = "备注";
            this.gridColumn1.Name = "Remark";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.toolbar1);
            this.panelEx2.Controls.Add(this.tbremark);
            this.panelEx2.Controls.Add(this.tbwarename);
            this.panelEx2.Controls.Add(this.tbwareid);
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(560, 0);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(451, 519);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 1;
            // 
            // toolbar1
            // 
            this.toolbar1.btnEditEnabled = false;
            this.toolbar1.flag = 0;
            this.toolbar1.Location = new System.Drawing.Point(4, 201);
            this.toolbar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.toolbar1.Name = "toolbar1";
            this.toolbar1.Size = new System.Drawing.Size(447, 136);
            this.toolbar1.TabIndex = 6;
            // 
            // tbremark
            // 
            // 
            // 
            // 
            this.tbremark.Border.Class = "TextBoxBorder";
            this.tbremark.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbremark.ButtonCustom.Tooltip = "";
            this.tbremark.ButtonCustom2.Tooltip = "";
            this.tbremark.Font = new System.Drawing.Font("宋体", 14.25F);
            this.tbremark.Location = new System.Drawing.Point(155, 121);
            this.tbremark.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbremark.Name = "tbremark";
            this.tbremark.PreventEnterBeep = true;
            this.tbremark.Size = new System.Drawing.Size(225, 29);
            this.tbremark.TabIndex = 5;
            // 
            // tbwarename
            // 
            // 
            // 
            // 
            this.tbwarename.Border.Class = "TextBoxBorder";
            this.tbwarename.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbwarename.ButtonCustom.Tooltip = "";
            this.tbwarename.ButtonCustom2.Tooltip = "";
            this.tbwarename.Font = new System.Drawing.Font("宋体", 14.25F);
            this.tbwarename.Location = new System.Drawing.Point(155, 68);
            this.tbwarename.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbwarename.Name = "tbwarename";
            this.tbwarename.PreventEnterBeep = true;
            this.tbwarename.Size = new System.Drawing.Size(225, 29);
            this.tbwarename.TabIndex = 4;
            this.superValidator1.SetValidator1(this.tbwarename, this.requiredFieldValidator2);
            // 
            // tbwareid
            // 
            // 
            // 
            // 
            this.tbwareid.Border.Class = "TextBoxBorder";
            this.tbwareid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbwareid.ButtonCustom.Tooltip = "";
            this.tbwareid.ButtonCustom2.Tooltip = "";
            this.tbwareid.Font = new System.Drawing.Font("宋体", 14.25F);
            this.tbwareid.Location = new System.Drawing.Point(155, 15);
            this.tbwareid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbwareid.Name = "tbwareid";
            this.tbwareid.PreventEnterBeep = true;
            this.tbwareid.Size = new System.Drawing.Size(225, 29);
            this.tbwareid.TabIndex = 3;
            this.superValidator1.SetValidator1(this.tbwareid, this.requiredFieldValidator1);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX3.Location = new System.Drawing.Point(25, 76);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(119, 31);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "仓库名称";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX2.Location = new System.Drawing.Point(28, 129);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(119, 31);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "备    注";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX1.Location = new System.Drawing.Point(25, 23);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(119, 31);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "仓库编号";
            // 
            // superValidator1
            // 
            this.superValidator1.ContainerControl = this;
            this.superValidator1.ErrorProvider = this.errorProvider1;
            this.superValidator1.Highlighter = this.highlighter1;
            // 
            // requiredFieldValidator2
            // 
            this.requiredFieldValidator2.ErrorMessage = "仓库名称必须输入";
            this.requiredFieldValidator2.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "仓库编号必须输入！";
            this.requiredFieldValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
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
            // frmWareHouse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1011, 519);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmWareHouse";
            this.Text = "仓库档案";
            this.Load += new System.EventHandler(this.frmWareHouse_Load);
            this.Resize += new System.EventHandler(this.frmWareHouse_Resize);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn WareID;
        private DevComponents.DotNetBar.SuperGrid.GridColumn WareName;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbremark;
        private DevComponents.DotNetBar.Controls.TextBoxX tbwarename;
        private DevComponents.DotNetBar.Controls.TextBoxX tbwareid;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private Toolbar toolbar1;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator2;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
    }
}