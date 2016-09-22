namespace SimpleWare
{
    partial class frmUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsers));
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.EmpId = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.EmpName = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.EmpFalg = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.EmpGroupID = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.EmpPost = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.EmpPhone = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.panelEx2 = new DevComponents.DotNetBar.PanelEx();
            this.cmbSCX = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem1 = new DevComponents.Editors.ComboItem();
            this.comboItem2 = new DevComponents.Editors.ComboItem();
            this.labelX11 = new DevComponents.DotNetBar.LabelX();
            this.cmbkilnno = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.comboItem7 = new DevComponents.Editors.ComboItem();
            this.comboItem8 = new DevComponents.Editors.ComboItem();
            this.labelX10 = new DevComponents.DotNetBar.LabelX();
            this.cmbRole = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.tbphone = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.tbpos = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.tbdept = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.toolbar1 = new SimpleWare.Toolbar();
            this.comboBoxEx1 = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.confirmpassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbpassword = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbemplid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.tbname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.superValidator1 = new DevComponents.DotNetBar.Validator.SuperValidator();
            this.compareValidator1 = new DevComponents.DotNetBar.Validator.CompareValidator();
            this.requiredFieldValidator1 = new DevComponents.DotNetBar.Validator.RequiredFieldValidator("Your error message here.");
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
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
            this.panelEx1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(571, 544);
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
            this.superGridControl1.Location = new System.Drawing.Point(0, 0);
            this.superGridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.superGridControl1.Name = "superGridControl1";
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.AllowEdit = false;
            this.superGridControl1.PrimaryGrid.AllowRowDelete = true;
            this.superGridControl1.PrimaryGrid.AutoHideDeletedRows = false;
            this.superGridControl1.PrimaryGrid.Columns.Add(this.EmpId);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.EmpName);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.EmpFalg);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.EmpGroupID);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.EmpPost);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.EmpPhone);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.superGridControl1.PrimaryGrid.ShowRowGridIndex = true;
            this.superGridControl1.PrimaryGrid.UseAlternateRowStyle = true;
            this.superGridControl1.Size = new System.Drawing.Size(571, 544);
            this.superGridControl1.TabIndex = 0;
            this.superGridControl1.Text = "superGridControl1";
            // 
            // EmpId
            // 
            this.EmpId.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.EmpId.DataPropertyName = "EmpId";
            this.EmpId.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EmpId.HeaderStyles.Default.TextColor = System.Drawing.SystemColors.ControlText;
            this.EmpId.HeaderText = "登录名";
            this.EmpId.Name = "EmpId";
            // 
            // EmpName
            // 
            this.EmpName.AllowSelection = false;
            this.EmpName.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.EmpName.DataPropertyName = "EmpName";
            this.EmpName.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EmpName.HeaderStyles.Default.TextColor = System.Drawing.SystemColors.ControlText;
            this.EmpName.HeaderText = "姓名";
            this.EmpName.Name = "EmpName";
            // 
            // EmpFalg
            // 
            this.EmpFalg.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EmpFalg.DataPropertyName = "EmpFalg";
            this.EmpFalg.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EmpFalg.HeaderStyles.Default.TextColor = System.Drawing.SystemColors.ControlText;
            this.EmpFalg.HeaderText = "用户类型";
            this.EmpFalg.Name = "EmpFalg";
            // 
            // EmpGroupID
            // 
            this.EmpGroupID.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.EmpGroupID.DataPropertyName = "EmpGroupID";
            this.EmpGroupID.EditorType = typeof(DevComponents.DotNetBar.SuperGrid.GridComboBoxExEditControl);
            this.EmpGroupID.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.EmpGroupID.HeaderText = "权限组";
            this.EmpGroupID.Name = "EmpGroupID";
            // 
            // gridColumn1
            // 
            this.gridColumn1.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn1.DataPropertyName = "EmpDept";
            this.gridColumn1.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn1.HeaderStyles.Default.TextColor = System.Drawing.SystemColors.ControlText;
            this.gridColumn1.HeaderText = "部门";
            this.gridColumn1.Name = "EmpDept";
            // 
            // EmpPost
            // 
            this.EmpPost.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.EmpPost.DataPropertyName = "EmpPost";
            this.EmpPost.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EmpPost.HeaderText = "职务";
            this.EmpPost.Name = "EmpPost";
            // 
            // EmpPhone
            // 
            this.EmpPhone.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.EmpPhone.DataPropertyName = "EmpPhone";
            this.EmpPhone.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.EmpPhone.HeaderText = "电话";
            this.EmpPhone.Name = "EmpPhone";
            // 
            // gridColumn2
            // 
            this.gridColumn2.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn2.DataPropertyName = "EmpLoginPwd";
            this.gridColumn2.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridColumn2.HeaderText = "密码";
            this.gridColumn2.Name = "EmpLoginPwd";
            // 
            // panelEx2
            // 
            this.panelEx2.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx2.Controls.Add(this.cmbSCX);
            this.panelEx2.Controls.Add(this.labelX11);
            this.panelEx2.Controls.Add(this.cmbkilnno);
            this.panelEx2.Controls.Add(this.labelX10);
            this.panelEx2.Controls.Add(this.cmbRole);
            this.panelEx2.Controls.Add(this.labelX9);
            this.panelEx2.Controls.Add(this.tbphone);
            this.panelEx2.Controls.Add(this.labelX8);
            this.panelEx2.Controls.Add(this.tbpos);
            this.panelEx2.Controls.Add(this.labelX7);
            this.panelEx2.Controls.Add(this.tbdept);
            this.panelEx2.Controls.Add(this.labelX6);
            this.panelEx2.Controls.Add(this.toolbar1);
            this.panelEx2.Controls.Add(this.comboBoxEx1);
            this.panelEx2.Controls.Add(this.labelX5);
            this.panelEx2.Controls.Add(this.confirmpassword);
            this.panelEx2.Controls.Add(this.tbpassword);
            this.panelEx2.Controls.Add(this.tbemplid);
            this.panelEx2.Controls.Add(this.tbname);
            this.panelEx2.Controls.Add(this.labelX4);
            this.panelEx2.Controls.Add(this.labelX3);
            this.panelEx2.Controls.Add(this.labelX2);
            this.panelEx2.Controls.Add(this.labelX1);
            this.panelEx2.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx2.Location = new System.Drawing.Point(571, 0);
            this.panelEx2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelEx2.Name = "panelEx2";
            this.panelEx2.Size = new System.Drawing.Size(454, 544);
            this.panelEx2.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx2.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx2.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.panelEx2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx2.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx2.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx2.Style.GradientAngle = 90;
            this.panelEx2.TabIndex = 1;
            // 
            // cmbSCX
            // 
            this.cmbSCX.DisplayMember = "Text";
            this.cmbSCX.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSCX.Font = new System.Drawing.Font("宋体", 12F);
            this.cmbSCX.FormattingEnabled = true;
            this.cmbSCX.ItemHeight = 20;
            this.cmbSCX.Items.AddRange(new object[] {
            this.comboItem1,
            this.comboItem2});
            this.cmbSCX.Location = new System.Drawing.Point(114, 285);
            this.cmbSCX.Margin = new System.Windows.Forms.Padding(5);
            this.cmbSCX.Name = "cmbSCX";
            this.cmbSCX.Size = new System.Drawing.Size(259, 26);
            this.cmbSCX.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbSCX.TabIndex = 66;
            // 
            // comboItem1
            // 
            this.comboItem1.Text = "A班";
            this.comboItem1.Value = "A";
            // 
            // comboItem2
            // 
            this.comboItem2.Text = "B班";
            this.comboItem2.Value = "B";
            // 
            // labelX11
            // 
            // 
            // 
            // 
            this.labelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX11.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX11.Location = new System.Drawing.Point(27, 289);
            this.labelX11.Margin = new System.Windows.Forms.Padding(5);
            this.labelX11.Name = "labelX11";
            this.labelX11.Size = new System.Drawing.Size(59, 20);
            this.labelX11.TabIndex = 65;
            this.labelX11.Text = "生产线";
            this.labelX11.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX11.TextLineAlignment = System.Drawing.StringAlignment.Far;
            // 
            // cmbkilnno
            // 
            this.cmbkilnno.DisplayMember = "Text";
            this.cmbkilnno.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbkilnno.Font = new System.Drawing.Font("宋体", 12F);
            this.cmbkilnno.FormattingEnabled = true;
            this.cmbkilnno.ItemHeight = 20;
            this.cmbkilnno.Items.AddRange(new object[] {
            this.comboItem7,
            this.comboItem8});
            this.cmbkilnno.Location = new System.Drawing.Point(114, 319);
            this.cmbkilnno.Margin = new System.Windows.Forms.Padding(0);
            this.cmbkilnno.Name = "cmbkilnno";
            this.cmbkilnno.Size = new System.Drawing.Size(259, 26);
            this.cmbkilnno.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbkilnno.TabIndex = 43;
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
            // labelX10
            // 
            // 
            // 
            // 
            this.labelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX10.Font = new System.Drawing.Font("宋体", 12F);
            this.labelX10.Location = new System.Drawing.Point(27, 317);
            this.labelX10.Margin = new System.Windows.Forms.Padding(5);
            this.labelX10.Name = "labelX10";
            this.labelX10.Size = new System.Drawing.Size(82, 28);
            this.labelX10.TabIndex = 44;
            this.labelX10.Text = "窑炉编号";
            // 
            // cmbRole
            // 
            this.cmbRole.DisplayMember = "Text";
            this.cmbRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.ItemHeight = 20;
            this.cmbRole.Location = new System.Drawing.Point(114, 353);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(259, 26);
            this.cmbRole.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cmbRole.TabIndex = 18;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX9.Location = new System.Drawing.Point(23, 350);
            this.labelX9.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(99, 31);
            this.labelX9.TabIndex = 17;
            this.labelX9.Text = "权 限 组";
            // 
            // tbphone
            // 
            // 
            // 
            // 
            this.tbphone.Border.Class = "TextBoxBorder";
            this.tbphone.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbphone.ButtonCustom.Tooltip = "";
            this.tbphone.ButtonCustom2.Tooltip = "";
            this.tbphone.Location = new System.Drawing.Point(114, 251);
            this.tbphone.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbphone.Name = "tbphone";
            this.tbphone.PreventEnterBeep = true;
            this.tbphone.Size = new System.Drawing.Size(259, 26);
            this.tbphone.TabIndex = 16;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX8.Location = new System.Drawing.Point(23, 250);
            this.labelX8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(88, 31);
            this.labelX8.TabIndex = 15;
            this.labelX8.Text = "电    话";
            // 
            // tbpos
            // 
            // 
            // 
            // 
            this.tbpos.Border.Class = "TextBoxBorder";
            this.tbpos.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbpos.ButtonCustom.Tooltip = "";
            this.tbpos.ButtonCustom2.Tooltip = "";
            this.tbpos.Location = new System.Drawing.Point(114, 217);
            this.tbpos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpos.Name = "tbpos";
            this.tbpos.PreventEnterBeep = true;
            this.tbpos.Size = new System.Drawing.Size(259, 26);
            this.tbpos.TabIndex = 14;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.Location = new System.Drawing.Point(23, 216);
            this.labelX7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(85, 31);
            this.labelX7.TabIndex = 13;
            this.labelX7.Text = "职    务";
            // 
            // tbdept
            // 
            // 
            // 
            // 
            this.tbdept.Border.Class = "TextBoxBorder";
            this.tbdept.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbdept.ButtonCustom.Tooltip = "";
            this.tbdept.ButtonCustom2.Tooltip = "";
            this.tbdept.Location = new System.Drawing.Point(114, 183);
            this.tbdept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbdept.Name = "tbdept";
            this.tbdept.PreventEnterBeep = true;
            this.tbdept.Size = new System.Drawing.Size(259, 26);
            this.tbdept.TabIndex = 12;
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(23, 184);
            this.labelX6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(85, 31);
            this.labelX6.TabIndex = 11;
            this.labelX6.Text = "部    门";
            // 
            // toolbar1
            // 
            this.toolbar1.btnEditEnabled = false;
            this.toolbar1.flag = 0;
            this.toolbar1.Location = new System.Drawing.Point(7, 382);
            this.toolbar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toolbar1.Name = "toolbar1";
            this.toolbar1.Size = new System.Drawing.Size(447, 149);
            this.toolbar1.TabIndex = 10;
            // 
            // comboBoxEx1
            // 
            this.comboBoxEx1.DisplayMember = "Text";
            this.comboBoxEx1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comboBoxEx1.FormattingEnabled = true;
            this.comboBoxEx1.ItemHeight = 20;
            this.comboBoxEx1.Location = new System.Drawing.Point(114, 149);
            this.comboBoxEx1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.comboBoxEx1.Name = "comboBoxEx1";
            this.comboBoxEx1.Size = new System.Drawing.Size(259, 26);
            this.comboBoxEx1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.comboBoxEx1.TabIndex = 9;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(23, 150);
            this.labelX5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(81, 31);
            this.labelX5.TabIndex = 8;
            this.labelX5.Text = "用户类型";
            // 
            // confirmpassword
            // 
            // 
            // 
            // 
            this.confirmpassword.Border.Class = "TextBoxBorder";
            this.confirmpassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.confirmpassword.ButtonCustom.Tooltip = "";
            this.confirmpassword.ButtonCustom2.Tooltip = "";
            this.confirmpassword.Location = new System.Drawing.Point(114, 115);
            this.confirmpassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.confirmpassword.Name = "confirmpassword";
            this.confirmpassword.PasswordChar = '*';
            this.confirmpassword.PreventEnterBeep = true;
            this.confirmpassword.Size = new System.Drawing.Size(259, 26);
            this.confirmpassword.TabIndex = 7;
            this.superValidator1.SetValidator1(this.confirmpassword, this.compareValidator1);
            this.confirmpassword.Leave += new System.EventHandler(this.confirmpassword_Leave);
            // 
            // tbpassword
            // 
            // 
            // 
            // 
            this.tbpassword.Border.Class = "TextBoxBorder";
            this.tbpassword.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbpassword.ButtonCustom.Tooltip = "";
            this.tbpassword.ButtonCustom2.Tooltip = "";
            this.tbpassword.Location = new System.Drawing.Point(114, 81);
            this.tbpassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbpassword.Name = "tbpassword";
            this.tbpassword.PasswordChar = '*';
            this.tbpassword.PreventEnterBeep = true;
            this.tbpassword.Size = new System.Drawing.Size(259, 26);
            this.tbpassword.TabIndex = 6;
            // 
            // tbemplid
            // 
            // 
            // 
            // 
            this.tbemplid.Border.Class = "TextBoxBorder";
            this.tbemplid.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbemplid.ButtonCustom.Tooltip = "";
            this.tbemplid.ButtonCustom2.Tooltip = "";
            this.tbemplid.Location = new System.Drawing.Point(114, 47);
            this.tbemplid.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbemplid.Name = "tbemplid";
            this.tbemplid.PreventEnterBeep = true;
            this.tbemplid.Size = new System.Drawing.Size(259, 26);
            this.tbemplid.TabIndex = 5;
            this.superValidator1.SetValidator1(this.tbemplid, this.requiredFieldValidator1);
            // 
            // tbname
            // 
            // 
            // 
            // 
            this.tbname.Border.Class = "TextBoxBorder";
            this.tbname.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tbname.ButtonCustom.Tooltip = "";
            this.tbname.ButtonCustom2.Tooltip = "";
            this.tbname.Location = new System.Drawing.Point(114, 13);
            this.tbname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbname.Name = "tbname";
            this.tbname.PreventEnterBeep = true;
            this.tbname.Size = new System.Drawing.Size(259, 26);
            this.tbname.TabIndex = 4;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(23, 114);
            this.labelX4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(79, 31);
            this.labelX4.TabIndex = 3;
            this.labelX4.Text = "确认密码";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(23, 80);
            this.labelX3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(82, 31);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "登录密码";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(23, 48);
            this.labelX2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(99, 31);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "登 录 名";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Location = new System.Drawing.Point(23, 13);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(99, 31);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "姓    名";
            // 
            // superValidator1
            // 
            this.superValidator1.ContainerControl = this;
            this.superValidator1.ErrorProvider = this.errorProvider1;
            this.superValidator1.Highlighter = this.highlighter1;
            // 
            // compareValidator1
            // 
            this.compareValidator1.ControlToCompare = this.tbpassword;
            this.compareValidator1.ErrorMessage = "2次输入密码不一致！！";
            this.compareValidator1.HighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Red;
            // 
            // requiredFieldValidator1
            // 
            this.requiredFieldValidator1.ErrorMessage = "Your error message here.";
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
            // gridColumn3
            // 
            this.gridColumn3.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn3.DataPropertyName = "EmpKilnNO";
            this.gridColumn3.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn3.HeaderText = "窑炉编号";
            this.gridColumn3.Name = "EmpKilnNO";
            // 
            // gridColumn4
            // 
            this.gridColumn4.CellStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn4.DefaultNewRowCellValue = "EmpWorshoId";
            this.gridColumn4.HeaderStyles.Default.Font = new System.Drawing.Font("宋体", 12F);
            this.gridColumn4.HeaderText = "生产线";
            this.gridColumn4.Name = "EmpWorshoId";
            // 
            // frmUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 544);
            this.Controls.Add(this.panelEx2);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmUsers";
            this.Text = "用户管理";
            this.Load += new System.EventHandler(this.frmUsers_Load);
            this.Resize += new System.EventHandler(this.frmUsers_Resize);
            this.panelEx1.ResumeLayout(false);
            this.panelEx2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.PanelEx panelEx2;
        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.DotNetBar.Controls.TextBoxX confirmpassword;
        private DevComponents.DotNetBar.Controls.TextBoxX tbpassword;
        private DevComponents.DotNetBar.Controls.TextBoxX tbemplid;
        private DevComponents.DotNetBar.Controls.TextBoxX tbname;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx comboBoxEx1;
        private DevComponents.DotNetBar.LabelX labelX5;
        private Toolbar toolbar1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn EmpId;
        private DevComponents.DotNetBar.SuperGrid.GridColumn EmpName;
        private DevComponents.DotNetBar.SuperGrid.GridColumn EmpFalg;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn EmpPost;
        private DevComponents.DotNetBar.SuperGrid.GridColumn EmpPhone;
        private DevComponents.DotNetBar.Controls.TextBoxX tbpos;
        private DevComponents.DotNetBar.LabelX labelX7;
        private DevComponents.DotNetBar.Controls.TextBoxX tbdept;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX tbphone;
        private DevComponents.DotNetBar.LabelX labelX8;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.Validator.SuperValidator superValidator1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevComponents.DotNetBar.Validator.CompareValidator compareValidator1;
        private DevComponents.DotNetBar.Validator.RequiredFieldValidator requiredFieldValidator1;
        private DevComponents.DotNetBar.LabelX labelX9;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbRole;
        private DevComponents.DotNetBar.SuperGrid.GridColumn EmpGroupID;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbkilnno;
        private DevComponents.Editors.ComboItem comboItem7;
        private DevComponents.Editors.ComboItem comboItem8;
        private DevComponents.DotNetBar.LabelX labelX10;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cmbSCX;
        private DevComponents.Editors.ComboItem comboItem1;
        private DevComponents.Editors.ComboItem comboItem2;
        private DevComponents.DotNetBar.LabelX labelX11;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
    }
}