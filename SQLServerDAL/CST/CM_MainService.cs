using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CM_MainService。
    /// </summary>
    public class CM_MainService : ICM_Main
    {
        #region ICM_Main 成员
        /// <summary>
        /// 根据ID判断数据是否存在
        /// </summary>
        /// <param name="ID">ID编号</param>
        /// <returns>bool值，找到返回true 否则为 false</returns>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CM_Main");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 消息添加方法
        /// </summary>
        /// <param name="main">消息对象</param>
        /// <returns>返回添加后的ID</returns>
        public int Add(Pbzx.Model.CM_Main main)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CM_Main(");
            strSql.Append("SoftInfo,regType,userClass,sender,[Type],category,state,postTime,beginTime,endTime,title,contentURL,lastTime,todayCount,totalCount,content,WebWidth,WebHeight,linkurl,UserName,HDSN)");
            strSql.Append(" values (");
            strSql.Append("@softInfo,@regType,@userClass,@sender,@mtype,@category,@state,@postTime,@beginTime,@endTime,@title,@contentURL,@lastTime,@todayCount,@totalCount,@content,@WebWidth,@WebHeight,@linkurl,@UserName,@HDSN)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = new SqlParameter[]
                     {
					new SqlParameter("@softInfo", main.SoftInfo),
					new SqlParameter("@regType", main.RegType),
					new SqlParameter("@userClass",main.UserClass),
					new SqlParameter("@sender", main.Sender),
					new SqlParameter("@mtype",  main.Mtype),
					new SqlParameter("@category",main.Category),
					new SqlParameter("@state",main.State),
					new SqlParameter("@postTime", main.PostTime),
					new SqlParameter("@beginTime",main.BeginTime),
					new SqlParameter("@endTime", main.EndTime),
                    new SqlParameter("@title",main.Title),
					new SqlParameter("@contentURL", main.ContentURL),
					new SqlParameter("@lastTime", main.LastTime),
					new SqlParameter("@todayCount", main.TodayCount),
					new SqlParameter("@totalCount", main.TotalCount),
					new SqlParameter("@content", main.Content),
                    new SqlParameter("@WebWidth",main.WebWidth),
                    new SqlParameter("@WebHeight",main.WebHeight),
                    new SqlParameter("@linkurl",main.Linkurl),
                    new SqlParameter("@UserName",main.UserName),
                    new SqlParameter("@HDSN",main.HDSN)
                   };

            object obj = DbHelperSQL1.GetSingle(strSql.ToString(), parameters);
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
        /// 消息更新方法
        /// </summary>
        /// <param name="main">消息对象</param>
        /// <returns>返回1或 0</returns>
        public int Update(Pbzx.Model.CM_Main main)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CM_Main set ");
            strSql.Append("softInfo=@softInfo,");
            strSql.Append("regType=@regType,");
            strSql.Append("userClass=@userClass,");
            strSql.Append("sender=@sender,");

            strSql.Append("type=@mtype,");
            strSql.Append("category=@category,");
            strSql.Append("state=@state,");
            strSql.Append("postTime=@postTime,");
            strSql.Append("beginTime=@beginTime,");
            strSql.Append("endTime=@endTime,");
            strSql.Append("title=@title,");
            strSql.Append("contentURL=@contentURL,");

            strSql.Append("lastTime=@lastTime,");
            // strSql.Append("todayCount=@todayCount,");
            // strSql.Append("totalCount=@totalCount,");
            strSql.Append("content=@content,");
            strSql.Append("WebWidth=@WebWidth,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("HDSN=@HDSN ,");

            strSql.Append("WebHeight=@WebHeight, linkurl=@linkurl where ID=@id");
            SqlParameter[] parameters = new SqlParameter[]
                     {
                    new SqlParameter("@id",main.Id),
					new SqlParameter("@softInfo", main.SoftInfo),
					new SqlParameter("@regType", main.RegType),
					new SqlParameter("@userClass",main.UserClass),
					new SqlParameter("@sender", main.Sender),
					new SqlParameter("@mtype",  main.Mtype),
					new SqlParameter("@category",main.Category),
					new SqlParameter("@state",main.State),
					new SqlParameter("@postTime", main.PostTime),
					new SqlParameter("@beginTime",main.BeginTime),
					new SqlParameter("@endTime", main.EndTime),
                    new SqlParameter("@title",main.Title),
					new SqlParameter("@contentURL", main.ContentURL),
					new SqlParameter("@lastTime", main.LastTime),
				//	new SqlParameter("@todayCount", main.TodayCount),
				//	new SqlParameter("@totalCount", main.TotalCount),
					new SqlParameter("@content", main.Content),
                    new SqlParameter("@UserName",main.UserName),
                    new SqlParameter("@HDSN",main.HDSN),
                    new SqlParameter("@WebWidth",main.WebWidth),
                    new SqlParameter("@WebHeight",main.WebHeight),
                    new SqlParameter("@linkurl",main.Linkurl)
                   };
            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除消息的方法
        /// </summary>
        /// <param name="ID">消息ID</param>
        /// <returns>成功为1 失败为 0</returns>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete CM_Main ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 根据消息ID 得到单个实体对象
        /// </summary>
        /// <param name="ID">消息ID</param>
        /// <returns>消息对象</returns>
        public Pbzx.Model.CM_Main GetMain(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from CM_Main ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID",ID)
            };


            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                Pbzx.Model.CM_Main main = new Pbzx.Model.CM_Main();

                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    main.Id = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }

                main.SoftInfo = ds.Tables[0].Rows[0]["SoftInfo"].ToString();

                main.RegType = ds.Tables[0].Rows[0]["RegType"].ToString();

                main.UserClass = ds.Tables[0].Rows[0]["UserClass"].ToString();

                main.Sender = ds.Tables[0].Rows[0]["Sender"].ToString();

                if (ds.Tables[0].Rows[0]["Type"].ToString() != "")
                {
                    main.Mtype = Convert.ToInt32(ds.Tables[0].Rows[0]["Type"].ToString());
                }

                main.Category = ds.Tables[0].Rows[0]["Category"].ToString();

                if (ds.Tables[0].Rows[0]["State"].ToString() != "")
                {
                    main.State = Convert.ToInt32(ds.Tables[0].Rows[0]["State"].ToString());
                }

                if (ds.Tables[0].Rows[0]["PostTime"].ToString() != "")
                {
                    main.PostTime = DateTime.Parse(ds.Tables[0].Rows[0]["PostTime"].ToString());
                }

                if (ds.Tables[0].Rows[0]["BeginTime"].ToString() != "")
                {
                    main.BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginTime"].ToString());
                }

                if (ds.Tables[0].Rows[0]["endTime"].ToString() != "")
                {
                    main.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["endTime"].ToString());
                }
                main.Title = ds.Tables[0].Rows[0]["Title"].ToString();

                main.ContentURL = ds.Tables[0].Rows[0]["ContentURL"].ToString();

                if (ds.Tables[0].Rows[0]["LastTime"].ToString() != "")
                {
                    main.LastTime = DateTime.Parse(ds.Tables[0].Rows[0]["LastTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TodayCount"].ToString() != "")
                {
                    main.TodayCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TodayCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TotalCount"].ToString() != "")
                {
                    main.TotalCount = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalCount"].ToString());
                }
                main.Content = ds.Tables[0].Rows[0]["Content"].ToString();
                main.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();

                main.HDSN = ds.Tables[0].Rows[0]["HDSN"].ToString();

                if (ds.Tables[0].Rows[0]["WebWidth"].ToString() != "")
                {
                    main.WebWidth = Convert.ToInt32(ds.Tables[0].Rows[0]["WebWidth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["WebHeight"].ToString() != "")
                {
                    main.WebHeight = Convert.ToInt32(ds.Tables[0].Rows[0]["WebHeight"].ToString());
                }
                main.Linkurl = ds.Tables[0].Rows[0]["linkurl"].ToString();
              
                return main;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 查找整个满足条件的消息
        /// </summary>
        /// <param name="strWhere">消息条件</param>
        /// <returns>数据表</returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select");
            strSql.Append("*FROM CM_Main ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL1.Query(strSql.ToString());
        }
        #endregion
    }
}
