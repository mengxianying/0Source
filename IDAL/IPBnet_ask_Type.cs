using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// �ӿڲ�IPBnet_ask_Type ��ժҪ˵����
	/// </summary>
	public interface IPBnet_ask_Type
	{
		#region  ��Ա����
		
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int Id);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(Pbzx.Model.PBnet_ask_Type model);
		/// <summary>
		/// ����һ������
		/// </summary>
        int Update(Pbzx.Model.PBnet_ask_Type model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
        int Delete(int Id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Pbzx.Model.PBnet_ask_Type GetModel(int Id);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
	}
}
