using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// ���ݽӿڲ�
    /// �����ˣ�����ΰ
    /// ����ʱ�䣺2010-10-25
    /// </summary>
   public interface IMarket_ApplicationItem
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// ����һ������
        /// </summary>
       int Add(Pbzx.Model.Market_ApplicationItem main);
        /// <summary>
        /// ����һ������
        /// </summary>
       int Update(Pbzx.Model.Market_ApplicationItem main);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
       Pbzx.Model.Market_ApplicationItem GetMain(int ID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion
    }
}
