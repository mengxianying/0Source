using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类TCDLTData。
    /// </summary>
    public class TCDLTData : ITCDLTData
    {
        public TCDLTData()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string issue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TCDLTData");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Pbzx.Model.TCDLTData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TCDLTData(");
            strSql.Append("date,issue,code,code2,LastModifytime,OpName,OpIp,Sales,BonusPool,Count1,Bonus1,Count2,Bonus2,Count3,Bonus3,Count4,Count5,Count6,Count7,Count8,AppCount1,AppBonus1,AppCount2,AppBonus2,AppCount3,AppBonus3,AddSales,AddCount1)");
            strSql.Append(" values (");
            strSql.Append("@date,@issue,@code,@code2,@LastModifytime,@OpName,@OpIp,@Sales,@BonusPool,@Count1,@Bonus1,@Count2,@Bonus2,@Count3,@Bonus3,@Count4,@Count5,@Count6,@Count7,@Count8,@AppCount1,@AppBonus1,@AppCount2,@AppBonus2,@AppCount3,@AppBonus3,@AddSales,@AddCount1)");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@code", SqlDbType.Char,10),
					new SqlParameter("@code2", SqlDbType.Char,4),
					new SqlParameter("@LastModifytime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,50),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,50),
					new SqlParameter("@Sales", SqlDbType.Int,4),
					new SqlParameter("@BonusPool", SqlDbType.Int,4),
					new SqlParameter("@Count1", SqlDbType.TinyInt,1),
					new SqlParameter("@Bonus1", SqlDbType.Int,4),
					new SqlParameter("@Count2", SqlDbType.SmallInt,2),
					new SqlParameter("@Bonus2", SqlDbType.Int,4),
					new SqlParameter("@Count3", SqlDbType.SmallInt,2),
					new SqlParameter("@Bonus3", SqlDbType.Int,4),
					new SqlParameter("@Count4", SqlDbType.Int,4),
					new SqlParameter("@Count5", SqlDbType.Int,4),
					new SqlParameter("@Count6", SqlDbType.Int,4),
					new SqlParameter("@Count7", SqlDbType.Int,4),
					new SqlParameter("@Count8", SqlDbType.Int,4),
					new SqlParameter("@AppCount1", SqlDbType.TinyInt,1),
					new SqlParameter("@AppBonus1", SqlDbType.Int,4),
					new SqlParameter("@AppCount2", SqlDbType.SmallInt,2),
					new SqlParameter("@AppBonus2", SqlDbType.Int,4),
					new SqlParameter("@AppCount3", SqlDbType.SmallInt,2),
					new SqlParameter("@AppBonus3", SqlDbType.Int,4),
					new SqlParameter("@AddSales", SqlDbType.Int,4),
					new SqlParameter("@AddCount1", SqlDbType.Int,4)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code;
            parameters[3].Value = model.code2;
            parameters[4].Value = model.LastModifytime;
            parameters[5].Value = model.OpName;
            parameters[6].Value = model.OpIp;
            parameters[7].Value = model.Sales;
            parameters[8].Value = model.BonusPool;
            parameters[9].Value = model.Count1;
            parameters[10].Value = model.Bonus1;
            parameters[11].Value = model.Count2;
            parameters[12].Value = model.Bonus2;
            parameters[13].Value = model.Count3;
            parameters[14].Value = model.Bonus3;
            parameters[15].Value = model.Count4;
            parameters[16].Value = model.Count5;
            parameters[17].Value = model.Count6;
            parameters[18].Value = model.Count7;
            parameters[19].Value = model.Count8;
            parameters[20].Value = model.AppCount1;
            parameters[21].Value = model.AppBonus1;
            parameters[22].Value = model.AppCount2;
            parameters[23].Value = model.AppBonus2;
            parameters[24].Value = model.AppCount3;
            parameters[25].Value = model.AppBonus3;
            parameters[26].Value = model.AddSales;
            parameters[27].Value = model.AddCount1;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.TCDLTData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TCDLTData set ");
            strSql.Append("date=@date,");
            strSql.Append("code=@code,");
            strSql.Append("code2=@code2,");
            strSql.Append("LastModifytime=@LastModifytime,");
            strSql.Append("OpName=@OpName,");
            strSql.Append("OpIp=@OpIp,");
            strSql.Append("Sales=@Sales,");
            strSql.Append("BonusPool=@BonusPool,");
            strSql.Append("Count1=@Count1,");
            strSql.Append("Bonus1=@Bonus1,");
            strSql.Append("Count2=@Count2,");
            strSql.Append("Bonus2=@Bonus2,");
            strSql.Append("Count3=@Count3,");
            strSql.Append("Bonus3=@Bonus3,");
            strSql.Append("Count4=@Count4,");
            strSql.Append("Count5=@Count5,");
            strSql.Append("Count6=@Count6,");
            strSql.Append("Count7=@Count7,");
            strSql.Append("Count8=@Count8,");
            strSql.Append("AppCount1=@AppCount1,");
            strSql.Append("AppBonus1=@AppBonus1,");
            strSql.Append("AppCount2=@AppCount2,");
            strSql.Append("AppBonus2=@AppBonus2,");
            strSql.Append("AppCount3=@AppCount3,");
            strSql.Append("AppBonus3=@AppBonus3,");
            strSql.Append("AddSales=@AddSales,");
            strSql.Append("AddCount1=@AddCount1");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@code", SqlDbType.Char,10),
					new SqlParameter("@code2", SqlDbType.Char,4),
					new SqlParameter("@LastModifytime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,50),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,50),
					new SqlParameter("@Sales", SqlDbType.Int,4),
					new SqlParameter("@BonusPool", SqlDbType.Int,4),
					new SqlParameter("@Count1", SqlDbType.TinyInt,1),
					new SqlParameter("@Bonus1", SqlDbType.Int,4),
					new SqlParameter("@Count2", SqlDbType.SmallInt,2),
					new SqlParameter("@Bonus2", SqlDbType.Int,4),
					new SqlParameter("@Count3", SqlDbType.SmallInt,2),
					new SqlParameter("@Bonus3", SqlDbType.Int,4),
					new SqlParameter("@Count4", SqlDbType.Int,4),
					new SqlParameter("@Count5", SqlDbType.Int,4),
					new SqlParameter("@Count6", SqlDbType.Int,4),
					new SqlParameter("@Count7", SqlDbType.Int,4),
					new SqlParameter("@Count8", SqlDbType.Int,4),
					new SqlParameter("@AppCount1", SqlDbType.TinyInt,1),
					new SqlParameter("@AppBonus1", SqlDbType.Int,4),
					new SqlParameter("@AppCount2", SqlDbType.SmallInt,2),
					new SqlParameter("@AppBonus2", SqlDbType.Int,4),
					new SqlParameter("@AppCount3", SqlDbType.SmallInt,2),
					new SqlParameter("@AppBonus3", SqlDbType.Int,4),
					new SqlParameter("@AddSales", SqlDbType.Int,4),
					new SqlParameter("@AddCount1", SqlDbType.Int,4)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code;
            parameters[3].Value = model.code2;
            parameters[4].Value = model.LastModifytime;
            parameters[5].Value = model.OpName;
            parameters[6].Value = model.OpIp;
            parameters[7].Value = model.Sales;
            parameters[8].Value = model.BonusPool;
            parameters[9].Value = model.Count1;
            parameters[10].Value = model.Bonus1;
            parameters[11].Value = model.Count2;
            parameters[12].Value = model.Bonus2;
            parameters[13].Value = model.Count3;
            parameters[14].Value = model.Bonus3;
            parameters[15].Value = model.Count4;
            parameters[16].Value = model.Count5;
            parameters[17].Value = model.Count6;
            parameters[18].Value = model.Count7;
            parameters[19].Value = model.Count8;
            parameters[20].Value = model.AppCount1;
            parameters[21].Value = model.AppBonus1;
            parameters[22].Value = model.AppCount2;
            parameters[23].Value = model.AppBonus2;
            parameters[24].Value = model.AppCount3;
            parameters[25].Value = model.AppBonus3;
            parameters[26].Value = model.AddSales;
            parameters[27].Value = model.AddCount1;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TCDLTData ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.TCDLTData GetModel(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 date,issue,code,code2,LastModifytime,OpName,OpIp,Sales,BonusPool,Count1,Bonus1,Count2,Bonus2,Count3,Bonus3,Count4,Count5,Count6,Count7,Count8,AppCount1,AppBonus1,AppCount2,AppBonus2,AppCount3,AppBonus3,AddSales,AddCount1 from TCDLTData ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            Pbzx.Model.TCDLTData model = new Pbzx.Model.TCDLTData();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["date"].ToString() != "")
                {
                    model.date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                }
                model.issue = ds.Tables[0].Rows[0]["issue"].ToString();
                model.code = ds.Tables[0].Rows[0]["code"].ToString();
                model.code2 = ds.Tables[0].Rows[0]["code2"].ToString();
                if (ds.Tables[0].Rows[0]["LastModifytime"].ToString() != "")
                {
                    model.LastModifytime = DateTime.Parse(ds.Tables[0].Rows[0]["LastModifytime"].ToString());
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
                if (ds.Tables[0].Rows[0]["Bonus3"].ToString() != "")
                {
                    model.Bonus3 = int.Parse(ds.Tables[0].Rows[0]["Bonus3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count4"].ToString() != "")
                {
                    model.Count4 = int.Parse(ds.Tables[0].Rows[0]["Count4"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count5"].ToString() != "")
                {
                    model.Count5 = int.Parse(ds.Tables[0].Rows[0]["Count5"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count6"].ToString() != "")
                {
                    model.Count6 = int.Parse(ds.Tables[0].Rows[0]["Count6"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count7"].ToString() != "")
                {
                    model.Count7 = int.Parse(ds.Tables[0].Rows[0]["Count7"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Count8"].ToString() != "")
                {
                    model.Count8 = int.Parse(ds.Tables[0].Rows[0]["Count8"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AppCount1"].ToString() != "")
                {
                    model.AppCount1 = int.Parse(ds.Tables[0].Rows[0]["AppCount1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AppBonus1"].ToString() != "")
                {
                    model.AppBonus1 = int.Parse(ds.Tables[0].Rows[0]["AppBonus1"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AppCount2"].ToString() != "")
                {
                    model.AppCount2 = int.Parse(ds.Tables[0].Rows[0]["AppCount2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AppBonus2"].ToString() != "")
                {
                    model.AppBonus2 = int.Parse(ds.Tables[0].Rows[0]["AppBonus2"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AppCount3"].ToString() != "")
                {
                    model.AppCount3 = int.Parse(ds.Tables[0].Rows[0]["AppCount3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AppBonus3"].ToString() != "")
                {
                    model.AppBonus3 = int.Parse(ds.Tables[0].Rows[0]["AppBonus3"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddSales"].ToString() != "")
                {
                    model.AddSales = int.Parse(ds.Tables[0].Rows[0]["AddSales"].ToString());
                }
                if (ds.Tables[0].Rows[0]["AddCount1"].ToString() != "")
                {
                    model.AddCount1 = int.Parse(ds.Tables[0].Rows[0]["AddCount1"].ToString());
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
            strSql.Append("select date,issue,code,code2,LastModifytime,OpName,OpIp,Sales,BonusPool,Count1,Bonus1,Count2,Bonus2,Count3,Bonus3,Count4,Count5,Count6,Count7,Count8,AppCount1,AppBonus1,AppCount2,AppBonus2,AppCount3,AppBonus3,AddSales,AddCount1 ");
            strSql.Append(" FROM TCDLTData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL1.Query(strSql.ToString());
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
            strSql.Append(" date,issue,code,code2,LastModifytime,OpName,OpIp,Sales,BonusPool,Count1,Bonus1,Count2,Bonus2,Count3,Bonus3,Count4,Count5,Count6,Count7,Count8,AppCount1,AppBonus1,AppCount2,AppBonus2,AppCount3,AppBonus3,AddSales,AddCount1 ");
            strSql.Append(" FROM TCDLTData ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
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
            parameters[0].Value = "TCDLTData";
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

