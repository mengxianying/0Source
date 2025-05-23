using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using Pbzx.IDAL;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:PBnet_platfrom_icon
    /// </summary>
    public partial class PBnet_platfrom_icon : IPBnet_platfrom_icon
    {
        public PBnet_platfrom_icon()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int p_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_platfrom_icon");
            strSql.Append(" where p_id=@p_id");
            SqlParameter[] parameters = {
					new SqlParameter("@p_id", SqlDbType.Int,4)
};
            parameters[0].Value = p_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string P_pfName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_platfrom_icon");
            strSql.Append(" where P_pfName=@P_pfName");
            SqlParameter[] parameters = {
					new SqlParameter("@P_pfName", SqlDbType.NVarChar,50)
};
            parameters[0].Value = P_pfName;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_platfrom_icon model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_platfrom_icon(");
            strSql.Append("p_imgName,P_pfPath,P_pfName,P_Sort,P_state)");
            strSql.Append(" values (");
            strSql.Append("@p_imgName,@P_pfPath,@P_pfName,@P_Sort,@P_state)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@p_imgName", SqlDbType.NVarChar,50),
					new SqlParameter("@P_pfPath", SqlDbType.NVarChar,100),
					new SqlParameter("@P_pfName", SqlDbType.NVarChar,50),
					new SqlParameter("@P_Sort", SqlDbType.Int,4),
					new SqlParameter("@P_state", SqlDbType.Int,4)};
            parameters[0].Value = model.p_imgName;
            parameters[1].Value = model.P_pfPath;
            parameters[2].Value = model.P_pfName;
            parameters[3].Value = model.P_Sort;
            parameters[4].Value = model.P_state;

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
        public bool Update(Pbzx.Model.PBnet_platfrom_icon model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_platfrom_icon set ");
            strSql.Append("p_imgName=@p_imgName,");
            strSql.Append("P_pfPath=@P_pfPath,");
            strSql.Append("P_pfName=@P_pfName,");
            strSql.Append("P_Sort=@P_Sort,");
            strSql.Append("P_state=@P_state");
            strSql.Append(" where p_id=@p_id");
            SqlParameter[] parameters = {
					new SqlParameter("@p_imgName", SqlDbType.NVarChar,50),
					new SqlParameter("@P_pfPath", SqlDbType.NVarChar,100),
					new SqlParameter("@P_pfName", SqlDbType.NVarChar,50),
					new SqlParameter("@P_Sort", SqlDbType.Int,4),
					new SqlParameter("@P_state", SqlDbType.Int,4),
					new SqlParameter("@p_id", SqlDbType.Int,4)};
            parameters[0].Value = model.p_imgName;
            parameters[1].Value = model.P_pfPath;
            parameters[2].Value = model.P_pfName;
            parameters[3].Value = model.P_Sort;
            parameters[4].Value = model.P_state;
            parameters[5].Value = model.p_id;

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
        public bool Delete(int p_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_platfrom_icon ");
            strSql.Append(" where p_id=@p_id");
            SqlParameter[] parameters = {
					new SqlParameter("@p_id", SqlDbType.Int,4)
};
            parameters[0].Value = p_id;

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
        public bool DeleteList(string p_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_platfrom_icon ");
            strSql.Append(" where p_id in (" + p_idlist + ")  ");
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
        public Pbzx.Model.PBnet_platfrom_icon GetModel(int p_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 p_id,p_imgName,P_pfPath,P_pfName,P_Sort,P_state from PBnet_platfrom_icon ");
            strSql.Append(" where p_id=@p_id");
            SqlParameter[] parameters = {
					new SqlParameter("@p_id", SqlDbType.Int,4)
};
            parameters[0].Value = p_id;

            Pbzx.Model.PBnet_platfrom_icon model = new Pbzx.Model.PBnet_platfrom_icon();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["p_id"].ToString() != "")
                {
                    model.p_id = int.Parse(ds.Tables[0].Rows[0]["p_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["p_imgName"] != null)
                {
                    model.p_imgName = ds.Tables[0].Rows[0]["p_imgName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["P_pfPath"] != null)
                {
                    model.P_pfPath = ds.Tables[0].Rows[0]["P_pfPath"].ToString();
                }
                if (ds.Tables[0].Rows[0]["P_pfName"] != null)
                {
                    model.P_pfName = ds.Tables[0].Rows[0]["P_pfName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["P_Sort"].ToString() != "")
                {
                    model.P_Sort = int.Parse(ds.Tables[0].Rows[0]["P_Sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["P_state"].ToString() != "")
                {
                    model.P_state = int.Parse(ds.Tables[0].Rows[0]["P_state"].ToString());
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
            strSql.Append("select p_id,p_imgName,P_pfPath,P_pfName,P_Sort,P_state ");
            strSql.Append(" FROM PBnet_platfrom_icon ");
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
            strSql.Append(" p_id,p_imgName,P_pfPath,P_pfName,P_Sort,P_state ");
            strSql.Append(" FROM PBnet_platfrom_icon ");
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
            parameters[0].Value = "PBnet_platfrom_icon";
            parameters[1].Value = "p_id";
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

