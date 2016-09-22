using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SimpleWare.ClassInfo;
using SimpleWare.DbMethod;
using SimpleWare.BaseClass;
using SimpleWare.Menu;
namespace SimpleWare
{
    public partial class frmSettings : Office2007Form
    {
        tb_settings setting;
        tb_SettingsMethod settingMethod = new tb_SettingsMethod();
        public frmSettings()
        {
            InitializeComponent();
        }

        private void rdbServer_Click(object sender, EventArgs e)
        {
            rdbLocal.Checked = false;
            rdbServer.Checked = true;
            tbPath.ReadOnly = false;
        }

        private void rdbLocal_Click(object sender, EventArgs e)
        {
            rdbLocal.Checked = true;
            rdbServer.Checked = false;
            tbPath.ReadOnly = true;
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            btnCancel.Enabled = false;
            btnSave.Enabled = false;
            LoadSettings();
            setControlsReadOnly(true);
        }

        private void setControlsReadOnly(bool p)
        {
            rdbLocal.Enabled = !p;
            rdbServer.Enabled = !p;
            tbPath.ReadOnly = p;
            ckbIsNeedRate.Enabled = !p;
        }

        private void LoadSettings()
        {
            setting = settingMethod.Find();
            switch (setting.PicSaveStyle)
            {
                case 0:
                    rdbLocal.Checked = true;
                    break;
                case 1:
                    rdbServer.Checked = true;
                    break;
            }
            tbPath.Text = setting.PicPath;
            ckbIsNeedRate.Checked = setting.IsNeedRate == 1;
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = false;
            btnSave.Enabled = true;
            btnCancel.Enabled = true;
            setControlsReadOnly(false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //btne
            if (rdbLocal.Checked)
                setting.PicSaveStyle = 0;
            if (rdbServer.Checked)
                setting.PicSaveStyle = 1;
            setting.PicPath = tbPath.Text.Trim();
            setting.IsNeedRate = ckbIsNeedRate.Checked ? 1 : 0;
            if (settingMethod.Update(setting))
                MessageUtil.ShowTips("保存成功!");
            LoadSettings();
            btnCancel.Enabled = false;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            setControlsReadOnly(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnCancel.Enabled = false;
            LoadSettings();
            setControlsReadOnly(true);
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            frmBaseMenu fra = new frmBaseMenu();
            //fra.MdiParent = this;
            fra.Show();
        }
    }
}
