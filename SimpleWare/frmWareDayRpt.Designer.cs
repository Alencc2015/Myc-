namespace SimpleWare
{
    partial class frmWareDayRpt
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
            this.cbwarehouse = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.date = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.tbgoodsname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.FGoodsName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.FMaterial = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.zrjc = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.rksl = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.pssl = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.PSL = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.JCSL = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.lblsl = new DevComponents.DotNetBar.LabelX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.date)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.lblsl);
            this.panelEx1.Controls.Add(this.labelX4);
            this.panelEx1.Controls.Add(this.cbwarehouse);
            this.panelEx1.Controls.Add(this.date);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.buttonX4);
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.tbgoodsname);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(765, 78);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // cbwarehouse
            // 
            this.cbwarehouse.DisplayMember = "Text";
            this.cbwarehouse.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbwarehouse.Font = new System.Drawing.Font("宋体", 12F);
            this.cbwarehouse.FormattingEnabled = true;
            this.cbwarehouse.ItemHeight = 20;
            this.cbwarehouse.Location = new System.Drawing.Point(358, 12);
            this.cbwarehouse.Name = "cbwarehouse";
            this.cbwarehouse.Size = new System.Drawing.Size(182, 26);
            this.cbwarehouse.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbwarehouse.TabIndex = 3;
            // 
            // date
            // 
            // 
            // 
            // 
            this.date.BackgroundStyle.Class = "DateTimeInputBackground";
            this.date.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.date.ButtonClear.Tooltip = "";
            this.date.ButtonCustom.Tooltip = "";
            this.date.ButtonCustom2.Tooltip = "";
            this.date.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.date.ButtonDropDown.Tooltip = "";
            this.date.ButtonDropDown.Visible = true;
            this.date.ButtonFreeText.Tooltip = "";
            this.date.Font = new System.Drawing.Font("宋体", 12F);
            this.date.IsPopupCalendarOpen = false;
            this.date.Location = new System.Drawing.Point(97, 11);
            // 
            // 
            // 
            this.date.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.date.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.date.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.date.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.date.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.date.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.date.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.date.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.date.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.date.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.date.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.date.MonthCalendar.DisplayMonth = new System.DateTime(2015, 5, 1, 0, 0, 0, 0);
            this.date.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.date.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.date.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.date.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.date.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.date.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.date.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.date.MonthCalendar.TodayButtonVisible = true;
            this.date.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(164, 26);
            this.date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.date.TabIndex = 1;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 14.25F);
            this.labelX3.Location = new System.Drawing.Point(6, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(85, 23);
            this.labelX3.TabIndex = 23;
            this.labelX3.Text = "日期";
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Font = new System.Drawing.Font("宋体", 12F);
            this.buttonX4.Image = global::SimpleWare.Properties.Resources.File_Excel;
            this.buttonX4.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.buttonX4.Location = new System.Drawing.Point(642, 17);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(92, 48);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 5;
            this.buttonX4.Text = "导出";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("宋体", 12F);
            this.buttonX1.Image = global::SimpleWare.Properties.Resources.zoom_layer;
            this.buttonX1.Location = new System.Drawing.Point(546, 17);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(92, 48);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 4;
            this.buttonX1.Text = "搜索";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
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
            this.tbgoodsname.Font = new System.Drawing.Font("宋体", 14.25F);
            this.tbgoodsname.Location = new System.Drawing.Point(97, 41);
            this.tbgoodsname.Name = "tbgoodsname";
            this.tbgoodsname.PreventEnterBeep = true;
            this.tbgoodsname.Size = new System.Drawing.Size(164, 29);
            this.tbgoodsname.TabIndex = 2;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 14.25F);
            this.labelX2.Location = new System.Drawing.Point(6, 44);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(85, 23);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "产品名称";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 14.25F);
            this.labelX1.Location = new System.Drawing.Point(267, 15);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(85, 23);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "仓位名称";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.superGridControl1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 78);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(765, 326);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 1;
            // 
            // superGridControl1
            // 
            this.superGridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.Font = new System.Drawing.Font("宋体", 14F);
            this.superGridControl1.Location = new System.Drawing.Point(0, 0);
            this.superGridControl1.Name = "superGridControl1";
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.AllowEdit = false;
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.FGoodsName);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.FMaterial);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.zrjc);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.rksl);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.pssl);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.PSL);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.JCSL);
            this.superGridControl1.PrimaryGrid.ShowRowGridIndex = true;
            this.superGridControl1.PrimaryGrid.UseAlternateRowStyle = true;
            this.superGridControl1.Size = new System.Drawing.Size(765, 326);
            this.superGridControl1.TabIndex = 0;
            this.superGridControl1.Text = "superGridControl1";
            // 
            // gridColumn1
            // 
            this.gridColumn1.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn1.DataPropertyName = "warename";
            this.gridColumn1.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn1.HeaderText = "仓位名称";
            this.gridColumn1.Name = "warename";
            // 
            // FGoodsName
            // 
            this.FGoodsName.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FGoodsName.DataPropertyName = "FGoodsName";
            this.FGoodsName.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FGoodsName.HeaderText = "产品名称";
            this.FGoodsName.Name = "FGoodsName";
            // 
            // FMaterial
            // 
            this.FMaterial.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.FMaterial.DataPropertyName = "FMaterial";
            this.FMaterial.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 15F);
            this.FMaterial.HeaderText = "瓷质";
            this.FMaterial.Name = "FMaterial";
            // 
            // zrjc
            // 
            this.zrjc.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.zrjc.CellStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zrjc.DataPropertyName = "zrjc";
            this.zrjc.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.zrjc.HeaderText = "昨日结存";
            this.zrjc.Name = "zrjc";
            // 
            // rksl
            // 
            this.rksl.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.rksl.CellStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rksl.CellStyles.Default.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rksl.DataPropertyName = "rksl";
            this.rksl.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rksl.HeaderStyles.Default.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.rksl.HeaderText = "入库数量";
            this.rksl.Name = "rksl";
            // 
            // gridColumn2
            // 
            this.gridColumn2.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.gridColumn2.CellStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn2.CellStyles.Default.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridColumn2.DataPropertyName = "CKSL";
            this.gridColumn2.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn2.HeaderStyles.Default.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.gridColumn2.HeaderText = "出库数量";
            this.gridColumn2.Name = "CKSL";
            // 
            // pssl
            // 
            this.pssl.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.pssl.CellStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pssl.CellStyles.Default.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pssl.DataPropertyName = "pssl";
            this.pssl.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.pssl.HeaderStyles.Default.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pssl.HeaderText = "碰损数量";
            this.pssl.Name = "pssl";
            // 
            // PSL
            // 
            this.PSL.CellStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PSL.CellStyles.Default.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PSL.DataPropertyName = "psl";
            this.PSL.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDoubleInputEditControl);
            this.PSL.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F);
            this.PSL.HeaderStyles.Default.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PSL.HeaderText = "碰损率";
            this.PSL.Name = "PSL";
            // 
            // JCSL
            // 
            this.JCSL.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.JCSL.CellStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JCSL.DataPropertyName = "JCSL";
            this.JCSL.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JCSL.HeaderText = "结存数量";
            this.JCSL.Name = "JCSL";
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 14.25F);
            this.labelX4.Location = new System.Drawing.Point(267, 47);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(110, 23);
            this.labelX4.TabIndex = 24;
            this.labelX4.Text = "合计库存：";
            // 
            // lblsl
            // 
            // 
            // 
            // 
            this.lblsl.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblsl.Font = new System.Drawing.Font("宋体", 14.25F);
            this.lblsl.Location = new System.Drawing.Point(358, 47);
            this.lblsl.Name = "lblsl";
            this.lblsl.Size = new System.Drawing.Size(182, 23);
            this.lblsl.TabIndex = 25;
            // 
            // frmWareDayRpt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 404);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "frmWareDayRpt";
            this.Text = "库存报表";
            this.Load += new System.EventHandler(this.frmWareDayRpt_Load);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.date)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbgoodsname;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput date;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbwarehouse;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn FGoodsName;
        private DevComponents.DotNetBar.SuperGrid.GridColumn zrjc;
        private DevComponents.DotNetBar.SuperGrid.GridColumn rksl;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn JCSL;
        private DevComponents.DotNetBar.SuperGrid.GridColumn pssl;
        private DevComponents.DotNetBar.SuperGrid.GridColumn PSL;
        private DevComponents.DotNetBar.SuperGrid.GridColumn FMaterial;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX lblsl;
    }
}