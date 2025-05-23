using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_Orders 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class PBnet_Orders
	{
		public PBnet_Orders()
		{
            _orderdate = DateTime.Now;
            _updatestaticdate = DateTime.Now;
            _remark = "";
            _result = "";
            _type = 0;
            _ispay = 0;
            _brokername = "";
            _iscancel = 0;
        }
        #region Model
        private string _orderid;
        private int _userid;
        private string _username;
        private DateTime? _orderdate;
        private string _receivername;
        private string _receiveraddress;
        private string _receiverpostalcode;
        private string _receiverphone;
        private string _receiveremail;
        private decimal? _totalproductprice;
        private decimal? _portprice;
        private decimal? _haspayedprice;
        private int? _porttypeid;
        private string _porttypename;
        private int _paytypeid;
        private string _paytypename;
        private int? _tipid;
        private string _tipname;
        private DateTime? _updatestaticdate;
        private string _c_memo1;
        private string _c_memo2;
        private string _remark;
        private string _result;
        private int? _type;
        private int? _ispay;
        private string _brokername;
        private int _iscancel;

        private int _orderClass;

        private string _userip;



        /// <summary>
        /// 订单编号
        /// </summary>
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
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
        /// 收货人姓名
        /// </summary>
        public string ReceiverName
        {
            set { _receivername = value; }
            get { return _receivername; }
        }
        /// <summary>
        /// 收货人地址
        /// </summary>
        public string ReceiverAddress
        {
            set { _receiveraddress = value; }
            get { return _receiveraddress; }
        }
        /// <summary>
        /// 收货人邮编
        /// </summary>
        public string ReceiverPostalCode
        {
            set { _receiverpostalcode = value; }
            get { return _receiverpostalcode; }
        }
        /// <summary>
        /// 收货人电话
        /// </summary>
        public string ReceiverPhone
        {
            set { _receiverphone = value; }
            get { return _receiverphone; }
        }
        /// <summary>
        /// 收件人Email
        /// </summary>
        public string ReceiverEmail
        {
            set { _receiveremail = value; }
            get { return _receiveremail; }
        }
        /// <summary>
        /// 产品总价
        /// </summary>
        public decimal? TotalProductPrice
        {
            set { _totalproductprice = value; }
            get { return _totalproductprice; }
        }
        /// <summary>
        /// 邮费
        /// </summary>
        public decimal? PortPrice
        {
            set { _portprice = value; }
            get { return _portprice; }
        }
        /// <summary>
        /// 已付费用
        /// </summary>
        public decimal? HasPayedPrice
        {
            set { _haspayedprice = value; }
            get { return _haspayedprice; }
        }
        /// <summary>
        /// 邮递类型编号
        /// </summary>
        public int? PortTypeID
        {
            set { _porttypeid = value; }
            get { return _porttypeid; }
        }
        /// <summary>
        /// 邮递类型名称
        /// </summary>
        public string PortTypeName
        {
            set { _porttypename = value; }
            get { return _porttypename; }
        }
        /// <summary>
        /// 付款方式编号
        /// </summary>
        public int PayTypeID
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
        /// 订单状态提示编号
        /// </summary>
        public int? TipID
        {
            set { _tipid = value; }
            get { return _tipid; }
        }
        /// <summary>
        /// 订单提示名
        /// </summary>
        public string TipName
        {
            set { _tipname = value; }
            get { return _tipname; }
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
        /// 用户备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// 处理结果
        /// </summary>
        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }
        /// <summary>
        /// 订单类型
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// 是否付款（对于网银转账和邮局汇款和财付通用户）
        /// </summary>
        public int? IsPay
        {
            set { _ispay = value; }
            get { return _ispay; }
        }
        /// <summary>
        /// 经纪人用户名
        /// </summary>
        public string BrokerName
        {
            set { _brokername = value; }
            get { return _brokername; }
        }
        /// <summary>
        /// 是否已取消
        /// </summary>
        public int  IsCancel
        {
            set { _iscancel = value; }
            get { return _iscancel; }
        }
        /// <summary>
        /// 订单类别
        /// </summary>
        public int OrderClass
        {
            get { return _orderClass; }
            set { _orderClass = value; }
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

