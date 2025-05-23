using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�ISoftwareHelp_Contrast ��ժҪ˵����
    /// </summary>
    public interface IHelp_Contrast
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int Ct_id);
        bool Exists(string Ct_TreeNum, string Ct_software);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Help_Contrast model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.Help_Contrast model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int Ct_id);
        int DeleteID(int Ct_TreeNum);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Help_Contrast GetModel(int Ct_id);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  ��Ա����
    }
}