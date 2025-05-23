using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�INote_Log ��ժҪ˵����
    /// </summary>
    public interface INote_Log
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Add(Pbzx.Model.Note_Log model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Pbzx.Model.Note_Log model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Note_Log GetModel(int ID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
    }
}
