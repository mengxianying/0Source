using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data;
using System.Data.SqlClient;
using Maticsoft.DBUtility;

namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类Note_Customize。
    /// </summary>
    public class Note_Customize : INote_Customize
    {
        public Note_Customize()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Note_Customize");
            strSql.Append(" where ID= @ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Note_Customize model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Note_Customize(");
            strSql.Append("SID,Phone,UserName,BeginTime,EndTime,Price,Status,ContinuationType)");
            strSql.Append(" values (");
            strSql.Append("@SID,@Phone,@UserName,@BeginTime,@EndTime,@Price,@Status,@ContinuationType)");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@Status",SqlDbType.Int),
                    new SqlParameter("@ContinuationType",SqlDbType.Int)};
            parameters[0].Value = model.SID;
            parameters[1].Value = model.Phone;
            parameters[2].Value = model.UserName;
            parameters[3].Value = model.BeginTime;
            parameters[4].Value = model.EndTime;
            parameters[5].Value = model.Price;
            parameters[6].Value = model.Status;
            parameters[7].Value = model.ContinuationType;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Note_Customize model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Note_Customize set ");
            strSql.Append("SID=@SID,");
            strSql.Append("Phone=@Phone,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("BeginTime=@BeginTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("Price=@Price ,");
            strSql.Append("Status=@Status ,");
            strSql.Append("ContinuationType=@ContinuationType");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@SID", SqlDbType.Int,4),
					new SqlParameter("@Phone", SqlDbType.VarChar,50),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@BeginTime", SqlDbType.DateTime),
					new SqlParameter("@EndTime", SqlDbType.DateTime),
					new SqlParameter("@Price", SqlDbType.Decimal,9),
                    new SqlParameter("@Status",SqlDbType.Int),
                    new SqlParameter("@ContinuationType",SqlDbType.Int)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.SID;
            parameters[2].Value = model.Phone;
            parameters[3].Value = model.UserName;
            parameters[4].Value = model.BeginTime;
            parameters[5].Value = model.EndTime;
            parameters[6].Value = model.Price;
            parameters[7].Value = model.Status;
            parameters[8].Value = model.ContinuationType;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Note_Customize ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
				};
            parameters[0].Value = ID;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Note_Customize GetModel(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Note_Customize ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            Pbzx.Model.Note_Customize model = new Pbzx.Model.Note_Customize();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            model.ID = ID;
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["SID"].ToString() != "")
                {
                    model.SID = int.Parse(ds.Tables[0].Rows[0]["SID"].ToString());
                }
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContinuationType"].ToString() != "")
                {
                    model.ContinuationType = int.Parse(ds.Tables[0].Rows[0]["ContinuationType"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }



        /// <summary>
        /// 根据条件得到一个对象实体
        /// </summary>
        public Pbzx.Model.Note_Customize GetModel(int sid, string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Note_Customize ");
            strSql.Append(" where SID=@SID and UserName=@UserName ");
            SqlParameter[] parameters = {
					new SqlParameter("@SID", SqlDbType.Int,4),
                    new SqlParameter("@UserName",SqlDbType.VarChar)};

            parameters[0].Value = sid;
            parameters[1].Value = username;
            Pbzx.Model.Note_Customize model = null;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                model = new Pbzx.Model.Note_Customize();
                model.SID = sid;

                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());

                }
                model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(ds.Tables[0].Rows[0]["BeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[0]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[0]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ContinuationType"].ToString() != "")
                {
                    model.ContinuationType = int.Parse(ds.Tables[0].Rows[0]["ContinuationType"].ToString());
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 根据条件得到数据列表
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public List<Pbzx.Model.Note_Customize> GetModelByName(string username)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Note_Customize ");
            strSql.Append(" where UserName=@UserName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@UserName",SqlDbType.VarChar)};

            parameters[0].Value = username;
            List<Pbzx.Model.Note_Customize> list = null;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                list = new List<Pbzx.Model.Note_Customize>();
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Pbzx.Model.Note_Customize model = new Pbzx.Model.Note_Customize();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());

                }
                if (ds.Tables[0].Rows[i]["SID"].ToString() != "")
                {
                    model.SID = int.Parse(ds.Tables[0].Rows[i]["SID"].ToString());

                }
                model.Phone = ds.Tables[0].Rows[i]["Phone"].ToString();
                model.UserName = ds.Tables[0].Rows[i]["UserName"].ToString();
                if (ds.Tables[0].Rows[i]["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(ds.Tables[0].Rows[i]["BeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[i]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[i]["EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[i]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[i]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[i]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[i]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[i]["ContinuationType"].ToString() != "")
                {
                    model.ContinuationType = int.Parse(ds.Tables[0].Rows[i]["ContinuationType"].ToString());
                }

                list.Add(model);
            }
            return list;
        }
        /// <summary>
        /// 根据条件得到数据列表
        /// </summary>
        /// <param name="username">SID</param>
        /// <returns></returns>
        public List<Pbzx.Model.Note_Customize> GetModelBySid(int sid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Note_Customize ");
            strSql.Append(" where SID=@SID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@SID",SqlDbType.VarChar)};

            parameters[0].Value = sid;
            List<Pbzx.Model.Note_Customize> list = null;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
            {
                list = new List<Pbzx.Model.Note_Customize>();
            }
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Pbzx.Model.Note_Customize model = new Pbzx.Model.Note_Customize();
                if (ds.Tables[0].Rows[i]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[i]["ID"].ToString());

                }
                if (ds.Tables[0].Rows[i]["SID"].ToString() != "")
                {
                    model.SID = int.Parse(ds.Tables[0].Rows[i]["SID"].ToString());

                }
                model.Phone = ds.Tables[0].Rows[i]["Phone"].ToString();
                model.UserName = ds.Tables[0].Rows[i]["UserName"].ToString();
                if (ds.Tables[0].Rows[i]["BeginTime"].ToString() != "")
                {
                    model.BeginTime = DateTime.Parse(ds.Tables[0].Rows[i]["BeginTime"].ToString());
                }
                if (ds.Tables[0].Rows[i]["EndTime"].ToString() != "")
                {
                    model.EndTime = DateTime.Parse(ds.Tables[0].Rows[i]["EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[i]["Price"].ToString() != "")
                {
                    model.Price = decimal.Parse(ds.Tables[0].Rows[i]["Price"].ToString());
                }
                if (ds.Tables[0].Rows[i]["Status"].ToString() != "")
                {
                    model.Status = int.Parse(ds.Tables[0].Rows[i]["Status"].ToString());
                }
                if (ds.Tables[0].Rows[i]["ContinuationType"].ToString() != "")
                {
                    model.ContinuationType = int.Parse(ds.Tables[0].Rows[i]["ContinuationType"].ToString());
                }

                list.Add(model);
            }
            return list;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from Note_Customize ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by ID ");
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion  成员方法
    }
}
