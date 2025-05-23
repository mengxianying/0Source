using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类TC7XCData。
    /// </summary>
    public class TC7XCData : ITC7XCData
    {
        public TC7XCData()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string issue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TC7XCData");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Pbzx.Model.TC7XCData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TC7XCData(");
            strSql.Append("date,issue,code,money,first,second,sum,summoney,bigsmall,bigsmallmoney,oddeven,oddevenmoney,LastModifyTime,OpName,OpIp,Sales,BonusPool,Count0,Bonus0,Count1,Bonus1,Count2,Bonus2,Count3,Count4,Count5)");
            strSql.Append(" values (");
            strSql.Append("@date,@issue,@code,@money,@first,@second,@sum,@summoney,@bigsmall,@bigsmallmoney,@oddeven,@oddevenmoney,@LastModifyTime,@OpName,@OpIp,@Sales,@BonusPool,@Count0,@Bonus0,@Count1,@Bonus1,@Count2,@Bonus2,@Count3,@Count4,@Count5)");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.DateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@code", SqlDbType.Char,7),
					new SqlParameter("@money", SqlDbType.NVarChar,20),
					new SqlParameter("@first", SqlDbType.NVarChar,20),
					new SqlParameter("@second", SqlDbType.NVarChar,20),
					new SqlParameter("@sum", SqlDbType.NVarChar,3),
					new SqlParameter("@summoney", SqlDbType.NVarChar,8),
					new SqlParameter("@bigsmall", SqlDbType.NVarChar,14),
					new SqlParameter("@bigsmallmoney", SqlDbType.NVarChar,8),
					new SqlParameter("@oddeven", SqlDbType.NVarChar,14),
					new SqlParameter("@oddevenmoney", SqlDbType.NVarChar,8),
					new SqlParameter("@LastModifyTime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,50),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,50),
					new SqlParameter("@Sales", SqlDbType.Int,4),
					new SqlParameter("@BonusPool", SqlDbType.Int,4),
					new SqlParameter("@Count0", SqlDbType.TinyInt,1),
					new SqlParameter("@Bonus0", SqlDbType.Int,4),
					new SqlParameter("@Count1", SqlDbType.SmallInt,2),
					new SqlParameter("@Bonus1", SqlDbType.Int,4),
					new SqlParameter("@Count2", SqlDbType.SmallInt,2),
					new SqlParameter("@Bonus2", SqlDbType.Int,4),
					new SqlParameter("@Count3", SqlDbType.SmallInt,2),
					new SqlParameter("@Count4", SqlDbType.Int,4),
					new SqlParameter("@Count5", SqlDbType.Int,4)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code;
            parameters[3].Value = model.money;
            parameters[4].Value = model.first;
            parameters[5].Value = model.second;
            parameters[6].Value = model.sum;
            parameters[7].Value = model.summoney;
            parameters[8].Value = model.bigsmall;
            parameters[9].Value = model.bigsmallmoney;
            parameters[10].Value = model.oddeven;
            parameters[11].Value = model.oddevenmoney;
            parameters[12].Value = model.LastModifyTime;
            parameters[13].Value = model.OpName;
            parameters[14].Value = model.OpIp;
            parameters[15].Value = model.Sales;
            parameters[16].Value = model.BonusPool;
            parameters[17].Value = model.Count0;
            parameters[18].Value = model.Bonus0;
            parameters[19].Value = model.Count1;
            parameters[20].Value = model.Bonus1;
            parameters[21].Value = model.Count2;
            parameters[22].Value = model.Bonus2;
            parameters[23].Value = model.Count3;
            parameters[24].Value = model.Count4;
            parameters[25].Value = model.Count5;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.TC7XCData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TC7XCData set ");
            strSql.Append("date=@date,");
            strSql.Append("code=@code,");
            strSql.Append("first=@first,");
            strSql.Append("second=@second,");
            strSql.Append("summoney=@summoney,");
            strSql.Append("bigsmall=@bigsmall,");
            strSql.Append("bigsmallmoney=@bigsmallmoney,");
            strSql.Append("oddeven=@oddeven,");
            strSql.Append("oddevenmoney=@oddevenmoney,");
            strSql.Append("LastModifyTime=@LastModifyTime,");
            strSql.Append("OpName=@OpName,");
            strSql.Append("OpIp=@OpIp,");
            strSql.Append("Sales=@Sales,");
            strSql.Append("BonusPool=@BonusPool,");
            strSql.Append("Count0=@Count0,");
            strSql.Append("Bonus0=@Bonus0,");
            strSql.Append("Count1=@Count1,");
            strSql.Append("Bonus1=@Bonus1,");
            strSql.Append("Count2=@Count2,");
            strSql.Append("Bonus2=@Bonus2,");
            strSql.Append("Count3=@Count3,");
            strSql.Append("Count4=@Count4,");
            strSql.Append("Count5=@Count5");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.DateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@code", SqlDbType.Char,7),
					new SqlParameter("@money", SqlDbType.NVarChar,20),
					new SqlParameter("@first", SqlDbType.NVarChar,20),
					new SqlParameter("@second", SqlDbType.NVarChar,20),
					new SqlParameter("@sum", SqlDbType.NVarChar,3),
					new SqlParameter("@summoney", SqlDbType.NVarChar,8),
					new SqlParameter("@bigsmall", SqlDbType.NVarChar,14),
					new SqlParameter("@bigsmallmoney", SqlDbType.NVarChar,8),
					new SqlParameter("@oddeven", SqlDbType.NVarChar,14),
					new SqlParameter("@oddevenmoney", SqlDbType.NVarChar,8),
					new SqlParameter("@LastModifyTime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,50),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,50),
					new SqlParameter("@Sales", SqlDbType.Int,4),
					new SqlParameter("@BonusPool", SqlDbType.Int,4),
					new SqlParameter("@Count0", SqlDbType.TinyInt,1),
					new SqlParameter("@Bonus0", SqlDbType.Int,4),
					new SqlParameter("@Count1", SqlDbType.SmallInt,2),
					new SqlParameter("@Bonus1", SqlDbType.Int,4),
					new SqlParameter("@Count2", SqlDbType.SmallInt,2),
					new SqlParameter("@Bonus2", SqlDbType.Int,4),
					new SqlParameter("@Count3", SqlDbType.SmallInt,2),
					new SqlParameter("@Count4", SqlDbType.Int,4),
					new SqlParameter("@Count5", SqlDbType.Int,4)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code;
            parameters[3].Value = model.money;
            parameters[4].Value = model.first;
            parameters[5].Value = model.second;
            parameters[6].Value = model.sum;
            parameters[7].Value = model.summoney;
            parameters[8].Value = model.bigsmall;
            parameters[9].Value = model.bigsmallmoney;
            parameters[10].Value = model.oddeven;
            parameters[11].Value = model.oddevenmoney;
            parameters[12].Value = model.LastModifyTime;
            parameters[13].Value = model.OpName;
            parameters[14].Value = model.OpIp;
            parameters[15].Value = model.Sales;
            parameters[16].Value = model.BonusPool;
            parameters[17].Value = model.Count0;
            parameters[18].Value = model.Bonus0;
            parameters[19].Value = model.Count1;
            parameters[20].Value = model.Bonus1;
            parameters[21].Value = model.Count2;
            parameters[22].Value = model.Bonus2;
            parameters[23].Value = model.Count3;
            parameters[24].Value = model.Count4;
            parameters[25].Value = model.Count5;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TC7XCData ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.TC7XCData GetModel(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 date,issue,code,money,first,second,sum,summoney,bigsmall,bigsmallmoney,oddeven,oddevenmoney,LastModifyTime,OpName,OpIp,Sales,BonusPool,Count0,Bonus0,Count1,Bonus1,Count2,Bonus2,Count3,Count4,Count5 from TC7XCData ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            Pbzx.Model.TC7XCData model = new Pbzx.Model.TC7XCData();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["date"].ToString() != "")
                {
                    model.date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                }
                model.issue = ds.Tables[0].Rows[0]["issue"].ToString();
                model.code = ds.Tables[0].Rows[0]["code"].ToString();
                model.money = ds.Tables[0].Rows[0]["money"].ToString();
                model.first = ds.Tables[0].Rows[0]["first"].ToString();
                model.second = ds.Tables[0].Rows[0]["second"].ToString();
                model.sum = ds.Tables[0].Rows[0]["sum"].ToString();
                model.summoney = ds.Tables[0].Rows[0]["summoney"].ToString();
                model.bigsmall = ds.Tables[0].Rows[0]["bigsmall"].ToString();
                model.bigsmallmoney = ds.Tables[0].Rows[0]["bigsmallmoney"].ToString();
                model.oddeven = ds.Tables[0].Rows[0]["oddeven"].ToString();
                model.oddevenmoney = ds.Tables[0].Rows[0]["oddevenmoney"].ToString();
                if (ds.Tables[0].Rows[0]["LastModifyTime"].ToString() != "")
                {
                    model.LastModifyTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastModifyTime"].ToString());
                }
                model.OpName = ds.Tables[0].Rows[0]["OpName"].ToString();
                model.OpIp = ds.Tables[0].Rows[0]["OpIp"].ToString();
                if (ds.Tables[0].Rows[0]["Sales"].ToString() != "")
                {
                    model.Sales = int.Parse(ds.Tables[0].Rows[0]["Sales"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BonusPool"].ToString() != "")
                {
                    model.BonusPool = int.Parse(ds.Tables[0].Rows[0]["BonusPool"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count0"].ToString() != "")
                {
                    model.Count0 = int.Parse(ds.Tables[0].Rows[0]["Count0"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Bonus0"].ToString() != "")
                {
                    model.Bonus0 = int.Parse(ds.Tables[0].Rows[0]["Bonus0"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count1"].ToString() != "")
                {
                    model.Count1 = int.Parse(ds.Tables[0].Rows[0]["Count1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Bonus1"].ToString() != "")
                {
                    model.Bonus1 = int.Parse(ds.Tables[0].Rows[0]["Bonus1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count2"].ToString() != "")
                {
                    model.Count2 = int.Parse(ds.Tables[0].Rows[0]["Count2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Bonus2"].ToString() != "")
                {
                    model.Bonus2 = int.Parse(ds.Tables[0].Rows[0]["Bonus2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count3"].ToString() != "")
                {
                    model.Count3 = int.Parse(ds.Tables[0].Rows[0]["Count3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count4"].ToString() != "")
                {
                    model.Count4 = int.Parse(ds.Tables[0].Rows[0]["Count4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count5"].ToString() != "")
                {
                    model.Count5 = int.Parse(ds.Tables[0].Rows[0]["Count5"].ToString());
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
            strSql.Append("select date,issue,code,money,first,second,sum,summoney,bigsmall,bigsmallmoney,oddeven,oddevenmoney,LastModifyTime,OpName,OpIp,Sales,BonusPool,Count0,Bonus0,Count1,Bonus1,Count2,Bonus2,Count3,Count4,Count5 ");
            strSql.Append(" FROM TC7XCData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL1.Query(strSql.ToString());
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
            parameters[0].Value = "TC7XCData";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL1.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

