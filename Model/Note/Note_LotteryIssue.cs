using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类Note_LotteryIssue 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class Note_LotteryIssue
    {
        public Note_LotteryIssue()
        { }
        #region Model
        private int _id;
        private int _sid;
        private string _qnumber;
        private string _content;

        private DateTime _begintime;

        private int isSend;

        public int IsSend
        {
            get { return isSend; }
            set { isSend = value; }
        }
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
        public int SID
        {
            set { _sid = value; }
            get { return _sid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QNumber
        {
            set { _qnumber = value; }
            get { return _qnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BeginTime
        {
            set { _begintime = value; }
            get { return _begintime; }
        }
        #endregion Model

    }
}
