using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using SimpleWare.ClassInfo;
using System.Windows.Forms;
namespace SimpleWare.DbMethod
{
    class tb_WorkNumMethod
    {
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader qlddr = null;
        Dbconnection dbl = new Dbconnection();
        #region 添加
        public  int tb_WorkNumAdd(tb_WorkNum WorkNum)
        {
            int intFlag = 0 ;
            try 
	        {	        
		        string str_Add = "Insert tb_WorkNum Values('"+WorkNum.strWorkNumID+"','"+WorkNum.strWorkNumName+"','"+WorkNum.strremark+"')";
                intFlag = dbl.ExeInfochange(str_Add);
                conn.Dispose();
                return intFlag;
	        }
	        catch (Exception ee)
	        {
                MessageBox.Show(ee.ToString());
                return intFlag;
	        }
        }
        #endregion
        #region 修改
        public int tb_WorkNumUpdate(tb_WorkNum WorkNum)
        {
            int intFlag = 0;
            try
            {
                string str_Update = "Update tb_WorkNum set WorkNumID = '"+WorkNum.strWorkNumID+"',WorkNumName = '"+WorkNum.strWorkNumName+"',remark = '"+WorkNum.strremark+"'";
                str_Update += " where WorkNumID = '" + WorkNum.strWorkNumID + "'";

                intFlag = dbl.ExeInfochange(str_Update);

                return intFlag;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return intFlag;
            }
        }
        #endregion
        #region 删除
        public int tb_WorkNumDelete(tb_WorkNum WorkNum)
        {
            int intFlag = 0;
            try
            {
                string str_Delete = "Delete from tb_WorkNum where WorkNumID = '"+WorkNum.strWorkNumID+"'";
                intFlag = dbl.ExeInfochange(str_Delete);
                return intFlag;
            }
            catch (Exception ee)
            {
                MessageBox.Show(ee.ToString());
                return intFlag;
            }
        }
        #endregion
    }
}
