using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:PBnet_PayAtt
    /// </summary>
    public partial class PBnet_PayAtt : IPBnet_PayAtt
    {
        public PBnet_PayAtt()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("Pa_id", "PBnet_PayAtt");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Pa_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_PayAtt");
            strSql.Append(" where Pa_id=@Pa_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Pa_id", SqlDbType.Int,4)};
            parameters[0].Value = Pa_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string Pa_Idol, string Pa_fans, string Pa_PSign)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_PayAtt");
            strSql.Append(" where Pa_Idol=@Pa_Idol and Pa_fans=@Pa_fans and Pa_PSign=@Pa_PSign");
            SqlParameter[] parameters = {
					new SqlParameter("@Pa_Idol", SqlDbType.NVarChar,50),
                    new SqlParameter("@Pa_fans", SqlDbType.NVarChar,50),
                    new SqlParameter("@Pa_PSign", SqlDbType.NVarChar,50)};
            parameters[0].Value = Pa_Idol;
            parameters[1].Value = Pa_fans;
            parameters[2].Value = Pa_PSign;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_PayAtt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_PayAtt(");
            strSql.Append("Pa_fans,Pa_time,Pa_Idol,Pa_PSign,Pa_state)");
            strSql.Append(" values (");
            strSql.Append("@Pa_fans,@Pa_time,@Pa_Idol,@Pa_PSign,@Pa_state)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Pa_fans", SqlDbType.NVarChar,50),
					new SqlParameter("@Pa_time", SqlDbType.DateTime),
					new SqlParameter("@Pa_Idol", SqlDbType.NVarChar,50),
					new SqlParameter("@Pa_PSign", SqlDbType.NVarChar,50),
					new SqlParameter("@Pa_state", SqlDbType.Int,4)};
            parameters[0].Value = model.Pa_fans;
            parameters[1].Value = model.Pa_time;
            parameters[2].Value = model.Pa_Idol;
            parameters[3].Value = model.Pa_PSign;
            parameters[4].Value = model.Pa_state;

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
        public bool Update(Pbzx.Model.PBnet_PayAtt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_PayAtt set ");
            strSql.Append("Pa_fans=@Pa_fans,");
            strSql.Append("Pa_time=@Pa_time,");
            strSql.Append("Pa_Idol=@Pa_Idol,");
            strSql.Append("Pa_PSign=@Pa_PSign,");
            strSql.Append("Pa_state=@Pa_state");
            strSql.Append(" where Pa_id=@Pa_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Pa_fans", SqlDbType.NVarChar,50),
					new SqlParameter("@Pa_time", SqlDbType.DateTime),
					new SqlParameter("@Pa_Idol", SqlDbType.NVarChar,50),
					new SqlParameter("@Pa_PSign", SqlDbType.NVarChar,50),
					new SqlParameter("@Pa_state", SqlDbType.Int,4),
					new SqlParameter("@Pa_id", SqlDbType.Int,4)};
            parameters[0].Value = model.Pa_fans;
            parameters[1].Value = model.Pa_time;
            parameters[2].Value = model.Pa_Idol;
            parameters[3].Value = model.Pa_PSign;
            parameters[4].Value = model.Pa_state;
            parameters[5].Value = model.Pa_id;

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
        public bool Delete(int Pa_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_PayAtt ");
            strSql.Append(" where Pa_id=@Pa_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Pa_id", SqlDbType.Int,4)};
            parameters[0].Value = Pa_id;

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
        public bool DeleteList(string Pa_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_PayAtt ");
            strSql.Append(" where Pa_id in (" + Pa_idlist + ")  ");
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
        public Pbzx.Model.PBnet_PayAtt GetModel(int Pa_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Pa_id,Pa_fans,Pa_time,Pa_Idol,Pa_PSign,Pa_state from PBnet_PayAtt ");
            strSql.Append(" where Pa_id=@Pa_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Pa_id", SqlDbType.Int,4)};
            parameters[0].Value = Pa_id;

            Pbzx.Model.PBnet_PayAtt model = new Pbzx.Model.PBnet_PayAtt();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Pa_id"].ToString() != "")
                {
                    model.Pa_id = int.Parse(ds.Tables[0].Rows[0]["Pa_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pa_fans"] != null)
                {
                    model.Pa_fans = ds.Tables[0].Rows[0]["Pa_fans"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pa_time"].ToString() != "")
                {
                    model.Pa_time = DateTime.Parse(ds.Tables[0].Rows[0]["Pa_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Pa_Idol"] != null)
                {
                    model.Pa_Idol = ds.Tables[0].Rows[0]["Pa_Idol"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pa_PSign"] != null)
                {
                    model.Pa_PSign = ds.Tables[0].Rows[0]["Pa_PSign"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Pa_state"].ToString() != "")
                {
                    model.Pa_state = int.Parse(ds.Tables[0].Rows[0]["Pa_state"].ToString());
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
            strSql.Append("select Pa_id,Pa_fans,Pa_time,Pa_Idol,Pa_PSign,Pa_state ");
            strSql.Append(" FROM PBnet_PayAtt ");
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
            strSql.Append(" Pa_id,Pa_fans,Pa_time,Pa_Idol,Pa_PSign,Pa_state ");
            strSql.Append(" FROM PBnet_PayAtt ");
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
            parameters[0].Value = "PBnet_PayAtt";
            parameters[1].Value = "Pa_id";
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

