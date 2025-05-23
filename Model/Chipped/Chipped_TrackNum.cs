using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// Chipped_TrackNum:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Chipped_TrackNum
    {
        public Chipped_TrackNum()
        { }
        #region Model
        private int _tn_id;
        private string _tn_ordernum;
        private string _tn_username;
        private int? _tn_playname;
        private string _tn_stopcondition;
        private string _tn_issue;
        private string _tn_num;
        private int? _tn_multiple;
        private decimal? _tn_money;
        private int? _tn_message;
        private DateTime? _tn_time;
        private int? _tn_complete = 0;
        private decimal? _tn_inward;
        private string _tn_order;
        private int? _tn_open = 0;
        private int? _tn_dtbt = 0;
        /// <summary>
        /// 
        /// </summary>
        public int tn_id
        {
            set { _tn_id = value; }
            get { return _tn_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tn_orderNum
        {
            set { _tn_ordernum = value; }
            get { return _tn_ordernum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tn_username
        {
            set { _tn_username = value; }
            get { return _tn_username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? tn_playname
        {
            set { _tn_playname = value; }
            get { return _tn_playname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tn_stopCondition
        {
            set { _tn_stopcondition = value; }
            get { return _tn_stopcondition; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tn_issue
        {
            set { _tn_issue = value; }
            get { return _tn_issue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tn_num
        {
            set { _tn_num = value; }
            get { return _tn_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? tn_multiple
        {
            set { _tn_multiple = value; }
            get { return _tn_multiple; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? tn_money
        {
            set { _tn_money = value; }
            get { return _tn_money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? tn_message
        {
            set { _tn_message = value; }
            get { return _tn_message; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? tn_time
        {
            set { _tn_time = value; }
            get { return _tn_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? tn_complete
        {
            set { _tn_complete = value; }
            get { return _tn_complete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? tn_Inward
        {
            set { _tn_inward = value; }
            get { return _tn_inward; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string tn_order
        {
            set { _tn_order = value; }
            get { return _tn_order; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? tn_open
        {
            set { _tn_open = value; }
            get { return _tn_open; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? tn_dtbt
        {
            set { _tn_dtbt = value; }
            get { return _tn_dtbt; }
        }
        #endregion Model

    }
}
