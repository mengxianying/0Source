using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_Module。
    /// </summary>
    public class PBnet_Module : Basic,IPBnet_Module
    {
        public PBnet_Module():base("PBnet_Module", "ID")
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_Module");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_Module model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_Module(");
            strSql.Append("Name,URL,LinkUrl,Depth,RootID,FlagMenu,Sort,Format,IsHome,CreateTime,TempID,AllSort)");
            strSql.Append(" values (");
            strSql.Append("@Name,@URL,@LinkUrl,@Depth,@RootID,@FlagMenu,@Sort,@Format,@IsHome,@CreateTime,@TempID,@AllSort)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@URL", SqlDbType.VarChar,500),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,500),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@FlagMenu", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Format", SqlDbType.Int,4),
					new SqlParameter("@IsHome", SqlDbType.Bit,1),
					new SqlParameter("@CreateTime", SqlDbType.SmallDateTime),
					new SqlParameter("@TempID", SqlDbType.VarChar,50),
                	new SqlParameter("@AllSort", SqlDbType.Int,4)
            };
            parameters[0].Value = model.Name;
            parameters[1].Value = model.URL;
            parameters[2].Value = model.LinkUrl;
            parameters[3].Value = model.Depth;
            parameters[4].Value = model.RootID;
            parameters[5].Value = model.FlagMenu;
            parameters[6].Value = model.Sort;
            parameters[7].Value = model.Format;
            parameters[8].Value = model.IsHome;
            parameters[9].Value = model.CreateTime;
            parameters[10].Value = model.TempID;
            parameters[11].Value = model.AllSort;

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
        public int Update(Pbzx.Model.PBnet_Module model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_Module set ");
            strSql.Append("Name=@Name,");
            strSql.Append("URL=@URL,");
            strSql.Append("LinkUrl=@LinkUrl,");
            strSql.Append("Depth=@Depth,");
            strSql.Append("RootID=@RootID,");
            strSql.Append("FlagMenu=@FlagMenu,");
            strSql.Append("Sort=@Sort,");
            strSql.Append("Format=@Format,");
            strSql.Append("IsHome=@IsHome,");
            strSql.Append("CreateTime=@CreateTime,");
            strSql.Append("TempID=@TempID,");
            strSql.Append("AllSort=@AllSort");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Name", SqlDbType.VarChar,50),
					new SqlParameter("@URL", SqlDbType.VarChar,500),
					new SqlParameter("@LinkUrl", SqlDbType.VarChar,500),
					new SqlParameter("@Depth", SqlDbType.Int,4),
					new SqlParameter("@RootID", SqlDbType.Int,4),
					new SqlParameter("@FlagMenu", SqlDbType.Int,4),
					new SqlParameter("@Sort", SqlDbType.Int,4),
					new SqlParameter("@Format", SqlDbType.Int,4),
					new SqlParameter("@IsHome", SqlDbType.Bit,1),
					new SqlParameter("@CreateTime", SqlDbType.SmallDateTime),
					new SqlParameter("@TempID", SqlDbType.VarChar,50),
                    new SqlParameter("@AllSort", SqlDbType.Int,4)
            };
            parameters[0].Value = model.ID;
            parameters[1].Value = model.Name;
            parameters[2].Value = model.URL;
            parameters[3].Value = model.LinkUrl;
            parameters[4].Value = model.Depth;
            parameters[5].Value = model.RootID;
            parameters[6].Value = model.FlagMenu;
            parameters[7].Value = model.Sort;
            parameters[8].Value = model.Format;
            parameters[9].Value = model.IsHome;
            parameters[10].Value = model.CreateTime;
            parameters[11].Value = model.TempID;
            parameters[12].Value = model.AllSort;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public  new  int Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete PBnet_Module ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_Module GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,Name,URL,LinkUrl,Depth,RootID,FlagMenu,Sort,Format,IsHome,CreateTime,TempID,AllSort from PBnet_Module ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            Pbzx.Model.PBnet_Module model = new Pbzx.Model.PBnet_Module();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                model.URL = ds.Tables[0].Rows[0]["URL"].ToString();
                model.LinkUrl = ds.Tables[0].Rows[0]["LinkUrl"].ToString();
                if (ds.Tables[0].Rows[0]["Depth"].ToString() != "")
                {
                    model.Depth = int.Parse(ds.Tables[0].Rows[0]["Depth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["RootID"].ToString() != "")
                {
                    model.RootID = int.Parse(ds.Tables[0].Rows[0]["RootID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FlagMenu"].ToString() != "")
                {
                    model.FlagMenu = int.Parse(ds.Tables[0].Rows[0]["FlagMenu"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Sort"].ToString() != "")
                {
                    model.Sort = int.Parse(ds.Tables[0].Rows[0]["Sort"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Format"].ToString() != "")
                {
                    model.Format = int.Parse(ds.Tables[0].Rows[0]["Format"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsHome"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsHome"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsHome"].ToString().ToLower() == "true"))
                    {
                        model.IsHome = true;
                    }
                    else
                    {
                        model.IsHome = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["CreateTime"].ToString() != "")
                {
                    model.CreateTime = DateTime.Parse(ds.Tables[0].Rows[0]["CreateTime"].ToString());
                }
                model.TempID = ds.Tables[0].Rows[0]["TempID"].ToString();
                if (ds.Tables[0].Rows[0]["AllSort"].ToString() != "")
                {
                    model.AllSort = int.Parse(ds.Tables[0].Rows[0]["AllSort"].ToString());
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
        public new  DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Name,URL,LinkUrl,Depth,RootID,FlagMenu,Sort,Format,IsHome,CreateTime,TempID,AllSort ");
            strSql.Append(" FROM PBnet_Module ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
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
            parameters[0].Value = "PBnet_Module";
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

