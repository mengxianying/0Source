using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�ISoftwareHelp_HelpName ��ժҪ˵����
    /// </summary>
    public interface IHelp_HelpName
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int Hn_ID);
        bool Exists(string name);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Help_HelpName model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.Help_HelpName model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int Hn_ID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Help_HelpName GetModel(int Hn_ID);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
    }
}
