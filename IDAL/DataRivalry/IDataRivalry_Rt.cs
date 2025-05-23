using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IDataRivalry_Result ��ժҪ˵����
    /// </summary>
    public interface IDataRivalry_Rt
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int Rt_ID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.DataRivalry_Rt model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.DataRivalry_Rt model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int Rt_ID);

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int DeleteJoint(int Rt_AwardNum);
        
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.DataRivalry_Rt GetModel(int Rt_ID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
    }
}
