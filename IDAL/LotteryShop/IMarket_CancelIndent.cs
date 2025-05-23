using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
   public interface IMarket_CancelIndent
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int CancelID);
        bool Exists(string name, int Item);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Market_CancelIndent model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.Market_CancelIndent model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int CancelID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Market_CancelIndent GetModel(int CancelID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        #endregion  ��Ա����
    }
}
