using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// Challenge_type:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Challenge_type
    {
        public Challenge_type()
        { }
        #region Model
        private int _t_id;
        private string _t_cond;
        private string _t_state;
        private int? _t_lottid;
        /// <summary>
        /// 
        /// </summary>
        public int T_id
        {
            set { _t_id = value; }
            get { return _t_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string T_cond
        {
            set { _t_cond = value; }
            get { return _t_cond; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string T_state
        {
            set { _t_state = value; }
            get { return _t_state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? T_lottID
        {
            set { _t_lottid = value; }
            get { return _t_lottid; }
        }
        #endregion Model

    }
}


