using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleWare.ClassInfo;
using System.Windows.Forms;
using System.Data;
using SimpleWare.BaseClass;
using System.Data.SqlClient;
using System.Configuration;
namespace SimpleWare.DbMethod
{
    class tb_ModelInfoMethod
    {
        Dblink dbl = new Dblink();
        Dbconnection dbc = new Dbconnection();

        #region 添加
        public int tb_ModelInfoAdd(
                tb_ModelInfo good
                )
        {
            int intFalg = 0;
            try
            {
                string str_Add = @"INSERT INTO [dbo].[tb_ModelInfo]
                                   ([ModelNo]
                                   ,[ModelName]
                                   ,[FCreater]
                                   ,[FCreateDate]
                                   ,[FModifier]
                                   ,[FModifydate]
                                   ,[FImagePath]
                                   ,[FTypeSteps1]
                                   ,[FTypeSteps2]
                                   ,[FTypeSteps3]
                                   ,[FIsStop]
                                   ,FMaterialQty)
                             VALUES (";
                str_Add += " '" + good.strModelNo + "','" + good.strModelName + "',";
                str_Add += " '" + good.strFCreater + "',";
                str_Add += " '" + good.dFCreateDate + "','" + good.strFModifier + "','" + good.dFModifydate + "','" + good.strFImagePath + "',";
                str_Add += "'" + good.strFTypeSteps1 + "','" + good.strFTypeSteps2 + "','" + good.strFTypeSteps3 + "'," + good.iFIsStop + ",'" + good.strFMaterialQty + "')";
                string sql = "select Count(1) from tb_ModelInfo where ModelNo='" + good.strModelNo + "'";
                //SqlCommand cmd1 = new SqlCommand(sql, conn);
                int count = dbc.ExecuteSelect(sql);
                if (count > 0)
                {
                    MessageUtil.ShowError("器型编号已存在!");
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
        public int tb_ModelUpdate(tb_ModelInfo good)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update tb_ModelInfo set ";
                str_Update += "ModelNo='" + good.strModelNo + "', ";
                str_Update += "ModelName='" + good.strModelName + "',";
                str_Update += "FModifier='" + good.strFModifier + "',";
                str_Update += "FModifydate= '" + good.dFModifydate + "',FImagePath ='" + good.strFImagePath + "',";
                str_Update += "FTypeSteps1='" + good.strFTypeSteps1 + "',FTypeSteps2 ='" + good.strFTypeSteps2 + "',";
                str_Update += "FTypeSteps3= '" + good.strFTypeSteps3 + "',FIsStop =" + good.iFIsStop + " ,FMaterialQty= '" + good.strFMaterialQty + "'";
                str_Update += " where  ModelNo='" + good.strModelNo + "'";

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
        public int tb_ModelUpdate(tb_ModelInfo good,string modelno)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update tb_ModelInfo set ";
                str_Update += "ModelNo='" + good.strModelNo + "', ";
                str_Update += "ModelName='" + good.strModelName + "',";
                str_Update += "FModifier='" + good.strFModifier + "',";
                str_Update += "FModifydate= '" + good.dFModifydate + "',FImagePath ='" + good.strFImagePath + "',";
                str_Update += "FTypeSteps1='" + good.strFTypeSteps1 + "',FTypeSteps2 ='" + good.strFTypeSteps2 + "',";
                str_Update += "FTypeSteps3= '" + good.strFTypeSteps3 + "',FIsStop =" + good.iFIsStop + " ,FMaterialQty= '" + good.strFMaterialQty + "'";
                str_Update += " where  ModelNo='" + modelno + "'";

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
        public int tb_ModelDelete(string goodid)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "delete from  tb_ModelInfo   where  ModelNo='" + goodid + "'";

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
        public tb_ModelInfo Find(string _Modelsname)
        {
            tb_ModelInfo goods = new tb_ModelInfo();
            string sql = "select ModelNo,ModelName,FTypeSteps1,FTypeSteps2,FTypeSteps3,FImagePath,FMaterialQty from tb_ModelInfo where ModelName ='" + _Modelsname + "' and FIsStop = 0";
            DataSet ds = dbl.GetDataset(sql);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            goods.strModelNo = ds.Tables[0].Rows[i][0].ToString();
                            goods.strModelName = ds.Tables[0].Rows[i][1].ToString();
                            goods.strFTypeSteps1 = ds.Tables[0].Rows[i][2].ToString();
                            goods.strFTypeSteps2 = ds.Tables[0].Rows[i][3].ToString();
                            goods.strFTypeSteps3 = ds.Tables[0].Rows[i][4].ToString();
                            goods.strFImagePath = ds.Tables[0].Rows[i][5].ToString();
                            goods.strFMaterialQty = ds.Tables[0].Rows[i][6].ToString();
                            //goods.strFImagePath = ds.Tables[0].Rows[i][5].ToString();
                        }
                    }
                }
            }
            return goods;
        }
        public tb_ModelInfo FindByID(string _modelId)
        {
            tb_ModelInfo goods = new tb_ModelInfo();
            string sql = "select ModelNo,ModelName,FTypeSteps1,FTypeSteps2,FTypeSteps3,FImagePath,FMaterialQty from tb_ModelInfo where ModelNo ='" + _modelId + "' and FIsStop = 0";
            DataSet ds = dbl.GetDataset(sql);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            goods.strModelNo = ds.Tables[0].Rows[i][0].ToString();
                            goods.strModelName = ds.Tables[0].Rows[i][1].ToString();
                            goods.strFTypeSteps1 = ds.Tables[0].Rows[i][2].ToString();
                            goods.strFTypeSteps2 = ds.Tables[0].Rows[i][3].ToString();
                            goods.strFTypeSteps3 = ds.Tables[0].Rows[i][4].ToString();
                            goods.strFImagePath = ds.Tables[0].Rows[i][5].ToString();
                            goods.strFMaterialQty = ds.Tables[0].Rows[i][6].ToString();
                            //goods.strFImagePath = ds.Tables[0].Rows[i][5].ToString();
                        }
                    }
                }
            }
            return goods;
        }

        public static Boolean exists(string _Modelsname)
        {
            Boolean result = false;
            string sql = "select ModelNo,ModelName from tb_ModelInfo where ModelName ='" + _Modelsname + "' and FIsStop = 0";
            DataSet ds = new DataSet();
            //string strConn = @"server=.\sql2005d;database =Library;integrated security=true";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string strConn = config.AppSettings.Settings["connectionstring"].Value;
            SqlConnection conn = new SqlConnection(strConn);
            SqlCommand command = new SqlCommand(sql, conn);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = command;
            adapter.Fill(ds);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        result = true;
                    }
                }
            }
            return result;
        }
    }
}
