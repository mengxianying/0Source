using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类TCPL35Data 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class TCPL35Data
    {
        public TCPL35Data()
        { }
        #region Model
        private DateTime _date;
        private string _issue;
        private string _code3;
        private string _code5;
        private string _testcode;
        private int? _machine;
        private int _ball;
        private DateTime? _lastmodifytime;
        private string _opname;
        private string _opip;
        private int? _p3sales;
        private int? _dxcount;
        private int? _z3count;
        private int? _z6count;
        private int? _p5sales;
        private int? _p5count;
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
        public string code3
        {
            set { _code3 = value; }
            get { return _code3; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string code5
        {
            set { _code5 = value; }
            get { return _code5; }
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
        public int? machine
        {
            set { _machine = value; }
            get { return _machine; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ball
        {
            set { _ball = value; }
            get { return _ball; }
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
        public int? P3Sales
        {
            set { _p3sales = value; }
            get { return _p3sales; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DxCount
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
        public int? P5Sales
        {
            set { _p5sales = value; }
            get { return _p5sales; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? P5Count
        {
            set { _p5count = value; }
            get { return _p5count; }
        }
        #endregion Model

    }
}

