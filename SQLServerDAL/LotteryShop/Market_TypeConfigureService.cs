using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Maticsoft.DBUtility;
using System.Data.SqlClient;
using System.Data;
using Pbzx.Model;


namespace Pbzx.SQLServerDAL
{
    public class Market_TypeConfigureService : IMarket_TypeConfigure
    {
        public Market_TypeConfigureService()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ConfigureID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Market_TypeConfigure");
            strSql.Append(" where ConfigureID=@ConfigureID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ConfigureID", SqlDbType.Int,4)};
            parameters[0].Value = ConfigureID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Market_TypeConfigure model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Market_TypeConfigure(");
            strSql.Append("TypeId,On_off,Sign,BeginTime,Endtime,Upload,SmallMoney,BigMoney,Ticheng,ManyIssue,Recommend)");
            strSql.Append(" values (");
            strSql.Append("@TypeId,@On_off,@Sign,@BeginTime,@Endtime,@Upload,@SmallMoney,@BigMoney,@Ticheng,@ManyIssue,@Recommend)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@On_off", SqlDbType.Int,4),
					new SqlParameter("@Sign", SqlDbType.Int,4),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@Endtime", SqlDbType.DateTime),
					new SqlParameter("@Upload", SqlDbType.Int,4),
					new SqlParameter("@SmallMoney", SqlDbType.Decimal,9),
					new SqlParameter("@BigMoney", SqlDbType.Decimal,9),
					new SqlParameter("@Ticheng", SqlDbType.NVarChar,10),
					new SqlParameter("@ManyIssue", SqlDbType.Int,4),
					new SqlParameter("@Recommend", SqlDbType.Int,4)};
            parameters[0].Value = model.TypeId;
            parameters[1].Value = model.On_off;
            parameters[2].Value = model.Sign;
            parameters[3].Value = model.BeginTime;
            parameters[4].Value = model.Endtime;
            parameters[5].Value = model.Upload;
            parameters[6].Value = model.SmallMoney;
            parameters[7].Value = model.BigMoney;
            parameters[8].Value = model.Ticheng;
            parameters[9].Value = model.ManyIssue;
            parameters[10].Value = model.Recommend;

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
        public void Update(Pbzx.Model.Market_TypeConfigure model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Market_TypeConfigure set ");
            strSql.Append("TypeId=@TypeId,");
            strSql.Append("On_off=@On_off,");
            strSql.Append("Sign=@Sign,");
            strSql.Append("BeginTime=@BeginTime,");
            strSql.Append("Endtime=@Endtime,");
            strSql.Append("Upload=@Upload,");
            strSql.Append("SmallMoney=@SmallMoney,");
            strSql.Append("BigMoney=@BigMoney,");
            strSql.Append("Ticheng=@Ticheng,");
            strSql.Append("ManyIssue=@ManyIssue,");
            strSql.Append("Recommend=@Recommend");
            strSql.Append(" where ConfigureID=@ConfigureID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ConfigureID", SqlDbType.Int,4),
					new SqlParameter("@TypeId", SqlDbType.Int,4),
					new SqlParameter("@On_off", SqlDbType.Int,4),
					new SqlParameter("@Sign", SqlDbType.Int,4),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@Endtime", SqlDbType.DateTime),
					new SqlParameter("@Upload", SqlDbType.Int,4),
					new SqlParameter("@SmallMoney", SqlDbType.Decimal,9),
					new SqlParameter("@BigMoney", SqlDbType.Decimal,9),
					new SqlParameter("@Ticheng", SqlDbType.NVarChar,10),
					new SqlParameter("@ManyIssue", SqlDbType.Int,4),
					new SqlParameter("@Recommend", SqlDbType.Int,4)};
            parameters[0].Value = model.ConfigureID;
            parameters[1].Value = model.TypeId;
            parameters[2].Value = model.On_off;
            parameters[3].Value = model.Sign;
            parameters[4].Value = model.BeginTime;
            parameters[5].Value = model.Endtime;
            parameters[6].Value = model.Upload;
            parameters[7].Value = model.SmallMoney;
            parameters[8].Value = model.BigMoney;
            parameters[9].Value = model.Ticheng;
            parameters[10].Value = model.ManyIssue;
            parameters[11].Value = model.Recommend;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int ConfigureID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Market_TypeConfigure ");
            strSql.Append(" where ConfigureID=@ConfigureID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ConfigureID", SqlDbType.Int,4)};
            parameters[0].Value = ConfigureID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Market_TypeConfigure GetModel(int ConfigureID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ConfigureID,TypeId,On_off,Sign,BeginTime,Endtime,Upload,SmallMoney,BigMoney,Ticheng,ManyIssue,Recommend from Market_TypeConfigure ");
            strSql.Append(" where ConfigureID=@ConfigureID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ConfigureID", SqlDbType.Int,4)};
            parameters[0].Value = ConfigureID;

            Pbzx.Model.Market_TypeConfigure model = new Pbzx.Model.Market_TypeConfigure();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ConfigureID"].ToString() != "")
                {
                    model.ConfigureID = int.Parse(ds.Tables[0].Rows[0]["ConfigureID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["TypeId"].ToString() != "")
                {
                    model.TypeId = int.Parse(ds.Tables[0].Rows[0]["TypeId"].ToString());
                }
                if (ds.Tables[0].Rows[0]["On_off"].ToString() != "")
                {
                    model.On_off = int.Parse(ds.Tables[0].Rows[0]["On_off"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sign"].ToString() != "")
                {
                    model.Sign = int.Parse(ds.Tables[0].Rows[0]["Sign"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Endtime"].ToString() != "")
                {
                    model.Endtime = DateTime.Parse(ds.Tables[0].Rows[0]["Endtime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Upload"].ToString() != "")
                {
                    model.Upload = int.Parse(ds.Tables[0].Rows[0]["Upload"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SmallMoney"].ToString() != "")
                {
                    model.SmallMoney = decimal.Parse(ds.Tables[0].Rows[0]["SmallMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BigMoney"].ToString() != "")
                {
                    model.BigMoney = decimal.Parse(ds.Tables[0].Rows[0]["BigMoney"].ToString());
                }
                model.Ticheng = ds.Tables[0].Rows[0]["Ticheng"].ToString();
                if (ds.Tables[0].Rows[0]["ManyIssue"].ToString() != "")
                {
                    model.ManyIssue = int.Parse(ds.Tables[0].Rows[0]["ManyIssue"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Recommend"].ToString() != "")
                {
                    model.Recommend = int.Parse(ds.Tables[0].Rows[0]["Recommend"].ToString());
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
            strSql.Append("select ConfigureID,TypeId,On_off,Sign,BeginTime,Endtime,Upload,SmallMoney,BigMoney,Ticheng,ManyIssue,Recommend ");
            strSql.Append(" FROM Market_TypeConfigure ");
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
            strSql.Append(" ConfigureID,TypeId,On_off,Sign,BeginTime,Endtime,Upload,SmallMoney,BigMoney,Ticheng,ManyIssue,Recommend ");
            strSql.Append(" FROM Market_TypeConfigure ");
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
