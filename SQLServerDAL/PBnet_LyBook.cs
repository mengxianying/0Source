using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_LyBook。
    /// </summary>
    public class PBnet_LyBook : IPBnet_LyBook
    {
        public PBnet_LyBook()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int SystemNumber)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_LyBook");
            strSql.Append(" where SystemNumber=@SystemNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@SystemNumber", SqlDbType.Int,4)};
            parameters[0].Value = SystemNumber;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_LyBook model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_LyBook(");
            strSql.Append("LyUserName,LyUserID,LySort,Ly_Phone,Ly_Email,LyContent,LyState,LyLogTime,LyLogIp)");
            strSql.Append(" values (");
            strSql.Append("@LyUserName,@LyUserID,@LySort,@Ly_Phone,@Ly_Email,@LyContent,@LyState,@LyLogTime,@LyLogIp)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@LyUserName", SqlDbType.VarChar,50),
					new SqlParameter("@LyUserID", SqlDbType.Int,4),
					new SqlParameter("@LySort", SqlDbType.Int,4),
					new SqlParameter("@Ly_Phone", SqlDbType.VarChar,100),
					new SqlParameter("@Ly_Email", SqlDbType.VarChar,100),
					new SqlParameter("@LyContent", SqlDbType.NText),
					new SqlParameter("@LyState", SqlDbType.TinyInt,1),
					new SqlParameter("@LyLogTime", SqlDbType.DateTime),
					new SqlParameter("@LyLogIp", SqlDbType.VarChar,50)};
            parameters[0].Value = model.LyUserName;
            parameters[1].Value = model.LyUserID;
            parameters[2].Value = model.LySort;
            parameters[3].Value = model.Ly_Phone;
            parameters[4].Value = model.Ly_Email;
            parameters[5].Value = model.LyContent;
            parameters[6].Value = model.LyState;
            parameters[7].Value = model.LyLogTime;
            parameters[8].Value = model.LyLogIp;

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
        public int Update(Pbzx.Model.PBnet_LyBook model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_LyBook set ");
            strSql.Append("LyUserName=@LyUserName,");
            strSql.Append("LyUserID=@LyUserID,");
            strSql.Append("LySort=@LySort,");
            strSql.Append("Ly_Phone=@Ly_Phone,");
            strSql.Append("Ly_Email=@Ly_Email,");
            strSql.Append("LyContent=@LyContent,");
            strSql.Append("LyState=@LyState,");
            strSql.Append("LyLogTime=@LyLogTime,");
            strSql.Append("LyLogIp=@LyLogIp");
            strSql.Append(" where SystemNumber=@SystemNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@SystemNumber", SqlDbType.Int,4),
					new SqlParameter("@LyUserName", SqlDbType.VarChar,50),
					new SqlParameter("@LyUserID", SqlDbType.Int,4),
					new SqlParameter("@LySort", SqlDbType.Int,4),
					new SqlParameter("@Ly_Phone", SqlDbType.VarChar,100),
					new SqlParameter("@Ly_Email", SqlDbType.VarChar,100),
					new SqlParameter("@LyContent", SqlDbType.NText),
					new SqlParameter("@LyState", SqlDbType.TinyInt,1),
					new SqlParameter("@LyLogTime", SqlDbType.DateTime),
					new SqlParameter("@LyLogIp", SqlDbType.VarChar,50)};
            parameters[0].Value = model.SystemNumber;
            parameters[1].Value = model.LyUserName;
            parameters[2].Value = model.LyUserID;
            parameters[3].Value = model.LySort;
            parameters[4].Value = model.Ly_Phone;
            parameters[5].Value = model.Ly_Email;
            parameters[6].Value = model.LyContent;
            parameters[7].Value = model.LyState;
            parameters[8].Value = model.LyLogTime;
            parameters[9].Value = model.LyLogIp;

          return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int SystemNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_LyBook ");
            strSql.Append(" where SystemNumber=@SystemNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@SystemNumber", SqlDbType.Int,4)};
            parameters[0].Value = SystemNumber;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_LyBook GetModel(int SystemNumber)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 SystemNumber,LyUserName,LyUserID,LySort,Ly_Phone,Ly_Email,LyContent,LyState,LyLogTime,LyLogIp from PBnet_LyBook ");
            strSql.Append(" where SystemNumber=@SystemNumber ");
            SqlParameter[] parameters = {
					new SqlParameter("@SystemNumber", SqlDbType.Int,4)};
            parameters[0].Value = SystemNumber;

            Pbzx.Model.PBnet_LyBook model = new Pbzx.Model.PBnet_LyBook();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SystemNumber"].ToString() != "")
                {
                    model.SystemNumber = int.Parse(ds.Tables[0].Rows[0]["SystemNumber"].ToString());
                }
                model.LyUserName = ds.Tables[0].Rows[0]["LyUserName"].ToString();
                if (ds.Tables[0].Rows[0]["LyUserID"].ToString() != "")
                {
                    model.LyUserID = int.Parse(ds.Tables[0].Rows[0]["LyUserID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LySort"].ToString() != "")
                {
                    model.LySort = int.Parse(ds.Tables[0].Rows[0]["LySort"].ToString());
                }
                model.Ly_Phone = ds.Tables[0].Rows[0]["Ly_Phone"].ToString();
                model.Ly_Email = ds.Tables[0].Rows[0]["Ly_Email"].ToString();
                model.LyContent = ds.Tables[0].Rows[0]["LyContent"].ToString();
                if (ds.Tables[0].Rows[0]["LyState"].ToString() != "")
                {
                    model.LyState = int.Parse(ds.Tables[0].Rows[0]["LyState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LyLogTime"].ToString() != "")
                {
                    model.LyLogTime = DateTime.Parse(ds.Tables[0].Rows[0]["LyLogTime"].ToString());
                }
                model.LyLogIp = ds.Tables[0].Rows[0]["LyLogIp"].ToString();
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
            strSql.Append("select SystemNumber,LyUserName,LyUserID,LySort,Ly_Phone,Ly_Email,LyContent,LyState,LyLogTime,LyLogIp ");
            strSql.Append(" FROM PBnet_LyBook ");
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
            strSql.Append(" SystemNumber,LyUserName,LyUserID,LySort,Ly_Phone,Ly_Email,LyContent,LyState,LyLogTime,LyLogIp ");
            strSql.Append(" FROM PBnet_LyBook ");
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
            parameters[0].Value = "PBnet_LyBook";
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

