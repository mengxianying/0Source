using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�ICL_RegisterInfo ��ժҪ˵����
    /// </summary>
    public interface ICL_RegisterInfo
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.CL_RegisterInfo model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.CL_RegisterInfo model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.CL_RegisterInfo GetModel(int ID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// ���ݷ�ҳ��������б�
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  ��Ա����

        /// <summary>
        /// ����sql����ѯ
        /// </summary>
        /// <param name="strSql">sql���</param>
        /// <returns>����ֵ</returns>
        DataSet Query(string strSql);
    }
}
