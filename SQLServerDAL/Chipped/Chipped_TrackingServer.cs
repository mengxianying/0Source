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
    /// 数据访问类Chipped_Tracking。
    /// </summary>
    public class Chipped_Tracking : IChipped_Tracking
    {
        public Chipped_Tracking()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_Tracking");
            strSql.Append(" where TID=@TID");
            SqlParameter[] parameters = {
					new SqlParameter("@TID", SqlDbType.Int,4)
};
            parameters[0].Value = TID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_Tracking model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_Tracking(");
            strSql.Append("TName,Tplay,TPeriod,TorderNum,Tstate)");
            strSql.Append(" values (");
            strSql.Append("@TName,@Tplay,@TPeriod,@TorderNum,@Tstate)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TName", SqlDbType.NVarChar,50),
					new SqlParameter("@Tplay", SqlDbType.Int,4),
					new SqlParameter("@TPeriod", SqlDbType.Int,4),
					new SqlParameter("@TorderNum", SqlDbType.NVarChar,100),
					new SqlParameter("@Tstate", SqlDbType.Int,4)};
            parameters[0].Value = model.TName;
            parameters[1].Value = model.Tplay;
            parameters[2].Value = model.TPeriod;
            parameters[3].Value = model.TorderNum;
            parameters[4].Value = model.Tstate;

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
        public bool Update(Pbzx.Model.Chipped_Tracking model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_Tracking set ");
            strSql.Append("TName=@TName,");
            strSql.Append("Tplay=@Tplay,");
            strSql.Append("TPeriod=@TPeriod,");
            strSql.Append("TorderNum=@TorderNum,");
            strSql.Append("Tstate=@Tstate");
            strSql.Append(" where TID=@TID");
            SqlParameter[] parameters = {
					new SqlParameter("@TName", SqlDbType.NVarChar,50),
					new SqlParameter("@Tplay", SqlDbType.Int,4),
					new SqlParameter("@TPeriod", SqlDbType.Int,4),
					new SqlParameter("@TorderNum", SqlDbType.NVarChar,100),
					new SqlParameter("@Tstate", SqlDbType.Int,4),
					new SqlParameter("@TID", SqlDbType.Int,4)};
            parameters[0].Value = model.TName;
            parameters[1].Value = model.Tplay;
            parameters[2].Value = model.TPeriod;
            parameters[3].Value = model.TorderNum;
            parameters[4].Value = model.Tstate;
            parameters[5].Value = model.TID;

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
        public bool Delete(int TID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_Tracking ");
            strSql.Append(" where TID=@TID");
            SqlParameter[] parameters = {
					new SqlParameter("@TID", SqlDbType.Int,4)
};
            parameters[0].Value = TID;

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
        public bool DeleteList(string TIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_Tracking ");
            strSql.Append(" where TID in (" + TIDlist + ")  ");
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
        public Pbzx.Model.Chipped_Tracking GetModel(int TID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 TID,TName,Tplay,TPeriod,TorderNum,Tstate from Chipped_Tracking ");
            strSql.Append(" where TID=@TID");
            SqlParameter[] parameters = {
					new SqlParameter("@TID", SqlDbType.Int,4)
};
            parameters[0].Value = TID;

            Pbzx.Model.Chipped_Tracking model = new Pbzx.Model.Chipped_Tracking();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["TID"].ToString() != "")
                {
                    model.TID = int.Parse(ds.Tables[0].Rows[0]["TID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TName"] != null)
                {
                    model.TName = ds.Tables[0].Rows[0]["TName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tplay"].ToString() != "")
                {
                    model.Tplay = int.Parse(ds.Tables[0].Rows[0]["Tplay"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TPeriod"].ToString() != "")
                {
                    model.TPeriod = int.Parse(ds.Tables[0].Rows[0]["TPeriod"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TorderNum"] != null)
                {
                    model.TorderNum = ds.Tables[0].Rows[0]["TorderNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Tstate"].ToString() != "")
                {
                    model.Tstate = int.Parse(ds.Tables[0].Rows[0]["Tstate"].ToString());
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
            strSql.Append("select TID,TName,Tplay,TPeriod,TorderNum,Tstate ");
            strSql.Append(" FROM Chipped_Tracking ");
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
            strSql.Append(" TID,TName,Tplay,TPeriod,TorderNum,Tstate ");
            strSql.Append(" FROM Chipped_Tracking ");
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
            parameters[0].Value = "Chipped_Tracking";
            parameters[1].Value = "TID";
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