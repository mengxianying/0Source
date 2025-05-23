using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IPBnet_School ��ժҪ˵����
    /// </summary>
    public interface IPBnet_School
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int IntID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.PBnet_School model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.PBnet_School model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int IntID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.PBnet_School GetModel(int IntID);
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
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  ��Ա����
        DataTable Query(string sql);
    }
}
