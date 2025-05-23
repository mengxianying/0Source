using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_broker ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// �Զ��������
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
        /// ����ɹ�ʱ��
        /// </summary>
        public DateTime? Pass_time
        {
            set { _pass_time = value; }
            get { return _pass_time; }
        }
        /// <summary>
        /// ����½������ҳ��ʱ��
        /// </summary>
        public DateTime? LastLogin_time
        {
            set { _lastlogin_time = value; }
            get { return _lastlogin_time; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? Apply_time
        {
            set { _apply_time = value; }
            get { return _apply_time; }
        }
        /// <summary>
        /// ���0Ϊ����У�1Ϊ����׼��2Ϊ������
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// ��ǰ�ۿ۵ȼ����ɾ������ۿ����þ�����
        /// </summary>
        public string Discount_gradeName
        {
            set { _discount_gradename = value; }
            get { return _discount_gradename; }
        }
        /// <summary>
        /// ��ǰ�ۿ�ֵ���ٷֱȵķ��ӣ�����75��ʾ�ٷ�֮75��
        /// </summary>
        public int? Discount_rate
        {
            set { _discount_rate = value; }
            get { return _discount_rate; }
        }
        /// <summary>
        /// ����Ƚ����ܶ�
        /// </summary>
        public decimal? Year_tradeMoney
        {
            set { _year_trademoney = value; }
            get { return _year_trademoney; }
        }
        /// <summary>
        /// ����������ܶ�
        /// </summary>
        public decimal? Year_incomeMoney
        {
            set { _year_incomemoney = value; }
            get { return _year_incomemoney; }
        }
        /// <summary>
        /// �ܽ��׽��
        /// </summary>
        public decimal? Total_tradeMoney
        {
            set { _total_trademoney = value; }
            get { return _total_trademoney; }
        }
        /// <summary>
        /// �ܻ�����
        /// </summary>
        public decimal? Total_incomeMoney
        {
            set { _total_incomemoney = value; }
            get { return _total_incomemoney; }
        }
        /// <summary>
        /// �������ʼʱ��
        /// </summary>
        public DateTime? YearStart_time
        {
            set { _yearstart_time = value; }
            get { return _yearstart_time; }
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
        /// �����
        /// </summary>
        public string Auditing_Manager
        {
            set { _auditing_manager = value; }
            get { return _auditing_manager; }
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

