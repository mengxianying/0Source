using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类CN_FreeTestUser2011 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class CN_FreeTestUser2011
    {
        public CN_FreeTestUser2011()
        { }
        #region Model
        private int _id;
        private string _hdsn;
        private string _globalid;
        private int _softwaretype;
        private int _installtype;
        private DateTime _firstlogintime;
        private DateTime _lastlogintime;
        private int _usecount;
        private int _status;
        private int _lastloginid;
        private int _serviceid;
        private string _lastloginip;
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
        public string GlobalID
        {
            set { _globalid = value; }
            get { return _globalid; }
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
        public int UseCount
        {
            set { _usecount = value; }
            get { return _usecount; }
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
        public int LastLoginID
        {
            set { _lastloginid = value; }
            get { return _lastloginid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ServiceID
        {
            set { _serviceid = value; }
            get { return _serviceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastLoginIP
        {
            set { _lastloginip = value; }
            get { return _lastloginip; }
        }
        #endregion Model
    }
}
