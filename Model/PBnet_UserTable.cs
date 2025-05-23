using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_UserTable 。(属性说明自动提取数据库字段的描述信息)
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
        /// 索引ID
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// BBS用户名
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
        /// 交易密码
        /// </summary>
        public string TradePwd
        {
            set { _tradepwd = value; }
            get { return _tradepwd; }
        }
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string CardID
        {
            set { _cardid = value; }
            get { return _cardid; }
        }
        /// <summary>
        /// 省份
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 城市
        /// </summary>
        public string City
        {
            set { _city = value; }
            get { return _city; }
        }
        /// <summary>
        /// 邮编
        /// </summary>
        public string PostCode
        {
            set { _postcode = value; }
            get { return _postcode; }
        }
        /// <summary>
        /// 详细地址
        /// </summary>
        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }
        /// <summary>
        /// 电话
        /// </summary>
        public string Telphone
        {
            set { _telphone = value; }
            get { return _telphone; }
        }
        /// <summary>
        /// 手机
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
        /// 生日
        /// </summary>
        public DateTime? Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 性别
        /// </summary>
        public bool Sex
        {
            set { _sex = value; }
            get { return _sex; }
        }
        /// <summary>
        /// 开户银行名
        /// </summary>
        public string BankName
        {
            set { _bankname = value; }
            get { return _bankname; }
        }
        /// <summary>
        /// 开户行信息
        /// </summary>
        public string BankInfo
        {
            set { _bankinfo = value; }
            get { return _bankinfo; }
        }
        /// <summary>
        /// 银行帐号
        /// </summary>
        public string AccountNumber
        {
            set { _accountnumber = value; }
            get { return _accountnumber; }
        }
        /// <summary>
        /// 当前余额
        /// </summary>
        public decimal? CurrentMoney
        {
            set { _currentmoney = value; }
            get { return _currentmoney; }
        }
        /// <summary>
        /// 当前冻结金额
        /// </summary>
        public decimal? FrozenMoney
        {
            set { _frozenmoney = value; }
            get { return _frozenmoney; }
        }
        /// <summary>
        /// 最后交易时间
        /// </summary>
        public DateTime? LastTrade_time
        {
            set { _lasttrade_time = value; }
            get { return _lasttrade_time; }
        }
        /// <summary>
        /// 用户标识（0：未开通高级用户，1：已经升级为高级用户，2：锁定）
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreatTime
        {
            set { _creattime = value; }
            get { return _creattime; }
        }
        /// <summary>
        /// 操作（审核或锁定）时间
        /// </summary>
        public DateTime? OperateTime
        {
            set { _operatetime = value; }
            get { return _operatetime; }
        }
        /// <summary>
        /// 操作（审核或锁定）者
        /// </summary>
        public string OperateManager
        {
            set { _operatemanager = value; }
            get { return _operatemanager; }
        }
        /// <summary>
        /// 操作结果（审核未通过或者锁定时需要填写）
        /// </summary>
        public string OperateResult
        {
            set { _operateresult = value; }
            get { return _operateresult; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }
        /// <summary>
        /// Email状态(0:未验证，1：验证中，2：验证失败，3：验证通过)
        /// </summary>
        public int? EmailState
        {
            set { _emailstate = value; }
            get { return _emailstate; }
        }
        /// <summary>
        /// 银行账号状态(0:未验证，1：验证中，2：验证失败，3：验证通过)
        /// </summary>
        public int? AccountNumberState
        {
            set { _accountnumberstate = value; }
            get { return _accountnumberstate; }
        }
        /// <summary>
        /// Email验证码
        /// </summary>
        public string EmailCode
        {
            set { _emailcode = value; }
            get { return _emailcode; }
        }
        /// <summary>
        /// 银行账号验证码
        /// </summary>
        public string AccountNumberCode
        {
            set { _accountnumbercode = value; }
            get { return _accountnumbercode; }
        }
        /// <summary>
        /// Email验证时间
        /// </summary>
        public DateTime? EmailCodeTime
        {
            set { _emailcodetime = value; }
            get { return _emailcodetime; }
        }
        /// <summary>
        /// 银行账号验证时间
        /// </summary>
        public DateTime? AccountNumberCodeTime
        {
            set { _accountnumbercodetime = value; }
            get { return _accountnumbercodetime; }
        }
        /// <summary>
        /// Email验证次数
        /// </summary>
        public int? EmailCodeCount
        {
            set { _emailcodecount = value; }
            get { return _emailcodecount; }
        }
        /// <summary>
        /// 银行账号验证次数
        /// </summary>
        public int? AccountNumberCodeCount
        {
            set { _accountnumbercodecount = value; }
            get { return _accountnumbercodecount; }
        }
        #endregion Model
    }
}

