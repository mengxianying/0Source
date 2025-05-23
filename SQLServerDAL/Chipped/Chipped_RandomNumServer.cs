using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using Pbzx.Model;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类:Chipped_RandomNum
    /// </summary>
    public class Chipped_RandomNum : IChipped_RandomNum
    {
        public Chipped_RandomNum()
        { }
        #region  Method
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Rn_id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Chipped_RandomNum");
            strSql.Append(" where Rn_id=@Rn_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Rn_id", SqlDbType.Int,4)
};
            parameters[0].Value = Rn_id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Chipped_RandomNum model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Chipped_RandomNum(");
            strSql.Append("Rn_name,Rn_play,Rn_note,Rn_multiple,Rn_tmtion,Rn_mess,Rn_state,Rn_time,Rn_num)");
            strSql.Append(" values (");
            strSql.Append("@Rn_name,@Rn_play,@Rn_note,@Rn_multiple,@Rn_tmtion,@Rn_mess,@Rn_state,@Rn_time,@Rn_num)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Rn_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Rn_play", SqlDbType.Int,4),
					new SqlParameter("@Rn_note", SqlDbType.Int,4),
					new SqlParameter("@Rn_multiple", SqlDbType.Int,4),
					new SqlParameter("@Rn_tmtion", SqlDbType.Decimal,9),
					new SqlParameter("@Rn_mess", SqlDbType.Int,4),
					new SqlParameter("@Rn_state", SqlDbType.Int,4),
					new SqlParameter("@Rn_time", SqlDbType.DateTime),
                    new SqlParameter("@Rn_num",SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Rn_name;
            parameters[1].Value = model.Rn_play;
            parameters[2].Value = model.Rn_note;
            parameters[3].Value = model.Rn_multiple;
            parameters[4].Value = model.Rn_tmtion;
            parameters[5].Value = model.Rn_mess;
            parameters[6].Value = model.Rn_state;
            parameters[7].Value = model.Rn_time;
            parameters[8].Value = model.Rn_num;

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
        public bool Update(Pbzx.Model.Chipped_RandomNum model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Chipped_RandomNum set ");
            strSql.Append("Rn_name=@Rn_name,");
            strSql.Append("Rn_play=@Rn_play,");
            strSql.Append("Rn_note=@Rn_note,");
            strSql.Append("Rn_multiple=@Rn_multiple,");
            strSql.Append("Rn_tmtion=@Rn_tmtion,");
            strSql.Append("Rn_mess=@Rn_mess,");
            strSql.Append("Rn_state=@Rn_state,");
            strSql.Append("Rn_time=@Rn_time,");
            strSql.Append("Rn_num=@Rn_num");
            strSql.Append(" where Rn_id=@Rn_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Rn_name", SqlDbType.NVarChar,50),
					new SqlParameter("@Rn_play", SqlDbType.Int,4),
					new SqlParameter("@Rn_note", SqlDbType.Int,4),
					new SqlParameter("@Rn_multiple", SqlDbType.Int,4),
					new SqlParameter("@Rn_tmtion", SqlDbType.Decimal,9),
					new SqlParameter("@Rn_mess", SqlDbType.Int,4),
					new SqlParameter("@Rn_state", SqlDbType.Int,4),
					new SqlParameter("@Rn_time", SqlDbType.DateTime),
					new SqlParameter("@Rn_id", SqlDbType.Int,4),
                    new SqlParameter("@Rn_num",SqlDbType.NVarChar,50)};
            parameters[0].Value = model.Rn_name;
            parameters[1].Value = model.Rn_play;
            parameters[2].Value = model.Rn_note;
            parameters[3].Value = model.Rn_multiple;
            parameters[4].Value = model.Rn_tmtion;
            parameters[5].Value = model.Rn_mess;
            parameters[6].Value = model.Rn_state;
            parameters[7].Value = model.Rn_time;
            parameters[8].Value = model.Rn_id;
            parameters[9].Value = model.Rn_num;

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
        public bool Delete(int Rn_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_RandomNum ");
            strSql.Append(" where Rn_id=@Rn_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Rn_id", SqlDbType.Int,4)
};
            parameters[0].Value = Rn_id;

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
        public bool DeleteList(string Rn_idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Chipped_RandomNum ");
            strSql.Append(" where Rn_id in (" + Rn_idlist + ")  ");
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
        public Pbzx.Model.Chipped_RandomNum GetModel(int Rn_id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Rn_id,Rn_name,Rn_play,Rn_note,Rn_multiple,Rn_tmtion,Rn_mess,Rn_state,Rn_time,Rn_num from Chipped_RandomNum ");
            strSql.Append(" where Rn_id=@Rn_id");
            SqlParameter[] parameters = {
					new SqlParameter("@Rn_id", SqlDbType.Int,4)
};
            parameters[0].Value = Rn_id;

            Pbzx.Model.Chipped_RandomNum model = new Pbzx.Model.Chipped_RandomNum();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Rn_id"].ToString() != "")
                {
                    model.Rn_id = int.Parse(ds.Tables[0].Rows[0]["Rn_id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rn_name"] != null)
                {
                    model.Rn_name = ds.Tables[0].Rows[0]["Rn_name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Rn_play"].ToString() != "")
                {
                    model.Rn_play = int.Parse(ds.Tables[0].Rows[0]["Rn_play"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rn_note"].ToString() != "")
                {
                    model.Rn_note = int.Parse(ds.Tables[0].Rows[0]["Rn_note"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rn_multiple"].ToString() != "")
                {
                    model.Rn_multiple = int.Parse(ds.Tables[0].Rows[0]["Rn_multiple"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rn_tmtion"].ToString() != "")
                {
                    model.Rn_tmtion = decimal.Parse(ds.Tables[0].Rows[0]["Rn_tmtion"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rn_mess"].ToString() != "")
                {
                    model.Rn_mess = int.Parse(ds.Tables[0].Rows[0]["Rn_mess"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rn_state"].ToString() != "")
                {
                    model.Rn_state = int.Parse(ds.Tables[0].Rows[0]["Rn_state"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rn_time"].ToString() != "")
                {
                    model.Rn_time = DateTime.Parse(ds.Tables[0].Rows[0]["Rn_time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rn_num"].ToString() != null)
                {
                    model.Rn_num = ds.Tables[0].Rows[0]["Rn_num"].ToString();
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
            strSql.Append("select Rn_id,Rn_name,Rn_play,Rn_note,Rn_multiple,Rn_tmtion,Rn_mess,Rn_state,Rn_time,Rn_num ");
            strSql.Append(" FROM Chipped_RandomNum ");
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
            strSql.Append(" Rn_id,Rn_name,Rn_play,Rn_note,Rn_multiple,Rn_tmtion,Rn_mess,Rn_state,Rn_time,Rn_num ");
            strSql.Append(" FROM Chipped_RandomNum ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  Method
    }
}

