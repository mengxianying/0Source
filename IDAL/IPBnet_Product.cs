using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// �ӿڲ�IPBnet_Product ��ժҪ˵����
	/// </summary>
	public interface IPBnet_Product
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int pb_SoftID);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(Pbzx.Model.PBnet_Product model);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Update(Pbzx.Model.PBnet_Product model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		int Delete(int pb_SoftID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Pbzx.Model.PBnet_Product GetModel(int pb_SoftID);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);

        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  ��Ա����
       
        /// <summary>
        /// ִ��sql���,������Ӱ������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteBySql(string sql);
        DataTable Query(string sql);
	}
}
