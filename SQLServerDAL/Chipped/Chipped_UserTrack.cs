using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Pbzx.Model;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Chipped_UserTrack
    /// </summary>
    public partial class Chipped_UserTrack : IChipped_UserTrack
    {
        public Chipped_UserTrack()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ut_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_UserTrack");
            strSql.Append(" where ut_id=@ut_id");
            SqlParameter[] parameters = {
					new SqlParameter("@ut_id", SqlDbType.Int,4)
};
            parameters[0].Value = ut_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_UserTrack model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_UserTrack(");
            strSql.Append("ut_username,ut_Lname,ut_state)");
            strSql.Append(" values (");
            strSql.Append("@ut_username,@ut_Lname,@ut_state)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ut_username", SqlDbType.NVarChar,50),
					new SqlParameter("@ut_Lname", SqlDbType.Int,4),
					new SqlParameter("@ut_state", SqlDbType.Int,4)};
            parameters[0].Value = model.ut_username;
            parameters[1].Value = model.ut_Lname;
            parameters[2].Value = model.ut_state;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
        public bool Update(Pbzx.Model.Chipped_UserTrack model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_UserTrack set ");
            strSql.Append("ut_username=@ut_username,");
            strSql.Append("ut_Lname=@ut_Lname,");
            strSql.Append("ut_state=@ut_state");
            strSql.Append(" where ut_id=@ut_id");
            SqlParameter[] parameters = {
					new SqlParameter("@ut_username", SqlDbType.NVarChar,50),
					new SqlParameter("@ut_Lname", SqlDbType.Int,4),
					new SqlParameter("@ut_state", SqlDbType.Int,4),
					new SqlParameter("@ut_id", SqlDbType.Int,4)};
            parameters[0].Value = model.ut_username;
            parameters[1].Value = model.ut_Lname;
            parameters[2].Value = model.ut_state;
            parameters[3].Value = model.ut_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool Delete(int ut_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_UserTrack ");
            strSql.Append(" where ut_id=@ut_id");
            SqlParameter[] parameters = {
					new SqlParameter("@ut_id", SqlDbType.Int,4)
};
            parameters[0].Value = ut_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
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
        public bool DeleteList(string ut_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_UserTrack ");
            strSql.Append(" where ut_id in (" + ut_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
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
        public Pbzx.Model.Chipped_UserTrack GetModel(int ut_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ut_id,ut_username,ut_Lname,ut_state from Chipped_UserTrack ");
            strSql.Append(" where ut_id=@ut_id");
            SqlParameter[] parameters = {
					new SqlParameter("@ut_id", SqlDbType.Int,4)
};
            parameters[0].Value = ut_id;

            Pbzx.Model.Chipped_UserTrack model = new Pbzx.Model.Chipped_UserTrack();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ut_id"].ToString() != "")
                {
                    model.ut_id = int.Parse(ds.Tables[0].Rows[0]["ut_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ut_username"] != null)
                {
                    model.ut_username = ds.Tables[0].Rows[0]["ut_username"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ut_Lname"].ToString() != "")
                {
                    model.ut_Lname = int.Parse(ds.Tables[0].Rows[0]["ut_Lname"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ut_state"].ToString() != "")
                {
                    model.ut_state = int.Parse(ds.Tables[0].Rows[0]["ut_state"].ToString());
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
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ut_id,ut_username,ut_Lname,ut_state ");
            strSql.Append(" FROM Chipped_UserTrack ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
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
            strSql.Append(" ut_id,ut_username,ut_Lname,ut_state ");
            strSql.Append(" FROM Chipped_UserTrack ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "Chipped_UserTrack";
            parameters[1].Value = "ut_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}
