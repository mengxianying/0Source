using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_jjqi ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class PBnet_jjqi
	{
		public PBnet_jjqi()
		{}
		#region Model
		private int _jiid;
		private int? _jname;
		/// <summary>
		/// 
		/// </summary>
		public int jiid
		{
			set{ _jiid=value;}
			get{return _jiid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? jname
		{
			set{ _jname=value;}
			get{return _jname;}
		}
		#endregion Model

	}
}

