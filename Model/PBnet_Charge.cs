using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_Charge 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_Charge
    {
        public PBnet_Charge()
        {
            _tipID = 1;
            _tipName = "1";
            _iscancel = 0;
        }
        #region Model
        private int _id;
        private string _orderid;
        private int? _userid;
        private string _username;
        private string _realname;
        private DateTime? _orderdate;
        private decimal? _paymoney;
        private int? _paytypeid;
        private string _paytypename;
        private decimal? _haspayedprice;
        private string _paynum;
        private string _c_memo1;
        private string _c_memo2;
        private int? _type;
        private int? _state;
        private string _remark;
        private string _result;
        private int? _ispay;
        private int _iscancel;
        private DateTime? _updatestaticdate;
        private int _onlinetype;
        private string _userip;

        /// <summary>
        /// 订单是否是在线订单（0：自动，1：手工）
        /// </summary>
        public int OnlineType
        {
            set { _onlinetype = value; }
            get { return _onlinetype; }
        }

        private int _tipID;
        
        public int TipID
        {
            get { return _tipID; }
            set { _tipID = value; }
        }

        private string _tipName;

        public string TipName
        {
            get { return _tipName; }
            set { _tipName = value; }
        }

        /// <summary>
        /// 充值编号
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 订单号
        /// </summary>
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
        }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime? OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal? PayMoney
        {
            set { _paymoney = value; }
            get { return _paymoney; }
        }
        /// <summary>
        /// 付款方式编号
        /// </summary>
        public int? PayTypeID
        {
            set { _paytypeid = value; }
            get { return _paytypeid; }
        }
        /// <summary>
        /// 付款方式名称
        /// </summary>
        public string PayTypeName
        {
            set { _paytypename = value; }
            get { return _paytypename; }
        }
        /// <summary>
        /// 已付款
        /// </summary>
        public decimal? HasPayedPrice
        {
            set { _haspayedprice = value; }
            get { return _haspayedprice; }
        }
        /// <summary>
        /// 充值使用的支付方式的账号，如银行号卡或支付宝的账号
        /// </summary>
        public string PayNum
        {
            set { _paynum = value; }
            get { return _paynum; }
        }
        /// <summary>
        /// 商户参数一
        /// </summary>
        public string c_memo1
        {
            set { _c_memo1 = value; }
            get { return _c_memo1; }
        }
        /// <summary>
        /// 商户参数二
        /// </summary>
        public string c_memo2
        {
            set { _c_memo2 = value; }
            get { return _c_memo2; }
        }
        /// <summary>
        /// 类型（0:充值；1：取款）
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 状态(0:未审核，1:审核通过，2：失败)
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 用户备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 支付结果
        /// </summary>
        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }
        /// <summary>
        /// 是否付款
        /// </summary>
        public int? IsPay
        {
            set { _ispay = value; }
            get { return _ispay; }
        }
        /// <summary>
        /// 是否取消
        /// </summary>
        public int IsCancel
        {
            set { _iscancel = value; }
            get { return _iscancel; }
        }
        /// <summary>
        /// 订单更新时间
        /// </summary>
        public DateTime? UpdateStaticDate
        {
            set { _updatestaticdate = value; }
            get { return _updatestaticdate; }
        }

        /// <summary>
        /// 用户下订单IP
        /// </summary>
        public string UserIP
        {
            set { _userip = value; }
            get { return _userip; }
        }
        #endregion Model

    }
}

