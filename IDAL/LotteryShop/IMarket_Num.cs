using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// ���ݽӿڲ�
    /// �����ˣ�����ΰ
    /// ����ʱ�䣺2010-10-22
    /// </summary>
   public interface IMarket_Num
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        /// <summary>
            /// ���ط���
            /// ������: zhouwei
            /// ����ʱ��: 2010-11-25
            /// </summary>
            /// <param name="id">��ĿID</param>
            /// <param name="expctNum">�ں�</param>
            /// <returns></returns>
       bool Exists(int id, string expctNum, string radio);
        /// <summary>
        /// ����һ������
        /// </summary>
       int Add(Pbzx.Model.Market_Num issueinfo);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.Market_Num issueinfo);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
       Pbzx.Model.Market_Num GetModel(int ID);
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
