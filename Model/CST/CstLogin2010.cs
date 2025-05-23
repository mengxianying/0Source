using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类CstLogin2010 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class CstLogin2010
    {
        public CstLogin2010()
        { }
        #region Model
        private int _id;
        //
        private string _hdsn;
        //
        private string _rn;
        //
        private int _softwaretype;
        //
        private int _installtype;
        //
        private string _version;
        //
        private string _osname;
        //当天登录次数
        private int _todaycount;
        //总登录次数
        private int _totalcount;
        //
        private int _status;
        //
        private int _hdsntype;
        //
        private string _lastloginip;
        private DateTime _expiredate;
        //
        private DateTime _firstlogintime;
        //
        private DateTime _lastlogintime;
        //获取普通消息和紧急消息的最后时间
        private DateTime _normalmsgtime;
        //获取网页消息的最后时间
        private DateTime _webmsgtime;
        //获取最新资讯的最后时间
        private DateTime _newsmsgtime;

        /// <summary>
        /// 用户全局ID
        /// </summary>
        private string globalID;

        public string GlobalID
        {
            get { return globalID; }
            set { globalID = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HDSN
        {
            set { _hdsn = value; }
            get { return _hdsn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RN
        {
            set { _rn = value; }
            get { return _rn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SoftwareType
        {
            set { _softwaretype = value; }
            get { return _softwaretype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int InstallType
        {
            set { _installtype = value; }
            get { return _installtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Version
        {
            set { _version = value; }
            get { return _version; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OSName
        {
            set { _osname = value; }
            get { return _osname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TodayCount
        {
            set { _todaycount = value; }
            get { return _todaycount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TotalCount
        {
            set { _totalcount = value; }
            get { return _totalcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int HDSNType
        {
            set { _hdsntype = value; }
            get { return _hdsntype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastLoginIP
        {
            set { _lastloginip = value; }
            get { return _lastloginip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ExpireDate
        {
            set { _expiredate = value; }
            get { return _expiredate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime FirstLoginTime
        {
            set { _firstlogintime = value; }
            get { return _firstlogintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastLoginTime
        {
            set { _lastlogintime = value; }
            get { return _lastlogintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime NormalMsgTime
        {
            set { _normalmsgtime = value; }
            get { return _normalmsgtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime WebMsgTime
        {
            set { _webmsgtime = value; }
            get { return _webmsgtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime NewsMsgTime
        {
            set { _newsmsgtime = value; }
            get { return _newsmsgtime; }
        }
        #endregion Model
    }
}
