using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_Links。
    /// </summary>
    public class PBnet_Links : IPBnet_Links
    {
        public PBnet_Links()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int IntID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_Links");
            strSql.Append(" where IntID=@IntID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntID", SqlDbType.Int,4)};
            parameters[0].Value = IntID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_Links model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_Links(");
            strSql.Append("IntLinkType,IntSiteName,NteSiteUrl,NteSiteIntro,NteLogoUrl,NvarSiteAdmin,NvarEmail,NvarSitePassword,BitIsGood,BitIsOK,ModifyTime,SortOrder,QQ,Tel,Remark)");
            strSql.Append(" values (");
            strSql.Append("@IntLinkType,@IntSiteName,@NteSiteUrl,@NteSiteIntro,@NteLogoUrl,@NvarSiteAdmin,@NvarEmail,@NvarSitePassword,@BitIsGood,@BitIsOK,@ModifyTime,@SortOrder,@QQ,@Tel,@Remark)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@IntLinkType", SqlDbType.Int,4),
					new SqlParameter("@IntSiteName", SqlDbType.NVarChar,200),
					new SqlParameter("@NteSiteUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@NteSiteIntro", SqlDbType.NVarChar,800),
					new SqlParameter("@NteLogoUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@NvarSiteAdmin", SqlDbType.NVarChar,50),
					new SqlParameter("@NvarEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@NvarSitePassword", SqlDbType.NVarChar,50),
					new SqlParameter("@BitIsGood", SqlDbType.Bit,1),
					new SqlParameter("@BitIsOK", SqlDbType.Int,4),
					new SqlParameter("@ModifyTime", SqlDbType.DateTime),
					new SqlParameter("@SortOrder", SqlDbType.Int,4),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,510)
            };
            parameters[0].Value = model.IntLinkType;
            parameters[1].Value = model.IntSiteName;
            parameters[2].Value = model.NteSiteUrl;
            parameters[3].Value = model.NteSiteIntro;
            parameters[4].Value = model.NteLogoUrl;
            parameters[5].Value = model.NvarSiteAdmin;
            parameters[6].Value = model.NvarEmail;
            parameters[7].Value = model.NvarSitePassword;
            parameters[8].Value = model.BitIsGood;
            parameters[9].Value = model.BitIsOK;
            parameters[10].Value = model.ModifyTime;
            parameters[11].Value = model.SortOrder;
            parameters[12].Value = model.QQ;
            parameters[13].Value = model.Tel;
            parameters[14].Value = model.Remark;

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
        public int Update(Pbzx.Model.PBnet_Links model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_Links set ");

            strSql.Append("IntLinkType=@IntLinkType,");
            strSql.Append("IntSiteName=@IntSiteName,");
            strSql.Append("NteSiteUrl=@NteSiteUrl,");
            strSql.Append("NteSiteIntro=@NteSiteIntro,");
            strSql.Append("NteLogoUrl=@NteLogoUrl,");
            strSql.Append("NvarSiteAdmin=@NvarSiteAdmin,");
            strSql.Append("NvarEmail=@NvarEmail,");
            strSql.Append("NvarSitePassword=@NvarSitePassword,");
            strSql.Append("BitIsGood=@BitIsGood,");
            strSql.Append("BitIsOK=@BitIsOK,");
            strSql.Append("ModifyTime=@ModifyTime,");
            strSql.Append("SortOrder=@SortOrder,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Remark=@Remark");
            strSql.Append(" where IntID=@IntID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntID", SqlDbType.Int,4),
					new SqlParameter("@IntLinkType", SqlDbType.Int,4),
					new SqlParameter("@IntSiteName", SqlDbType.NVarChar,200),
					new SqlParameter("@NteSiteUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@NteSiteIntro", SqlDbType.NVarChar,800),
					new SqlParameter("@NteLogoUrl", SqlDbType.NVarChar,100),
					new SqlParameter("@NvarSiteAdmin", SqlDbType.NVarChar,50),
					new SqlParameter("@NvarEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@NvarSitePassword", SqlDbType.NVarChar,50),
					new SqlParameter("@BitIsGood", SqlDbType.Bit,1),
					new SqlParameter("@BitIsOK", SqlDbType.Int,4),
					new SqlParameter("@ModifyTime", SqlDbType.DateTime),
					new SqlParameter("@SortOrder", SqlDbType.Int,4),
					new SqlParameter("@QQ", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.NVarChar,50),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,510)
            };
            parameters[0].Value = model.IntID;
            parameters[1].Value = model.IntLinkType;
            parameters[2].Value = model.IntSiteName;
            parameters[3].Value = model.NteSiteUrl;
            parameters[4].Value = model.NteSiteIntro;
            parameters[5].Value = model.NteLogoUrl;
            parameters[6].Value = model.NvarSiteAdmin;
            parameters[7].Value = model.NvarEmail;
            parameters[8].Value = model.NvarSitePassword;
            parameters[9].Value = model.BitIsGood;
            parameters[10].Value = model.BitIsOK;
            parameters[11].Value = model.ModifyTime;
            parameters[12].Value = model.SortOrder;
            parameters[13].Value = model.QQ;
            parameters[14].Value = model.Tel;
            parameters[15].Value = model.Remark;


            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int IntID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_Links ");
            strSql.Append(" where IntID=@IntID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntID", SqlDbType.Int,4)};
            parameters[0].Value = IntID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_Links GetModel(int IntID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 IntID,IntLinkType,IntSiteName,NteSiteUrl,NteSiteIntro,NteLogoUrl,NvarSiteAdmin,NvarEmail,NvarSitePassword,BitIsGood,BitIsOK,ModifyTime,SortOrder,QQ,Tel,Remark from PBnet_Links ");
            strSql.Append(" where IntID=@IntID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntID", SqlDbType.Int,4)};
            parameters[0].Value = IntID;

            Pbzx.Model.PBnet_Links model = new Pbzx.Model.PBnet_Links();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["IntID"].ToString() != "")
                {
                    model.IntID = int.Parse(ds.Tables[0].Rows[0]["IntID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IntLinkType"].ToString() != "")
                {
                    model.IntLinkType = int.Parse(ds.Tables[0].Rows[0]["IntLinkType"].ToString());
                }
                model.IntSiteName = ds.Tables[0].Rows[0]["IntSiteName"].ToString();
                model.NteSiteUrl = ds.Tables[0].Rows[0]["NteSiteUrl"].ToString();
                model.NteSiteIntro = ds.Tables[0].Rows[0]["NteSiteIntro"].ToString();
                model.NteLogoUrl = ds.Tables[0].Rows[0]["NteLogoUrl"].ToString();
                model.NvarSiteAdmin = ds.Tables[0].Rows[0]["NvarSiteAdmin"].ToString();
                model.NvarEmail = ds.Tables[0].Rows[0]["NvarEmail"].ToString();
                model.NvarSitePassword = ds.Tables[0].Rows[0]["NvarSitePassword"].ToString();
                if (ds.Tables[0].Rows[0]["BitIsGood"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BitIsGood"].ToString() == "1") || (ds.Tables[0].Rows[0]["BitIsGood"].ToString().ToLower() == "true"))
                    {
                        model.BitIsGood = true;
                    }
                    else
                    {
                        model.BitIsGood = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["BitIsOK"].ToString() != "")
                {
                    model.BitIsOK = Convert.ToInt32(ds.Tables[0].Rows[0]["BitIsOK"].ToString());
                    //if ((ds.Tables[0].Rows[0]["BitIsOK"].ToString() == "1") || (ds.Tables[0].Rows[0]["BitIsOK"].ToString().ToLower() == "true"))
                    //{
                    //    model.BitIsOK = 1;
                    //}
                    //else if ((ds.Tables[0].Rows[0]["BitIsOK"].ToString() == "0") || (ds.Tables[0].Rows[0]["BitIsOK"].ToString().ToLower() == "true"))
                    //{
                    //    model.BitIsOK = 0;
                    //}
                }
                if (ds.Tables[0].Rows[0]["ModifyTime"].ToString() != "")
                {
                    model.ModifyTime = DateTime.Parse(ds.Tables[0].Rows[0]["ModifyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["SortOrder"].ToString() != "")
                {
                    model.SortOrder = int.Parse(ds.Tables[0].Rows[0]["SortOrder"].ToString());
                }
                model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                model.Tel = ds.Tables[0].Rows[0]["Tel"].ToString();
                model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
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
            strSql.Append("select IntID,IntLinkType,IntSiteName,NteSiteUrl,NteSiteIntro,NteLogoUrl,NvarSiteAdmin,NvarEmail,NvarSitePassword,BitIsGood,BitIsOK,ModifyTime,SortOrder,QQ,Tel,Remark ");
            strSql.Append(" FROM PBnet_Links ");
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
            strSql.Append(" IntID,IntLinkType,IntSiteName,NteSiteUrl,NteSiteIntro,NteLogoUrl,NvarSiteAdmin,NvarEmail,NvarSitePassword,BitIsGood,BitIsOK,ModifyTime,SortOrder,QQ,Tel,Remark ");
            strSql.Append(" FROM PBnet_Links ");
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
            parameters[0].Value = "PBnet_Links";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  成员方法

        #region Delete:删除友情链接.
        /// <summary>
        /// 删除友情链接.
        /// </summary>
        /// <param name="linkid">多个ID.</param>
        /// <returns>被删除的记录数.</returns>
        public int Delete(string linkid)
        {
            string SqlStr = "DELETE FROM PBnet_Links WHERE IntID IN(" + linkid + ")";
            return DbHelperSQL.ExecuteSql(SqlStr);
        }
        #endregion

        #region OK:审核友情链接.
        /// <summary>
        /// :审核友情链接.
        /// </summary>
        /// <param name="linkid">多个ID.</param>
        /// <returns>被审核的记录数.</returns>
        public int Auditing(string linkid)
        {
            string SqlStr = "update PBnet_Links set BitIsOK='1' WHERE IntID IN(" + linkid + ")";
            return DbHelperSQL.ExecuteSql(SqlStr);
        }
        #endregion

        #region NO: 不审核友情链接.
        /// <summary>
        /// :不审核友情链接.
        /// </summary>
        /// <param name="linkid">多个ID.</param>
        /// <returns>不被审核的记录数.</returns>
        public int NoAuditing(string linkid)
        {
            string SqlStr = "update PBnet_Links set BitIsOK='0' WHERE IntID IN(" + linkid + ")";
            return DbHelperSQL.ExecuteSql(SqlStr);
        }
        #endregion


    }
}

