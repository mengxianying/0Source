using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_Charge ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// �����Ƿ������߶�����0���Զ���1���ֹ���
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
        /// ��ֵ���
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// �û����
        /// </summary>
        public int? UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// ��ʵ����
        /// </summary>
        public string RealName
        {
            set { _realname = value; }
            get { return _realname; }
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
        /// ���
        /// </summary>
        public decimal? PayMoney
        {
            set { _paymoney = value; }
            get { return _paymoney; }
        }
        /// <summary>
        /// ���ʽ���
        /// </summary>
        public int? PayTypeID
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
        /// �Ѹ���
        /// </summary>
        public decimal? HasPayedPrice
        {
            set { _haspayedprice = value; }
            get { return _haspayedprice; }
        }
        /// <summary>
        /// ��ֵʹ�õ�֧����ʽ���˺ţ������кſ���֧�������˺�
        /// </summary>
        public string PayNum
        {
            set { _paynum = value; }
            get { return _paynum; }
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
        /// ���ͣ�0:��ֵ��1��ȡ�
        /// </summary>
        public int? Type
        {
            set { _type = value; }
            get { return _type; }
        }
        /// <summary>
        /// ״̬(0:δ��ˣ�1:���ͨ����2��ʧ��)
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
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
        /// ֧�����
        /// </summary>
        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }
        /// <summary>
        /// �Ƿ񸶿�
        /// </summary>
        public int? IsPay
        {
            set { _ispay = value; }
            get { return _ispay; }
        }
        /// <summary>
        /// �Ƿ�ȡ��
        /// </summary>
        public int IsCancel
        {
            set { _iscancel = value; }
            get { return _iscancel; }
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

