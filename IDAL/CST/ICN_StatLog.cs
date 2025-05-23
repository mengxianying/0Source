using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�ICN_StatLog ��ժҪ˵����
    /// </summary>
    public interface ICN_StatLog
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.CN_StatLog model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.CN_StatLog model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.CN_StatLog GetModel(int ID);
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
