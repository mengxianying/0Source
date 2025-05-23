using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    public interface IChipped_Info
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(string QNumber);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Chipped_Info model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.Chipped_Info model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(string QNumber);
        int Delete(string QNumber, string username);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Chipped_Info GetModel(string QNumber);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        DataSet GetList(int Top, string strWhere, string filedOrder);
        #endregion  ��Ա����

    }
}
