using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类Chipped_TrackingOrders 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Chipped_TrackingOrders
    {
        public Chipped_TrackingOrders()
        { }
        #region Model
        private int _trackingid;
        private string _usern;
        private int? _trackinglnum;
        private string _trackingname;
        private DateTime? _trackingtime;
        private int? _subscribenum;
        private decimal? _buymoney;
        private int? _trackingstate = 0;
        private int? _trackingn;
        /// <summary>
        /// 
        /// </summary>
        public int TrackingID
        {
            set { _trackingid = value; }
            get { return _trackingid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserN
        {
            set { _usern = value; }
            get { return _usern; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TrackingLNum
        {
            set { _trackinglnum = value; }
            get { return _trackinglnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TrackingName
        {
            set { _trackingname = value; }
            get { return _trackingname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? TrackingTime
        {
            set { _trackingtime = value; }
            get { return _trackingtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? SubscribeNum
        {
            set { _subscribenum = value; }
            get { return _subscribenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? BuyMoney
        {
            set { _buymoney = value; }
            get { return _buymoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TrackingState
        {
            set { _trackingstate = value; }
            get { return _trackingstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TrackingN
        {
            set { _trackingn = value; }
            get { return _trackingn; }
        }
        #endregion Model
    }
}
