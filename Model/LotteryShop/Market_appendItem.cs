using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    ///添加项目信息模型类
    /// 添加人：杨良伟
    ///2010-10-20 
    /// </summary>
    [Serializable]
    public class Market_appendItem
    {
        public Market_appendItem()
        { }
        #region Model
        private int _appendid;
        private int _typeid;
        private string _userid;
        private int _charge;
        private int _on_off;
        private string _say;
        private DateTime _time;
        private decimal _agio;
        private decimal _price;
        private string _issuetime;
        private int _commend;
        private int _state;
        private int _confine;
        /// <summary>
        /// 
        /// </summary>
        public int appendID
        {
            set { _appendid = value; }
            get { return _appendid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Charge
        {
            set { _charge = value; }
            get { return _charge; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int On_off
        {
            set { _on_off = value; }
            get { return _on_off; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Say
        {
            set { _say = value; }
            get { return _say; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Time
        {
            set { _time = value; }
            get { return _time; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Agio
        {
            set { _agio = value; }
            get { return _agio; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal Price
        {
            set { _price = value; }
            get { return _price; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IssueTime
        {
            set { _issuetime = value; }
            get { return _issuetime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Commend
        {
            set { _commend = value; }
            get { return _commend; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Confine
        {
            set { _confine = value; }
            get { return _confine; }
        }
        #endregion Model
    }
}
