using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleWare
{
    public partial class frmRpttest : Form
    {
        public frmRpttest()
        {
            InitializeComponent();
        }

        private void frmRpttest_Load(object sender, EventArgs e)
        {
            // TODO:  这行代码将数据加载到表“SimpleWareDataSet.SelPorceLain”中。您可以根据需要移动或删除它。
            this.SelPorceLainTableAdapter.Fill(this.SimpleWareDataSet.SelPorceLain);

            this.reportViewer1.RefreshReport();
        }
    }
}
