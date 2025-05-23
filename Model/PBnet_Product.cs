using System;
using System.Collections;
using System.Collections.Generic;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_Product 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    public class PBnet_Product : IComparer<Pbzx.Model.PBnet_Product>
    {
        public PBnet_Product()
        {
            _pb_lasthittime = DateTime.Now;  
        }
        #region Model
        private int _pb_softid;
        private int? _pb_classid;
        private string _pb_softname;
        private string _pb_softversion;
        private string _pb_author;
        private string _pb_authoremail;
        private string _pb_authorhomepage;
        private string _pb_demourl;
        private string _pb_editor;
        private string _pb_keyword;
        private int _pb_hits;
        private int _pb_dayhits;
        private int _pb_weekhits;
        private int _pb_monthhits;
        private DateTime _pb_updatetime;
        private string _pb_operatingsystem;
        private string _pb_typename;
        private int _pb_softtype;
        private int _pb_softlanguage;
        private int _pb_copyrighttype;
        private int _pb_softsize;
        private string _pb_regurl;
        private bool _pb_ontop;
        private bool _pb_elite;
        private bool _pb_passed;
        private string _pb_softintro;
        private string _pb_softpicurl;
        private string _pb_downloadurl1;
        private string _pb_downloadurl2;
        private string _pb_downloadurl3;
        private string _pb_downloadurl4;
        private int _pb_softlevel;
        private int _pb_softpoint;
        private bool _pb_deleted;
        private int _pb_stars;
        private string _pb_decompresspassword;
        private DateTime _pb_lasthittime;
        private string _pb_softcontent;
        private int _countid;
        private string _pb_softdemo;
        private string _pb_illuminate;
        private bool _pb_indexshow;
        private bool _pb_freeshow;
        private int _outerhits;
        private int _outerdayhits;
        private int _outerweekhits;
        private int _outermonthhits;
        private int _cstid;
        private bool _pbnet_softshow;
        private string _video;

        public string Video
        {
            get { return _video; }
            set { _video = value; }
        }


        private int _icountid = 0;
        /// <summary>
        /// 
        /// </summary>
        public int icountid
        {
            set { _icountid = value; }
            get { return _icountid; }
        }


 
        /// <summary>
        /// 
        /// </summary>
        public int pb_SoftID
        {
            set { _pb_softid = value; }
            get { return _pb_softid; }
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
        public string pb_SoftName
        {
            set { _pb_softname = value; }
            get { return _pb_softname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_SoftVersion
        {
            set { _pb_softversion = value; }
            get { return _pb_softversion; }
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
        /// 年价格
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
        public int pb_Hits
        {
            set { _pb_hits = value; }
            get { return _pb_hits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pb_DayHits
        {
            set { _pb_dayhits = value; }
            get { return _pb_dayhits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pb_WeekHits
        {
            set { _pb_weekhits = value; }
            get { return _pb_weekhits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pb_MonthHits
        {
            set { _pb_monthhits = value; }
            get { return _pb_monthhits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime pb_UpdateTime
        {
            set { _pb_updatetime = value; }
            get { return _pb_updatetime; }
        }
        /// <summary>
        /// 软件版本类别
        /// </summary>
        public string pb_OperatingSystem
        {
            set { _pb_operatingsystem = value; }
            get { return _pb_operatingsystem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_TypeName
        {
            set { _pb_typename = value; }
            get { return _pb_typename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pb_SoftType
        {
            set { _pb_softtype = value; }
            get { return _pb_softtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pb_SoftLanguage
        {
            set { _pb_softlanguage = value; }
            get { return _pb_softlanguage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pb_CopyrightType
        {
            set { _pb_copyrighttype = value; }
            get { return _pb_copyrighttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pb_SoftSize
        {
            set { _pb_softsize = value; }
            get { return _pb_softsize; }
        }
        /// <summary>
        /// 终身价格
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
        public string pb_SoftIntro
        {
            set { _pb_softintro = value; }
            get { return _pb_softintro; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_SoftPicUrl
        {
            set { _pb_softpicurl = value; }
            get { return _pb_softpicurl; }
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
        public int pb_SoftLevel
        {
            set { _pb_softlevel = value; }
            get { return _pb_softlevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int pb_SoftPoint
        {
            set { _pb_softpoint = value; }
            get { return _pb_softpoint; }
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
        public int pb_Stars
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
        public string pb_softContent
        {
            set { _pb_softcontent = value; }
            get { return _pb_softcontent; }
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
        public string pb_Softdemo
        {
            set { _pb_softdemo = value; }
            get { return _pb_softdemo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string pb_illuminate
        {
            set { _pb_illuminate = value; }
            get { return _pb_illuminate; }
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
        public bool pb_freeshow
        {
            set { _pb_freeshow = value; }
            get { return _pb_freeshow; }
        }
        /// <summary>
        /// 外部总下载
        /// </summary>
        public int OuterHits
        {
            set { _outerhits = value; }
            get { return _outerhits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OuterDayHits
        {
            set { _outerdayhits = value; }
            get { return _outerdayhits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OuterWeekHits
        {
            set { _outerweekhits = value; }
            get { return _outerweekhits; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int OuterMonthHits
        {
            set { _outermonthhits = value; }
            get { return _outermonthhits; }
        }
        /// <summary>
        /// 软件编号
        /// </summary>
        public int CstID
        {
            set { _cstid = value; }
            get { return _cstid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool PBnet_Softshow
        {
            set { _pbnet_softshow = value; }
            get { return _pbnet_softshow; }
        }
        #endregion Model



        private bool _isDesc = true;
        public bool IsDesc
        {
            get { return _isDesc; }
            set { _isDesc = value; }
        }

        #region IComparer<PBnet_Product> 成员

        public int Compare(PBnet_Product x, PBnet_Product y)
        {
            if (IsDesc)
            {
                return (int)x.countid - (int)y.countid;
            }
            else
            {
                return (int)y.countid - (int)x.countid;
            }
        }

        #endregion
    }
}

