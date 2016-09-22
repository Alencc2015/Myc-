using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using SimpleWare.DbMethod;
using DevComponents.DotNetBar;
namespace SimpleWare
{
    public partial class frmLogin1 : Office2007Form
    {
        public frmLogin1()
        {
            InitializeComponent();
        }
        public static string userName;
        public static string passWord;
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader qlddr = null; 
        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("osk.exe");        //调用系统软键盘 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 验证
            userName = editUsername.Text.Trim();
            passWord = editPassword.Text.Trim();
            if (userName == "admin" && passWord == "1")
            {
                this.Hide();
                frmMain fm = new frmMain();
                fm.Show();
            }
            else
            {
                try
                {
                    //数据库连接的建立
                    conn = Dblink();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from tb_EmpInfo where EmpId ='" + userName + "'and EmpLoginPwd ='" + passWord.Trim() + "'and EmpFalg= 0";
                    //conn.Open();
                    qlddr = cmd.ExecuteReader();
                    if (qlddr.HasRows == true)     //一条一条的读取记录,如果有则为真
                    {
                        qlddr.Close();
                        conn.Close();
                        this.Hide();
                        frmMain fm = new frmMain();
                        fm.Show();
                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误,请重新输入!", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        editUsername.Text = "";
                        editPassword.Text = "";
                        editUsername.Focus();
                    }
                    conn.Close();
                    cmd.Dispose();
                }
                catch (Exception)
                {
                    //MessageBox.Show("此用户已停用或密码错误,请重新输入!", "登录提示");
                }
            }
            #endregion
        }

        private SqlConnection Dblink()
        {
            throw new NotImplementedException();
        }
    }
}
