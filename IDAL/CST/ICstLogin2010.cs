using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    public interface ICstLogin2010
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Add(Pbzx.Model.CstLogin2010 model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Pbzx.Model.CstLogin2010 model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.CstLogin2010 GetModel(int ID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
    }
}
