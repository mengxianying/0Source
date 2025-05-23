using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类CN_RegisterLog 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CN_RegisterLog
    {
        public CN_RegisterLog()
        { }
        #region Model
        private int _id;
        private string _bbsname;
        private int _softwaretype;
        private int _installtype;
        private int _usetype;
        private int _usevalue;
        private string _paytype;
        private decimal _paymoney;
        private int _paystatus;
        private DateTime? _paytime;
        private string _paydetails;
        private int _registertype;
        private string _operator;
        private string _agentname;
        private string _cardinfo;
        private DateTime _createtime;
        private string _username;
        private string _remarks;
        private int? _cnuserid;
        private int? _cnuserdetailsid;
        private int? _old_usertype;
        private DateTime? _old_expiredate;
        private int? _old_validdays;
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
        public string BbsName
        {
            set { _bbsname = value; }
            get { return _bbsname; }
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
        /// 使用类型，1：包月，2：计天，3：限期
        /// </summary>
        public int UseType
        {
            set { _usetype = value; }
            get { return _usetype; }
        }
        /// <summary>
        /// 使用值，如果为包月，则为月数，如果为计天，则为天数，如果为限期，则为到期日期（如20071231）
        /// </summary>
        public int UseValue
        {
            set { _usevalue = value; }
            get { return _usevalue; }
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
        public decimal PayMoney
        {
            set { _paymoney = value; }
            get { return _paymoney; }
        }
        /// <summary>
        /// 付费状态，1：未付费，2：已付费，3：免费
        /// </summary>
        public int PayStatus
        {
            set { _paystatus = value; }
            get { return _paystatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? PayTime
        {
            set { _paytime = value; }
            get { return _paytime; }
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
        /// 注册方式，1：公司注册，2：代理注册，3：充值卡注册
        /// </summary>
        public int RegisterType
        {
            set { _registertype = value; }
            get { return _registertype; }
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
        public string AgentName
        {
            set { _agentname = value; }
            get { return _agentname; }
        }
        /// <summary>
        /// 卡信息，卡号-密码
        /// </summary>
        public string CardInfo
        {
            set { _cardinfo = value; }
            get { return _cardinfo; }
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
        public string Username
        {
            set { _username = value; }
            get { return _username; }
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
        public int? CNUserID
        {
            set { _cnuserid = value; }
            get { return _cnuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CNUserDetailsID
        {
            set { _cnuserdetailsid = value; }
            get { return _cnuserdetailsid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Old_UserType
        {
            set { _old_usertype = value; }
            get { return _old_usertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Old_ExpireDate
        {
            set { _old_expiredate = value; }
            get { return _old_expiredate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Old_ValidDays
        {
            set { _old_validdays = value; }
            get { return _old_validdays; }
        }
        #endregion Model

    }
}

