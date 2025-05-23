using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����CN_User ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class CN_User
    {
        public CN_User()
        { }
        #region Model
        private int _id;
        private string _username;
        private int _softwaretype;
        private int _installtype;
        private int _usertype;
        private DateTime? _expiredate;
        private int _validdays;
        private DateTime _createtime;
        private DateTime _lastpaytime;
        private int _usecount;
        private int _lastloginid;
        private int? _serviceid;
        private string _hdsnlist;
        private int? _statresult;
        private string _userremarks;
        private string _remarks;
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
        public int UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ExpireDate
        {
            set { _expiredate = value; }
            get { return _expiredate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ValidDays
        {
            set { _validdays = value; }
            get { return _validdays; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime LastPayTime
        {
            set { _lastpaytime = value; }
            get { return _lastpaytime; }
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
        public string HDSNList
        {
            set { _hdsnlist = value; }
            get { return _hdsnlist; }
        }
        /// <summary>
        /// �����Ϣ��-1δͳ�ƣ�����������õĲ�Ʊ��id
        /// </summary>
        public int? StatResult
        {
            set { _statresult = value; }
            get { return _statresult; }
        }
        /// <summary>
        /// �û���ע
        /// </summary>
        public string UserRemarks
        {
            set { _userremarks = value; }
            get { return _userremarks; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        #endregion Model

    }
}

