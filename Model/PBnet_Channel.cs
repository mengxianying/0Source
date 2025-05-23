using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_Channel ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_Channel
    {
        public PBnet_Channel()
        { }
        #region Model
        private int _channelid;
        private string _channelname;
        private int? _channelfid;
        private bool _isauditing;
        private int? _orderid;
        private int? _depth;
        private int? _rootid;
        private string _channelfids;
        /// <summary>
        /// Ƶ��ID
        /// </summary>
        public int ChannelID
        {
            set { _channelid = value; }
            get { return _channelid; }
        }
        /// <summary>
        /// Ƶ������
        /// </summary>
        public string ChannelName
        {
            set { _channelname = value; }
            get { return _channelname; }
        }
        /// <summary>
        /// Ƶ����ID
        /// </summary>
        public int? ChannelFID
        {
            set { _channelfid = value; }
            get { return _channelfid; }
        }
        /// <summary>
        /// �Ƿ��Ƽ�
        /// </summary>
        public bool IsAuditing
        {
            set { _isauditing = value; }
            get { return _isauditing; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// ���
        /// </summary>
        public int? Depth
        {
            set { _depth = value; }
            get { return _depth; }
        }
        /// <summary>
        /// �����ID
        /// </summary>
        public int? RootID
        {
            set { _rootid = value; }
            get { return _rootid; }
        }
        /// <summary>
        /// ����Ų㼶��ϵ
        /// </summary>
        public string ChannelFIDS
        {
            set { _channelfids = value; }
            get { return _channelfids; }
        }
        #endregion Model

    }
}

