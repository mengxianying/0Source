using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IPlatformPublic_payments ��ժҪ˵����
    /// </summary>
    public interface IPlatformPublic_payments
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int Pp_id);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.PlatformPublic_payments model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.PlatformPublic_payments model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int Pp_id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.PlatformPublic_payments GetModel(int Pp_id);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
    }
}
