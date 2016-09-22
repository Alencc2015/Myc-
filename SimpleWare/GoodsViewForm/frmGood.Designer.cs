namespace SimpleWare
{
    partial class frmGood
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
            this.superGridControl1 = new DevComponents.DotNetBar.SuperGrid.SuperGridControl();
            this.tbgoodsname = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.tbgoodid = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.tbmodelno = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.tbitemno = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gridColumn1 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn2 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn3 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn4 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            this.gridColumn5 = new DevComponents.DotNetBar.SuperGrid.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // superGridControl1
            // 
            this.superGridControl1.FilterExprColors.SysFunction = System.Drawing.Color.DarkRed;
            this.superGridControl1.Location = new System.Drawing.Point(-4, 12);
            this.superGridControl1.Name = "superGridControl1";
            // 
            // 
            // 
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn1);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn2);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn3);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn4);
            this.superGridControl1.PrimaryGrid.Columns.Add(this.gridColumn5);
            this.superGridControl1.Size = new System.Drawing.Size(396, 390);
            this.superGridControl1.TabIndex = 0;
            this.superGridControl1.Text = "superGridControl1";
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
            this.tbgoodsname.Location = new System.Drawing.Point(508, 90);
            this.tbgoodsname.Margin = new System.Windows.Forms.Padding(4);
            this.tbgoodsname.Name = "tbgoodsname";
            this.tbgoodsname.PreventEnterBeep = true;
            this.tbgoodsname.Size = new System.Drawing.Size(296, 29);
            this.tbgoodsname.TabIndex = 8;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX2.Location = new System.Drawing.Point(407, 92);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(80, 31);
            this.labelX2.TabIndex = 7;
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
            this.tbgoodid.Location = new System.Drawing.Point(508, 27);
            this.tbgoodid.Margin = new System.Windows.Forms.Padding(4);
            this.tbgoodid.Name = "tbgoodid";
            this.tbgoodid.PreventEnterBeep = true;
            this.tbgoodid.Size = new System.Drawing.Size(296, 29);
            this.tbgoodid.TabIndex = 6;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX1.Location = new System.Drawing.Point(399, 31);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(100, 31);
            this.labelX1.TabIndex = 5;
            this.labelX1.Text = "编号";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(407, 247);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(89, 106);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 9;
            this.buttonX1.Text = "buttonX1";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
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
            this.tbmodelno.Location = new System.Drawing.Point(508, 190);
            this.tbmodelno.Margin = new System.Windows.Forms.Padding(4);
            this.tbmodelno.Name = "tbmodelno";
            this.tbmodelno.PreventEnterBeep = true;
            this.tbmodelno.Size = new System.Drawing.Size(296, 29);
            this.tbmodelno.TabIndex = 14;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX4.Location = new System.Drawing.Point(410, 188);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(100, 31);
            this.labelX4.TabIndex = 13;
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
            this.tbitemno.Location = new System.Drawing.Point(508, 127);
            this.tbitemno.Margin = new System.Windows.Forms.Padding(4);
            this.tbitemno.Name = "tbitemno";
            this.tbitemno.PreventEnterBeep = true;
            this.tbitemno.Size = new System.Drawing.Size(296, 29);
            this.tbitemno.TabIndex = 12;
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("宋体", 14F);
            this.labelX3.Location = new System.Drawing.Point(410, 127);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(80, 31);
            this.labelX3.TabIndex = 11;
            this.labelX3.Text = "货号";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(508, 227);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(296, 226);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.DataPropertyName = "GoodId";
            this.gridColumn1.HeaderText = "编号";
            this.gridColumn1.Name = "GoodId";
            // 
            // gridColumn2
            // 
            this.gridColumn2.DefaultNewRowCellValue = "GoodName";
            this.gridColumn2.HeaderText = "名称";
            this.gridColumn2.Name = "GoodName";
            // 
            // gridColumn3
            // 
            this.gridColumn3.DefaultNewRowCellValue = "ItemNO";
            this.gridColumn3.HeaderText = "货号";
            this.gridColumn3.Name = "ItemNO";
            // 
            // gridColumn4
            // 
            this.gridColumn4.DefaultNewRowCellValue = "ModelNO";
            this.gridColumn4.HeaderText = "型号";
            this.gridColumn4.Name = "ModelNO";
            // 
            // gridColumn5
            // 
            this.gridColumn5.DefaultNewRowCellValue = "FImagePath";
            this.gridColumn5.HeaderText = "图片路径";
            this.gridColumn5.Name = "FImagePath";
            // 
            // frmGood
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 483);
            this.Controls.Add(this.tbmodelno);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.tbitemno);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.tbgoodsname);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.tbgoodid);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.superGridControl1);
            this.DoubleBuffered = true;
            this.Name = "frmGood";
            this.Text = "frmGood";
            this.Load += new System.EventHandler(this.frmGood_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.SuperGrid.SuperGridControl superGridControl1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbgoodsname;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX tbgoodid;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.Controls.TextBoxX tbmodelno;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX tbitemno;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn1;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn2;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn3;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn4;
        private DevComponents.DotNetBar.SuperGrid.GridColumn gridColumn5;
    }
}