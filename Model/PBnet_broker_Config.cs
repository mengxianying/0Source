using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_broker_Config ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_broker_Config
    {
        public PBnet_broker_Config()
        { }
        #region Model
        private int _id;
        private int? _discount_grade;
        private string _discount_gradename;
        private int? _discount_rate;
        private decimal? _min_trademoney;
        /// <summary>
        /// 
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// �ۿ۵ȼ�
        /// </summary>
        public int? Discount_grade
        {
            set { _discount_grade = value; }
            get { return _discount_grade; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Discount_gradeName
        {
            set { _discount_gradename = value; }
            get { return _discount_gradename; }
        }
        /// <summary>
        /// �ۿ�ֵ���ٷֱȵķ��ӣ�����75��ʾ�ٷ�֮75��
        /// </summary>
        public int? Discount_rate
        {
            set { _discount_rate = value; }
            get { return _discount_rate; }
        }
        /// <summary>
        /// �ﵽ���ۿ۵���ͽ��׽��
        /// </summary>
        public decimal? Min_tradeMoney
        {
            set { _min_trademoney = value; }
            get { return _min_trademoney; }
        }
        #endregion Model

    }
}

