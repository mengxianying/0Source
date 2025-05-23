using System;
using System.Collections.Generic;
using System.Text;

using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IDataRivalry_UpLoadFile ��ժҪ˵����
    /// </summary>
    public interface IDataRivalry_UpLoadFile
    {
        #region  ��Ա����
        /// <summary>
        /// �õ����ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int F_drID);
        /// <summary>
        /// �Ƿ���ڼ�¼
        /// </summary>
        /// <param name="UserName">�û���</param>
        /// <param name="FileName">�ļ���</param>
        /// <returns></returns>
        bool Exists(string UserName, string FileName, int FileSize);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.DataRivalry_UpLoadFile model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.DataRivalry_UpLoadFile model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int F_drID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.DataRivalry_UpLoadFile GetModel(int F_drID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        DataSet GetListDesc(string strWhere);

        DataSet GetListView(string strWhere);

        #endregion  ��Ա����
    }
}