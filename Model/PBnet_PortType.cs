using System;
namespace Pbzx.Model
{
	/// <summary>
	/// ʵ����PBnet_PortType ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class PBnet_PortType
	{
		public PBnet_PortType()
		{}
		#region Model
		private int _porttypeid;
		private string _porttypename;
		private decimal? _portprice;
		/// <summary>
		/// �ʵݷ�ʽ���
		/// </summary>
		public int PortTypeID
		{
			set{ _porttypeid=value;}
			get{return _porttypeid;}
		}
		/// <summary>
		/// �ʵݷ�ʽ��
		/// </summary>
		public string PortTypeName
		{
			set{ _porttypename=value;}
			get{return _porttypename;}
		}
		/// <summary>
		/// �ʵݼ۸�
		/// </summary>
		public decimal? PortPrice
		{
			set{ _portprice=value;}
			get{return _portprice;}
		}
		#endregion Model

	}
}

