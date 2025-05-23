using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_Product。
    /// </summary>
    public class PBnet_Product : IPBnet_Product
    {
        public PBnet_Product()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("pb_SoftID", "PBnet_Product");
        }

        public bool Exists(int pb_SoftID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_Product");
            strSql.Append(" where pb_SoftID=@pb_SoftID ");
            SqlParameter[] parameters = {
					new SqlParameter("@pb_SoftID", SqlDbType.Int,4)};
            parameters[0].Value = pb_SoftID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_Product(");
            strSql.Append("pb_ClassID,pb_SoftName,pb_SoftVersion,pb_Author,pb_AuthorEmail,pb_AuthorHomepage,pb_DemoUrl,pb_Editor,pb_Keyword,pb_Hits,pb_DayHits,pb_WeekHits,pb_MonthHits,pb_UpdateTime,pb_OperatingSystem,pb_TypeName,pb_SoftType,pb_SoftLanguage,pb_CopyrightType,pb_SoftSize,pb_RegUrl,pb_OnTop,pb_Elite,pb_Passed,pb_SoftIntro,pb_SoftPicUrl,pb_DownloadUrl1,pb_DownloadUrl2,pb_DownloadUrl3,pb_DownloadUrl4,pb_SoftLevel,pb_SoftPoint,pb_Deleted,pb_Stars,pb_DecompressPassword,pb_LastHitTime,pb_softContent,countid,pb_Softdemo,pb_illuminate,pb_indexshow,pb_freeshow,OuterHits,OuterDayHits,OuterWeekHits,OuterMonthHits,CstID,PBnet_Softshow,icountid,Video)");
            strSql.Append(" values (");
            strSql.Append("@pb_ClassID,@pb_SoftName,@pb_SoftVersion,@pb_Author,@pb_AuthorEmail,@pb_AuthorHomepage,@pb_DemoUrl,@pb_Editor,@pb_Keyword,@pb_Hits,@pb_DayHits,@pb_WeekHits,@pb_MonthHits,@pb_UpdateTime,@pb_OperatingSystem,@pb_TypeName,@pb_SoftType,@pb_SoftLanguage,@pb_CopyrightType,@pb_SoftSize,@pb_RegUrl,@pb_OnTop,@pb_Elite,@pb_Passed,@pb_SoftIntro,@pb_SoftPicUrl,@pb_DownloadUrl1,@pb_DownloadUrl2,@pb_DownloadUrl3,@pb_DownloadUrl4,@pb_SoftLevel,@pb_SoftPoint,@pb_Deleted,@pb_Stars,@pb_DecompressPassword,@pb_LastHitTime,@pb_softContent,@countid,@pb_Softdemo,@pb_illuminate,@pb_indexshow,@pb_freeshow,@OuterHits,@OuterDayHits,@OuterWeekHits,@OuterMonthHits,@CstID,@PBnet_Softshow,@icountid,@Video)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@pb_ClassID", SqlDbType.Int,4),
					new SqlParameter("@pb_SoftName", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_SoftVersion", SqlDbType.NVarChar,100),
					new SqlParameter("@pb_Author", SqlDbType.NVarChar,30),
					new SqlParameter("@pb_AuthorEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_AuthorHomepage", SqlDbType.NVarChar,200),
					new SqlParameter("@pb_DemoUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_Editor", SqlDbType.NVarChar,20),
					new SqlParameter("@pb_Keyword", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_Hits", SqlDbType.Int,4),
					new SqlParameter("@pb_DayHits", SqlDbType.Int,4),
					new SqlParameter("@pb_WeekHits", SqlDbType.Int,4),
					new SqlParameter("@pb_MonthHits", SqlDbType.Int,4),
					new SqlParameter("@pb_UpdateTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_OperatingSystem", SqlDbType.NVarChar,100),
					new SqlParameter("@pb_TypeName", SqlDbType.VarChar,50),
					new SqlParameter("@pb_SoftType", SqlDbType.Int,4),
					new SqlParameter("@pb_SoftLanguage", SqlDbType.Int,4),
					new SqlParameter("@pb_CopyrightType", SqlDbType.Int,4),
					new SqlParameter("@pb_SoftSize", SqlDbType.Int,4),
					new SqlParameter("@pb_RegUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@pb_OnTop", SqlDbType.Bit,1),
					new SqlParameter("@pb_Elite", SqlDbType.Bit,1),
					new SqlParameter("@pb_Passed", SqlDbType.Bit,1),
					new SqlParameter("@pb_SoftIntro", SqlDbType.NText),
					new SqlParameter("@pb_SoftPicUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl1", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl2", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl3", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl4", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_SoftLevel", SqlDbType.Int,4),
					new SqlParameter("@pb_SoftPoint", SqlDbType.Int,4),
					new SqlParameter("@pb_Deleted", SqlDbType.Bit,1),
					new SqlParameter("@pb_Stars", SqlDbType.Int,4),
					new SqlParameter("@pb_DecompressPassword", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_LastHitTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_softContent", SqlDbType.NText),
					new SqlParameter("@countid", SqlDbType.Int,4),
					new SqlParameter("@pb_Softdemo", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_illuminate", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_indexshow", SqlDbType.Bit,1),
					new SqlParameter("@pb_freeshow", SqlDbType.Bit,1),
					new SqlParameter("@OuterHits", SqlDbType.Int,4),
					new SqlParameter("@OuterDayHits", SqlDbType.Int,4),
					new SqlParameter("@OuterWeekHits", SqlDbType.Int,4),
					new SqlParameter("@OuterMonthHits", SqlDbType.Int,4),
					new SqlParameter("@CstID", SqlDbType.TinyInt,1),
					new SqlParameter("@PBnet_Softshow", SqlDbType.Bit,1),
                    new SqlParameter("@icountid", SqlDbType.Int,4),
                    new SqlParameter("@Video",SqlDbType.Text)    
            };
            parameters[0].Value = model.pb_ClassID;
            parameters[1].Value = model.pb_SoftName;
            parameters[2].Value = model.pb_SoftVersion;
            parameters[3].Value = model.pb_Author;
            parameters[4].Value = model.pb_AuthorEmail;
            parameters[5].Value = model.pb_AuthorHomepage;
            parameters[6].Value = model.pb_DemoUrl;
            parameters[7].Value = model.pb_Editor;
            parameters[8].Value = model.pb_Keyword;
            parameters[9].Value = model.pb_Hits;
            parameters[10].Value = model.pb_DayHits;
            parameters[11].Value = model.pb_WeekHits;
            parameters[12].Value = model.pb_MonthHits;
            parameters[13].Value = model.pb_UpdateTime;
            parameters[14].Value = model.pb_OperatingSystem;
            parameters[15].Value = model.pb_TypeName;
            parameters[16].Value = model.pb_SoftType;
            parameters[17].Value = model.pb_SoftLanguage;
            parameters[18].Value = model.pb_CopyrightType;
            parameters[19].Value = model.pb_SoftSize;
            parameters[20].Value = model.pb_RegUrl;
            parameters[21].Value = model.pb_OnTop;
            parameters[22].Value = model.pb_Elite;
            parameters[23].Value = model.pb_Passed;
            parameters[24].Value = model.pb_SoftIntro;
            parameters[25].Value = model.pb_SoftPicUrl;
            parameters[26].Value = model.pb_DownloadUrl1;
            parameters[27].Value = model.pb_DownloadUrl2;
            parameters[28].Value = model.pb_DownloadUrl3;
            parameters[29].Value = model.pb_DownloadUrl4;
            parameters[30].Value = model.pb_SoftLevel;
            parameters[31].Value = model.pb_SoftPoint;
            parameters[32].Value = model.pb_Deleted;
            parameters[33].Value = model.pb_Stars;
            parameters[34].Value = model.pb_DecompressPassword;
            parameters[35].Value = model.pb_LastHitTime;
            parameters[36].Value = model.pb_softContent;
            parameters[37].Value = model.countid;
            parameters[38].Value = model.pb_Softdemo;
            parameters[39].Value = model.pb_illuminate;
            parameters[40].Value = model.pb_indexshow;
            parameters[41].Value = model.pb_freeshow;
            parameters[42].Value = model.OuterHits;
            parameters[43].Value = model.OuterDayHits;
            parameters[44].Value = model.OuterWeekHits;
            parameters[45].Value = model.OuterMonthHits;
            parameters[46].Value = model.CstID;
            parameters[47].Value = model.PBnet_Softshow;
            parameters[48].Value = model.icountid;
            parameters[49].Value = model.Video;

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
        public int Update(Pbzx.Model.PBnet_Product model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_Product set ");
            strSql.Append("pb_ClassID=@pb_ClassID,");
            strSql.Append("pb_SoftName=@pb_SoftName,");
            strSql.Append("pb_SoftVersion=@pb_SoftVersion,");
            strSql.Append("pb_Author=@pb_Author,");
            strSql.Append("pb_AuthorEmail=@pb_AuthorEmail,");
            strSql.Append("pb_AuthorHomepage=@pb_AuthorHomepage,");
            strSql.Append("pb_DemoUrl=@pb_DemoUrl,");
            strSql.Append("pb_Editor=@pb_Editor,");
            strSql.Append("pb_Keyword=@pb_Keyword,");
            strSql.Append("pb_Hits=@pb_Hits,");
            strSql.Append("pb_DayHits=@pb_DayHits,");
            strSql.Append("pb_WeekHits=@pb_WeekHits,");
            strSql.Append("pb_MonthHits=@pb_MonthHits,");
            strSql.Append("pb_UpdateTime=@pb_UpdateTime,");
            strSql.Append("pb_OperatingSystem=@pb_OperatingSystem,");
            strSql.Append("pb_TypeName=@pb_TypeName,");
            strSql.Append("pb_SoftType=@pb_SoftType,");
            strSql.Append("pb_SoftLanguage=@pb_SoftLanguage,");
            strSql.Append("pb_CopyrightType=@pb_CopyrightType,");
            strSql.Append("pb_SoftSize=@pb_SoftSize,");
            strSql.Append("pb_RegUrl=@pb_RegUrl,");
            strSql.Append("pb_OnTop=@pb_OnTop,");
            strSql.Append("pb_Elite=@pb_Elite,");
            strSql.Append("pb_Passed=@pb_Passed,");
            strSql.Append("pb_SoftIntro=@pb_SoftIntro,");
            strSql.Append("pb_SoftPicUrl=@pb_SoftPicUrl,");
            strSql.Append("pb_DownloadUrl1=@pb_DownloadUrl1,");
            strSql.Append("pb_DownloadUrl2=@pb_DownloadUrl2,");
            strSql.Append("pb_DownloadUrl3=@pb_DownloadUrl3,");
            strSql.Append("pb_DownloadUrl4=@pb_DownloadUrl4,");
            strSql.Append("pb_SoftLevel=@pb_SoftLevel,");
            strSql.Append("pb_SoftPoint=@pb_SoftPoint,");
            strSql.Append("pb_Stars=@pb_Stars,");
            strSql.Append("pb_DecompressPassword=@pb_DecompressPassword,");
            strSql.Append("pb_LastHitTime=@pb_LastHitTime,");
            strSql.Append("pb_softContent=@pb_softContent,");
            strSql.Append("countid=@countid,");
            strSql.Append("pb_Softdemo=@pb_Softdemo,");
            strSql.Append("pb_illuminate=@pb_illuminate,");
            strSql.Append("pb_indexshow=@pb_indexshow,");
            strSql.Append("pb_freeshow=@pb_freeshow,");
            strSql.Append("OuterHits=@OuterHits,");
            strSql.Append("OuterDayHits=@OuterDayHits,");
            strSql.Append("OuterWeekHits=@OuterWeekHits,");
            strSql.Append("OuterMonthHits=@OuterMonthHits,");
            strSql.Append("CstID=@CstID,");
            strSql.Append("PBnet_Softshow=@PBnet_Softshow,");
            //icountid
            strSql.Append("icountid=@icountid,");
            strSql.Append("Video=@Video ");
            strSql.Append(" where pb_SoftID=@pb_SoftID ");
            SqlParameter[] parameters = {
					new SqlParameter("@pb_SoftID", SqlDbType.Int,4),
					new SqlParameter("@pb_ClassID", SqlDbType.Int,4),
					new SqlParameter("@pb_SoftName", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_SoftVersion", SqlDbType.NVarChar,100),
					new SqlParameter("@pb_Author", SqlDbType.NVarChar,30),
					new SqlParameter("@pb_AuthorEmail", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_AuthorHomepage", SqlDbType.NVarChar,200),
					new SqlParameter("@pb_DemoUrl", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_Editor", SqlDbType.NVarChar,20),
					new SqlParameter("@pb_Keyword", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_Hits", SqlDbType.Int,4),
					new SqlParameter("@pb_DayHits", SqlDbType.Int,4),
					new SqlParameter("@pb_WeekHits", SqlDbType.Int,4),
					new SqlParameter("@pb_MonthHits", SqlDbType.Int,4),
					new SqlParameter("@pb_UpdateTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_OperatingSystem", SqlDbType.NVarChar,100),
					new SqlParameter("@pb_TypeName", SqlDbType.VarChar,50),
					new SqlParameter("@pb_SoftType", SqlDbType.Int,4),
					new SqlParameter("@pb_SoftLanguage", SqlDbType.Int,4),
					new SqlParameter("@pb_CopyrightType", SqlDbType.Int,4),
					new SqlParameter("@pb_SoftSize", SqlDbType.Int,4),
					new SqlParameter("@pb_RegUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@pb_OnTop", SqlDbType.Bit,1),
					new SqlParameter("@pb_Elite", SqlDbType.Bit,1),
					new SqlParameter("@pb_Passed", SqlDbType.Bit,1),
					new SqlParameter("@pb_SoftIntro", SqlDbType.NText),
					new SqlParameter("@pb_SoftPicUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl1", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl2", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl3", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl4", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_SoftLevel", SqlDbType.Int,4),
					new SqlParameter("@pb_SoftPoint", SqlDbType.Int,4),
					new SqlParameter("@pb_Deleted", SqlDbType.Bit,1),
					new SqlParameter("@pb_Stars", SqlDbType.Int,4),
					new SqlParameter("@pb_DecompressPassword", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_LastHitTime", SqlDbType.SmallDateTime),
					new SqlParameter("@pb_softContent", SqlDbType.NText),
					new SqlParameter("@countid", SqlDbType.Int,4),
					new SqlParameter("@pb_Softdemo", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_illuminate", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_indexshow", SqlDbType.Bit,1),
					new SqlParameter("@pb_freeshow", SqlDbType.Bit,1),
					new SqlParameter("@OuterHits", SqlDbType.Int,4),
					new SqlParameter("@OuterDayHits", SqlDbType.Int,4),
					new SqlParameter("@OuterWeekHits", SqlDbType.Int,4),
					new SqlParameter("@OuterMonthHits", SqlDbType.Int,4),
					new SqlParameter("@CstID", SqlDbType.TinyInt,1),
					new SqlParameter("@PBnet_Softshow", SqlDbType.Bit,1),
                    new SqlParameter("@icountid", SqlDbType.Int,4),
                    new SqlParameter("@Video",SqlDbType.Text)
            //icountid
            };
            parameters[0].Value = model.pb_SoftID;
            parameters[1].Value = model.pb_ClassID;
            parameters[2].Value = model.pb_SoftName;
            parameters[3].Value = model.pb_SoftVersion;
            parameters[4].Value = model.pb_Author;
            parameters[5].Value = model.pb_AuthorEmail;
            parameters[6].Value = model.pb_AuthorHomepage;
            parameters[7].Value = model.pb_DemoUrl;
            parameters[8].Value = model.pb_Editor;
            parameters[9].Value = model.pb_Keyword;
            parameters[10].Value = model.pb_Hits;
            parameters[11].Value = model.pb_DayHits;
            parameters[12].Value = model.pb_WeekHits;
            parameters[13].Value = model.pb_MonthHits;
            parameters[14].Value = model.pb_UpdateTime;
            parameters[15].Value = model.pb_OperatingSystem;
            parameters[16].Value = model.pb_TypeName;
            parameters[17].Value = model.pb_SoftType;
            parameters[18].Value = model.pb_SoftLanguage;
            parameters[19].Value = model.pb_CopyrightType;
            parameters[20].Value = model.pb_SoftSize;
            parameters[21].Value = model.pb_RegUrl;
            parameters[22].Value = model.pb_OnTop;
            parameters[23].Value = model.pb_Elite;
            parameters[24].Value = model.pb_Passed;
            parameters[25].Value = model.pb_SoftIntro;
            parameters[26].Value = model.pb_SoftPicUrl;
            parameters[27].Value = model.pb_DownloadUrl1;
            parameters[28].Value = model.pb_DownloadUrl2;
            parameters[29].Value = model.pb_DownloadUrl3;
            parameters[30].Value = model.pb_DownloadUrl4;
            parameters[31].Value = model.pb_SoftLevel;
            parameters[32].Value = model.pb_SoftPoint;
            parameters[33].Value = model.pb_Deleted;
            parameters[34].Value = model.pb_Stars;
            parameters[35].Value = model.pb_DecompressPassword;
            parameters[36].Value = model.pb_LastHitTime;
            parameters[37].Value = model.pb_softContent;
            parameters[38].Value = model.countid;
            parameters[39].Value = model.pb_Softdemo;
            parameters[40].Value = model.pb_illuminate;
            parameters[41].Value = model.pb_indexshow;
            parameters[42].Value = model.pb_freeshow;
            parameters[43].Value = model.OuterHits;
            parameters[44].Value = model.OuterDayHits;
            parameters[45].Value = model.OuterWeekHits;
            parameters[46].Value = model.OuterMonthHits;
            parameters[47].Value = model.CstID;
            parameters[48].Value = model.PBnet_Softshow;
            parameters[49].Value = model.icountid;
            parameters[50].Value = model.Video;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int pb_SoftID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_Product ");
            strSql.Append(" where pb_SoftID=@pb_SoftID ");
            SqlParameter[] parameters = {
					new SqlParameter("@pb_SoftID", SqlDbType.Int,4)};
            parameters[0].Value = pb_SoftID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_Product GetModel(int pb_SoftID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 pb_SoftID,pb_ClassID,pb_SoftName,pb_SoftVersion,pb_Author,pb_AuthorEmail,pb_AuthorHomepage,pb_DemoUrl,pb_Editor,pb_Keyword,pb_Hits,pb_DayHits,pb_WeekHits,pb_MonthHits,pb_UpdateTime,pb_OperatingSystem,pb_TypeName,pb_SoftType,pb_SoftLanguage,pb_CopyrightType,pb_SoftSize,pb_RegUrl,pb_OnTop,pb_Elite,pb_Passed,pb_SoftIntro,pb_SoftPicUrl,pb_DownloadUrl1,pb_DownloadUrl2,pb_DownloadUrl3,pb_DownloadUrl4,pb_SoftLevel,pb_SoftPoint,pb_Deleted,pb_Stars,pb_DecompressPassword,pb_LastHitTime,pb_softContent,countid,pb_Softdemo,pb_illuminate,pb_indexshow,pb_freeshow,OuterHits,OuterDayHits,OuterWeekHits,OuterMonthHits,CstID,PBnet_Softshow,icountid,Video from PBnet_Product ");
            strSql.Append(" where pb_SoftID=@pb_SoftID ");
            SqlParameter[] parameters = {
					new SqlParameter("@pb_SoftID", SqlDbType.Int,4)};
            parameters[0].Value = pb_SoftID;

            Pbzx.Model.PBnet_Product model = new Pbzx.Model.PBnet_Product();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["pb_SoftID"].ToString() != "")
                {
                    model.pb_SoftID = int.Parse(ds.Tables[0].Rows[0]["pb_SoftID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_ClassID"].ToString() != "")
                {
                    model.pb_ClassID = int.Parse(ds.Tables[0].Rows[0]["pb_ClassID"].ToString());
                }
                model.pb_SoftName = ds.Tables[0].Rows[0]["pb_SoftName"].ToString();
                model.pb_SoftVersion = ds.Tables[0].Rows[0]["pb_SoftVersion"].ToString();
                model.pb_Author = ds.Tables[0].Rows[0]["pb_Author"].ToString();
                model.pb_AuthorEmail = ds.Tables[0].Rows[0]["pb_AuthorEmail"].ToString();
                model.pb_AuthorHomepage = ds.Tables[0].Rows[0]["pb_AuthorHomepage"].ToString();
                model.pb_DemoUrl = ds.Tables[0].Rows[0]["pb_DemoUrl"].ToString();
                model.pb_Editor = ds.Tables[0].Rows[0]["pb_Editor"].ToString();
                model.pb_Keyword = ds.Tables[0].Rows[0]["pb_Keyword"].ToString();
                if (ds.Tables[0].Rows[0]["pb_Hits"].ToString() != "")
                {
                    model.pb_Hits = int.Parse(ds.Tables[0].Rows[0]["pb_Hits"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_DayHits"].ToString() != "")
                {
                    model.pb_DayHits = int.Parse(ds.Tables[0].Rows[0]["pb_DayHits"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_WeekHits"].ToString() != "")
                {
                    model.pb_WeekHits = int.Parse(ds.Tables[0].Rows[0]["pb_WeekHits"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_MonthHits"].ToString() != "")
                {
                    model.pb_MonthHits = int.Parse(ds.Tables[0].Rows[0]["pb_MonthHits"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_UpdateTime"].ToString() != "")
                {
                    model.pb_UpdateTime = DateTime.Parse(ds.Tables[0].Rows[0]["pb_UpdateTime"].ToString());
                }
                model.pb_OperatingSystem = ds.Tables[0].Rows[0]["pb_OperatingSystem"].ToString();
                model.pb_TypeName = ds.Tables[0].Rows[0]["pb_TypeName"].ToString();
                if (ds.Tables[0].Rows[0]["pb_SoftType"].ToString() != "")
                {
                    model.pb_SoftType = int.Parse(ds.Tables[0].Rows[0]["pb_SoftType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_SoftLanguage"].ToString() != "")
                {
                    model.pb_SoftLanguage = int.Parse(ds.Tables[0].Rows[0]["pb_SoftLanguage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_CopyrightType"].ToString() != "")
                {
                    model.pb_CopyrightType = int.Parse(ds.Tables[0].Rows[0]["pb_CopyrightType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_SoftSize"].ToString() != "")
                {
                    model.pb_SoftSize = int.Parse(ds.Tables[0].Rows[0]["pb_SoftSize"].ToString());
                }
                model.pb_RegUrl = ds.Tables[0].Rows[0]["pb_RegUrl"].ToString();
                if (ds.Tables[0].Rows[0]["pb_OnTop"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["pb_OnTop"].ToString() == "1") || (ds.Tables[0].Rows[0]["pb_OnTop"].ToString().ToLower() == "true"))
                    {
                        model.pb_OnTop = true;
                    }
                    else
                    {
                        model.pb_OnTop = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["pb_Elite"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["pb_Elite"].ToString() == "1") || (ds.Tables[0].Rows[0]["pb_Elite"].ToString().ToLower() == "true"))
                    {
                        model.pb_Elite = true;
                    }
                    else
                    {
                        model.pb_Elite = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["pb_Passed"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["pb_Passed"].ToString() == "1") || (ds.Tables[0].Rows[0]["pb_Passed"].ToString().ToLower() == "true"))
                    {
                        model.pb_Passed = true;
                    }
                    else
                    {
                        model.pb_Passed = false;
                    }
                }
                model.pb_SoftIntro = ds.Tables[0].Rows[0]["pb_SoftIntro"].ToString();
                model.pb_SoftPicUrl = ds.Tables[0].Rows[0]["pb_SoftPicUrl"].ToString();
                model.pb_DownloadUrl1 = ds.Tables[0].Rows[0]["pb_DownloadUrl1"].ToString();
                model.pb_DownloadUrl2 = ds.Tables[0].Rows[0]["pb_DownloadUrl2"].ToString();
                model.pb_DownloadUrl3 = ds.Tables[0].Rows[0]["pb_DownloadUrl3"].ToString();
                model.pb_DownloadUrl4 = ds.Tables[0].Rows[0]["pb_DownloadUrl4"].ToString();
                if (ds.Tables[0].Rows[0]["pb_SoftLevel"].ToString() != "")
                {
                    model.pb_SoftLevel = int.Parse(ds.Tables[0].Rows[0]["pb_SoftLevel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_SoftPoint"].ToString() != "")
                {
                    model.pb_SoftPoint = int.Parse(ds.Tables[0].Rows[0]["pb_SoftPoint"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_Deleted"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["pb_Deleted"].ToString() == "1") || (ds.Tables[0].Rows[0]["pb_Deleted"].ToString().ToLower() == "true"))
                    {
                        model.pb_Deleted = true;
                    }
                    else
                    {
                        model.pb_Deleted = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["pb_Stars"].ToString() != "")
                {
                    model.pb_Stars = int.Parse(ds.Tables[0].Rows[0]["pb_Stars"].ToString());
                }
                model.pb_DecompressPassword = ds.Tables[0].Rows[0]["pb_DecompressPassword"].ToString();
                if (ds.Tables[0].Rows[0]["pb_LastHitTime"].ToString() != "")
                {
                    model.pb_LastHitTime = DateTime.Parse(ds.Tables[0].Rows[0]["pb_LastHitTime"].ToString());
                }
                model.pb_softContent = ds.Tables[0].Rows[0]["pb_softContent"].ToString();
                if (ds.Tables[0].Rows[0]["countid"].ToString() != "")
                {
                    model.countid = int.Parse(ds.Tables[0].Rows[0]["countid"].ToString());
                }
                model.pb_Softdemo = ds.Tables[0].Rows[0]["pb_Softdemo"].ToString();
                model.pb_illuminate = ds.Tables[0].Rows[0]["pb_illuminate"].ToString();
                if (ds.Tables[0].Rows[0]["pb_indexshow"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["pb_indexshow"].ToString() == "1") || (ds.Tables[0].Rows[0]["pb_indexshow"].ToString().ToLower() == "true"))
                    {
                        model.pb_indexshow = true;
                    }
                    else
                    {
                        model.pb_indexshow = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["pb_freeshow"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["pb_freeshow"].ToString() == "1") || (ds.Tables[0].Rows[0]["pb_freeshow"].ToString().ToLower() == "true"))
                    {
                        model.pb_freeshow = true;
                    }
                    else
                    {
                        model.pb_freeshow = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["OuterHits"].ToString() != "")
                {
                    model.OuterHits = int.Parse(ds.Tables[0].Rows[0]["OuterHits"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OuterDayHits"].ToString() != "")
                {
                    model.OuterDayHits = int.Parse(ds.Tables[0].Rows[0]["OuterDayHits"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OuterWeekHits"].ToString() != "")
                {
                    model.OuterWeekHits = int.Parse(ds.Tables[0].Rows[0]["OuterWeekHits"].ToString());
                }
                if (ds.Tables[0].Rows[0]["OuterMonthHits"].ToString() != "")
                {
                    model.OuterMonthHits = int.Parse(ds.Tables[0].Rows[0]["OuterMonthHits"].ToString());
                }
                if (ds.Tables[0].Rows[0]["CstID"].ToString() != "")
                {
                    model.CstID = int.Parse(ds.Tables[0].Rows[0]["CstID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBnet_Softshow"].ToString() != "")
                {
                    if ((ds.Tables[0].Rows[0]["PBnet_Softshow"].ToString() == "1") || (ds.Tables[0].Rows[0]["PBnet_Softshow"].ToString().ToLower() == "true"))
                    {
                        model.PBnet_Softshow = true;
                    }
                    else
                    {
                        model.PBnet_Softshow = false;
                    }
                }
                if (ds.Tables[0].Rows[0]["icountid"].ToString() != "")
                {
                    model.icountid = int.Parse(ds.Tables[0].Rows[0]["icountid"].ToString());
                }

                model.Video = ds.Tables[0].Rows[0]["Video"].ToString();

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
            strSql.Append("select pb_SoftID,pb_ClassID,pb_SoftName,pb_SoftVersion,pb_Author,pb_AuthorEmail,pb_AuthorHomepage,pb_DemoUrl,pb_Editor,pb_Keyword,pb_Hits,pb_DayHits,pb_WeekHits,pb_MonthHits,pb_UpdateTime,pb_OperatingSystem,pb_TypeName,pb_SoftType,pb_SoftLanguage,pb_CopyrightType,pb_SoftSize,pb_RegUrl,pb_OnTop,pb_Elite,pb_Passed,pb_SoftIntro,pb_SoftPicUrl,pb_DownloadUrl1,pb_DownloadUrl2,pb_DownloadUrl3,pb_DownloadUrl4,pb_SoftLevel,pb_SoftPoint,pb_Deleted,pb_Stars,pb_DecompressPassword,pb_LastHitTime,pb_softContent,countid,pb_Softdemo,pb_illuminate,pb_indexshow,pb_freeshow,OuterHits,OuterDayHits,OuterWeekHits,OuterMonthHits,CstID,PBnet_Softshow,icountid,Video ");
            strSql.Append(" FROM PBnet_Product ");
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
            strSql.Append(" pb_SoftID,pb_ClassID,pb_SoftName,pb_SoftVersion,pb_Author,pb_AuthorEmail,pb_AuthorHomepage,pb_DemoUrl,pb_Editor,pb_Keyword,pb_Hits,pb_DayHits,pb_WeekHits,pb_MonthHits,pb_UpdateTime,pb_OperatingSystem,pb_TypeName,pb_SoftType,pb_SoftLanguage,pb_CopyrightType,pb_SoftSize,pb_RegUrl,pb_OnTop,pb_Elite,pb_Passed,pb_SoftIntro,pb_SoftPicUrl,pb_DownloadUrl1,pb_DownloadUrl2,pb_DownloadUrl3,pb_DownloadUrl4,pb_SoftLevel,pb_SoftPoint,pb_Deleted,pb_Stars,pb_DecompressPassword,pb_LastHitTime,pb_softContent,countid,pb_Softdemo,pb_illuminate,pb_indexshow,pb_freeshow,OuterHits,OuterDayHits,OuterWeekHits,OuterMonthHits,CstID,PBnet_Softshow,icountid,Video ");
            strSql.Append(" FROM PBnet_Product ");
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
            parameters[0].Value = "PBnet_Product";
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
    }
}

