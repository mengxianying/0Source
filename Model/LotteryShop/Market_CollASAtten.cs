using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
	/// ʵ����Market_CollASAtten ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
    [Serializable]
    public class Market_CollASAtten
    {
        public Market_CollASAtten()
        { }
        #region Model
        private int _intid;
        private string _uname;
        private string _appname;
        private int? _statc;
        private int? _mark;
        private DateTime? _apptime;
        /// <summary>
        /// 
        /// </summary>
        public int intId
        {
            set { _intid = value; }
            get { return _intid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Uname
        {
            set { _uname = value; }
            get { return _uname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string appName
        {
            set { _appname = value; }
            get { return _appname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? statc
        {
            set { _statc = value; }
            get { return _statc; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? mark
        {
            set { _mark = value; }
            get { return _mark; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? appTime
        {
            set { _apptime = value; }
            get { return _apptime; }
        }
        #endregion Model
    }
}
