using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Data.SqlClient;
using SimpleWare.DbMethod;
using SimpleWare.BaseClass;
using AutoUpdate;
using System.Net;
using System.Xml;
using SimpleWare.ClassInfo;

namespace SimpleWare
{
    public partial class frmLogin : Office2007Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        public static string userCode;
        public static string userName;
        public static string passWord;
        public static tb_EmpInfo curUser = new tb_EmpInfo();
        public int userGrpID;
        public static Dictionary<int,string> menuDict = new Dictionary<int,string>();
        public static Dictionary<int, string> moduleDict = new Dictionary<int, string>();
        public static Boolean isGm,isSuperGm;
        SqlConnection conn = null;
        SqlCommand cmd = null;
        SqlDataReader qlddr = null;

        Marquee M = new Marquee();
        private void frmLogin_Load(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            M.Start(panelEx2, "今天是 " + dt.GetDateTimeFormats('D')[1].ToString() + "   欢迎您", Point.Add(labelX3.Location, new Size(0, labelX3.Height)), new Size(390, 100));
            //labelX3.Text = ;// +" " + dt.GetDateTimeFormats('D')[2].ToString();//星期六 2005年11月5日
            //"今天是 " + dt.GetDateTimeFormats('D')[1].ToString() + "   欢迎您"
            AutoUpdate.AutoUpdate au = new AutoUpdate.AutoUpdate();
            try
            {
                au.Update();
            }
            catch (WebException exp)
            {
                MessageBox.Show(String.Format("无法找到指定资源\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (XmlException exp)
            {
                MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NotSupportedException exp)
            {
                MessageBox.Show(String.Format("升级地址配置错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException exp)
            {
                MessageBox.Show(String.Format("下载的升级文件有错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exp)
            {
                MessageBox.Show(String.Format("升级过程中发生错误\n\n{0}", exp.Message), "自动升级", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogHelper.Error(String.Format("升级过程中发生错误\n\n{0}", exp.Message));
            }
        }
        private void buttonX1_Click(object sender, EventArgs e)
        {
            userCode = tbusername.Text.Trim();
            passWord = tbpassword.Text.Trim();
            /*if (userName == "admin" && passWord == "1")
            {
                this.Hide();
                frmMain fm = new frmMain();
                fm.Show();
            }
            else
            {*/
            try
            {
                if (userCode == "admin" && passWord == "1")
                {
                    isSuperGm = true;   
                    this.Hide();
                    frmMain fm = new frmMain();
                    fm.Show();
                }
                else
                { 
                    //数据库连接的建立
                    conn = Dbconnection.Dblink();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "select * from tb_EmpInfo where EmpId ='" + userCode + "' and EmpLoginPwd ='" + passWord.Trim() + "' and Active= 1";
                    conn.Open();
                    qlddr = cmd.ExecuteReader();
                    qlddr.Read();
                    if (qlddr.HasRows == true)     //
                    {
                        if (qlddr["EmpFalg"].ToString() == "1")//管理员
                        {
                            isGm = true;
                        }
                        userGrpID = qlddr["EmpGroupID"] == null ? -1 : Convert.ToInt16(qlddr["EmpGroupID"]);
                        //if (qlddr["EmpRole"].ToString() == "01")//出入窑
                        //{
                        //    isCRY = true;
                        //}
                        //if (qlddr["EmpRole"].ToString() == "02")//出入库
                        //{
                        //    isCrk = true;
                        //}
                        //if (qlddr["EmpRole"].ToString() == "03")//选瓷
                        //{
                        //    isXc = true;
                        //}
                        curUser.strEmpId = qlddr["EmpId"].ToString();
                        curUser.strEmpName = qlddr["EmpName"].ToString();
                        curUser.strEmpDept = qlddr["EmpDept"].ToString();
                        curUser.strEmpKilnNO = qlddr["EmpKilnNO"].ToString();
                        curUser.strEmpWorshoId = qlddr["EmpWorshoId"].ToString();
                        userName = qlddr["EmpName"].ToString();
                        BaseGroupMenuMethod bgM = new BaseGroupMenuMethod();
                        menuDict = bgM.getMenuDic(userGrpID);
                        moduleDict = bgM.getmoduleDict(userGrpID);
                        qlddr.Close();
                        conn.Close();
                        this.Hide();
                        frmMain fm = new frmMain();
                        fm.Show();
                        string ip = WindowsUtil.IP();
                        //LogHelper.WriteLog(userName+" "+userCode+" 于 "+ip+" 登录系统");
                        //Msg msg = new Msg(DateTime.Now, userName + " " + userCode + " 于 " + ip + " 登录系统", MsgType.Information);
                        Log log = new Log();
                        log.Write(DateTime.Now, userName + " " + userCode + " 于 " + ip + " 登录系统", MsgType.Information);

                    }
                    else
                    {
                        MessageBox.Show("用户名或密码错误,请重新输入!", "登录提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tbpassword.Text = "";
                        //tbusername.Text = "";
                        tbpassword.Focus();
                    }

                    conn.Close();
                    cmd.Dispose();
                }

            }
            catch (Exception ee)
            {
                LogHelper.WriteLog("登录系统出现错误"+ee.ToString());
                //MessageBox.Show("此用户已停用或密码错误,请重新输入!", "登录提示");
            }
            
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            M.Stop();
            M.Dispose();
            M = null;
            Application.Exit();
        }

        private void tbpassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonX1_Click(sender, e);
            }
        }


    }
}
