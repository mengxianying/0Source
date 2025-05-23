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
    /// 数据访问类Chipped_bounsAllost。
    /// </summary>
    public class Chipped_bounsAllost
    {
        public Chipped_bounsAllost()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "Chipped_bounsAllost");
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string AwardNum, string AwardName, int lotteryState)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_bounsAllost");
            strSql.Append(" where AwardNum= @AwardNum");
            strSql.Append(" and AwardName=@AwardName");
            strSql.Append(" and lotteryState=@lotteryState");
            SqlParameter[] parameters = {
					new SqlParameter("@AwardNum", SqlDbType.NVarChar,50),
                    new SqlParameter("@AwardName",SqlDbType.NVarChar,50),
                    new SqlParameter("@lotteryState",SqlDbType.Int,4)
				};
            parameters[0].Value = AwardNum;
            parameters[1].Value = AwardName;
            parameters[2].Value = lotteryState;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_bounsAllost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_bounsAllost(");
            strSql.Append("AwardNum,AwardName,lotteryState,bounsAllost,AssignState,ATime)");
            strSql.Append(" values (");
            strSql.Append("@AwardNum,@AwardName,@lotteryState,@bounsAllost,@AssignState,@ATime)");
            SqlParameter[] parameters = {
					new SqlParameter("@AwardNum", SqlDbType.NVarChar),
					new SqlParameter("@AwardName", SqlDbType.NVarChar),
					new SqlParameter("@lotteryState", SqlDbType.Int,4),
					new SqlParameter("@bounsAllost", SqlDbType.Decimal,9),
					new SqlParameter("@AssignState", SqlDbType.Int,4),
					new SqlParameter("@ATime", SqlDbType.DateTime)};
            parameters[0].Value = model.AwardNum;
            parameters[1].Value = model.AwardName;
            parameters[2].Value = model.lotteryState;
            parameters[3].Value = model.bounsAllost;
            parameters[4].Value = model.AssignState;
            parameters[5].Value = model.ATime;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
             
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.Chipped_bounsAllost model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_bounsAllost set ");
            strSql.Append("AwardNum=@AwardNum,");
            strSql.Append("AwardName=@AwardName,");
            strSql.Append("lotteryState=@lotteryState,");
            strSql.Append("bounsAllost=@bounsAllost,");
            strSql.Append("AssignState=@AssignState,");
            strSql.Append("ATime=@ATime");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@AwardNum", SqlDbType.NVarChar),
					new SqlParameter("@AwardName", SqlDbType.NVarChar),
					new SqlParameter("@lotteryState", SqlDbType.Int,4),
					new SqlParameter("@bounsAllost", SqlDbType.Decimal,9),
					new SqlParameter("@AssignState", SqlDbType.Int,4),
					new SqlParameter("@ATime", SqlDbType.DateTime)};
            parameters[0].Value = model.AwardNum;
            parameters[1].Value = model.AwardName;
            parameters[2].Value = model.lotteryState;
            parameters[3].Value = model.bounsAllost;
            parameters[4].Value = model.AssignState;
            parameters[5].Value = model.ATime;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string AwardNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Chipped_bounsAllost ");
            strSql.Append(" where AwardNum=@AwardNum");
            SqlParameter[] parameters = {
					new SqlParameter("@AwardNum", SqlDbType.NVarChar,50)
				};
            parameters[0].Value = AwardNum;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Chipped_bounsAllost GetModel(string AwardNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Chipped_bounsAllost ");
            strSql.Append(" where AwardNum=@AwardNum");
            SqlParameter[] parameters = {
					new SqlParameter("@AwardNum", SqlDbType.NVarChar,50)};
            parameters[0].Value = AwardNum;
            Pbzx.Model.Chipped_bounsAllost model = new Pbzx.Model.Chipped_bounsAllost();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.AwardNum = ds.Tables[0].Rows[0]["AwardNum"].ToString();
                model.AwardName = ds.Tables[0].Rows[0]["AwardName"].ToString();
                if (ds.Tables[0].Rows[0]["lotteryState"].ToString() != "")
                {
                    model.lotteryState = int.Parse(ds.Tables[0].Rows[0]["lotteryState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bounsAllost"].ToString() != "")
                {
                    model.bounsAllost = decimal.Parse(ds.Tables[0].Rows[0]["bounsAllost"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AssignState"].ToString() != "")
                {
                    model.AssignState = int.Parse(ds.Tables[0].Rows[0]["AssignState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ATime"].ToString() != "")
                {
                    model.ATime = DateTime.Parse(ds.Tables[0].Rows[0]["ATime"].ToString());
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
            strSql.Append("select * from Chipped_bounsAllost ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
