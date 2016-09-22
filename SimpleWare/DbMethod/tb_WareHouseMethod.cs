using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWare.ClassInfo;
using System.Windows.Forms;
using System.Data;
using SimpleWare.BaseClass;
namespace SimpleWare.DbMethod
{
    class tb_WareHouseMethod
    {
        Dblink dbl = new Dblink();
        Dbconnection dbc = new Dbconnection();

        #region 添加
        public int tb_WareHouseAdd(tb_WareHouse good)
        {
            int intFalg = 0;
            try
            {
                string str_Add = "insert into tb_WareHouse(WareID,WareName,Remark) values( ";
                str_Add += " '" + good.strWareID + "','" + good.strWareName + "','" + good.strRemark + "')";
                string sql = "select Count(1) from tb_WareHouse where WareID='" + good.strWareID + "'";
                //SqlCommand cmd1 = new SqlCommand(sql, conn);
                int count = dbc.ExecuteSelect(sql);
                if (count > 0)
                {
                    MessageUtil.ShowError("仓库编号已存在!");
                    return 0;
                }
                else
                {
                    intFalg = dbc.ExeInfochange(str_Add);
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
        public int tb_WareHouseUpdate(tb_WareHouse ware)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update tb_WareHouse set ";
                str_Update += "WareName='" + ware.strWareName + "',";
                str_Update += "Remark='" + ware.strRemark + "'";
                str_Update += "where WareID = '"+ware.strWareID+"'";

                intFalg = dbc.ExeInfochange(str_Update);
                // conn.Dispose();
                return intFalg;


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return intFalg;

            }

        }
        #endregion
        #region 删除
        public int tb_WareHouseDelete(string wareid)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "delete from  tb_WareHouse   where  WareID='" + wareid + "'";

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
        public tb_WareHouse Find(string _id)
        {
            tb_WareHouse goods = new tb_WareHouse();
            string sql = "select WareID,WareName,Remark from tb_WareHouse where WareID ='" + _id + "'";
            DataSet ds = dbl.GetDataset(sql);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            goods.strWareID = ds.Tables[0].Rows[i][0].ToString();
                            goods.strWareName = ds.Tables[0].Rows[i][1].ToString();
                            goods.strRemark = ds.Tables[0].Rows[i][2].ToString();
                        }
                    }
                }
            }
            return goods;
        }
    }
}
