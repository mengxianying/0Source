using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IDataRivalry_Level ��ժҪ˵����
    /// </summary>
    public interface IDataRivalry_Level
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int Le_id);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.DataRivalry_Level model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.DataRivalry_Level model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int Le_id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.DataRivalry_Level GetModel(int Le_id);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
    }
}
