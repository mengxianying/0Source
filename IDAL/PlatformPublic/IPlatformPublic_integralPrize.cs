using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IPlatformPublic_integralPrize ��ժҪ˵����
    /// </summary>
    public interface IPlatformPublic_integralPrize
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int Pip_id);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.PlatformPublic_integralPrize model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.PlatformPublic_integralPrize model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int Pip_id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.PlatformPublic_integralPrize GetModel(int Pip_id);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
    }
}
