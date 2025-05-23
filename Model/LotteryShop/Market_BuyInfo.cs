using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类Market_BuyInfo 。(属性说明自动提取数据库字段的描述信息)
    /// 创建人：周伟
    /// 创建时间：2010-10-22
    /// </summary>
    [Serializable]
    public class Market_BuyInfo
    {
        public Market_BuyInfo()
        { }
        #region Model
        private int _buyid;
        private string _buyuserid;
        private int _issueinfoid;
        private string _lotterytype;
        private string _shopuserid;
        private decimal? _price;
        private int? _term;
        private DateTime? _begintime;
        private DateTime? _endtime;
        private int _buycontinue;
        private int _market;
        /// <summary>
        /// 
        /// </summary>
        public int buyid
        {
            set { _buyid = value; }
            get { return _buyid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string buyuserid
        {
            set { _buyuserid = value; }
            get { return _buyuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int issueInfoId
        {
            set { _issueinfoid = value; }
            get { return _issueinfoid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LotteryType
        {
            set { _lotterytype = value; }
            get { return _lotterytype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ShopUserID
        {
            set { _shopuserid = value; }
            get { return _shopuserid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Term
        {
            set { _term = value; }
            get { return _term; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BeginTime
        {
            set { _begintime = value; }
            get { return _begintime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int buyContinue
        {
            set { _buycontinue = value; }
            get { return _buycontinue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int market
        {
            set { _market = value; }
            get { return _market; }
        }
        #endregion Model

    }
}
