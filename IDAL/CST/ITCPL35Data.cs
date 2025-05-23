using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�ITCPL35Data ��ժҪ˵����
    /// </summary>
    public interface ITCPL35Data
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(string issue);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Add(Pbzx.Model.TCPL35Data model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Pbzx.Model.TCPL35Data model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(string issue);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.TCPL35Data GetModel(string issue);
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
