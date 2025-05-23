using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�IPBnet_Charge ��ժҪ˵����
    /// </summary>
    public interface IPBnet_Charge
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int Id);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.PBnet_Charge model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.PBnet_Charge model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int Id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.PBnet_Charge GetModel(int Id);
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
