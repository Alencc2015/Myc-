namespace SimpleWare
{
    partial class frmCarDetail
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
            this.enddate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.date = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.buttonX4 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.tbcar = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbgood = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.tbgoodsname = new DevComponents.DotNetBar.LabelX();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.JCDATE = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.JCGoodsName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.ZYHGSL = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.CYHGSL = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.JCKLSL = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.JCPSSL = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.JCKHSL = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.bhgl = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.cmbkilnno = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.FKilnNO = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.enddate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.date)).BeginInit();
            this.panelEx2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.cmbkilnno);
            this.panelEx1.Controls.Add(this.labelX5);
            this.panelEx1.Controls.Add(this.enddate);
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.date);
            this.panelEx1.Controls.Add(this.labelX3);
            this.panelEx1.Controls.Add(this.buttonX4);
            this.panelEx1.Controls.Add(this.buttonX1);
            this.panelEx1.Controls.Add(this.tbcar);
            this.panelEx1.Controls.Add(this.tbgood);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.tbgoodsname);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(902, 69);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // enddate
            // 
            // 
            // 
            // 
            this.enddate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.enddate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.enddate.ButtonClear.Tooltip = "";
            this.enddate.ButtonCustom.Tooltip = "";
            this.enddate.ButtonCustom2.Tooltip = "";
            this.enddate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.enddate.ButtonDropDown.Tooltip = "";
            this.enddate.ButtonDropDown.Visible = true;
            this.enddate.ButtonFreeText.Tooltip = "";
            this.enddate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.enddate.IsPopupCalendarOpen = false;
            this.enddate.Location = new System.Drawing.Point(94, 32);
            // 
            // 
            // 
            this.enddate.MonthCalendar.AnnuallyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.enddate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.enddate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.enddate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.enddate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.enddate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.enddate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.enddate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.enddate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.enddate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.enddate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.enddate.MonthCalendar.DisplayMonth = new System.DateTime(2015, 5, 1, 0, 0, 0, 0);
            this.enddate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            this.enddate.MonthCalendar.MarkedDates = new System.DateTime[0];
            this.enddate.MonthCalendar.MonthlyMarkedDates = new System.DateTime[0];
            // 
            // 
            // 
            this.enddate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.enddate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.enddate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.enddate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.enddate.MonthCalendar.TodayButtonVisible = true;
            this.enddate.MonthCalendar.WeeklyMarkedDays = new System.DayOfWeek[0];
            this.enddate.Name = "enddate";
            this.enddate.Size = new System.Drawing.Size(121, 26);
            this.enddate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.enddate.TabIndex = 27;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(10, 33);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(94, 23);
            this.labelX2.TabIndex = 28;
            this.labelX2.Text = "结束日期";
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
            this.date.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.date.IsPopupCalendarOpen = false;
            this.date.Location = new System.Drawing.Point(94, 4);
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
            this.date.Size = new System.Drawing.Size(121, 26);
            this.date.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.date.TabIndex = 25;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX3.Location = new System.Drawing.Point(10, 7);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(94, 23);
            this.labelX3.TabIndex = 26;
            this.labelX3.Text = "开始日期";
            // 
            // buttonX4
            // 
            this.buttonX4.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX4.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX4.Font = new System.Drawing.Font("宋体", 12F);
            this.buttonX4.Image = global::SimpleWare.Properties.Resources.File_Excel;
            this.buttonX4.ImageFixedSize = new System.Drawing.Size(48, 48);
            this.buttonX4.Location = new System.Drawing.Point(749, 7);
            this.buttonX4.Name = "buttonX4";
            this.buttonX4.Size = new System.Drawing.Size(94, 48);
            this.buttonX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX4.TabIndex = 24;
            this.buttonX4.Text = "导出";
            this.buttonX4.Click += new System.EventHandler(this.buttonX4_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Font = new System.Drawing.Font("宋体", 12F);
            this.buttonX1.Image = global::SimpleWare.Properties.Resources.zoom_layer;
            this.buttonX1.Location = new System.Drawing.Point(648, 7);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(94, 48);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 23;
            this.buttonX1.Text = "搜索";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // tbcar
            // 
            // 
            // 
            // 
            this.tbcar.Border.Class = "TextBoxBorder";
            this.tbcar.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbcar.ButtonCustom.Tooltip = "";
            this.tbcar.ButtonCustom2.Tooltip = "";
            this.tbcar.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbcar.Location = new System.Drawing.Point(297, 33);
            this.tbcar.Name = "tbcar";
            this.tbcar.PreventEnterBeep = true;
            this.tbcar.Size = new System.Drawing.Size(124, 26);
            this.tbcar.TabIndex = 3;
            // 
            // tbgood
            // 
            // 
            // 
            // 
            this.tbgood.Border.Class = "TextBoxBorder";
            this.tbgood.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbgood.ButtonCustom.Tooltip = "";
            this.tbgood.ButtonCustom2.Tooltip = "";
            this.tbgood.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbgood.Location = new System.Drawing.Point(297, 4);
            this.tbgood.Name = "tbgood";
            this.tbgood.PreventEnterBeep = true;
            this.tbgood.Size = new System.Drawing.Size(124, 26);
            this.tbgood.TabIndex = 2;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(221, 34);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(84, 23);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "窑 车 号";
            // 
            // tbgoodsname
            // 
            // 
            // 
            // 
            this.tbgoodsname.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbgoodsname.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbgoodsname.Location = new System.Drawing.Point(221, 4);
            this.tbgoodsname.Name = "tbgoodsname";
            this.tbgoodsname.Size = new System.Drawing.Size(84, 23);
            this.tbgoodsname.TabIndex = 0;
            this.tbgoodsname.Text = "产品名称";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.superGridControl1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(0, 69);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(902, 338);
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
            this.superGridControl1.Font = new System.Drawing.Font("宋体", 12F);
            this.superGridControl1.Location = new System.Drawing.Point(0, 0);
            this.superGridControl1.Name = "superGridControl1";
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.AllowEdit = false;
            this.superGridControl1.PrimaryGrid.Columns.Add(this.JCDATE);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.JCGoodsName);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.FKilnNO);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.ZYHGSL);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.CYHGSL);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.JCKLSL);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.JCPSSL);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.JCKHSL);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.bhgl);
            this.superGridControl1.PrimaryGrid.ShowRowGridIndex = true;
            this.superGridControl1.PrimaryGrid.UseAlternateRowStyle = true;
            this.superGridControl1.Size = new System.Drawing.Size(902, 338);
            this.superGridControl1.TabIndex = 0;
            this.superGridControl1.Text = "superGridControl1";
            // 
            // JCDATE
            // 
            this.JCDATE.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.JCDATE.DataPropertyName = "JCDATE";
            this.JCDATE.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridDateTimeInputEditControl);
            this.JCDATE.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F);
            this.JCDATE.HeaderText = "日期";
            this.JCDATE.Name = "JCDATE";
            // 
            // JCGoodsName
            // 
            this.JCGoodsName.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JCGoodsName.DataPropertyName = "JCGoodsName";
            this.JCGoodsName.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JCGoodsName.HeaderText = "产品名称";
            this.JCGoodsName.Name = "JCGoodsName";
            // 
            // gridColumn1
            // 
            this.gridColumn1.AutoSizeMode = DevComponents.DotNetBar.SuperGrid.ColumnAutoSizeMode.AllCells;
            this.gridColumn1.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn1.DataPropertyName = "JCCarNO";
            this.gridColumn1.DefaultNewRowCellValue = "";
            this.gridColumn1.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn1.HeaderText = "窑车号";
            this.gridColumn1.Name = "JCCarNO";
            // 
            // gridColumn2
            // 
            this.gridColumn2.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn2.DataPropertyName = "JCMaterial";
            this.gridColumn2.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F);
            this.gridColumn2.HeaderText = "瓷质";
            this.gridColumn2.Name = "JCMaterial";
            // 
            // ZYHGSL
            // 
            this.ZYHGSL.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.ZYHGSL.CellStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZYHGSL.CellStyles.Default.TextColor = System.Drawing.Color.Black;
            this.ZYHGSL.DataPropertyName = "ZYHGSL";
            this.ZYHGSL.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.ZYHGSL.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ZYHGSL.HeaderText = "装窑数量";
            this.ZYHGSL.Name = "ZYHGSL";
            // 
            // CYHGSL
            // 
            this.CYHGSL.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.CYHGSL.CellStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CYHGSL.CellStyles.Default.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CYHGSL.DataPropertyName = "CYHGSL";
            this.CYHGSL.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.CYHGSL.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CYHGSL.HeaderText = "出窑合格数量";
            this.CYHGSL.Name = "CYHGSL";
            // 
            // JCKLSL
            // 
            this.JCKLSL.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.JCKLSL.CellStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JCKLSL.CellStyles.Default.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.JCKLSL.DataPropertyName = "JCKLSL";
            this.JCKLSL.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.JCKLSL.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JCKLSL.HeaderText = "开裂数量";
            this.JCKLSL.Name = "JCKLSL";
            // 
            // JCPSSL
            // 
            this.JCPSSL.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.JCPSSL.CellStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JCPSSL.CellStyles.Default.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.JCPSSL.DataPropertyName = "JCPSSL";
            this.JCPSSL.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.JCPSSL.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JCPSSL.HeaderText = "碰损数量";
            this.JCPSSL.Name = "JCPSSL";
            // 
            // JCKHSL
            // 
            this.JCKHSL.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.JCKHSL.CellStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JCKHSL.CellStyles.Default.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.JCKHSL.DataPropertyName = "JCKHSL";
            this.JCKHSL.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridIntegerInputEditControl);
            this.JCKHSL.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.JCKHSL.HeaderText = "过火数量";
            this.JCKHSL.Name = "JCKHSL";
            // 
            // bhgl
            // 
            this.bhgl.CellStyles.Default.Alignment = DevComponents.DotNetBar.SuperGrid.Style.Alignment.MiddleRight;
            this.bhgl.CellStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.bhgl.CellStyles.Default.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.bhgl.DataPropertyName = "bhgl";
            this.bhgl.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F);
            this.bhgl.HeaderText = "不合格率";
            this.bhgl.Name = "bhgl";
            // 
            // cmbkilnno
            // 
            this.cmbkilnno.DisplayMember = "Text";
            this.cmbkilnno.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbkilnno.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cmbkilnno.FormattingEnabled = true;
            this.cmbkilnno.ItemHeight = 20;
            this.cmbkilnno.Items.AddRange(new object[] {
            this.comboItem7,
            this.comboItem8});
            this.cmbkilnno.Location = new System.Drawing.Point(507, 4);
            this.cmbkilnno.Margin = new System.Windows.Forms.Padding(5);
            this.cmbkilnno.Name = "cmbkilnno";
            this.cmbkilnno.Size = new System.Drawing.Size(121, 26);
            this.cmbkilnno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbkilnno.TabIndex = 64;
            // 
            // comboItem7
            // 
            this.comboItem7.Text = "A班";
            this.comboItem7.Value = "A";
            // 
            // comboItem8
            // 
            this.comboItem8.Text = "B班";
            this.comboItem8.Value = "B";
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX5.Location = new System.Drawing.Point(430, 4);
            this.labelX5.Margin = new System.Windows.Forms.Padding(5);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 24);
            this.labelX5.TabIndex = 63;
            this.labelX5.Text = "窑炉编号";
            // 
            // FKilnNO
            // 
            this.FKilnNO.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.FKilnNO.DataPropertyName = "FKilnNO";
            this.FKilnNO.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 14.25F);
            this.FKilnNO.HeaderText = "窑炉编号";
            this.FKilnNO.Name = "FKilnNO";
            // 
            // frmCarDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 407);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Name = "frmCarDetail";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "装窑明细表";
            this.Load += new System.EventHandler(this.frmCarDetail_Load);
            this.Resize += new System.EventHandler(this.frmCarDetail_Resize);
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.enddate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.date)).EndInit();
            this.panelEx2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.LabelX tbgoodsname;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbcar;
        private DevComponents.DotNetBar.Controls.TextBoxX tbgood;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonX4;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn JCGoodsName;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn ZYHGSL;
        private DevComponents.DotNetBar.SuperGrid.GridColumn CYHGSL;
        private DevComponents.DotNetBar.SuperGrid.GridColumn JCKLSL;
        private DevComponents.DotNetBar.SuperGrid.GridColumn JCPSSL;
        private DevComponents.DotNetBar.SuperGrid.GridColumn JCKHSL;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput date;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn JCDATE;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput enddate;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn bhgl;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbkilnno;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.SuperGrid.GridColumn FKilnNO;
    }
}