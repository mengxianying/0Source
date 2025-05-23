using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_Channel。
    /// </summary>
    public class PBnet_Channel : IPBnet_Channel
    {
        public PBnet_Channel()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ChannelID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_Channel");
            strSql.Append(" where ChannelID=@ChannelID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ChannelID", SqlDbType.Int,4)};
            parameters[0].Value = ChannelID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_Channel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_Channel(");
            strSql.Append("ChannelName,ChannelFID,IsAuditing,OrderID,Depth,RootID,ChannelFIDS)");
            strSql.Append(" values (");
            strSql.Append("@ChannelName,@ChannelFID,@IsAuditing,@OrderID,@Depth,@RootID,@ChannelFIDS)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ChannelName", SqlDbType.VarChar,100),
					new SqlParameter("@ChannelFID", SqlDbType.Int,4),
					new SqlParameter("@IsAuditing", SqlDbType.Bit,1),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@ChannelFIDS", SqlDbType.VarChar,255)};
            parameters[0].Value = model.ChannelName;
            parameters[1].Value = model.ChannelFID;
            parameters[2].Value = model.IsAuditing;
            parameters[3].Value = model.OrderID;
            parameters[4].Value = model.Depth;
            parameters[5].Value = model.RootID;
            parameters[6].Value = model.ChannelFIDS;

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
        public void Update(Pbzx.Model.PBnet_Channel model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_Channel set ");
            strSql.Append("ChannelName=@ChannelName,");
            strSql.Append("ChannelFID=@ChannelFID,");
            strSql.Append("IsAuditing=@IsAuditing,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("Depth=@Depth,");
            strSql.Append("RootID=@RootID,");
            strSql.Append("ChannelFIDS=@ChannelFIDS");
            strSql.Append(" where ChannelID=@ChannelID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ChannelID", SqlDbType.Int,4),
					new SqlParameter("@ChannelName", SqlDbType.VarChar,100),
					new SqlParameter("@ChannelFID", SqlDbType.Int,4),
					new SqlParameter("@IsAuditing", SqlDbType.Bit,1),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@ChannelFIDS", SqlDbType.VarChar,255)};
            parameters[0].Value = model.ChannelID;
            parameters[1].Value = model.ChannelName;
            parameters[2].Value = model.ChannelFID;
            parameters[3].Value = model.IsAuditing;
            parameters[4].Value = model.OrderID;
            parameters[5].Value = model.Depth;
            parameters[6].Value = model.RootID;
            parameters[7].Value = model.ChannelFIDS;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ChannelID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_Channel ");
            strSql.Append(" where ChannelID=@ChannelID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ChannelID", SqlDbType.Int,4)};
            parameters[0].Value = ChannelID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_Channel GetModel(int ChannelID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ChannelID,ChannelName,ChannelFID,IsAuditing,OrderID,Depth,RootID,ChannelFIDS from PBnet_Channel ");
            strSql.Append(" where ChannelID=@ChannelID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ChannelID", SqlDbType.Int,4)};
            parameters[0].Value = ChannelID;

            Pbzx.Model.PBnet_Channel model = new Pbzx.Model.PBnet_Channel();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ChannelID"].ToString() != "")
                {
                    model.ChannelID = int.Parse(ds.Tables[0].Rows[0]["ChannelID"].ToString());
                }
                model.ChannelName = ds.Tables[0].Rows[0]["ChannelName"].ToString();
                if (ds.Tables[0].Rows[0]["ChannelFID"].ToString() != "")
                {
                    model.ChannelFID = int.Parse(ds.Tables[0].Rows[0]["ChannelFID"].ToString());
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
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RootID"].ToString() != "")
                {
                    model.RootID = int.Parse(ds.Tables[0].Rows[0]["RootID"].ToString());
                }
                model.ChannelFIDS = ds.Tables[0].Rows[0]["ChannelFIDS"].ToString();
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
            strSql.Append("select ChannelID,ChannelName,ChannelFID,IsAuditing,OrderID,Depth,RootID,ChannelFIDS ");
            strSql.Append(" FROM PBnet_Channel ");
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
            strSql.Append(" ChannelID,ChannelName,ChannelFID,IsAuditing,OrderID,Depth,RootID,ChannelFIDS ");
            strSql.Append(" FROM PBnet_Channel ");
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
            parameters[0].Value = "PBnet_Channel";
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

