using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���Chipped_Tracking ��ժҪ˵����
    /// </summary>
    public partial class Chipped_Tracking
    {
        private readonly IChipped_Tracking dal = DataAccess.CreateChipped_Tracking();
        public Chipped_Tracking()
        { }
        #region  Method
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int TID)
        {
            return dal.Exists(TID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Chipped_Tracking model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.Chipped_Tracking model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int TID)
        {

            return dal.Delete(TID);
        }
        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool DeleteList(string TIDlist)
        {
            return dal.DeleteList(TIDlist);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Chipped_Tracking GetModel(int TID)
        {

            return dal.GetModel(TID);
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
        public List<Pbzx.Model.Chipped_Tracking> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.Chipped_Tracking> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.Chipped_Tracking> modelList = new List<Pbzx.Model.Chipped_Tracking>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.Chipped_Tracking model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.Chipped_Tracking();
                    if (dt.Rows[n]["TID"].ToString() != "")
                    {
                        model.TID = int.Parse(dt.Rows[n]["TID"].ToString());
                    }
                    model.TName = dt.Rows[n]["TName"].ToString();
                    if (dt.Rows[n]["Tplay"].ToString() != "")
                    {
                        model.Tplay = int.Parse(dt.Rows[n]["Tplay"].ToString());
                    }
                    if (dt.Rows[n]["TPeriod"].ToString() != "")
                    {
                        model.TPeriod = int.Parse(dt.Rows[n]["TPeriod"].ToString());
                    }
                    model.TorderNum = dt.Rows[n]["TorderNum"].ToString();
                    if (dt.Rows[n]["Tstate"].ToString() != "")
                    {
                        model.Tstate = int.Parse(dt.Rows[n]["Tstate"].ToString());
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

        #endregion  Method
    }
}
