using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类CN_FreeTestUser 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CN_FreeTestUser
    {
        public CN_FreeTestUser()
        { }
        #region Model
        private int _id;
        private string _hdsn;
        private string _diskcvol;
        private int _softwaretype;
        private int _installtype;
        private DateTime? _firstlogintime;
        private DateTime? _lastlogintime;
        private int _usecount;
        private int _status;
        private int _lastloginid;
        private int? _serviceid;
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
        public string DiskCVol
        {
            set { _diskcvol = value; }
            get { return _diskcvol; }
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
        public DateTime? FirstLoginTime
        {
            set { _firstlogintime = value; }
            get { return _firstlogintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastLoginTime
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
        public int? ServiceID
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

