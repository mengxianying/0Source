using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类CL_RegisterInfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CL_RegisterInfo
    {
        public CL_RegisterInfo()
        {
            _sns = "";
            _operator = "";
            _paytype = "";
            _paydetails = "";
            _paytime = DateTime.Now;
            _agentname = "";
            _cardinfo = "";
            _createtime = DateTime.Now;
            _username = "";
            _useremail = "";
            _usertel = "";
            _useraddress = "";
            _remarks = "";
        }
        #region Model
        private int _id;
        private int _softwaretype;
        private int _installtype;
        private string _sns;
        private int _status;
        private string _operator;
        private string _paytype;
        private int _paymoney;
        private string _paydetails;
        private int _paystatus;
        private DateTime _paytime;
        private int _registertype;
        private string _agentname;
        private string _cardinfo;
        private DateTime _createtime;
        private string _username;
        private string _useremail;
        private string _usertel;
        private string _useraddress;
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
        public string SNs
        {
            set { _sns = value; }
            get { return _sns; }
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
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
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
        public int PayMoney
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
        public int PayStatus
        {
            set { _paystatus = value; }
            get { return _paystatus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime PayTime
        {
            set { _paytime = value; }
            get { return _paytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int RegisterType
        {
            set { _registertype = value; }
            get { return _registertype; }
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
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
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
        public string UserTel
        {
            set { _usertel = value; }
            get { return _usertel; }
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
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        #endregion Model

    }
}

