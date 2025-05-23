using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_OrderTradeInfo 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_OrderTradeInfo
    {
        public PBnet_OrderTradeInfo()
        {
           
        }
        #region Model
        private int _tradeid;
        private string _orderid;
        private decimal? _c_orderamount;
        private DateTime? _c_ymd;
        private string _c_transnum;
        private bool _c_succmark;
        private string _c_cause;
        private int? _c_moneytype;
        private int? _paytype;
        private string _username;
        private string _payandporttype;
        private int? _ordertype;
        private string _ordertypename;
        /// <summary>
        /// 
        /// </summary>
        public int TradeID
        {
            set { _tradeid = value; }
            get { return _tradeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 订单总金额
        /// </summary>
        public decimal? c_orderamount
        {
            set { _c_orderamount = value; }
            get { return _c_orderamount; }
        }
        /// <summary>
        /// 订单日期
        /// </summary>
        public DateTime? c_ymd
        {
            set { _c_ymd = value; }
            get { return _c_ymd; }
        }
        /// <summary>
        /// 云网支付网关提供的该笔订单的交易流水号，供日后查询、核对使用
        /// </summary>
        public string c_transnum
        {
            set { _c_transnum = value; }
            get { return _c_transnum; }
        }
        /// <summary>
        /// 交易成功标志，1-成功 0-失败
        /// </summary>
        public bool c_succmark
        {
            set { _c_succmark = value; }
            get { return _c_succmark; }
        }
        /// <summary>
        /// 如果订单支付失败，则该值代表失败原因
        /// </summary>
        public string c_cause
        {
            set { _c_cause = value; }
            get { return _c_cause; }
        }
        /// <summary>
        /// 币种（0-人民币）
        /// </summary>
        public int? c_moneytype
        {
            set { _c_moneytype = value; }
            get { return _c_moneytype; }
        }
        /// <summary>
        /// 交易种类（0:云网）
        /// </summary>
        public int? PayType
        {
            set { _paytype = value; }
            get { return _paytype; }
        }
        /// <summary>
        /// 客户姓名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 付款种类+邮递种类
        /// </summary>
        public string PayAndPortType
        {
            set { _payandporttype = value; }
            get { return _payandporttype; }
        }
        /// <summary>
        /// 订单类别
        /// </summary>
        public int? OrderType
        {
            set { _ordertype = value; }
            get { return _ordertype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OrderTypeName
        {
            set { _ordertypename = value; }
            get { return _ordertypename; }
        }
        #endregion Model


    }
}
