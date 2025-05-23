using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Data;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 短信回复类
    /// </summary>
    public class Note_WriteBack : INote_WriteBack
    {

        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Note_WriteBack");
            strSql.Append(" where ID= @ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public void Add(Model.Note_WriteBack model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Note_WriteBack(");
            strSql.Append("Phone,Countent,BeginTime,Sp_PID)");
            strSql.Append(" values (");
            strSql.Append("@Phone,@Countent,@BeginTime,@Sp_PID)");
            SqlParameter[] parameters = {
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@Countent", SqlDbType.NVarChar),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
                    new SqlParameter("@Sp_PID",SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Phone;
            parameters[1].Value = model.Content;
            parameters[2].Value = model.BeginTime;
            parameters[3].Value = model.Sp_PID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void Update(Model.Note_WriteBack model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Note_WriteBack set ");
            strSql.Append("Phone=@Phone,");
            strSql.Append("Countent=@Countent,");
            strSql.Append("BeginTime=@BeginTime,");
            strSql.Append("Sp_PID=@Sp_PID");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@Countent", SqlDbType.NVarChar),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
                    new SqlParameter("@Sp_PID",SqlDbType.NVarChar,50)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Phone;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.BeginTime;
            parameters[4].Value = model.Sp_PID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Note_WriteBack ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        public Model.Note_WriteBack GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Note_WriteBack ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            Pbzx.Model.Note_WriteBack model = new Pbzx.Model.Note_WriteBack();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Countent"].ToString();
                if (ds.Tables[0].Rows[0]["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginTime"].ToString());
                }
                model.Sp_PID = ds.Tables[0].Rows[0]["Sp_PID"].ToString();
                return model;
            }
            else
            {
                return null;
            }
        }

        public System.Data.DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Note_WriteBack ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
