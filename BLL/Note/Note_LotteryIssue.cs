using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using Maticsoft.DBUtility;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���Note_LotteryIssue ��ժҪ˵����
    /// </summary>
    public class Note_LotteryIssue
    {
        private static readonly INote_LotteryIssue dal = DataAccess.CreateNote_LotteryIssue();
        public Note_LotteryIssue()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Add(Pbzx.Model.Note_LotteryIssue model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public void Update(Pbzx.Model.Note_LotteryIssue model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public void Delete(int ID)
        {
            dal.Delete(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Note_LotteryIssue GetModel(int ID)
        {
            return dal.GetModel(ID);
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
        public DataSet GetList()
        {
            return dal.GetList("");
        }

        public List<Pbzx.Model.Note_LotteryIssue> GetLists(string strwhere)
        {
            return DataTableToList(GetList(strwhere).Tables[0]);
        }
        /// <summary>
        /// �õ�����һ�ڵ���Ϣ
        /// </summary>
        /// <param name="sid"></param>
        /// <returns></returns>
        public Pbzx.Model.Note_LotteryIssue GetMaxModel(string sid)
        {
            return DataTableToModel(DbHelperSQL.Query("SELECT TOP 1 * FROM Note_LotteryIssue WHERE (SID = '" + sid + "') and IsSend=0 ORDER BY BeginTime DESC").Tables[0]);
        }



        /// <summary>
        /// ������ݶ���
        /// </summary>
        public Pbzx.Model.Note_LotteryIssue DataTableToModel(DataTable dt)
        {
            Pbzx.Model.Note_LotteryIssue model = null;
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {


                model = new Pbzx.Model.Note_LotteryIssue();
                if (dt.Rows[0]["ID"].ToString() != "")
                {
                    model.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                }
                model.SID = int.Parse(dt.Rows[0]["SID"].ToString());

                model.QNumber = dt.Rows[0]["QNumber"].ToString();
                model.Content = dt.Rows[0]["Content"].ToString();
                model.BeginTime = Convert.ToDateTime(dt.Rows[0]["beginTime"].ToString());
                model.IsSend = Convert.ToInt32(dt.Rows[0]["IsSend"].ToString());
            }
            return model;
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Note_LotteryIssue> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Note_LotteryIssue> modelList = null;
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                modelList = new List<Pbzx.Model.Note_LotteryIssue>();
                Pbzx.Model.Note_LotteryIssue model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Note_LotteryIssue();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.SID = int.Parse(dt.Rows[n]["SID"].ToString());

                    model.QNumber = dt.Rows[n]["QNumber"].ToString();
                    model.Content = dt.Rows[n]["Content"].ToString();
                    model.BeginTime = Convert.ToDateTime(dt.Rows[n]["beginTime"].ToString());
                    model.IsSend = Convert.ToInt32(dt.Rows[0]["IsSend"].ToString());
                    modelList.Add(model);
                }
            }
            return modelList;
        }
        #endregion  ��Ա����
    }
}
