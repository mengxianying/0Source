using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_broker 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_broker
    {
        public PBnet_broker()
        {
            _year_trademoney = 0;
            _year_incomemoney = 0;
            _total_trademoney = 0;
            _total_incomemoney = 0;
        }
        #region Model
        private int _id;
        private string _username;
        private DateTime? _pass_time;
        private DateTime? _lastlogin_time;
        private DateTime? _apply_time;
        private int? _state;
        private string _discount_gradename;
        private int? _discount_rate;
        private decimal? _year_trademoney;
        private decimal? _year_incomemoney;
        private decimal? _total_trademoney;
        private decimal? _total_incomemoney;
        private DateTime? _yearstart_time;
        private DateTime? _lasttrade_time;
        private string _auditing_manager;
        private string _remark;
        /// <summary>
        /// 自动增长编号
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
        /// 申请成功时间
        /// </summary>
        public DateTime? Pass_time
        {
            set { _pass_time = value; }
            get { return _pass_time; }
        }
        /// <summary>
        /// 最后登陆经纪人页面时间
        /// </summary>
        public DateTime? LastLogin_time
        {
            set { _lastlogin_time = value; }
            get { return _lastlogin_time; }
        }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? Apply_time
        {
            set { _apply_time = value; }
            get { return _apply_time; }
        }
        /// <summary>
        /// 类别，0为审核中，1为已批准，2为已锁定
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 当前折扣等级（由经纪人折扣设置决定）
        /// </summary>
        public string Discount_gradeName
        {
            set { _discount_gradename = value; }
            get { return _discount_gradename; }
        }
        /// <summary>
        /// 当前折扣值（百分比的分子，比如75表示百分之75）
        /// </summary>
        public int? Discount_rate
        {
            set { _discount_rate = value; }
            get { return _discount_rate; }
        }
        /// <summary>
        /// 本年度交易总额
        /// </summary>
        public decimal? Year_tradeMoney
        {
            set { _year_trademoney = value; }
            get { return _year_trademoney; }
        }
        /// <summary>
        /// 本年度收益总额
        /// </summary>
        public decimal? Year_incomeMoney
        {
            set { _year_incomemoney = value; }
            get { return _year_incomemoney; }
        }
        /// <summary>
        /// 总交易金额
        /// </summary>
        public decimal? Total_tradeMoney
        {
            set { _total_trademoney = value; }
            get { return _total_trademoney; }
        }
        /// <summary>
        /// 总获益金额
        /// </summary>
        public decimal? Total_incomeMoney
        {
            set { _total_incomemoney = value; }
            get { return _total_incomemoney; }
        }
        /// <summary>
        /// 本年度起始时间
        /// </summary>
        public DateTime? YearStart_time
        {
            set { _yearstart_time = value; }
            get { return _yearstart_time; }
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
        /// 审核者
        /// </summary>
        public string Auditing_Manager
        {
            set { _auditing_manager = value; }
            get { return _auditing_manager; }
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

