using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;
using System.Collections.Generic;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_News。
    /// </summary>
    public class PBnet_News : IPBnet_News
    {
        public PBnet_News()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int IntID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_News");
            strSql.Append(" where IntID=@IntID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntID", SqlDbType.Int,4)};
            parameters[0].Value = IntID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_News(");
            strSql.Append("NvarTitle,NvarShortTitle,NteContent,NvarAuthor,DatDateAndTime,IntChannelID,IntShowType,BitIsPass,BitIsTop,BitIsHot,IntDisPosition,IntClick,VarPicUrl,VarOperator,IntOrderID,NKey,Metadesc,Source,SourceUrl,Attribute,RandomFileName,EffectDate,Templet,SavePath,FileEXName,IsStatic,PageNum,ShowIndex,ShowInSoft,InWeiXin)");
            strSql.Append(" values (");
            strSql.Append("@NvarTitle,@NvarShortTitle,@NteContent,@NvarAuthor,@DatDateAndTime,@IntChannelID,@IntShowType,@BitIsPass,@BitIsTop,@BitIsHot,@IntDisPosition,@IntClick,@VarPicUrl,@VarOperator,@IntOrderID,@NKey,@Metadesc,@Source,@SourceUrl,@Attribute,@RandomFileName,@EffectDate,@Templet,@SavePath,@FileEXName,@IsStatic,@PageNum,@ShowIndex,@ShowInSoft,@InWeiXin)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@NvarTitle", SqlDbType.NVarChar,255),
					new SqlParameter("@NvarShortTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@NteContent", SqlDbType.NText),
					new SqlParameter("@NvarAuthor", SqlDbType.NVarChar,50),
					new SqlParameter("@DatDateAndTime", SqlDbType.DateTime),
					new SqlParameter("@IntChannelID", SqlDbType.Int,4),
					new SqlParameter("@IntShowType", SqlDbType.Int,4),
					new SqlParameter("@BitIsPass", SqlDbType.Bit,1),
					new SqlParameter("@BitIsTop", SqlDbType.TinyInt,1),
					new SqlParameter("@BitIsHot", SqlDbType.Bit,1),
					new SqlParameter("@IntDisPosition", SqlDbType.VarChar,255),
					new SqlParameter("@IntClick", SqlDbType.Int,4),
					new SqlParameter("@VarPicUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@VarOperator", SqlDbType.NVarChar,100),
					new SqlParameter("@IntOrderID", SqlDbType.Int,4),
					new SqlParameter("@NKey", SqlDbType.NVarChar,200),
					new SqlParameter("@Metadesc", SqlDbType.NVarChar,200),
					new SqlParameter("@Source", SqlDbType.NVarChar,200),
					new SqlParameter("@SourceUrl", SqlDbType.NVarChar,500),
					new SqlParameter("@Attribute", SqlDbType.VarChar,50),
					new SqlParameter("@RandomFileName", SqlDbType.VarChar,100),
					new SqlParameter("@EffectDate", SqlDbType.DateTime),
					new SqlParameter("@Templet", SqlDbType.NVarChar,200),
					new SqlParameter("@SavePath", SqlDbType.NVarChar,200),
					new SqlParameter("@FileEXName", SqlDbType.NVarChar,6),
					new SqlParameter("@IsStatic", SqlDbType.Bit,1),
					new SqlParameter("@PageNum", SqlDbType.Int,4),
					new SqlParameter("@ShowIndex", SqlDbType.Bit,1),
					new SqlParameter("@ShowInSoft", SqlDbType.Bit,1),
                    new SqlParameter("@InWeiXin", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.NvarTitle;
            parameters[1].Value = model.NvarShortTitle;
            parameters[2].Value = model.NteContent;
            parameters[3].Value = model.NvarAuthor;
            parameters[4].Value = model.DatDateAndTime;
            parameters[5].Value = model.IntChannelID;
            parameters[6].Value = model.IntShowType;
            parameters[7].Value = model.BitIsPass;
            parameters[8].Value = model.BitIsTop;
            parameters[9].Value = model.BitIsHot;
            parameters[10].Value = model.IntDisPosition;
            parameters[11].Value = model.IntClick;
            parameters[12].Value = model.VarPicUrl;
            parameters[13].Value = model.VarOperator;
            parameters[14].Value = model.IntOrderID;
            parameters[15].Value = model.NKey;
            parameters[16].Value = model.Metadesc;
            parameters[17].Value = model.Source;
            parameters[18].Value = model.SourceUrl;
            parameters[19].Value = model.Attribute;
            parameters[20].Value = model.RandomFileName;
            parameters[21].Value = model.EffectDate;
            parameters[22].Value = model.Templet;
            parameters[23].Value = model.SavePath;
            parameters[24].Value = model.FileEXName;
            parameters[25].Value = model.IsStatic;
            parameters[26].Value = model.PageNum;
            parameters[27].Value = model.ShowIndex;
            parameters[28].Value = model.ShowInSoft;
            parameters[29].Value = model.InWeiXin;

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
        public int Update(Pbzx.Model.PBnet_News model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_News set ");

            strSql.Append("NvarTitle=@NvarTitle,");
            strSql.Append("NvarShortTitle=@NvarShortTitle,");
            strSql.Append("NteContent=@NteContent,");
            strSql.Append("NvarAuthor=@NvarAuthor,");
             strSql.Append("DatDateAndTime=@DatDateAndTime,");
            strSql.Append("IntChannelID=@IntChannelID,");
            strSql.Append("IntShowType=@IntShowType,");
            strSql.Append("BitIsTop=@BitIsTop,");
            strSql.Append("BitIsHot=@BitIsHot,");
            strSql.Append("BitIsPass=@BitIsPass,");
            strSql.Append("IntDisPosition=@IntDisPosition,");
            strSql.Append("IntClick=@IntClick,");
            strSql.Append("VarPicUrl=@VarPicUrl,");
            strSql.Append("VarOperator=@VarOperator,");
            strSql.Append("IntOrderID=@IntOrderID,");
            strSql.Append("NKey=@NKey,");
            strSql.Append("Metadesc=@Metadesc,");
            strSql.Append("Source=@Source,");
            strSql.Append("SourceUrl=@SourceUrl,");
            strSql.Append("Attribute=@Attribute,");
            strSql.Append("RandomFileName=@RandomFileName,");
            strSql.Append("EffectDate=@EffectDate,");
            strSql.Append("Templet=@Templet,");
            strSql.Append("SavePath=@SavePath,");
            strSql.Append("FileEXName=@FileEXName,");
            strSql.Append("IsStatic=@IsStatic,");
            strSql.Append("PageNum=@PageNum,");
            strSql.Append("ShowIndex=@ShowIndex,");
            strSql.Append("ShowInSoft=@ShowInSoft,");
            strSql.Append("InWeiXin=@InWeiXin");
            strSql.Append(" where IntID=@IntID ");

            SqlParameter[] parameters = {
					new SqlParameter("@IntID", SqlDbType.Int,4),
					new SqlParameter("@NvarTitle", SqlDbType.NVarChar,255),
					new SqlParameter("@NvarShortTitle", SqlDbType.NVarChar,50),
					new SqlParameter("@NteContent", SqlDbType.NText),
					new SqlParameter("@NvarAuthor", SqlDbType.NVarChar,50),
					new SqlParameter("@DatDateAndTime", SqlDbType.DateTime),
					new SqlParameter("@IntChannelID", SqlDbType.Int,4),
					new SqlParameter("@IntShowType", SqlDbType.Int,4),

                    new SqlParameter("@BitIsTop", SqlDbType.TinyInt,1),
                    new SqlParameter("@BitIsHot", SqlDbType.Bit,1),
					new SqlParameter("@BitIsPass", SqlDbType.Bit,1),
					new SqlParameter("@IntDisPosition", SqlDbType.VarChar,255),
					new SqlParameter("@IntClick", SqlDbType.Int,4),
					new SqlParameter("@VarPicUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@VarOperator", SqlDbType.NVarChar,100),
					new SqlParameter("@IntOrderID", SqlDbType.Int,4),
					new SqlParameter("@NKey", SqlDbType.NVarChar,200),
					new SqlParameter("@Metadesc", SqlDbType.NVarChar,200),
					new SqlParameter("@Source", SqlDbType.NVarChar,200),
					new SqlParameter("@SourceUrl", SqlDbType.NVarChar,500),
					new SqlParameter("@Attribute", SqlDbType.VarChar,50),
					new SqlParameter("@RandomFileName", SqlDbType.VarChar,100),
					new SqlParameter("@EffectDate", SqlDbType.DateTime),
					new SqlParameter("@Templet", SqlDbType.NVarChar,200),
					new SqlParameter("@SavePath", SqlDbType.NVarChar,200),
					new SqlParameter("@FileEXName", SqlDbType.NVarChar,6),
					new SqlParameter("@IsStatic", SqlDbType.Bit,1),
					new SqlParameter("@PageNum", SqlDbType.Int,4),
					new SqlParameter("@ShowIndex", SqlDbType.Bit,1),
					new SqlParameter("@ShowInSoft", SqlDbType.Bit,1),
                                         new SqlParameter("@InWeiXin", SqlDbType.Int,4)};
            parameters[0].Value = model.IntID;
            parameters[1].Value = model.NvarTitle;
            parameters[2].Value = model.NvarShortTitle;
            parameters[3].Value = model.NteContent;
            parameters[4].Value = model.NvarAuthor;
            parameters[5].Value = model.DatDateAndTime;
            parameters[6].Value = model.IntChannelID;
            parameters[7].Value = model.IntShowType;

            parameters[8].Value = model.BitIsTop;
            parameters[9].Value = model.BitIsHot;
            parameters[10].Value = model.BitIsPass;

            parameters[11].Value = model.IntDisPosition;
            parameters[12].Value = model.IntClick;
            parameters[13].Value = model.VarPicUrl;
            parameters[14].Value = model.VarOperator;
            parameters[15].Value = model.IntOrderID;
            parameters[16].Value = model.NKey;
            parameters[17].Value = model.Metadesc;
            parameters[18].Value = model.Source;
            parameters[19].Value = model.SourceUrl;
            parameters[20].Value = model.Attribute;
            parameters[21].Value = model.RandomFileName;
            parameters[22].Value = model.EffectDate;
            parameters[23].Value = model.Templet;
            parameters[24].Value = model.SavePath;
            parameters[25].Value = model.FileEXName;
            parameters[26].Value = model.IsStatic;
            parameters[27].Value = model.PageNum;
            parameters[28].Value = model.ShowIndex;
            parameters[29].Value = model.ShowInSoft;
            parameters[30].Value = model.InWeiXin;

           return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int IntID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_News ");
            strSql.Append(" where IntID=@IntID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntID", SqlDbType.Int,4)};
            parameters[0].Value = IntID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_News GetModel(int IntID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 IntID,NvarTitle,NvarShortTitle,NteContent,NvarAuthor,DatDateAndTime,IntChannelID,IntShowType,BitIsPass,BitIsTop,BitIsHot,IntDisPosition,IntClick,VarPicUrl,VarOperator,IntOrderID,NKey,Metadesc,Source,SourceUrl,Attribute,RandomFileName,EffectDate,Templet,SavePath,FileEXName,IsStatic,PageNum,ShowIndex,ShowInSoft,InWeiXin from PBnet_News ");
            strSql.Append(" where IntID=@IntID ");
            SqlParameter[] parameters = {
					new SqlParameter("@IntID", SqlDbType.Int,4)};
            parameters[0].Value = IntID;

            Pbzx.Model.PBnet_News model = new Pbzx.Model.PBnet_News();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["IntID"].ToString() != "")
                {
                    model.IntID = int.Parse(ds.Tables[0].Rows[0]["IntID"].ToString());
                }
                model.NvarTitle = ds.Tables[0].Rows[0]["NvarTitle"].ToString();
                model.NvarShortTitle = ds.Tables[0].Rows[0]["NvarShortTitle"].ToString();
                model.NteContent = ds.Tables[0].Rows[0]["NteContent"].ToString();
                model.NvarAuthor = ds.Tables[0].Rows[0]["NvarAuthor"].ToString();
                if (ds.Tables[0].Rows[0]["DatDateAndTime"].ToString() != "")
                {
                    model.DatDateAndTime = DateTime.Parse(ds.Tables[0].Rows[0]["DatDateAndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IntChannelID"].ToString() != "")
                {
                    model.IntChannelID = int.Parse(ds.Tables[0].Rows[0]["IntChannelID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IntShowType"].ToString() != "")
                {
                    model.IntShowType = int.Parse(ds.Tables[0].Rows[0]["IntShowType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BitIsPass"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BitIsPass"].ToString() == "1") || (ds.Tables[0].Rows[0]["BitIsPass"].ToString().ToLower() == "true"))
                    {
                        model.BitIsPass = true;
                    }
                    else
                    {
                        model.BitIsPass = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["BitIsTop"].ToString() != "")
                {
                    model.BitIsTop = int.Parse(ds.Tables[0].Rows[0]["BitIsTop"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BitIsHot"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["BitIsHot"].ToString() == "1") || (ds.Tables[0].Rows[0]["BitIsHot"].ToString().ToLower() == "true"))
                    {
                        model.BitIsHot = true;
                    }
                    else
                    {
                        model.BitIsHot = false;
                    }
                }
                model.IntDisPosition = ds.Tables[0].Rows[0]["IntDisPosition"].ToString();
                if (ds.Tables[0].Rows[0]["IntClick"].ToString() != "")
                {
                    model.IntClick = int.Parse(ds.Tables[0].Rows[0]["IntClick"].ToString());
                }
                model.VarPicUrl = ds.Tables[0].Rows[0]["VarPicUrl"].ToString();
                model.VarOperator = ds.Tables[0].Rows[0]["VarOperator"].ToString();
                if (ds.Tables[0].Rows[0]["IntOrderID"].ToString() != "")
                {
                    model.IntOrderID = int.Parse(ds.Tables[0].Rows[0]["IntOrderID"].ToString());
                }
                model.NKey = ds.Tables[0].Rows[0]["NKey"].ToString();
                model.Metadesc = ds.Tables[0].Rows[0]["Metadesc"].ToString();
                model.Source = ds.Tables[0].Rows[0]["Source"].ToString();
                model.SourceUrl = ds.Tables[0].Rows[0]["SourceUrl"].ToString();
                model.Attribute = ds.Tables[0].Rows[0]["Attribute"].ToString();
                model.RandomFileName = ds.Tables[0].Rows[0]["RandomFileName"].ToString();
                if (ds.Tables[0].Rows[0]["EffectDate"].ToString() != "")
                {
                    model.EffectDate = DateTime.Parse(ds.Tables[0].Rows[0]["EffectDate"].ToString());
                }
                model.Templet = ds.Tables[0].Rows[0]["Templet"].ToString();
                model.SavePath = ds.Tables[0].Rows[0]["SavePath"].ToString();
                model.FileEXName = ds.Tables[0].Rows[0]["FileEXName"].ToString();
                if (ds.Tables[0].Rows[0]["IsStatic"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["IsStatic"].ToString() == "1") || (ds.Tables[0].Rows[0]["IsStatic"].ToString().ToLower() == "true"))
                    {
                        model.IsStatic = true;
                    }
                    else
                    {
                        model.IsStatic = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["PageNum"].ToString() != "")
                {
                    model.PageNum = int.Parse(ds.Tables[0].Rows[0]["PageNum"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShowIndex"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ShowIndex"].ToString() == "1") || (ds.Tables[0].Rows[0]["ShowIndex"].ToString().ToLower() == "true"))
                    {
                        model.ShowIndex = true;
                    }
                    else
                    {
                        model.ShowIndex = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["ShowInSoft"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["ShowInSoft"].ToString() == "1") || (ds.Tables[0].Rows[0]["ShowInSoft"].ToString().ToLower() == "true"))
                    {
                        model.ShowInSoft = true;
                    }
                    else
                    {
                        model.ShowInSoft = false;
                    }
                }
               if (ds.Tables[0].Rows[0]["InWeiXin"].ToString() != "")
                {
                    model.InWeiXin = int.Parse(ds.Tables[0].Rows[0]["InWeiXin"].ToString());
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
            strSql.Append("select IntID,NvarTitle,NvarShortTitle,NteContent,NvarAuthor,DatDateAndTime,IntChannelID,IntShowType,BitIsPass,BitIsTop,BitIsHot,IntDisPosition,IntClick,VarPicUrl,VarOperator,IntOrderID,NKey,Metadesc,Source,SourceUrl,Attribute,RandomFileName,EffectDate,Templet,SavePath,FileEXName,IsStatic,PageNum,ShowIndex,ShowInSoft,InWeiXin ");
            strSql.Append(" FROM PBnet_News ");
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
            strSql.Append(" IntID,NvarTitle,NvarShortTitle,NteContent,NvarAuthor,DatDateAndTime,IntChannelID,IntShowType,BitIsPass,BitIsTop,BitIsHot,IntDisPosition,IntClick,VarPicUrl,VarOperator,IntOrderID,NKey,Metadesc,Source,SourceUrl,Attribute,RandomFileName,EffectDate,Templet,SavePath,FileEXName,IsStatic,PageNum,ShowIndex,ShowInSoft,InWeiXin ");
            strSql.Append(" FROM PBnet_News ");
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
            parameters[0].Value = "PBnet_News";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/
        #endregion  成员方法
        public int ExecuteBySql(string sql)
        {
            return DbHelperSQL.ExecuteSql(sql);
        }
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
         #region
         /// <summary>
         /// 根据模块ID删除
         /// </summary>
         /// <param name="moduleinfo">模块ID</param>
         public void ArticleDeleteByModuleID(int Moduleid)
         {
             int rowsAffected;
             SqlParameter[] parameters = {
					new SqlParameter("@Moduleid", SqlDbType.Int,4)};
             parameters[0].Value = Moduleid;

             DbHelperSQL.RunProcedure("rzrs_ArticleDeleteByModuleID", parameters, out rowsAffected);
         }






        #endregion
     }
}

