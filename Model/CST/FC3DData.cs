using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类FC3DData 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class FC3DData
    {
        public FC3DData()
        { }
        #region Model
        private DateTime _date;
        private string _issue;
        private string _testcode;
        private string _code;
        private int? _machine;
        private int? _ball;
        private int _dxcount;
        private int? _z3count;
        private int? _z6count;
        private int? _sales;
        private int? _bonus;
        private string _testorderb;
        private string _testorders;
        private string _testorderg;
        private DateTime? _lastmodifytime;
        private string _opname;
        private string _opip;
        private string _codeorderb;
        private string _codeorders;
        private string _codeorderg;

        private string _attentioncode;
        private string _decode;

        /// <summary>
        /// 彩神通关注码
        /// </summary>
        public string AttentionCode
        {
            set { _attentioncode = value; }
            get { return _attentioncode; }
        }
        /// <summary>
        /// 试机号对应码
        /// </summary>
        public string decode
        {
            set { _decode = value; }
            get { return _decode; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime date
        {
            set { _date = value; }
            get { return _date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string issue
        {
            set { _issue = value; }
            get { return _issue; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string testcode
        {
            set { _testcode = value; }
            get { return _testcode; }
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
        public int? machine
        {
            set { _machine = value; }
            get { return _machine; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ball
        {
            set { _ball = value; }
            get { return _ball; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int DXCount
        {
            set { _dxcount = value; }
            get { return _dxcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Z3Count
        {
            set { _z3count = value; }
            get { return _z3count; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Z6Count
        {
            set { _z6count = value; }
            get { return _z6count; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Sales
        {
            set { _sales = value; }
            get { return _sales; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Bonus
        {
            set { _bonus = value; }
            get { return _bonus; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TestOrderB
        {
            set { _testorderb = value; }
            get { return _testorderb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TestOrderS
        {
            set { _testorders = value; }
            get { return _testorders; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TestOrderG
        {
            set { _testorderg = value; }
            get { return _testorderg; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LastModifyTime
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
        /// <summary>
        /// 
        /// </summary>
        public string CodeOrderB
        {
            set { _codeorderb = value; }
            get { return _codeorderb; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CodeOrderS
        {
            set { _codeorders = value; }
            get { return _codeorders; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CodeOrderG
        {
            set { _codeorderg = value; }
            get { return _codeorderg; }
        }
        #endregion Model

    }
}

