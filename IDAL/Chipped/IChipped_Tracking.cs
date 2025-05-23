using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IChipped_Tracking ��ժҪ˵����
    /// </summary>
    public interface IChipped_Tracking
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int TID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.Chipped_Tracking model);
        /// <summary>
        /// ����һ������
        /// </summary>
        bool Update(Pbzx.Model.Chipped_Tracking model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        bool Delete(int TID);
        bool DeleteList(string TIDlist);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.Chipped_Tracking GetModel(int TID);
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
    }
}