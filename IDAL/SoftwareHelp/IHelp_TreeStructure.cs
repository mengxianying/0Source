using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�ISoftwareHelp_TreeStructure ��ժҪ˵����
    /// </summary>
    public interface IHelp_TreeStructure
    {
        #region  ��Ա����
        /// <summary>
        /// �õ����ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int ID);
        bool Exists(string name, string lottery, int TreeName);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Help_TreeStructure model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.Help_TreeStructure model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int ID);
        int Delete(string Noet);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Help_TreeStructure GetModel(int ID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
    }
}
