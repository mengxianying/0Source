using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类Chipped_Tracking 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Chipped_Tracking
    {
        public Chipped_Tracking()
        { }
        #region Model
        private int _tid;
        private string _tname;
        private int? _tplay;
        private int? _tperiod;
        private string _tordernum;
        private int? _tstate;
        /// <summary>
        /// 
        /// </summary>
        public int TID
        {
            set { _tid = value; }
            get { return _tid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TName
        {
            set { _tname = value; }
            get { return _tname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Tplay
        {
            set { _tplay = value; }
            get { return _tplay; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TPeriod
        {
            set { _tperiod = value; }
            get { return _tperiod; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TorderNum
        {
            set { _tordernum = value; }
            get { return _tordernum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Tstate
        {
            set { _tstate = value; }
            get { return _tstate; }
        }
        #endregion Model
    }
}
