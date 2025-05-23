using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类FC7LC。
    /// </summary>
    public class FC7LC : IFC7LC
    {
        public FC7LC()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string issue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FC7LC");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.FC7LC model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FC7LC(");
            strSql.Append("date,issue,code,tcode,LastModifytime,OpName,OpIp,Sales,BonusPool,Count1,Bonus1,Count2,Bonus2,Count3,Bonus3,Count4,Count5,Count6,Count7)");
            strSql.Append(" values (");
            strSql.Append("@date,@issue,@code,@tcode,@LastModifytime,@OpName,@OpIp,@Sales,@BonusPool,@Count1,@Bonus1,@Count2,@Bonus2,@Count3,@Bonus3,@Count4,@Count5,@Count6,@Count7)");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@code", SqlDbType.Char,14),
					new SqlParameter("@tcode", SqlDbType.Char,2),
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
					new SqlParameter("@Count7", SqlDbType.Int,4)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code;
            parameters[3].Value = model.tcode;
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
            
            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.FC7LC model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FC7LC set ");
            strSql.Append("date=@date,");
            strSql.Append("code=@code,");
            strSql.Append("tcode=@tcode,");
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
            strSql.Append("Count7=@Count7");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@code", SqlDbType.Char,14),
					new SqlParameter("@tcode", SqlDbType.Char,2),
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
					new SqlParameter("@Count7", SqlDbType.Int,4)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code;
            parameters[3].Value = model.tcode;
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

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  Delete(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FC7LC ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.FC7LC GetModel(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 date,issue,code,tcode,LastModifytime,OpName,OpIp,Sales,BonusPool,Count1,Bonus1,Count2,Bonus2,Count3,Bonus3,Count4,Count5,Count6,Count7 from FC7LC ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            Pbzx.Model.FC7LC model = new Pbzx.Model.FC7LC();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["date"].ToString() != "")
                {
                    model.date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                }
                model.issue = ds.Tables[0].Rows[0]["issue"].ToString();
                model.code = ds.Tables[0].Rows[0]["code"].ToString();
                model.tcode = ds.Tables[0].Rows[0]["tcode"].ToString();
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
            strSql.Append("select date,issue,code,tcode,LastModifytime,OpName,OpIp,Sales,BonusPool,Count1,Bonus1,Count2,Bonus2,Count3,Bonus3,Count4,Count5,Count6,Count7 ");
            strSql.Append(" FROM FC7LC ");
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
            strSql.Append(" date,issue,code,tcode,LastModifytime,OpName,OpIp,Sales,BonusPool,Count1,Bonus1,Count2,Bonus2,Count3,Bonus3,Count4,Count5,Count6,Count7 ");
            strSql.Append(" FROM FC7LC ");
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
            parameters[0].Value = "FC7LC";
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

