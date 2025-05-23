using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    public class PBnet_WebLog
    {
        public PBnet_WebLog()
        {
            _actiontime = DateTime.Now;
        }
        #region Model
        private int _id;
        private string _actiontype;
        private string _detail;
        private string _operator;
        private string _userip;
        private DateTime _actiontime;
        /// <summary>
        /// 编号
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 操作名称
        /// </summary>
        public string ActionType
        {
            set { _actiontype = value; }
            get { return _actiontype; }
        }
        /// <summary>
        /// 详细内容
        /// </summary>
        public string Detail
        {
            set { _detail = value; }
            get { return _detail; }
        }
        /// <summary>
        /// 操作者
        /// </summary>
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
        }
        /// <summary>
        /// IP
        /// </summary>
        public string UserIP
        {
            set { _userip = value; }
            get { return _userip; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime ActionTime
        {
            set { _actiontime = value; }
            get { return _actiontime; }
        }
        #endregion Model
    }
}
