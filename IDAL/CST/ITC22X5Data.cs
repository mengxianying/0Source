using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�ITC22X5Data ��ժҪ˵����
    /// </summary>
    public interface ITC22X5Data
    {
        #region  ��Ա����
        /// <summary>
        /// �õ����ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int issue);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.TC22X5Data model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.TC22X5Data model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int issue);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.TC22X5Data GetModel(int issue);
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
