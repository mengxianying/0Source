using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڷ���
    /// ������: zhouwei
    /// ����ʱ��: 2010-11-8
    /// </summary>
    public interface IMarket_CollASAtten
    {
        #region  ��Ա����
                /// <summary>
        /// ��ȡ���ݵĸ���
        /// ������: zhouwei
        /// ����ʱ��: 2010-11-8
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <returns></returns>
        DataSet Num(string strWhere);

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);

        bool Exists(string Uname, string appName,int statc,int mark);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Market_CollASAtten mod);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.Market_CollASAtten mod);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Market_CollASAtten GetModel(int ID);
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