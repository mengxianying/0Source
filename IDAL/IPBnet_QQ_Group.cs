using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IPBnet_QQ_Group ��ժҪ˵����
    /// </summary>
    public interface IPBnet_QQ_Group
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.PBnet_QQ_Group model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int  Update(Pbzx.Model.PBnet_QQ_Group model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int  Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.PBnet_QQ_Group GetModel(int ID);
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
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  ��Ա����
    }
}
