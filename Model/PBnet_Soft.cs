using System;
using System.Collections.Generic;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_Soft 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class PBnet_Soft : IComparer<Pbzx.Model.PBnet_Soft>
    {
        public PBnet_Soft()
        {
            _countid = 0;
            _pb_lasthittime = DateTime.Now;
        }
        #region Model
        private int _pbnet_softid;
        private int? _pb_classid;
        private string _pbnet_softname;
        private string _pbnet_softversion;
        private string _pb_author;
        private string _pb_authoremail;
        private string _pb_authorhomepage;
        private string _pb_demourl;
        private string _pb_editor;
        private string _pb_keyword;
        private int? _pb_hits;
        private int? _pb_dayhits;
        private int? _pb_weekhits;
        private int? _pb_monthhits;
        private DateTime? _pb_updatetime;
        private string _pb_operatingsystem;
        private int? _pbnet_softtype;
        private int? _pbnet_softlanguage;
        private int? _pb_copyrighttype;
        private int? _pbnet_softsize;
        private string _pb_regurl;
        private bool _pb_ontop;
        private bool _pb_elite;
        private bool _pb_passed;
        private string _pbnet_softintro;
        private string _pbnet_softpicurl;
        private string _pb_downloadurl1;
        private string _pb_downloadurl2;
        private string _pb_downloadurl3;
        private string _pb_downloadurl4;
        private int? _pbnet_softlevel;
        private int? _pbnet_softpoint;
        private bool _pb_deleted;
        private int? _pb_stars;
        private string _pb_decompresspassword;
        private DateTime _pb_lasthittime;
        private int _countid;
        private bool _pb_indexshow;
        private bool _pbnet_softshow;
        private int? _scountid;
        private int? _icountid;
        private int _outerhits;
        private int _outerdayhits;
        private int _outerweekhits;
        private int _outermonthhits;
        private string _video;

        /// <summary>
        /// 在线视频
        /// </summary>
        public string Video
        {
            get { return _video; }
            set { _video = value; }
        }
        /// <summary>
        /// 外部总下载量
        /// </summary>
        public int OuterHits
        {
            get { return _outerhits; }
            set { _outerhits = value; }
        }


        /// <summary>
        /// 
        /// </summary>
        public int OuterDayHits
        {
            get { return _outerdayhits; }
            set { _outerdayhits = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OuterWeekHits
        {
            get { return _outerweekhits; }
            set { _outerweekhits = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OuterMonthHits
        {
            get { return _outermonthhits; }
            set { _outermonthhits = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int PBnet_SoftID
        {
            set { _pbnet_softid = value; }
            get { return _pbnet_softid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pb_ClassID
        {
            set { _pb_classid = value; }
            get { return _pb_classid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBnet_SoftName
        {
            set { _pbnet_softname = value; }
            get { return _pbnet_softname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBnet_SoftVersion
        {
            set { _pbnet_softversion = value; }
            get { return _pbnet_softversion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_Author
        {
            set { _pb_author = value; }
            get { return _pb_author; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_AuthorEmail
        {
            set { _pb_authoremail = value; }
            get { return _pb_authoremail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_AuthorHomepage
        {
            set { _pb_authorhomepage = value; }
            get { return _pb_authorhomepage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_DemoUrl
        {
            set { _pb_demourl = value; }
            get { return _pb_demourl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_Editor
        {
            set { _pb_editor = value; }
            get { return _pb_editor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_Keyword
        {
            set { _pb_keyword = value; }
            get { return _pb_keyword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pb_Hits
        {
            set { _pb_hits = value; }
            get { return _pb_hits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pb_DayHits
        {
            set { _pb_dayhits = value; }
            get { return _pb_dayhits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pb_WeekHits
        {
            set { _pb_weekhits = value; }
            get { return _pb_weekhits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pb_MonthHits
        {
            set { _pb_monthhits = value; }
            get { return _pb_monthhits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? pb_UpdateTime
        {
            set { _pb_updatetime = value; }
            get { return _pb_updatetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_OperatingSystem
        {
            set { _pb_operatingsystem = value; }
            get { return _pb_operatingsystem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PBnet_SoftType
        {
            set { _pbnet_softtype = value; }
            get { return _pbnet_softtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PBnet_SoftLanguage
        {
            set { _pbnet_softlanguage = value; }
            get { return _pbnet_softlanguage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pb_CopyrightType
        {
            set { _pb_copyrighttype = value; }
            get { return _pb_copyrighttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PBnet_SoftSize
        {
            set { _pbnet_softsize = value; }
            get { return _pbnet_softsize; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_RegUrl
        {
            set { _pb_regurl = value; }
            get { return _pb_regurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool pb_OnTop
        {
            set { _pb_ontop = value; }
            get { return _pb_ontop; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool pb_Elite
        {
            set { _pb_elite = value; }
            get { return _pb_elite; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool pb_Passed
        {
            set { _pb_passed = value; }
            get { return _pb_passed; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBnet_SoftIntro
        {
            set { _pbnet_softintro = value; }
            get { return _pbnet_softintro; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PBnet_SoftPicUrl
        {
            set { _pbnet_softpicurl = value; }
            get { return _pbnet_softpicurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_DownloadUrl1
        {
            set { _pb_downloadurl1 = value; }
            get { return _pb_downloadurl1; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_DownloadUrl2
        {
            set { _pb_downloadurl2 = value; }
            get { return _pb_downloadurl2; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_DownloadUrl3
        {
            set { _pb_downloadurl3 = value; }
            get { return _pb_downloadurl3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_DownloadUrl4
        {
            set { _pb_downloadurl4 = value; }
            get { return _pb_downloadurl4; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PBnet_SoftLevel
        {
            set { _pbnet_softlevel = value; }
            get { return _pbnet_softlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? PBnet_SoftPoint
        {
            set { _pbnet_softpoint = value; }
            get { return _pbnet_softpoint; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool pb_Deleted
        {
            set { _pb_deleted = value; }
            get { return _pb_deleted; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pb_Stars
        {
            set { _pb_stars = value; }
            get { return _pb_stars; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_DecompressPassword
        {
            set { _pb_decompresspassword = value; }
            get { return _pb_decompresspassword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime pb_LastHitTime
        {
            set { _pb_lasthittime = value; }
            get { return _pb_lasthittime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int countid
        {
            set { _countid = value; }
            get { return _countid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool pb_indexshow
        {
            set { _pb_indexshow = value; }
            get { return _pb_indexshow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool PBnet_Softshow
        {
            set { _pbnet_softshow = value; }
            get { return _pbnet_softshow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? scountid
        {
            set { _scountid = value; }
            get { return _scountid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? icountid
        {
            set { _icountid = value; }
            get { return _icountid; }
        }
        #endregion Model


        #region IComparer<PBnet_Product> 成员
        private bool _isDesc = true;
        public bool IsDesc
        {
            get { return _isDesc; }
            set { _isDesc = value; }
        }

        public int Compare(PBnet_Soft x, PBnet_Soft y)
        {
            if (IsDesc)
            {
                return x.countid - y.countid;
            }
            else
            {
                return y.countid - x.countid;
            }
        }

        #endregion

    }
}

