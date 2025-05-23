using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IChipped_TrackingOrders ��ժҪ˵����
    /// </summary>
    public interface IChipped_TrackingOrders
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int TrackingID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Chipped_TrackingOrders model);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool Update(Pbzx.Model.Chipped_TrackingOrders model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(int TrackingID);
        bool DeleteList(string TrackingIDlist);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Chipped_TrackingOrders GetModel(int TrackingID);
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
