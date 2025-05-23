using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Challenge_Cinfo
    /// </summary>
    public partial class Challenge_Cinfo : IChallenge_Cinfo
    {
        public Challenge_Cinfo()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int C_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Challenge_Cinfo");
            strSql.Append(" where C_id=@C_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_id", SqlDbType.Int,4)
};
            parameters[0].Value = C_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string name,int issue,int lottID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Challenge_Cinfo");
            strSql.Append(" where C_name=@name and C_issue=@issue and C_lottID=@lottID");
            SqlParameter[] parameters = {
                    new SqlParameter("@name",SqlDbType.NVarChar,50),
					new SqlParameter("@issue", SqlDbType.Int,4),
                    new SqlParameter("@lottID", SqlDbType.Int,4)
};
            parameters[0].Value = name;
            parameters[1].Value = issue;
            parameters[2].Value = lottID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Challenge_Cinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Challenge_Cinfo(");
            strSql.Append("C_name,C_lottID,C_issue,C_time,C_Tid,C_num,C_win)");
            strSql.Append(" values (");
            strSql.Append("@C_name,@C_lottID,@C_issue,@C_time,@C_Tid,@C_num,@C_win)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@C_name", SqlDbType.NVarChar,50),
					new SqlParameter("@C_lottID", SqlDbType.Int,4),
					new SqlParameter("@C_issue", SqlDbType.Int,4),
					new SqlParameter("@C_time", SqlDbType.DateTime),
					new SqlParameter("@C_Tid", SqlDbType.Int,4),
					new SqlParameter("@C_num", SqlDbType.NVarChar,50),
					new SqlParameter("@C_win", SqlDbType.Int,4)};
            parameters[0].Value = model.C_name;
            parameters[1].Value = model.C_lottID;
            parameters[2].Value = model.C_issue;
            parameters[3].Value = model.C_time;
            parameters[4].Value = model.C_Tid;
            parameters[5].Value = model.C_num;
            parameters[6].Value = model.C_win;

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
        public bool Update(Pbzx.Model.Challenge_Cinfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Challenge_Cinfo set ");
            strSql.Append("C_name=@C_name,");
            strSql.Append("C_lottID=@C_lottID,");
            strSql.Append("C_issue=@C_issue,");
            strSql.Append("C_time=@C_time,");
            strSql.Append("C_Tid=@C_Tid,");
            strSql.Append("C_num=@C_num,");
            strSql.Append("C_win=@C_win");
            strSql.Append(" where C_id=@C_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_name", SqlDbType.NVarChar,50),
					new SqlParameter("@C_lottID", SqlDbType.Int,4),
					new SqlParameter("@C_issue", SqlDbType.Int,4),
					new SqlParameter("@C_time", SqlDbType.DateTime),
					new SqlParameter("@C_Tid", SqlDbType.Int,4),
					new SqlParameter("@C_num", SqlDbType.NVarChar,50),
					new SqlParameter("@C_win", SqlDbType.Int,4),
					new SqlParameter("@C_id", SqlDbType.Int,4)};
            parameters[0].Value = model.C_name;
            parameters[1].Value = model.C_lottID;
            parameters[2].Value = model.C_issue;
            parameters[3].Value = model.C_time;
            parameters[4].Value = model.C_Tid;
            parameters[5].Value = model.C_num;
            parameters[6].Value = model.C_win;
            parameters[7].Value = model.C_id;

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
        public bool Delete(int C_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Challenge_Cinfo ");
            strSql.Append(" where C_id=@C_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_id", SqlDbType.Int,4)
};
            parameters[0].Value = C_id;

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
        public bool DeleteList(string C_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Challenge_Cinfo ");
            strSql.Append(" where C_id in (" + C_idlist + ")  ");
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
        public Pbzx.Model.Challenge_Cinfo GetModel(int C_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 C_id,C_name,C_lottID,C_issue,C_time,C_Tid,C_num,C_win from Challenge_Cinfo ");
            strSql.Append(" where C_id=@C_id");
            SqlParameter[] parameters = {
					new SqlParameter("@C_id", SqlDbType.Int,4)
};
            parameters[0].Value = C_id;

            Pbzx.Model.Challenge_Cinfo model = new Pbzx.Model.Challenge_Cinfo();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["C_id"].ToString() != "")
                {
                    model.C_id = int.Parse(ds.Tables[0].Rows[0]["C_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["C_name"] != null)
                {
                    model.C_name = ds.Tables[0].Rows[0]["C_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_lottID"].ToString() != "")
                {
                    model.C_lottID = int.Parse(ds.Tables[0].Rows[0]["C_lottID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["C_issue"].ToString() != "")
                {
                    model.C_issue = int.Parse(ds.Tables[0].Rows[0]["C_issue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["C_time"].ToString() != "")
                {
                    model.C_time = DateTime.Parse(ds.Tables[0].Rows[0]["C_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["C_Tid"].ToString() != "")
                {
                    model.C_Tid = int.Parse(ds.Tables[0].Rows[0]["C_Tid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["C_num"] != null)
                {
                    model.C_num = ds.Tables[0].Rows[0]["C_num"].ToString();
                }
                if (ds.Tables[0].Rows[0]["C_win"].ToString() != "")
                {
                    model.C_win = int.Parse(ds.Tables[0].Rows[0]["C_win"].ToString());
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
            strSql.Append("select C_id,C_name,C_lottID,C_issue,C_time,C_Tid,C_num,C_win ");
            strSql.Append(" FROM Challenge_Cinfo ");
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
            strSql.Append(" C_id,C_name,C_lottID,C_issue,C_time,C_Tid,C_num,C_win ");
            strSql.Append(" FROM Challenge_Cinfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 双色球列转行
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetBankTransfer(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_issue,C_name,");

            strSql.Append("MAX(CASE T_state WHEN 'hq3d' THEN C_num ELSE null END) AS 'hq3d',");
            strSql.Append("MAX(CASE T_state WHEN 'hq6d' THEN C_num ELSE null END) AS 'hq6d',");
            strSql.Append("MAX(CASE T_state WHEN 's3hq' THEN C_num ELSE null END) AS 's3hq',");
            strSql.Append("MAX(CASE T_state WHEN 's6hq' THEN C_num ELSE null END) AS 's6hq',");
            strSql.Append("MAX(CASE T_state WHEN 'lq1d' THEN C_num ELSE null END) AS 'lq1d',");
            strSql.Append("MAX(CASE T_state WHEN 'lq3d' THEN C_num ELSE null END) AS 'lq3d',");
            strSql.Append("MAX(CASE T_state WHEN 's3lq' THEN C_num ELSE null END) AS 's3lq',");
            strSql.Append("MAX(CASE T_state WHEN 's6lq' THEN C_num ELSE null END) AS 's6lq',");
            strSql.Append("MAX(CASE T_state WHEN 'h3l' THEN C_num ELSE null END) AS 'h3l',");
            strSql.Append("MAX(CASE T_state WHEN 'h2l' THEN C_num ELSE null END) AS 'h2l'");

            strSql.Append(" FROM v_ReCon");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" and c_name is not null and T_lottID=3");
            }
            strSql.Append(" GROUP BY C_name,C_issue,C_time order by C_time desc");

            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 3D 列转行
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetBankTransferD(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_issue,C_name,");

            strSql.Append("MAX(CASE T_state WHEN 'dd' THEN C_num ELSE null END) AS 'dd',");
            strSql.Append("MAX(CASE T_state WHEN 'sd' THEN C_num ELSE null END) AS 'sd',");
            strSql.Append("MAX(CASE T_state WHEN 'zx1z' THEN C_num ELSE null END) AS 'zx1z',");
            strSql.Append("MAX(CASE T_state WHEN 's1m' THEN C_num ELSE null END) AS 's1m',");
            strSql.Append("MAX(CASE T_state WHEN 's2m' THEN C_num ELSE null END) AS 's2m',");
            strSql.Append("MAX(CASE T_state WHEN 'dk' THEN C_num ELSE null END) AS 'dk',");
            strSql.Append("MAX(CASE T_state WHEN 'dh' THEN C_num ELSE null END) AS 'dh',");
            strSql.Append("MAX(CASE T_state WHEN 's1h' THEN C_num ELSE null END) AS 's1h',");
            strSql.Append("MAX(CASE T_state WHEN '5dw' THEN C_num ELSE null END) AS '5dw',");
            strSql.Append("MAX(CASE T_state WHEN '3dw' THEN C_num ELSE null END) AS '3dw',");
            strSql.Append("MAX(CASE T_state WHEN 'zx' THEN C_num ELSE null END) AS 'zx',");
            strSql.Append("MAX(CASE T_state WHEN 'm' THEN C_num ELSE null END) AS 'm'");


            strSql.Append(" FROM dbo.v_ReCon");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" and c_name is not null and T_lottID=1");
            }
            strSql.Append(" GROUP BY C_name,C_issue,C_time order by C_time desc");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 排列3 列转行
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetBankTransferP(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_issue,C_name,");
            strSql.Append("MAX(CASE T_state WHEN 'pdd' THEN C_num ELSE null END) AS 'pdd',");
            strSql.Append("MAX(CASE T_state WHEN 'psd' THEN C_num ELSE null END) AS 'psd',");
            strSql.Append("MAX(CASE T_state WHEN 'pzx1z' THEN C_num ELSE null END) AS 'pzx1z',");
            strSql.Append("MAX(CASE T_state WHEN 'ps1m' THEN C_num ELSE null END) AS 'ps1m',");
            strSql.Append("MAX(CASE T_state WHEN 'ps2m' THEN C_num ELSE null END) AS 'ps2m',");
            strSql.Append("MAX(CASE T_state WHEN 'pdk' THEN C_num ELSE null END) AS 'pdk',");
            strSql.Append("MAX(CASE T_state WHEN 'pdh' THEN C_num ELSE null END) AS 'pdh',");
            strSql.Append("MAX(CASE T_state WHEN 'ps1h' THEN C_num ELSE null END) AS 'ps1h',");
            strSql.Append("MAX(CASE T_state WHEN 'p5dw' THEN C_num ELSE null END) AS 'p5dw',");
            strSql.Append("MAX(CASE T_state WHEN 'p3dw' THEN C_num ELSE null END) AS 'p3dw',");
            strSql.Append("MAX(CASE T_state WHEN 'pzx' THEN C_num ELSE null END) AS 'pzx',");
            strSql.Append("MAX(CASE T_state WHEN 'p5m' THEN C_num ELSE null END) AS 'p5m'");


            strSql.Append(" FROM dbo.v_ReCon");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" and c_name is not null and T_lottID=9999");
            }
            strSql.Append(" GROUP BY C_name,C_issue,C_time order by C_time desc");

            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 用于双色球统计----正常列转行
        /// </summary>
        /// <param name="Top">查询的个数</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetStitaSSq(int Top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select");
            if (Top > 0)
            {
                strSql.Append(" top "+Top.ToString());
            }
            strSql.Append(" C_issue,C_name,");
            strSql.Append("MAX(CASE T_state WHEN 'hq3d' THEN C_num ELSE null END) AS 'hq3d',");
            strSql.Append("MAX(CASE T_state WHEN 'hq6d' THEN C_num ELSE null END) AS 'hq6d',");
            strSql.Append("MAX(CASE T_state WHEN 's3hq' THEN C_num ELSE null END) AS 's3hq',");
            strSql.Append("MAX(CASE T_state WHEN 's6hq' THEN C_num ELSE null END) AS 's6hq',");
            strSql.Append("MAX(CASE T_state WHEN 'lq1d' THEN C_num ELSE null END) AS 'lq1d',");
            strSql.Append("MAX(CASE T_state WHEN 'lq3d' THEN C_num ELSE null END) AS 'lq3d',");
            strSql.Append("MAX(CASE T_state WHEN 's3lq' THEN C_num ELSE null END) AS 's3lq',");
            strSql.Append("MAX(CASE T_state WHEN 's6lq' THEN C_num ELSE null END) AS 's6lq',");
            strSql.Append("MAX(CASE T_state WHEN 'h3l' THEN C_num ELSE null END) AS 'h3l',");
            strSql.Append("MAX(CASE T_state WHEN 'h2l' THEN C_num ELSE null END) AS 'h2l'");

            strSql.Append(" FROM v_ReCon");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" and c_name is not null and T_lottID=3");
            }
            strSql.Append(" GROUP BY C_name,C_issue ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 3D 排列3的统计列表--正常列转行
        /// </summary>
        /// <param name="Top">查询的个数</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        public DataSet GetStitaD(int Top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" C_issue,C_name,");
            strSql.Append("MAX(CASE T_state WHEN 'dd' THEN C_num ELSE null END) AS 'dd',");
            strSql.Append("MAX(CASE T_state WHEN 'sd' THEN C_num ELSE null END) AS 'sd',");
            strSql.Append("MAX(CASE T_state WHEN 'zx1z' THEN C_num ELSE null END) AS 'zx1z',");
            strSql.Append("MAX(CASE T_state WHEN 's1m' THEN C_num ELSE null END) AS 's1m',");
            strSql.Append("MAX(CASE T_state WHEN 's2m' THEN C_num ELSE null END) AS 's2m',");
            strSql.Append("MAX(CASE T_state WHEN 'dk' THEN C_num ELSE null END) AS 'dk',");
            strSql.Append("MAX(CASE T_state WHEN 'dh' THEN C_num ELSE null END) AS 'dh',");
            strSql.Append("MAX(CASE T_state WHEN 's1h' THEN C_num ELSE null END) AS 's1h',");
            strSql.Append("MAX(CASE T_state WHEN '5dw' THEN C_num ELSE null END) AS '5dw',");
            strSql.Append("MAX(CASE T_state WHEN '3dw' THEN C_num ELSE null END) AS '3dw',");
            strSql.Append("MAX(CASE T_state WHEN 'zx' THEN C_num ELSE null END) AS 'zx',");
            strSql.Append("MAX(CASE T_state WHEN 'm' THEN C_num ELSE null END) AS 'm'");


            strSql.Append(" FROM dbo.v_ReCon");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
                strSql.Append(" and c_name is not null and T_lottID=1");
            }
            strSql.Append(" GROUP BY C_name,C_issue ");

            return DbHelperSQL.Query(strSql.ToString());
        }

        
        /// <summary>
        /// 统计双色球中奖次数-按条件的和（中奖次数相加）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetStatiUser(int Top,string strWhere)
        { 

            StringBuilder strSql = new StringBuilder();
            //释放数据库权限 使用pivor函数
            //strSql.Append("exec sp_dbcmptlevel [Pinble_Web], 90");
            strSql.Append("select ");
            strSql.Append("hq3d,hq6d,s3hq,s6hq,lq1d,lq3d,s3lq,s6lq,h3l,h2l");
            strSql.Append(" from(select ");
            if(Top>0)
            {
                strSql.Append("top "+Top.ToString());
            }
            strSql.Append(" T_state,C_win from v_ReCon");
            strSql.Append(" where " + strWhere + " and T_lottID=3 ) p");
            strSql.Append(" pivot (sum(C_win) for T_state in (hq3d,hq6d,s3hq,s6hq,lq1d,lq3d,s3lq,s6lq,h3l,h2l)) as t");

            return DbHelperSQL.Query(strSql.ToString());

        }
        /// <summary>
        /// 统计3D 中奖次数---按条件的和（中奖次数相加）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetStatiUserD(int Top,string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            //释放数据库权限 使用pivor函数
            //strSql.Append("exec sp_dbcmptlevel [Pinble_Web], 90");
            strSql.Append("select ");
            strSql.Append("dd,sd,zx1z,s1m,s2m,dk,dh,s1h,5dw,3dw,zx,m");
            strSql.Append(" from(select ");
            if (Top > 0)
            {
                strSql.Append("top " + Top.ToString());
            }
            strSql.Append(" T_state,C_win from v_ReCon");
            strSql.Append(" where " + strWhere + " and T_lottID=1 ) p");
            strSql.Append(" pivot (sum(C_win) for T_state in (dd,sd,zx1z,s1m,s2m,dk,dh,s1h,[5dw],[3dw],zx,m)) as t");


            return DbHelperSQL.Query(strSql.ToString());

        }
        /// <summary>
        /// 统计排列3 中奖次数---按条件的和（中奖次数相加）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetStatiUserP(int Top, string strWhere)
        {

            StringBuilder strSql = new StringBuilder();
            //释放数据库权限 使用pivor函数
            //strSql.Append("exec sp_dbcmptlevel [Pinble_Web], 90");
            strSql.Append("select ");
            strSql.Append("pdd,psd,pzx1z,ps1m,ps2m,pdk,pdh,ps1h,p5dw,p3dw,pzx,p5m");
            strSql.Append(" from(select ");
            if (Top > 0)
            {
                strSql.Append("top " + Top.ToString());
            }
            strSql.Append(" T_state,C_win from v_ReCon");
            strSql.Append(" where " + strWhere + " and T_lottID=9999 ) p");
            strSql.Append(" pivot (sum(C_win) for T_state in (pdd,psd,pzx1z,ps1m,ps2m,pdk,pdh,ps1h,p5dw,p3dw,pzx,p5m)) as t");

            return DbHelperSQL.Query(strSql.ToString());

        }

        /// <summary>
        /// 用户的中奖排行 3D 双色球
        /// </summary>
        /// <param name="steWhere">查询条件</param>
        public DataSet GetCompOFs(int Top,string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_name,isnull(hq3d,0) as 'hq3d',isnull(hq6d,0) as 'hq6d',isnull(s3hq,0) as 's3hq',isnull(s6hq,0) as 's6hq',isnull(lq1d,0) as 'lq1d',isnull(lq3d,0) as 'lq3d',isnull(s3lq,0) as 's3lq',isnull(s6lq,0) as 's6lq',isnull(h3l,0) as 'h3l',isnull(h2l,0) as h2l,");
            strSql.Append("isnull(dd,0) as 'dd',isnull(sd,0) as 'sd',isnull(zx1z,0) as 'zx1z',isnull(s1m,0) as 's1m',isnull(s2m,0) as 's2m',isnull(dk,0) as 'dk',isnull(dh,0) as dh,isnull(s1h,0) as 's1h',isnull([5dw],0) as '5dw',isnull([3dw],0) as '3dw',isnull(zx,0) as 'zx',isnull(m,0) as 'm',");
            strSql.Append("isnull(hq3d,0)+isnull(hq6d,0)+isnull(s3hq,0)+isnull(s6hq,0)+isnull(lq1d,0)+isnull(lq3d,0)+isnull(s3lq,0)+isnull(s6lq,0)+isnull(h3l,0)+isnull(h2l,0)");
            strSql.Append("+isnull(dd,0)+isnull(sd,0)+isnull(zx1z,0)+isnull(s1m,0)+isnull(s2m,0)+isnull(dk,0)+isnull(dh,0)+isnull(s1h,0)+isnull([5dw],0)+isnull([3dw],0)+isnull(zx,0)+isnull(m,0) as Tsum");
            strSql.Append(" from (select");
            //if (Top > 0)
            //{
            //    strSql.Append(" top "+ Top.ToString());
            //}

            strSql.Append("  c_name,T_state,C_win from v_ReCon");

            strSql.Append(" where " + strWhere);

            strSql.Append(" ) p");

            strSql.Append(" pivot (sum(C_win) for T_state in (hq3d,hq6d,s3hq,s6hq,lq1d,lq3d,s3lq,s6lq,h3l,h2l,dd,sd,zx1z,s1m,s2m,dk,dh,s1h,[5dw],[3dw],zx,m,Tsum)) as t");
            strSql.Append(" where c_name is not null");

            strSql.Append(" group by C_name,hq3d,hq6d,s3hq,s6hq,lq1d,lq3d,s3lq,s6lq,h3l,h2l,dd,sd,zx1z,s1m,s2m,dk,dh,s1h,[5dw],[3dw],zx,m,Tsum order by Tsum desc");

            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 用户的中奖排行 3D 双色球
        /// </summary>
        /// <param name="steWhere">查询条件</param>
        public DataSet GetCompOFs(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_name,isnull(hq3d,0) as 'hq3d',isnull(hq6d,0) as 'hq6d',isnull(s3hq,0) as 's3hq',isnull(s6hq,0) as 's6hq',isnull(lq1d,0) as 'lq1d',isnull(lq3d,0) as 'lq3d',isnull(s3lq,0) as 's3lq',isnull(s6lq,0) as 's6lq',isnull(h3l,0) as 'h3l',isnull(h2l,0) as h2l,");
            strSql.Append("isnull(dd,0) as 'dd',isnull(sd,0) as 'sd',isnull(zx1z,0) as 'zx1z',isnull(s1m,0) as 's1m',isnull(s2m,0) as 's2m',isnull(dk,0) as 'dk',isnull(dh,0) as dh,isnull(s1h,0) as 's1h',isnull([5dw],0) as '5dw',isnull([3dw],0) as '3dw',isnull(zx,0) as 'zx',isnull(m,0) as 'm',");
            strSql.Append("isnull(hq3d,0)+isnull(hq6d,0)+isnull(s3hq,0)+isnull(s6hq,0)+isnull(lq1d,0)+isnull(lq3d,0)+isnull(s3lq,0)+isnull(s6lq,0)+isnull(h3l,0)+isnull(h2l,0)");
            strSql.Append("+isnull(dd,0)+isnull(sd,0)+isnull(zx1z,0)+isnull(s1m,0)+isnull(s2m,0)+isnull(dk,0)+isnull(dh,0)+isnull(s1h,0)+isnull([5dw],0)+isnull([3dw],0)+isnull(zx,0)+isnull(m,0) as Tsum");
            strSql.Append(" from (select");

            strSql.Append("  c_name,T_state,C_win from v_ReCon");

            strSql.Append(" where " + strWhere);

            strSql.Append(" ) p");

            strSql.Append(" pivot (sum(C_win) for T_state in (hq3d,hq6d,s3hq,s6hq,lq1d,lq3d,s3lq,s6lq,h3l,h2l,dd,sd,zx1z,s1m,s2m,dk,dh,s1h,[5dw],[3dw],zx,m,Tsum)) as t");
            strSql.Append(" where c_name is not null");

            strSql.Append(" group by C_name,hq3d,hq6d,s3hq,s6hq,lq1d,lq3d,s3lq,s6lq,h3l,h2l,dd,sd,zx1z,s1m,s2m,dk,dh,s1h,[5dw],[3dw],zx,m,Tsum order by Tsum desc");

            return DbHelperSQL.Query(strSql.ToString());
        }






        /// <summary>
        /// 用户的中奖排行 3D 双色球
        /// </summary>
        /// <param name="steWhere">查询条件</param>
        public DataSet GetCompOFs(int TopNum,int Top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select");
            if (TopNum > 0)
            {
                strSql.Append(" top " + TopNum.ToString());
            }
            strSql.Append("C_name,isnull(hq3d,0) as 'hq3d',isnull(hq6d,0) as 'hq6d',isnull(s3hq,0) as 's3hq',isnull(s6hq,0) as 's6hq',isnull(lq1d,0) as 'lq1d',isnull(lq3d,0) as 'lq3d',isnull(s3lq,0) as 's3lq',isnull(s6lq,0) as 's6lq',isnull(h3l,0) as 'h3l',isnull(h2l,0) as h2l,");
            strSql.Append("isnull(dd,0) as 'dd',isnull(sd,0) as 'sd',isnull(zx1z,0) as 'zx1z',isnull(s1m,0) as 's1m',isnull(s2m,0) as 's2m',isnull(dk,0) as 'dk',isnull(dh,0) as dh,isnull(s1h,0) as 's1h',isnull([5dw],0) as '5dw',isnull([3dw],0) as '3dw',isnull(zx,0) as 'zx',isnull(m,0) as 'm',");
            strSql.Append("isnull(hq3d,0)+isnull(hq6d,0)+isnull(s3hq,0)+isnull(s6hq,0)+isnull(lq1d,0)+isnull(lq3d,0)+isnull(s3lq,0)+isnull(s6lq,0)+isnull(h3l,0)+isnull(h2l,0)");
            strSql.Append("+isnull(dd,0)+isnull(sd,0)+isnull(zx1z,0)+isnull(s1m,0)+isnull(s2m,0)+isnull(dk,0)+isnull(dh,0)+isnull(s1h,0)+isnull([5dw],0)+isnull([3dw],0)+isnull(zx,0)+isnull(m,0) as Tsum");
            strSql.Append(" from (select");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }

            strSql.Append("  c_name,T_state,C_win from v_ReCon");

            strSql.Append(" where " + strWhere);

            strSql.Append(" ) p");

            strSql.Append(" pivot (sum(C_win) for T_state in (hq3d,hq6d,s3hq,s6hq,lq1d,lq3d,s3lq,s6lq,h3l,h2l,dd,sd,zx1z,s1m,s2m,dk,dh,s1h,[5dw],[3dw],zx,m,Tsum)) as t");
            strSql.Append(" where c_name is not null");

            strSql.Append(" group by C_name,hq3d,hq6d,s3hq,s6hq,lq1d,lq3d,s3lq,s6lq,h3l,h2l,dd,sd,zx1z,s1m,s2m,dk,dh,s1h,[5dw],[3dw],zx,m,Tsum order by Tsum desc");

            return DbHelperSQL.Query(strSql.ToString());
        }


        /// <summary>
        /// 用户的中奖排行 排列3
        /// </summary>
        /// <param name="steWhere">查询条件</param>
        public DataSet GetCompOFs_P(int Top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select C_name,");
            strSql.Append("isnull(pdd,0) as 'pdd',isnull(psd,0) as 'psd',isnull(pzx1z,0) as 'pzx1z',isnull(ps1m,0) as 'ps1m',isnull(ps2m,0) as 'ps2m',isnull(pdk,0) as 'pdk',isnull(pdh,0) as pdh,isnull(ps1h,0) as 'ps1h',isnull([p5dw],0) as 'p5dw',isnull([p3dw],0) as 'p3dw',isnull(pzx,0) as 'pzx',isnull([p5m],0) as 'p5m',");

            strSql.Append("isnull(pdd,0)+isnull(psd,0)+isnull(pzx1z,0)+isnull(ps1m,0)+isnull(ps2m,0)+isnull(pdk,0)+isnull(pdh,0)+isnull(ps1h,0)+isnull([p5dw],0)+isnull([p3dw],0)+isnull(pzx,0)+isnull([p5m],0) as Tsum");
            strSql.Append(" from (select");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }

            strSql.Append("  c_name,T_state,C_win from v_ReCon");

            strSql.Append(" where " + strWhere);

            strSql.Append(" ) p");

            strSql.Append(" pivot (sum(C_win) for T_state in (pdd,psd,pzx1z,ps1m,ps2m,pdk,pdh,ps1h,[p5dw],[p3dw],pzx,[p5m],Tsum)) as t");
            strSql.Append(" where c_name is not null");

            strSql.Append(" group by C_name,pdd,psd,pzx1z,ps1m,ps2m,pdk,pdh,ps1h,[p5dw],[p3dw],pzx,[p5m],Tsum order by Tsum desc");

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
            parameters[0].Value = "Challenge_Cinfo";
            parameters[1].Value = "C_id";
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
