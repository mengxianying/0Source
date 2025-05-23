using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pbzx.IDAL;
using Pbzx.DALFactory;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���Note_LotteryType ��ժҪ˵����
    /// </summary>
    public class Note_LotteryType
    {
        private static readonly INote_LotteryType dal = DataAccess.CreateNote_LotteryType();
        public Note_LotteryType()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int SID)
        {
            return dal.Exists(SID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Note_LotteryType model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.Note_LotteryType model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int SID)
        {
            return dal.Delete(SID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Note_LotteryType GetModel(int SID)
        {
            return dal.GetModel(SID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Note_LotteryType> GetLists(string strWhere)
        {
            return DataTableToList(dal.GetList(strWhere).Tables[0]);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Note_LotteryType> GetLists()
        {
            return DataTableToList(dal.GetList("").Tables[0]);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Note_LotteryType> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Note_LotteryType> modelList = null;
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                modelList = new List<Pbzx.Model.Note_LotteryType>();
                Pbzx.Model.Note_LotteryType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Note_LotteryType();
                    if (dt.Rows[n]["SID"].ToString() != "")
                    {
                        model.SID = int.Parse(dt.Rows[n]["SID"].ToString());
                    }
                    model.SName = dt.Rows[n]["SName"].ToString();

                    model.PriceContent = dt.Rows[n]["PriceContent"].ToString();
                    model.Explain = dt.Rows[n]["Explain"].ToString();
                    model.Ispublic = Convert.ToBoolean(dt.Rows[n]["Ispublic"].ToString());
                    model.BeginTime = Convert.ToDateTime(dt.Rows[n]["BeginTime"].ToString());
                    model.UpTime = Convert.ToDateTime(dt.Rows[n]["UpTime"].ToString());
                    model.IssueWeek = dt.Rows[n]["IssueWeek"].ToString();
                    model.IssueTime = dt.Rows[n]["IssueTime"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        #endregion  ��Ա����
    }
}
