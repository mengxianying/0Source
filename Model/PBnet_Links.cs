using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_Links ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_Links
    {
        public PBnet_Links()
        {
            _modifytime = DateTime.Now;
        }
        #region Model
        private int _intid;
        private int _intlinktype;
        private string _intsitename;
        private string _ntesiteurl;
        private string _ntesiteintro;
        private string _ntelogourl;
        private string _nvarsiteadmin;
        private string _nvaremail;
        private string _nvarsitepassword;
        private bool _bitisgood;
        private int _bitisok;
        private DateTime? _modifytime;
        private int? _sortorder;
        private string _qq;
        private string _tel;

        private string _remark;

        /// <summary>
        /// ��ע
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// �������ӱ�ţ������Զ�������
        /// </summary>
        public int IntID
        {
            set { _intid = value; }
            get { return _intid; }
        }
        /// <summary>
        /// ��������
        /// </summary>
        public int IntLinkType
        {
            set { _intlinktype = value; }
            get { return _intlinktype; }
        }
        /// <summary>
        /// վ������
        /// </summary>
        public string IntSiteName
        {
            set { _intsitename = value; }
            get { return _intsitename; }
        }
        /// <summary>
        /// վ��URL
        /// </summary>
        public string NteSiteUrl
        {
            set { _ntesiteurl = value; }
            get { return _ntesiteurl; }
        }
        /// <summary>
        /// վ����
        /// </summary>
        public string NteSiteIntro
        {
            set { _ntesiteintro = value; }
            get { return _ntesiteintro; }
        }
        /// <summary>
        /// վ��logo��ַ
        /// </summary>
        public string NteLogoUrl
        {
            set { _ntelogourl = value; }
            get { return _ntelogourl; }
        }
        /// <summary>
        /// վ������
        /// </summary>
        public string NvarSiteAdmin
        {
            set { _nvarsiteadmin = value; }
            get { return _nvarsiteadmin; }
        }
        /// <summary>
        /// ��ϵ�ʼ�
        /// </summary>
        public string NvarEmail
        {
            set { _nvaremail = value; }
            get { return _nvaremail; }
        }
        /// <summary>
        /// վ������
        /// </summary>
        public string NvarSitePassword
        {
            set { _nvarsitepassword = value; }
            get { return _nvarsitepassword; }
        }
        /// <summary>
        /// �Ƽ�վ��(1���Ƽ���0�����Ƽ�)
        /// </summary>
        public bool BitIsGood
        {
            set { _bitisgood = value; }
            get { return _bitisgood; }
        }
        /// <summary>
        /// �Ƿ����(1���Ѿ���ˣ�0��δ���)
        /// </summary>
        public int BitIsOK
        {
            set { _bitisok = value; }
            get { return _bitisok; }
        }
        /// <summary>
        /// ��������ʱ��
        /// </summary>
        public DateTime? ModifyTime
        {
            set { _modifytime = value; }
            get { return _modifytime; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int? SortOrder
        {
            set { _sortorder = value; }
            get { return _sortorder; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QQ
        {
            set { _qq = value; }
            get { return _qq; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        #endregion Model

    }
}
