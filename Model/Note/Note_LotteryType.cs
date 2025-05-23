using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类Note_LotteryType 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Note_LotteryType
    {
        public Note_LotteryType()
        { }
        #region Model
        private int _sid;
        private string _sname;
        private string _pricecontent;
        private string _explain;
        private bool _ispublic;
        private DateTime beginTime;


        /// <summary>
        /// 星期
        /// </summary>
        private string issueWeek;

        public string IssueWeek
        {
            get { return issueWeek; }
            set { issueWeek = value; }
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        private string issueTime;

        public string IssueTime
        {
            get { return issueTime; }
            set { issueTime = value; }
        }



        public DateTime BeginTime
        {
            get { return beginTime; }
            set { beginTime = value; }
        }
        private DateTime upTime;

        public DateTime UpTime
        {
            get { return upTime; }
            set { upTime = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int SID
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SName
        {
            set { _sname = value; }
            get { return _sname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PriceContent
        {
            set { _pricecontent = value; }
            get { return _pricecontent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Explain
        {
            set { _explain = value; }
            get { return _explain; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Ispublic
        {
            set { _ispublic = value; }
            get { return _ispublic; }
        }
        #endregion Model

    }
}
