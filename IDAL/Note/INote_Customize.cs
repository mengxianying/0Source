using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�INote_Customize ��ժҪ˵����
    /// </summary>
    public interface INote_Customize
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Note_Customize model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.Note_Customize model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Note_Customize GetModel(int ID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);

        Pbzx.Model.Note_Customize GetModel(int sid, string username);

        List<Pbzx.Model.Note_Customize> GetModelByName(string username);

        List<Pbzx.Model.Note_Customize> GetModelBySid(int sid);

        #endregion  ��Ա����
    }
}
