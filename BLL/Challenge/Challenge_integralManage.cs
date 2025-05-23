using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data;
using Pbzx.DALFactory;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���Challenge_integral ��ժҪ˵����
    /// </summary>
    public class Challenge_integral
    {
        private readonly IChallenge_integral dal = DataAccess.CreateChallenge_integral();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Challenge_integral", "I_id");
        public Challenge_integral()
        { }
        #region  Method
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int I_id)
        {
            return dal.Exists(I_id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Challenge_integral model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.Challenge_integral model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int I_id)
        {

            return dal.Delete(I_id);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string I_idlist)
        {
            return dal.DeleteList(I_idlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Challenge_integral GetModel(int I_id)
        {

            return dal.GetModel(I_id);
        }


        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Challenge_integral> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Challenge_integral> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Challenge_integral> modelList = new List<Pbzx.Model.Challenge_integral>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Challenge_integral model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Challenge_integral();
                    if (dt.Rows[n]["I_id"].ToString() != "")
                    {
                        model.I_id = int.Parse(dt.Rows[n]["I_id"].ToString());
                    }
                    model.I_name = dt.Rows[n]["I_name"].ToString();
                    if (dt.Rows[n]["I_lottid"].ToString() != "")
                    {
                        model.I_lottid = int.Parse(dt.Rows[n]["I_lottid"].ToString());
                    }
                    model.I_condName = dt.Rows[n]["I_condName"].ToString();
                    if (dt.Rows[n]["I_integral"].ToString() != "")
                    {
                        model.I_integral = int.Parse(dt.Rows[n]["I_integral"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��ҳ��ȡ�����б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        //public DataSet GetRank(string strWhere, string TempWhere)
        //{
        //    return dal.GetRank(strWhere,TempWhere);
        //}

        /// <summary>
        /// //���� ������ͬͳ��
        /// </summary>
        /// <param name="V_table">��ͼ����</param>
        /// <param name="strWhere">����</param>
        /// <returns></returns>
        public DataSet RankSSq(string V_table, string strWhere)
        {
            return dal.RankSSq(V_table, strWhere);
        }

        /// <summary>
        /// ���ǰ���� �� ��������
        /// </summary>
        /// <param name="V_table">��ͼ����</param>
        /// <param name="strWhere">����</param>
        /// <returns></returns>
        public DataSet RankSSq(int Top, string V_table, string strWhere)
        {
            return dal.RankSSq(Top,V_table, strWhere);
        }


        /// <summary>
        /// ˫ɫ����ֲ�ѯ
        /// </summary>
        /// <param name="strWhere">����</param>
        /// <returns></returns>
        public DataSet selectRankS(string strWhere)
        {
            return dal.selectRankS(strWhere);
        }

        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// ������: zhouwei
        /// ����ʱ��: 2011-12-13
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchIntegral(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Challenge_integral", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion  Method
    }
}

