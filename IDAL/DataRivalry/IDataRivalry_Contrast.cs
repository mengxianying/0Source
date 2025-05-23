using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IDataRivalry_Contrast ��ժҪ˵����
    /// </summary>
    public interface IDataRivalry_Contrast
    {
        #region  ��Ա����
        /// <summary>
        /// �õ����ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ct_id);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.DataRivalry_Contrast model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.DataRivalry_Contrast model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ct_id);

        /// <summary>
        /// ɾ��һ������ ������Ϣ��ID 
        /// </summary>
        int DeleteJoint(int Ct_drID);

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.DataRivalry_Contrast GetModel(int ct_id);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);


        #endregion  ��Ա����
    }
}
