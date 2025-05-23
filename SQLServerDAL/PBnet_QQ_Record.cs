using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_QQ_Record。
    /// </summary>
    public class PBnet_QQ_Record : IPBnet_QQ_Record
    {
        public PBnet_QQ_Record()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_QQ_Record");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_QQ_Record model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_QQ_Record(");
            strSql.Append("QQ_GropID,QQ_ID,UserName,OnlineState,QQ_Detail,AddManager,AddTime,KickOffManager,KickOffTime,IsLock,UpdateManager)");
            strSql.Append(" values (");
            strSql.Append("@QQ_GropID,@QQ_ID,@UserName,@OnlineState,@QQ_Detail,@AddManager,@AddTime,@KickOffManager,@KickOffTime,@IsLock,@UpdateManager)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@QQ_GropID", SqlDbType.Int,4),
					new SqlParameter("@QQ_ID", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@OnlineState", SqlDbType.SmallInt,2),
					new SqlParameter("@QQ_Detail", SqlDbType.VarChar,2000),
					new SqlParameter("@AddManager", SqlDbType.VarChar,50),
					new SqlParameter("@AddTime", SqlDbType.SmallDateTime),
					new SqlParameter("@KickOffManager", SqlDbType.VarChar,50),
					new SqlParameter("@KickOffTime", SqlDbType.SmallDateTime),
                    new SqlParameter("@IsLock", SqlDbType.Bit,1),
                    new SqlParameter("@UpdateManager",SqlDbType.VarChar)
            };
            parameters[0].Value = model.QQ_GropID;
            parameters[1].Value = model.QQ_ID;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.OnlineState;
            parameters[4].Value = model.QQ_Detail;
            parameters[5].Value = model.AddManager;

            parameters[6].Value = model.AddTime;
            if (model.AddTime == null)
            {
                parameters[6].Value = null;
            }
            parameters[7].Value = model.KickOffManager;
            if (model.KickOffManager == null)
            {
                parameters[7].Value = null;
            }
            parameters[8].Value = model.KickOffTime;
            parameters[9].Value = model.IsLock;
            parameters[10].Value = model.UpdateManager;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.PBnet_QQ_Record model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_QQ_Record set ");
            strSql.Append("QQ_GropID=@QQ_GropID,");
            strSql.Append("QQ_ID=@QQ_ID,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("OnlineState=@OnlineState,");
            strSql.Append("QQ_Detail=@QQ_Detail,");
            strSql.Append("AddManager=@AddManager,");
            strSql.Append("AddTime=@AddTime,");
            strSql.Append("KickOffManager=@KickOffManager,");
            strSql.Append("KickOffTime=@KickOffTime,");
            strSql.Append("IsLock=@IsLock,");
            strSql.Append("UpdateManager=@UpdateManager");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@QQ_GropID", SqlDbType.Int,4),
					new SqlParameter("@QQ_ID", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@OnlineState", SqlDbType.SmallInt,2),
					new SqlParameter("@QQ_Detail", SqlDbType.VarChar,2000),
					new SqlParameter("@AddManager", SqlDbType.VarChar,50),
					new SqlParameter("@AddTime", SqlDbType.SmallDateTime),
					new SqlParameter("@KickOffManager", SqlDbType.VarChar,50),
					new SqlParameter("@KickOffTime", SqlDbType.SmallDateTime),
                    new SqlParameter("@IsLock", SqlDbType.Bit,1),
                    new SqlParameter("@UpdateManager",SqlDbType.VarChar)
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.QQ_GropID;
            parameters[2].Value = model.QQ_ID;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.OnlineState;
            parameters[5].Value = model.QQ_Detail;
            parameters[6].Value = model.AddManager;
            parameters[7].Value = model.AddTime;
            if (model.AddTime == null)
            {
                parameters[7].Value = null;
            }

            parameters[8].Value = model.KickOffManager;
            if (model.KickOffManager == null)
            {
                parameters[8].Value = null;
            }
            parameters[9].Value = model.KickOffTime;
            parameters[10].Value = model.IsLock;
            parameters[11].Value = model.UpdateManager;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_QQ_Record ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_QQ_Record GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,QQ_GropID,QQ_ID,UserName,OnlineState,QQ_Detail,AddManager,AddTime,KickOffManager,KickOffTime,IsLock,UpdateManager from PBnet_QQ_Record ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_QQ_Record model = new Pbzx.Model.PBnet_QQ_Record();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QQ_GropID"].ToString() != "")
                {
                    model.QQ_GropID = int.Parse(ds.Tables[0].Rows[0]["QQ_GropID"].ToString());
                }
                model.QQ_ID = ds.Tables[0].Rows[0]["QQ_ID"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["OnlineState"].ToString() != "")
                {
                    model.OnlineState = int.Parse(ds.Tables[0].Rows[0]["OnlineState"].ToString());
                }
                model.QQ_Detail = ds.Tables[0].Rows[0]["QQ_Detail"].ToString();
                model.AddManager = ds.Tables[0].Rows[0]["AddManager"].ToString();
                if (ds.Tables[0].Rows[0]["AddTime"].ToString() != "")
                {
                    model.AddTime = DateTime.Parse(ds.Tables[0].Rows[0]["AddTime"].ToString());
                }
                model.KickOffManager = ds.Tables[0].Rows[0]["KickOffManager"].ToString();
                if (ds.Tables[0].Rows[0]["KickOffTime"].ToString() != "")
                {
                    model.KickOffTime = DateTime.Parse(ds.Tables[0].Rows[0]["KickOffTime"].ToString());
                }

                if (ds.Tables[0].Rows[0]["IsLock"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsLock"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsLock"].ToString().ToLower() == "true"))
                    {
                        model.IsLock = true;
                    }
                    else
                    {
                        model.IsLock = false;
                    }
                }

                model.UpdateManager = ds.Tables[0].Rows[0]["UpdateManager"].ToString();

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
            strSql.Append("select ID,QQ_GropID,QQ_ID,UserName,OnlineState,QQ_Detail,AddManager,AddTime,KickOffManager,KickOffTime,IsLock,UpdateManager ");
            strSql.Append(" FROM PBnet_QQ_Record ");
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
            strSql.Append(" ID,QQ_GropID,QQ_ID,UserName,OnlineState,QQ_Detail,AddManager,AddTime,KickOffManager,KickOffTime,IsLock,UpdateManager ");
            strSql.Append(" FROM PBnet_QQ_Record ");
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
            parameters[0].Value = "PBnet_QQ_Record";
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

