using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IFC3DData ��ժҪ˵����
    /// </summary>
    public interface IFC3DData
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(string issue);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.FC3DData model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.FC3DData model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(string issue);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.FC3DData GetModel(string issue);
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
