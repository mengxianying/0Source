using System;
namespace Pbzx.Model
{
	/// <summary>
	/// 实体类CstSoftware 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	public class CstSoftware
	{
		public CstSoftware()
		{}
		#region Model
		private int _cstid;
		private string _cstname;
		private int _softwaretype;
		private string _softwarename;
		private string _softwarenamecolor;
		private int _installtype;
		private string _installname;
		private string _installnamecolor;
		private int? _flag;
		private int? _yearmoney;
		private int? _lifemoney;

        private int _versiontype;
        private string _versiontypename;


        /// <summary>
        /// 版本类型(0:全能版,1专业版,2 标准版,3 免费版,4 胆杀版,5 睿智版,255无效版)
        /// </summary>
        public int VersionType
        {
            set { _versiontype = value; }
            get { return _versiontype; }
        }
        /// <summary>
        /// 版本类型名称(versionType字段大于0小于200)的前台显示出来
        /// </summary>
        public string VersionTypeName
        {
            set { _versiontypename = value; }
            get { return _versiontypename; }
        }


		/// <summary>
		/// 
		/// </summary>
		public int CstID
		{
			set{ _cstid=value;}
			get{return _cstid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CstName
		{
			set{ _cstname=value;}
			get{return _cstname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int SoftwareType
		{
			set{ _softwaretype=value;}
			get{return _softwaretype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SoftwareName
		{
			set{ _softwarename=value;}
			get{return _softwarename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string SoftwareNameColor
		{
			set{ _softwarenamecolor=value;}
			get{return _softwarenamecolor;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int InstallType
		{
			set{ _installtype=value;}
			get{return _installtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InstallName
		{
			set{ _installname=value;}
			get{return _installname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string InstallNameColor
		{
			set{ _installnamecolor=value;}
			get{return _installnamecolor;}
		}
		/// <summary>
		/// 0:private  1:public
		/// </summary>
		public int? Flag
		{
			set{ _flag=value;}
			get{return _flag;}
		}
		/// <summary>
		/// 年费
		/// </summary>
		public int? YearMoney
		{
			set{ _yearmoney=value;}
			get{return _yearmoney;}
		}
		/// <summary>
		/// 终身费
		/// </summary>
		public int? LifeMoney
		{
			set{ _lifemoney=value;}
			get{return _lifemoney;}
		}
		#endregion Model

	}
}

