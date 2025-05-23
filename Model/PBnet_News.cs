using System;
namespace Pbzx.Model
{
    /// <summary>
    /// ʵ����PBnet_News ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
    /// </summary>
    [Serializable]
    public class PBnet_News
    {
        public PBnet_News()
        {
            _pagenum = 1;
            _fileexname = ".htm";
            _effectdate = DateTime.Now;
            _datdateandtime = DateTime.Now;
            _varpicurl = "";
        }
        #region Model
        private int _intid;
        private string _nvartitle;
        private string _nvarshorttitle;
        private string _ntecontent;
        private string _nvarauthor;
        private DateTime _datdateandtime;
        private int? _intchannelid;
        private int? _intshowtype;
        private bool _bitispass;
        private int? _bitistop;
        private bool _bitishot;
        private string _intdisposition;
        private int? _intclick;
        private string _varpicurl;
        private string _varoperator;
        private int? _intorderid;
        private string _nkey;
        private string _metadesc;
        private string _source;
        private string _sourceurl;
        private string _attribute;
        private string _randomfilename;
        private DateTime? _effectdate;
        private string _templet;
        private string _savepath;
        private string _fileexname;
        private bool _isstatic;
        private int? _pagenum;
        private bool _showindex;
        private bool _showinsoft;
        private int _InWeiXin;

        public int InWeiXin { 
            set{_InWeiXin =value;}
            get{ return _InWeiXin;}
        }
        
        /// <summary>
        /// ���ű��(�Զ�����)
        /// </summary>
        public int IntID
        {
            set { _intid = value; }
            get { return _intid; }
        }
        /// <summary>
        /// ���ű���
        /// </summary>
        public string NvarTitle
        {
            set { _nvartitle = value; }
            get { return _nvartitle; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NvarShortTitle
        {
            set { _nvarshorttitle = value; }
            get { return _nvarshorttitle; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string NteContent
        {
            set { _ntecontent = value; }
            get { return _ntecontent; }
        }
        /// <summary>
        /// ����
        /// </summary>
        public string NvarAuthor
        {
            set { _nvarauthor = value; }
            get { return _nvarauthor; }
        }
        /// <summary>
        /// ���ʱ��
        /// </summary>
        public DateTime DatDateAndTime
        {
            set { _datdateandtime = value; }
            get { return _datdateandtime; }
        }
        /// <summary>
        /// ����Ƶ��ID
        /// </summary>
        public int? IntChannelID
        {
            set { _intchannelid = value; }
            get { return _intchannelid; }
        }
        /// <summary>
        /// ���������
        /// </summary>
        public int? IntShowType
        {
            set { _intshowtype = value; }
            get { return _intshowtype; }
        }
        /// <summary>
        /// �Ƿ���ˣ�1:�����,0:δ��ˣ�
        /// </summary>
        public bool BitIsPass
        {
            set { _bitispass = value; }
            get { return _bitispass; }
        }
        /// <summary>
        /// �Ƿ��ö�(0�����ö���1���ö�)
        /// </summary>
        public int? BitIsTop
        {
            set { _bitistop = value; }
            get { return _bitistop; }
        }
        /// <summary>
        /// �Ƿ����ţ�1�����ţ�0���������ţ�
        /// </summary>
        public bool BitIsHot
        {
            set { _bitishot = value; }
            get { return _bitishot; }
        }
        /// <summary>
        /// ��ʾλ��(1:������Ѷ�õ�Ƭ,2:��ҳͷ���ö���3:��ҳ�������ö��ȵ�)
        /// </summary>
        public string IntDisPosition
        {
            set { _intdisposition = value; }
            get { return _intdisposition; }
        }
        /// <summary>
        /// �������
        /// </summary>
        public int? IntClick
        {
            set { _intclick = value; }
            get { return _intclick; }
        }
        /// <summary>
        /// ͼƬ·��
        /// </summary>
        public string VarPicUrl
        {
            set { _varpicurl = value; }
            get { return _varpicurl; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public string VarOperator
        {
            set { _varoperator = value; }
            get { return _varoperator; }
        }
        /// <summary>
        /// ������
        /// </summary>
        public int? IntOrderID
        {
            set { _intorderid = value; }
            get { return _intorderid; }
        }
        /// <summary>
        /// ���Źؼ��֣�ÿ���ؼ�����,�ָ
        /// </summary>
        public string NKey
        {
            set { _nkey = value; }
            get { return _nkey; }
        }
        /// <summary>
        /// �ؼ�������
        /// </summary>
        public string Metadesc
        {
            set { _metadesc = value; }
            get { return _metadesc; }
        }
        /// <summary>
        /// ������Դ
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// ��Դ��ַ
        /// </summary>
        public string SourceUrl
        {
            set { _sourceurl = value; }
            get { return _sourceurl; }
        }
        /// <summary>
        /// ��������(0:ͼƬ1:�õ�Ƭ2��ͷ��3������4������)
        /// </summary>
        public string Attribute
        {
            set { _attribute = value; }
            get { return _attribute; }
        }
        /// <summary>
        /// ��������ļ���
        /// </summary>
        public string RandomFileName
        {
            set { _randomfilename = value; }
            get { return _randomfilename; }
        }
        /// <summary>
        /// ����ʱ��
        /// </summary>
        public DateTime? EffectDate
        {
            set { _effectdate = value; }
            get { return _effectdate; }
        }
        /// <summary>
        /// ģ��
        /// </summary>
        public string Templet
        {
            set { _templet = value; }
            get { return _templet; }
        }
        /// <summary>
        /// ����·��
        /// </summary>
        public string SavePath
        {
            set { _savepath = value; }
            get { return _savepath; }
        }
        /// <summary>
        /// ��׺��
        /// </summary>
        public string FileEXName
        {
            set { _fileexname = value; }
            get { return _fileexname; }
        }
        /// <summary>
        /// �Ƿ��Ѿ����ɾ�̬ҳ��
        /// </summary>
        public bool IsStatic
        {
            set { _isstatic = value; }
            get { return _isstatic; }
        }
        /// <summary>
        /// �м�ҳ
        /// </summary>
        public int? PageNum
        {
            set { _pagenum = value; }
            get { return _pagenum; }
        }
        /// <summary>
        /// �Ƿ���ҳ��ʾ
        /// </summary>
        public bool ShowIndex
        {
            set { _showindex = value; }
            get { return _showindex; }
        }
        /// <summary>
        /// �Ƿ������Ƕ
        /// </summary>
        public bool ShowInSoft
        {
            set { _showinsoft = value; }
            get { return _showinsoft; }
        }
        #endregion Model

    }
}

