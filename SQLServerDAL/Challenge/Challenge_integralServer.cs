using System;
using System.Collections.Generic;
using System.Text;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;
using Pbzx.IDAL;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类Challenge_integral。
    /// </summary>
    public class Challenge_integral : IChallenge_integral
    {
        public Challenge_integral()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int I_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Challenge_integral");
            strSql.Append(" where I_id=@I_id");
            SqlParameter[] parameters = {
					new SqlParameter("@I_id", SqlDbType.Int,4)
};
            parameters[0].Value = I_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Challenge_integral model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Challenge_integral(");
            strSql.Append("I_name,I_lottid,I_condName,I_integral)");
            strSql.Append(" values (");
            strSql.Append("@I_name,@I_lottid,@I_condName,@I_integral)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@I_name", SqlDbType.NVarChar,50),
					new SqlParameter("@I_lottid", SqlDbType.Int,4),
					new SqlParameter("@I_condName", SqlDbType.NVarChar,10),
					new SqlParameter("@I_integral", SqlDbType.Int,4)};
            parameters[0].Value = model.I_name;
            parameters[1].Value = model.I_lottid;
            parameters[2].Value = model.I_condName;
            parameters[3].Value = model.I_integral;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.Challenge_integral model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Challenge_integral set ");
            strSql.Append("I_name=@I_name,");
            strSql.Append("I_lottid=@I_lottid,");
            strSql.Append("I_condName=@I_condName,");
            strSql.Append("I_integral=@I_integral");
            strSql.Append(" where I_id=@I_id");
            SqlParameter[] parameters = {
					new SqlParameter("@I_name", SqlDbType.NVarChar,50),
					new SqlParameter("@I_lottid", SqlDbType.Int,4),
					new SqlParameter("@I_condName", SqlDbType.NVarChar,10),
					new SqlParameter("@I_integral", SqlDbType.Int,4),
					new SqlParameter("@I_id", SqlDbType.Int,4)};
            parameters[0].Value = model.I_name;
            parameters[1].Value = model.I_lottid;
            parameters[2].Value = model.I_condName;
            parameters[3].Value = model.I_integral;
            parameters[4].Value = model.I_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int I_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Challenge_integral ");
            strSql.Append(" where I_id=@I_id");
            SqlParameter[] parameters = {
					new SqlParameter("@I_id", SqlDbType.Int,4)
};
            parameters[0].Value = I_id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string I_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Challenge_integral ");
            strSql.Append(" where I_id in (" + I_idlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Challenge_integral GetModel(int I_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 I_id,I_name,I_lottid,I_condName,I_integral from Challenge_integral ");
            strSql.Append(" where I_id=@I_id");
            SqlParameter[] parameters = {
					new SqlParameter("@I_id", SqlDbType.Int,4)
};
            parameters[0].Value = I_id;

            Pbzx.Model.Challenge_integral model = new Pbzx.Model.Challenge_integral();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["I_id"].ToString() != "")
                {
                    model.I_id = int.Parse(ds.Tables[0].Rows[0]["I_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["I_name"] != null)
                {
                    model.I_name = ds.Tables[0].Rows[0]["I_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["I_lottid"].ToString() != "")
                {
                    model.I_lottid = int.Parse(ds.Tables[0].Rows[0]["I_lottid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["I_condName"] != null)
                {
                    model.I_condName = ds.Tables[0].Rows[0]["I_condName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["I_integral"].ToString() != "")
                {
                    model.I_integral = int.Parse(ds.Tables[0].Rows[0]["I_integral"].ToString());
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
            strSql.Append("select I_id,I_name,I_lottid,I_condName,I_integral ");
            strSql.Append(" FROM Challenge_integral ");
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
            strSql.Append(" I_id,I_name,I_lottid,I_condName,I_integral ");
            strSql.Append(" FROM Challenge_integral ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        ///// <summary>
        ///// 统计排名
        ///// </summary>
        ///// <param name="strWhere"></param>
        ///// <returns></returns>
        //public DataSet GetRank(string strWhere,string TempWhere)
        //{
        //    //StringBuilder strSql = new StringBuilder();
        //    ////查询临时表的字符串
        //    //StringBuilder strTemp = new StringBuilder();
        //    //strSql.Append("select *,row_number() over(order by I_integral desc ) as 'pm' into #aa");
        //    //strSql.Append(" from Challenge_integral");
        //    //strSql.Append(" where " + strWhere);
        //    //strSql.Append(" order by I_integral  desc");
        //    //if (DbHelperSQL.Exists(strSql.ToString()))
        //    //{
        //    //    strTemp.Append("select * from ");
        //    //    strTemp.Append(" #aa");
        //    //    strTemp.Append(" where "+TempWhere);
        //    //}
        //    //return DbHelperSQL.Query(strTemp.ToString());
        //    return DbHelperMySQL.Query("");
        //}

        

        /// <summary>
        /// //积分排名 按条件同统计
        /// </summary>
        /// <param name="V_table">视图名称</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet RankSSq(string V_table,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from");
            strSql.Append(" " + V_table);
            strSql.Append(" where " + strWhere);
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 获得前几行 的 积分排名
        /// </summary>
        /// <param name="V_table">视图名称</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet RankSSq(int Top,string V_table, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select");
            strSql.Append(" top " + Top.ToString());
            strSql.Append(" *");
            strSql.Append(" from");
            strSql.Append(" " + V_table);
            strSql.Append(" where " + strWhere);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 积分查询 3D 双色球  排列3
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet selectRankS(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select I_name,");
            strSql.Append("MAX(CASE I_condName WHEN 'hq3d' THEN I_integral ELSE 0 END) AS 'hq3d',");
            strSql.Append("MAX(CASE I_condName WHEN 'hq6d' THEN I_integral ELSE 0 END) AS 'hq6d',");
            strSql.Append("MAX(CASE I_condName WHEN 's3hq' THEN I_integral ELSE 0 END) AS 's3hq',");
            strSql.Append("MAX(CASE I_condName WHEN 's6hq' THEN I_integral ELSE 0 END) AS 's6hq',");
            strSql.Append("MAX(CASE I_condName WHEN 'lq1d' THEN I_integral ELSE 0 END) AS 'lq1d',");
            strSql.Append("MAX(CASE I_condName WHEN 'lq3d' THEN I_integral ELSE 0 END) AS 'lq3d',");
            strSql.Append("MAX(CASE I_condName WHEN 's3lq' THEN I_integral ELSE 0 END) AS 's3lq',");
            strSql.Append("MAX(CASE I_condName WHEN 's6lq' THEN I_integral ELSE 0 END) AS 's6lq',");
            strSql.Append("MAX(CASE I_condName WHEN 'h3l' THEN I_integral ELSE 0 END) AS 'h3l',");
            strSql.Append("MAX(CASE I_condName WHEN 'h2l' THEN I_integral ELSE 0 END) AS 'h2l',");
            //3D 部分
            strSql.Append("MAX(CASE I_condName WHEN 'dd' THEN I_integral ELSE 0 END) AS 'dd',");
            strSql.Append("MAX(CASE I_condName WHEN 'sd' THEN I_integral ELSE 0 END) AS 'sd',");
            strSql.Append("MAX(CASE I_condName WHEN 'zx1z' THEN I_integral ELSE 0 END) AS 'zx1z',");
            strSql.Append("MAX(CASE I_condName WHEN 's1m' THEN I_integral ELSE 0 END) AS 's1m',");
            strSql.Append("MAX(CASE I_condName WHEN 's2m' THEN I_integral ELSE 0 END) AS 's2m',");
            strSql.Append("MAX(CASE I_condName WHEN 'dk' THEN I_integral ELSE 0 END) AS 'dk',");
            strSql.Append("MAX(CASE I_condName WHEN 'dh' THEN I_integral ELSE 0 END) AS 'dh',");
            strSql.Append("MAX(CASE I_condName WHEN 's1h' THEN I_integral ELSE 0 END) AS 's1h',");
            strSql.Append("MAX(CASE I_condName WHEN '5dw' THEN I_integral ELSE 0 END) AS '5dw',");
            strSql.Append("MAX(CASE I_condName WHEN '3dw' THEN I_integral ELSE 0 END) AS '3dw',");
            strSql.Append("MAX(CASE I_condName WHEN 'zx' THEN I_integral ELSE 0 END) AS 'zx',");
            strSql.Append("MAX(CASE I_condName WHEN 'm' THEN I_integral ELSE 0 END) AS 'm',");
            //排3部分
            strSql.Append("MAX(CASE I_condName WHEN 'pdd' THEN I_integral ELSE 0 END) AS 'pdd',");
            strSql.Append("MAX(CASE I_condName WHEN 'psd' THEN I_integral ELSE 0 END) AS 'psd',");
            strSql.Append("MAX(CASE I_condName WHEN 'pzx1z' THEN I_integral ELSE 0 END) AS 'pzx1z',");
            strSql.Append("MAX(CASE I_condName WHEN 'ps1m' THEN I_integral ELSE 0 END) AS 'ps1m',");
            strSql.Append("MAX(CASE I_condName WHEN 'ps2m' THEN I_integral ELSE 0 END) AS 'ps2m',");
            strSql.Append("MAX(CASE I_condName WHEN 'pdk' THEN I_integral ELSE 0 END) AS 'pdk',");
            strSql.Append("MAX(CASE I_condName WHEN 'pdh' THEN I_integral ELSE 0 END) AS 'pdh',");
            strSql.Append("MAX(CASE I_condName WHEN 'ps1h' THEN I_integral ELSE 0 END) AS 'ps1h',");
            strSql.Append("MAX(CASE I_condName WHEN 'p5dw' THEN I_integral ELSE 0 END) AS 'p5dw',");
            strSql.Append("MAX(CASE I_condName WHEN 'p3dw' THEN I_integral ELSE 0 END) AS 'p3dw',");
            strSql.Append("MAX(CASE I_condName WHEN 'pzx' THEN I_integral ELSE 0 END) AS 'pzx',");
            strSql.Append("MAX(CASE I_condName WHEN 'p5m' THEN I_integral ELSE 0 END) AS 'p5m'");

            strSql.Append("from Challenge_integral");
            strSql.Append(" where " + strWhere + " group by I_name");

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
            parameters[0].Value = "Challenge_integral";
            parameters[1].Value = "I_id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  Method
    }
}