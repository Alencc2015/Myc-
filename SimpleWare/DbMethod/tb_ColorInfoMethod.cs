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
    class tb_ColorInfoMethod
    {
        Dblink dbl = new Dblink();
        Dbconnection dbc = new Dbconnection();

        #region 添加
        public int tb_ColorInfoAdd(
                tb_ColorInfo good
                )
        {
            int intFalg = 0;
            try
            {
                string str_Add = @"INSERT INTO [dbo].[tb_ColorInfo]
                                   ([ColorNo]
                                   ,[ColorName]
                                   ,[FCreater]
                                   ,[FCreateDate]
                                   ,[FModifier]
                                   ,[FModifydate]
                                   ,[FColorSteps]
                                   ,[FIsStop])
                             VALUES(";
                str_Add += " '" + good.strColorNo + "','" + good.strColorName + "',";
                str_Add += " '" + good.strFCreater + "',";
                str_Add += " '" + good.dFCreateDate + "','" + good.strFModifier + "','" + good.dFModifydate + "',";
                str_Add += "'" + good.strFColorSteps +  "'," + good.iFIsStop + ")";
                string sql = "select Count(1) from tb_ColorInfo where ColorNo='" + good.strColorNo + "'";
                //SqlCommand cmd1 = new SqlCommand(sql, conn);
                int count = dbc.ExecuteSelect(sql);
                if (count > 0)
                {
                    MessageUtil.ShowError("花色编号已存在!");
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
        public int tb_ColorUpdate(tb_ColorInfo good)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update tb_ColorInfo set ";
                str_Update += "ColorNo='" + good.strColorNo + "', ";
                str_Update += "ColorName='" + good.strColorName + "',";
                str_Update += "FModifier='" + good.strFModifier + "',";
                str_Update += "FModifydate= '" + good.dFModifydate + "',";
                //str_Update += "FTypeSteps1='" + good.strFTypeSteps1 + "',FTypeSteps2 ='" + good.strFTypeSteps2 + "',";
                str_Update += "FColorSteps= '" + good.strFColorSteps + "',FIsStop =" + good.iFIsStop;
                str_Update += " where  ColorNo='" + good.strColorNo + "'";

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
        public int tb_ColorUpdate(tb_ColorInfo good,string colorno)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update tb_ColorInfo set ";
                str_Update += "ColorNo='" + good.strColorNo + "', ";
                str_Update += "ColorName='" + good.strColorName + "',";
                str_Update += "FModifier='" + good.strFModifier + "',";
                str_Update += "FModifydate= '" + good.dFModifydate + "',";
                //str_Update += "FTypeSteps1='" + good.strFTypeSteps1 + "',FTypeSteps2 ='" + good.strFTypeSteps2 + "',";
                str_Update += "FColorSteps= '" + good.strFColorSteps + "',FIsStop =" + good.iFIsStop;
                str_Update += " where  ColorNo='" + colorno + "'";

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
        public int tb_ColorDelete(string goodid)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "delete from  tb_ColorInfo   where  ColorNo='" + goodid + "'";

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
        public tb_ColorInfo Find(string _colorNO)
        {
            tb_ColorInfo goods = new tb_ColorInfo();
            string sql = "select ColorNo,ColorName,FColorSteps from tb_ColorInfo where ColorNo ='" + _colorNO + "' and FIsStop = 0 ";
            DataSet ds = dbl.GetDataset(sql);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            goods.strColorNo = ds.Tables[0].Rows[i][0].ToString();
                            goods.strColorName = ds.Tables[0].Rows[i][1].ToString();
                            goods.strFColorSteps = ds.Tables[0].Rows[i][2].ToString();
                        }
                    }
                }
            }
            return goods;
        }
    }
}
