using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SimpleWare.ClassInfo;
using System.Windows.Forms;
using System.Data;

namespace SimpleWare.DbMethod
{
    public class tb_JCHMethod
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader qlddr = null;
        Dbconnection dbl = new Dbconnection();
        #region 添加
        public int tb_JCHADD (tb_JCH JCH)
        {
            int intFalg = 0;
            try
            {
                string str_Add = "insert into tb_JCH(JCDate,JCWorknum,JCOperator,JCWareID,JCGoodsID,JCHGSL,JCPSSL,JCKLSL,JCKHSL,JCCarNO,JCTYPE,JCSerialNum,JCGoodsName,JCModelno,JCItemID,JCMaterial,FImagePath,FRYHGSL,FHGL,FZYID,FPSSL,FPSL,FKilnNo) values( ";
                str_Add += " '" + JCH.dJCDate + "','" + JCH.strJCWorknum + "',";
                str_Add += " '" + JCH.strJCOperator+ "','" + JCH.strJCWareID + "','"+JCH.strJCGoodsID+"',";
                str_Add += JCH.dJCHGSL + "," + JCH.dJCPSSL + "," + JCH.dJCKLSL + "," + JCH.dJCKHSL + ",'";
                str_Add += JCH.strJCCarNO + "'," + JCH.intJCTYPE + ",'" + JCH.strJCSerialNum + "','" + JCH.strJCGoodsName + "','";
                str_Add += JCH.strJCModelno + "','" + JCH.strJCItemID + "','" + JCH.strJCMaterial + "','" + JCH.strFImagePath + "'," + JCH.dFRYHGSL + "," + JCH.dFHGL + "," + JCH.iFZYID + "," + JCH.iFPSSL + "," + JCH.dFPSL + ",'" + JCH.strFKilnNo+ "')";
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
        public int tb_JCHUpdate(tb_JCH JCH)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update tb_JCH set ";
                str_Update += "JCDate='" + JCH.dJCDate +"'," ;
                str_Update += "JCWorknum='" + JCH.strJCWorknum + "',JCOperator='"+JCH.strJCOperator+"',JCWareID='"+JCH.strJCWareID+"',JCGoodsID='"+JCH.strJCGoodsID+"',JCMaterial ='"+JCH.strJCMaterial+"',";
                str_Update += "JCHGSL= " + JCH.dJCHGSL + ",JCPSSL=" + JCH.dJCKHSL + ",JCKLSL=" + JCH.dJCKLSL + ",JCKHSL = " + JCH.dJCKHSL + ",JCCarNO='" + JCH.strJCCarNO + "',JCTYPE=" + JCH.intJCTYPE + ",FRYHGSL = " + JCH.dFRYHGSL + ",FHGL=" + JCH.dFHGL + ",FPSSL=" + JCH.iFPSSL + ",FPSL=" + JCH.dFPSL + ",FKilnNo='" + JCH.strFKilnNo + "'";
                str_Update += " where  JCSerialNum='" + JCH.strJCSerialNum + "'";

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
        public int tb_JCHDelete(string _id)
        {
            int intFalg = 0;
            try
            {

                string str_Delete = "Delete from  tb_JCH where JCSerialNum = '" + _id + "'";

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
        public tb_JCH tb_JCHFind(string _sql,string _fieldsname)
        {
            tb_JCH jch = new tb_JCH();
            Dblink dbl1 = new Dblink();
            string[] s = _fieldsname.Split(',');
            try
            {
                DataSet ds = dbl1.GetDataset(_sql);
                if (ds != null)
                {
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < s.Length; i++)
                            {

                            }
                        }
                    }
                }

                return jch;


            }
            catch (Exception ee)
            {

                MessageBox.Show(ee.Message.ToString());
                return null;

            }

        }
        #endregion
        #region //生成流水号 例如：KH-20071118114255
        public string tb_JCSerialNum(int _JCTYPE)
        {
            int intYear = DateTime.Now.Year;
            int intMonth = DateTime.Now.Month;
            int intDate = DateTime.Now.Day;
            int intHour = DateTime.Now.Hour;
            int intSecond = DateTime.Now.Second;
            int intMinute = DateTime.Now.Minute;
            string strTime = null;
            if (_JCTYPE == 0)
                strTime += "ZY-";
            else
                strTime += "CY-";
            strTime += intYear.ToString();
           /* if (intMonth < 10)
            {
                strTime += "0" + intMonth.ToString();
            }
            else
            {
                strTime += intMonth.ToString();
            }
            if (intDate < 10)
            {
                strTime += "0" + intDate.ToString();
            }
            else
            {
                strTime += intDate.ToString();
            }
            */ 
            string selnum = "SELECT top 1 RIGHT(JCSerialNum,6) FROM tb_JCH where JCTYPE = " + _JCTYPE + " AND LEFT(JCSerialNum,7)='" + strTime + "' order by JCSerialNum desc";
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
            if (maxNum>0 && maxNum <10)
	        {
		        strMaxnum   = "00000"+maxNum;
	        }
            else if (maxNum>=10 && maxNum<100)
	        {
		        strMaxnum   = "0000"+maxNum;
	        }
            else if (maxNum>=100 && maxNum<1000)
	        {
		        strMaxnum   = "000"+maxNum;
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
                strMaxnum   = Convert.ToString(maxNum);
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
