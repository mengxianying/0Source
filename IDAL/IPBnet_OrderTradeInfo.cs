using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IPBnet_OrderTradeInfo ��ժҪ˵����
    /// </summary>
    public interface IPBnet_OrderTradeInfo
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int TradeID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.PBnet_OrderTradeInfo model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Pbzx.Model.PBnet_OrderTradeInfo model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(int TradeID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.PBnet_OrderTradeInfo GetModel(int TradeID);
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
