using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Challenge_config
    /// </summary>
    public partial class Challenge_config : IChallenge_config
    {
        public Challenge_config()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Challenge_config");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Challenge_config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Challenge_config(");
            strSql.Append("CTime,Complete,agreeRef,lastIP,attState)");
            strSql.Append(" values (");
            strSql.Append("@CTime,@Complete,@agreeRef,@lastIP,@attState)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CTime", SqlDbType.DateTime),
					new SqlParameter("@Complete", SqlDbType.Int,4),
					new SqlParameter("@agreeRef", SqlDbType.Int,4),
					new SqlParameter("@lastIP", SqlDbType.NVarChar,50),
					new SqlParameter("@attState", SqlDbType.NVarChar,20)};
            parameters[0].Value = model.CTime;
            parameters[1].Value = model.Complete;
            parameters[2].Value = model.agreeRef;
            parameters[3].Value = model.lastIP;
            parameters[4].Value = model.attState;

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
        public bool Update(Pbzx.Model.Challenge_config model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Challenge_config set ");
            strSql.Append("CTime=@CTime,");
            strSql.Append("Complete=@Complete,");
            strSql.Append("agreeRef=@agreeRef,");
            strSql.Append("lastIP=@lastIP,");
            strSql.Append("attState=@attState");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@CTime", SqlDbType.DateTime),
					new SqlParameter("@Complete", SqlDbType.Int,4),
					new SqlParameter("@agreeRef", SqlDbType.Int,4),
					new SqlParameter("@lastIP", SqlDbType.NVarChar,50),
					new SqlParameter("@attState", SqlDbType.NVarChar,20),
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = model.CTime;
            parameters[1].Value = model.Complete;
            parameters[2].Value = model.agreeRef;
            parameters[3].Value = model.lastIP;
            parameters[4].Value = model.attState;
            parameters[5].Value = model.id;

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
        public bool Delete(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Challenge_config ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

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
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Challenge_config ");
            strSql.Append(" where id in (" + idlist + ")  ");
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
        public Pbzx.Model.Challenge_config GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,CTime,Complete,agreeRef,lastIP,attState from Challenge_config ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
};
            parameters[0].Value = id;

            Pbzx.Model.Challenge_config model = new Pbzx.Model.Challenge_config();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CTime"].ToString() != "")
                {
                    model.CTime = DateTime.Parse(ds.Tables[0].Rows[0]["CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Complete"].ToString() != "")
                {
                    model.Complete = int.Parse(ds.Tables[0].Rows[0]["Complete"].ToString());
                }
                if (ds.Tables[0].Rows[0]["agreeRef"].ToString() != "")
                {
                    model.agreeRef = int.Parse(ds.Tables[0].Rows[0]["agreeRef"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lastIP"] != null)
                {
                    model.lastIP = ds.Tables[0].Rows[0]["lastIP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["attState"] != null)
                {
                    model.attState = ds.Tables[0].Rows[0]["attState"].ToString();
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Challenge_config GetModelS(string aState)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 id,CTime,Complete,agreeRef,lastIP,attState from Challenge_config ");
            strSql.Append(" where attState=@aState");
            SqlParameter[] parameters = {
					new SqlParameter("@aState", SqlDbType.Int,4)
};
            parameters[0].Value = aState;

            Pbzx.Model.Challenge_config model = new Pbzx.Model.Challenge_config();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["id"].ToString() != "")
                {
                    model.id = int.Parse(ds.Tables[0].Rows[0]["id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CTime"].ToString() != "")
                {
                    model.CTime = DateTime.Parse(ds.Tables[0].Rows[0]["CTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Complete"].ToString() != "")
                {
                    model.Complete = int.Parse(ds.Tables[0].Rows[0]["Complete"].ToString());
                }
                if (ds.Tables[0].Rows[0]["agreeRef"].ToString() != "")
                {
                    model.agreeRef = int.Parse(ds.Tables[0].Rows[0]["agreeRef"].ToString());
                }
                if (ds.Tables[0].Rows[0]["lastIP"] != null)
                {
                    model.lastIP = ds.Tables[0].Rows[0]["lastIP"].ToString();
                }
                if (ds.Tables[0].Rows[0]["attState"] != null)
                {
                    model.attState = ds.Tables[0].Rows[0]["attState"].ToString();
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
            strSql.Append("select id,CTime,Complete,agreeRef,lastIP,attState ");
            strSql.Append(" FROM Challenge_config ");
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
            strSql.Append(" id,CTime,Complete,agreeRef,lastIP,attState ");
            strSql.Append(" FROM Challenge_config ");
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
            parameters[0].Value = "Challenge_config";
            parameters[1].Value = "id";
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

