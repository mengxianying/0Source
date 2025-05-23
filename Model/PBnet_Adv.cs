using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_Adv ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_Adv
    {
        public PBnet_Adv()
        { }
        #region Model
        private long _id;
        private string _pb_sitename;
        private string _pb_siteurl;
        private string _pb_siteintro;
        private string _pb_imgurl;
        private int? _pb_imgwidth;
        private int? _pb_imgheight;
        private bool _pb_isflash;
        private bool _pb_isselected;
        private string _pb_adsetting;
        private DateTime? _pb_addtime;
        private DateTime? _pb_endtime;
        private int? _pb_peakc1;
        private int? _pb_peakc2;
        private int? _pb_peakcount;
        private int? _pb_speaknum;
        private bool _pb_adbstype;
        private int? _pb_priority;
        private int? _pb_sameip;
        private DateTime? _pb_today;
        private int? _pb_tdcount;
        private int? _pb_allcount;
        private int? _pbs_tdcount;
        private int? _pbs_allcount;
        private int? _countid;
        private string _placename;
        /// <summary>
        /// 
        /// </summary>
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// վ������
        /// </summary>
        public string pb_SiteName
        {
            set { _pb_sitename = value; }
            get { return _pb_sitename; }
        }
        /// <summary>
        /// վ���ַ
        /// </summary>
        public string pb_SiteUrl
        {
            set { _pb_siteurl = value; }
            get { return _pb_siteurl; }
        }
        /// <summary>
        /// վ����
        /// </summary>
        public string pb_SiteIntro
        {
            set { _pb_siteintro = value; }
            get { return _pb_siteintro; }
        }
        /// <summary>
        /// ͼƬ����ַ
        /// </summary>
        public string pb_ImgUrl
        {
            set { _pb_imgurl = value; }
            get { return _pb_imgurl; }
        }
        /// <summary>
        /// ͼƬ�����
        /// </summary>
        public int? pb_ImgWidth
        {
            set { _pb_imgwidth = value; }
            get { return _pb_imgwidth; }
        }
        /// <summary>
        /// ͼƬ���߶�
        /// </summary>
        public int? pb_ImgHeight
        {
            set { _pb_imgheight = value; }
            get { return _pb_imgheight; }
        }
        /// <summary>
        /// �Ƿ���flash���
        /// </summary>
        public bool pb_IsFlash
        {
            set { _pb_isflash = value; }
            get { return _pb_isflash; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool pb_IsSelected
        {
            set { _pb_isselected = value; }
            get { return _pb_isselected; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public string pb_ADSetting
        {
            set { _pb_adsetting = value; }
            get { return _pb_adsetting; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? pb_ADDTime
        {
            set { _pb_addtime = value; }
            get { return _pb_addtime; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? pb_ENDTime
        {
            set { _pb_endtime = value; }
            get { return _pb_endtime; }
        }
        /// <summary>
        /// ��ֵ1
        /// </summary>
        public int? pb_PeakC1
        {
            set { _pb_peakc1 = value; }
            get { return _pb_peakc1; }
        }
        /// <summary>
        /// ��ֵ2
        /// </summary>
        public int? pb_PeakC2
        {
            set { _pb_peakc2 = value; }
            get { return _pb_peakc2; }
        }
        /// <summary>
        /// ��ֵ
        /// </summary>
        public int? pb_PeakCount
        {
            set { _pb_peakcount = value; }
            get { return _pb_peakcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pb_sPeakNum
        {
            set { _pb_speaknum = value; }
            get { return _pb_speaknum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool pb_ADBSType
        {
            set { _pb_adbstype = value; }
            get { return _pb_adbstype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pb_Priority
        {
            set { _pb_priority = value; }
            get { return _pb_priority; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pb_SameIP
        {
            set { _pb_sameip = value; }
            get { return _pb_sameip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? pb_Today
        {
            set { _pb_today = value; }
            get { return _pb_today; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pb_TDCount
        {
            set { _pb_tdcount = value; }
            get { return _pb_tdcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pb_ALLCount
        {
            set { _pb_allcount = value; }
            get { return _pb_allcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pbs_TDCount
        {
            set { _pbs_tdcount = value; }
            get { return _pbs_tdcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? pbs_ALLCount
        {
            set { _pbs_allcount = value; }
            get { return _pbs_allcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? CountID
        {
            set { _countid = value; }
            get { return _countid; }
        }
        /// <summary>
        /// ���λ���
        /// </summary>
        public string PlaceName
        {
            set { _placename = value; }
            get { return _placename; }
        }
        #endregion Model

    }
}

