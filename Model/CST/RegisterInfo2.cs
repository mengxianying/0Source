using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类RegisterInfo2 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class RegisterInfo2
    {
        public RegisterInfo2()
        { }
        #region Model
        private int _id;
        private string _rn;
        private string _hdsn;
        private int _status;
        private int? _softwaretype;
        private int? _installtype;
        private int? _usertype;
        private int? _usetype;
        private string _operator;
        private int? _agentid;
        private string _agentname;
        private string _paytype;
        private decimal? _paymoney;
        private string _paydetails;
        private string _cardno;
        private string _cardpassword;
        private int? _timetype;
        private DateTime? _registerdate;
        private DateTime? _expiredate;
        private string _username;
        private string _usertel;
        private string _useremail;
        private string _useraddress;
        private int _updatecount;
        private DateTime? _lastupdatedate;
        private string _lastupdateversion;
        private DateTime? _dd_time;
        private DateTime? _dd_date;
        private int? _dd_count;
        private string _remarks;
        private string _bbsid;
        private string _orgsn;
        private string _oldsn;
        private int? _isreregistered;

        private int _RegisterMode;

        public int RegisterMode
        {
            get { return _RegisterMode; }
            set { _RegisterMode = value; }
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
        public string RN
        {
            set { _rn = value; }
            get { return _rn; }
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
        public int Status
        {
            set { _status = value; }
            get { return _status; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SoftwareType
        {
            set { _softwaretype = value; }
            get { return _softwaretype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? InstallType
        {
            set { _installtype = value; }
            get { return _installtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? UserType
        {
            set { _usertype = value; }
            get { return _usertype; }
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
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? AgentID
        {
            set { _agentid = value; }
            get { return _agentid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AgentName
        {
            set { _agentname = value; }
            get { return _agentname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayType
        {
            set { _paytype = value; }
            get { return _paytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? PayMoney
        {
            set { _paymoney = value; }
            get { return _paymoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayDetails
        {
            set { _paydetails = value; }
            get { return _paydetails; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CardNo
        {
            set { _cardno = value; }
            get { return _cardno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CardPassword
        {
            set { _cardpassword = value; }
            get { return _cardpassword; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TimeType
        {
            set { _timetype = value; }
            get { return _timetype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RegisterDate
        {
            set { _registerdate = value; }
            get { return _registerdate; }
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
        public string Username
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserTel
        {
            set { _usertel = value; }
            get { return _usertel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserEmail
        {
            set { _useremail = value; }
            get { return _useremail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserAddress
        {
            set { _useraddress = value; }
            get { return _useraddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int UpdateCount
        {
            set { _updatecount = value; }
            get { return _updatecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastUpdateDate
        {
            set { _lastupdatedate = value; }
            get { return _lastupdatedate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastUpdateVersion
        {
            set { _lastupdateversion = value; }
            get { return _lastupdateversion; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DD_Time
        {
            set { _dd_time = value; }
            get { return _dd_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? DD_Date
        {
            set { _dd_date = value; }
            get { return _dd_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DD_Count
        {
            set { _dd_count = value; }
            get { return _dd_count; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BBsID
        {
            set { _bbsid = value; }
            get { return _bbsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrgSN
        {
            set { _orgsn = value; }
            get { return _orgsn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OldSN
        {
            set { _oldsn = value; }
            get { return _oldsn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsReRegistered
        {
            set { _isreregistered = value; }
            get { return _isreregistered; }
        }
        #endregion Model

    }
}

