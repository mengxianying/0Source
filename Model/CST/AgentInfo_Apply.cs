using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类AgentInfo_Apply 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class AgentInfo_Apply
    {
        public AgentInfo_Apply()
        { }
        #region Model
        private int _id;
        private string _password;
        private string _name;
        private string _company;
        private string _telephone;
        private string _fax;
        private string _mobile;
        private string _email;
        private string _postcode;
        private string _province;
        private string _address;
        private DateTime? _createdate;
        private DateTime _expiredate;
        private int _type;
        private int _pricepercent;
        private int _status;
        private string _remark;
        private bool _delshow;
        private int? _countid;
        private string _agtmore;
        private string _postmore;
        private string _agttype;
        private string _username;
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
        public string Password
        {
            set { _password = value; }
            get { return _password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Company
        {
            set { _company = value; }
            get { return _company; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Telephone
        {
            set { _telephone = value; }
            get { return _telephone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Fax
        {
            set { _fax = value; }
            get { return _fax; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EMail
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
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
        public int Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PricePercent
        {
            set { _pricepercent = value; }
            get { return _pricepercent; }
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
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool delshow
        {
            set { _delshow = value; }
            get { return _delshow; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? countid
        {
            set { _countid = value; }
            get { return _countid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string agtmore
        {
            set { _agtmore = value; }
            get { return _agtmore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string postmore
        {
            set { _postmore = value; }
            get { return _postmore; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string agttype
        {
            set { _agttype = value; }
            get { return _agttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        #endregion Model

    }
}

