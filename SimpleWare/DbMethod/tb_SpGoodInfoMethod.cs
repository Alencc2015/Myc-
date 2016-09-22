using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleWare.ClassInfo;
using System.Windows.Forms;
using System.Data;
using SimpleWare.BaseClass;
namespace SimpleWare.DbMethod
{
    class tb_SpGoodInfoMethod
    {
        Dblink dbl = new Dblink();
        Dbconnection dbc = new Dbconnection();
        DataSet ds = new DataSet();
        #region 添加
        public int tb_SpGoodsInfoAdd(
                tb_SpGoodsInfo good
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
                string str_Add = "insert into tb_SpGoodsInfo(GoodId,GoodName,ItemNO,ModelNO,GoodMaterial,FCreater,FCreateDate,FImagePath,FColor,FTypeSteps1,FTypeSteps2,FTypeSteps3,FColorSteps,FIsStop,FMaterialQty) values( ";
                str_Add += " '" + good.strGoodsId + "','" + good.strGoodsName + "',";
                str_Add += " '" + good.strItemNO + "',";
                str_Add += " '" + good.strModelNO + "','" + good.strGoodMaterial + "','" + good.strFCreater + "','" + good.dFCreateDate + "','" + good.strFImagePath + "',";
                str_Add += " '" + good.strFColor + "','" + good.strFTypeSteps1 + "','" + good.strFTypeSteps2 + "','" + good.strFTypeSteps3 + "','" + good.strFColorSteps + "'," + good.iFIsStop + ",'" + good.strFMaterialQty + "')";
                string sql = "select Count(1) from tb_SpGoodsInfo where GoodId='" + good.strGoodsId + "'";
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
                MessageUtil.ShowError("新增失败!");
                return intFalg;

            }

        }
        #endregion
        #region 修改
        public int tb_SpgoodUpdate(tb_SpGoodsInfo good)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update tb_SpGoodsInfo set ";
                str_Update += "GoodId='" + good.strGoodsId + "', ";
                str_Update += "Goodname='" + good.strGoodsName + "',";
                str_Update += "ItemNO='" + good.strItemNO + "',";
                str_Update += "ModelNO= '" + good.strModelNO + "',GoodMaterial='" + good.strGoodMaterial + "',FImagePath ='" + good.strFImagePath + "',";
                str_Update += "FColor= '" + good.strFColor + "',FTypeSteps1='" + good.strFTypeSteps1 + "',FTypeSteps2 ='" + good.strFTypeSteps2 + "',";
                str_Update += "FTypeSteps3= '" + good.strFTypeSteps3 + "',FColorSteps='" + good.strFColor + "',FIsStop =" + good.iFIsStop + ",FMaterialQty = '" + good.strFMaterialQty + "'";
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
        public int tb_SpgoodUpdate(tb_SpGoodsInfo good,string goodid)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update tb_SpGoodsInfo set ";
                str_Update += "GoodId='" + good.strGoodsId + "', ";
                str_Update += "Goodname='" + good.strGoodsName + "',";
                str_Update += "ItemNO='" + good.strItemNO + "',";
                str_Update += "ModelNO= '" + good.strModelNO + "',GoodMaterial='" + good.strGoodMaterial + "',FImagePath ='" + good.strFImagePath + "',";
                str_Update += "FColor= '" + good.strFColor + "',FTypeSteps1='" + good.strFTypeSteps1 + "',FTypeSteps2 ='" + good.strFTypeSteps2 + "',";
                str_Update += "FTypeSteps3= '" + good.strFTypeSteps3 + "',FColorSteps='" + good.strFColor + "',FIsStop =" + good.iFIsStop + ",FMaterialQty = '" + good.strFMaterialQty + "'";
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
        public int tb_SpgoodDelete(string goodid)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "delete from  tb_SpGoodsInfo   where  GoodId='" + goodid + "'";

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
        public tb_SpGoodsInfo Find(string _goodsname)
        {
            tb_SpGoodsInfo goods = new tb_SpGoodsInfo();
            string sql = "select GoodId,GoodName,ItemNO,ModelNO,GoodMaterial,FImagePath,FColor,FMaterialQty from tb_SpGoodsInfo where GoodName ='" + _goodsname + "'";
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
                            goods.strFColor = ds.Tables[0].Rows[i][6].ToString();
                        }
                    }
                }
            }
            return goods;
        }
        public tb_SpGoodsInfo FindByID(string _goodid)
        {
            tb_SpGoodsInfo goods = new tb_SpGoodsInfo();
            string sql = "select GoodId,GoodName,ItemNO,ModelNO,GoodMaterial,FImagePath,FColor from tb_SpGoodsInfo where GoodId ='" + _goodid + "'";
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
                            goods.strFColor = ds.Tables[0].Rows[i][6].ToString();
                        }
                    }
                }
            }
            return goods;
        }      
    }
}
