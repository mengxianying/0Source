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
    /// 数据访问类DataRivalry_Rt。
    /// </summary>
    public class DataRivalry_Rt : IDataRivalry_Rt
    {
        public DataRivalry_Rt()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Rt_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from DataRivalry_Rt");
            strSql.Append(" where Rt_ID= @Rt_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Rt_ID", SqlDbType.Int,4)
				};
            parameters[0].Value = Rt_ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_Rt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into DataRivalry_Rt(");
            strSql.Append("Rt_Period,Rt_AwardNum,Rt_UserName,Rt_Single,Rt_Group,Rt_two,Rt_one,Rt_zero,Rt_Radio,Rt_choose,Rt_ChangeSingle,Rt_CSSent,Rt_CSRate)");
            strSql.Append(" values (");
            strSql.Append("@Rt_Period,@Rt_AwardNum,@Rt_UserName,@Rt_Single,@Rt_Group,@Rt_two,@Rt_one,@Rt_zero,@Rt_Radio,@Rt_choose,@Rt_ChangeSingle,@Rt_CSSent,@Rt_CSRate)");
            SqlParameter[] parameters = {
					new SqlParameter("@Rt_Period", SqlDbType.Int,4),
					new SqlParameter("@Rt_AwardNum", SqlDbType.Int,4),
					new SqlParameter("@Rt_UserName", SqlDbType.NVarChar),
					new SqlParameter("@Rt_Single", SqlDbType.Int,4),
					new SqlParameter("@Rt_Group", SqlDbType.Int,4),
					new SqlParameter("@Rt_two", SqlDbType.Int,4),
					new SqlParameter("@Rt_one", SqlDbType.Int,4),
					new SqlParameter("@Rt_zero", SqlDbType.Int,4),
					new SqlParameter("@Rt_Radio", SqlDbType.Int,4),
					new SqlParameter("@Rt_choose", SqlDbType.Int,4),
					new SqlParameter("@Rt_ChangeSingle", SqlDbType.Int,4),
					new SqlParameter("@Rt_CSSent", SqlDbType.Int,4),
					new SqlParameter("@Rt_CSRate", SqlDbType.NVarChar)};
            parameters[0].Value = model.Rt_Period;
            parameters[1].Value = model.Rt_AwardNum;
            parameters[2].Value = model.Rt_UserName;
            parameters[3].Value = model.Rt_Single;
            parameters[4].Value = model.Rt_Group;
            parameters[5].Value = model.Rt_two;
            parameters[6].Value = model.Rt_one;
            parameters[7].Value = model.Rt_zero;
            parameters[8].Value = model.Rt_Radio;
            parameters[9].Value = model.Rt_choose;
            parameters[10].Value = model.Rt_ChangeSingle;
            parameters[11].Value = model.Rt_CSSent;
            parameters[12].Value = model.Rt_CSRate;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.DataRivalry_Rt model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DataRivalry_Rt set ");
            strSql.Append("Rt_Period=@Rt_Period,");
            strSql.Append("Rt_AwardNum=@Rt_AwardNum,");
            strSql.Append("Rt_UserName=@Rt_UserName,");
            strSql.Append("Rt_Single=@Rt_Single,");
            strSql.Append("Rt_Group=@Rt_Group,");
            strSql.Append("Rt_two=@Rt_two,");
            strSql.Append("Rt_one=@Rt_one,");
            strSql.Append("Rt_zero=@Rt_zero,");
            strSql.Append("Rt_Radio=@Rt_Radio,");
            strSql.Append("Rt_choose=@Rt_choose,");
            strSql.Append("Rt_ChangeSingle=@Rt_ChangeSingle,");
            strSql.Append("Rt_CSSent=@Rt_CSSent,");
            strSql.Append("Rt_CSRate=@Rt_CSRate");
            strSql.Append(" where Rt_ID=@Rt_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Rt_ID", SqlDbType.Int,4),
					new SqlParameter("@Rt_Period", SqlDbType.Int,4),
					new SqlParameter("@Rt_AwardNum", SqlDbType.Int,4),
					new SqlParameter("@Rt_UserName", SqlDbType.NVarChar),
					new SqlParameter("@Rt_Single", SqlDbType.Int,4),
					new SqlParameter("@Rt_Group", SqlDbType.Int,4),
					new SqlParameter("@Rt_two", SqlDbType.Int,4),
					new SqlParameter("@Rt_one", SqlDbType.Int,4),
					new SqlParameter("@Rt_zero", SqlDbType.Int,4),
					new SqlParameter("@Rt_Radio", SqlDbType.Int,4),
					new SqlParameter("@Rt_choose", SqlDbType.Int,4),
					new SqlParameter("@Rt_ChangeSingle", SqlDbType.Int,4),
					new SqlParameter("@Rt_CSSent", SqlDbType.Int,4),
					new SqlParameter("@Rt_CSRate", SqlDbType.NVarChar)};
            parameters[0].Value = model.Rt_ID;
            parameters[1].Value = model.Rt_Period;
            parameters[2].Value = model.Rt_AwardNum;
            parameters[3].Value = model.Rt_UserName;
            parameters[4].Value = model.Rt_Single;
            parameters[5].Value = model.Rt_Group;
            parameters[6].Value = model.Rt_two;
            parameters[7].Value = model.Rt_one;
            parameters[8].Value = model.Rt_zero;
            parameters[9].Value = model.Rt_Radio;
            parameters[10].Value = model.Rt_choose;
            parameters[11].Value = model.Rt_ChangeSingle;
            parameters[12].Value = model.Rt_CSSent;
            parameters[13].Value = model.Rt_CSRate;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Rt_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete DataRivalry_Rt ");
            strSql.Append(" where Rt_ID=@Rt_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Rt_ID", SqlDbType.Int,4)
				};
            parameters[0].Value = Rt_ID;
             return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int DeleteJoint(int Rt_AwardNum)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete DataRivalry_Rt ");
            strSql.Append(" where Rt_AwardNum=@Rt_AwardNum");
            SqlParameter[] parameters = {
					new SqlParameter("@Rt_AwardNum", SqlDbType.Int,4)
				};
            parameters[0].Value = Rt_AwardNum;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.DataRivalry_Rt GetModel(int Rt_ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from DataRivalry_Rt ");
            strSql.Append(" where Rt_ID=@Rt_ID");
            SqlParameter[] parameters = {
					new SqlParameter("@Rt_ID", SqlDbType.Int,4)};
            parameters[0].Value = Rt_ID;
            Pbzx.Model.DataRivalry_Rt model = new Pbzx.Model.DataRivalry_Rt();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.Rt_ID = Rt_ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Rt_Period"].ToString() != "")
                {
                    model.Rt_Period = int.Parse(ds.Tables[0].Rows[0]["Rt_Period"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rt_AwardNum"].ToString() != "")
                {
                    model.Rt_AwardNum = int.Parse(ds.Tables[0].Rows[0]["Rt_AwardNum"].ToString());
                }
                model.Rt_UserName = ds.Tables[0].Rows[0]["Rt_UserName"].ToString();
                if (ds.Tables[0].Rows[0]["Rt_Single"].ToString() != "")
                {
                    model.Rt_Single = int.Parse(ds.Tables[0].Rows[0]["Rt_Single"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rt_Group"].ToString() != "")
                {
                    model.Rt_Group = int.Parse(ds.Tables[0].Rows[0]["Rt_Group"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rt_two"].ToString() != "")
                {
                    model.Rt_two = int.Parse(ds.Tables[0].Rows[0]["Rt_two"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rt_one"].ToString() != "")
                {
                    model.Rt_one = int.Parse(ds.Tables[0].Rows[0]["Rt_one"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rt_zero"].ToString() != "")
                {
                    model.Rt_zero = int.Parse(ds.Tables[0].Rows[0]["Rt_zero"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rt_Radio"].ToString() != "")
                {
                    model.Rt_Radio = int.Parse(ds.Tables[0].Rows[0]["Rt_Radio"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rt_choose"].ToString() != "")
                {
                    model.Rt_choose = int.Parse(ds.Tables[0].Rows[0]["Rt_choose"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rt_ChangeSingle"].ToString() != "")
                {
                    model.Rt_ChangeSingle = int.Parse(ds.Tables[0].Rows[0]["Rt_ChangeSingle"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Rt_CSSent"].ToString() != "")
                {
                    model.Rt_CSSent = int.Parse(ds.Tables[0].Rows[0]["Rt_CSSent"].ToString());
                }
                model.Rt_CSRate = ds.Tables[0].Rows[0]["Rt_CSRate"].ToString();
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
            strSql.Append("select * from DataRivalry_Rt ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by Rt_ID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
