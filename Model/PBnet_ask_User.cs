using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_ask_User ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ����ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// BBS�û���
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int Point
        {
            set { _point = value; }
            get { return _point; }
        }
        /// <summary>
        /// ���ͷ�
        /// </summary>
        public int Pointpenalty
        {
            set { _pointpenalty = value; }
            get { return _pointpenalty; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public int OtherPointpenalty
        {
            set { _otherpointpenalty = value; }
            get { return _otherpointpenalty; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int AskNum
        {
            set { _asknum = value; }
            get { return _asknum; }
        }
        /// <summary>
        /// �ش���
        /// </summary>
        public int ReplyNum
        {
            set { _replynum = value; }
            get { return _replynum; }
        }
        /// <summary>
        /// ��Ѵ���
        /// </summary>
        public int Best_ReplyNum
        {
            set { _best_replynum = value; }
            get { return _best_replynum; }
        }
        /// <summary>
        /// ��ͨʱ��
        /// </summary>
        public DateTime OpenTime
        {
            set { _opentime = value; }
            get { return _opentime; }
        }
        /// <summary>
        /// ���ⱻɾ��
        /// </summary>
        public int Ask_DelNum
        {
            set { _ask_delnum = value; }
            get { return _ask_delnum; }
        }
        /// <summary>
        /// �û���
        /// </summary>
        public string UserGroup
        {
            set { _usergroup = value; }
            get { return _usergroup; }
        }
        /// <summary>
        /// ״̬��0:����,1:��������
        /// </summary>
        public int State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// �����÷�
        /// </summary>
        public int Score
        {
            set { _score = value; }
            get { return _score; }
        }
        #endregion Model

    }
}

