using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�ICL_PrintLine ��ժҪ˵����
    /// </summary>
    public interface ICL_PrintLine
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.CL_PrintLine model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.CL_PrintLine model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.CL_PrintLine GetModel(int ID);
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
