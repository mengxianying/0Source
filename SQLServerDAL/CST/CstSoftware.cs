using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类CstSoftware。
    /// </summary>
    public class CstSoftware : ICstSoftware
    {
        public CstSoftware()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL1.GetMaxID("CstID", "CstSoftware");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int CstID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from CstSoftware");
            strSql.Append(" where CstID=@CstID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CstID", SqlDbType.TinyInt)};
            parameters[0].Value = CstID;

            return DbHelperSQL1.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.CstSoftware model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into CstSoftware(");
            strSql.Append("CstName,SoftwareType,SoftwareName,SoftwareNameColor,InstallType,InstallName,InstallNameColor,Flag,YearMoney,LifeMoney,VersionType,VersionTypeName)");
            strSql.Append(" values (");
            strSql.Append("@CstName,@SoftwareType,@SoftwareName,@SoftwareNameColor,@InstallType,@InstallName,@InstallNameColor,@Flag,@YearMoney,@LifeMoney,@VersionType,@VersionTypeName)");
            SqlParameter[] parameters = {
					new SqlParameter("@CstID", SqlDbType.TinyInt,1),
					new SqlParameter("@CstName", SqlDbType.NVarChar,16),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@SoftwareName", SqlDbType.NVarChar,16),
					new SqlParameter("@SoftwareNameColor", SqlDbType.Char,7),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallName", SqlDbType.NVarChar,16),
					new SqlParameter("@InstallNameColor", SqlDbType.Char,7),
					new SqlParameter("@Flag", SqlDbType.TinyInt,1),
					new SqlParameter("@YearMoney", SqlDbType.Int,4),
					new SqlParameter("@LifeMoney", SqlDbType.Int,4),
					new SqlParameter("@VersionType", SqlDbType.TinyInt,1),
					new SqlParameter("@VersionTypeName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CstID;
            parameters[1].Value = model.CstName;
            parameters[2].Value = model.SoftwareType;
            parameters[3].Value = model.SoftwareName;
            parameters[4].Value = model.SoftwareNameColor;
            parameters[5].Value = model.InstallType;
            parameters[6].Value = model.InstallName;
            parameters[7].Value = model.InstallNameColor;
            parameters[8].Value = model.Flag;
            parameters[9].Value = model.YearMoney;
            parameters[10].Value = model.LifeMoney;

            parameters[11].Value = model.VersionType;
            parameters[12].Value = model.VersionTypeName;


            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.CstSoftware model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update CstSoftware set ");
            strSql.Append("CstName=@CstName,");
            strSql.Append("SoftwareType=@SoftwareType,");
            strSql.Append("SoftwareNameColor=@SoftwareNameColor,");
            strSql.Append("InstallType=@InstallType,");
            strSql.Append("InstallNameColor=@InstallNameColor,");
            strSql.Append("Flag=@Flag,");
            strSql.Append("YearMoney=@YearMoney,");
            strSql.Append("LifeMoney=@LifeMoney,");
            strSql.Append("VersionType=@VersionType,");
            strSql.Append("VersionTypeName=@VersionTypeName");
            strSql.Append(" where CstID=@CstID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CstID", SqlDbType.TinyInt,1),
					new SqlParameter("@CstName", SqlDbType.NVarChar,16),
					new SqlParameter("@SoftwareType", SqlDbType.TinyInt,1),
					new SqlParameter("@SoftwareName", SqlDbType.NVarChar,16),
					new SqlParameter("@SoftwareNameColor", SqlDbType.Char,7),
					new SqlParameter("@InstallType", SqlDbType.TinyInt,1),
					new SqlParameter("@InstallName", SqlDbType.NVarChar,16),
					new SqlParameter("@InstallNameColor", SqlDbType.Char,7),
					new SqlParameter("@Flag", SqlDbType.TinyInt,1),
					new SqlParameter("@YearMoney", SqlDbType.Int,4),
					new SqlParameter("@LifeMoney", SqlDbType.Int,4),
					new SqlParameter("@VersionType", SqlDbType.TinyInt,1),
					new SqlParameter("@VersionTypeName", SqlDbType.VarChar,50)};
            parameters[0].Value = model.CstID;
            parameters[1].Value = model.CstName;
            parameters[2].Value = model.SoftwareType;
            parameters[3].Value = model.SoftwareName;
            parameters[4].Value = model.SoftwareNameColor;
            parameters[5].Value = model.InstallType;
            parameters[6].Value = model.InstallName;
            parameters[7].Value = model.InstallNameColor;
            parameters[8].Value = model.Flag;
            parameters[9].Value = model.YearMoney;
            parameters[10].Value = model.LifeMoney;

            parameters[11].Value = model.VersionType;
            parameters[12].Value = model.VersionTypeName;
            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int CstID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from CstSoftware ");
            strSql.Append(" where CstID=@CstID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CstID", SqlDbType.TinyInt)};
            parameters[0].Value = CstID;

            return DbHelperSQL1.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.CstSoftware GetModel(int CstID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 CstID,CstName,SoftwareType,SoftwareName,SoftwareNameColor,InstallType,InstallName,InstallNameColor,Flag,YearMoney,LifeMoney,VersionType,VersionTypeName  from CstSoftware ");
            strSql.Append(" where CstID=@CstID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CstID", SqlDbType.TinyInt)};
            parameters[0].Value = CstID;

            Pbzx.Model.CstSoftware model = new Pbzx.Model.CstSoftware();
            DataSet ds = DbHelperSQL1.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CstID"].ToString() != "")
                {
                    model.CstID = int.Parse(ds.Tables[0].Rows[0]["CstID"].ToString());
                }
                model.CstName = ds.Tables[0].Rows[0]["CstName"].ToString();
                if (ds.Tables[0].Rows[0]["SoftwareType"].ToString() != "")
                {
                    model.SoftwareType = int.Parse(ds.Tables[0].Rows[0]["SoftwareType"].ToString());
                }
                model.SoftwareName = ds.Tables[0].Rows[0]["SoftwareName"].ToString();
                model.SoftwareNameColor = ds.Tables[0].Rows[0]["SoftwareNameColor"].ToString();
                if (ds.Tables[0].Rows[0]["InstallType"].ToString() != "")
                {
                    model.InstallType = int.Parse(ds.Tables[0].Rows[0]["InstallType"].ToString());
                }
                model.InstallName = ds.Tables[0].Rows[0]["InstallName"].ToString();
                model.InstallNameColor = ds.Tables[0].Rows[0]["InstallNameColor"].ToString();
                if (ds.Tables[0].Rows[0]["Flag"].ToString() != "")
                {
                    model.Flag = int.Parse(ds.Tables[0].Rows[0]["Flag"].ToString());
                }
                if (ds.Tables[0].Rows[0]["YearMoney"].ToString() != "")
                {
                    model.YearMoney = int.Parse(ds.Tables[0].Rows[0]["YearMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LifeMoney"].ToString() != "")
                {
                    model.LifeMoney = int.Parse(ds.Tables[0].Rows[0]["LifeMoney"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VersionType"].ToString() != "")
                {
                    model.VersionType = int.Parse(ds.Tables[0].Rows[0]["VersionType"].ToString());
                }
                model.VersionTypeName = ds.Tables[0].Rows[0]["VersionTypeName"].ToString();

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
            strSql.Append("select CstID,CstName,SoftwareType,SoftwareName,SoftwareNameColor,InstallType,InstallName,InstallNameColor,Flag,YearMoney,LifeMoney,VersionType,VersionTypeName  ");
            strSql.Append(" FROM CstSoftware ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL1.Query(strSql.ToString());
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
            parameters[0].Value = "CstSoftware";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL1.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法
    }
}

