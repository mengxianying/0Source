using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IPBnet_News ��ժҪ˵����
    /// </summary>
    public interface IPBnet_News
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int IntID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.PBnet_News model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.PBnet_News model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int IntID);
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.PBnet_News GetModel(int IntID);
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
        /// ִ��sql���,������Ӱ������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteBySql(string sql);
        DataTable Query(string sql);

    }
}
