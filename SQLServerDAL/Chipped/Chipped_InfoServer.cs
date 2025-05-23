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
    public class Chipped_InfoServer:IChipped_Info
    {
        #region  成员方法

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string QNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_info");
            strSql.Append(" where QNumber=@QNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@QNumber", SqlDbType.NVarChar,50)};
            parameters[0].Value = QNumber;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_Info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_info(");
            strSql.Append("QNumber,ChippedName,ChippedShare,ChippedTime)");
            strSql.Append(" values (");
            strSql.Append("@QNumber,@ChippedName,@ChippedShare,@ChippedTime)");
            SqlParameter[] parameters = {
					new SqlParameter("@QNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@ChippedName", SqlDbType.NVarChar,50),
					new SqlParameter("@ChippedShare", SqlDbType.Int,4),
					new SqlParameter("@ChippedTime", SqlDbType.DateTime)};
            parameters[0].Value = model.QNumber;
            parameters[1].Value = model.ChippedName;
            parameters[2].Value = model.ChippedShare;
            parameters[3].Value = model.ChippedTime;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Chipped_Info model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_info set ");
            strSql.Append("ChippedName=@ChippedName,");
            strSql.Append("ChippedShare=@ChippedShare,");
            strSql.Append("ChippedTime=@ChippedTime");
            strSql.Append(" where QNumber=@QNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@QNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@ChippedName", SqlDbType.NVarChar,50),
					new SqlParameter("@ChippedShare", SqlDbType.Int,4),
					new SqlParameter("@ChippedTime", SqlDbType.DateTime)};
            parameters[0].Value = model.QNumber;
            parameters[1].Value = model.ChippedName;
            parameters[2].Value = model.ChippedShare;
            parameters[3].Value = model.ChippedTime;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string QNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_info ");
            strSql.Append(" where QNumber=@QNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@QNumber", SqlDbType.NVarChar,50)};
            parameters[0].Value = QNumber;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(string QNumber,string username)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_info ");
            strSql.Append(" where QNumber=@QNumber and username=@ChippedName");
            SqlParameter[] parameters = {
					new SqlParameter("@QNumber", SqlDbType.NVarChar,50),
                    new SqlParameter("@ChippedName", SqlDbType.NVarChar,50)};
            parameters[0].Value = QNumber;
             parameters[1].Value = username;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Chipped_Info GetModel(string QNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 QNumber,ChippedName,ChippedShare,ChippedTime from Chipped_info ");
            strSql.Append(" where QNumber=@QNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@QNumber", SqlDbType.NVarChar,50)};
            parameters[0].Value = QNumber;

            Pbzx.Model.Chipped_Info model = new Pbzx.Model.Chipped_Info();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                model.QNumber = ds.Tables[0].Rows[0]["QNumber"].ToString();
                model.ChippedName = ds.Tables[0].Rows[0]["ChippedName"].ToString();
                if (ds.Tables[0].Rows[0]["ChippedShare"].ToString() != "")
                {
                    model.ChippedShare = int.Parse(ds.Tables[0].Rows[0]["ChippedShare"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ChippedTime"].ToString() != "")
                {
                    model.ChippedTime = DateTime.Parse(ds.Tables[0].Rows[0]["ChippedTime"].ToString());
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
            strSql.Append("select QNumber,ChippedName,ChippedShare,ChippedTime ");
            strSql.Append(" FROM Chipped_info ");
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
            strSql.Append(" QNumber,ChippedName,ChippedShare,ChippedTime ");
            strSql.Append(" FROM Chipped_info ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
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
            parameters[0].Value = "Chipped_info";
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
