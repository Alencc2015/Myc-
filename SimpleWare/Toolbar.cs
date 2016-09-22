using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SimpleWare.BaseClass;
namespace SimpleWare
{
    public partial class Toolbar : UserControl
    {
        public delegate void BtnSaveClick(object sender, EventArgs e);
        public delegate void BtnNewClick(object sender, EventArgs e);
        public delegate void BtnDeleteClick(object sender, EventArgs e);
        public delegate void BtnEditClick(object sender, EventArgs e);
        public delegate void BtnCancelClick(object sender, EventArgs e);
        public delegate void BtnImportClick(object sender, EventArgs e);
        //public delegate void SetBtnEditEnabled(object sender, EventArgs e);

        //public event SetBtnEditEnabled setBtnEditEnabled;
        public event BtnCancelClick btnCancelClick;
        public event BtnEditClick btnEditClick;
        public event BtnDeleteClick btnDeleteClick;
        public event BtnNewClick btnNewClick;
        public event BtnSaveClick btnSaveClick;
        public event BtnImportClick btnImportClick;

        
        public Dictionary<string, object> controlsValue;
        private int OpFlag;
        public int flag
        {
            get { return OpFlag; }
            set { OpFlag = value; }
        }

        private Boolean BtnEditEnabled;
        public Boolean btnEditEnabled
        {
            get { return BtnEditEnabled; }
            set 
            {
                BtnEditEnabled = value;
                btnedit.Enabled = value;
            }
        }
        public Toolbar()
        {
            InitializeComponent();
        }

        private void btnnew_Click(object sender, EventArgs e)
        {
            btnnew.Enabled = false;
            btnedit.Enabled = false;
            btndelete.Enabled = false;
            btnsave.Enabled = true;
            btncancel.Enabled = true;
            btnImport.Enabled = false;
            if (btnNewClick != null)
            {
                btnNewClick(this,new EventArgs());
            }
        }

        private void Toolbar_Load(object sender, EventArgs e)
        {
            btnsave.Enabled = false;
            btncancel.Enabled = false;
            //btnedit.Enabled = false;
            //btndelete.Enabled = false;
            //btnedit.Enabled = btnEditEnabled;
            //this.setBtnEditEnabled += new SetBtnEditEnabled(setEnabled);
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            if (btnSaveClick != null)
            {
                btnSaveClick(this, new EventArgs());
            }
            if (flag == 0)
            {
                if (cbcontinue.Checked)
                {
                    btnnew.Enabled = false;
                    btnedit.Enabled = false;
                    btnsave.Enabled = true;
                    btncancel.Enabled = true;
                    btndelete.Enabled = false;
                    
                }
                else
                {
                    btnnew.Enabled = true;
                    btnedit.Enabled = true;
                    btnsave.Enabled = false;
                    btncancel.Enabled = false;
                    btndelete.Enabled = true;
                }
            }
            else
            {
                btnnew.Enabled = true;
                btnedit.Enabled = true;
                btnsave.Enabled = false;
                btncancel.Enabled = false;
                btndelete.Enabled = true;
            }
        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            btnnew.Enabled = false;
            btnedit.Enabled = false;
            btnsave.Enabled = true;
            btncancel.Enabled = true;
            btndelete.Enabled = false;
            btnImport.Enabled = false;
            if (btnEditClick != null)
            {
                btnEditClick(this, new EventArgs());
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            Boolean isGm = frmLogin.isGm || frmLogin.isSuperGm;
            //if (!isGm)
            //{
            //    MessageUtil.ShowError("您无权删除该数据，请联系系统管理员!");
            //    return;
            //}
            if (btnDeleteClick != null)
            {
                btnDeleteClick(this, new EventArgs());
            }
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            if (btnCancelClick != null)
            {
                btnCancelClick(this, new EventArgs());
            }
            //if (flag == 0)
            //{
            //    btnnew.Enabled = true;
            //    btnedit.Enabled = true;
            //    //btnsave.Enabled = false;
            //    btndelete.Enabled = true;
            //    btncancel.Enabled = false;
            //    btnImport.Enabled = true;
            //}
            //else
            //{

            //}
            btnnew.Enabled = true;
            btnedit.Enabled = true;
            btnsave.Enabled = false;
            btndelete.Enabled = true;
            btncancel.Enabled = false;
            btnImport.Enabled = true;

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (btnImportClick != null)
            {
                btnImportClick(this, new EventArgs());
            }
        }
    }
}
