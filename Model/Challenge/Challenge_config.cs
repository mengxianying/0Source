using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// Challenge_config:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Challenge_config
    {
        public Challenge_config()
        { }
        #region Model
        private int _id;
        private DateTime? _ctime;
        private int? _complete;
        private int? _agreeref;
        private string _lastip;
        private string _attstate;
        /// <summary>
        /// 
        /// </summary>
        public int id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? CTime
        {
            set { _ctime = value; }
            get { return _ctime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Complete
        {
            set { _complete = value; }
            get { return _complete; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? agreeRef
        {
            set { _agreeref = value; }
            get { return _agreeref; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string lastIP
        {
            set { _lastip = value; }
            get { return _lastip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string attState
        {
            set { _attstate = value; }
            get { return _attstate; }
        }
        #endregion Model

    }
}