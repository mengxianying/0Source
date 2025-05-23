using System;
using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.Model;
using System.Data;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace Pbzx.SQLServerDAL
{

    public class Market_CollASAttenServer : IMarket_CollASAtten
    {
       //public Market_CollASAttenServer()
       // {}
       #region  成员方法
        /// <summary>
        /// 获取数据的个数
        /// 创建人: zhouwei
        /// 创建时间: 2010-11-8
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet Num(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *");
            strSql.Append(" from Market_CollASAtten");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());


        }

       /// <summary>
       /// 是否存在该记录
       /// </summary>
       public bool Exists(int intId)
       {
           StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Market_CollASAtten");
            strSql.Append(" where intId=@intId ");
            SqlParameter[] parameters = {
					new SqlParameter("@intId", SqlDbType.Int,4)};
            parameters[0].Value = intId;

           return DbHelperSQL.Exists(strSql.ToString(), parameters);
       }
        /// <summary>
        /// 重载Exists 
        /// 创建人: zhouwei
        /// 创建时间: 2010-11-8
        /// </summary>
        /// <param name="accUser">操作人</param>
        /// <param name="userName">被收藏商家名称</param>
        /// <returns></returns>
        public bool Exists(string Uname,string appName,int statc,int mark)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Market_CollASAtten");
            strSql.Append(" where Uname=@Uname ");
            strSql.Append("and appName=@appName");
            strSql.Append(" and statc=@statc");
            strSql.Append(" and mark=@mark");
            SqlParameter[] parameters = {
                    new SqlParameter("@Uname", SqlDbType.NVarChar,50),
                    new SqlParameter("@appName",SqlDbType.NVarChar,50),
                    new SqlParameter("@statc",SqlDbType.Int,4),
                    new SqlParameter("@mark",SqlDbType.Int,4),
                    
            };
            parameters[0].Value = Uname;
            parameters[1].Value = appName;
            parameters[2].Value = statc;
            parameters[3].Value = mark;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

       /// <summary>
       /// 增加一条数据
       /// </summary>
       public int Add(Pbzx.Model.Market_CollASAtten model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("insert into Market_CollASAtten(");
           strSql.Append("Uname,appName,statc,mark,appTime)");
           strSql.Append(" values (");
           strSql.Append("@Uname,@appName,@statc,@mark,@appTime)");
           strSql.Append(";select @@IDENTITY");
           SqlParameter[] parameters = {
					new SqlParameter("@Uname", SqlDbType.NVarChar,50),
					new SqlParameter("@appName", SqlDbType.NVarChar,50),
					new SqlParameter("@statc", SqlDbType.Int,4),
					new SqlParameter("@mark", SqlDbType.Int,4),
					new SqlParameter("@appTime", SqlDbType.DateTime)};
           parameters[0].Value = model.Uname;
           parameters[1].Value = model.appName;
           parameters[2].Value = model.statc;
           parameters[3].Value = model.mark;
           parameters[4].Value = model.appTime;

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
       public int Update(Pbzx.Model.Market_CollASAtten model)
       {
           StringBuilder strSql = new StringBuilder();
           strSql.Append("update Market_CollASAtten set ");
           strSql.Append("Uname=@Uname,");
           strSql.Append("appName=@appName,");
           strSql.Append("statc=@statc,");
           strSql.Append("mark=@mark,");
           strSql.Append("appTime=@appTime");
           strSql.Append(" where intId=@intId ");
           SqlParameter[] parameters = {
					new SqlParameter("@intId", SqlDbType.Int,4),
					new SqlParameter("@Uname", SqlDbType.NVarChar,50),
					new SqlParameter("@appName", SqlDbType.NVarChar,50),
					new SqlParameter("@statc", SqlDbType.Int,4),
					new SqlParameter("@mark", SqlDbType.Int,4),
					new SqlParameter("@appTime", SqlDbType.DateTime)};
           parameters[0].Value = model.intId;
           parameters[1].Value = model.Uname;
           parameters[2].Value = model.appName;
           parameters[3].Value = model.statc;
           parameters[4].Value = model.mark;
           parameters[5].Value = model.appTime;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }

       /// <summary>
       /// 删除一条数据
       /// </summary>
       public int Delete(int intId)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("delete from Market_CollASAtten ");
           strSql.Append(" where intId=@intId ");
           SqlParameter[] parameters = {
					new SqlParameter("@intId", SqlDbType.Int,4)};
           parameters[0].Value = intId;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
       }


       /// <summary>
       /// 得到一个对象实体
       /// </summary>
       public Pbzx.Model.Market_CollASAtten GetModel(int intId)
       {

           StringBuilder strSql = new StringBuilder();
           strSql.Append("select  top 1 intId,Uname,appName,statc,mark,appTime from Market_CollASAtten ");
           strSql.Append(" where intId=@intId ");
           SqlParameter[] parameters = {
					new SqlParameter("@intId", SqlDbType.Int,4)};
           parameters[0].Value = intId;

           Pbzx.Model.Market_CollASAtten model = new Pbzx.Model.Market_CollASAtten();
           DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
           if (ds.Tables[0].Rows.Count > 0)
           {
               if (ds.Tables[0].Rows[0]["intId"].ToString() != "")
               {
                   model.intId = int.Parse(ds.Tables[0].Rows[0]["intId"].ToString());
               }
               model.Uname = ds.Tables[0].Rows[0]["Uname"].ToString();
               model.appName = ds.Tables[0].Rows[0]["appName"].ToString();
               if (ds.Tables[0].Rows[0]["statc"].ToString() != "")
               {
                   model.statc = int.Parse(ds.Tables[0].Rows[0]["statc"].ToString());
               }
               if (ds.Tables[0].Rows[0]["mark"].ToString() != "")
               {
                   model.mark = int.Parse(ds.Tables[0].Rows[0]["mark"].ToString());
               }
               if (ds.Tables[0].Rows[0]["appTime"].ToString() != "")
               {
                   model.appTime = DateTime.Parse(ds.Tables[0].Rows[0]["appTime"].ToString());
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
            strSql.Append("select intId,Uname,appName,statc,mark,appTime ");
            strSql.Append(" FROM Market_CollASAtten ");
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
            strSql.Append(" intId,Uname,appName,statc,mark,appTime ");
            strSql.Append(" FROM Market_CollASAtten ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
           return DbHelperSQL.Query(strSql.ToString());
       }

       #endregion  成员方法
    }
}