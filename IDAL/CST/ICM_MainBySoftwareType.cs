using System;
using System.Collections.Generic;
using System.Text;

using Pbzx.Model;
using System.Data;

namespace Pbzx.IDAL
{
    public interface ICM_MainBySoftwareType
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.CM_MainBySoftwareType main);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.CM_MainBySoftwareType main);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID);

        int DeleteByCM_ID(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.CM_MainBySoftwareType GetMain(int ID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion
    }
}
