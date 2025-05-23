using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// ���ݽӿڲ�
    /// �����ˣ�����ΰ
    /// ����ʱ�䣺2010-10-20
    /// </summary>
    public interface IMarket_appendItem
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int Id);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Market_appendItem model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.Market_appendItem model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int Id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Market_appendItem GetModel(int Id);
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
