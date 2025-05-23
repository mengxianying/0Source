using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IFCSSCData_JiangX ��ժҪ˵����
    /// </summary>
    public interface IFCSSCData_JiangX
    {
        #region  ��Ա����
        /// <summary>
        /// �õ����ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int Issue);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.FCSSCData_JiangX model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.FCSSCData_JiangX model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int Issue);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.FCSSCData_JiangX GetModel(int Issue);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// ���ݷ�ҳ��������б�
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  ��Ա����
    }
}
