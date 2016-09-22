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
namespace SimpleWare
{
    public partial class VKeyBoard : UserControl
    {
        public VKeyBoard()
        {
            InitializeComponent();
        }
        public delegate void labClick(object sender, EventArgs e);
        //public delegate void SetBtnEditEnabled(object sender, EventArgs e);

        //public event SetBtnEditEnabled setBtnEditEnabled;
        public event labClick lblclick;
        Color backColor1 = Color.Transparent;//这颜色是时鼠标经过变色的，对功能没有作用
        Color backColor2 = Color.Orange;
        Color backColor3 = Color.Blue;
        private void labSend_Click(object sender, EventArgs e)
        {
            if (lblclick != null)
            {
                lblclick(this,new EventArgs());
            }
            Label lab = sender as Label;

            SendKeys.Send(lab.Text);            
        }

        private void labSend_MouseEnter(object sender, EventArgs e)
        {
            backColor1 = ((Label)(sender)).BackColor;
            ((Label)(sender)).BackColor = backColor2;
        }
        private void labSend_MouseHover(object sender, EventArgs e)
        {
            //backColor1 = ((Label)(sender)).BackColor;
            ((Label)(sender)).BackColor = backColor2;
        }
        private void labSend_MouseLeave(object sender, EventArgs e)
        {
            ((Label)(sender)).BackColor = backColor1;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{DELETE}");  
        }

        private void label12_Click(object sender, EventArgs e)
        {
            SendKeys.Send("{BKSP}");
        }
    }
}
