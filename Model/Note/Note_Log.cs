using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类Note_Log 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Note_Log
    {
        public Note_Log()
        { }
        #region Model
        private int _id;
        private string _phone;
        private string _countent;
        private DateTime? _begintime;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Phone
        {
            set { _phone = value; }
            get { return _phone; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Countent
        {
            set { _countent = value; }
            get { return _countent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? BeginTime
        {
            set { _begintime = value; }
            get { return _begintime; }
        }
        #endregion Model

    }
}
