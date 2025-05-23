using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_ask_Question 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_ask_Question
    {
        public PBnet_ask_Question()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _content;
        private string _relay;
        private string _asker;
        private DateTime _asktime;
        private DateTime? _overtime;
        private DateTime _updatetime;
        private int? _views;
        private string _typename;
        private int? _typeid;
        private int? _ftypeid;
        private int? _state;
        private string _answerer;
        private int? _largesspoint;
        private bool _iscommend;
        private bool _isanonymous;
        private int? _attachid;
        private int? _replys;
        private int? _askerid;
        private int? _answererid;
        private bool _bitishot;
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
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 补充
        /// </summary>
        public string Relay
        {
            set { _relay = value; }
            get { return _relay; }
        }
        /// <summary>
        /// 提问者用户名
        /// </summary>
        public string Asker
        {
            set { _asker = value; }
            get { return _asker; }
        }
        /// <summary>
        /// 提问时间
        /// </summary>
        public DateTime AskTime
        {
            set { _asktime = value; }
            get { return _asktime; }
        }
        /// <summary>
        /// 到期时间
        /// </summary>
        public DateTime? OverTime
        {
            set { _overtime = value; }
            get { return _overtime; }
        }
        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// 浏览数
        /// </summary>
        public int? Views
        {
            set { _views = value; }
            get { return _views; }
        }
        /// <summary>
        /// 类别名
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 类别编号
        /// </summary>
        public int? TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 父类别编号
        /// </summary>
        public int? FTypeID
        {
            set { _ftypeid = value; }
            get { return _ftypeid; }
        }
        /// <summary>
        /// 问题状态（0：待解决;1：已解决;2：已关闭）
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Answerer
        {
            set { _answerer = value; }
            get { return _answerer; }
        }
        /// <summary>
        /// 悬赏付出
        /// </summary>
        public int? LargessPoint
        {
            set { _largesspoint = value; }
            get { return _largesspoint; }
        }
        /// <summary>
        /// 是否精华
        /// </summary>
        public bool IsCommend
        {
            set { _iscommend = value; }
            get { return _iscommend; }
        }
        /// <summary>
        /// 是否匿名
        /// </summary>
        public bool IsAnonymous
        {
            set { _isanonymous = value; }
            get { return _isanonymous; }
        }
        /// <summary>
        /// 上传文件编号
        /// </summary>
        public int? AttachId
        {
            set { _attachid = value; }
            get { return _attachid; }
        }
        /// <summary>
        /// 回答数
        /// </summary>
        public int? Replys
        {
            set { _replys = value; }
            get { return _replys; }
        }
        /// <summary>
        /// 提问者编号
        /// </summary>
        public int? AskerId
        {
            set { _askerid = value; }
            get { return _askerid; }
        }
        /// <summary>
        /// 最近答案id
        /// </summary>
        public int? AnswererId
        {
            set { _answererid = value; }
            get { return _answererid; }
        }
        /// <summary>
        /// 是否热点
        /// </summary>
        public bool BitIsHot
        {
            set { _bitishot = value; }
            get { return _bitishot; }
        }
        /// <summary>
        /// 是否删除
        /// </summary>
        public bool Deleted
        {
            set { _deleted = value; }
            get { return _deleted; }
        }
        #endregion Model

    }
}

