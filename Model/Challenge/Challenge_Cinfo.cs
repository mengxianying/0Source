using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// Challenge_Cinfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Challenge_Cinfo
    {
        public Challenge_Cinfo()
        { }
        #region Model
        private int _c_id;
        private string _c_name;
        private int? _c_lottid;
        private int? _c_issue;
        private DateTime? _c_time;
        private int? _c_tid;
        private string _c_num;
        private int? _c_win = 0;
        /// <summary>
        /// 
        /// </summary>
        public int C_id
        {
            set { _c_id = value; }
            get { return _c_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string C_name
        {
            set { _c_name = value; }
            get { return _c_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? C_lottID
        {
            set { _c_lottid = value; }
            get { return _c_lottid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? C_issue
        {
            set { _c_issue = value; }
            get { return _c_issue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? C_time
        {
            set { _c_time = value; }
            get { return _c_time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? C_Tid
        {
            set { _c_tid = value; }
            get { return _c_tid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string C_num
        {
            set { _c_num = value; }
            get { return _c_num; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? C_win
        {
            set { _c_win = value; }
            get { return _c_win; }
        }
        #endregion Model

    }
}
