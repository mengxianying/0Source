using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// ���ݽӿڲ�
    /// �����ˣ�����ΰ
    /// ����ʱ�䣺2010-10-20
    /// </summary>
    public interface IMarket_TypeConfigure
    {
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		bool Exists(int ConfigureID);

		/// <summary>
		/// ����һ������
		/// </summary>
	    int Add(Pbzx.Model.Market_TypeConfigure model);
		
		/// <summary>
		/// ����һ������
		/// </summary>
	    void Update(Pbzx.Model.Market_TypeConfigure model);
		

		/// <summary>
		/// ɾ��һ������
		/// </summary>
	     void Delete(int ConfigureID);
		


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		Pbzx.Model.Market_TypeConfigure GetModel(int ConfigureID);
		
			
			

		/// <summary>
		/// ��������б�
		/// </summary>
	    DataSet GetList(string strWhere);

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);



		#endregion  ��Ա����
    }
}
