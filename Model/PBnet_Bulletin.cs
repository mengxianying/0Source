using System;
namespace Pbzx.Model
{
    /// <summary>
    /// 实体类PBnet_Bulletin 。(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PBnet_Bulletin
    {
        public PBnet_Bulletin()
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
        private DateTime? _datdateandtime;
        private int? _intchannelid;
        private int? _intshowtype;
        private bool _bitispass;
        private bool _bitistop;
        private string _intdisposition;
        private int? _intclick;
        private string _varpicurl;
        private string _varoperator;
        private int? _intorderid;
        private bool _bitishot;
        private string _nkey;
        private string _metadesc;
        private string _source;
        private string _sourceurl;
        private string _attribute;
        private string _randomfilename;
        private DateTime _effectdate;
        private string _templet;
        private string _savepath;
        private string _fileexname;
        private bool _isstatic;
        private int? _pagenum;

        private int _InWeiXin;

        public int InWeiXin
        {
            set { _InWeiXin = value; }
            get { return _InWeiXin; }
        }

        private bool _showIndex;
        /// <summary>
        /// 是否首页显示
        /// </summary>
        public bool ShowIndex
        {
            get { return _showIndex; }
            set { _showIndex = value; }
        }

        private bool _showInSoft;
        /// <summary>
        /// 是否软件内嵌
        /// </summary>
        public bool ShowInSoft
        {
            get { return _showInSoft; }
            set { _showInSoft = value; }
        }

        /// <summary>
        /// 公告编号(自动增长)
        /// </summary>
        public int IntID
        {
            set { _intid = value; }
            get { return _intid; }
        }
        /// <summary>
        /// 公告标题
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
        /// 内容
        /// </summary>
        public string NteContent
        {
            set { _ntecontent = value; }
            get { return _ntecontent; }
        }
        /// <summary>
        /// 作者
        /// </summary>
        public string NvarAuthor
        {
            set { _nvarauthor = value; }
            get { return _nvarauthor; }
        }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? DatDateAndTime
        {
            set { _datdateandtime = value; }
            get { return _datdateandtime; }
        }
        /// <summary>
        /// 所属频道ID
        /// </summary>
        public int? IntChannelID
        {
            set { _intchannelid = value; }
            get { return _intchannelid; }
        }
        /// <summary>
        /// 所属类别编号
        /// </summary>
        public int? IntShowType
        {
            set { _intshowtype = value; }
            get { return _intshowtype; }
        }
        /// <summary>
        /// 是否审核（1:已审核,0:未审核）
        /// </summary>
        public bool BitIsPass
        {
            set { _bitispass = value; }
            get { return _bitispass; }
        }
        /// <summary>
        /// 是否置顶(1：置顶，0：不置顶)
        /// </summary>
        public bool BitIsTop
        {
            set { _bitistop = value; }
            get { return _bitistop; }
        }
        /// <summary>
        /// 显示位置(做一个枚举，0:首页，1:**频道页,2:***频道页 等等)
        /// </summary>
        public string  IntDisPosition
        {
            set { _intdisposition = value; }
            get { return _intdisposition; }
        }
        /// <summary>
        /// 点击次数
        /// </summary>
        public int? IntClick
        {
            set { _intclick = value; }
            get { return _intclick; }
        }
        /// <summary>
        /// 图片路径
        /// </summary>
        public string VarPicUrl
        {
            set { _varpicurl = value; }
            get { return _varpicurl; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VarOperator
        {
            set { _varoperator = value; }
            get { return _varoperator; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IntOrderID
        {
            set { _intorderid = value; }
            get { return _intorderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool BitIsHot
        {
            set { _bitishot = value; }
            get { return _bitishot; }
        }
        /// <summary>
        /// 新闻关键字（每个关键字用,分割）
        /// </summary>
        public string NKey
        {
            set { _nkey = value; }
            get { return _nkey; }
        }
        /// <summary>
        /// 关键字描述
        /// </summary>
        public string Metadesc
        {
            set { _metadesc = value; }
            get { return _metadesc; }
        }
        /// <summary>
        /// 文章来源
        /// </summary>
        public string Source
        {
            set { _source = value; }
            get { return _source; }
        }
        /// <summary>
        /// 来源地址
        /// </summary>
        public string SourceUrl
        {
            set { _sourceurl = value; }
            get { return _sourceurl; }
        }
        /// <summary>
        /// 文章属性(0:图片1:幻灯片2：头条3：滚动4：焦点)
        /// </summary>
        public string Attribute
        {
            set { _attribute = value; }
            get { return _attribute; }
        }
        /// <summary>
        /// 文章随机文件名
        /// </summary>
        public string RandomFileName
        {
            set { _randomfilename = value; }
            get { return _randomfilename; }
        }
        /// <summary>
        /// 过期时间
        /// </summary>
        public DateTime EffectDate
        {
            set { _effectdate = value; }
            get { return _effectdate; }
        }
        /// <summary>
        /// 文章模板
        /// </summary>
        public string Templet
        {
            set { _templet = value; }
            get { return _templet; }
        }
        /// <summary>
        /// 保存路径
        /// </summary>
        public string SavePath
        {
            set { _savepath = value; }
            get { return _savepath; }
        }
        /// <summary>
        /// 文章后缀名
        /// </summary>
        public string FileEXName
        {
            set { _fileexname = value; }
            get { return _fileexname; }
        }
        /// <summary>
        /// 是否已经生成静态页面
        /// </summary>
        public bool IsStatic
        {
            set { _isstatic = value; }
            get { return _isstatic; }
        }
        /// <summary>
        /// 有几页
        /// </summary>
        public int? PageNum
        {
            set { _pagenum = value; }
            get { return _pagenum; }
        }
        #endregion Model

    }
}

