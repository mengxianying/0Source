using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_QQ_Group 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_QQ_Group
    {
        public PBnet_QQ_Group()
        {
            _id = 0;
            _qq_groupid = "";
            _qq_groupname = "";           
        }
        #region Model
        private int _id;
        private string _qq_groupid;
        private string _qq_groupname;
        private int _qq_grouptype;
        private bool _issoftgroup;
        private string _qq_groupadmin;
        private string _qq_groupdetails;
        private bool _isenable;
        private int _sortid;
        private DateTime? _createtime;
        /// <summary>
        /// 自动增长编号
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// qq群号
        /// </summary>
        public string QQ_GroupID
        {
            set { _qq_groupid = value; }
            get { return _qq_groupid; }
        }
        /// <summary>
        /// qq群名称
        /// </summary>
        public string QQ_GroupName
        {
            set { _qq_groupname = value; }
            get { return _qq_groupname; }
        }
        /// <summary>
        /// qq群类型
        /// </summary>
        public int QQ_GroupType
        {
            set { _qq_grouptype = value; }
            get { return _qq_grouptype; }
        }
        /// <summary>
        /// 是否是软件用户群
        /// </summary>
        public bool IsSoftGroup
        {
            set { _issoftgroup = value; }
            get { return _issoftgroup; }
        }
        /// <summary>
        /// qq群管理员
        /// </summary>
        public string QQ_GroupAdmin
        {
            set { _qq_groupadmin = value; }
            get { return _qq_groupadmin; }
        }
        /// <summary>
        /// qq群备注
        /// </summary>
        public string QQ_GroupDetails
        {
            set { _qq_groupdetails = value; }
            get { return _qq_groupdetails; }
        }
        /// <summary>
        /// 启用状态（0：不启用，1：启用）
        /// </summary>
        public bool IsEnable
        {
            set { _isenable = value; }
            get { return _isenable; }
        }
        /// <summary>
        /// 排序编号
        /// </summary>
        public int SortID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

    }
}
