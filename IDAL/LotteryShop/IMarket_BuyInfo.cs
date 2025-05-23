using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IMarket_BuyInfo ��ժҪ˵����
    /// ������: zhouwei
    /// ����ʱ��: 2010-10-22
    /// </summary>
    public interface IMarket_BuyInfo
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(string buyuserid, int issueInfoId);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Market_BuyInfo buy);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.Market_BuyInfo buy);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Market_BuyInfo GetModel(int issueInfoId);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);

        //����һ��datatable
        DataTable Query(string sql);
        //����һ��Dataset ����
        DataSet QuerySet(string sql);
        #endregion
    }
}
