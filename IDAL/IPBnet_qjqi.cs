using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// �ӿڲ�IPBnet_qjqi ��ժҪ˵����
	/// </summary>
	public interface IPBnet_qjqi
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int qiuid);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(Pbzx.Model.PBnet_qjqi model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(Pbzx.Model.PBnet_qjqi model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int qiuid);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Pbzx.Model.PBnet_qjqi GetModel(int qiuid);
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
