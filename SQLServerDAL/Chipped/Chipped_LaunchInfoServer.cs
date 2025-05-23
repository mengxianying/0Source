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
    public class Chipped_LaunchInfoServer : IChipped_LaunchInfo
    {
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string QNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_LaunchInfo");
            strSql.Append(" where QNumber=@QNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@QNumber", SqlDbType.NVarChar,50)};
            parameters[0].Value = QNumber;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.chipped_LaunchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_LaunchInfo(");
            strSql.Append("QNumber,Title,Say,LaunchTime,playName,ExpectNum,ChoiceNum,UserName,doubles,Share,Object,BuyShare,Protect,opens,Commission,Winning,Purchasing,State,AtotalMoney,bounsAllost)");
            strSql.Append(" values (");
            strSql.Append("@QNumber,@Title,@Say,@LaunchTime,@playName,@ExpectNum,@ChoiceNum,@UserName,@doubles,@Share,@Object,@BuyShare,@Protect,@opens,@Commission,@Winning,@Purchasing,@State,@AtotalMoney,@bounsAllost)");
            SqlParameter[] parameters = {
					new SqlParameter("@QNumber", SqlDbType.NVarChar,100),
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Say", SqlDbType.NVarChar,200),
					new SqlParameter("@LaunchTime", SqlDbType.DateTime),
					new SqlParameter("@playName", SqlDbType.Int,4),
					new SqlParameter("@ExpectNum", SqlDbType.Int,4),
					new SqlParameter("@ChoiceNum", SqlDbType.Text),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@doubles", SqlDbType.Int,4),
					new SqlParameter("@Share", SqlDbType.Int,4),
					new SqlParameter("@Object", SqlDbType.NVarChar,50),
					new SqlParameter("@BuyShare", SqlDbType.Int,4),
					new SqlParameter("@Protect", SqlDbType.Int,4),
					new SqlParameter("@opens", SqlDbType.Int,4),
					new SqlParameter("@Commission", SqlDbType.Int,4),
					new SqlParameter("@Winning", SqlDbType.Int,4),
					new SqlParameter("@Purchasing", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@AtotalMoney", SqlDbType.Decimal,9),
					new SqlParameter("@bounsAllost", SqlDbType.NVarChar,50)};
            parameters[0].Value = model.QNumber;
            parameters[1].Value = model.Title;
            parameters[2].Value = model.Say;
            parameters[3].Value = model.LaunchTime;
            parameters[4].Value = model.playName;
            parameters[5].Value = model.ExpectNum;
            parameters[6].Value = model.ChoiceNum;
            parameters[7].Value = model.UserName;
            parameters[8].Value = model.doubles;
            parameters[9].Value = model.Share;
            parameters[10].Value = model.Object;
            parameters[11].Value = model.BuyShare;
            parameters[12].Value = model.Protect;
            parameters[13].Value = model.opens;
            parameters[14].Value = model.Commission;
            parameters[15].Value = model.Winning;
            parameters[16].Value = model.Purchasing;
            parameters[17].Value = model.State;
            parameters[18].Value = model.AtotalMoney;
            parameters[19].Value = model.bounsAllost;
            //DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.chipped_LaunchInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_LaunchInfo set ");
            strSql.Append("Title=@Title,");
            strSql.Append("Say=@Say,");
            strSql.Append("LaunchTime=@LaunchTime,");
            strSql.Append("playName=@playName,");
            strSql.Append("ExpectNum=@ExpectNum,");
            strSql.Append("ChoiceNum=@ChoiceNum,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("doubles=@doubles,");
            strSql.Append("Share=@Share,");
            strSql.Append("Object=@Object,");
            strSql.Append("BuyShare=@BuyShare,");
            strSql.Append("Protect=@Protect,");
            strSql.Append("opens=@opens,");
            strSql.Append("Commission=@Commission,");
            strSql.Append("Winning=@Winning,");
            strSql.Append("Purchasing=@Purchasing,");
            strSql.Append("State=@State,");
            strSql.Append("AtotalMoney=@AtotalMoney,");
            strSql.Append("bounsAllost=@bounsAllost");
            strSql.Append(" where QNumber=@QNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,100),
					new SqlParameter("@Say", SqlDbType.NVarChar,200),
					new SqlParameter("@LaunchTime", SqlDbType.DateTime),
					new SqlParameter("@playName", SqlDbType.Int,4),
					new SqlParameter("@ExpectNum", SqlDbType.Int,4),
					new SqlParameter("@ChoiceNum", SqlDbType.Text),
					new SqlParameter("@UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@doubles", SqlDbType.Int,4),
					new SqlParameter("@Share", SqlDbType.Int,4),
					new SqlParameter("@Object", SqlDbType.NVarChar,50),
					new SqlParameter("@BuyShare", SqlDbType.Int,4),
					new SqlParameter("@Protect", SqlDbType.Int,4),
					new SqlParameter("@opens", SqlDbType.Int,4),
					new SqlParameter("@Commission", SqlDbType.Int,4),
					new SqlParameter("@Winning", SqlDbType.Int,4),
					new SqlParameter("@Purchasing", SqlDbType.Int,4),
					new SqlParameter("@State", SqlDbType.Int,4),
					new SqlParameter("@AtotalMoney", SqlDbType.Decimal,9),
					new SqlParameter("@bounsAllost", SqlDbType.NVarChar,50),
					new SqlParameter("@QNumber", SqlDbType.NVarChar,100)};
            parameters[0].Value = model.Title;
            parameters[1].Value = model.Say;
            parameters[2].Value = model.LaunchTime;
            parameters[3].Value = model.playName;
            parameters[4].Value = model.ExpectNum;
            parameters[5].Value = model.ChoiceNum;
            parameters[6].Value = model.UserName;
            parameters[7].Value = model.doubles;
            parameters[8].Value = model.Share;
            parameters[9].Value = model.Object;
            parameters[10].Value = model.BuyShare;
            parameters[11].Value = model.Protect;
            parameters[12].Value = model.opens;
            parameters[13].Value = model.Commission;
            parameters[14].Value = model.Winning;
            parameters[15].Value = model.Purchasing;
            parameters[16].Value = model.State;
            parameters[17].Value = model.AtotalMoney;
            parameters[18].Value = model.bounsAllost;
            parameters[19].Value = model.QNumber;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string QNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_LaunchInfo ");
            strSql.Append(" where QNumber=@QNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@QNumber", SqlDbType.NVarChar,50)};
            parameters[0].Value = QNumber;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.chipped_LaunchInfo GetModel(string QNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 QNumber,Title,Say,LaunchTime,playName,ExpectNum,ChoiceNum,UserName,doubles,Share,Object,BuyShare,Protect,opens,Commission,Winning,Purchasing,State,AtotalMoney,bounsAllost from Chipped_LaunchInfo ");
            strSql.Append(" where QNumber=@QNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@QNumber", SqlDbType.NVarChar,100)};
            parameters[0].Value = QNumber;

            Pbzx.Model.chipped_LaunchInfo model = new Pbzx.Model.chipped_LaunchInfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["QNumber"] != null)
                {
                    model.QNumber = ds.Tables[0].Rows[0]["QNumber"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Title"] != null)
                {
                    model.Title = ds.Tables[0].Rows[0]["Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Say"] != null)
                {
                    model.Say = ds.Tables[0].Rows[0]["Say"].ToString();
                }
                if (ds.Tables[0].Rows[0]["LaunchTime"].ToString() != "")
                {
                    model.LaunchTime = DateTime.Parse(ds.Tables[0].Rows[0]["LaunchTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["playName"].ToString() != "")
                {
                    model.playName = int.Parse(ds.Tables[0].Rows[0]["playName"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ExpectNum"].ToString() != "")
                {
                    model.ExpectNum = int.Parse(ds.Tables[0].Rows[0]["ExpectNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ChoiceNum"] != null)
                {
                    model.ChoiceNum = ds.Tables[0].Rows[0]["ChoiceNum"].ToString();
                }
                if (ds.Tables[0].Rows[0]["UserName"] != null)
                {
                    model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["doubles"].ToString() != "")
                {
                    model.doubles = int.Parse(ds.Tables[0].Rows[0]["doubles"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Share"].ToString() != "")
                {
                    model.Share = int.Parse(ds.Tables[0].Rows[0]["Share"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Object"] != null)
                {
                    model.Object = ds.Tables[0].Rows[0]["Object"].ToString();
                }
                if (ds.Tables[0].Rows[0]["BuyShare"].ToString() != "")
                {
                    model.BuyShare = int.Parse(ds.Tables[0].Rows[0]["BuyShare"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Protect"].ToString() != "")
                {
                    model.Protect = int.Parse(ds.Tables[0].Rows[0]["Protect"].ToString());
                }
                if (ds.Tables[0].Rows[0]["opens"].ToString() != "")
                {
                    model.opens = int.Parse(ds.Tables[0].Rows[0]["opens"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Commission"].ToString() != "")
                {
                    model.Commission = int.Parse(ds.Tables[0].Rows[0]["Commission"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Winning"].ToString() != "")
                {
                    model.Winning = int.Parse(ds.Tables[0].Rows[0]["Winning"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Purchasing"].ToString() != "")
                {
                    model.Purchasing = int.Parse(ds.Tables[0].Rows[0]["Purchasing"].ToString());
                }
                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    model.State = int.Parse(ds.Tables[0].Rows[0]["State"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AtotalMoney"].ToString() != "")
                {
                    model.AtotalMoney = decimal.Parse(ds.Tables[0].Rows[0]["AtotalMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["bounsAllost"] != null)
                {
                    model.bounsAllost = ds.Tables[0].Rows[0]["bounsAllost"].ToString();
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
            strSql.Append("select QNumber,Title,Say,LaunchTime,playName,ExpectNum,ChoiceNum,UserName,doubles,Share,Object,BuyShare,Protect,opens,Commission,Winning,Purchasing,State,AtotalMoney ");
            strSql.Append(" FROM Chipped_LaunchInfo ");
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
            strSql.Append(" QNumber,Title,Say,LaunchTime,playName,ExpectNum,ChoiceNum,UserName,doubles,Share,Object,BuyShare,Protect,opens,Commission,Winning,Purchasing,State,AtotalMoney ");
            strSql.Append(" FROM Chipped_LaunchInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <returns></returns>
        public DataSet QuerySet(string sql)
        {
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables.Count > 0)
            {
                return ds;
            }
            else
            {
                return null;
            }
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
            parameters[0].Value = "Chipped_LaunchInfo";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}
