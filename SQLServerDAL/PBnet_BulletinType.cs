using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_BulletinType。
    /// </summary>
    public class PBnet_BulletinType : IPBnet_BulletinType
    {
        public PBnet_BulletinType()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int IntNewsTypeID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_BulletinType");
            strSql.Append(" where IntNewsTypeID=@IntNewsTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntNewsTypeID", SqlDbType.Int,4)};
            parameters[0].Value = IntNewsTypeID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_BulletinType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_BulletinType(");
            strSql.Append("VarTypeName,IntTypeFID,IntTypeLevel,BitComment,BitIsAuditing,IntOrderID,Depth,RootID,ModuleFIDS,TypeEnName,DisCount,IntSortID)");
            strSql.Append(" values (");
            strSql.Append("@VarTypeName,@IntTypeFID,@IntTypeLevel,@BitComment,@BitIsAuditing,@IntOrderID,@Depth,@RootID,@ModuleFIDS,@TypeEnName,@DisCount,@IntSortID)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@VarTypeName", SqlDbType.VarChar,100),
					new SqlParameter("@IntTypeFID", SqlDbType.Int,4),
					new SqlParameter("@IntTypeLevel", SqlDbType.Int,4),
					new SqlParameter("@BitComment", SqlDbType.Bit,1),
					new SqlParameter("@BitIsAuditing", SqlDbType.Bit,1),
					new SqlParameter("@IntOrderID", SqlDbType.VarChar,255),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@ModuleFIDS", SqlDbType.VarChar,200),
					new SqlParameter("@TypeEnName", SqlDbType.VarChar,50),
					new SqlParameter("@DisCount", SqlDbType.Int,4),
					new SqlParameter("@IntSortID", SqlDbType.Int,4)};
            parameters[0].Value = model.VarTypeName;
            parameters[1].Value = model.IntTypeFID;
            parameters[2].Value = model.IntTypeLevel;
            parameters[3].Value = model.BitComment;
            parameters[4].Value = model.BitIsAuditing;
            parameters[5].Value = model.IntOrderID;
            parameters[6].Value = model.Depth;
            parameters[7].Value = model.RootID;
            parameters[8].Value = model.ModuleFIDS;
            parameters[9].Value = model.TypeEnName;
            parameters[10].Value = model.DisCount;
            parameters[11].Value = model.IntSortID;

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
        public int Update(Pbzx.Model.PBnet_BulletinType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_BulletinType set ");
            strSql.Append("VarTypeName=@VarTypeName,");
            strSql.Append("IntTypeFID=@IntTypeFID,");
            strSql.Append("IntTypeLevel=@IntTypeLevel,");
            strSql.Append("BitComment=@BitComment,");
            strSql.Append("BitIsAuditing=@BitIsAuditing,");
            strSql.Append("IntOrderID=@IntOrderID,");
            strSql.Append("Depth=@Depth,");
            strSql.Append("RootID=@RootID,");
            strSql.Append("ModuleFIDS=@ModuleFIDS,");
            strSql.Append("TypeEnName=@TypeEnName,");
            strSql.Append("DisCount=@DisCount,");
            strSql.Append("IntSortID=@IntSortID");
            strSql.Append(" where IntNewsTypeID=@IntNewsTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntNewsTypeID", SqlDbType.Int,4),
					new SqlParameter("@VarTypeName", SqlDbType.VarChar,100),
					new SqlParameter("@IntTypeFID", SqlDbType.Int,4),
					new SqlParameter("@IntTypeLevel", SqlDbType.Int,4),
					new SqlParameter("@BitComment", SqlDbType.Bit,1),
					new SqlParameter("@BitIsAuditing", SqlDbType.Bit,1),
					new SqlParameter("@IntOrderID", SqlDbType.VarChar,255),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@ModuleFIDS", SqlDbType.VarChar,200),
					new SqlParameter("@TypeEnName", SqlDbType.VarChar,50),
					new SqlParameter("@DisCount", SqlDbType.Int,4),
					new SqlParameter("@IntSortID", SqlDbType.Int,4)};
            parameters[0].Value = model.IntNewsTypeID;
            parameters[1].Value = model.VarTypeName;
            parameters[2].Value = model.IntTypeFID;
            parameters[3].Value = model.IntTypeLevel;
            parameters[4].Value = model.BitComment;
            parameters[5].Value = model.BitIsAuditing;
            parameters[6].Value = model.IntOrderID;
            parameters[7].Value = model.Depth;
            parameters[8].Value = model.RootID;
            parameters[9].Value = model.ModuleFIDS;
            parameters[10].Value = model.TypeEnName;
            parameters[11].Value = model.DisCount;
            parameters[12].Value = model.IntSortID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int IntNewsTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_BulletinType ");
            strSql.Append(" where IntNewsTypeID=@IntNewsTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntNewsTypeID", SqlDbType.Int,4)};
            parameters[0].Value = IntNewsTypeID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_BulletinType GetModel(int IntNewsTypeID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 IntNewsTypeID,VarTypeName,IntTypeFID,IntTypeLevel,BitComment,BitIsAuditing,IntOrderID,Depth,RootID,ModuleFIDS,TypeEnName,DisCount,IntSortID from PBnet_BulletinType ");
            strSql.Append(" where IntNewsTypeID=@IntNewsTypeID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntNewsTypeID", SqlDbType.Int,4)};
            parameters[0].Value = IntNewsTypeID;

            Pbzx.Model.PBnet_BulletinType model = new Pbzx.Model.PBnet_BulletinType();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["IntNewsTypeID"].ToString() != "")
                {
                    model.IntNewsTypeID = int.Parse(ds.Tables[0].Rows[0]["IntNewsTypeID"].ToString());
                }
                model.VarTypeName = ds.Tables[0].Rows[0]["VarTypeName"].ToString();
                if (ds.Tables[0].Rows[0]["IntTypeFID"].ToString() != "")
                {
                    model.IntTypeFID = int.Parse(ds.Tables[0].Rows[0]["IntTypeFID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IntTypeLevel"].ToString() != "")
                {
                    model.IntTypeLevel = int.Parse(ds.Tables[0].Rows[0]["IntTypeLevel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BitComment"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BitComment"].ToString() == "1") || (ds.Tables[0].Rows[0]["BitComment"].ToString().ToLower() == "true"))
                    {
                        model.BitComment = true;
                    }
                    else
                    {
                        model.BitComment = false;
                    }
                }
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
                model.IntOrderID = ds.Tables[0].Rows[0]["IntOrderID"].ToString();
                if (ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RootID"].ToString() != "")
                {
                    model.RootID = int.Parse(ds.Tables[0].Rows[0]["RootID"].ToString());
                }
                model.ModuleFIDS = ds.Tables[0].Rows[0]["ModuleFIDS"].ToString();
                model.TypeEnName = ds.Tables[0].Rows[0]["TypeEnName"].ToString();
                if (ds.Tables[0].Rows[0]["DisCount"].ToString() != "")
                {
                    model.DisCount = int.Parse(ds.Tables[0].Rows[0]["DisCount"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IntSortID"].ToString() != "")
                {
                    model.IntSortID = int.Parse(ds.Tables[0].Rows[0]["IntSortID"].ToString());
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
            strSql.Append("select IntNewsTypeID,VarTypeName,IntTypeFID,IntTypeLevel,BitComment,BitIsAuditing,IntOrderID,Depth,RootID,ModuleFIDS,TypeEnName,DisCount,IntSortID ");
            strSql.Append(" FROM PBnet_BulletinType ");
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
            strSql.Append(" IntNewsTypeID,VarTypeName,IntTypeFID,IntTypeLevel,BitComment,BitIsAuditing,IntOrderID,Depth,RootID,ModuleFIDS,TypeEnName,DisCount,IntSortID  ");
            strSql.Append(" FROM PBnet_BulletinType ");
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
            parameters[0].Value = "PBnet_BulletinType";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        public DataTable Query(string sql)
        {
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
            {
                return null;
            }
        }
    }
}

