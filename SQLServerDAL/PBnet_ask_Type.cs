using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_ask_Type。
    /// </summary>
    public class PBnet_ask_Type : IPBnet_ask_Type
    {
        public PBnet_ask_Type()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_ask_Type");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_ask_Type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_ask_Type(");
            strSql.Append("TypeName,TypeID,FTypeID,OrderID,Depth,RootID,ModuleFIDS,BitIsAuditing)");
            strSql.Append(" values (");
            strSql.Append("@TypeName,@TypeID,@FTypeID,@OrderID,@Depth,@RootID,@ModuleFIDS,@BitIsAuditing)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@FTypeID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@ModuleFIDS", SqlDbType.VarChar,50),
					new SqlParameter("@BitIsAuditing", SqlDbType.Bit,1)};
            parameters[0].Value = model.TypeName;
            parameters[1].Value = model.TypeID;
            parameters[2].Value = model.FTypeID;
            parameters[3].Value = model.OrderID;
            parameters[4].Value = model.Depth;
            parameters[5].Value = model.RootID;
            parameters[6].Value = model.ModuleFIDS;
            parameters[7].Value = model.BitIsAuditing;

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
        public int Update(Pbzx.Model.PBnet_ask_Type model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_ask_Type set ");
            strSql.Append("TypeName=@TypeName,");
            strSql.Append("FTypeID=@FTypeID,");
            strSql.Append("TypeID=@TypeID,");
            strSql.Append("OrderID=@OrderID,");
            strSql.Append("RootID=@RootID,");
            strSql.Append("ModuleFIDS=@ModuleFIDS,");
            strSql.Append("BitIsAuditing=@BitIsAuditing");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4),
					new SqlParameter("@TypeName", SqlDbType.NVarChar,50),
					new SqlParameter("@TypeID", SqlDbType.Int,4),
					new SqlParameter("@FTypeID", SqlDbType.Int,4),
					new SqlParameter("@OrderID", SqlDbType.Int,4),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@ModuleFIDS", SqlDbType.VarChar,50),
					new SqlParameter("@BitIsAuditing", SqlDbType.Bit,1)};
            parameters[0].Value = model.Id;
            parameters[1].Value = model.TypeName;
            parameters[2].Value = model.TypeID;
            parameters[3].Value = model.FTypeID;
            parameters[4].Value = model.OrderID;
            parameters[5].Value = model.Depth;
            parameters[6].Value = model.RootID;
            parameters[7].Value = model.ModuleFIDS;
            parameters[8].Value = model.BitIsAuditing;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_ask_Type ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_ask_Type GetModel(int Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 Id,TypeName,TypeID,FTypeID,OrderID,Depth,RootID,ModuleFIDS,BitIsAuditing from PBnet_ask_Type ");
            strSql.Append(" where Id=@Id ");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)};
            parameters[0].Value = Id;

            Pbzx.Model.PBnet_ask_Type model = new Pbzx.Model.PBnet_ask_Type();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                model.TypeName = ds.Tables[0].Rows[0]["TypeName"].ToString();
                if (ds.Tables[0].Rows[0]["TypeID"].ToString() != "")
                {
                    model.TypeID = int.Parse(ds.Tables[0].Rows[0]["TypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FTypeID"].ToString() != "")
                {
                    model.FTypeID = int.Parse(ds.Tables[0].Rows[0]["FTypeID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OrderID"].ToString() != "")
                {
                    model.OrderID = int.Parse(ds.Tables[0].Rows[0]["OrderID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RootID"].ToString() != "")
                {
                    model.RootID = int.Parse(ds.Tables[0].Rows[0]["RootID"].ToString());
                }
                model.ModuleFIDS = ds.Tables[0].Rows[0]["ModuleFIDS"].ToString();
                if (ds.Tables[0].Rows[0]["BitIsAuditing"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BitIsAuditing"].ToString() == "1") || (ds.Tables[0].Rows[0]["BitIsAuditing"].ToString().ToLower() == "true"))
                    {
                        model.BitIsAuditing = true;
                    }
                    else
                    {
                        model.BitIsAuditing = false;
                    }
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
            strSql.Append("select Id,TypeName,TypeID,FTypeID,OrderID,Depth,RootID,ModuleFIDS,BitIsAuditing ");
            strSql.Append(" FROM PBnet_ask_Type ");
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
            strSql.Append(" Id,TypeName,TypeID,FTypeID,OrderID,Depth,RootID,ModuleFIDS,BitIsAuditing ");
            strSql.Append(" FROM PBnet_ask_Type ");
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
            parameters[0].Value = "PBnet_ask_Type";
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

