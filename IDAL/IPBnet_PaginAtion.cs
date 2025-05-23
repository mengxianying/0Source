using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IPBnet_PaginAtion ��ժҪ˵����
    /// </summary>
    public interface IPBnet_PaginAtion
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int PaginationID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.PBnet_PaginAtion model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Pbzx.Model.PBnet_PaginAtion model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(int PaginationID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.PBnet_PaginAtion GetModel(int PaginationID);
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

        int PaginationCreate(Pbzx.Model.PBnet_PaginAtion paginAtionInfo);
        

        void PaginationDelete(int id, global::Pbzx.Common.EModuleType moduletype);

        System.Collections.Generic.List<Pbzx.Model.PBnet_PaginAtion> PaginationGet(int id, global::Pbzx.Common.EModuleType moduletype);
    }
}
