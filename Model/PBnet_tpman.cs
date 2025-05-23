using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类PBnet_tpman 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class PBnet_tpman
	{
		public PBnet_tpman()
		{

            _lastime = DateTime.Now;
            _master_id = 0;

        }
        #region Model
        private int _master_id;
        private string _master_name;
        private string _master_password;
        private string _column_setting;
        private string _setting;
        private DateTime? _lastime;
        private string _lastip;
        private string _cookiess;
        private bool _state = false;
        private string _cpdata_setting;
        private int? _logincount = 0;
        private string _usergroup = "";
        private string _iplimit;
        private string _regionlimit;
        /// <summary>
        /// 
        /// </summary>
        public int Master_Id
        {
            set { _master_id = value; }
            get { return _master_id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Master_Name
        {
            set { _master_name = value; }
            get { return _master_name; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Master_Password
        {
            set { _master_password = value; }
            get { return _master_password; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Column_Setting
        {
            set { _column_setting = value; }
            get { return _column_setting; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Setting
        {
            set { _setting = value; }
            get { return _setting; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? LasTime
        {
            set { _lastime = value; }
            get { return _lastime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string LastIP
        {
            set { _lastip = value; }
            get { return _lastip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Cookiess
        {
            set { _cookiess = value; }
            get { return _cookiess; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool State
        {
            set { _state = value; }
            get { return _state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CpData_Setting
        {
            set { _cpdata_setting = value; }
            get { return _cpdata_setting; }
        }
        /// <summary>
        /// 登陆次数
        /// </summary>
        public int? LoginCount
        {
            set { _logincount = value; }
            get { return _logincount; }
        }
        /// <summary>
        /// 用户组名称
        /// </summary>
        public string UserGroup
        {
            set { _usergroup = value; }
            get { return _usergroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ipLimit
        {
            set { _iplimit = value; }
            get { return _iplimit; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string regionLimit
        {
            set { _regionlimit = value; }
            get { return _regionlimit; }
        }
        #endregion Model

	}
}

