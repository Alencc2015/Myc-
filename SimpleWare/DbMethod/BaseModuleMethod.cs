using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SimpleWare.ClassInfo;
using SimpleWare.BaseClass;

namespace SimpleWare.DbMethod
{
    class BaseModuleMethod
    {
        Dbconnection dbc = new Dbconnection();
        //public bool Exists(int ModuleId)
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append("select count(1) from BaseModule");
        //    strSql.Append(" where ");
        //    strSql.Append(" ModuleId = @ModuleId  ");
        //    SqlParameter[] parameters = {
        //            new SqlParameter("@ModuleId", SqlDbType.Int,4)
        //    };
        //    parameters[0].Value = ModuleId;

        //    return DbHelperSQL.Exists(strSql.ToString(), parameters);
        //}



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public  int Add(BaseModule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into BaseModule(");
            strSql.Append("Name,Memo,SortId");
            strSql.Append(") values (");
            strSql.Append("@Name,@Memo,@SortId");
            strSql.Append(") ");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
			            new SqlParameter("@Name", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Memo", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@SortId", SqlDbType.Int,4)              
              
            };

            parameters[0].Value = model.Name;
            parameters[1].Value = model.Memo;
            parameters[2].Value = model.SortId;

            object obj = dbc.ExeInfochange(strSql.ToString(), parameters);
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
        public bool Update(BaseModule model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BaseModule set ");

            strSql.Append(" Name = @Name , ");
            strSql.Append(" Memo = @Memo , ");
            strSql.Append(" SortId = @SortId , ");
            strSql.Append(" where ModuleId=@ModuleId ");

            SqlParameter[] parameters = {
			            new SqlParameter("@ModuleId", SqlDbType.Int,4) ,            
                        new SqlParameter("@Name", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@Memo", SqlDbType.VarChar,254) ,            
                        new SqlParameter("@SortId", SqlDbType.Int,4) ,            
           
              
            };

            parameters[0].Value = model.ModuleId;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.Memo;
            parameters[3].Value = model.SortId;
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
        public bool Delete(int ModuleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BaseModule ");
            strSql.Append(" where ModuleId=@ModuleId");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleId", SqlDbType.Int,4)
			};
            parameters[0].Value = ModuleId;


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
        public bool DeleteList(string ModuleIdlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BaseModule ");
            strSql.Append(" where ID in (" + ModuleIdlist + ")  ");
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
        public BaseModule GetModel(int ModuleId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ModuleId, Name, Memo, SortId ");
            strSql.Append("  from BaseModule ");
            strSql.Append(" where ModuleId=@ModuleId");
            SqlParameter[] parameters = {
					new SqlParameter("@ModuleId", SqlDbType.Int,4)
			};
            parameters[0].Value = ModuleId;


            BaseModule model = new BaseModule();
            DataSet ds = dbc.ds(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ModuleId"].ToString() != "")
                {
                    model.ModuleId = int.Parse(ds.Tables[0].Rows[0]["ModuleId"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.Memo = ds.Tables[0].Rows[0]["Memo"].ToString();
                if (ds.Tables[0].Rows[0]["SortId"].ToString() != "")
                {
                    model.SortId = int.Parse(ds.Tables[0].Rows[0]["SortId"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public  List<BaseModule> GetList(string strWhere)
        {
            try
            {
                List<BaseModule> list = new List<BaseModule>();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ModuleId,Name,Memo,SortId");
                strSql.Append(" FROM BaseModule ");
                if (strWhere.Trim() != "")
                {
                    strSql.Append(" where " + strWhere);
                }
                DataSet ds = dbc.ds(strSql.ToString());
                
                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        BaseModule module = new BaseModule();
                        module.ModuleId = Convert.ToInt16(ds.Tables[0].Rows[i]["ModuleId"]);
                        module.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                        module.SortId = Convert.ToInt16(ds.Tables[0].Rows[i]["SortId"]);
                        list.Add(module);
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

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" * ");
            strSql.Append(" FROM BaseModule ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return dbc.ds(strSql.ToString());
        }

    }
}
