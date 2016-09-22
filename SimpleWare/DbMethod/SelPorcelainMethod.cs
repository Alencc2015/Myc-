using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWare.ClassInfo;
using System.Windows.Forms;
using System.Data;
namespace SimpleWare.DbMethod
{
    class SelPorcelainMethod
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader qlddr = null;
        Dbconnection dbl = new Dbconnection();
        Dblink dblink = new Dblink();
        #region 添加
        public int SelPorcelainADD(tb_SelPorcelain sp)
        {
            int intFalg = 0;
            try
            {
                string str_Add = @"INSERT INTO [dbo].[SelPorceLain] (  
                                     [PlApplyDate]  
                                     ,[PlApplytime]
                                     ,[PLOperatorID]  
                                     ,[PlOperator]  
                                     ,[PlSerialNum]  
                                     ,[PlWorkNumID]  
                                     ,[PlGoodsID]  
                                     ,[PlGoodsName]  
                                     ,[PlKilnNo]  
                                     ,[PlColor]  
                                     ,[PlWorkshopId]  
                                     ,[PlNeedGlazed]  
                                     ,[PlModelFaults]
                                     ,[PlModelFaultsID ] 
                                     ,[PlGlazeFaults]  
                                     ,[PlFireFaults]  
                                     ,[PlLevels]  
                                     ,[FTypeSteps1] 
                                     ,[FTypeSteps2] 
                                     ,[FTypeSteps3] 
                                     ,[FColorSteps] 
                                     ,[PlQty]  
                                     ,[PlThisQty]
                                     ,PlModelNo
                                     ,[FImagePath],
                                     fMaterial)  
                                  VALUES (  ";
                
                    str_Add  +=   "'"+sp.dPlApplyDate+"',"+
                                   " '" + sp.strPlApplytime + "'," +
                                   " '"+sp.strPlOperatorID+"',"+
                                   " '"+sp.strPlOperator+"',"+
                                   " '"+sp.strPlSerialNum+"',"+
                                   " '"+sp.strPlWorkNumID+"',"+
                                   " '"+sp.strPlGoodsID+"',"+
                                   " '"+sp.strPlGoodsName+"',"+
                                   " '"+sp.strPlKilnNo+"',"+
                                   " '"+sp.strPlColor+"',"+
                                   " '"+sp.strPlWorkshopId+"',"+
                                   " "+sp.iPlNeedGlazed+","+
                                   " '"+sp.strPlModelFaults+"',"+
                                  " '" + sp.strPlModelFaultsID + "'," +
                                   " '"+sp.strPlGlazeFaults+"',"+
                                   " '"+sp.strPlFireFaults+"',"+
                                   " '"+sp.strPlLevels+"',"+
                                   " '" + sp.strFTypeSteps1 + "'," +
                                   " '" + sp.strFTypeSteps2 + "'," +
                                   " '" + sp.strFTypeSteps3 + "'," +
                                   " '" + sp.strFColorSteps + "'," +
                                   " "+sp.iPlQty+","+
                                   ""+sp.iPlThisQty+","+
                                    " '" + sp.strPlModelNo + "'," +
                                   "'"+sp.strFImagePath+"',"+
                                    "'"+sp.FMaterial+"')";
                intFalg = dbl.ExeInfochange(str_Add);
                return intFalg;


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return intFalg;

            }

        }
        #endregion
        #region 修改
        public int SelPorcelainUpdate(tb_SelPorcelain sp)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "UPdate  [dbo].[SelPorceLain] set  " + 
                                    "[PlApplyDate] = '"+sp.dPlApplyDate+"' "+
                                    ",[PlApplytime] = '" + sp.strPlApplytime + "' " +
                                    ",[PLOperatorID] = '"+sp.strPlOperatorID+"' "+
                                    ",[PlOperator] = '"+sp.strPlOperator+"' "+
                                    ",[PlWorkNumID] = '"+sp.strPlWorkNumID+"' "+
                                    ",[PlGoodsID] = '"+sp.strPlGoodsID+"'"+
                                    ",[PlGoodsName] = '"+sp.strPlGoodsName +"' "+
                                    ",[PlModelNo] = '" + sp.strPlModelNo + "' " +
                                    ",[PlKilnNo] = '"+sp.strPlKilnNo+"' "+
                                    ",[PlColor] = '"+sp.strPlColor+"' "+
                                    ",[PlWorkshopId] = '"+sp.strPlWorkshopId +"' "+
                                    ",[PlNeedGlazed] =  "+sp.iPlNeedGlazed+" "+
                                    ",[PlModelFaults] = '"+sp.strPlModelFaults+"' " +
                                    ",[PlModelFaultsID] = '" + sp.strPlModelFaultsID + "' " +
                                    ",[PlGlazeFaults] = '"+sp.strPlGlazeFaults+ "' "+
                                    ",[PlFireFaults]  = '"+sp.strPlFireFaults +"' "+
                                    ",[PlLevels]  = '"+sp.strPlLevels +"' "+
                                    ",[FTypeSteps1]  = '" + sp.strFTypeSteps1 + "' " +
                                    ",[FTypeSteps2]  = '" + sp.strFTypeSteps2 + "' " +
                                    ",[FTypeSteps3]  = '" + sp.strFTypeSteps3 + "' " +
                                    ",[FColorSteps]  = '" + sp.strFColorSteps + "' " +
                                    ",[PlQty]  =  "+sp.iPlQty +" "+
                                    ",[PlThisQty] = " + sp.iPlThisQty + "  " +
                                    ",fMaterial = '"+sp.FMaterial+"' "+
                                    " where PlSerialNum = '"+sp.strPlSerialNum +"' ";

                intFalg = dbl.ExeInfochange(str_Update);
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
        public int SelPorcelainDelete(string _id)
        {
            int intFalg = 0;
            try
            {

                string str_Delete = "Delete from  SelPorcelain where PlSerialNum = '" + _id + "'";

                intFalg = dbl.ExeInfochange(str_Delete);

                return intFalg;


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return intFalg;

            }

        }
        #endregion

        #region 批量删除
        public int SelPorcelainDeleteIDs(string _ids)
        {
            int intFalg = 0;
            try
            {

                string str_Delete = "Delete from  SelPorcelain where PlSerialNum in (" + _ids + ")";

                intFalg = dbl.ExeInfochange(str_Delete);

                return intFalg;


            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return intFalg;

            }

        }
        #endregion


        #region //生成流水号 例如：KH-20071118114255
        public string SelPorceLainSerialNum()
        {
            int intYear = DateTime.Now.Year;
            int intMonth = DateTime.Now.Month;
            int intDate = DateTime.Now.Day;
            int intHour = DateTime.Now.Hour;
            int intSecond = DateTime.Now.Second;
            int intMinute = DateTime.Now.Minute;
            string strTime = null;
            strTime += "SP-";
            strTime += intYear.ToString();
            strTime += intMonth < 10 ? "0" + intMonth.ToString() : intMonth.ToString();
            string selnum = "SELECT top 1 RIGHT(PlSerialNum,6) FROM SelPorcelain where  LEFT(PlSerialNum,9)='" + strTime + "' order by PlSerialNum desc";
            //getSqlConnection getConnection = new getSqlConnection();
            conn = Dbconnection.Dblink();
            conn.Open();
            cmd = new SqlCommand(selnum, conn);
            int maxNum = 1;
            string strMaxnum = "";
            qlddr = cmd.ExecuteReader();
            if (qlddr.Read())
            {
                maxNum = Convert.ToInt32(qlddr.GetString(0)) + 1;
            }
            if (maxNum > 0 && maxNum < 10)
            {
                strMaxnum = "00000" + maxNum;
            }
            else if (maxNum >= 10 && maxNum < 100)
            {
                strMaxnum = "0000" + maxNum;
            }
            else if (maxNum >= 100 && maxNum < 1000)
            {
                strMaxnum = "000" + maxNum;
            }
            else if (maxNum >= 1000 && maxNum < 10000)
            {
                strMaxnum = "00" + maxNum;
            }
            else if (maxNum >= 10000 && maxNum < 100000)
            {
                strMaxnum = "0" + maxNum;
            }
            else
            {
                strMaxnum = Convert.ToString(maxNum);
            }
            qlddr.Close();

             return (strTime + strMaxnum);



        }
        public int getThisworknumSumQty(string usercode)
        {
            int qty = 0;

            string selnum = "select isnull(sum(PlQty),0) as PlQty from SelPorceLain where  PlApplyDate='" + System.DateTime.Today + "' and PLOperatorID = '" + usercode + "'";
            //getSqlConnection getConnection = new getSqlConnection();
            DataSet ds = dblink.GetDataset(selnum);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        qty = Convert.ToInt32(Convert.ToInt32(ds.Tables[0].Rows[0]["PlQty"].ToString()));
                    }
                }
            }

            return qty;
        }
        #endregion

    }
}
