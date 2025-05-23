using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Pbzx.IDAL;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Chipped_TrackNum
    /// </summary>
    public partial class Chipped_TrackNum : IChipped_TrackNum
    {
        public Chipped_TrackNum()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("tn_id", "Chipped_TrackNum");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int tn_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_TrackNum");
            strSql.Append(" where tn_id=@tn_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@tn_id", SqlDbType.Int,4)};
            parameters[0].Value = tn_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_TrackNum model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_TrackNum(");
            strSql.Append("tn_orderNum,tn_username,tn_playname,tn_stopCondition,tn_issue,tn_num,tn_multiple,tn_money,tn_message,tn_time,tn_complete,tn_Inward,tn_order,tn_open,tn_dtbt)");
            strSql.Append(" values (");
            strSql.Append("@tn_orderNum,@tn_username,@tn_playname,@tn_stopCondition,@tn_issue,@tn_num,@tn_multiple,@tn_money,@tn_message,@tn_time,@tn_complete,@tn_Inward,@tn_order,@tn_open,@tn_dtbt)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@tn_orderNum", SqlDbType.NVarChar,200),
					new SqlParameter("@tn_username", SqlDbType.NVarChar,50),
					new SqlParameter("@tn_playname", SqlDbType.Int,4),
					new SqlParameter("@tn_stopCondition", SqlDbType.NVarChar,50),
					new SqlParameter("@tn_issue", SqlDbType.NVarChar,100),
					new SqlParameter("@tn_num", SqlDbType.NText),
					new SqlParameter("@tn_multiple", SqlDbType.Int,4),
					new SqlParameter("@tn_money", SqlDbType.Decimal,9),
					new SqlParameter("@tn_message", SqlDbType.Int,4),
					new SqlParameter("@tn_time", SqlDbType.DateTime),
					new SqlParameter("@tn_complete", SqlDbType.Int,4),
					new SqlParameter("@tn_Inward", SqlDbType.Decimal,9),
					new SqlParameter("@tn_order", SqlDbType.NVarChar,50),
					new SqlParameter("@tn_open", SqlDbType.Int,4),
					new SqlParameter("@tn_dtbt", SqlDbType.Int,4)};
            parameters[0].Value = model.tn_orderNum;
            parameters[1].Value = model.tn_username;
            parameters[2].Value = model.tn_playname;
            parameters[3].Value = model.tn_stopCondition;
            parameters[4].Value = model.tn_issue;
            parameters[5].Value = model.tn_num;
            parameters[6].Value = model.tn_multiple;
            parameters[7].Value = model.tn_money;
            parameters[8].Value = model.tn_message;
            parameters[9].Value = model.tn_time;
            parameters[10].Value = model.tn_complete;
            parameters[11].Value = model.tn_Inward;
            parameters[12].Value = model.tn_order;
            parameters[13].Value = model.tn_open;
            parameters[14].Value = model.tn_dtbt;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Chipped_TrackNum model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_TrackNum set ");
            strSql.Append("tn_orderNum=@tn_orderNum,");
            strSql.Append("tn_username=@tn_username,");
            strSql.Append("tn_playname=@tn_playname,");
            strSql.Append("tn_stopCondition=@tn_stopCondition,");
            strSql.Append("tn_issue=@tn_issue,");
            strSql.Append("tn_num=@tn_num,");
            strSql.Append("tn_multiple=@tn_multiple,");
            strSql.Append("tn_money=@tn_money,");
            strSql.Append("tn_message=@tn_message,");
            strSql.Append("tn_time=@tn_time,");
            strSql.Append("tn_complete=@tn_complete,");
            strSql.Append("tn_Inward=@tn_Inward,");
            strSql.Append("tn_order=@tn_order,");
            strSql.Append("tn_open=@tn_open,");
            strSql.Append("tn_dtbt=@tn_dtbt");
            strSql.Append(" where tn_id=@tn_id");
            SqlParameter[] parameters = {
					new SqlParameter("@tn_orderNum", SqlDbType.NVarChar,200),
					new SqlParameter("@tn_username", SqlDbType.NVarChar,50),
					new SqlParameter("@tn_playname", SqlDbType.Int,4),
					new SqlParameter("@tn_stopCondition", SqlDbType.NVarChar,50),
					new SqlParameter("@tn_issue", SqlDbType.NVarChar,100),
					new SqlParameter("@tn_num", SqlDbType.NText),
					new SqlParameter("@tn_multiple", SqlDbType.Int,4),
					new SqlParameter("@tn_money", SqlDbType.Decimal,9),
					new SqlParameter("@tn_message", SqlDbType.Int,4),
					new SqlParameter("@tn_time", SqlDbType.DateTime),
					new SqlParameter("@tn_complete", SqlDbType.Int,4),
					new SqlParameter("@tn_Inward", SqlDbType.Decimal,9),
					new SqlParameter("@tn_order", SqlDbType.NVarChar,50),
					new SqlParameter("@tn_open", SqlDbType.Int,4),
					new SqlParameter("@tn_dtbt", SqlDbType.Int,4),
					new SqlParameter("@tn_id", SqlDbType.Int,4)};
            parameters[0].Value = model.tn_orderNum;
            parameters[1].Value = model.tn_username;
            parameters[2].Value = model.tn_playname;
            parameters[3].Value = model.tn_stopCondition;
            parameters[4].Value = model.tn_issue;
            parameters[5].Value = model.tn_num;
            parameters[6].Value = model.tn_multiple;
            parameters[7].Value = model.tn_money;
            parameters[8].Value = model.tn_message;
            parameters[9].Value = model.tn_time;
            parameters[10].Value = model.tn_complete;
            parameters[11].Value = model.tn_Inward;
            parameters[12].Value = model.tn_order;
            parameters[13].Value = model.tn_open;
            parameters[14].Value = model.tn_dtbt;
            parameters[15].Value = model.tn_id;

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
        public bool Delete(int tn_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_TrackNum ");
            strSql.Append(" where tn_id=@tn_id ");
            SqlParameter[] parameters = {
					new SqlParameter("@tn_id", SqlDbType.Int,4)};
            parameters[0].Value = tn_id;

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
        public bool DeleteList(string tn_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_TrackNum ");
            strSql.Append(" where tn_id in (" + tn_idlist + ")  ");
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
        public Pbzx.Model.Chipped_TrackNum GetModel(int tn_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 tn_id,tn_orderNum,tn_username,tn_playname,tn_stopCondition,tn_issue,tn_num,tn_multiple,tn_money,tn_message,tn_time,tn_complete,tn_Inward,tn_order,tn_open,tn_dtbt from Chipped_TrackNum ");
            strSql.Append(" where tn_id=@tn_id");
            SqlParameter[] parameters = {
					new SqlParameter("@tn_id", SqlDbType.Int,4)
};
            parameters[0].Value = tn_id;

            Pbzx.Model.Chipped_TrackNum model = new Pbzx.Model.Chipped_TrackNum();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["tn_id"].ToString() != "")
                {
                    model.tn_id = int.Parse(ds.Tables[0].Rows[0]["tn_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tn_orderNum"] != null)
                {
                    model.tn_orderNum = ds.Tables[0].Rows[0]["tn_orderNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["tn_username"] != null)
                {
                    model.tn_username = ds.Tables[0].Rows[0]["tn_username"].ToString();
                }
                if (ds.Tables[0].Rows[0]["tn_playname"].ToString() != "")
                {
                    model.tn_playname = int.Parse(ds.Tables[0].Rows[0]["tn_playname"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tn_stopCondition"] != null)
                {
                    model.tn_stopCondition = ds.Tables[0].Rows[0]["tn_stopCondition"].ToString();
                }
                if (ds.Tables[0].Rows[0]["tn_issue"] != null)
                {
                    model.tn_issue = ds.Tables[0].Rows[0]["tn_issue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["tn_num"] != null)
                {
                    model.tn_num = ds.Tables[0].Rows[0]["tn_num"].ToString();
                }
                if (ds.Tables[0].Rows[0]["tn_multiple"].ToString() != "")
                {
                    model.tn_multiple = int.Parse(ds.Tables[0].Rows[0]["tn_multiple"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tn_money"].ToString() != "")
                {
                    model.tn_money = decimal.Parse(ds.Tables[0].Rows[0]["tn_money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tn_message"].ToString() != "")
                {
                    model.tn_message = int.Parse(ds.Tables[0].Rows[0]["tn_message"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tn_time"].ToString() != "")
                {
                    model.tn_time = DateTime.Parse(ds.Tables[0].Rows[0]["tn_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tn_complete"].ToString() != "")
                {
                    model.tn_complete = int.Parse(ds.Tables[0].Rows[0]["tn_complete"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tn_Inward"].ToString() != "")
                {
                    model.tn_Inward = decimal.Parse(ds.Tables[0].Rows[0]["tn_Inward"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tn_order"] != null)
                {
                    model.tn_order = ds.Tables[0].Rows[0]["tn_order"].ToString();
                }
                if (ds.Tables[0].Rows[0]["tn_open"].ToString() != "")
                {
                    model.tn_open = int.Parse(ds.Tables[0].Rows[0]["tn_open"].ToString());
                }
                if (ds.Tables[0].Rows[0]["tn_dtbt"].ToString() != "")
                {
                    model.tn_dtbt = int.Parse(ds.Tables[0].Rows[0]["tn_dtbt"].ToString());
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
            strSql.Append("select tn_id,tn_orderNum,tn_username,tn_playname,tn_stopCondition,tn_issue,tn_num,tn_multiple,tn_money,tn_message,tn_time,tn_complete,tn_Inward,tn_order,tn_open,tn_dtbt ");
            strSql.Append(" FROM Chipped_TrackNum ");
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
            strSql.Append(" tn_id,tn_orderNum,tn_username,tn_playname,tn_stopCondition,tn_issue,tn_num,tn_multiple,tn_money,tn_message,tn_time,tn_complete,tn_Inward,tn_order,tn_open,tn_dtbt ");
            strSql.Append(" FROM Chipped_TrackNum ");
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
            parameters[0].Value = "Chipped_TrackNum";
            parameters[1].Value = "tn_id";
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
