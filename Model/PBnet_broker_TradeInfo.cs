using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_broker_TradeInfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_broker_TradeInfo
    {
        public PBnet_broker_TradeInfo()
        { }
        #region Model
        private int _id;
        private string _brokername;
        private string _orderid;
        private string _customername;
        private decimal? _customerpay;
        private decimal? _brokerincome;
        private DateTime? _createtime;
        private string _regmanager;
        private string _remark;
        /// <summary>
        /// 索引ID
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 经纪人BBS用户名
        /// </summary>
        public string BrokerName
        {
            set { _brokername = value; }
            get { return _brokername; }
        }
        /// <summary>
        /// 订单号ID（用于查找对应的注册信息）
        /// </summary>
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 客户名（客户：购买软件的用户）
        /// </summary>
        public string CustomerName
        {
            set { _customername = value; }
            get { return _customername; }
        }
        /// <summary>
        /// 客户支付金额（按客户折扣购买软件的金额）
        /// </summary>
        public decimal? CustomerPay
        {
            set { _customerpay = value; }
            get { return _customerpay; }
        }
        /// <summary>
        /// 经纪人应得金额（经纪人折扣）
        /// </summary>
        public decimal? BrokerIncome
        {
            set { _brokerincome = value; }
            get { return _brokerincome; }
        }
        /// <summary>
        /// 该纪录产生时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// 注册人员
        /// </summary>
        public string RegManager
        {
            set { _regmanager = value; }
            get { return _regmanager; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

