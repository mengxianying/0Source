using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IFC4DData_ShangH ��ժҪ˵����
    /// </summary>
    public interface IFC4DData_ShangH
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(string issue);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.FC4DData_ShangH model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.FC4DData_ShangH model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(string issue);
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.FC4DData_ShangH GetModel(string issue);
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
