using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// �ӿڲ�IPBnet_ipdata ��ժҪ˵����
	/// </summary>
	public interface IPBnet_ipdata
	{
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(decimal ip1,decimal ip2);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Add(Pbzx.Model.PBnet_ipdata model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(Pbzx.Model.PBnet_ipdata model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(decimal ip1,decimal ip2);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Pbzx.Model.PBnet_ipdata GetModel(decimal ip1,decimal ip2);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	}
}
