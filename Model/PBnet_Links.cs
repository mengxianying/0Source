using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_Links 。(属性说明自动提取数据库字段的描述信息)
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
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }
        /// <summary>
        /// 友情链接编号（主键自动增长）
        /// </summary>
        public int IntID
        {
            set { _intid = value; }
            get { return _intid; }
        }
        /// <summary>
        /// 链接类型
        /// </summary>
        public int IntLinkType
        {
            set { _intlinktype = value; }
            get { return _intlinktype; }
        }
        /// <summary>
        /// 站点名称
        /// </summary>
        public string IntSiteName
        {
            set { _intsitename = value; }
            get { return _intsitename; }
        }
        /// <summary>
        /// 站点URL
        /// </summary>
        public string NteSiteUrl
        {
            set { _ntesiteurl = value; }
            get { return _ntesiteurl; }
        }
        /// <summary>
        /// 站点简介
        /// </summary>
        public string NteSiteIntro
        {
            set { _ntesiteintro = value; }
            get { return _ntesiteintro; }
        }
        /// <summary>
        /// 站点logo地址
        /// </summary>
        public string NteLogoUrl
        {
            set { _ntelogourl = value; }
            get { return _ntelogourl; }
        }
        /// <summary>
        /// 站长姓名
        /// </summary>
        public string NvarSiteAdmin
        {
            set { _nvarsiteadmin = value; }
            get { return _nvarsiteadmin; }
        }
        /// <summary>
        /// 联系邮件
        /// </summary>
        public string NvarEmail
        {
            set { _nvaremail = value; }
            get { return _nvaremail; }
        }
        /// <summary>
        /// 站点密码
        /// </summary>
        public string NvarSitePassword
        {
            set { _nvarsitepassword = value; }
            get { return _nvarsitepassword; }
        }
        /// <summary>
        /// 推荐站点(1：推荐，0：不推荐)
        /// </summary>
        public bool BitIsGood
        {
            set { _bitisgood = value; }
            get { return _bitisgood; }
        }
        /// <summary>
        /// 是否审核(1：已经审核，0：未审核)
        /// </summary>
        public int BitIsOK
        {
            set { _bitisok = value; }
            get { return _bitisok; }
        }
        /// <summary>
        /// 加入或更改时间
        /// </summary>
        public DateTime? ModifyTime
        {
            set { _modifytime = value; }
            get { return _modifytime; }
        }
        /// <summary>
        /// 排序编号
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
