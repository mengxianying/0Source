using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_QQ_Group ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// �Զ��������
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// qqȺ��
        /// </summary>
        public string QQ_GroupID
        {
            set { _qq_groupid = value; }
            get { return _qq_groupid; }
        }
        /// <summary>
        /// qqȺ����
        /// </summary>
        public string QQ_GroupName
        {
            set { _qq_groupname = value; }
            get { return _qq_groupname; }
        }
        /// <summary>
        /// qqȺ����
        /// </summary>
        public int QQ_GroupType
        {
            set { _qq_grouptype = value; }
            get { return _qq_grouptype; }
        }
        /// <summary>
        /// �Ƿ�������û�Ⱥ
        /// </summary>
        public bool IsSoftGroup
        {
            set { _issoftgroup = value; }
            get { return _issoftgroup; }
        }
        /// <summary>
        /// qqȺ����Ա
        /// </summary>
        public string QQ_GroupAdmin
        {
            set { _qq_groupadmin = value; }
            get { return _qq_groupadmin; }
        }
        /// <summary>
        /// qqȺ��ע
        /// </summary>
        public string QQ_GroupDetails
        {
            set { _qq_groupdetails = value; }
            get { return _qq_groupdetails; }
        }
        /// <summary>
        /// ����״̬��0�������ã�1�����ã�
        /// </summary>
        public bool IsEnable
        {
            set { _isenable = value; }
            get { return _isenable; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int SortID
        {
            set { _sortid = value; }
            get { return _sortid; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? CreateTime
        {
            set { _createtime = value; }
            get { return _createtime; }
        }
        #endregion Model

    }
}
