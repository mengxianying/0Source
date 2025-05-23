using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    public interface IChipped_LaunchInfo
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(string QNumber);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.chipped_LaunchInfo model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.chipped_LaunchInfo model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(string QNumber);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.chipped_LaunchInfo GetModel(string QNumber);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
        DataSet QuerySet(string sql);
        #endregion  ��Ա����

    }
}
