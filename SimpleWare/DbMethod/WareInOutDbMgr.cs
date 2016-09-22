using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleWare.ClassInfo;
using System.Windows.Forms;
namespace SimpleWare.DbMethod
{
    class WareInOutDbMgr
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader qlddr = null;
        Dbconnection dbl = new Dbconnection();
        #region 添加
        public int WareInOutADD(WareInOut FH)
        {
            int intFalg = 0;
            try
            {
                string str_Add = "insert into WareInOut(FDate,FWorknum,FOperator,FWareID,FGoodID,FHGSL,FPSSL,FKLSL,FKHSL,FCarNO,FTYPE,FSerialNum,FGoodsName,FModelno,FItemID,FMaterial,FimagePath,FPSL,FInvoiceType) values( ";
                str_Add += " '" + FH.dFDate + "','" + FH.strFWorknum + "',";
                str_Add += " '" + FH.strFOperator + "','" + FH.strFWareID + "','" + FH.strFGoodsID + "',";
                str_Add += FH.dFHGSL + "," + FH.dFPSSL + "," + FH.dFKLSL + "," + FH.dFKHSL + ",'" + FH.strFCarNO + "'," + FH.intFTYPE + ",'" + FH.strFSerialNum + "','" + FH.strFGoodsName + "','" + FH.strFModelno + "','" + FH.strFItemID + "','" + FH.strFMaterial + "','";
                str_Add += FH.strFimagePath + "'," + FH.dFPSL + ",'" + FH.strFInvoiceType+ "')";
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
        public int WareInOutUpdate(WareInOut FH)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update WareInOut set ";
                str_Update += "FDate='" + FH.dFDate + "',";
                str_Update += "FWorknum='" + FH.strFWorknum + "',FOperator='" + FH.strFOperator + "',FWareID='" + FH.strFWareID + "',FGoodID='" + FH.strFGoodsID + "',FMaterial = '"+FH.strFMaterial+"',";
                str_Update += "FHGSL= " + FH.dFHGSL + ",FPSSL=" + FH.dFKHSL + ",FKLSL=" + FH.dFKLSL + ",FKHSL = " + FH.dFKHSL + ",FCarNO='" + FH.strFCarNO + "',FTYPE=" + FH.intFTYPE + ",FPSL = " + FH.dFPSL + ", FInvoiceType='" + FH.strFInvoiceType + "'";
                str_Update += " where  FSerialNum='" + FH.strFSerialNum + "'";

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
        public int WareInOutDelete(string _id)
        {
            int intFalg = 0;
            try
            {

                string str_Delete = "Delete from  WareInOut where FSerialNum = '" + _id + "'";

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


        #region 查询
        public int WareInOutFind(string strObject, string pwwd, int intFalg)
        {
            int intCount = 0;
            string strSecar = null;

            try
            {
                switch (intFalg)
                {
                    case 1:
                        strSecar = "select * from tb_EmpInfo where EmpLoginName= '" + strObject + "' and EmpFalg=0";
                        break;
                    case 2:
                        strSecar = "select * from tb_EmpInfo where EmpLoginName= '" + strObject + "' and EmpFalg=0 and EmpLoginPwd='" + pwwd + "'";
                        break;
                }


                conn = Dbconnection.Dblink();
                conn.Open();
                cmd = new SqlCommand(strSecar, conn);

                qlddr = cmd.ExecuteReader();
                qlddr.Read();
                if (qlddr.HasRows)
                {
                    intCount = 1;
                }


                return intCount;


            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message.ToString());
                return intCount = 2;

            }

        }
        #endregion
        #region //生成流水号 例如：KH-20071118114255
        public string WareInOutSerialNum(int _FTYPE)
        {
            int intYear = DateTime.Now.Year;
            int intMonth = DateTime.Now.Month;
            int intDate = DateTime.Now.Day;
            int intHour = DateTime.Now.Hour;
            int intSecond = DateTime.Now.Second;
            int intMinute = DateTime.Now.Minute;
            string strTime = null;
            if (_FTYPE == 0)
                strTime += "RK-";
            else
                strTime += "CK-";
            strTime += intYear.ToString();
            string selnum = "SELECT top 1 RIGHT(FSerialNum,6) FROM WareInOut where FTYPE = " + _FTYPE + " AND LEFT(FSerialNum,7)='" + strTime + "' order by FSerialNum desc";
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
            /* if (intHour < 10)
             {
                 strTime += "0" + intHour.ToString();
             }
             else
             {
                 strTime += intHour.ToString();
             }
             if (intMinute < 10)
             {

                 strTime += "0" + intMinute.ToString();
             }
             else
             {
                 strTime += intMinute.ToString();
             }
             if (intSecond < 10)
             {

                 strTime += "0" + intSecond.ToString();
             }
             else
             {
                 strTime += intSecond.ToString();
             }
             */
             return (strTime + strMaxnum);



        }

        #endregion
    }
}
