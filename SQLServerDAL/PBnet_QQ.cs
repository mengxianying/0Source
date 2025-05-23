using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_QQ。
    /// </summary>
    public class PBnet_QQ : IPBnet_QQ
    {
        public PBnet_QQ()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int IntId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_QQ");
            strSql.Append(" where IntId=@IntId ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntId", SqlDbType.Int,4)};
            parameters[0].Value = IntId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_QQ model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_QQ(");
            strSql.Append("VarQQNumber,VarName,IntDisplayPosition,IntOrderID,BitIsAuditing,Team,Tel)");
            strSql.Append(" values (");
            strSql.Append("@VarQQNumber,@VarName,@IntDisplayPosition,@IntOrderID,@BitIsAuditing,@Team,@Tel)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@VarQQNumber", SqlDbType.VarChar,50),
					new SqlParameter("@VarName", SqlDbType.VarChar,50),
					new SqlParameter("@IntDisplayPosition", SqlDbType.Int,4),
					new SqlParameter("@IntOrderID", SqlDbType.Int,4),
					new SqlParameter("@BitIsAuditing", SqlDbType.Bit,1),
					new SqlParameter("@Team", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50)};
            parameters[0].Value = model.VarQQNumber;
            parameters[1].Value = model.VarName;
            parameters[2].Value = model.IntDisplayPosition;
            parameters[3].Value = model.IntOrderID;
            parameters[4].Value = model.BitIsAuditing;
            parameters[5].Value = model.Team;
            parameters[6].Value = model.Tel;

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
        public int Update(Pbzx.Model.PBnet_QQ model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_QQ set ");
            strSql.Append("VarQQNumber=@VarQQNumber,");
            strSql.Append("VarName=@VarName,");
            strSql.Append("IntDisplayPosition=@IntDisplayPosition,");
            strSql.Append("IntOrderID=@IntOrderID,");
            strSql.Append("BitIsAuditing=@BitIsAuditing,");
            strSql.Append("Team=@Team,");
            strSql.Append("Tel=@Tel");
            strSql.Append(" where IntId=@IntId ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntId", SqlDbType.Int,4),
					new SqlParameter("@VarQQNumber", SqlDbType.VarChar,50),
					new SqlParameter("@VarName", SqlDbType.VarChar,50),
					new SqlParameter("@IntDisplayPosition", SqlDbType.Int,4),
					new SqlParameter("@IntOrderID", SqlDbType.Int,4),
					new SqlParameter("@BitIsAuditing", SqlDbType.Bit,1),
					new SqlParameter("@Team", SqlDbType.VarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,50)};
            parameters[0].Value = model.IntId;
            parameters[1].Value = model.VarQQNumber;
            parameters[2].Value = model.VarName;
            parameters[3].Value = model.IntDisplayPosition;
            parameters[4].Value = model.IntOrderID;
            parameters[5].Value = model.BitIsAuditing;
            parameters[6].Value = model.Team;
            parameters[7].Value = model.Tel;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int IntId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_QQ ");
            strSql.Append(" where IntId=@IntId ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntId", SqlDbType.Int,4)};
            parameters[0].Value = IntId;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_QQ GetModel(int IntId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 IntId,VarQQNumber,VarName,IntDisplayPosition,IntOrderID,BitIsAuditing,Team,Tel from PBnet_QQ ");
            strSql.Append(" where IntId=@IntId ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntId", SqlDbType.Int,4)};
            parameters[0].Value = IntId;

            Pbzx.Model.PBnet_QQ model = new Pbzx.Model.PBnet_QQ();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["IntId"].ToString() != "")
                {
                    model.IntId = int.Parse(ds.Tables[0].Rows[0]["IntId"].ToString());
                }
                model.VarQQNumber = ds.Tables[0].Rows[0]["VarQQNumber"].ToString();
                model.VarName = ds.Tables[0].Rows[0]["VarName"].ToString();
                if (ds.Tables[0].Rows[0]["IntDisplayPosition"].ToString() != "")
                {
                    model.IntDisplayPosition = int.Parse(ds.Tables[0].Rows[0]["IntDisplayPosition"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IntOrderID"].ToString() != "")
                {
                    model.IntOrderID = int.Parse(ds.Tables[0].Rows[0]["IntOrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BitIsAuditing"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BitIsAuditing"].ToString() == "1") || (ds.Tables[0].Rows[0]["BitIsAuditing"].ToString().ToLower() == "true"))
                    {
                        model.BitIsAuditing = true;
                    }
                    else
                    {
                        model.BitIsAuditing = false;
                    }
                }
                model.Team = ds.Tables[0].Rows[0]["Team"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
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
            strSql.Append("select IntId,VarQQNumber,VarName,IntDisplayPosition,IntOrderID,BitIsAuditing,Team,Tel ");
            strSql.Append(" FROM PBnet_QQ ");
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
            strSql.Append(" IntId,VarQQNumber,VarName,IntDisplayPosition,IntOrderID,BitIsAuditing,Team,Tel ");
            strSql.Append(" FROM PBnet_QQ ");
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
            parameters[0].Value = "PBnet_QQ";
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

