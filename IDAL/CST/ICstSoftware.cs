using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�ICstSoftware ��ժҪ˵����
    /// </summary>
    public interface ICstSoftware
    {
        #region  ��Ա����
        /// <summary>
        /// �õ����ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int CstID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.CstSoftware model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.CstSoftware model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int CstID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.CstSoftware GetModel(int CstID);
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
