using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_ask_Reply 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_ask_Reply
    {
        public PBnet_ask_Reply()
        { }
        #region Model
        private int _id;
        private int _questionid;
        private string _content;
        private string _replyer;
        private DateTime _replytime;
        private bool _isbest;
        private string _referencebook;
        private string _comment;
        private int? _goodcomment;
        private int? _badcomment;
        private int? _attachid;
        private int? _replyerid;
        private bool _deleted;

        private bool auditing;
        /// <summary>
        /// 审核状态
        /// </summary>
        public bool Auditing
        {
            get { return auditing; }
            set { auditing = value; }
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
        public int QuestionId
        {
            set { _questionid = value; }
            get { return _questionid; }
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
        public string Replyer
        {
            set { _replyer = value; }
            get { return _replyer; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReplyTime
        {
            set { _replytime = value; }
            get { return _replytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool IsBest
        {
            set { _isbest = value; }
            get { return _isbest; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ReferenceBook
        {
            set { _referencebook = value; }
            get { return _referencebook; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Comment
        {
            set { _comment = value; }
            get { return _comment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? GoodComment
        {
            set { _goodcomment = value; }
            get { return _goodcomment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BadComment
        {
            set { _badcomment = value; }
            get { return _badcomment; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? AttachId
        {
            set { _attachid = value; }
            get { return _attachid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ReplyerId
        {
            set { _replyerid = value; }
            get { return _replyerid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Deleted
        {
            set { _deleted = value; }
            get { return _deleted; }
        }
        #endregion Model

    }
}

