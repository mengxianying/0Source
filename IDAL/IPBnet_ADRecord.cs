using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// �ӿڲ�IPBnet_ADRecord ��ժҪ˵����
	/// </summary>
	public interface IPBnet_ADRecord
	{
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(Pbzx.Model.PBnet_ADRecord model);
		/// <summary>
		/// ����һ������
		/// </summary>
		void Update(Pbzx.Model.PBnet_ADRecord model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		void Delete(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Pbzx.Model.PBnet_ADRecord GetModel(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id);
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
