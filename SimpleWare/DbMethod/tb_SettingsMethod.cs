using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SimpleWare.ClassInfo;
namespace SimpleWare.DbMethod
{
    class tb_SettingsMethod
    {
        Dbconnection dbl = new Dbconnection();
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(tb_settings model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_Settings set ");

            strSql.Append(" id = @id , ");
            strSql.Append(" PicSaveStyle = @PicSaveStyle , ");
            strSql.Append(" PicPath = @PicPath  ");
            strSql.Append(" isNeedRate = @isNeedRate  ");
            strSql.Append(" where id=@id  ");

            SqlParameter[] parameters = {
			            new SqlParameter("@id", SqlDbType.Int,4) ,            
                        new SqlParameter("@PicSaveStyle", SqlDbType.Int,4) ,            
                        new SqlParameter("@PicPath", SqlDbType.VarChar,2000) ,            
                        new SqlParameter("@isNeedRate",SqlDbType.Int,4) 
            };

            parameters[0].Value = model.id;
            parameters[1].Value = model.PicSaveStyle;
            parameters[2].Value = model.PicPath;
            parameters[3].Value = model.IsNeedRate;
            int rows = dbl.ExeInfochange(strSql.ToString(), parameters);
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
        public tb_settings Find()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id, PicSaveStyle, PicPath,isNeedRate");
            strSql.Append("  from tb_Settings ");

            tb_settings model = new tb_settings();
            DataSet ds = dbl.ds(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PicSaveStyle"].ToString() != "")
                {
                    model.PicSaveStyle = int.Parse(ds.Tables[0].Rows[0]["PicSaveStyle"].ToString());
                }
                model.PicPath = ds.Tables[0].Rows[0]["PicPath"].ToString();
                if (ds.Tables[0].Rows[0]["isNeedRate"].ToString() != "")
                {
                    model.IsNeedRate = int.Parse(ds.Tables[0].Rows[0]["isNeedRate"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }


          
    }
}
