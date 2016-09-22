using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleWare.ClassInfo;
using System.Data;
namespace SimpleWare.DbMethod
{
    class BaseGroupMenuMethod
    {
        Dbconnection dbc = new Dbconnection();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(int groupid,int moduleid,int menuid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BaseGroupMenu(");
            strSql.Append("GroupId,ModuleId,MenuId");
            strSql.Append(") values (");
            strSql.Append(groupid+",");
            strSql.Append(moduleid + ",");
            strSql.Append(menuid);
            strSql.Append(") ");
            object obj = dbc.ExeInfochange(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }

        }

        /// <summary>
        /// 删除数据
        /// </summary>
        public bool Delete(int groupid)
        {
            string sql = "delete from BaseGroupMenu where groupid =  " + groupid;
            int rows = dbc.ExeInfochange(sql);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool exist(int groupid, int moduleid, int menuid)
        {
            string sql = "select 1 from BaseGroupMenu where groupid =" + groupid + " and moduleid = " + moduleid + " and menuid = " + menuid;
            int rows = dbc.ExecuteSelect(sql);
            return (rows == 1);
        }


        internal void Add(int SelectGroupId, List<BaseMenu> menulist)
        {
            foreach (BaseMenu menu in menulist)
            {
                this.Add(SelectGroupId, menu.ModuleId, menu.MenuId);
            }
        }
        public Dictionary<int, string> getMenuDic(int groupid)
        {
            Dictionary<int, string> menu = new Dictionary<int, string>();
            string sql = "select GroupId,a.ModuleId,a.MenuId,b.Name  from BaseGroupMenu a "+
                         "  left join BaseMenu b on a.menuid = b.menuid  where a.groupid =" + groupid ;
            DataSet ds = dbc.ds(sql);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            menu.Add(Convert.ToInt16(ds.Tables[0].Rows[i]["MenuId"]), ds.Tables[0].Rows[i]["Name"].ToString());
                        }
                    }
                }
            }
            return menu;
        }

        internal Dictionary<int, string> getmoduleDict(int userGrpID)
        {
            Dictionary<int, string> menu = new Dictionary<int, string>();
            string sql = "select distinct GroupId,a.ModuleId,c.Name  from BaseGroupMenu a " +
                         "  left join BaseModule c on a.ModuleID = c.ModuleID " +
                         "  where a.groupid =" + userGrpID;
            DataSet ds = dbc.ds(sql);
            if (ds != null)
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            menu.Add(Convert.ToInt16(ds.Tables[0].Rows[i]["ModuleId"]), ds.Tables[0].Rows[i]["Name"].ToString());
                        }
                    }
                }
            }
            return menu;
        }
    }
}
