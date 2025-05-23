using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类Chipped_AcctPayCharge 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class Chipped_AcctPayCharge
    {
        public Chipped_AcctPayCharge()
        { }
        #region Model
        private int _apcid;
        private string _apcname;
        private int _accttype;
        private string _payltem;
        private string _specificitem;
        private DateTime _apctime;
        /// <summary>
        /// 
        /// </summary>
        public int apcID
        {
            set { _apcid = value; }
            get { return _apcid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string apcName
        {
            set { _apcname = value; }
            get { return _apcname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int acctType
        {
            set { _accttype = value; }
            get { return _accttype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Payltem
        {
            set { _payltem = value; }
            get { return _payltem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string specificItem
        {
            set { _specificitem = value; }
            get { return _specificitem; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime apcTime
        {
            set { _apctime = value; }
            get { return _apctime; }
        }
        #endregion Model
    }
}
