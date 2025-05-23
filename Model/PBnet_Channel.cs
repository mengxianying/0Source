using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_Channel 。(属性说明自动提取数据库字段的描述信息)
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
        /// 频道ID
        /// </summary>
        public int ChannelID
        {
            set { _channelid = value; }
            get { return _channelid; }
        }
        /// <summary>
        /// 频道名称
        /// </summary>
        public string ChannelName
        {
            set { _channelname = value; }
            get { return _channelname; }
        }
        /// <summary>
        /// 频道父ID
        /// </summary>
        public int? ChannelFID
        {
            set { _channelfid = value; }
            get { return _channelfid; }
        }
        /// <summary>
        /// 是否推荐
        /// </summary>
        public bool IsAuditing
        {
            set { _isauditing = value; }
            get { return _isauditing; }
        }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int? OrderID
        {
            set { _orderid = value; }
            get { return _orderid; }
        }
        /// <summary>
        /// 深度
        /// </summary>
        public int? Depth
        {
            set { _depth = value; }
            get { return _depth; }
        }
        /// <summary>
        /// 跟类别ID
        /// </summary>
        public int? RootID
        {
            set { _rootid = value; }
            get { return _rootid; }
        }
        /// <summary>
        /// 父编号层级关系
        /// </summary>
        public string ChannelFIDS
        {
            set { _channelfids = value; }
            get { return _channelfids; }
        }
        #endregion Model

    }
}

