using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// �ӿڲ�IPBnet_NewsType ��ժҪ˵����
	/// </summary>
	public interface IPBnet_NewsType
	{
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int IntNewsTypeID);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(Pbzx.Model.PBnet_NewsType model);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Update(Pbzx.Model.PBnet_NewsType model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		int Delete(int IntNewsTypeID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Pbzx.Model.PBnet_NewsType GetModel(int IntNewsTypeID);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
        DataTable Query(string sql);
	}
}
