using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类FCSSData。
    /// </summary>
    public class FCSSData : IFCSSData
    {
        public FCSSData()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string issue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FCSSData");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.FCSSData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FCSSData(");
            strSql.Append("date,issue,redcode,bluecode,bluecode2,LastModifytime,OpName,OpIP,MachineID,Sales,BonusPool,Count1,Bonus1,Count2,Bonus2,Count3,Count4,Count5,Count6,Sunday)");
            strSql.Append(" values (");
            strSql.Append("@date,@issue,@redcode,@bluecode,@bluecode2,@LastModifytime,@OpName,@OpIP,@MachineID,@Sales,@BonusPool,@Count1,@Bonus1,@Count2,@Bonus2,@Count3,@Count4,@Count5,@Count6,@Sunday)");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@redcode", SqlDbType.Char,12),
					new SqlParameter("@bluecode", SqlDbType.Char,2),
					new SqlParameter("@bluecode2", SqlDbType.NVarChar,2),
					new SqlParameter("@LastModifytime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,50),
					new SqlParameter("@OpIP", SqlDbType.NVarChar,50),
					new SqlParameter("@MachineID", SqlDbType.TinyInt,1),
					new SqlParameter("@Sales", SqlDbType.Int,4),
					new SqlParameter("@BonusPool", SqlDbType.Int,4),
					new SqlParameter("@Count1", SqlDbType.TinyInt,1),
					new SqlParameter("@Bonus1", SqlDbType.Int,4),
					new SqlParameter("@Count2", SqlDbType.SmallInt,2),
					new SqlParameter("@Bonus2", SqlDbType.Int,4),
					new SqlParameter("@Count3", SqlDbType.SmallInt,2),
					new SqlParameter("@Count4", SqlDbType.Int,4),
					new SqlParameter("@Count5", SqlDbType.Int,4),
					new SqlParameter("@Count6", SqlDbType.Int,4),
					new SqlParameter("@Sunday", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.redcode;
            parameters[3].Value = model.bluecode;
            parameters[4].Value = model.bluecode2;
            parameters[5].Value = model.LastModifytime;
            parameters[6].Value = model.OpName;
            parameters[7].Value = model.OpIP;
            parameters[8].Value = model.MachineID;
            parameters[9].Value = model.Sales;
            parameters[10].Value = model.BonusPool;
            parameters[11].Value = model.Count1;
            parameters[12].Value = model.Bonus1;
            parameters[13].Value = model.Count2;
            parameters[14].Value = model.Bonus2;
            parameters[15].Value = model.Count3;
            parameters[16].Value = model.Count4;
            parameters[17].Value = model.Count5;
            parameters[18].Value = model.Count6;
            parameters[19].Value = model.Sunday;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int  Update(Pbzx.Model.FCSSData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FCSSData set ");
            strSql.Append("date=@date,");
            strSql.Append("redcode=@redcode,");
            strSql.Append("bluecode=@bluecode,");
            strSql.Append("bluecode2=@bluecode2,");
            strSql.Append("LastModifytime=@LastModifytime,");
            strSql.Append("OpName=@OpName,");
            strSql.Append("OpIP=@OpIP,");
            strSql.Append("MachineID=@MachineID,");
            strSql.Append("Sales=@Sales,");
            strSql.Append("BonusPool=@BonusPool,");
            strSql.Append("Count1=@Count1,");
            strSql.Append("Bonus1=@Bonus1,");
            strSql.Append("Count2=@Count2,");
            strSql.Append("Bonus2=@Bonus2,");
            strSql.Append("Count3=@Count3,");
            strSql.Append("Count4=@Count4,");
            strSql.Append("Count5=@Count5,");
            strSql.Append("Count6=@Count6,");
            strSql.Append("Sunday=@Sunday");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@redcode", SqlDbType.Char,12),
					new SqlParameter("@bluecode", SqlDbType.Char,2),
					new SqlParameter("@bluecode2", SqlDbType.NVarChar,2),
					new SqlParameter("@LastModifytime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,50),
					new SqlParameter("@OpIP", SqlDbType.NVarChar,50),
					new SqlParameter("@MachineID", SqlDbType.TinyInt,1),
					new SqlParameter("@Sales", SqlDbType.Int,4),
					new SqlParameter("@BonusPool", SqlDbType.Int,4),
					new SqlParameter("@Count1", SqlDbType.TinyInt,1),
					new SqlParameter("@Bonus1", SqlDbType.Int,4),
					new SqlParameter("@Count2", SqlDbType.SmallInt,2),
					new SqlParameter("@Bonus2", SqlDbType.Int,4),
					new SqlParameter("@Count3", SqlDbType.SmallInt,2),
					new SqlParameter("@Count4", SqlDbType.Int,4),
					new SqlParameter("@Count5", SqlDbType.Int,4),
					new SqlParameter("@Count6", SqlDbType.Int,4),
					new SqlParameter("@Sunday", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.redcode;
            parameters[3].Value = model.bluecode;
            parameters[4].Value = model.bluecode2;
            parameters[5].Value = model.LastModifytime;
            parameters[6].Value = model.OpName;
            parameters[7].Value = model.OpIP;
            parameters[8].Value = model.MachineID;
            parameters[9].Value = model.Sales;
            parameters[10].Value = model.BonusPool;
            parameters[11].Value = model.Count1;
            parameters[12].Value = model.Bonus1;
            parameters[13].Value = model.Count2;
            parameters[14].Value = model.Bonus2;
            parameters[15].Value = model.Count3;
            parameters[16].Value = model.Count4;
            parameters[17].Value = model.Count5;
            parameters[18].Value = model.Count6;
            parameters[19].Value = model.Sunday;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FCSSData ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.FCSSData GetModel(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 date,issue,redcode,bluecode,bluecode2,LastModifytime,OpName,OpIP,MachineID,Sales,BonusPool,Count1,Bonus1,Count2,Bonus2,Count3,Count4,Count5,Count6,Sunday from FCSSData ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            Pbzx.Model.FCSSData model = new Pbzx.Model.FCSSData();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["date"].ToString() != "")
                {
                    model.date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                }
                model.issue = ds.Tables[0].Rows[0]["issue"].ToString();
                model.redcode = ds.Tables[0].Rows[0]["redcode"].ToString();
                model.bluecode = ds.Tables[0].Rows[0]["bluecode"].ToString();
                model.bluecode2 = ds.Tables[0].Rows[0]["bluecode2"].ToString();
                if (ds.Tables[0].Rows[0]["LastModifytime"].ToString() != "")
                {
                    model.LastModifytime = DateTime.Parse(ds.Tables[0].Rows[0]["LastModifytime"].ToString());
                }
                model.OpName = ds.Tables[0].Rows[0]["OpName"].ToString();
                model.OpIP = ds.Tables[0].Rows[0]["OpIP"].ToString();
                if (ds.Tables[0].Rows[0]["MachineID"].ToString() != "")
                {
                    model.MachineID = int.Parse(ds.Tables[0].Rows[0]["MachineID"].ToString());
                }
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
                if (ds.Tables[0].Rows[0]["Sunday"].ToString() != "")
                {
                    model.Sunday = int.Parse(ds.Tables[0].Rows[0]["Sunday"].ToString());
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
            strSql.Append("select date,issue,redcode,bluecode,bluecode2,LastModifytime,OpName,OpIP,MachineID,Sales,BonusPool,Count1,Bonus1,Count2,Bonus2,Count3,Count4,Count5,Count6,Sunday ");
            strSql.Append(" FROM FCSSData ");
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
            parameters[0].Value = "FCSSData";
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

