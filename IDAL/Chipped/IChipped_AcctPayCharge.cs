using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IChipped_AcctPayCharge ��ժҪ˵����
    /// </summary>
    public interface IChipped_AcctPayCharge
    {
        #region  ��Ա����
        /// <summary>
        /// �õ����ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int apcID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Chipped_AcctPayCharge model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Pbzx.Model.Chipped_AcctPayCharge model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(int apcID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Chipped_AcctPayCharge GetModel(int apcID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
    }
}

