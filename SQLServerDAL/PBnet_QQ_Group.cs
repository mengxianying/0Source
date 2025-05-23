using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_QQ_Group。
    /// </summary>
    public class PBnet_QQ_Group : IPBnet_QQ_Group
    {
        public PBnet_QQ_Group()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_QQ_Group");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_QQ_Group model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_QQ_Group(");
            strSql.Append("QQ_GroupID,QQ_GroupName,QQ_GroupType,IsSoftGroup,QQ_GroupAdmin,QQ_GroupDetails,IsEnable,SortID,CreateTime)");
            strSql.Append(" values (");
            strSql.Append("@QQ_GroupID,@QQ_GroupName,@QQ_GroupType,@IsSoftGroup,@QQ_GroupAdmin,@QQ_GroupDetails,@IsEnable,@SortID,@CreateTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@QQ_GroupID", SqlDbType.VarChar,20),
					new SqlParameter("@QQ_GroupName", SqlDbType.VarChar,50),
					new SqlParameter("@QQ_GroupType", SqlDbType.Int,4),
					new SqlParameter("@IsSoftGroup", SqlDbType.Bit,1),
					new SqlParameter("@QQ_GroupAdmin", SqlDbType.VarChar,100),
					new SqlParameter("@QQ_GroupDetails", SqlDbType.VarChar,400),
					new SqlParameter("@IsEnable", SqlDbType.Bit,1),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.QQ_GroupID;
            parameters[1].Value = model.QQ_GroupName;
            parameters[2].Value = model.QQ_GroupType;
            parameters[3].Value = model.IsSoftGroup;
            parameters[4].Value = model.QQ_GroupAdmin;
            parameters[5].Value = model.QQ_GroupDetails;
            parameters[6].Value = model.IsEnable;
            parameters[7].Value = model.SortID;
            parameters[8].Value = model.CreateTime;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return -1;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int  Update(Pbzx.Model.PBnet_QQ_Group model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_QQ_Group set ");
            strSql.Append("QQ_GroupID=@QQ_GroupID,");
            strSql.Append("QQ_GroupName=@QQ_GroupName,");
            strSql.Append("QQ_GroupType=@QQ_GroupType,");
            strSql.Append("IsSoftGroup=@IsSoftGroup,");
            strSql.Append("QQ_GroupAdmin=@QQ_GroupAdmin,");
            strSql.Append("QQ_GroupDetails=@QQ_GroupDetails,");
            strSql.Append("IsEnable=@IsEnable,");
            strSql.Append("SortID=@SortID,");
            strSql.Append("CreateTime=@CreateTime");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@QQ_GroupID", SqlDbType.VarChar,20),
					new SqlParameter("@QQ_GroupName", SqlDbType.VarChar,50),
					new SqlParameter("@QQ_GroupType", SqlDbType.Int,4),
					new SqlParameter("@IsSoftGroup", SqlDbType.Bit,1),
					new SqlParameter("@QQ_GroupAdmin", SqlDbType.VarChar,100),
					new SqlParameter("@QQ_GroupDetails", SqlDbType.VarChar,400),
					new SqlParameter("@IsEnable", SqlDbType.Bit,1),
					new SqlParameter("@SortID", SqlDbType.Int,4),
					new SqlParameter("@CreateTime", SqlDbType.SmallDateTime)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.QQ_GroupID;
            parameters[2].Value = model.QQ_GroupName;
            parameters[3].Value = model.QQ_GroupType;
            parameters[4].Value = model.IsSoftGroup;
            parameters[5].Value = model.QQ_GroupAdmin;
            parameters[6].Value = model.QQ_GroupDetails;
            parameters[7].Value = model.IsEnable;
            parameters[8].Value = model.SortID;
            parameters[9].Value = model.CreateTime;

           return  DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int  Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_QQ_Group ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_QQ_Group GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,QQ_GroupID,QQ_GroupName,QQ_GroupType,IsSoftGroup,QQ_GroupAdmin,QQ_GroupDetails,IsEnable,SortID,CreateTime from PBnet_QQ_Group ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_QQ_Group model = new Pbzx.Model.PBnet_QQ_Group();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.QQ_GroupID = ds.Tables[0].Rows[0]["QQ_GroupID"].ToString();
                model.QQ_GroupName = ds.Tables[0].Rows[0]["QQ_GroupName"].ToString();
                if (ds.Tables[0].Rows[0]["QQ_GroupType"].ToString() != "")
                {
                    model.QQ_GroupType = int.Parse(ds.Tables[0].Rows[0]["QQ_GroupType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsSoftGroup"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsSoftGroup"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsSoftGroup"].ToString().ToLower() == "true"))
                    {
                        model.IsSoftGroup = true;
                    }
                    else
                    {
                        model.IsSoftGroup = false;
                    }
                }
                model.QQ_GroupAdmin = ds.Tables[0].Rows[0]["QQ_GroupAdmin"].ToString();
                model.QQ_GroupDetails = ds.Tables[0].Rows[0]["QQ_GroupDetails"].ToString();
                if (ds.Tables[0].Rows[0]["IsEnable"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsEnable"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsEnable"].ToString().ToLower() == "true"))
                    {
                        model.IsEnable = true;
                    }
                    else
                    {
                        model.IsEnable = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["SortID"].ToString() != "")
                {
                    model.SortID = int.Parse(ds.Tables[0].Rows[0]["SortID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
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
            strSql.Append("select ID,QQ_GroupID,QQ_GroupName,QQ_GroupType,IsSoftGroup,QQ_GroupAdmin,QQ_GroupDetails,IsEnable,SortID,CreateTime ");
            strSql.Append(" FROM PBnet_QQ_Group ");
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
            strSql.Append(" ID,QQ_GroupID,QQ_GroupName,QQ_GroupType,IsSoftGroup,QQ_GroupAdmin,QQ_GroupDetails,IsEnable,SortID,CreateTime ");
            strSql.Append(" FROM PBnet_QQ_Group ");
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
            parameters[0].Value = "PBnet_QQ_Group";
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

