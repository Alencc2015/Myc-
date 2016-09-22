using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleWare.ClassInfo;
using SimpleWare.BaseClass;
using System.Data;
using DevComponents.DotNetBar.Controls;
namespace SimpleWare.DbMethod
{
    class BaseGroupMethod
    {
        Dblink dbl = new Dblink();
        Dbconnection dbc = new Dbconnection();

        #region 添加
        public int Add(
                BaseGroup group
                )
        {
            int intFalg = 0;
            try
            {
                string str_Add = @"INSERT INTO [dbo].[BaseGroup]
                                   ([Name]
                                   ,[IsStop]
                                   ,[Admin]
                                   ,[Memo])
                             VALUES(";
                str_Add += " '" + group.Name + "','" + group.IsStop + "',";
                str_Add += " '" + group.Admin + "',";
                str_Add += " '" + group.Memo + "')";
                //string sql = "select Count(1) from tb_ColorInfo where ColorNo='" + group.strColorNo + "'";
                //SqlCommand cmd1 = new SqlCommand(sql, conn);
                //int count = dbc.ExecuteSelect(sql);
                //if (count > 0)
                //{
                //    MessageUtil.ShowError("花色编号已存在!");
                //    return 0;
               // }
               // else
                //{
                    intFalg = dbc.ExeInfochange(str_Add);
                    //}
                    return intFalg;
               // }


            }
            catch (Exception ee)
            {
                //MessageBox.Show(ee.ToString());
                return intFalg;

            }

        }
        #endregion
        #region 修改
        public int Update(BaseGroup group)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "update BaseGroup set ";
                str_Update += "Name='" + group.Name + "', ";
                str_Update += "IsStop='" + group.IsStop + "',";
                str_Update += "Admin='" + group.Admin + "',";
                str_Update += "Memo= '" + group.Memo + "'";
                str_Update += " where  GroupId='" + group.GroupId + "'";

                intFalg = dbc.ExeInfochange(str_Update);
                return intFalg;
                // conn.Dispose();
                //return intFalg;


            }
            catch (Exception ee)
            {
                //MessageBox.Show(ee.ToString());
                return intFalg;

            }

        }
        #endregion
        #region 删除
        public int Delete(int groupid)
        {
            int intFalg = 0;
            try
            {

                string str_Update = "delete from  BaseGroup   where  groupid=" + groupid;

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
        public BaseGroup Find(int groupid)
        {
            BaseGroup groups = new BaseGroup();
            string sql = "select groupid,Name,IsStop,Admin,Memo from BaseGroup where groupid =" + groupid + " and FIsStop = 0 ";
            DataSet ds = dbl.GetDataset(sql);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            groups.GroupId = Convert.ToInt16(ds.Tables[0].Rows[i]["groupid"]);
                            groups.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                            groups.IsStop = Convert.ToInt16(ds.Tables[0].Rows[i]["Name"]);
                            groups.Admin = Convert.ToInt16(ds.Tables[0].Rows[i]["Admin"]);
                            groups.Memo = ds.Tables[0].Rows[i]["Memo"].ToString();
   
                        }
                    }
                }
            }
            return groups;
        }
        public static void SetGrpCombox(ComboBoxEx _control)
        {
            DataSet ds = new DataSet();
            Dblink dbl = new Dblink();
            string sql = "select GroupId,Name from BaseGroup where isstop =  0 order by GroupId";
            ds = dbl.GetDatasetReport(sql, "BaseGroup");
            List<string> listArr = new List<string>();
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    _control.DataSource = ds.Tables[0];
                    _control.DisplayMember = "Name";
                    _control.ValueMember = "GroupId";
                }

            }
        }
    }
}
