using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_QQ_Record ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_QQ_Record
    {
        public PBnet_QQ_Record()
        {
            _IsLock = false;
            _addtime = null;
            _kickofftime = null;
        }
        #region Model
        private int _id;
        private int _qq_gropid;
        private string _qq_id;
        private string _username;
        private int _onlinestate;
        private string _qq_detail;
        private string _addmanager;
        private DateTime? _addtime;
        private string _kickoffmanager;
        private DateTime? _kickofftime;
        private string _updateManager;

        public string UpdateManager
        {
            get { return _updateManager; }
            set { _updateManager = value; }
        }

        private bool _IsLock;

        /// <summary>
        /// �Ƿ���
        /// </summary>
        public bool IsLock
        {
            get { return _IsLock; }
            set { _IsLock = value; }
        }

        /// <summary>
        /// qq�����¼���Զ��������
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// ����qqȺ���
        /// </summary>
        public int QQ_GropID
        {
            set { _qq_gropid = value; }
            get { return _qq_gropid; }
        }
        /// <summary>
        /// QQ��
        /// </summary>
        public string QQ_ID
        {
            set { _qq_id = value; }
            get { return _qq_id; }
        }
        /// <summary>
        /// ��̳��
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// ����״̬��0�����ߣ�1���˳���2�����ߣ�
        /// </summary>
        public int OnlineState
        {
            set { _onlinestate = value; }
            get { return _onlinestate; }
        }
        /// <summary>
        /// ˵��(���߼�¼ԭ��ȵ�)
        /// </summary>
        public string QQ_Detail
        {
            set { _qq_detail = value; }
            get { return _qq_detail; }
        }
        /// <summary>
        /// ���������
        /// </summary>
        public string AddManager
        {
            set { _addmanager = value; }
            get { return _addmanager; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// �˳����߱��߲�����
        /// </summary>
        public string KickOffManager
        {
            set { _kickoffmanager = value; }
            get { return _kickoffmanager; }
        }
        /// <summary>
        /// �˳�ʱ��
        /// </summary>
        public DateTime? KickOffTime
        {
            set { _kickofftime = value; }
            get { return _kickofftime; }
        }
        #endregion Model

    }
}

