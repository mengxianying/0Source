using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类AgentAgree 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class AgentAgree
    {
        public AgentAgree()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _content;
        private string _agreeurl;
        private DateTime _addtime;
        private int? _state;
        private string _purpose;
        private int? _intchannelid;
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
        public string Title
        {
            set { _title = value; }
            get { return _title; }
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
        public string AgreeUrl
        {
            set { _agreeurl = value; }
            get { return _agreeurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Purpose
        {
            set { _purpose = value; }
            get { return _purpose; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IntChannelID
        {
            set { _intchannelid = value; }
            get { return _intchannelid; }
        }
        #endregion Model

    }
}

