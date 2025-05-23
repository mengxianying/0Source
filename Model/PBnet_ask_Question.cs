using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_ask_Question ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// ���״̬
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
        /// ����
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string Relay
        {
            set { _relay = value; }
            get { return _relay; }
        }
        /// <summary>
        /// �������û���
        /// </summary>
        public string Asker
        {
            set { _asker = value; }
            get { return _asker; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime AskTime
        {
            set { _asktime = value; }
            get { return _asktime; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? OverTime
        {
            set { _overtime = value; }
            get { return _overtime; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime UpdateTime
        {
            set { _updatetime = value; }
            get { return _updatetime; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public int? Views
        {
            set { _views = value; }
            get { return _views; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// �����
        /// </summary>
        public int? TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public int? FTypeID
        {
            set { _ftypeid = value; }
            get { return _ftypeid; }
        }
        /// <summary>
        /// ����״̬��0�������;1���ѽ��;2���ѹرգ�
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
        /// ���͸���
        /// </summary>
        public int? LargessPoint
        {
            set { _largesspoint = value; }
            get { return _largesspoint; }
        }
        /// <summary>
        /// �Ƿ񾫻�
        /// </summary>
        public bool IsCommend
        {
            set { _iscommend = value; }
            get { return _iscommend; }
        }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool IsAnonymous
        {
            set { _isanonymous = value; }
            get { return _isanonymous; }
        }
        /// <summary>
        /// �ϴ��ļ����
        /// </summary>
        public int? AttachId
        {
            set { _attachid = value; }
            get { return _attachid; }
        }
        /// <summary>
        /// �ش���
        /// </summary>
        public int? Replys
        {
            set { _replys = value; }
            get { return _replys; }
        }
        /// <summary>
        /// �����߱��
        /// </summary>
        public int? AskerId
        {
            set { _askerid = value; }
            get { return _askerid; }
        }
        /// <summary>
        /// �����id
        /// </summary>
        public int? AnswererId
        {
            set { _answererid = value; }
            get { return _answererid; }
        }
        /// <summary>
        /// �Ƿ��ȵ�
        /// </summary>
        public bool BitIsHot
        {
            set { _bitishot = value; }
            get { return _bitishot; }
        }
        /// <summary>
        /// �Ƿ�ɾ��
        /// </summary>
        public bool Deleted
        {
            set { _deleted = value; }
            get { return _deleted; }
        }
        #endregion Model

    }
}

