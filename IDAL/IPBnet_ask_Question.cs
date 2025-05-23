using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// �ӿڲ�IPBnet_ask_Question ��ժҪ˵����
	/// </summary>
	public interface IPBnet_ask_Question
	{
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int Id);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(Pbzx.Model.PBnet_ask_Question model);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Update(Pbzx.Model.PBnet_ask_Question model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		int Delete(int Id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Pbzx.Model.PBnet_ask_Question GetModel(int Id);
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

        /// <summary>
        /// ��������ŵõ���������
        /// </summary>
        /// <param name="typeId">���id</param>
        /// <returns>��������</returns>
        /// author:meng
        /// date:09-08-17
        object GetCountByTypeId(string typeId);
        int ExecuteBySql(string sql);
	}
}
