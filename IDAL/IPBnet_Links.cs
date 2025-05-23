using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// �ӿڲ�IPBnet_Links ��ժҪ˵����
	/// </summary>
    public interface IPBnet_Links
    {
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        bool Exists(int IntID);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Add(Pbzx.Model.PBnet_Links model);
        /// <summary>
        /// ����һ������
        /// </summary>
        int Update(Pbzx.Model.PBnet_Links model);
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        int Delete(int IntID);
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        Pbzx.Model.PBnet_Links GetModel(int IntID);
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


        /// <summary>
        /// ɾ����������.
        /// </summary>
        /// <param name="linkid">���ID.</param>
        /// <returns>��ɾ���ļ�¼��.</returns>
        int Delete(string linkid);

        int Auditing(string linkid);
        int NoAuditing(string linkid);
	}
}
