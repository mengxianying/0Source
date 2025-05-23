using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_Orders ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// �������
        /// </summary>
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// �û����
        /// </summary>
        public int UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// �û�����
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public DateTime? OrderDate
        {
            set { _orderdate = value; }
            get { return _orderdate; }
        }
        /// <summary>
        /// �ջ�������
        /// </summary>
        public string ReceiverName
        {
            set { _receivername = value; }
            get { return _receivername; }
        }
        /// <summary>
        /// �ջ��˵�ַ
        /// </summary>
        public string ReceiverAddress
        {
            set { _receiveraddress = value; }
            get { return _receiveraddress; }
        }
        /// <summary>
        /// �ջ����ʱ�
        /// </summary>
        public string ReceiverPostalCode
        {
            set { _receiverpostalcode = value; }
            get { return _receiverpostalcode; }
        }
        /// <summary>
        /// �ջ��˵绰
        /// </summary>
        public string ReceiverPhone
        {
            set { _receiverphone = value; }
            get { return _receiverphone; }
        }
        /// <summary>
        /// �ռ���Email
        /// </summary>
        public string ReceiverEmail
        {
            set { _receiveremail = value; }
            get { return _receiveremail; }
        }
        /// <summary>
        /// ��Ʒ�ܼ�
        /// </summary>
        public decimal? TotalProductPrice
        {
            set { _totalproductprice = value; }
            get { return _totalproductprice; }
        }
        /// <summary>
        /// �ʷ�
        /// </summary>
        public decimal? PortPrice
        {
            set { _portprice = value; }
            get { return _portprice; }
        }
        /// <summary>
        /// �Ѹ�����
        /// </summary>
        public decimal? HasPayedPrice
        {
            set { _haspayedprice = value; }
            get { return _haspayedprice; }
        }
        /// <summary>
        /// �ʵ����ͱ��
        /// </summary>
        public int? PortTypeID
        {
            set { _porttypeid = value; }
            get { return _porttypeid; }
        }
        /// <summary>
        /// �ʵ���������
        /// </summary>
        public string PortTypeName
        {
            set { _porttypename = value; }
            get { return _porttypename; }
        }
        /// <summary>
        /// ���ʽ���
        /// </summary>
        public int PayTypeID
        {
            set { _paytypeid = value; }
            get { return _paytypeid; }
        }
        /// <summary>
        /// ���ʽ����
        /// </summary>
        public string PayTypeName
        {
            set { _paytypename = value; }
            get { return _paytypename; }
        }
        /// <summary>
        /// ����״̬��ʾ���
        /// </summary>
        public int? TipID
        {
            set { _tipid = value; }
            get { return _tipid; }
        }
        /// <summary>
        /// ������ʾ��
        /// </summary>
        public string TipName
        {
            set { _tipname = value; }
            get { return _tipname; }
        }
        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime? UpdateStaticDate
        {
            set { _updatestaticdate = value; }
            get { return _updatestaticdate; }
        }
        /// <summary>
        /// �̻�����һ
        /// </summary>
        public string c_memo1
        {
            set { _c_memo1 = value; }
            get { return _c_memo1; }
        }
        /// <summary>
        /// �̻�������
        /// </summary>
        public string c_memo2
        {
            set { _c_memo2 = value; }
            get { return _c_memo2; }
        }
        /// <summary>
        /// �û���ע
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// �Ƿ񸶿��������ת�˺��ʾֻ��ͲƸ�ͨ�û���
        /// </summary>
        public int? IsPay
        {
            set { _ispay = value; }
            get { return _ispay; }
        }
        /// <summary>
        /// �������û���
        /// </summary>
        public string BrokerName
        {
            set { _brokername = value; }
            get { return _brokername; }
        }
        /// <summary>
        /// �Ƿ���ȡ��
        /// </summary>
        public int  IsCancel
        {
            set { _iscancel = value; }
            get { return _iscancel; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public int OrderClass
        {
            get { return _orderClass; }
            set { _orderClass = value; }
        }
        /// <summary>
        /// �û��¶���IP
        /// </summary>
        public string UserIP
        {
            set { _userip = value; }
            get { return _userip; }
        }

        #endregion Model

	}
}

