using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类SoftDogInfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SoftDogInfo
    {
        public SoftDogInfo()
        { }
        #region Model
        private int _id;
        private string _sn;
        private DateTime _createtime;
        private string _creater;
        private string _oldsn;
        private int? _sellprice;
        private int _status;
        private string _remarks;
        private int? _agentid;
        private string _agentname;
        private string _seller;
        private DateTime? _selltime;
        private string _paytype;
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
        public string SN
        {
            set { _sn = value; }
            get { return _sn; }
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
        public string Creater
        {
            set { _creater = value; }
            get { return _creater; }
        }
        /// <summary>
        /// 旧的认证码，适用于补发
        /// </summary>
        public string OldSN
        {
            set { _oldsn = value; }
            get { return _oldsn; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SellPrice
        {
            set { _sellprice = value; }
            get { return _sellprice; }
        }
        /// <summary>
        /// 状态，0：未售出 1：已售出  其他都是禁用
        /// </summary>
        public int Status
        {
            set { _status = value; }
            get { return _status; }
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
        public string Seller
        {
            set { _seller = value; }
            get { return _seller; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? SellTime
        {
            set { _selltime = value; }
            get { return _selltime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PayType
        {
            set { _paytype = value; }
            get { return _paytype; }
        }
        #endregion Model

    }
}

