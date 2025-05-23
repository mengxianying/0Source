using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_broker_Config 。(属性说明自动提取数据库字段的描述信息)
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
        /// 折扣等级
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
        /// 折扣值（百分比的分子，比如75表示百分之75）
        /// </summary>
        public int? Discount_rate
        {
            set { _discount_rate = value; }
            get { return _discount_rate; }
        }
        /// <summary>
        /// 达到该折扣的最低交易金额
        /// </summary>
        public decimal? Min_tradeMoney
        {
            set { _min_trademoney = value; }
            get { return _min_trademoney; }
        }
        #endregion Model

    }
}

