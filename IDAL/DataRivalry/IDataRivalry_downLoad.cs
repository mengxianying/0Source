using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IDataRivalry_downLoad ��ժҪ˵����
    /// </summary>
    public interface IDataRivalry_downLoad
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int Dl_id);
        bool Exists(int Dl_ufID, string Dl_name);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.DataRivalry_downLoad model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.DataRivalry_downLoad model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int Dl_id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.DataRivalry_downLoad GetModel(int Dl_id);
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
