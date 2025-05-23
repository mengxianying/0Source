using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Maticsoft.DBUtility;//请先添加引用
namespace Pbzx.SQLServerDAL
{
    /// <summary>
    /// 数据访问类PBnet_Soft。
    /// </summary>
    public class PBnet_Soft : IPBnet_Soft
    {
        public PBnet_Soft()
        { }
        #region  成员方法

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("PBnet_SoftID", "PBnet_Soft");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int PBnet_SoftID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from PBnet_Soft");
            strSql.Append(" where PBnet_SoftID=@PBnet_SoftID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBnet_SoftID", SqlDbType.Int,4)};
            parameters[0].Value = PBnet_SoftID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PBnet_Soft model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into PBnet_Soft(");
            strSql.Append("pb_ClassID,PBnet_SoftName,PBnet_SoftVersion,pb_Author,pb_AuthorEmail,pb_AuthorHomepage,pb_DemoUrl,pb_Editor,pb_Keyword,pb_Hits,pb_DayHits,pb_WeekHits,pb_MonthHits,pb_UpdateTime,pb_OperatingSystem,PBnet_SoftType,PBnet_SoftLanguage,pb_CopyrightType,PBnet_SoftSize,pb_RegUrl,pb_OnTop,pb_Elite,pb_Passed,PBnet_SoftIntro,PBnet_SoftPicUrl,pb_DownloadUrl1,pb_DownloadUrl2,pb_DownloadUrl3,pb_DownloadUrl4,PBnet_SoftLevel,PBnet_SoftPoint,pb_Deleted,pb_Stars,pb_DecompressPassword,pb_LastHitTime,countid,pb_indexshow,PBnet_Softshow,scountid,icountid,OuterHits,OuterDayHits,OuterWeekHits,OuterMonthHits,Video)");
            strSql.Append(" values (");
            strSql.Append("@pb_ClassID,@PBnet_SoftName,@PBnet_SoftVersion,@pb_Author,@pb_AuthorEmail,@pb_AuthorHomepage,@pb_DemoUrl,@pb_Editor,@pb_Keyword,@pb_Hits,@pb_DayHits,@pb_WeekHits,@pb_MonthHits,@pb_UpdateTime,@pb_OperatingSystem,@PBnet_SoftType,@PBnet_SoftLanguage,@pb_CopyrightType,@PBnet_SoftSize,@pb_RegUrl,@pb_OnTop,@pb_Elite,@pb_Passed,@PBnet_SoftIntro,@PBnet_SoftPicUrl,@pb_DownloadUrl1,@pb_DownloadUrl2,@pb_DownloadUrl3,@pb_DownloadUrl4,@PBnet_SoftLevel,@PBnet_SoftPoint,@pb_Deleted,@pb_Stars,@pb_DecompressPassword,@pb_LastHitTime,@countid,@pb_indexshow,@PBnet_Softshow,@scountid,@icountid,@OuterHits,@OuterDayHits,@OuterWeekHits,@OuterMonthHits,@Video)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@pb_ClassID", SqlDbType.Int,4),
					new SqlParameter("@PBnet_SoftName", SqlDbType.NVarChar,255),
					new SqlParameter("@PBnet_SoftVersion", SqlDbType.NVarChar,100),
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
					new SqlParameter("@PBnet_SoftType", SqlDbType.Int,4),
					new SqlParameter("@PBnet_SoftLanguage", SqlDbType.Int,4),
					new SqlParameter("@pb_CopyrightType", SqlDbType.Int,4),
					new SqlParameter("@PBnet_SoftSize", SqlDbType.Int,4),
					new SqlParameter("@pb_RegUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@pb_OnTop", SqlDbType.Bit,1),
					new SqlParameter("@pb_Elite", SqlDbType.Bit,1),
					new SqlParameter("@pb_Passed", SqlDbType.Bit,1),
					new SqlParameter("@PBnet_SoftIntro", SqlDbType.NText),
					new SqlParameter("@PBnet_SoftPicUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl1", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl2", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl3", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl4", SqlDbType.NVarChar,255),
					new SqlParameter("@PBnet_SoftLevel", SqlDbType.Int,4),
					new SqlParameter("@PBnet_SoftPoint", SqlDbType.Int,4),
					new SqlParameter("@pb_Deleted", SqlDbType.Bit,1),
					new SqlParameter("@pb_Stars", SqlDbType.Int,4),
					new SqlParameter("@pb_DecompressPassword", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_LastHitTime", SqlDbType.SmallDateTime),
					new SqlParameter("@countid", SqlDbType.Int,4),
					new SqlParameter("@pb_indexshow", SqlDbType.Bit,1),
					new SqlParameter("@PBnet_Softshow", SqlDbType.Bit,1),
					new SqlParameter("@scountid", SqlDbType.Int,4),
					new SqlParameter("@icountid", SqlDbType.Int,4),
					new SqlParameter("@OuterHits", SqlDbType.Int,4),
					new SqlParameter("@OuterDayHits", SqlDbType.Int,4),
					new SqlParameter("@OuterWeekHits", SqlDbType.Int,4),
					new SqlParameter("@OuterMonthHits", SqlDbType.Int,4),
                    new SqlParameter("@Video",SqlDbType.Text)
            };
            parameters[0].Value = model.pb_ClassID;
            parameters[1].Value = model.PBnet_SoftName;
            parameters[2].Value = model.PBnet_SoftVersion;
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
            parameters[15].Value = model.PBnet_SoftType;
            parameters[16].Value = model.PBnet_SoftLanguage;
            parameters[17].Value = model.pb_CopyrightType;
            parameters[18].Value = model.PBnet_SoftSize;
            parameters[19].Value = model.pb_RegUrl;
            parameters[20].Value = model.pb_OnTop;
            parameters[21].Value = model.pb_Elite;
            parameters[22].Value = model.pb_Passed;
            parameters[23].Value = model.PBnet_SoftIntro;
            parameters[24].Value = model.PBnet_SoftPicUrl;
            parameters[25].Value = model.pb_DownloadUrl1;
            parameters[26].Value = model.pb_DownloadUrl2;
            parameters[27].Value = model.pb_DownloadUrl3;
            parameters[28].Value = model.pb_DownloadUrl4;
            parameters[29].Value = model.PBnet_SoftLevel;
            parameters[30].Value = model.PBnet_SoftPoint;
            parameters[31].Value = model.pb_Deleted;
            parameters[32].Value = model.pb_Stars;
            parameters[33].Value = model.pb_DecompressPassword;
            parameters[34].Value = model.pb_LastHitTime;
            parameters[35].Value = model.countid;
            parameters[36].Value = model.pb_indexshow;
            parameters[37].Value = model.PBnet_Softshow;
            parameters[38].Value = model.scountid;
            parameters[39].Value = model.icountid;
            parameters[40].Value = model.OuterHits;
            parameters[41].Value = model.OuterDayHits;
            parameters[42].Value = model.OuterWeekHits;
            parameters[43].Value = model.OuterMonthHits;
            parameters[44].Value = model.Video;

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
        public int Update(Pbzx.Model.PBnet_Soft model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update PBnet_Soft set ");
            strSql.Append("pb_ClassID=@pb_ClassID,");
            strSql.Append("PBnet_SoftName=@PBnet_SoftName,");
            strSql.Append("PBnet_SoftVersion=@PBnet_SoftVersion,");
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
            strSql.Append("PBnet_SoftType=@PBnet_SoftType,");
            strSql.Append("PBnet_SoftLanguage=@PBnet_SoftLanguage,");
            strSql.Append("pb_CopyrightType=@pb_CopyrightType,");
            strSql.Append("PBnet_SoftSize=@PBnet_SoftSize,");
            strSql.Append("pb_RegUrl=@pb_RegUrl,");
            strSql.Append("pb_OnTop=@pb_OnTop,");
            strSql.Append("pb_Elite=@pb_Elite,");
            strSql.Append("pb_Passed=@pb_Passed,");
            strSql.Append("PBnet_SoftIntro=@PBnet_SoftIntro,");
            strSql.Append("PBnet_SoftPicUrl=@PBnet_SoftPicUrl,");
            strSql.Append("pb_DownloadUrl1=@pb_DownloadUrl1,");
            strSql.Append("pb_DownloadUrl2=@pb_DownloadUrl2,");
            strSql.Append("pb_DownloadUrl3=@pb_DownloadUrl3,");
            strSql.Append("pb_DownloadUrl4=@pb_DownloadUrl4,");
            strSql.Append("PBnet_SoftLevel=@PBnet_SoftLevel,");
            strSql.Append("PBnet_SoftPoint=@PBnet_SoftPoint,");
            strSql.Append("pb_Deleted=@pb_Deleted,");
            strSql.Append("pb_Stars=@pb_Stars,");
            strSql.Append("pb_DecompressPassword=@pb_DecompressPassword,");
            strSql.Append("pb_LastHitTime=@pb_LastHitTime,");
            strSql.Append("countid=@countid,");
            strSql.Append("pb_indexshow=@pb_indexshow,");
            strSql.Append("PBnet_Softshow=@PBnet_Softshow,");
            strSql.Append("scountid=@scountid,");
            strSql.Append("icountid=@icountid,");
            strSql.Append("OuterHits=@OuterHits,");
            strSql.Append("OuterDayHits=@OuterDayHits,");
            strSql.Append("OuterWeekHits=@OuterWeekHits,");
            strSql.Append("OuterMonthHits=@OuterMonthHits,");
            strSql.Append("Video=@Video");
            strSql.Append(" where PBnet_SoftID=@PBnet_SoftID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBnet_SoftID", SqlDbType.Int,4),
					new SqlParameter("@pb_ClassID", SqlDbType.Int,4),
					new SqlParameter("@PBnet_SoftName", SqlDbType.NVarChar,255),
					new SqlParameter("@PBnet_SoftVersion", SqlDbType.NVarChar,100),
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
					new SqlParameter("@PBnet_SoftType", SqlDbType.Int,4),
					new SqlParameter("@PBnet_SoftLanguage", SqlDbType.Int,4),
					new SqlParameter("@pb_CopyrightType", SqlDbType.Int,4),
					new SqlParameter("@PBnet_SoftSize", SqlDbType.Int,4),
					new SqlParameter("@pb_RegUrl", SqlDbType.NVarChar,200),
					new SqlParameter("@pb_OnTop", SqlDbType.Bit,1),
					new SqlParameter("@pb_Elite", SqlDbType.Bit,1),
					new SqlParameter("@pb_Passed", SqlDbType.Bit,1),
					new SqlParameter("@PBnet_SoftIntro", SqlDbType.NText),
					new SqlParameter("@PBnet_SoftPicUrl", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl1", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl2", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl3", SqlDbType.NVarChar,255),
					new SqlParameter("@pb_DownloadUrl4", SqlDbType.NVarChar,255),
					new SqlParameter("@PBnet_SoftLevel", SqlDbType.Int,4),
					new SqlParameter("@PBnet_SoftPoint", SqlDbType.Int,4),
					new SqlParameter("@pb_Deleted", SqlDbType.Bit,1),
					new SqlParameter("@pb_Stars", SqlDbType.Int,4),
					new SqlParameter("@pb_DecompressPassword", SqlDbType.NVarChar,50),
					new SqlParameter("@pb_LastHitTime", SqlDbType.SmallDateTime),
					new SqlParameter("@countid", SqlDbType.Int,4),
					new SqlParameter("@pb_indexshow", SqlDbType.Bit,1),
					new SqlParameter("@PBnet_Softshow", SqlDbType.Bit,1),
					new SqlParameter("@scountid", SqlDbType.Int,4),
					new SqlParameter("@icountid", SqlDbType.Int,4),
					new SqlParameter("@OuterHits", SqlDbType.Int,4),
					new SqlParameter("@OuterDayHits", SqlDbType.Int,4),
					new SqlParameter("@OuterWeekHits", SqlDbType.Int,4),
					new SqlParameter("@OuterMonthHits", SqlDbType.Int,4),
                    new SqlParameter("@Video",SqlDbType.Text)};
            parameters[0].Value = model.PBnet_SoftID;
            parameters[1].Value = model.pb_ClassID;
            parameters[2].Value = model.PBnet_SoftName;
            parameters[3].Value = model.PBnet_SoftVersion;
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
            parameters[16].Value = model.PBnet_SoftType;
            parameters[17].Value = model.PBnet_SoftLanguage;
            parameters[18].Value = model.pb_CopyrightType;
            parameters[19].Value = model.PBnet_SoftSize;
            parameters[20].Value = model.pb_RegUrl;
            parameters[21].Value = model.pb_OnTop;
            parameters[22].Value = model.pb_Elite;
            parameters[23].Value = model.pb_Passed;
            parameters[24].Value = model.PBnet_SoftIntro;
            parameters[25].Value = model.PBnet_SoftPicUrl;
            parameters[26].Value = model.pb_DownloadUrl1;
            parameters[27].Value = model.pb_DownloadUrl2;
            parameters[28].Value = model.pb_DownloadUrl3;
            parameters[29].Value = model.pb_DownloadUrl4;
            parameters[30].Value = model.PBnet_SoftLevel;
            parameters[31].Value = model.PBnet_SoftPoint;
            parameters[32].Value = model.pb_Deleted;
            parameters[33].Value = model.pb_Stars;
            parameters[34].Value = model.pb_DecompressPassword;
            parameters[35].Value = model.pb_LastHitTime;
            parameters[36].Value = model.countid;
            parameters[37].Value = model.pb_indexshow;
            parameters[38].Value = model.PBnet_Softshow;
            parameters[39].Value = model.scountid;
            parameters[40].Value = model.icountid;
            parameters[41].Value = model.OuterHits;
            parameters[42].Value = model.OuterDayHits;
            parameters[43].Value = model.OuterWeekHits;
            parameters[44].Value = model.OuterMonthHits;
            parameters[45].Value = model.Video;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int PBnet_SoftID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from PBnet_Soft ");
            strSql.Append(" where PBnet_SoftID=@PBnet_SoftID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBnet_SoftID", SqlDbType.Int,4)};
            parameters[0].Value = PBnet_SoftID;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_Soft GetModel(int PBnet_SoftID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 PBnet_SoftID,pb_ClassID,PBnet_SoftName,PBnet_SoftVersion,pb_Author,pb_AuthorEmail,pb_AuthorHomepage,pb_DemoUrl,pb_Editor,pb_Keyword,pb_Hits,pb_DayHits,pb_WeekHits,pb_MonthHits,pb_UpdateTime,pb_OperatingSystem,PBnet_SoftType,PBnet_SoftLanguage,pb_CopyrightType,PBnet_SoftSize,pb_RegUrl,pb_OnTop,pb_Elite,pb_Passed,PBnet_SoftIntro,PBnet_SoftPicUrl,pb_DownloadUrl1,pb_DownloadUrl2,pb_DownloadUrl3,pb_DownloadUrl4,PBnet_SoftLevel,PBnet_SoftPoint,pb_Deleted,pb_Stars,pb_DecompressPassword,pb_LastHitTime,countid,pb_indexshow,PBnet_Softshow,scountid,icountid,OuterHits,OuterDayHits,OuterWeekHits,OuterMonthHits,Video from PBnet_Soft ");
            strSql.Append(" where PBnet_SoftID=@PBnet_SoftID ");
            SqlParameter[] parameters = {
					new SqlParameter("@PBnet_SoftID", SqlDbType.Int,4)};
            parameters[0].Value = PBnet_SoftID;

            Pbzx.Model.PBnet_Soft model = new Pbzx.Model.PBnet_Soft();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["PBnet_SoftID"].ToString() != "")
                {
                    model.PBnet_SoftID = int.Parse(ds.Tables[0].Rows[0]["PBnet_SoftID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_ClassID"].ToString() != "")
                {
                    model.pb_ClassID = int.Parse(ds.Tables[0].Rows[0]["pb_ClassID"].ToString());
                }
                model.PBnet_SoftName = ds.Tables[0].Rows[0]["PBnet_SoftName"].ToString();
                model.PBnet_SoftVersion = ds.Tables[0].Rows[0]["PBnet_SoftVersion"].ToString();
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
                if (ds.Tables[0].Rows[0]["PBnet_SoftType"].ToString() != "")
                {
                    model.PBnet_SoftType = int.Parse(ds.Tables[0].Rows[0]["PBnet_SoftType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBnet_SoftLanguage"].ToString() != "")
                {
                    model.PBnet_SoftLanguage = int.Parse(ds.Tables[0].Rows[0]["PBnet_SoftLanguage"].ToString());
                }
                if (ds.Tables[0].Rows[0]["pb_CopyrightType"].ToString() != "")
                {
                    model.pb_CopyrightType = int.Parse(ds.Tables[0].Rows[0]["pb_CopyrightType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBnet_SoftSize"].ToString() != "")
                {
                    model.PBnet_SoftSize = int.Parse(ds.Tables[0].Rows[0]["PBnet_SoftSize"].ToString());
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
                model.PBnet_SoftIntro = ds.Tables[0].Rows[0]["PBnet_SoftIntro"].ToString();
                model.PBnet_SoftPicUrl = ds.Tables[0].Rows[0]["PBnet_SoftPicUrl"].ToString();
                model.pb_DownloadUrl1 = ds.Tables[0].Rows[0]["pb_DownloadUrl1"].ToString();
                model.pb_DownloadUrl2 = ds.Tables[0].Rows[0]["pb_DownloadUrl2"].ToString();
                model.pb_DownloadUrl3 = ds.Tables[0].Rows[0]["pb_DownloadUrl3"].ToString();
                model.pb_DownloadUrl4 = ds.Tables[0].Rows[0]["pb_DownloadUrl4"].ToString();
                if (ds.Tables[0].Rows[0]["PBnet_SoftLevel"].ToString() != "")
                {
                    model.PBnet_SoftLevel = int.Parse(ds.Tables[0].Rows[0]["PBnet_SoftLevel"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PBnet_SoftPoint"].ToString() != "")
                {
                    model.PBnet_SoftPoint = int.Parse(ds.Tables[0].Rows[0]["PBnet_SoftPoint"].ToString());
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
                if (ds.Tables[0].Rows[0]["countid"].ToString() != "")
                {
                    model.countid = int.Parse(ds.Tables[0].Rows[0]["countid"].ToString());
                }
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
                if (ds.Tables[0].Rows[0]["scountid"].ToString() != "")
                {
                    model.scountid = int.Parse(ds.Tables[0].Rows[0]["scountid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["icountid"].ToString() != "")
                {
                    model.icountid = int.Parse(ds.Tables[0].Rows[0]["icountid"].ToString());
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
            strSql.Append("select PBnet_SoftID,pb_ClassID,PBnet_SoftName,PBnet_SoftVersion,pb_Author,pb_AuthorEmail,pb_AuthorHomepage,pb_DemoUrl,pb_Editor,pb_Keyword,pb_Hits,pb_DayHits,pb_WeekHits,pb_MonthHits,pb_UpdateTime,pb_OperatingSystem,PBnet_SoftType,PBnet_SoftLanguage,pb_CopyrightType,PBnet_SoftSize,pb_RegUrl,pb_OnTop,pb_Elite,pb_Passed,PBnet_SoftIntro,PBnet_SoftPicUrl,pb_DownloadUrl1,pb_DownloadUrl2,pb_DownloadUrl3,pb_DownloadUrl4,PBnet_SoftLevel,PBnet_SoftPoint,pb_Deleted,pb_Stars,pb_DecompressPassword,pb_LastHitTime,countid,pb_indexshow,PBnet_Softshow,scountid,icountid,OuterHits,OuterDayHits,OuterWeekHits,OuterMonthHits,Video ");
            strSql.Append(" FROM PBnet_Soft ");
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
            strSql.Append(" PBnet_SoftID,pb_ClassID,PBnet_SoftName,PBnet_SoftVersion,pb_Author,pb_AuthorEmail,pb_AuthorHomepage,pb_DemoUrl,pb_Editor,pb_Keyword,pb_Hits,pb_DayHits,pb_WeekHits,pb_MonthHits,pb_UpdateTime,pb_OperatingSystem,PBnet_SoftType,PBnet_SoftLanguage,pb_CopyrightType,PBnet_SoftSize,pb_RegUrl,pb_OnTop,pb_Elite,pb_Passed,PBnet_SoftIntro,PBnet_SoftPicUrl,pb_DownloadUrl1,pb_DownloadUrl2,pb_DownloadUrl3,pb_DownloadUrl4,PBnet_SoftLevel,PBnet_SoftPoint,pb_Deleted,pb_Stars,pb_DecompressPassword,pb_LastHitTime,countid,pb_indexshow,PBnet_Softshow,scountid,icountid,OuterHits,OuterDayHits,OuterWeekHits,OuterMonthHits,Video ");
            strSql.Append(" FROM PBnet_Soft ");
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
            parameters[0].Value = "PBnet_Soft";
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


        public int ExecuteBySql(string sql)
        {
            return DbHelperSQL.ExecuteSql(sql);
        }
    }
}

