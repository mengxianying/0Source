using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类FC3DData。
    /// </summary>
    public class FC3DData : IFC3DData
    {
        public FC3DData()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string issue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from FC3DData");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int  Add(Pbzx.Model.FC3DData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FC3DData(");
            strSql.Append("date,issue,testcode,code,DXCount,Z3Count,Z6Count,Sales,Bonus,TestOrderB,TestOrderS,TestOrderG,LastModifyTime,OpName,OpIp,CodeOrderB,CodeOrderS,CodeOrderG,AttentionCode,decode)");
            strSql.Append(" values (");
            strSql.Append("@date,@issue,@testcode,@code,@DXCount,@Z3Count,@Z6Count,@Sales,@Bonus,@TestOrderB,@TestOrderS,@TestOrderG,@LastModifyTime,@OpName,@OpIp,@CodeOrderB,@CodeOrderS,@CodeOrderG,@AttentionCode,@decode)");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@testcode", SqlDbType.Char,3),
					new SqlParameter("@code", SqlDbType.NVarChar,3),
                    //new SqlParameter("@machine", SqlDbType.TinyInt,1),
                    //new SqlParameter("@ball", SqlDbType.TinyInt,1),
					new SqlParameter("@DXCount", SqlDbType.Int,4),
					new SqlParameter("@Z3Count", SqlDbType.Int,4),
					new SqlParameter("@Z6Count", SqlDbType.Int,4),
					new SqlParameter("@Sales", SqlDbType.Int,4),
					new SqlParameter("@Bonus", SqlDbType.Int,4),
					new SqlParameter("@TestOrderB", SqlDbType.NVarChar,10),
					new SqlParameter("@TestOrderS", SqlDbType.NVarChar,10),
					new SqlParameter("@TestOrderG", SqlDbType.NVarChar,10),
					new SqlParameter("@LastModifyTime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,50),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,50),
					new SqlParameter("@CodeOrderB", SqlDbType.NVarChar,10),
					new SqlParameter("@CodeOrderS", SqlDbType.NVarChar,10),
					new SqlParameter("@CodeOrderG", SqlDbType.NVarChar,10),
					new SqlParameter("@AttentionCode", SqlDbType.NVarChar,3),
					new SqlParameter("@decode", SqlDbType.NVarChar,3)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.testcode;
            parameters[3].Value = model.code;
            //parameters[4].Value = model.machine;
           // parameters[3].Value = model.ball;
            parameters[4].Value = model.DXCount;
            parameters[5].Value = model.Z3Count;
            parameters[6].Value = model.Z6Count;
            parameters[7].Value = model.Sales;
            parameters[8].Value = model.Bonus;
            parameters[9].Value = model.TestOrderB;
            parameters[10].Value = model.TestOrderS;
            parameters[11].Value = model.TestOrderG;
            parameters[12].Value = model.LastModifyTime;
            parameters[13].Value = model.OpName;
            parameters[14].Value = model.OpIp;
            parameters[15].Value = model.CodeOrderB;
            parameters[16].Value = model.CodeOrderS;
            parameters[17].Value = model.CodeOrderG;
            parameters[18].Value = model.AttentionCode;
            parameters[19].Value = model.decode;
            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int  Update(Pbzx.Model.FC3DData model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FC3DData set ");
            strSql.Append("date=@date,");
            strSql.Append("testcode=@testcode,");
            strSql.Append("code=@code,");
            strSql.Append("machine=@machine,");
            strSql.Append("ball=@ball,");
            strSql.Append("Z3Count=@Z3Count,");
            strSql.Append("Z6Count=@Z6Count,");
            strSql.Append("Sales=@Sales,");
            strSql.Append("Bonus=@Bonus,");
            strSql.Append("TestOrderB=@TestOrderB,");
            strSql.Append("TestOrderS=@TestOrderS,");
            strSql.Append("TestOrderG=@TestOrderG,");
            strSql.Append("LastModifyTime=@LastModifyTime,");
            strSql.Append("OpName=@OpName,");
            strSql.Append("OpIp=@OpIp,");
            strSql.Append("CodeOrderB=@CodeOrderB,");
            strSql.Append("CodeOrderS=@CodeOrderS,");
            strSql.Append("CodeOrderG=@CodeOrderG,");
            strSql.Append("AttentionCode=@AttentionCode,");
            strSql.Append("decode=@decode");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.SmallDateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@testcode", SqlDbType.Char,3),
					new SqlParameter("@code", SqlDbType.NVarChar,3),
					new SqlParameter("@machine", SqlDbType.TinyInt,1),
					new SqlParameter("@ball", SqlDbType.TinyInt,1),
					new SqlParameter("@DXCount", SqlDbType.Int,4),
					new SqlParameter("@Z3Count", SqlDbType.Int,4),
					new SqlParameter("@Z6Count", SqlDbType.Int,4),
					new SqlParameter("@Sales", SqlDbType.Int,4),
					new SqlParameter("@Bonus", SqlDbType.Int,4),
					new SqlParameter("@TestOrderB", SqlDbType.NVarChar,10),
					new SqlParameter("@TestOrderS", SqlDbType.NVarChar,10),
					new SqlParameter("@TestOrderG", SqlDbType.NVarChar,10),
					new SqlParameter("@LastModifyTime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,50),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,50),
					new SqlParameter("@CodeOrderB", SqlDbType.NVarChar,10),
					new SqlParameter("@CodeOrderS", SqlDbType.NVarChar,10),
					new SqlParameter("@CodeOrderG", SqlDbType.NVarChar,10),
					new SqlParameter("@AttentionCode", SqlDbType.NVarChar,3),
					new SqlParameter("@decode", SqlDbType.NVarChar,3)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.testcode;
            parameters[3].Value = model.code;
            parameters[4].Value = model.machine;
            parameters[5].Value = model.ball;
            parameters[6].Value = model.DXCount;
            parameters[7].Value = model.Z3Count;
            parameters[8].Value = model.Z6Count;
            parameters[9].Value = model.Sales;
            parameters[10].Value = model.Bonus;
            parameters[11].Value = model.TestOrderB;
            parameters[12].Value = model.TestOrderS;
            parameters[13].Value = model.TestOrderG;
            parameters[14].Value = model.LastModifyTime;
            parameters[15].Value = model.OpName;
            parameters[16].Value = model.OpIp;
            parameters[17].Value = model.CodeOrderB;
            parameters[18].Value = model.CodeOrderS;
            parameters[19].Value = model.CodeOrderG;
            parameters[20].Value = model.AttentionCode;
            parameters[21].Value = model.decode;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  Delete(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FC3DData ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.FC3DData GetModel(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 date,issue,testcode,code,machine,ball,DXCount,Z3Count,Z6Count,Sales,Bonus,TestOrderB,TestOrderS,TestOrderG,LastModifyTime,OpName,OpIp,CodeOrderB,CodeOrderS,CodeOrderG,AttentionCode,decode from FC3DData ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            Pbzx.Model.FC3DData model = new Pbzx.Model.FC3DData();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["date"].ToString() != "")
                {
                    model.date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                }
                model.issue = ds.Tables[0].Rows[0]["issue"].ToString();
                model.testcode = ds.Tables[0].Rows[0]["testcode"].ToString();
                model.code = ds.Tables[0].Rows[0]["code"].ToString();
                if (ds.Tables[0].Rows[0]["machine"].ToString() != "")
                {
                    model.machine = int.Parse(ds.Tables[0].Rows[0]["machine"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ball"].ToString() != "")
                {
                    model.ball = int.Parse(ds.Tables[0].Rows[0]["ball"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DXCount"].ToString() != "")
                {
                    model.DXCount = int.Parse(ds.Tables[0].Rows[0]["DXCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Z3Count"].ToString() != "")
                {
                    model.Z3Count = int.Parse(ds.Tables[0].Rows[0]["Z3Count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Z6Count"].ToString() != "")
                {
                    model.Z6Count = int.Parse(ds.Tables[0].Rows[0]["Z6Count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sales"].ToString() != "")
                {
                    model.Sales = int.Parse(ds.Tables[0].Rows[0]["Sales"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Bonus"].ToString() != "")
                {
                    model.Bonus = int.Parse(ds.Tables[0].Rows[0]["Bonus"].ToString());
                }
                model.TestOrderB = ds.Tables[0].Rows[0]["TestOrderB"].ToString();
                model.TestOrderS = ds.Tables[0].Rows[0]["TestOrderS"].ToString();
                model.TestOrderG = ds.Tables[0].Rows[0]["TestOrderG"].ToString();
                if (ds.Tables[0].Rows[0]["LastModifyTime"].ToString() != "")
                {
                    model.LastModifyTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastModifyTime"].ToString());
                }
                model.OpName = ds.Tables[0].Rows[0]["OpName"].ToString();
                model.OpIp = ds.Tables[0].Rows[0]["OpIp"].ToString();
                model.CodeOrderB = ds.Tables[0].Rows[0]["CodeOrderB"].ToString();
                model.CodeOrderS = ds.Tables[0].Rows[0]["CodeOrderS"].ToString();
                model.CodeOrderG = ds.Tables[0].Rows[0]["CodeOrderG"].ToString();
                model.AttentionCode = ds.Tables[0].Rows[0]["AttentionCode"].ToString();
                model.decode = ds.Tables[0].Rows[0]["decode"].ToString();
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
            strSql.Append("select date,issue,testcode,code,machine,ball,DXCount,Z3Count,Z6Count,Sales,Bonus,TestOrderB,TestOrderS,TestOrderG,LastModifyTime,OpName,OpIp,CodeOrderB,CodeOrderS,CodeOrderG,AttentionCode,decode ");
            strSql.Append(" FROM FC3DData ");
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
            strSql.Append(" date,issue,testcode,code,machine,ball,DXCount,Z3Count,Z6Count,Sales,Bonus,TestOrderB,TestOrderS,TestOrderG,LastModifyTime,OpName,OpIp,CodeOrderB,CodeOrderS,CodeOrderG,AttentionCode,decode ");
            strSql.Append(" FROM FC3DData ");
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
            parameters[0].Value = "FC3DData";
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

