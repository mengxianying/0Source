using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_qjqi ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class PBnet_qjqi
	{
		public PBnet_qjqi()
		{}
		#region Model
		private int _qiuid;
		private int? _qname;
		/// <summary>
		/// 
		/// </summary>
		public int qiuid
		{
			set{ _qiuid=value;}
			get{return _qiuid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? qname
		{
			set{ _qname=value;}
			get{return _qname;}
		}
		#endregion Model

	}
}

