using System;
using System.Collections.Generic;
using System.Text;


namespace Pbzx.Model
{
    public class chipped_LaunchInfo
    {
        public chipped_LaunchInfo()
		{}
        #region Model
        private string _qnumber;
        private string _title;
        private string _say;
        private DateTime? _launchtime;
        private int? _playname;
        private int? _expectnum;
        private string _choicenum;
        private string _username;
        private int? _doubles;
        private int? _share;
        private string _object;
        private int? _buyshare;
        private int? _protect;
        private int? _opens;
        private int? _commission;
        private int _winning = 0;
        private int? _purchasing;
        private int? _state;
        private decimal? _atotalmoney;
        private string _bounsallost;
        /// <summary>
        /// 
        /// </summary>
        public string QNumber
        {
            set { _qnumber = value; }
            get { return _qnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Say
        {
            set { _say = value; }
            get { return _say; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LaunchTime
        {
            set { _launchtime = value; }
            get { return _launchtime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? playName
        {
            set { _playname = value; }
            get { return _playname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ExpectNum
        {
            set { _expectnum = value; }
            get { return _expectnum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ChoiceNum
        {
            set { _choicenum = value; }
            get { return _choicenum; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? doubles
        {
            set { _doubles = value; }
            get { return _doubles; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Share
        {
            set { _share = value; }
            get { return _share; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Object
        {
            set { _object = value; }
            get { return _object; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? BuyShare
        {
            set { _buyshare = value; }
            get { return _buyshare; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Protect
        {
            set { _protect = value; }
            get { return _protect; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? opens
        {
            set { _opens = value; }
            get { return _opens; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Commission
        {
            set { _commission = value; }
            get { return _commission; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int Winning
        {
            set { _winning = value; }
            get { return _winning; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Purchasing
        {
            set { _purchasing = value; }
            get { return _purchasing; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public decimal? AtotalMoney
        {
            set { _atotalmoney = value; }
            get { return _atotalmoney; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string bounsAllost
        {
            set { _bounsallost = value; }
            get { return _bounsallost; }
        }
        #endregion Model

    }

}
