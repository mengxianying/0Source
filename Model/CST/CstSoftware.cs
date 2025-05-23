using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����CstSoftware ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
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
        /// �汾����(0:ȫ�ܰ�,1רҵ��,2 ��׼��,3 ��Ѱ�,4 ��ɱ��,5 ��ǰ�,255��Ч��)
        /// </summary>
        public int VersionType
        {
            set { _versiontype = value; }
            get { return _versiontype; }
        }
        /// <summary>
        /// �汾��������(versionType�ֶδ���0С��200)��ǰ̨��ʾ����
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
		/// ���
		/// </summary>
		public int? YearMoney
		{
			set{ _yearmoney=value;}
			get{return _yearmoney;}
		}
		/// <summary>
		/// �����
		/// </summary>
		public int? LifeMoney
		{
			set{ _lifemoney=value;}
			get{return _lifemoney;}
		}
		#endregion Model

	}
}

