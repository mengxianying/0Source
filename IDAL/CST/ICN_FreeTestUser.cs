using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�ICN_FreeTestUser ��ժҪ˵����
    /// </summary>
    public interface ICN_FreeTestUser
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.CN_FreeTestUser model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.CN_FreeTestUser model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.CN_FreeTestUser GetModel(int ID);
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
