using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_QQ_Record 。(属性说明自动提取数据库字段的描述信息)
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
        /// 是否被锁
        /// </summary>
        public bool IsLock
        {
            get { return _IsLock; }
            set { _IsLock = value; }
        }

        /// <summary>
        /// qq号码记录表自动增长编号
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 所属qq群编号
        /// </summary>
        public int QQ_GropID
        {
            set { _qq_gropid = value; }
            get { return _qq_gropid; }
        }
        /// <summary>
        /// QQ号
        /// </summary>
        public string QQ_ID
        {
            set { _qq_id = value; }
            get { return _qq_id; }
        }
        /// <summary>
        /// 论坛名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 在线状态（0：在线，1：退出，2：被踢）
        /// </summary>
        public int OnlineState
        {
            set { _onlinestate = value; }
            get { return _onlinestate; }
        }
        /// <summary>
        /// 说明(被踢记录原因等等)
        /// </summary>
        public string QQ_Detail
        {
            set { _qq_detail = value; }
            get { return _qq_detail; }
        }
        /// <summary>
        /// 加入操作人
        /// </summary>
        public string AddManager
        {
            set { _addmanager = value; }
            get { return _addmanager; }
        }
        /// <summary>
        /// 加入时间
        /// </summary>
        public DateTime? AddTime
        {
            set { _addtime = value; }
            get { return _addtime; }
        }
        /// <summary>
        /// 退出或者被踢操作人
        /// </summary>
        public string KickOffManager
        {
            set { _kickoffmanager = value; }
            get { return _kickoffmanager; }
        }
        /// <summary>
        /// 退出时间
        /// </summary>
        public DateTime? KickOffTime
        {
            set { _kickofftime = value; }
            get { return _kickofftime; }
        }
        #endregion Model

    }
}

