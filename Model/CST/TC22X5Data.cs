using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����TC22X5Data ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class TC22X5Data
    {
        public TC22X5Data()
        { }
        #region Model
        private DateTime? _date;
        private int _issue;
        private string _code;
        private DateTime? _lastmodifytime;
        private string _opname;
        private string _opip;
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
        public int issue
        {
            set { _issue = value; }
            get { return _issue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string code
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

