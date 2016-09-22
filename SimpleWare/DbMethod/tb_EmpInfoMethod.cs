using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SimpleWare.ClassInfo;
using System.Windows.Forms;
using System.Data;
using DevComponents.DotNetBar.Controls;
using SimpleWare.BaseClass;
namespace SimpleWare.DbMethod
{
    public class tb_EmpInfoMenthod
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader qlddr = null;
        Dblink dblink = new Dblink();
        Dbconnection dbl = new Dbconnection();
        #region 添加
        public int tb_EmpInfoAdd(tb_EmpInfo Empinfo)
        {
            int intFalg = 0;
            try
            {
                string str_Add = "insert into tb_EmpInfo values( ";
                str_Add += " '" + Empinfo.strEmpId + "','" + Empinfo.strEmpName + "',";
                str_Add += " '" + Empinfo.strEmpLoginPwd + "'," ;
                str_Add += " '" + Empinfo.strEmpDept + "','" + Empinfo.strEmpPost + "'," + " '" + Empinfo.strEmpPhone + "'," + Empinfo.intEmpFalg + ",1,null," + Empinfo.intEmpGroupID;
                str_Add += ", '" + Empinfo.strEmpKilnNO + "','"+Empinfo.strEmpWorshoId+"')";
                
                string sql = "select Count(1) from tb_EmpInfo where EmpId='" + Empinfo.strEmpId + "'";
                //SqlCommand cmd1 = new SqlCommand(sql, conn);
                int count = dbl.ExecuteSelect(sql);
                if (count > 0)
                {
                    MessageUtil.ShowError("该员工已存在!");
                    return 0;
                }
                else
                {
                    intFalg = dbl.ExeInfochange(str_Add);
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
        public int tb_EmpInfoUpdate(tb_EmpInfo Empinfo)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update tb_EmpInfo set ";
                str_Update += "EmpName='" + Empinfo.strEmpName +"'," ;
                str_Update += "EmpLoginPwd='" + Empinfo.strEmpLoginPwd + "',";
                str_Update += "EmpWorshoId='" + Empinfo.strEmpWorshoId + "',EmpKilnNO='" + Empinfo.strEmpKilnNO + "',";
                str_Update += "EmpDept= '" + Empinfo.strEmpDept + "',EmpPost='" + Empinfo.strEmpPost + "',EmpPhone='" + Empinfo.strEmpPhone + "',empfalg=" + Empinfo.intEmpFalg + ",EmpGroupID=" + Empinfo.intEmpGroupID + "";
                str_Update += " where  EmpId='" + Empinfo.strEmpId + "'";

                intFalg = dbl.ExeInfochange(str_Update);
                //conn.Dispose();
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
        public int tb_EmpInfoDelete(string _emplid)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update tb_EmpInfo set ";
                str_Update += "Active= 0 where  EmpId='" + _emplid + "'";

                intFalg = dbl.ExeInfochange(str_Update);
                //conn.Dispose();
                return intFalg;


            }
            catch (Exception ee)
            {
                return intFalg;

            }

        }
        #endregion
        #region 查询
      /*  public void tb_EmpInfoFind(string strObject, int intFalg, Object DataObject)
        {
            int intCount = 0;
            string strSecar = null;
            try
            {
                switch (intFalg)//判断条件
                {
                    case 1://"员工姓名":
                        strSecar = "select * from tb_EmpInfo where EmpName like  '%" + strObject + "%' and EmpFalg=0";
                        break;
                    case 2://所属部门"
                        strSecar = "select * from tb_EmpInfo where EmpDept like '%" + strObject + "%' and EmpFalg=0";
                        break;
                    case 3://"员工职位":
                        strSecar = "select * from tb_EmpInfo where EmpPost like '%" + strObject + "%' and EmpFalg=0";
                        break;
                    case 4:
                        strSecar = "select * from tb_EmpInfo where EmpFalg=0";
                        break;
                }
                getSqlConnection getConnection = new getSqlConnection();
                conn = getConnection.GetCon();
                cmd = new SqlCommand(strSecar, conn);
                int ii = 0;
                qlddr = cmd.ExecuteReader();
                while (qlddr.Read())
                {
                    ii++;
                }
                qlddr.Close();
                System.Windows.Forms.DataGridView dv = (DataGridView)DataObject;
                if (ii != 0)
                {
                    int i = 0;
                    dv.RowCount = ii;
                    qlddr = cmd.ExecuteReader();
                    while (qlddr.Read())
                    {
                        dv[0, i].Value = qlddr[0].ToString();
                        dv[1, i].Value = qlddr[1].ToString();
                        dv[2, i].Value = qlddr[4].ToString();
                        dv[3, i].Value = qlddr[6].ToString();
                        dv[4, i].Value = qlddr[7].ToString();
                        dv[5, i].Value = qlddr[9].ToString();
                        i++;
                    }
                    qlddr.Close();
                }
                else
                {
                    for (int i = 0; i < dv.RowCount; i++)
                    {
                        dv[0, i].Value = "";
                        dv[1, i].Value = "";
                        dv[2, i].Value = "";
                        dv[3, i].Value = "";
                        dv[4, i].Value = "";
                        dv[5, i].Value = "";
                    }
                }
            }
            catch (Exception ee)
            {
            }
        }*/
        #endregion
        #region 查询
       /* public SqlDataReader tb_EmpInfoFind(string strObject, int intFalg)
        {
            int intCount = 0;
            string strSecar = null;

            try
            {
                switch (intFalg)
                {
                    case 1:
                        strSecar = "select * from tb_EmpInfo where EmpId= '" + strObject + "' and EmpFalg=0";
                        break;
                    case 2:
                        strSecar = "select * from tb_EmpInfo where EmpFalg=0";
                        break;
                }
                strSecar = "select * from tb_EmpInfo where EmpId= '" + strObject + "' and EmpFalg=0";

                getSqlConnection getConnection = new getSqlConnection();
                conn = getConnection.GetCon();
                cmd = new SqlCommand(strSecar, conn);

                qlddr = cmd.ExecuteReader();


                return qlddr;


            }
            catch (Exception ee)
            {


                return qlddr;

            }

        }
        #endregion

        #region 查询
        public int tb_EmpInfoFind(string strObject, string pwwd, int intFalg)
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

                getSqlConnection getConnection = new getSqlConnection();
                conn = getConnection.GetCon();
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

        }*/
        #endregion
        #region //生成客户编号 例如：KH-20071118114255
        public string tb_EmpInfoID()
        {
            int intYear = DateTime.Now.Day;
            int intMonth = DateTime.Now.Month;
            int intDate = DateTime.Now.Year;
            int intHour = DateTime.Now.Hour;
            int intSecond = DateTime.Now.Second;
            int intMinute = DateTime.Now.Minute;
            string strTime = null;
            strTime = intYear.ToString();
            if (intMonth < 10)
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
            if (intHour < 10)
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


            return ("YG-" + strTime);



        }// end if 
        #endregion

        static Boolean isGm(string _id)
        {
            Boolean result = false;
            Dbconnection db = new Dbconnection();
            string sql = "select empfalg from tb_empinfo where empid='" + _id + "'";
            if (db.ExeInfochange(sql) != 0)
            {
                result = true;
            }
            return result;
        }
        public static string userid(string username)
        {
            string userid = "";
            string selnum = "select empid from tb_empinfo where empname='" + username + "'";
            //getSqlConnection getConnection = new getSqlConnection();
            Dblink dbl = new Dblink();
            DataSet ds = dbl.GetDataset(selnum);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        userid = ds.Tables[0].Rows[0]["empid"].ToString();
                    }
                }
            }

            return userid;
        }
        public static void SetCombox(ComboBoxEx _control)
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select EmpId,EmpName from tb_empinfo where Active= 1" ;
            ds = dbl.GetDatasetReport(sql, "tb_EmpInfo");
            List<string> listArr = new List<string>();
            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    _control.DataSource = ds.Tables[0];
                    _control.DisplayMember = "EmpName";
                    _control.ValueMember = "EmpId";
                }

            }
        }
    }
}
