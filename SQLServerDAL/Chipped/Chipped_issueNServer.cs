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
    /// 数据访问类:Chipped_issueN
    /// </summary>
    public partial class Chipped_issueN : IChipped_issueN
    {
        public Chipped_issueN()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int In_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_issueN");
            strSql.Append(" where In_id=@In_id");
            SqlParameter[] parameters = {
					new SqlParameter("@In_id", SqlDbType.Int,4)
};
            parameters[0].Value = In_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string In_num)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_issueN");
            strSql.Append(" where In_num=@In_num");
            SqlParameter[] parameters = {
					new SqlParameter("@In_num", SqlDbType.NVarChar,100)
};
            parameters[0].Value = In_num;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_issueN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_issueN(");
            strSql.Append("In_RnId,In_num,In_mark,In_issue,In_multiple,In_money,In_state,In_bouns)");
            strSql.Append(" values (");
            strSql.Append("@In_RnId,@In_num,@In_mark,@In_issue,@In_multiple,@In_money,@In_state,@In_bouns)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@In_RnId", SqlDbType.Int,4),
					new SqlParameter("@In_num", SqlDbType.NVarChar,100),
					new SqlParameter("@In_mark", SqlDbType.Int,4),
					new SqlParameter("@In_issue", SqlDbType.NVarChar,50),
					new SqlParameter("@In_multiple", SqlDbType.Int,4),
					new SqlParameter("@In_money", SqlDbType.Decimal,9),
					new SqlParameter("@In_state", SqlDbType.Int,4),
					new SqlParameter("@In_bouns", SqlDbType.Decimal,9)};
            parameters[0].Value = model.In_RnId;
            parameters[1].Value = model.In_num;
            parameters[2].Value = model.In_mark;
            parameters[3].Value = model.In_issue;
            parameters[4].Value = model.In_multiple;
            parameters[5].Value = model.In_money;
            parameters[6].Value = model.In_state;
            parameters[7].Value = model.In_bouns;

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
        public bool Update(Pbzx.Model.Chipped_issueN model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_issueN set ");
            strSql.Append("In_RnId=@In_RnId,");
            strSql.Append("In_num=@In_num,");
            strSql.Append("In_mark=@In_mark,");
            strSql.Append("In_issue=@In_issue,");
            strSql.Append("In_multiple=@In_multiple,");
            strSql.Append("In_money=@In_money,");
            strSql.Append("In_state=@In_state,");
            strSql.Append("In_bouns=@In_bouns");
            strSql.Append(" where In_id=@In_id");
            SqlParameter[] parameters = {
					new SqlParameter("@In_RnId", SqlDbType.Int,4),
					new SqlParameter("@In_num", SqlDbType.NVarChar,100),
					new SqlParameter("@In_mark", SqlDbType.Int,4),
					new SqlParameter("@In_issue", SqlDbType.NVarChar,50),
					new SqlParameter("@In_multiple", SqlDbType.Int,4),
					new SqlParameter("@In_money", SqlDbType.Decimal,9),
					new SqlParameter("@In_state", SqlDbType.Int,4),
					new SqlParameter("@In_bouns", SqlDbType.Decimal,9),
					new SqlParameter("@In_id", SqlDbType.Int,4)};
            parameters[0].Value = model.In_RnId;
            parameters[1].Value = model.In_num;
            parameters[2].Value = model.In_mark;
            parameters[3].Value = model.In_issue;
            parameters[4].Value = model.In_multiple;
            parameters[5].Value = model.In_money;
            parameters[6].Value = model.In_state;
            parameters[7].Value = model.In_bouns;
            parameters[8].Value = model.In_id;
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
        public bool Delete(int In_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_issueN ");
            strSql.Append(" where In_id=@In_id");
            SqlParameter[] parameters = {
					new SqlParameter("@In_id", SqlDbType.Int,4)
};
            parameters[0].Value = In_id;

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
        public bool DeleteRn(int In_RnId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_issueN ");
            strSql.Append(" where In_RnId=@In_RnId");
            SqlParameter[] parameters = {
					new SqlParameter("@In_RnId", SqlDbType.Int,4)
};
            parameters[0].Value = In_RnId;

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
        public bool DeleteList(string In_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_issueN ");
            strSql.Append(" where In_id in (" + In_idlist + ")  ");
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
        public Pbzx.Model.Chipped_issueN GetModel(int In_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 In_id,In_RnId,In_num,In_mark,In_issue,In_multiple,In_money,In_state,In_bouns from Chipped_issueN ");
            strSql.Append(" where In_id=@In_id");
            SqlParameter[] parameters = {
					new SqlParameter("@In_id", SqlDbType.Int,4)
};
            parameters[0].Value = In_id;

            Pbzx.Model.Chipped_issueN model = new Pbzx.Model.Chipped_issueN();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["In_id"].ToString() != "")
                {
                    model.In_id = int.Parse(ds.Tables[0].Rows[0]["In_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["In_RnId"].ToString() != "")
                {
                    model.In_RnId = int.Parse(ds.Tables[0].Rows[0]["In_RnId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["In_num"] != null)
                {
                    model.In_num = ds.Tables[0].Rows[0]["In_num"].ToString();
                }
                if (ds.Tables[0].Rows[0]["In_mark"].ToString() != "")
                {
                    model.In_mark = int.Parse(ds.Tables[0].Rows[0]["In_mark"].ToString());
                }
                if (ds.Tables[0].Rows[0]["In_issue"] != null)
                {
                    model.In_issue = ds.Tables[0].Rows[0]["In_issue"].ToString();
                }
                if (ds.Tables[0].Rows[0]["In_multiple"].ToString() != "")
                {
                    model.In_multiple = int.Parse(ds.Tables[0].Rows[0]["In_multiple"].ToString());
                }
                if (ds.Tables[0].Rows[0]["In_money"].ToString() != "")
                {
                    model.In_money = decimal.Parse(ds.Tables[0].Rows[0]["In_money"].ToString());
                }
                if (ds.Tables[0].Rows[0]["In_state"].ToString() != "")
                {
                    model.In_state = int.Parse(ds.Tables[0].Rows[0]["In_state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["In_bouns"].ToString() != "")
                {
                    model.In_bouns = decimal.Parse(ds.Tables[0].Rows[0]["In_bouns"].ToString());
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
            strSql.Append("select In_id,In_RnId,In_num,In_mark,In_issue,In_multiple,In_money,In_state,In_bouns ");
            strSql.Append(" FROM Chipped_issueN ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListView(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM v_RandomNumIssue ");
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
            strSql.Append(" In_id,In_RnId,In_num,In_mark,In_issue,In_multiple,In_money,In_state,In_bouns ");
            strSql.Append(" FROM Chipped_issueN ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }


        #endregion  Method
    }
}
