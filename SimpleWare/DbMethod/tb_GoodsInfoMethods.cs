using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SimpleWare.ClassInfo;
using System.Data;
using System.Windows.Forms;
using SimpleWare.BaseClass;
namespace SimpleWare.DbMethod
{
    class tb_GoodsInfoMethods
    {
        Dblink dbl = new Dblink();
        Dbconnection dbc = new Dbconnection();

        #region 添加
        public int tb_GoodsInfoAdd(
                tb_GoodsInfo good
                )
        {
            int intFalg = 0;
            try
            {
               /* if (ishaspics)
                {
                    string str_Add = "insert into tb_GoodsInfo(GoodId,GoodName,ItemNO,ModelNO,GoodMaterial,FCreater,FCreateDate,fImage) values( ";
                    str_Add += " '" + good.strGoodsId + "','" + good.strGoodsName + "',";
                    str_Add += " '" + good.strItemNO + "',";
                    str_Add += " '" + good.strModelNO + "','" + good.strGoodMaterial + "','" + good.strFCreater + "','" + good.dFCreateDate + "',@img )";
                    intFalg = dbc.ExeInfochange(str_Add, "@img", good.image);
                }
                else
                {
                */
                string str_Add = "insert into tb_GoodsInfo(GoodId,GoodName,ItemNO,ModelNO,GoodMaterial,FCreater,FCreateDate,FImagePath) values( ";
                str_Add += " '" + good.strGoodsId + "','" + good.strGoodsName + "',";
                str_Add += " '" + good.strItemNO + "',";
                str_Add += " '" + good.strModelNO + "','" + good.strGoodMaterial + "','" + good.strFCreater + "','" + good.dFCreateDate + "','" + good.strFImagePath + "')";;
                //str_Add += " '" + good.strFColor + "','" + good.strFTypeSteps1 + "','" + good.strFTypeSteps2 + "','" + good.strFTypeSteps3 + "','" + good.strFColorSteps + "'," + good.iFIsStop+ 
                string sql = "select Count(1) from tb_GoodsInfo where GoodId='" + good.strGoodsId + "'";
                //SqlCommand cmd1 = new SqlCommand(sql, conn);
                int count = dbc.ExecuteSelect(sql);
                if (count > 0)
                {
                    MessageUtil.ShowError("产品编号已存在!");
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
        public int tb_goodUpdate(tb_GoodsInfo good)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update tb_GoodsInfo set ";
                str_Update += "GoodId='" + good.strGoodsId + "', ";
                str_Update += "Goodname='" + good.strGoodsName + "',";
                str_Update += "ItemNO='" + good.strItemNO + "',";
                str_Update += "ModelNO= '" + good.strModelNO + "',GoodMaterial='" + good.strGoodMaterial + "',FImagePath ='"+good.strFImagePath+"'";
                str_Update += " where  GoodId='" + good.strGoodsId + "'";

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
        public int tb_goodUpdate(tb_GoodsInfo good,string goodid)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update tb_GoodsInfo set ";
                str_Update += "GoodId='" + good.strGoodsId + "', ";
                str_Update += "Goodname='" + good.strGoodsName + "',";
                str_Update += "ItemNO='" + good.strItemNO + "',";
                str_Update += "ModelNO= '" + good.strModelNO + "',GoodMaterial='" + good.strGoodMaterial + "',FImagePath ='" + good.strFImagePath + "'";
                str_Update += " where  GoodId='" + goodid + "'";

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
        public int tb_goodDelete(string goodid)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "delete from  tb_GoodsInfo   where  GoodId='" + goodid + "'";

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
        public tb_GoodsInfo Find(string _goodsname)
        {
            tb_GoodsInfo goods = new tb_GoodsInfo();
            string sql = "select GoodId,GoodName,ItemNO,ModelNO,GoodMaterial,FImagePath from tb_GoodsInfo where GoodName ='" + _goodsname + "'";
            DataSet ds = dbl.GetDataset(sql);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            goods.strGoodsId = ds.Tables[0].Rows[i][0].ToString();
                            goods.strGoodsName = ds.Tables[0].Rows[i][1].ToString();
                            goods.strItemNO = ds.Tables[0].Rows[i][2].ToString();
                            goods.strModelNO = ds.Tables[0].Rows[i][3].ToString();
                            goods.strGoodMaterial = ds.Tables[0].Rows[i][4].ToString();
                            goods.strFImagePath = ds.Tables[0].Rows[i][5].ToString();
                        }
                    }
                }
            }
            return goods;
        }
    }
}
