using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// �ӿڲ�Ipb_adminloginlog ��ժҪ˵����
    /// </summary>
    public interface Ipb_adminloginlog
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(long id);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.pb_adminloginlog model);
        /// <summary>
        /// ����һ������
        /// </summary>
        void Update(Pbzx.Model.pb_adminloginlog model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        void Delete(long id);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.pb_adminloginlog GetModel(long id);
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
