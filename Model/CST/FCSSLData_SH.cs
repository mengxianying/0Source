using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类FCSSLData_SH 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class FCSSLData_SH
    {
        public FCSSLData_SH()
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

