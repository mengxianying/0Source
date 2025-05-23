using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类TCPL35Data。
    /// </summary>
    public class TCPL35Data : ITCPL35Data
    {
        public TCPL35Data()
        { }
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string issue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from TCPL35Data");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Pbzx.Model.TCPL35Data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into TCPL35Data(");
            strSql.Append("date,issue,code3,code5,testcode,machine,ball,LastModifyTime,OpName,OpIp,P3Sales,DxCount,Z3Count,Z6Count,P5Sales,P5Count)");
            strSql.Append(" values (");
            strSql.Append("@date,@issue,@code3,@code5,@testcode,@machine,@ball,@LastModifyTime,@OpName,@OpIp,@P3Sales,@DxCount,@Z3Count,@Z6Count,@P5Sales,@P5Count)");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.DateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@code3", SqlDbType.Char,3),
					new SqlParameter("@code5", SqlDbType.Char,5),
					new SqlParameter("@testcode", SqlDbType.Char,3),
					new SqlParameter("@machine", SqlDbType.TinyInt,1),
					new SqlParameter("@ball", SqlDbType.TinyInt,1),
					new SqlParameter("@LastModifyTime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,50),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,50),
					new SqlParameter("@P3Sales", SqlDbType.Int,4),
					new SqlParameter("@DxCount", SqlDbType.Int,4),
					new SqlParameter("@Z3Count", SqlDbType.Int,4),
					new SqlParameter("@Z6Count", SqlDbType.Int,4),
					new SqlParameter("@P5Sales", SqlDbType.Int,4),
					new SqlParameter("@P5Count", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code3;
            parameters[3].Value = model.code5;
            parameters[4].Value = model.testcode;
            parameters[5].Value = model.machine;
            parameters[6].Value = model.ball;
            parameters[7].Value = model.LastModifyTime;
            parameters[8].Value = model.OpName;
            parameters[9].Value = model.OpIp;
            parameters[10].Value = model.P3Sales;
            parameters[11].Value = model.DxCount;
            parameters[12].Value = model.Z3Count;
            parameters[13].Value = model.Z6Count;
            parameters[14].Value = model.P5Sales;
            parameters[15].Value = model.P5Count;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.TCPL35Data model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update TCPL35Data set ");
            strSql.Append("code3=@code3,");
            strSql.Append("code5=@code5,");
            strSql.Append("testcode=@testcode,");
            strSql.Append("machine=@machine,");
            strSql.Append("LastModifyTime=@LastModifyTime,");
            strSql.Append("OpName=@OpName,");
            strSql.Append("OpIp=@OpIp,");
            strSql.Append("P3Sales=@P3Sales,");
            strSql.Append("DxCount=@DxCount,");
            strSql.Append("Z3Count=@Z3Count,");
            strSql.Append("Z6Count=@Z6Count,");
            strSql.Append("P5Sales=@P5Sales,");
            strSql.Append("P5Count=@P5Count");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@date", SqlDbType.DateTime),
					new SqlParameter("@issue", SqlDbType.Char,7),
					new SqlParameter("@code3", SqlDbType.Char,3),
					new SqlParameter("@code5", SqlDbType.Char,5),
					new SqlParameter("@testcode", SqlDbType.Char,3),
					new SqlParameter("@machine", SqlDbType.TinyInt,1),
					new SqlParameter("@ball", SqlDbType.TinyInt,1),
					new SqlParameter("@LastModifyTime", SqlDbType.DateTime),
					new SqlParameter("@OpName", SqlDbType.NVarChar,50),
					new SqlParameter("@OpIp", SqlDbType.NVarChar,50),
					new SqlParameter("@P3Sales", SqlDbType.Int,4),
					new SqlParameter("@DxCount", SqlDbType.Int,4),
					new SqlParameter("@Z3Count", SqlDbType.Int,4),
					new SqlParameter("@Z6Count", SqlDbType.Int,4),
					new SqlParameter("@P5Sales", SqlDbType.Int,4),
					new SqlParameter("@P5Count", SqlDbType.SmallInt,2)};
            parameters[0].Value = model.date;
            parameters[1].Value = model.issue;
            parameters[2].Value = model.code3;
            parameters[3].Value = model.code5;
            parameters[4].Value = model.testcode;
            parameters[5].Value = model.machine;
            parameters[6].Value = model.ball;
            parameters[7].Value = model.LastModifyTime;
            parameters[8].Value = model.OpName;
            parameters[9].Value = model.OpIp;
            parameters[10].Value = model.P3Sales;
            parameters[11].Value = model.DxCount;
            parameters[12].Value = model.Z3Count;
            parameters[13].Value = model.Z6Count;
            parameters[14].Value = model.P5Sales;
            parameters[15].Value = model.P5Count;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from TCPL35Data ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.TCPL35Data GetModel(string issue)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 date,issue,code3,code5,testcode,machine,ball,LastModifyTime,OpName,OpIp,P3Sales,DxCount,Z3Count,Z6Count,P5Sales,P5Count from TCPL35Data ");
            strSql.Append(" where issue=@issue ");
            SqlParameter[] parameters = {
					new SqlParameter("@issue", SqlDbType.Char,10)};
            parameters[0].Value = issue;

            Pbzx.Model.TCPL35Data model = new Pbzx.Model.TCPL35Data();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["date"].ToString() != "")
                {
                    model.date = DateTime.Parse(ds.Tables[0].Rows[0]["date"].ToString());
                }
                model.issue = ds.Tables[0].Rows[0]["issue"].ToString();
                model.code3 = ds.Tables[0].Rows[0]["code3"].ToString();
                model.code5 = ds.Tables[0].Rows[0]["code5"].ToString();
                model.testcode = ds.Tables[0].Rows[0]["testcode"].ToString();
                if (ds.Tables[0].Rows[0]["machine"].ToString() != "")
                {
                    model.machine = int.Parse(ds.Tables[0].Rows[0]["machine"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ball"].ToString() != "")
                {
                    model.ball = int.Parse(ds.Tables[0].Rows[0]["ball"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LastModifyTime"].ToString() != "")
                {
                    model.LastModifyTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastModifyTime"].ToString());
                }
                model.OpName = ds.Tables[0].Rows[0]["OpName"].ToString();
                model.OpIp = ds.Tables[0].Rows[0]["OpIp"].ToString();
                if (ds.Tables[0].Rows[0]["P3Sales"].ToString() != "")
                {
                    model.P3Sales = int.Parse(ds.Tables[0].Rows[0]["P3Sales"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DxCount"].ToString() != "")
                {
                    model.DxCount = int.Parse(ds.Tables[0].Rows[0]["DxCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Z3Count"].ToString() != "")
                {
                    model.Z3Count = int.Parse(ds.Tables[0].Rows[0]["Z3Count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Z6Count"].ToString() != "")
                {
                    model.Z6Count = int.Parse(ds.Tables[0].Rows[0]["Z6Count"].ToString());
                }
                if (ds.Tables[0].Rows[0]["P5Sales"].ToString() != "")
                {
                    model.P5Sales = int.Parse(ds.Tables[0].Rows[0]["P5Sales"].ToString());
                }
                if (ds.Tables[0].Rows[0]["P5Count"].ToString() != "")
                {
                    model.P5Count = int.Parse(ds.Tables[0].Rows[0]["P5Count"].ToString());
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
            strSql.Append("select date,issue,code3,code5,testcode,machine,ball,LastModifyTime,OpName,OpIp,P3Sales,DxCount,Z3Count,Z6Count,P5Sales,P5Count ");
            strSql.Append(" FROM TCPL35Data ");
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
            strSql.Append(" date,issue,code3,code5,testcode,machine,ball,LastModifyTime,OpName,OpIp,P3Sales,DxCount,Z3Count,Z6Count,P5Sales,P5Count ");
            strSql.Append(" FROM TCPL35Data ");
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
            parameters[0].Value = "TCPL35Data";
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

