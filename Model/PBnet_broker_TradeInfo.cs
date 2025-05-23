using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_broker_TradeInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ����ID
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ������BBS�û���
        /// </summary>
        public string BrokerName
        {
            set { _brokername = value; }
            get { return _brokername; }
        }
        /// <summary>
        /// ������ID�����ڲ��Ҷ�Ӧ��ע����Ϣ��
        /// </summary>
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// �ͻ������ͻ�������������û���
        /// </summary>
        public string CustomerName
        {
            set { _customername = value; }
            get { return _customername; }
        }
        /// <summary>
        /// �ͻ�֧�������ͻ��ۿ۹�������Ľ�
        /// </summary>
        public decimal? CustomerPay
        {
            set { _customerpay = value; }
            get { return _customerpay; }
        }
        /// <summary>
        /// ������Ӧ�ý��������ۿۣ�
        /// </summary>
        public decimal? BrokerIncome
        {
            set { _brokerincome = value; }
            get { return _brokerincome; }
        }
        /// <summary>
        /// �ü�¼����ʱ��
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        /// <summary>
        /// ע����Ա
        /// </summary>
        public string RegManager
        {
            set { _regmanager = value; }
            get { return _regmanager; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        #endregion Model

    }
}

