using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
	/// <summary>
	/// 数据访问类PBnet_LotteryMenu。
	/// </summary>
	public class PBnet_LotteryMenu:IPBnet_LotteryMenu
	{
		public PBnet_LotteryMenu()
		{}
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("IntId", "PBnet_LotteryMenu");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int IntId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_LotteryMenu");
            strSql.Append(" where IntId=@IntId ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntId", SqlDbType.Int,4)};
            parameters[0].Value = IntId;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int  Add(Pbzx.Model.PBnet_LotteryMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_LotteryMenu(");
            strSql.Append("NvarName,NvarClass,IntClass_OrderId,NvarOrderId,BitIs_show,BitState,IntCase,NvarApp_name,NvarLott_date,Url,DayLottCount,TimeList,LottTypeCount,LottTypeInfo,LottWebsites,Mark,IsRefresh,IssueLen,IssueInfo)");
            strSql.Append(" values (");
            strSql.Append("@NvarName,@NvarClass,@IntClass_OrderId,@NvarOrderId,@BitIs_show,@BitState,@IntCase,@NvarApp_name,@NvarLott_date,@Url,@DayLottCount,@TimeList,@LottTypeCount,@LottTypeInfo,@LottWebsites,@Mark,@IsRefresh,@IssueLen,@IssueInfo)");
            SqlParameter[] parameters = {
					new SqlParameter("@NvarName", SqlDbType.NVarChar,50),
					new SqlParameter("@NvarClass", SqlDbType.NVarChar,50),
					new SqlParameter("@IntClass_OrderId", SqlDbType.Int,4),
					new SqlParameter("@NvarOrderId", SqlDbType.Int,4),
					new SqlParameter("@BitIs_show", SqlDbType.Bit,1),
					new SqlParameter("@BitState", SqlDbType.Bit,1),
					new SqlParameter("@IntCase", SqlDbType.Int,4),
					new SqlParameter("@NvarApp_name", SqlDbType.NVarChar,30),
					new SqlParameter("@NvarLott_date", SqlDbType.NVarChar,5),
					new SqlParameter("@Url", SqlDbType.VarChar,100),
					new SqlParameter("@DayLottCount", SqlDbType.Int,4),
					new SqlParameter("@TimeList", SqlDbType.VarChar,800),
					new SqlParameter("@LottTypeCount", SqlDbType.Int,4),
					new SqlParameter("@LottTypeInfo", SqlDbType.VarChar,120),
					new SqlParameter("@LottWebsites", SqlDbType.VarChar,1000),
					new SqlParameter("@Mark", SqlDbType.NVarChar,512),
					new SqlParameter("@IsRefresh", SqlDbType.Bit,1),
					new SqlParameter("@IssueLen", SqlDbType.SmallInt,2),
					new SqlParameter("@IssueInfo", SqlDbType.VarChar,50)};
            parameters[0].Value = model.NvarName;
            parameters[1].Value = model.NvarClass;
            parameters[2].Value = model.IntClass_OrderId;
            parameters[3].Value = model.NvarOrderId;
            parameters[4].Value = model.BitIs_show;
            parameters[5].Value = model.BitState;
            parameters[6].Value = model.IntCase;
            parameters[7].Value = model.NvarApp_name;
            parameters[8].Value = model.NvarLott_date;
            parameters[9].Value = model.Url;
            parameters[10].Value = model.DayLottCount;
            parameters[11].Value = model.TimeList;
            parameters[12].Value = model.LottTypeCount;
            parameters[13].Value = model.LottTypeInfo;
            parameters[14].Value = model.LottWebsites;
            parameters[15].Value = model.Mark;
            parameters[16].Value = model.IsRefresh;
            parameters[17].Value = model.IssueLen;
            parameters[18].Value = model.IssueInfo;

           return   DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int  Update(Pbzx.Model.PBnet_LotteryMenu model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_LotteryMenu set ");

            strSql.Append("NvarName=@NvarName,");
            strSql.Append("NvarClass=@NvarClass,");
            strSql.Append("IntClass_OrderId=@IntClass_OrderId,");
            strSql.Append("NvarOrderId=@NvarOrderId,");
            strSql.Append("BitIs_show=@BitIs_show,");
            strSql.Append("BitState=@BitState,");
            strSql.Append("IntCase=@IntCase,");
            strSql.Append("NvarApp_name=@NvarApp_name,");
            strSql.Append("NvarLott_date=@NvarLott_date,");
            strSql.Append("Url=@Url,");
            strSql.Append("DayLottCount=@DayLottCount,");
            strSql.Append("TimeList=@TimeList,");
            strSql.Append("LottTypeCount=@LottTypeCount,");
            strSql.Append("LottTypeInfo=@LottTypeInfo,");
            strSql.Append("LottWebsites=@LottWebsites,");
            strSql.Append("Mark=@Mark,");
            strSql.Append("IsRefresh=@IsRefresh,");
            strSql.Append("IssueLen=@IssueLen,");
            strSql.Append("IssueInfo=@IssueInfo");

            strSql.Append(" where IntId=@IntId ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntId", SqlDbType.Int,4),
					new SqlParameter("@NvarName", SqlDbType.NVarChar,50),
					new SqlParameter("@NvarClass", SqlDbType.NVarChar,50),
					new SqlParameter("@IntClass_OrderId", SqlDbType.Int,4),
					new SqlParameter("@NvarOrderId", SqlDbType.Int,4),
					new SqlParameter("@BitIs_show", SqlDbType.Bit,1),
					new SqlParameter("@BitState", SqlDbType.Bit,1),
					new SqlParameter("@IntCase", SqlDbType.Int,4),
					new SqlParameter("@NvarApp_name", SqlDbType.NVarChar,30),
					new SqlParameter("@NvarLott_date", SqlDbType.NVarChar,5),
					new SqlParameter("@Url", SqlDbType.VarChar,100),
					new SqlParameter("@DayLottCount", SqlDbType.Int,4),
					new SqlParameter("@TimeList", SqlDbType.VarChar,800),
					new SqlParameter("@LottTypeCount", SqlDbType.Int,4),
					new SqlParameter("@LottTypeInfo", SqlDbType.VarChar,120),
					new SqlParameter("@LottWebsites", SqlDbType.VarChar,1000),
					new SqlParameter("@Mark", SqlDbType.NVarChar,512),
					new SqlParameter("@IsRefresh", SqlDbType.Bit,1),
					new SqlParameter("@IssueLen", SqlDbType.SmallInt,2),
					new SqlParameter("@IssueInfo", SqlDbType.VarChar,50)};
            parameters[0].Value = model.IntId;
            parameters[1].Value = model.NvarName;
            parameters[2].Value = model.NvarClass;
            parameters[3].Value = model.IntClass_OrderId;
            parameters[4].Value = model.NvarOrderId;
            parameters[5].Value = model.BitIs_show;
            parameters[6].Value = model.BitState;
            parameters[7].Value = model.IntCase;
            parameters[8].Value = model.NvarApp_name;
            parameters[9].Value = model.NvarLott_date;
            parameters[10].Value = model.Url;
            parameters[11].Value = model.DayLottCount;
            parameters[12].Value = model.TimeList;
            parameters[13].Value = model.LottTypeCount;
            parameters[14].Value = model.LottTypeInfo;
            parameters[15].Value = model.LottWebsites;
            parameters[16].Value = model.Mark;
            parameters[17].Value = model.IsRefresh;
            parameters[18].Value = model.IssueLen;
            parameters[19].Value = model.IssueInfo;

           return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  Delete(int IntId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_LotteryMenu ");
            strSql.Append(" where IntId=@IntId ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntId", SqlDbType.Int,4)};
            parameters[0].Value = IntId;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_LotteryMenu GetModel(int IntId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 IntId,NvarName,NvarClass,IntClass_OrderId,NvarOrderId,BitIs_show,BitState,IntCase,NvarApp_name,NvarLott_date,Url,DayLottCount,TimeList,LottTypeCount,LottTypeInfo,LottWebsites,Mark,IsRefresh,IssueLen,IssueInfo from PBnet_LotteryMenu ");
            strSql.Append(" where IntId=@IntId ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntId", SqlDbType.Int,4)};
            parameters[0].Value = IntId;

            Pbzx.Model.PBnet_LotteryMenu model = new Pbzx.Model.PBnet_LotteryMenu();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["IntId"].ToString() != "")
                {
                    model.IntId = int.Parse(ds.Tables[0].Rows[0]["IntId"].ToString());
                }
                model.NvarName = ds.Tables[0].Rows[0]["NvarName"].ToString();
                model.NvarClass = ds.Tables[0].Rows[0]["NvarClass"].ToString();
                if (ds.Tables[0].Rows[0]["IntClass_OrderId"].ToString() != "")
                {
                    model.IntClass_OrderId = int.Parse(ds.Tables[0].Rows[0]["IntClass_OrderId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NvarOrderId"].ToString() != "")
                {
                    model.NvarOrderId = int.Parse(ds.Tables[0].Rows[0]["NvarOrderId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BitIs_show"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BitIs_show"].ToString() == "1") || (ds.Tables[0].Rows[0]["BitIs_show"].ToString().ToLower() == "true"))
                    {
                        model.BitIs_show = true;
                    }
                    else
                    {
                        model.BitIs_show = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["BitState"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BitState"].ToString() == "1") || (ds.Tables[0].Rows[0]["BitState"].ToString().ToLower() == "true"))
                    {
                        model.BitState = true;
                    }
                    else
                    {
                        model.BitState = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IntCase"].ToString() != "")
                {
                    model.IntCase = int.Parse(ds.Tables[0].Rows[0]["IntCase"].ToString());
                }
                model.NvarApp_name = ds.Tables[0].Rows[0]["NvarApp_name"].ToString();
                model.NvarLott_date = ds.Tables[0].Rows[0]["NvarLott_date"].ToString();
                model.Url = ds.Tables[0].Rows[0]["Url"].ToString();
                if (ds.Tables[0].Rows[0]["DayLottCount"].ToString() != "")
                {
                    model.DayLottCount = int.Parse(ds.Tables[0].Rows[0]["DayLottCount"].ToString());
                }
                model.TimeList = ds.Tables[0].Rows[0]["TimeList"].ToString();
                if (ds.Tables[0].Rows[0]["LottTypeCount"].ToString() != "")
                {
                    model.LottTypeCount = int.Parse(ds.Tables[0].Rows[0]["LottTypeCount"].ToString());
                }
                model.LottTypeInfo = ds.Tables[0].Rows[0]["LottTypeInfo"].ToString();
                model.LottWebsites = ds.Tables[0].Rows[0]["LottWebsites"].ToString();
                model.Mark = ds.Tables[0].Rows[0]["Mark"].ToString();
                if (ds.Tables[0].Rows[0]["IsRefresh"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsRefresh"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsRefresh"].ToString().ToLower() == "true"))
                    {
                        model.IsRefresh = true;
                    }
                    else
                    {
                        model.IsRefresh = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["IssueLen"].ToString() != "")
                {
                    model.IssueLen = int.Parse(ds.Tables[0].Rows[0]["IssueLen"].ToString());
                }
                model.IssueInfo = ds.Tables[0].Rows[0]["IssueInfo"].ToString();
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
            strSql.Append("select IntId,NvarName,NvarClass,IntClass_OrderId,NvarOrderId,BitIs_show,BitState,IntCase,NvarApp_name,NvarLott_date,Url,DayLottCount,TimeList,LottTypeCount,LottTypeInfo,LottWebsites,Mark,IsRefresh,IssueLen,IssueInfo ");
            strSql.Append(" FROM PBnet_LotteryMenu ");
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
            strSql.Append(" IntId,NvarName,NvarClass,IntClass_OrderId,NvarOrderId,BitIs_show,BitState,IntCase,NvarApp_name,NvarLott_date,Url,DayLottCount,TimeList,LottTypeCount,LottTypeInfo,LottWebsites,Mark,IsRefresh,IssueLen,IssueInfo ");
            strSql.Append(" FROM PBnet_LotteryMenu ");
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
            parameters[0].Value = "PBnet_LotteryMenu";
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

