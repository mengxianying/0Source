using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IPBnet_OrderDetail_Delegate ��ժҪ˵����
    /// </summary>
    public interface IPBnet_OrderDetail_Delegate
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(long OrderDetailID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.PBnet_OrderDetail_Delegate model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Pbzx.Model.PBnet_OrderDetail_Delegate model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(long OrderDetailID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.PBnet_OrderDetail_Delegate GetModel(long OrderDetailID);
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

        DataSet SelectOrderDetailDelegateByOrderID(string orderID);
        #endregion  ��Ա����
    }
}
