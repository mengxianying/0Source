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
    /// 数据访问类Note_LotteryType。
    /// </summary>
    public class Note_LotteryType : INote_LotteryType
    {
        public Note_LotteryType()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Note_LotteryType");
            strSql.Append(" where SID= @SID");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4)
				};
            parameters[0].Value = SID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Note_LotteryType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Note_LotteryType(");
            strSql.Append("SName,PriceContent,Explain,Ispublic,BeginTime,UpTime,IssueWeek,IssueTime)");
            strSql.Append(" values (");
            strSql.Append("@SName,@PriceContent,@Explain,@Ispublic,@BeginTime,@UpTime,@IssueWeek,@IssueTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@SName", SqlDbType.NVarChar),
					new SqlParameter("@PriceContent", SqlDbType.NVarChar),
					new SqlParameter("@Explain", SqlDbType.NVarChar),
					new SqlParameter("@Ispublic", SqlDbType.Bit,1),
                    new SqlParameter("@BeginTime",SqlDbType.DateTime),
                    new SqlParameter("@UpTime",SqlDbType.DateTime),
                    new SqlParameter("@IssueWeek",SqlDbType.VarChar),
                    new SqlParameter("@IssueTime",SqlDbType.VarChar)};
            parameters[0].Value = model.SName;
            parameters[1].Value = model.PriceContent;
            parameters[2].Value = model.Explain;
            parameters[3].Value = model.Ispublic;
            parameters[4].Value = model.BeginTime;
            parameters[5].Value = model.UpTime;
            parameters[6].Value = model.IssueWeek;
            parameters[7].Value = model.IssueTime;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Note_LotteryType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Note_LotteryType set ");
            strSql.Append("SName=@SName,");
            strSql.Append("PriceContent=@PriceContent,");
            strSql.Append("Explain=@Explain,");
            strSql.Append("Ispublic=@Ispublic ,");
            strSql.Append("BeginTime=@BeginTime ,");
            strSql.Append("UpTime=@UpTime,");
            strSql.Append("IssueWeek=@IssueWeek,");
            strSql.Append("IssueTime=@IssueTime");
            strSql.Append(" where SID=@SID");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@SName", SqlDbType.NVarChar),
					new SqlParameter("@PriceContent", SqlDbType.NVarChar),
					new SqlParameter("@Explain", SqlDbType.NVarChar),
					new SqlParameter("@Ispublic", SqlDbType.Bit,1),
                    new SqlParameter("@BeginTime",SqlDbType.DateTime),
                    new SqlParameter("@UpTime",SqlDbType.DateTime),
                    new SqlParameter("@IssueWeek",SqlDbType.VarChar),
                    new SqlParameter("@IssueTime",SqlDbType.VarChar)};
            parameters[0].Value = model.SID;
            parameters[1].Value = model.SName;
            parameters[2].Value = model.PriceContent;
            parameters[3].Value = model.Explain;
            parameters[4].Value = model.Ispublic;
            parameters[5].Value = model.BeginTime;
            parameters[6].Value = model.UpTime;
            parameters[7].Value = model.IssueWeek;
            parameters[8].Value = model.IssueTime;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int SID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Note_LotteryType ");
            strSql.Append(" where SID=@SID");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4)
				};
            parameters[0].Value = SID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Note_LotteryType GetModel(int SID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Note_LotteryType ");
            strSql.Append(" where SID=@SID");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4)};
            parameters[0].Value = SID;
            Pbzx.Model.Note_LotteryType model = null;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model = new Pbzx.Model.Note_LotteryType();
                model.SID = SID;
                model.SName = ds.Tables[0].Rows[0]["SName"].ToString();
                model.PriceContent = ds.Tables[0].Rows[0]["PriceContent"].ToString();
                model.Explain = ds.Tables[0].Rows[0]["Explain"].ToString();
                model.BeginTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["BeginTime"]);
                model.UpTime = Convert.ToDateTime(ds.Tables[0].Rows[0]["UpTime"]);
                model.IssueWeek = ds.Tables[0].Rows[0]["IssueWeek"].ToString();
                model.IssueTime = ds.Tables[0].Rows[0]["IssueTime"].ToString();
                if (ds.Tables[0].Rows[0]["Ispublic"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["Ispublic"].ToString() == "1") || (ds.Tables[0].Rows[0]["Ispublic"].ToString().ToLower() == "true"))
                    {
                        model.Ispublic = true;
                    }
                    else
                    {
                        model.Ispublic = false;
                    }
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
            strSql.Append("select * from Note_LotteryType ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by SID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
