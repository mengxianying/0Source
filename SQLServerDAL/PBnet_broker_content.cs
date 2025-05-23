using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_broker_content。
    /// </summary>
    public class PBnet_broker_content : IPBnet_broker_content
    {
        public PBnet_broker_content()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_broker_content");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_broker_content model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_broker_content(");
            strSql.Append("Btitle,Bcontent,Btype,IntSortID,IsAuditing,BaddTime)");
            strSql.Append(" values (");
            strSql.Append("@Btitle,@Bcontent,@Btype,@IntSortID,@IsAuditing,@BaddTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Btitle", SqlDbType.NVarChar,100),
					new SqlParameter("@Bcontent", SqlDbType.NText),
					new SqlParameter("@Btype", SqlDbType.Char,10),
					new SqlParameter("@IntSortID", SqlDbType.Int,4),
					new SqlParameter("@IsAuditing", SqlDbType.Bit,1),
					new SqlParameter("@BaddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.Btitle;
            parameters[1].Value = model.Bcontent;
            parameters[2].Value = model.Btype;
            parameters[3].Value = model.IntSortID;
            parameters[4].Value = model.IsAuditing;
            parameters[5].Value = model.BaddTime;

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
        public int Update(Pbzx.Model.PBnet_broker_content model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_broker_content set ");
            strSql.Append("Btitle=@Btitle,");
            strSql.Append("Bcontent=@Bcontent,");
            strSql.Append("Btype=@Btype,");
            strSql.Append("IntSortID=@IntSortID,");
            strSql.Append("IsAuditing=@IsAuditing,");
            strSql.Append("BaddTime=@BaddTime");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Btitle", SqlDbType.NVarChar,100),
					new SqlParameter("@Bcontent", SqlDbType.NText),
					new SqlParameter("@Btype", SqlDbType.Char,10),
					new SqlParameter("@IntSortID", SqlDbType.Int,4),
					new SqlParameter("@IsAuditing", SqlDbType.Bit,1),
					new SqlParameter("@BaddTime", SqlDbType.DateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Btitle;
            parameters[2].Value = model.Bcontent;
            parameters[3].Value = model.Btype;
            parameters[4].Value = model.IntSortID;
            parameters[5].Value = model.IsAuditing;
            parameters[6].Value = model.BaddTime;

          return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_broker_content ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_broker_content GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Btitle,Bcontent,Btype,IntSortID,IsAuditing,BaddTime from PBnet_broker_content ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_broker_content model = new Pbzx.Model.PBnet_broker_content();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Btitle = ds.Tables[0].Rows[0]["Btitle"].ToString();
                model.Bcontent = ds.Tables[0].Rows[0]["Bcontent"].ToString();
                model.Btype = ds.Tables[0].Rows[0]["Btype"].ToString();
                if (ds.Tables[0].Rows[0]["IntSortID"].ToString() != "")
                {
                    model.IntSortID = int.Parse(ds.Tables[0].Rows[0]["IntSortID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsAuditing"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsAuditing"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsAuditing"].ToString().ToLower() == "true"))
                    {
                        model.IsAuditing = true;
                    }
                    else
                    {
                        model.IsAuditing = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["BaddTime"].ToString() != "")
                {
                    model.BaddTime = DateTime.Parse(ds.Tables[0].Rows[0]["BaddTime"].ToString());
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
            strSql.Append("select ID,Btitle,Bcontent,Btype,IntSortID,IsAuditing,BaddTime ");
            strSql.Append(" FROM PBnet_broker_content ");
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
            strSql.Append(" ID,Btitle,Bcontent,Btype,IntSortID,IsAuditing,BaddTime ");
            strSql.Append(" FROM PBnet_broker_content ");
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
            parameters[0].Value = "PBnet_broker_content";
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

