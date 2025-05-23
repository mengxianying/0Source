using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// �ӿڲ�IPBnet_ProductPrice ��ժҪ˵����
	/// </summary>
	public interface IPBnet_ProductPrice
	{
		#region  ��Ա����

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int IntPriceID);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Add(Pbzx.Model.PBnet_ProductPrice model);
		/// <summary>
		/// ����һ������
		/// </summary>
		int Update(Pbzx.Model.PBnet_ProductPrice model);
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		int Delete(int IntPriceID);
		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Pbzx.Model.PBnet_ProductPrice GetModel(int IntPriceID);
		/// <summary>
		/// ��������б�
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// ���ݷ�ҳ��������б�
		/// </summary>
//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        DataSet SelectAllProductPrice();

         /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere, string orderbyStr);

		#endregion  ��Ա����
	}
}
