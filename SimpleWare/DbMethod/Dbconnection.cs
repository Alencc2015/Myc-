using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Configuration;
using System.Drawing;
namespace SimpleWare.DbMethod
{
    class Dbconnection
    {
        #region 代码引用的变量
        //string G_Str_ConnectionString = "Data Source=.;database=SimpleWare;uid=sa;pwd=P@ssw0rd";
        SqlConnection G_Con;  //声明链接对象
        #endregion
        #region   连接数据库
        public static SqlConnection Dblink()
        {
            //string connectionString = @"Data Source=.;database=SimpleWare;uid=sa;pwd=P@ssw0rd";
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string connectionString = config.AppSettings.Settings["connectionstring"].Value;
            SqlConnection myConnection = new SqlConnection(connectionString);
            //SqlCommand command = new SqlCommand(connectionString);
            return myConnection;
        }
        #endregion
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>int number</returns>
        public int ExeInfochange(string sql)
        {
            try
            {
                SqlConnection G_Con = Dblink();
                SqlCommand myCommand = G_Con.CreateCommand();
                myCommand.CommandText = sql;
                G_Con.Open();
                int number = myCommand.ExecuteNonQuery();
                G_Con.Close();
                G_Con.Dispose();
                return number;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return 0;
            }
        }
        public int ExeInfochange(string sql,SqlParameter[] parameters)
        {
            try
            {
                SqlConnection G_Con = Dblink();
                SqlCommand myCommand = G_Con.CreateCommand();
                myCommand.CommandText = sql;
                G_Con.Open();
                foreach (var parameter in parameters)
                {
                    myCommand.Parameters.Add(parameter);
                }
                int number = myCommand.ExecuteNonQuery();
  
                G_Con.Close();
                G_Con.Dispose();
                return number;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return 0;
            }
        }

        public int ExeInfochange(string sql, string strparametername, byte[] img)
        {
            try
            {
                SqlConnection G_Con = Dblink();
                SqlCommand myCommand = G_Con.CreateCommand();
                myCommand.CommandText = sql;
                myCommand.Parameters.Add(strparametername, System.Data.SqlDbType.Image);
                // myCommand.Parameters.Add("@Image", SqlDbType.Binary);
                myCommand.Parameters[strparametername].Value = img;
                G_Con.Open();
                int number = myCommand.ExecuteNonQuery();
                G_Con.Close();
                G_Con.Dispose();
                return number;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return 0;
            }
        }
        /// <summary>
        /// 执行 Select 语句
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecuteSelect(string sql)
        {
            try
            {
                SqlConnection G_Con = Dblink();
                SqlCommand myCommand = G_Con.CreateCommand();
                myCommand.CommandText = sql;
                G_Con.Open();
                int number = Convert.ToInt32(myCommand.ExecuteScalar());
                G_Con.Close();
                G_Con.Dispose();
                return number;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return 0;
            }
        }

        public DataSet ds (string strSql,SqlParameter[] parameters)
        {
            try
            {
                SqlConnection con = Dblink();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = strSql;
                foreach (SqlParameter parmeter in parameters)
                {
                    cmd.Parameters.Add(parmeter);
                }
                SqlDataAdapter adr = new SqlDataAdapter();
                adr.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adr.Fill(ds);
                return ds;
                con.Close();
                cmd.Dispose();
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return null;
            }
        }
        /// <summary>
        /// 获取数据集
        /// </summary>
        /// <param name="str1"></param>
        /// <returns>DataSet ds</returns>
        public DataSet ds(string str1)
        {
            string sql = str1;
            try
            {
                SqlConnection G_Con = Dblink();
                SqlCommand myCommand = G_Con.CreateCommand();
                myCommand.CommandText = sql;
                G_Con.Open();
                SqlDataAdapter myDataReader = new SqlDataAdapter();
                myDataReader.SelectCommand = myCommand;
                DataSet ds = new DataSet();
                myDataReader.Fill(ds);
                G_Con.Close();
                G_Con.Dispose();
                return ds;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return null;
            }
        }
        public SqlDataReader dr(string strsql)
        {
            SqlDataReader qlddr = null;
            SqlConnection conn = Dblink();
            SqlCommand cmd = null;
            try
            {


                conn = Dblink();
                cmd = new SqlCommand(strsql, conn);

                qlddr = cmd.ExecuteReader();
                return qlddr;

            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return qlddr;

            }
        }
    }
}
