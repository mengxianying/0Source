using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// �ӿڲ�IPBnet_jjqi ��ժҪ˵����
	/// </summary>
	public interface IPBnet_jjqi
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int jiid);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(Pbzx.Model.PBnet_jjqi model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(Pbzx.Model.PBnet_jjqi model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int jiid);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Pbzx.Model.PBnet_jjqi GetModel(int jiid);
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
