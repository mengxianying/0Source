using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IPBnet_SchoolType ��ժҪ˵����
    /// </summary>
    public interface IPBnet_SchoolType
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int IntNewsTypeID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.PBnet_SchoolType model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.PBnet_SchoolType model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int IntNewsTypeID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.PBnet_SchoolType GetModel(int IntNewsTypeID);
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
        DataTable Query(string sql);
    }
}
