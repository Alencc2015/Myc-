using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWare.ClassInfo;
using System.Windows.Forms;
using System.Data;
using DevComponents.DotNetBar.Controls;
using SimpleWare.BaseClass;
namespace SimpleWare.DbMethod
{
    class tb_BaseMgr
    {
        Dblink dbl = new Dblink();
        Dbconnection dbc = new Dbconnection();

        #region 添加
        public int tb_BaseAdd(
                tb_Base good
                )
        {
            int intFalg = 0;
            try
            {
                /* if (ishaspics)
                 {
                     string str_Add = "insert into tb_BaseInfo(GoodId,GoodName,ItemNO,ModelNO,GoodMaterial,FCreater,FCreateDate,fImage) values( ";
                     str_Add += " '" + good.strGoodsId + "','" + good.strGoodsName + "',";
                     str_Add += " '" + good.strItemNO + "',";
                     str_Add += " '" + good.strModelNO + "','" + good.strGoodMaterial + "','" + good.strFCreater + "','" + good.dFCreateDate + "',@img )";
                     intFalg = dbc.ExeInfochange(str_Add, "@img", good.image);
                 }
                 else
                 {
                 */
                string str_Add = "insert into tb_Base(FClass,FBaseID,FBaseName,FRemark) values( ";
                str_Add += " '" + good.strFClass + "','" + good.strFBaseID + "',";
                str_Add += " '" + good.strFBaseName + "',";
                str_Add += " '" + good.strFRemark+"')";
                string sql = "select Count(1) from tb_Base where FBaseID='" + good.strFBaseID + "'";
                //SqlCommand cmd1 = new SqlCommand(sql, conn);
                int count = dbc.ExecuteSelect(sql);
                if (count > 0)
                {
                    MessageUtil.ShowError("编号已存在!");
                    return 0;
                }
                else
                {
                    intFalg = dbc.ExeInfochange(str_Add);
                    //}
                    return intFalg;
                }

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return intFalg;

            }

        }
        #endregion
        #region 修改
        public int tb_goodUpdate(tb_Base good)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update tb_Base set ";
                str_Update += "FClass='" + good.strFClass + "', ";
                str_Update += "FBaseName='" + good.strFBaseName + "',";
                str_Update += "FRemark= '" + good.strFRemark + "'";
                str_Update += " where  FBaseID='" + good.strFBaseID + "'";

                intFalg = dbc.ExeInfochange(str_Update);
                return intFalg;
                // conn.Dispose();
                //return intFalg;


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return intFalg;

            }

        }
        #endregion
        #region 删除
        public int tb_baseDelete(string goodid)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "delete from  tb_Base   where  FBaseID='" + goodid + "'";

                intFalg = dbc.ExeInfochange(str_Update);
                //conn.Dispose();
                return intFalg;


            }
            catch (Exception ee)
            {
                return intFalg;

            }

        }
        #endregion
        public tb_Base Find(string _baseid)
        {
            tb_Base goods = new tb_Base();
            string sql = "select FClass,FBaseID,FBaseName,FRemark from tb_Base where FBaseID ='" + _baseid + "'";
            DataSet ds = dbl.GetDataset(sql);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            goods.strFClass = ds.Tables[0].Rows[i][0].ToString();
                            goods.strFBaseID = ds.Tables[0].Rows[i][1].ToString();
                            goods.strFBaseName = ds.Tables[0].Rows[i][2].ToString();
                            goods.strFRemark = ds.Tables[0].Rows[i][3].ToString();
                        }
                    }
                }
            }
            return goods;
        }
        public static void SetCombox(string _class, ComboBoxEx _control)
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select FBaseID,FBaseName from tb_base where FClass =  '" + _class + "' order by FBaseID";
            ds = dbl.GetDatasetReport(sql, "tb_base");
            List<string> listArr = new List<string>();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    _control.DataSource = ds.Tables[0];
                    _control.DisplayMember = "FBaseName";
                    _control.ValueMember = "FBaseID";
                }

            }
        }

    }
}
