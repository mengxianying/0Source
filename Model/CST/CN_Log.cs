using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类CN_Log 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CN_Log
    {
        public CN_Log()
        { }
        #region Model
        private int _id;
        private string _username;
        private int _softwaretype;
        private int _installtype;
        private string _programver;
        private string _hdsn;
        private string _rn;
        private string _ip;
        private int _port;
        private DateTime _starttime;
        private DateTime _endtime;
        private int _loginmutex;
        private int _status;
        private int _serviceid;
        private int? _userindex;
        private int? _usetype;
        private int? _usevalue;
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
        public string Username
        {
            set { _username = value; }
            get { return _username; }
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
        public string ProgramVer
        {
            set { _programver = value; }
            get { return _programver; }
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
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Port
        {
            set { _port = value; }
            get { return _port; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LoginMutex
        {
            set { _loginmutex = value; }
            get { return _loginmutex; }
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
        public int ServiceID
        {
            set { _serviceid = value; }
            get { return _serviceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UserIndex
        {
            set { _userindex = value; }
            get { return _userindex; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UseType
        {
            set { _usetype = value; }
            get { return _usetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UseValue
        {
            set { _usevalue = value; }
            get { return _usevalue; }
        }
        #endregion Model

    }
}

