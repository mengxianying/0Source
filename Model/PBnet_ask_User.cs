using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_ask_User 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_ask_User
    {
        public PBnet_ask_User()
        {
            _username = "";
            _point = 0;
            _pointpenalty = 0;
            _otherpointpenalty = 0;
            _asknum = 0;
            _replynum = 0;
            _best_replynum = 0;
            _opentime = DateTime.Now;
            _ask_delnum = 0;
            _usergroup = "";
            _state = 0;
            _score = 0;
        }
        #region Model
        private int _id;
        private string _username;
        private int _point;
        private int _pointpenalty;
        private int _otherpointpenalty;
    
        private int _asknum;
        private int _replynum;
        private int _best_replynum;
        private DateTime _opentime;
        private int _ask_delnum;
        private string _usergroup;
        private int _state;
        private int _score;
        /// <summary>
        /// 索引ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// BBS用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 积分
        /// </summary>
        public int Point
        {
            set { _point = value; }
            get { return _point; }
        }
        /// <summary>
        /// 悬赏分
        /// </summary>
        public int Pointpenalty
        {
            set { _pointpenalty = value; }
            get { return _pointpenalty; }
        }
        /// <summary>
        /// 罚分
        /// </summary>
        public int OtherPointpenalty
        {
            set { _otherpointpenalty = value; }
            get { return _otherpointpenalty; }
        }
        /// <summary>
        /// 问题数
        /// </summary>
        public int AskNum
        {
            set { _asknum = value; }
            get { return _asknum; }
        }
        /// <summary>
        /// 回答数
        /// </summary>
        public int ReplyNum
        {
            set { _replynum = value; }
            get { return _replynum; }
        }
        /// <summary>
        /// 最佳答案数
        /// </summary>
        public int Best_ReplyNum
        {
            set { _best_replynum = value; }
            get { return _best_replynum; }
        }
        /// <summary>
        /// 开通时间
        /// </summary>
        public DateTime OpenTime
        {
            set { _opentime = value; }
            get { return _opentime; }
        }
        /// <summary>
        /// 问题被删数
        /// </summary>
        public int Ask_DelNum
        {
            set { _ask_delnum = value; }
            get { return _ask_delnum; }
        }
        /// <summary>
        /// 用户组
        /// </summary>
        public string UserGroup
        {
            set { _usergroup = value; }
            get { return _usergroup; }
        }
        /// <summary>
        /// 状态（0:正常,1:被锁定）
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 奖励得分
        /// </summary>
        public int Score
        {
            set { _score = value; }
            get { return _score; }
        }
        #endregion Model

    }
}

