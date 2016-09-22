using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleWare.ClassInfo;
using System.Data;
using System.Data.SqlClient;
using SimpleWare.ClassInfo;
using SimpleWare.BaseClass;
namespace SimpleWare.DbMethod
{
    class BaseMenuMethod
    {
        //public bool Exists(int MenuId)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(1) from BaseMenu");
        //    strSql.Append(" where ");
        //    strSql.Append(" MenuId = @MenuId  ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@MenuId", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = MenuId;

        //    return DbHelperSQL.Exists(strSql.ToString(), parameters);
        //}


        Dbconnection dbc = new Dbconnection();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(BaseMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BaseMenu(");
            strSql.Append("Memo,SortId,Name,ModuleId,PMenuId");
            strSql.Append(") values (");
            strSql.Append("'"+model.Memo+"',");
            strSql.Append(model.SortId+",");
            strSql.Append("'" + model.Name + "',");
            strSql.Append(model.ModuleId+",");
            strSql.Append(model.PMenuId);
            //strSql.Append("@Memo,@Image,@UrlId,@UrlName,@BindSQL,@WorkId,@SortId,@Name,@DllName,@FunName,@ModuleId,@PMenuId,@MenuToolBar,@MenuLookBar");
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
        /// 更新一条数据
        /// </summary>
        public bool Update(BaseMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BaseMenu set ");

            strSql.Append(" Memo = @Memo , ");
            strSql.Append(" Image = @Image , ");
            strSql.Append(" UrlId = @UrlId , ");
            strSql.Append(" UrlName = @UrlName , ");
            strSql.Append(" BindSQL = @BindSQL , ");
            strSql.Append(" WorkId = @WorkId , ");
            strSql.Append(" SortId = @SortId , ");
            strSql.Append(" Name = @Name , ");
            strSql.Append(" DllName = @DllName , ");
            strSql.Append(" FunName = @FunName , ");
            strSql.Append(" ModuleId = @ModuleId , ");
            strSql.Append(" PMenuId = @PMenuId ");
            strSql.Append(" where MenuId=@MenuId ");

            SqlParameter[] parameters = {
			            new SqlParameter("@MenuId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Memo", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@Image", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@UrlId", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@UrlName", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@BindSQL", SqlDbType.NVarChar,-1) ,            
                        new SqlParameter("@WorkId", SqlDbType.Int,4) ,            
                        new SqlParameter("@SortId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@DllName", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@FunName", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@ModuleId", SqlDbType.Int,4) ,            
                        new SqlParameter("@PMenuId", SqlDbType.Int,4)            
       
              
            };

            parameters[0].Value = model.MenuId;
            parameters[1].Value = model.Memo;
            parameters[2].Value = model.Image;
            parameters[3].Value = model.UrlId;
            parameters[4].Value = model.UrlName;
            parameters[5].Value = model.BindSQL;
            parameters[6].Value = model.WorkId;
            parameters[7].Value = model.SortId;
            parameters[8].Value = model.Name;
            parameters[9].Value = model.DllName;
            parameters[10].Value = model.FunName;
            parameters[11].Value = model.ModuleId;
            parameters[12].Value = model.PMenuId;
            int rows = dbc.ExeInfochange(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int MenuId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BaseMenu ");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
            parameters[0].Value = MenuId;


            int rows = dbc.ExeInfochange(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 批量删除一批数据
        /// </summary>
        public bool DeleteList(string MenuIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BaseMenu ");
            strSql.Append(" where ID in (" + MenuIdlist + ")  ");
            int rows = dbc.ExeInfochange(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BaseMenu GetModel(int MenuId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select MenuId, Memo, Image, UrlId, UrlName, BindSQL, WorkId, SortId, Name, DllName, FunName, ModuleId, PMenuId, MenuToolBar, MenuLookBar  ");
            strSql.Append("  from BaseMenu ");
            strSql.Append(" where MenuId=@MenuId");
            SqlParameter[] parameters = {
					new SqlParameter("@MenuId", SqlDbType.Int,4)
			};
            parameters[0].Value = MenuId;


            BaseMenu model = new BaseMenu();
            DataSet ds = dbc.ds(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["MenuId"].ToString() != "")
                {
                    model.MenuId = int.Parse(ds.Tables[0].Rows[0]["MenuId"].ToString());
                }
                model.Memo = ds.Tables[0].Rows[0]["Memo"].ToString();
                if (ds.Tables[0].Rows[0]["SortId"].ToString() != "")
                {
                    model.SortId = int.Parse(ds.Tables[0].Rows[0]["SortId"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                if (ds.Tables[0].Rows[0]["ModuleId"].ToString() != "")
                {
                    model.ModuleId = int.Parse(ds.Tables[0].Rows[0]["ModuleId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PMenuId"].ToString() != "")
                {
                    model.PMenuId = int.Parse(ds.Tables[0].Rows[0]["PMenuId"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        public List<BaseMenu> GetList(int _moduleId)
        {
            return this.GetList(_moduleId, -1);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<BaseMenu> GetList(int _moduleId,int pMenuID)
        {
            try
            {
                List<BaseMenu> list = new List<BaseMenu>();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("SELECT MenuId,SortId,Name,ModuleId,PMenuId,Memo");
                strSql.Append(" FROM dbo.BaseMenu ");
                strSql.Append("where 1 = 1 ");
                if (_moduleId != -1)
                {
                    strSql.Append(" and ModuleId = " + _moduleId);
                }
                if (pMenuID != -1)
                {
                    strSql.Append(" and PMenuId = " + pMenuID);
                }
                DataSet ds = dbc.ds(strSql.ToString());
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        BaseMenu menu = new BaseMenu();
                        menu.MenuId = Convert.ToInt16(ds.Tables[0].Rows[i]["MenuId"]);
                        menu.SortId = Convert.ToInt16(ds.Tables[0].Rows[i]["SortId"]);
                        menu.ModuleId = Convert.ToInt16(ds.Tables[0].Rows[i]["ModuleId"]);
                        menu.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                         menu.PMenuId = Convert.ToInt16(ds.Tables[0].Rows[i]["PMenuId"]);
                        menu.Memo = ds.Tables[0].Rows[i]["Memo"].ToString();
                        list.Add(menu);
                    }
                }
                return list;
            }
            catch (Exception ee)
            {
                MessageUtil.ShowError(ee.Message);
                return null;
            }
        }

    }
}
