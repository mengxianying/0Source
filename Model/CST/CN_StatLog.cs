using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类CN_StatLog 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class CN_StatLog
    {
        public CN_StatLog()
        { }
        #region Model
        private int _id;
        private DateTime? _starttime;
        private DateTime? _endtime;
        private string _result;
        private string _errorinfo;
        private DateTime? _enddate;
        private int? _days;
        private string _flag;
        private string _stattablename;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Result
        {
            set { _result = value; }
            get { return _result; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ErrorInfo
        {
            set { _errorinfo = value; }
            get { return _errorinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndDate
        {
            set { _enddate = value; }
            get { return _enddate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Days
        {
            set { _days = value; }
            get { return _days; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Flag
        {
            set { _flag = value; }
            get { return _flag; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string StatTableName
        {
            set { _stattablename = value; }
            get { return _stattablename; }
        }
        #endregion Model

    }
}

