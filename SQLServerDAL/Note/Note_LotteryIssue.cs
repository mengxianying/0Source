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
    /// 数据访问类Note_LotteryIssue。
    /// </summary>
    public class Note_LotteryIssue : INote_LotteryIssue
    {
        public Note_LotteryIssue()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Note_LotteryIssue");
            strSql.Append(" where ID= @ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Pbzx.Model.Note_LotteryIssue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Note_LotteryIssue(");
            strSql.Append("SID,QNumber,Content,BeginTime,IsSend)");
            strSql.Append(" values (");
            strSql.Append("@SID,@QNumber,@Content,@BeginTime,@IsSend)");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@QNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Content", SqlDbType.VarChar,225),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
                    new SqlParameter("@IsSend",SqlDbType.Int)};
            parameters[0].Value = model.SID;
            parameters[1].Value = model.QNumber;
            parameters[2].Value = model.Content;
            parameters[3].Value = model.BeginTime;
            parameters[4].Value = model.IsSend;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.Note_LotteryIssue model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Note_LotteryIssue set ");
            strSql.Append("SID=@SID,");
            strSql.Append("QNumber=@QNumber,");
            strSql.Append("Content=@Content,");
            strSql.Append("BeginTime=@BeginTime,");
            strSql.Append("IsSend=@IsSend");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@QNumber", SqlDbType.VarChar,50),
					new SqlParameter("@Content", SqlDbType.VarChar,225),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
                    new SqlParameter("@IsSend",SqlDbType.Int)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SID;
            parameters[2].Value = model.QNumber;
            parameters[3].Value = model.Content;
            parameters[4].Value = model.BeginTime;
            parameters[5].Value = model.IsSend;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Note_LotteryIssue ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Note_LotteryIssue GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Note_LotteryIssue ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            Pbzx.Model.Note_LotteryIssue model = new Pbzx.Model.Note_LotteryIssue();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SID"].ToString() != "")
                {
                    model.SID = int.Parse(ds.Tables[0].Rows[0]["SID"].ToString());
                }
                model.QNumber = ds.Tables[0].Rows[0]["QNumber"].ToString();
                model.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                if (ds.Tables[0].Rows[0]["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginTime"].ToString());
                }
                model.IsSend = Convert.ToInt32(ds.Tables[0].Rows[0]["IsSend"].ToString());
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
            strSql.Append("select * from Note_LotteryIssue ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID  desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
