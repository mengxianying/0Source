using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.Model;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// ����Ϣ�ӿ���
    /// 2010-9-16
    /// --------����ΰ
    /// </summary>
    public interface ICM_Main
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.CM_Main main);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.CM_Main main);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.CM_Main GetMain(int ID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion
    }
}
