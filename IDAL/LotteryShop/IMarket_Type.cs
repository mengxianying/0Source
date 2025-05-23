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
    public interface IMarket_Type
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// ����һ������
        /// </summary>
       int Add(Pbzx.Model.Market_Type main);
        /// <summary>
        /// ����һ������
        /// </summary>
       int Update(Pbzx.Model.Market_Type main);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Market_Type GetModel(int ID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);

        /// <summary>
        /// ���ǰ��������
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        #endregion
    }
}
