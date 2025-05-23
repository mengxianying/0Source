using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类Chipped_bounsAllost 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Chipped_bounsAllost
    {
        public Chipped_bounsAllost()
        { }
        #region Model
        private string _awardnum;
        private string _awardname;
        private int _lotterystate;
        private decimal _bounsallost;
        private int _assignstate;
        private DateTime _atime;
        /// <summary>
        /// 
        /// </summary>
        public string AwardNum
        {
            set { _awardnum = value; }
            get { return _awardnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AwardName
        {
            set { _awardname = value; }
            get { return _awardname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int lotteryState
        {
            set { _lotterystate = value; }
            get { return _lotterystate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal bounsAllost
        {
            set { _bounsallost = value; }
            get { return _bounsallost; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int AssignState
        {
            set { _assignstate = value; }
            get { return _assignstate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ATime
        {
            set { _atime = value; }
            get { return _atime; }
        }
        #endregion Model
    }
}
