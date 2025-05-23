using System;
using System.Collections.Generic;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_BulletinType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_BulletinType : IComparer<Pbzx.Model.PBnet_BulletinType>
    {
        public PBnet_BulletinType()
        { }
        #region Model
        private int _intnewstypeid;
        private string _vartypename;
        private int _inttypefid;
        private int? _inttypelevel;
        private bool _bitcomment;
        private bool _bitisauditing;
        private string _intorderid;
        private int? _depth;
        private int? _rootid;
        private string _modulefids;
        private string _typeenname;

        private int _discount;
        private int _intsortid;

        /// <summary>
        /// �����
        /// </summary>
        public int IntNewsTypeID
        {
            set { _intnewstypeid = value; }
            get { return _intnewstypeid; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string VarTypeName
        {
            set { _vartypename = value; }
            get { return _vartypename; }
        }
        /// <summary>
        /// ��ID
        /// </summary>
        public int IntTypeFID
        {
            set { _inttypefid = value; }
            get { return _inttypefid; }
        }
        /// <summary>
        /// Ȩ��
        /// </summary>
        public int? IntTypeLevel
        {
            set { _inttypelevel = value; }
            get { return _inttypelevel; }
        }
        /// <summary>
        /// �Ƿ�����
        /// </summary>
        public bool BitComment
        {
            set { _bitcomment = value; }
            get { return _bitcomment; }
        }
        /// <summary>
        /// �Ƿ����
        /// </summary>
        public bool BitIsAuditing
        {
            set { _bitisauditing = value; }
            get { return _bitisauditing; }
        }
        /// <summary>
        /// �����ַ���
        /// </summary>
        public string IntOrderID
        {
            set { _intorderid = value; }
            get { return _intorderid; }
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
        /// �������
        /// </summary>
        public int? RootID
        {
            set { _rootid = value; }
            get { return _rootid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ModuleFIDS
        {
            set { _modulefids = value; }
            get { return _modulefids; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeEnName
        {
            set { _typeenname = value; }
            get { return _typeenname; }
        }

        /// <summary>
        /// ��ʾ����
        /// </summary>
        public int DisCount
        {
            set { _discount = value; }
            get { return _discount; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int IntSortID
        {
            set { _intsortid = value; }
            get { return _intsortid; }
        }
        #endregion Model



        #region IComparer<PBnet_BulletinType> ��Ա

        private bool _isDesc = true;

        public bool IsDesc
        {
            get { return _isDesc; }
            set { _isDesc = value; }
        }
        public int Compare(PBnet_BulletinType x, PBnet_BulletinType y)
        {
            if (IsDesc)
            {
                return (int)x.IntSortID - (int)y.IntSortID;
            }
            else
            {
                return (int)y.IntSortID - (int)x.IntSortID;
            }
        }

        #endregion


    }
}

