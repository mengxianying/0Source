using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IPBnet_Orders_Delegates ��ժҪ˵����
    /// </summary>
    public interface IPBnet_Orders_Delegates
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(string OrderID);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Add(Pbzx.Model.PBnet_Orders_Delegates model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Pbzx.Model.PBnet_Orders_Delegates model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(string OrderID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.PBnet_Orders_Delegates GetModel(string OrderID);
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
        /// <summary>
        /// ����sql����ѯ
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataSet Query(string sql);
    }
}
