using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    [Serializable]
    public class K3Date
    {
        public K3Date()
        { }
        #region Model
        private int _issue;
        private DateTime? _date;
        private string _code;
        private DateTime? _lastmodifytime;
        private string _opname;
        private string _opip;
        /// <summary>
        /// 
        /// </summary>
        public int Issue
        {
            set { _issue = value; }
            get { return _issue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Code
        {
            set { _code = value; }
            get { return _code; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastModifytime
        {
            set { _lastmodifytime = value; }
            get { return _lastmodifytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpName
        {
            set { _opname = value; }
            get { return _opname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string OpIp
        {
            set { _opip = value; }
            get { return _opip; }
        }
        #endregion Model

    }
}
