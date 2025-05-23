using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�ICN_Software ��ժҪ˵����
    /// </summary>
    public interface ICN_Software
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID, int InstallType);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.CN_Software model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int  Update(Pbzx.Model.CN_Software model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID, int InstallType);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.CN_Software GetModel(int ID, int InstallType);
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
