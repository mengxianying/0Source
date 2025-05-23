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
    /// 数据访问类:Chipped_cofig
    /// </summary>
    public partial class Chipped_cofig : IChipped_cofig
    {
        public Chipped_cofig()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int cfg_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_cofig");
            strSql.Append(" where cfg_id=@cfg_id");
            SqlParameter[] parameters = {
					new SqlParameter("@cfg_id", SqlDbType.Int,4)
};
            parameters[0].Value = cfg_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ExistsState(int cfg_state)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_cofig");
            strSql.Append(" where cfg_state=@cfg_state");
            SqlParameter[] parameters = {
					new SqlParameter("@cfg_state", SqlDbType.Int,4)
};
            parameters[0].Value = cfg_state;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_cofig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_cofig(");
            strSql.Append("cfg_lname,cfg_state,cfg_tarState)");
            strSql.Append(" values (");
            strSql.Append("@cfg_lname,@cfg_state,@cfg_tarState)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@cfg_lname", SqlDbType.NVarChar,50),
					new SqlParameter("@cfg_state", SqlDbType.Int,4),
					new SqlParameter("@cfg_tarState", SqlDbType.Int,4)};
            parameters[0].Value = model.cfg_lname;
            parameters[1].Value = model.cfg_state;
            parameters[2].Value = model.cfg_tarState;

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
        public bool Update(Pbzx.Model.Chipped_cofig model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_cofig set ");
            strSql.Append("cfg_lname=@cfg_lname,");
            strSql.Append("cfg_state=@cfg_state,");
            strSql.Append("cfg_tarState=@cfg_tarState");
            strSql.Append(" where cfg_id=@cfg_id");
            SqlParameter[] parameters = {
					new SqlParameter("@cfg_lname", SqlDbType.NVarChar,50),
					new SqlParameter("@cfg_state", SqlDbType.Int,4),
					new SqlParameter("@cfg_tarState", SqlDbType.Int,4),
					new SqlParameter("@cfg_id", SqlDbType.Int,4)};
            parameters[0].Value = model.cfg_lname;
            parameters[1].Value = model.cfg_state;
            parameters[2].Value = model.cfg_tarState;
            parameters[3].Value = model.cfg_id;

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
        public bool Delete(int cfg_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_cofig ");
            strSql.Append(" where cfg_id=@cfg_id");
            SqlParameter[] parameters = {
					new SqlParameter("@cfg_id", SqlDbType.Int,4)
};
            parameters[0].Value = cfg_id;

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
        public bool DeleteList(string cfg_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_cofig ");
            strSql.Append(" where cfg_id in (" + cfg_idlist + ")  ");
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
        public Pbzx.Model.Chipped_cofig GetModel(int cfg_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 cfg_id,cfg_lname,cfg_state,cfg_tarState from Chipped_cofig ");
            strSql.Append(" where cfg_id=@cfg_id");
            SqlParameter[] parameters = {
					new SqlParameter("@cfg_id", SqlDbType.Int,4)
};
            parameters[0].Value = cfg_id;

            Pbzx.Model.Chipped_cofig model = new Pbzx.Model.Chipped_cofig();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["cfg_id"].ToString() != "")
                {
                    model.cfg_id = int.Parse(ds.Tables[0].Rows[0]["cfg_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cfg_lname"] != null)
                {
                    model.cfg_lname = ds.Tables[0].Rows[0]["cfg_lname"].ToString();
                }
                if (ds.Tables[0].Rows[0]["cfg_state"].ToString() != "")
                {
                    model.cfg_state = int.Parse(ds.Tables[0].Rows[0]["cfg_state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["cfg_tarState"].ToString() != "")
                {
                    model.cfg_tarState = int.Parse(ds.Tables[0].Rows[0]["cfg_tarState"].ToString());
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
            strSql.Append("select cfg_id,cfg_lname,cfg_state,cfg_tarState ");
            strSql.Append(" FROM Chipped_cofig ");
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
            strSql.Append(" cfg_id,cfg_lname,cfg_state,cfg_tarState ");
            strSql.Append(" FROM Chipped_cofig ");
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
            parameters[0].Value = "Chipped_cofig";
            parameters[1].Value = "cfg_id";
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
