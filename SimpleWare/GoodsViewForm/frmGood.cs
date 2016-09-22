using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using SimpleWare.BaseClass;
using SimpleWare.DbMethod;
namespace SimpleWare
{
    public partial class frmGood : Office2007Form
    {
        DataSet ds = null;
        Dblink dbl = new Dblink();
        Object dataSource = null;
        object context = null;
        tb_GoodsInfoMethods goodmethod = new tb_GoodsInfoMethods();
        private BindingManagerBase _Bm;
        internal BindingManagerBase Bm
        {
            get { return (_Bm); }

            set
            {
                if (_Bm != null)
                    _Bm.PositionChanged -= BmPositionChanged;

                _Bm = value;

                if (_Bm != null)
                    _Bm.PositionChanged += BmPositionChanged;
            }

        }
        void BmPositionChanged(object sender, EventArgs e)
        {
            //toolbar1.btnedit.Enabled = true;
            //toolbar1.btndelete.Enabled = true;
            /*if (ds != null)
            {
                context = ds.Tables[0];
                UpdateBindings(context);

            }
             * */
        }
        public frmGood()
        {
            InitializeComponent();
        }

        private void frmGood_Load(object sender, EventArgs e)
        {
            FreshGoods();

        }
        private void FreshGoods()
        {

            string sql = "select  GoodId,GoodName,ItemNO,ModelNO,FImagePath from tb_GoodsInfo order by FCreateDate desc,GoodName asc";
            ds = dbl.GetDataset(sql, "tb_GoodsInfo");
            if (ds != null)
            {
                dataSource = ds.Tables[0];
                context = dataSource;
                //dataMember = ((DataTable)dataSource).DefaultView;
                superGridControl1.PrimaryGrid.DataSource = ds;
                superGridControl1.PrimaryGrid.DataMember = "tb_GoodsInfo";
                Bm = (dataSource != null)
                         ? superGridControl1.BindingContext[context]
                         : null;
                UpdateBindings(context);
            }
            else
            {
                superGridControl1.PrimaryGrid.DataSource = null;
            }
        }
        private void UpdateBindings(object context)
        {
            tbgoodid.DataBindings.Clear();
            tbgoodsname.DataBindings.Clear();
            if (context != null)
            {
                tbgoodid.DataBindings.Add(new Binding("Text", context, "GoodId"));
                tbgoodsname.DataBindings.Add(new Binding("Text", context, "GoodName"));

                tbitemno.DataBindings.Add(new Binding("Text", context, "ItemNO"));
                tbmodelno.DataBindings.Add(new Binding("Text", context, "ModelNO"));
                //cbmaterial.DataBindings.Add(new Binding("Text", context, "GoodMaterial"));
                pictureBox1.DataBindings.Add(new Binding("ImageLocation", context, "FImagePath"));

            }
            else
            {
                tbgoodid.Text = "";
                tbgoodsname.Text = "";
                tbitemno.Text = "";
                tbmodelno.Text = "";
                //cbmaterial.Text = "";

                pictureBox1.Image = null;

            }

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            if (MessageUtil.ConfirmYesNo("确定要删除这条记录吗？"))
            {
                if (Bm != null)
                {
                    if (Bm.Position >= 0)
                    {
                        int index = Math.Max(0, Bm.Position);
                        //DataSet dataSet =supergrid.PrimaryGrid.DataSource as DataSet;

                        if (ds != null)
                        {
                            DataTable table = ds.Tables[0];
                            goodmethod.tb_goodDelete(table.Rows[index]["GoodId"].ToString());
                            table.Rows.RemoveAt(index);

                            ds.AcceptChanges();

                            superGridControl1.PrimaryGrid.PurgeDeletedRows(true);
                        }


                    }
                }
            }
        }
    }
}
