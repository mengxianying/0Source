using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// �ӿڲ�IPBnet_Soft ��ժҪ˵����
	/// </summary>
	public interface IPBnet_Soft
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int PBnet_SoftID);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(Pbzx.Model.PBnet_Soft model);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Update(Pbzx.Model.PBnet_Soft model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		int Delete(int PBnet_SoftID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Pbzx.Model.PBnet_Soft GetModel(int PBnet_SoftID);
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

        /// <summary>
        /// ִ��sql���,������Ӱ������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteBySql(string sql);
	}
}
