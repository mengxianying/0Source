using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_ADRecord ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	public class PBnet_ADRecord
	{
		public PBnet_ADRecord()
		{}
		#region Model
		private long _id;
		private long _pb_adid;
		private DateTime _pb_vstime;
		private string _pb_vsip;
		/// <summary>
		/// 
		/// </summary>
		public long id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public long pb_ADid
		{
			set{ _pb_adid=value;}
			get{return _pb_adid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime pb_VsTime
		{
			set{ _pb_vstime=value;}
			get{return _pb_vstime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string pb_VsIP
		{
			set{ _pb_vsip=value;}
			get{return _pb_vsip;}
		}
		#endregion Model

	}
}

