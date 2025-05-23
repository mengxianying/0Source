using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    public class Chipped_Attention
    {
        private static readonly IChipped_Attention dal = DataAccess.CreateChipped_Attention();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Chipped_Attention", "id");
        public Chipped_Attention()
        { }
        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }
        public bool Exists(string AName, string AttentionName)
        { 
            return dal.Exists(AName,AttentionName);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Chipped_Attention model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Pbzx.Model.Chipped_Attention model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(string name)
        {
            return dal.Delete(name);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Chipped_Attention GetModel(int id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// ������: zhouwei
        /// ����ʱ��: 2011-02-28
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchChipped(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Chipped_Attention", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        #endregion  ��Ա����
    }
}
