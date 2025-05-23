using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_UserTable ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_UserTable
    {
        public PBnet_UserTable()
        {
            _sex = true;
            _currentmoney = 0;
            _frozenmoney = 0;
            _state = 0;
            _creattime = DateTime.Now;
            _operatetime = DateTime.Now;
            _emailstate = 0;
            _accountnumberstate = 0;
            _emailcodecount = 0;
            _accountnumbercodecount = 0;
            _emailcodetime = DateTime.Now;
            _accountnumbercodetime = DateTime.Now;
        }
        #region Model
        private int _id;
        private string _username;
        private string _realname;
        private string _tradepwd;
        private string _cardid;
        private string _province;
        private string _city;
        private string _postcode;
        private string _address;
        private string _telphone;
        private string _mobile;
        private string _email;
        private string _qq;
        private string _msn;
        private DateTime? _birthday;
        private bool _sex;
        private string _bankname;
        private string _bankinfo;
        private string _accountnumber;
        private decimal? _currentmoney;
        private decimal? _frozenmoney;
        private DateTime? _lasttrade_time;
        private int? _state;
        private DateTime? _creattime;
        private DateTime? _operatetime;
        private string _operatemanager;
        private string _operateresult;
        private string _remark;
        private int? _emailstate;
        private int? _accountnumberstate;
        private string _emailcode;
        private string _accountnumbercode;
        private DateTime? _emailcodetime;
        private DateTime? _accountnumbercodetime;
        private int? _emailcodecount;
        private int? _accountnumbercodecount;
        /// <summary>
        /// ����ID
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// BBS�û���
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
        public string TradePwd
        {
            set { _tradepwd = value; }
            get { return _tradepwd; }
        }
        /// <summary>
        /// ���֤����
        /// </summary>
        public string CardID
        {
            set { _cardid = value; }
            get { return _cardid; }
        }
        /// <summary>
        /// ʡ��
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// �ʱ�
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// ��ϸ��ַ
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// �绰
        /// </summary>
        public string Telphone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// �ֻ�
        /// </summary>
        public string Mobile
        {
            set { _mobile = value; }
            get { return _mobile; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Email
        {
            set { _email = value; }
            get { return _email; }
        }
        /// <summary>
        /// qq
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// msn
        /// </summary>
        public string MSN
        {
            set { _msn = value; }
            get { return _msn; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public DateTime? Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// �Ա�
        /// </summary>
        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// ����������
        /// </summary>
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// ��������Ϣ
        /// </summary>
        public string BankInfo
        {
            set { _bankinfo = value; }
            get { return _bankinfo; }
        }
        /// <summary>
        /// �����ʺ�
        /// </summary>
        public string AccountNumber
        {
            set { _accountnumber = value; }
            get { return _accountnumber; }
        }
        /// <summary>
        /// ��ǰ���
        /// </summary>
        public decimal? CurrentMoney
        {
            set { _currentmoney = value; }
            get { return _currentmoney; }
        }
        /// <summary>
        /// ��ǰ������
        /// </summary>
        public decimal? FrozenMoney
        {
            set { _frozenmoney = value; }
            get { return _frozenmoney; }
        }
        /// <summary>
        /// �����ʱ��
        /// </summary>
        public DateTime? LastTrade_time
        {
            set { _lasttrade_time = value; }
            get { return _lasttrade_time; }
        }
        /// <summary>
        /// �û���ʶ��0��δ��ͨ�߼��û���1���Ѿ�����Ϊ�߼��û���2��������
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? CreatTime
        {
            set { _creattime = value; }
            get { return _creattime; }
        }
        /// <summary>
        /// ��������˻�������ʱ��
        /// </summary>
        public DateTime? OperateTime
        {
            set { _operatetime = value; }
            get { return _operatetime; }
        }
        /// <summary>
        /// ��������˻���������
        /// </summary>
        public string OperateManager
        {
            set { _operatemanager = value; }
            get { return _operatemanager; }
        }
        /// <summary>
        /// ������������δͨ����������ʱ��Ҫ��д��
        /// </summary>
        public string OperateResult
        {
            set { _operateresult = value; }
            get { return _operateresult; }
        }
        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// Email״̬(0:δ��֤��1����֤�У�2����֤ʧ�ܣ�3����֤ͨ��)
        /// </summary>
        public int? EmailState
        {
            set { _emailstate = value; }
            get { return _emailstate; }
        }
        /// <summary>
        /// �����˺�״̬(0:δ��֤��1����֤�У�2����֤ʧ�ܣ�3����֤ͨ��)
        /// </summary>
        public int? AccountNumberState
        {
            set { _accountnumberstate = value; }
            get { return _accountnumberstate; }
        }
        /// <summary>
        /// Email��֤��
        /// </summary>
        public string EmailCode
        {
            set { _emailcode = value; }
            get { return _emailcode; }
        }
        /// <summary>
        /// �����˺���֤��
        /// </summary>
        public string AccountNumberCode
        {
            set { _accountnumbercode = value; }
            get { return _accountnumbercode; }
        }
        /// <summary>
        /// Email��֤ʱ��
        /// </summary>
        public DateTime? EmailCodeTime
        {
            set { _emailcodetime = value; }
            get { return _emailcodetime; }
        }
        /// <summary>
        /// �����˺���֤ʱ��
        /// </summary>
        public DateTime? AccountNumberCodeTime
        {
            set { _accountnumbercodetime = value; }
            get { return _accountnumbercodetime; }
        }
        /// <summary>
        /// Email��֤����
        /// </summary>
        public int? EmailCodeCount
        {
            set { _emailcodecount = value; }
            get { return _emailcodecount; }
        }
        /// <summary>
        /// �����˺���֤����
        /// </summary>
        public int? AccountNumberCodeCount
        {
            set { _accountnumbercodecount = value; }
            get { return _accountnumbercodecount; }
        }
        #endregion Model
    }
}

