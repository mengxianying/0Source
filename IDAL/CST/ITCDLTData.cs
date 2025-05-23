using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�ITCDLTData ��ժҪ˵����
    /// </summary>
    public interface ITCDLTData
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(string issue);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Add(Pbzx.Model.TCDLTData model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Pbzx.Model.TCDLTData model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(string issue);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.TCDLTData GetModel(string issue);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// ���ݷ�ҳ��������б�
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  ��Ա����
    }
}
