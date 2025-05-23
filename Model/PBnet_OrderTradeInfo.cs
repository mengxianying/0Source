using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_OrderTradeInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// �����ܽ��
        /// </summary>
        public decimal? c_orderamount
        {
            set { _c_orderamount = value; }
            get { return _c_orderamount; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? c_ymd
        {
            set { _c_ymd = value; }
            get { return _c_ymd; }
        }
        /// <summary>
        /// ����֧�������ṩ�ĸñʶ����Ľ�����ˮ�ţ����պ��ѯ���˶�ʹ��
        /// </summary>
        public string c_transnum
        {
            set { _c_transnum = value; }
            get { return _c_transnum; }
        }
        /// <summary>
        /// ���׳ɹ���־��1-�ɹ� 0-ʧ��
        /// </summary>
        public bool c_succmark
        {
            set { _c_succmark = value; }
            get { return _c_succmark; }
        }
        /// <summary>
        /// �������֧��ʧ�ܣ����ֵ����ʧ��ԭ��
        /// </summary>
        public string c_cause
        {
            set { _c_cause = value; }
            get { return _c_cause; }
        }
        /// <summary>
        /// ���֣�0-����ң�
        /// </summary>
        public int? c_moneytype
        {
            set { _c_moneytype = value; }
            get { return _c_moneytype; }
        }
        /// <summary>
        /// �������ࣨ0:������
        /// </summary>
        public int? PayType
        {
            set { _paytype = value; }
            get { return _paytype; }
        }
        /// <summary>
        /// �ͻ�����
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// ��������+�ʵ�����
        /// </summary>
        public string PayAndPortType
        {
            set { _payandporttype = value; }
            get { return _payandporttype; }
        }
        /// <summary>
        /// �������
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
