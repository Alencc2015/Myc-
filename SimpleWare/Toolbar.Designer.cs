namespace SimpleWare
{
    partial class Toolbar
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btndelete = new DevComponents.DotNetBar.ButtonX();
            this.btnsave = new DevComponents.DotNetBar.ButtonX();
            this.btnedit = new DevComponents.DotNetBar.ButtonX();
            this.btnnew = new DevComponents.DotNetBar.ButtonX();
            this.btncancel = new DevComponents.DotNetBar.ButtonX();
            this.cbcontinue = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.btnImport = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // btndelete
            // 
            this.btndelete.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btndelete.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btndelete.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btndelete.Image = global::SimpleWare.Properties.Resources.Folder_delete;
            this.btndelete.ImageFixedSize = new System.Drawing.Size(64, 64);
            this.btndelete.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btndelete.ImageTextSpacing = -15;
            this.btndelete.Location = new System.Drawing.Point(271, 29);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(57, 70);
            this.btndelete.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btndelete.TabIndex = 18;
            this.btndelete.Text = "删除";
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
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
            this.btnsave.Location = new System.Drawing.Point(137, 29);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(57, 70);
            this.btnsave.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnsave.TabIndex = 17;
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
            this.btnedit.Location = new System.Drawing.Point(70, 29);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(57, 70);
            this.btnedit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnedit.TabIndex = 16;
            this.btnedit.Text = "编辑";
            this.btnedit.Click += new System.EventHandler(this.btnedit_Click);
            // 
            // btnnew
            // 
            this.btnnew.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnnew.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnnew.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnnew.Image = global::SimpleWare.Properties.Resources.Folder_add;
            this.btnnew.ImageFixedSize = new System.Drawing.Size(64, 64);
            this.btnnew.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnnew.ImageTextSpacing = -15;
            this.btnnew.Location = new System.Drawing.Point(3, 29);
            this.btnnew.Name = "btnnew";
            this.btnnew.Size = new System.Drawing.Size(57, 70);
            this.btnnew.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnnew.TabIndex = 15;
            this.btnnew.Text = "新增";
            this.btnnew.Click += new System.EventHandler(this.btnnew_Click);
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
            this.btncancel.Location = new System.Drawing.Point(204, 29);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(57, 70);
            this.btncancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btncancel.TabIndex = 19;
            this.btncancel.Text = "取消";
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // cbcontinue
            // 
            // 
            // 
            // 
            this.cbcontinue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.cbcontinue.Checked = true;
            this.cbcontinue.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbcontinue.CheckValue = "Y";
            this.cbcontinue.Location = new System.Drawing.Point(6, 3);
            this.cbcontinue.Name = "cbcontinue";
            this.cbcontinue.Size = new System.Drawing.Size(269, 23);
            this.cbcontinue.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbcontinue.TabIndex = 20;
            this.cbcontinue.Text = "新增时保存完继续新增";
            // 
            // btnImport
            // 
            this.btnImport.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImport.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnImport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnImport.Image = global::SimpleWare.Properties.Resources.Folder;
            this.btnImport.ImageFixedSize = new System.Drawing.Size(64, 64);
            this.btnImport.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnImport.ImageTextSpacing = -15;
            this.btnImport.Location = new System.Drawing.Point(338, 29);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(57, 70);
            this.btnImport.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnImport.TabIndex = 21;
            this.btnImport.Text = "导入";
            this.btnImport.Visible = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // Toolbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.cbcontinue);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btnedit);
            this.Controls.Add(this.btnnew);
            this.Name = "Toolbar";
            this.Size = new System.Drawing.Size(432, 102);
            this.Load += new System.EventHandler(this.Toolbar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public DevComponents.DotNetBar.ButtonX btnedit;
        public DevComponents.DotNetBar.ButtonX btndelete;
        public DevComponents.DotNetBar.ButtonX btnsave;
        public DevComponents.DotNetBar.ButtonX btnnew;
        public DevComponents.DotNetBar.ButtonX btncancel;
        public DevComponents.DotNetBar.Controls.CheckBoxX cbcontinue;
        public DevComponents.DotNetBar.ButtonX btnImport;
    }
}
