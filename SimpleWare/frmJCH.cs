using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWare.ClassInfo;
using SimpleWare.DbMethod;
using System.Data.SqlClient;
using DevComponents.DotNetBar;
namespace SimpleWare
{
    public partial class frmJCH : Office2007Form
    {
        public frmJCH()
        {
            InitializeComponent();
        }
        tb_JCH JCH = new tb_JCH();
        tb_JCHMethod JCHMethod = new tb_JCHMethod();
        SqlConnection conn = null;
        Dblink dbl = new Dblink();
        DataSet ds = new DataSet();
        Dbconnection dbc = new Dbconnection();
        private void textBox4_Enter(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.Start("osk.exe");        //调用系统软键盘 
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            //System.Diagnostics.Process.
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            JCH.strJCOperator = lblusername.Text;
            JCH.dJCDate = System.DateTime.Now;
            JCH.strJCWorknum = cmbWorknum.Text;
            JCH.strJCWareID = tbWare.Text;
            JCH.strJCCarNO = tbCarno.Text;
            JCH.intJCTYPE = cbtype.SelectedIndex;
            string serialNum = JCHMethod.tb_JCSerialNum(cbtype.SelectedIndex);
            label16.Text = serialNum;
            JCH.strJCSerialNum = serialNum;
            JCH.strJCGoodsID = tbgoodsid.Text;
            JCH.dJCHGSL = Convert.ToInt16(tbhgsl.Text);
            JCH.dJCKLSL = Convert.ToInt16(tbklsl.Text);
            JCH.dJCPSSL = Convert.ToInt16(tbpssl.Text);
            JCH.dJCKHSL = Convert.ToInt16(tbkhsl.Text);
            JCHMethod.tb_JCHADD(JCH);
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {

        }

        private void frmJCH_Load(object sender, EventArgs e)
        {
           // label16.Text = frmLogin.userName;
            lblusername.Text = frmLogin1.userName;
            lbldate.Text = System.DateTime.Now.ToShortDateString();

        }

        private void tbklsl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar))&& e.KeyChar !=(char)8)
            {
                e.Handled = true;
            }
        }

        private void tbgoodsid_TextChanged(object sender, EventArgs e)
        {
           /* List<string> listArr = new List<string>();
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //this.lbgoods.Visible = true;
                    //this.lbgoods.Items.Clear();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        listArr.Add(ds.Tables[0].Rows[i][1].ToString());
                    }
                }
            }
            //string[] myarr = listArr.ToArray();
            //tbgoodsid.AutoCompleteCustomSource.AddRange(myarr);
            //tbgoodsid.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //tbgoodsid.AutoCompleteMode = AutoCompleteMode.SuggestAppend; 
           */ //DataBase db = new DataBase();//自己写的类
            string sql = "select GoodId,GoodName from tb_GoodsInfo where GoodId like " + "'%" + this.tbgoodsid.Text + "%'";
            ds = dbl.GetDatasetReport(sql, "tb_GoodsInfo");
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.lbgoods.Visible = true;
                    this.lbgoods.Items.Clear();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        this.lbgoods.Items.Add(ds.Tables[0].Rows[i][1].ToString());
                    }
                }
            }
        }

        private void lbgoods_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.lbgoods.SelectedItems.Count > 0)
            {
                this.tbgoodsid.Text = this.lbgoods.SelectedItem.ToString();
            }
        }

        private void lbgoods_Leave(object sender, EventArgs e)
        {
            this.lbgoods.Visible = false;
        }

        private void tbgoodsearch_TextChanged(object sender, EventArgs e)
        {
            string sql = "select GoodId,GoodName from tb_GoodsInfo where GoodId like " + "'%" + this.tbgoodsearch.Text + "%'";
            ds = dbl.GetDatasetReport(sql, "tb_GoodsInfo");
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    this.lbgoodssearch.Visible = true;
                    this.lbgoodssearch.Items.Clear();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        this.lbgoodssearch.Items.Add(ds.Tables[0].Rows[i][1].ToString());
                    }
                }
            }
        }

        private void lbgoodssearch_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.lbgoodssearch.SelectedItems.Count > 0)
            {
                this.tbgoodsearch.Text = this.lbgoodssearch.SelectedItem.ToString();
            }
        }

        private void lbgoodssearch_Leave(object sender, EventArgs e)
        {
            this.lbgoodssearch.Visible = false;
        }

        private void dgvlist_DoubleClick(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = tpdetail;
            FillControls();

        }
        public void FillControls()
        {
            try
            {
                string sql = "select JCDate,JCWorknum,JCOperator,JCWareID,JCGoodsID,JCHGSL,JCPSSL,JCKLSL,JCKHSL,JCCarNO,JCTYPE,JCSerialNum,JCGoodsName "+
                             " from tb_jch where JCSerialNum = '" + this.dgvlist[0, this.dgvlist.CurrentCell.RowIndex].Value.ToString() + "'";
                SqlDataReader sqldr = dbc.dr(sql);

                sqldr.Read();
                if (sqldr.HasRows)
                {
                    tbdate.Text                 = sqldr[0].ToString();
                    cmbWorknum.SelectedText     = sqldr[1].ToString();
                    tboperator.Text             = sqldr[2].ToString();
                    tbWare.Text                 = sqldr[3].ToString();

                    tbhgsl.Text                 = sqldr[5].ToString();
                    tbpssl.Text                 = sqldr[6].ToString();
                    tbklsl.Text                 = sqldr[7].ToString();
                    tbkhsl.Text                 = sqldr[8].ToString();
                    tbCarno.Text                = sqldr[9].ToString();
                    cbtype.SelectedText         = sqldr[10].ToString();
                    label16.Text                = sqldr[11].ToString();
 
                }
                sqldr.Close();

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());

            }

        }
        private void dgvlist_SelectionChanged(object sender, EventArgs e)
        {
            ///
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sql = "select JCDate as 日期,JCTYPE as 类型,JCGoodsName as 产品名称,JCWareID as 仓位,JCHGSL as 合格数量,JCKLSL as 开裂数量,JCPSSL as 碰损数量,"+
                        " JCKHSL as 过火数量,JCCarNO as 窑车号, JCWorknum as 班次,JCOperator as 操作员,JCSerialNum as 流水号 " +
                         " from tb_jch where 1=1 ";
            if (dtdate.Text != "")
            {
                sql += "and JCDate = '" + dtdate.Value.Date.ToShortDateString()+"'";
            }
            if (cbtypesearch.Text == "入窑")
            {
                sql += "and JCTYPE = 0";
            }
            if (cbtypesearch.Text == "出窑")
            {
                sql += "and JCTYPE = 1";
            }
            if (tbgoodsearch.Text.Trim() != "")
            {
                sql += "and JCGoodsName = '" + tbgoodsearch.Text.Trim()+ "'";
            }
            dgvlist.AutoGenerateColumns = false;
            dgvlist.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dbl.InfoShow(sql, dgvlist);
            //dgvlist
        }


    }
}
