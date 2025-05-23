using System;
using System.Collections.Generic;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_LotteryMenu 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
    public class PBnet_LotteryMenu : IComparer<Pbzx.Model.PBnet_LotteryMenu>
	{
		public PBnet_LotteryMenu()
		{
            _intid = 0;
            _nvarname = "";
            _nvarclass = "";
            _intclass_orderid = 0;
            _nvarorderid = 0;
            _intcase = 0;
            _nvarapp_name = "";
            _nvarlott_date = "";
            _url = "";
            _isRefresh = true;
            _issueLen = 7;

        }
        #region Model
        private int _intid;
        private string _nvarname;
        private string _nvarclass;
        private int? _intclass_orderid;
        private int _nvarorderid;
        private bool _bitis_show;
        private bool _bitState;
        private int? _intcase;
        private string _nvarapp_name;
        private string _nvarlott_date;
        private string _url;
        private int? _daylottcount;
        private string _timelist;
        private int? _lotttypecount;
        private string _lotttypeinfo;
        private string _lottwebsites;
        private string _mark;
        private bool _isRefresh;
        private int _issueLen;

        private string _issueInfo;

        /// <summary>
        /// 期号信息
        /// </summary>
        public string IssueInfo
        {
            get { return _issueInfo; }
            set { _issueInfo = value; }
        }

        public int IssueLen
        {
            get { return _issueLen; }
            set { _issueLen = value; }
        }

        public bool IsRefresh
        {
            get { return _isRefresh; }
            set { _isRefresh = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int IntId
        {
            set { _intid = value; }
            get { return _intid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NvarName
        {
            set { _nvarname = value; }
            get { return _nvarname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NvarClass
        {
            set { _nvarclass = value; }
            get { return _nvarclass; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IntClass_OrderId
        {
            set { _intclass_orderid = value; }
            get { return _intclass_orderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int NvarOrderId
        {
            set { _nvarorderid = value; }
            get { return _nvarorderid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool BitIs_show
        {
            set { _bitis_show = value; }
            get { return _bitis_show; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool BitState
        {
            set { _bitState = value; }
            get { return _bitState; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IntCase
        {
            set { _intcase = value; }
            get { return _intcase; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NvarApp_name
        {
            set { _nvarapp_name = value; }
            get { return _nvarapp_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string NvarLott_date
        {
            set { _nvarlott_date = value; }
            get { return _nvarlott_date; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            set { _url = value; }
            get { return _url; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? DayLottCount
        {
            set { _daylottcount = value; }
            get { return _daylottcount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TimeList
        {
            set { _timelist = value; }
            get { return _timelist; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LottTypeCount
        {
            set { _lotttypecount = value; }
            get { return _lotttypecount; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LottTypeInfo
        {
            set { _lotttypeinfo = value; }
            get { return _lotttypeinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LottWebsites
        {
            set { _lottwebsites = value; }
            get { return _lottwebsites; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mark
        {
            set { _mark = value; }
            get { return _mark; }
        }
        #endregion Model

        private bool _isDesc;

        public bool IsDesc
        {
            get { return _isDesc; }
            set { _isDesc = value; }
        }

        //比较排序
        #region IComparer<PBnet_LotteryMenu> 成员

        public int Compare(PBnet_LotteryMenu x, PBnet_LotteryMenu y)
        {
            if (IsDesc)
            {
                return x.NvarOrderId - y.NvarOrderId;
            }
            else
            {
                return y.NvarOrderId.CompareTo(x.NvarOrderId);
            }
        }

        #endregion
    }
}

