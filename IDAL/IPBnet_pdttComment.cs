using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// �ӿڲ�IPBnet_pdttComment ��ժҪ˵����
	/// </summary>
	public interface IPBnet_pdttComment
	{
		#region  ��Ա����
		/// <summary>
		/// �õ����ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int pb_CommentID);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(Pbzx.Model.PBnet_pdttComment model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(Pbzx.Model.PBnet_pdttComment model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(int pb_CommentID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Pbzx.Model.PBnet_pdttComment GetModel(int pb_CommentID);
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
