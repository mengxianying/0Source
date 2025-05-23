using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// Chipped_issueN:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Chipped_issueN
    {
        public Chipped_issueN()
        { }
        #region Model
        private int _in_id;
        private int? _in_rnid;
        private string _in_num;
        private int? _in_mark = 0;
        private string _in_issue;
        private int? _in_multiple;
        private decimal? _in_money;
        private int _in_state = 0;
        private decimal? _in_bouns;
        /// <summary>
        /// 
        /// </summary>
        public int In_id
        {
            set { _in_id = value; }
            get { return _in_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? In_RnId
        {
            set { _in_rnid = value; }
            get { return _in_rnid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string In_num
        {
            set { _in_num = value; }
            get { return _in_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? In_mark
        {
            set { _in_mark = value; }
            get { return _in_mark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string In_issue
        {
            set { _in_issue = value; }
            get { return _in_issue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? In_multiple
        {
            set { _in_multiple = value; }
            get { return _in_multiple; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? In_money
        {
            set { _in_money = value; }
            get { return _in_money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int In_state
        {
            set { _in_state = value; }
            get { return _in_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? In_bouns
        {
            set { _in_bouns = value; }
            get { return _in_bouns; }
        }
        #endregion Model

    }
}
