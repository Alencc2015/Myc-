using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SimpleWare;
using DevComponents.DotNetBar;
using System.Reflection;
using SimpleWare.DbMethod;
using SimpleWare.GoodsViewForm;
using SimpleWare.SelPorcelain;
using SimpleWare.SelPorcelainForms;
using SimpleWare.Menu;
using System.Net;
using System.Xml;
using SimpleWare.BaseClass;
namespace SimpleWare
{
    public partial class frmMain : Office2007Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (!OnlyOpen("frmGoods", "产品档案"))
            {
                frmGoods fra = new frmGoods();
                fra.MdiParent = this;
                fra.Show();
            }
        }
        public bool OnlyOpen(string MdiChildrenClassName, string funtion)
        {
            //遍历每一个MDI子窗体实例
            foreach (Form childFrm in this.MdiChildren)
            {
                //若子窗体的类型与实参相同,则存在该类的实例
                if (childFrm.Name == MdiChildrenClassName)
                {
                    //若该窗体被最小化了,则显将其恢复到原来状态
                    if (childFrm.WindowState == FormWindowState.Minimized)
                    {
                        childFrm.WindowState = FormWindowState.Normal;
                    }
                    childFrm.Activate();
                    return true;
                }
            }
            return false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!OnlyOpen("frmJCH", "进出窑登记"))
            {
                frmJCH fra = new frmJCH();
                fra.MdiParent = this;
                fra.WindowState = FormWindowState.Maximized;
                fra.Show();
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //设置时间和日期
            tssl1.Text = "今天日期：" + System.DateTime.Now.ToLongDateString();
            //tssl1.Width = 1 / 4 * statusStrip1.Width;
            tssl2.Text = "登录时间：" + System.DateTime.Now.ToLongTimeString();
            //tssl2.Width = 1 / 4 * statusStrip1.Width;
            //tssl3.Width = 1 / 4 * statusStrip1.Width;
            tsslLoginUser.Text = "当前用户：" + " " + frmLogin.userName;
            //tsslLoginUser.Width = 1 / 4 * statusStrip1.Width;
            timer1.Enabled = true;
            timer2.Enabled = true;
            this.WindowState = FormWindowState.Maximized;
            setBtnVisible();
        }

        private void setBtnVisible()
        {
            int width = 0;
            int firstTab = 0;
            Boolean isSuperGm = frmLogin.isSuperGm;
            
            if (!isSuperGm)
            {
                foreach (RibbonTabItem item in ribbonControl1.Items)
                {
                    if (frmLogin.moduleDict.ContainsValue(item.Text))
                    {
                        RibbonPanel panel = item.Panel;
                        foreach (Control control in panel.Controls)
                        {
                            if (control.GetType() == typeof(RibbonBar))
                            {
                                RibbonBar bar = (RibbonBar)control;
                                foreach (ButtonItem btnControl in bar.Items)
                                {
                                    if (btnControl.Text != "退出系统")
                                    {
                                        if(frmLogin.menuDict.ContainsValue(btnControl.Text))
                                        {
                                            btnControl.Visible = true;
                                            width += btnControl.Size.Width;
                                        }
                                        else
                                            btnControl.Visible = false;
                                    }
                                }
                                bar.Width = width + 50;
                            }

                        }
                        item.Panel.AutoSize = true;
                        if(firstTab == 0)
                            ribbonControl1.SelectedRibbonTabItem = item;
                        firstTab++;
                    }
                    else
                        item.Visible = false;
                    
                }
                ribbonControl1.SuspendLayout();
                int i = 1;
                foreach (SideBarPanelItem control in sideBar1.Panels)
                {
                    
                    if (frmLogin.moduleDict.ContainsValue(control.Text))
                    {
  
                        foreach (BaseItem item in control.SubItems)
	                    {
                            if (item.GetType() == typeof(ButtonItem))
                                item.Visible = frmLogin.menuDict.ContainsValue(item.Text);
                                
	                    }
                    }
                    else 
                        control.Visible = false;
                }
            }
        }
        private void tool_ItemDetail_Click(object sender, EventArgs e)
        {
         //   SetMdiForm("备件信息", typeof(FrmItemDetail));
        }
        /// <summary>
        /// 创建或者显示一个多文档界面页面
        /// </summary>
        /// <param name="caption">窗体标题</param>
        /// <param name="formType">窗体类型</param>
        public void SetMdiForm(string caption, Type formType)
        {
            bool IsOpened = false;

            //遍历现有的Tab页面，如果存在，那么设置为选中即可
            foreach (SuperTabItem tabitem in NavTabControl.Tabs)
            {
                if (tabitem.Name == caption)
                {
                    NavTabControl.SelectedTab = tabitem;
                    IsOpened = true;
                    break;
                }
            }

            //如果在现有Tab页面中没有找到，那么就要初始化了Tab页面了
            if (!IsOpened)
            {
                //为了方便管理，调用LoadMdiForm函数来创建一个新的窗体，并作为MDI的子窗体
                //然后分配给SuperTab控件，创建一个SuperTabItem并显示
                DevComponents.DotNetBar.Office2007Form form = ChildWinManagement.LoadMdiForm(this, formType)
                    as DevComponents.DotNetBar.Office2007Form;

                SuperTabItem tabItem = NavTabControl.CreateTab(caption);
                tabItem.Name = caption;
                tabItem.Text = caption;

                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.Visible = true;
                form.Dock = DockStyle.Fill;
                //tabItem.Icon = form.Icon;
                tabItem.AttachedControl.Controls.Add(form);
                
                NavTabControl.SelectedTab = tabItem;
            }
        }
        public void CloseAllDocuments()
        {
            for (int i = NavTabControl.Tabs.Count - 1; i >= 1; i--)
            {
                SuperTabItem tabitem = NavTabControl.Tabs[i] as SuperTabItem;
                if (tabitem != null && tabitem.Text != "欢迎")
                {
                    tabitem.Close();
                }
            }
        }

        public void CloseOthers()
        {
            if (ActiveMdiChild != null)
            {
                Type formType = ActiveMdiChild.GetType();
                for (int i = NavTabControl.Tabs.Count - 1; i >= 0; i--)
                {
                    SuperTabItem tabitem = NavTabControl.Tabs[i] as SuperTabItem;
                    if (tabitem != null && tabitem.Text != "欢迎" && formType != tabitem.AttachedControl.Controls[0].GetType())
                    {
                        tabitem.Close();
                    }
                }
            }
        }


        private void buttonItem1_Click(object sender, EventArgs e)
        {
            SetMdiForm("出窑登记", typeof(frmJCHEx));
        }

        private void 关闭其他窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseOthers();
        }

        private void 全部关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllDocuments();
        }

        private void buttonItem2_Click(object sender, EventArgs e)
        {

        }

        private void buttonItem5_Click(object sender, EventArgs e)
        {
            SetMdiForm("仓库档案", typeof(frmWareHouse));
        }

        private void biGoods_Click(object sender, EventArgs e)
        {
            SetMdiForm("产品资料", typeof(frmGoods));
        }

        private void biRptday_Click(object sender, EventArgs e)
        {
            SetMdiForm("库存日报表", typeof(frmWareDayRpt));
        }

        private void birptdetail_Click(object sender, EventArgs e)
        {
            SetMdiForm("装窑明细表", typeof(frmCarDetail));
        }

        private void biusers_Click(object sender, EventArgs e)
        {
            SetMdiForm("用户管理", typeof(frmUsers));
        }

        private void buttonItem10_Click(object sender, EventArgs e)
        {
            SetMdiForm("用户管理", typeof(frmUsers));

        }

        private void superTabItem1_DoubleClick(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                Type formType = ActiveMdiChild.GetType();
                SuperTabItem tabitem = NavTabControl.SelectedTab as SuperTabItem;
                if (tabitem != null && tabitem.Text != "欢迎" && formType != tabitem.AttachedControl.Controls[0].GetType())
                {
                    tabitem.Close();
                }
            }
        }

        private void NavTabControl_DoubleClick(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                Type formType = ActiveMdiChild.GetType();
                SuperTabItem tabitem = NavTabControl.SelectedTab as SuperTabItem;
                if (tabitem != null && tabitem.Text != "欢迎" && formType != tabitem.AttachedControl.Controls[0].GetType())
                {
                    tabitem.Close();
                }
            }
        }

        private void NavTabControl_TabStripMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                Type formType = ActiveMdiChild.GetType();
                SuperTabItem tabitem = NavTabControl.SelectedTab as SuperTabItem;
                if (tabitem != null && tabitem.Text != "欢迎")
                {
                    tabitem.Close();
                }
            }
        }

        private void buttonItem11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void buttonItem15_Click(object sender, EventArgs e)
        {
            SetMdiForm("装窑登记", typeof(frmJCHIn));
        }

        private void buttonItem19_Click(object sender, EventArgs e)
        {
            SetMdiForm("入库登记", typeof(frmWareIn));
        }

        private void buttonItem20_Click(object sender, EventArgs e)
        {
            SetMdiForm("出库登记", typeof(frmWareOut));
        }

        private void buttonItem13_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tssl3.Text = "现在时间：" + System.DateTime.Now.ToLongTimeString();
        }

        private void buttonItem21_Click(object sender, EventArgs e)
        {
            SetMdiForm("基础资料", typeof(frmBaseInfo));
        }

        private void 基础资料_Click(object sender, EventArgs e)
        {
            SetMdiForm("基础资料", typeof(frmBaseInfo));
        }

        private void buttonItem22_Click(object sender, EventArgs e)
        {
            SetMdiForm("出入库明细表", typeof(frmWareDetailRpt));
        }

        private void buttonItem23_Click(object sender, EventArgs e)
        {
            SetMdiForm("选瓷登记", typeof(frmSelPorcelain));
        }

        private void buttonItem25_Click(object sender, EventArgs e)
        {
            SetMdiForm("选瓷登记", typeof(frmSelPorcelain));
        }

        private void buttonItem26_Click(object sender, EventArgs e)
        {
            SetMdiForm("选瓷产品档案", typeof(frmSpGoods));
        }

        private void buttonItem27_Click(object sender, EventArgs e)
        {
            SetMdiForm("选瓷产品档案", typeof(frmSpGoods));
        }

        private void buttonItem28_Click(object sender, EventArgs e)
        {
            SetMdiForm("器型档案", typeof(frmModel));
        }

        private void buttonItem29_Click(object sender, EventArgs e)
        {
            SetMdiForm("花色档案", typeof(frmColor));
        }

        private void buttonItem31_Click(object sender, EventArgs e)
        {
            SetMdiForm("器型档案", typeof(frmModel));
        }

        private void buttonItem32_Click(object sender, EventArgs e)
        {
            SetMdiForm("花色档案", typeof(frmColor));
        }

        private void btnItemXCHZ_Click(object sender, EventArgs e)
        {
            SetMdiForm("选瓷汇总表", typeof(frmSelpainSumRpt));
        }

        private void btnItemXCHZ1_Click(object sender, EventArgs e)
        {
            SetMdiForm("选瓷汇总表", typeof(frmSelpainSumRpt));
        }

        private void buttonItem33_Click(object sender, EventArgs e)
        {
            SetMdiForm("质量分析日报表", typeof(frmZLFXB));
        }

        private void buttonItem30_Click(object sender, EventArgs e)
        {
            SetMdiForm("质量分析日报表", typeof(frmZLFXB));
        }

        private void buttonItem30_Click_1(object sender, EventArgs e)
        {
            SetMdiForm("参数设置", typeof(frmSettings));
        }

        private void buttonItem33_Click_1(object sender, EventArgs e)
        {
            SetMdiForm("参数设置", typeof(frmSettings));
        }

        private void buttonItem34_Click(object sender, EventArgs e)
        {
            SetMdiForm("权限管理", typeof(frmEmpMenu));
        }

        private void buttonItem35_Click(object sender, EventArgs e)
        {
            SetMdiForm("用户组管理", typeof(frmUserGroups));
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //检查更新
            AutoUpdate.AutoUpdate au = new AutoUpdate.AutoUpdate();
            try
            {
                if (au != null)
                {
                    MessageBox.Show("发现新版本，点击确定按钮更新为最新程序!", "自动更新", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.Close();
                    au.Update();
                }
                
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
    }
}
