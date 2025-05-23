using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;
using Pbzx.Common;
using System.Collections.Generic;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_PaginAtion。
    /// </summary>
    public class PBnet_PaginAtion : IPBnet_PaginAtion
    {
        public PBnet_PaginAtion()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PaginationID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_PaginAtion");
            strSql.Append(" where PaginationID=@PaginationID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PaginationID", SqlDbType.Int,4)};
            parameters[0].Value = PaginationID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_PaginAtion model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_PaginAtion(");
            strSql.Append("ID,FilePath,PhysicPath,FileName,Suffix,PageNo,PageType)");
            strSql.Append(" values (");
            strSql.Append("@ID,@FilePath,@PhysicPath,@FileName,@Suffix,@PageNo,@PageType)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@FilePath", SqlDbType.VarChar,255),
					new SqlParameter("@PhysicPath", SqlDbType.VarChar,255),
					new SqlParameter("@FileName", SqlDbType.VarChar,50),
					new SqlParameter("@Suffix", SqlDbType.Char,4),
					new SqlParameter("@PageNo", SqlDbType.SmallInt,2),
					new SqlParameter("@PageType", SqlDbType.Int,4)};
            parameters[0].Value = model.ID;
            parameters[1].Value = model.FilePath;
            parameters[2].Value = model.PhysicPath;
            parameters[3].Value = model.FileName;
            parameters[4].Value = model.Suffix;
            parameters[5].Value = model.PageNo;
            parameters[6].Value = model.PageType;

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
        public void Update(Pbzx.Model.PBnet_PaginAtion model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_PaginAtion set ");
            strSql.Append("ID=@ID,");
            strSql.Append("FilePath=@FilePath,");
            strSql.Append("PhysicPath=@PhysicPath,");
            strSql.Append("FileName=@FileName,");
            strSql.Append("Suffix=@Suffix,");
            strSql.Append("PageNo=@PageNo,");
            strSql.Append("PageType=@PageType");
            strSql.Append(" where PaginationID=@PaginationID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PaginationID", SqlDbType.Int,4),
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@FilePath", SqlDbType.VarChar,255),
					new SqlParameter("@PhysicPath", SqlDbType.VarChar,255),
					new SqlParameter("@FileName", SqlDbType.VarChar,50),
					new SqlParameter("@Suffix", SqlDbType.Char,4),
					new SqlParameter("@PageNo", SqlDbType.SmallInt,2),
					new SqlParameter("@PageType", SqlDbType.Int,4)};
            parameters[0].Value = model.PaginationID;
            parameters[1].Value = model.ID;
            parameters[2].Value = model.FilePath;
            parameters[3].Value = model.PhysicPath;
            parameters[4].Value = model.FileName;
            parameters[5].Value = model.Suffix;
            parameters[6].Value = model.PageNo;
            parameters[7].Value = model.PageType;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int PaginationID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_PaginAtion ");
            strSql.Append(" where PaginationID=@PaginationID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PaginationID", SqlDbType.Int,4)};
            parameters[0].Value = PaginationID;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_PaginAtion GetModel(int PaginationID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PaginationID,ID,FilePath,PhysicPath,FileName,Suffix,PageNo,PageType from PBnet_PaginAtion ");
            strSql.Append(" where PaginationID=@PaginationID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PaginationID", SqlDbType.Int,4)};
            parameters[0].Value = PaginationID;

            Pbzx.Model.PBnet_PaginAtion model = new Pbzx.Model.PBnet_PaginAtion();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PaginationID"].ToString() != "")
                {
                    model.PaginationID = int.Parse(ds.Tables[0].Rows[0]["PaginationID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                model.FilePath = ds.Tables[0].Rows[0]["FilePath"].ToString();
                model.PhysicPath = ds.Tables[0].Rows[0]["PhysicPath"].ToString();
                model.FileName = ds.Tables[0].Rows[0]["FileName"].ToString();
                model.Suffix = ds.Tables[0].Rows[0]["Suffix"].ToString();
                if (ds.Tables[0].Rows[0]["PageNo"].ToString() != "")
                {
                    model.PageNo = int.Parse(ds.Tables[0].Rows[0]["PageNo"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PageType"].ToString() != "")
                {
                    model.PageType = int.Parse(ds.Tables[0].Rows[0]["PageType"].ToString());
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
            strSql.Append("select PaginationID,ID,FilePath,PhysicPath,FileName,Suffix,PageNo,PageType ");
            strSql.Append(" FROM PBnet_PaginAtion ");
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
            strSql.Append(" PaginationID,ID,FilePath,PhysicPath,FileName,Suffix,PageNo,PageType ");
            strSql.Append(" FROM PBnet_PaginAtion ");
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
            parameters[0].Value = "PBnet_PaginAtion";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法


        #region 新闻内容分页操作
        /// <summary>
        /// 添加新闻内容分页
        /// </summary>
        public int PaginationCreate(Pbzx.Model.PBnet_PaginAtion paginAtionInfo)
        {
            return Add(paginAtionInfo);
        }

        /// <summary>
        /// 根据ID,和类别删除分页
        /// </summary>
        public void PaginationDelete(int id, EModuleType moduletype)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
                new SqlParameter("@PageType", SqlDbType.Int,4)
            };
            parameters[0].Value = id;
            parameters[1].Value = (int)moduletype;
            DbHelperSQL.RunProcedure("rzrs_PaginAtionDelete", parameters);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_PaginAtion> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_PaginAtion> modelList = new List<Pbzx.Model.PBnet_PaginAtion>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_PaginAtion model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_PaginAtion();
                    if (dt.Rows[n]["PaginationID"].ToString() != "")
                    {
                        model.PaginationID = int.Parse(dt.Rows[n]["PaginationID"].ToString());
                    }
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.FilePath = dt.Rows[n]["FilePath"].ToString();
                    model.PhysicPath = dt.Rows[n]["PhysicPath"].ToString();
                    model.FileName = dt.Rows[n]["FileName"].ToString();
                    model.Suffix = dt.Rows[n]["Suffix"].ToString();
                    if (dt.Rows[n]["PageNo"].ToString() != "")
                    {
                        model.PageNo = int.Parse(dt.Rows[n]["PageNo"].ToString());
                    }
                    if (dt.Rows[n]["PageType"].ToString() != "")
                    {
                        model.PageType = int.Parse(dt.Rows[n]["PageType"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 根据ID获取新闻内容分页数据
        /// </summary>
        public List<Pbzx.Model.PBnet_PaginAtion> PaginationGet(int id, EModuleType moduletype)
        {
            DataTable ds = GetList("[ID]='"+id+"' and PageType='"+(int)moduletype+"' order by pageno").Tables[0];
            return DataTableToList(ds);
        }




        /// <summary>
        /// 参数集
        /// </summary>
        /// <returns></returns>
        public SqlParameter[] SqlParam(Pbzx.Model.PBnet_PaginAtion paginAtionInfo)
        {
            SqlParameter[] paramList ={
                SQLHelper.MakeInParam("@id",SqlDbType.Int,4,paginAtionInfo.ID),
                SQLHelper.MakeInParam("@FilePath",SqlDbType.VarChar,255,paginAtionInfo.FilePath),
                SQLHelper.MakeInParam("@PhysicPath",SqlDbType.VarChar,255,paginAtionInfo.PhysicPath),
                SQLHelper.MakeInParam("@FileName",SqlDbType.VarChar,50,paginAtionInfo.FileName),
                SQLHelper.MakeInParam("@Suffix",SqlDbType.Char,4,paginAtionInfo.Suffix),
                SQLHelper.MakeInParam("@PageNo",SqlDbType.SmallInt,4,paginAtionInfo.PageNo),
                SQLHelper.MakeInParam("@PageType",SqlDbType.Int,4,paginAtionInfo.PageType)
            };
            return paramList;
        }
        #endregion
    }
}

