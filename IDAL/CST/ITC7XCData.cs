using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�ITC7XCData ��ժҪ˵����
    /// </summary>
    public interface ITC7XCData
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(string issue);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Add(Pbzx.Model.TC7XCData model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Pbzx.Model.TC7XCData model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(string issue);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.TC7XCData GetModel(string issue);
        /// <summary>
        /// ��������б�
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// ���ݷ�ҳ��������б�
        /// </summary>
        //		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  ��Ա����
    }
}
