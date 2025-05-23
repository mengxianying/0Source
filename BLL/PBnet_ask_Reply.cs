using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
namespace Pbzx.BLL
{
	/// <summary>
	/// ҵ���߼���PBnet_ask_Reply ��ժҪ˵����
	/// </summary>
	public class PBnet_ask_Reply
	{
		private readonly IPBnet_ask_Reply dal=DataAccess.CreatePBnet_ask_Reply();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_ask_Reply", "ID");
		public PBnet_ask_Reply()
		{}
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
		public bool  Add(Pbzx.Model.PBnet_ask_Reply model)
		{
            return dal.Add(model) > 0 ? true : false;
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Pbzx.Model.PBnet_ask_Reply model)
		{
            return dal.Update(model) > 0 ? true : false;
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int ID)
		{

            return dal.Delete(ID) > 0 ? true : false;
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_ask_Reply GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_ask_Reply GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_ask_ReplyModel-" + ID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_ask_Reply)objModel;
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
        public List<Pbzx.Model.PBnet_ask_Reply> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_ask_Reply> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_ask_Reply> modelList = new List<Pbzx.Model.PBnet_ask_Reply>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_ask_Reply model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_ask_Reply();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    if (dt.Rows[n]["QuestionId"].ToString() != "")
                    {
                        model.QuestionId = int.Parse(dt.Rows[n]["QuestionId"].ToString());
                    }
                    model.Content = dt.Rows[n]["Content"].ToString();
                    model.Replyer = dt.Rows[n]["Replyer"].ToString();
                    if (dt.Rows[n]["ReplyTime"].ToString() != "")
                    {
                        model.ReplyTime = DateTime.Parse(dt.Rows[n]["ReplyTime"].ToString());
                    }
                    if (dt.Rows[n]["IsBest"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsBest"].ToString() == "1") || (dt.Rows[n]["IsBest"].ToString().ToLower() == "true"))
                        {
                            model.IsBest = true;
                        }
                        else
                        {
                            model.IsBest = false;
                        }
                    }
                    model.ReferenceBook = dt.Rows[n]["ReferenceBook"].ToString();
                    model.Comment = dt.Rows[n]["Comment"].ToString();
                    if (dt.Rows[n]["GoodComment"].ToString() != "")
                    {
                        model.GoodComment = int.Parse(dt.Rows[n]["GoodComment"].ToString());
                    }
                    if (dt.Rows[n]["BadComment"].ToString() != "")
                    {
                        model.BadComment = int.Parse(dt.Rows[n]["BadComment"].ToString());
                    }
                    if (dt.Rows[n]["AttachId"].ToString() != "")
                    {
                        model.AttachId = int.Parse(dt.Rows[n]["AttachId"].ToString());
                    }
                    if (dt.Rows[n]["ReplyerId"].ToString() != "")
                    {
                        model.ReplyerId = int.Parse(dt.Rows[n]["ReplyerId"].ToString());
                    }
                    if (dt.Rows[n]["Deleted"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Deleted"].ToString() == "1") || (dt.Rows[n]["Deleted"].ToString().ToLower() == "true"))
                        {
                            model.Deleted = true;
                        }
                        else
                        {
                            model.Deleted = false;
                        }
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
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}
		#endregion  ��Ա����


        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_ask_Reply", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// ִ��sql��䷵�ص���ֵ
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public object GetSingleData(string sql)
        {
            return basicDAL.GetValueBySql(sql);
        }

        /// <summary>
        /// ���ݣɣ�����ɾ��ɾ������
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchDel(string strID)
        {
            string sql = "DELETE FROM PBnet_ask_Reply WHERE Id IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }


        /// <summary>
        /// ���ݣɣ�������������
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchUpdate(string strID, string column, bool trueOrFalse)
        {
            int value = trueOrFalse ? 1 : 0;
            string sql = "update PBnet_ask_Reply set " + column + "=" + value + " WHERE Id IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }
        /// <summary>
        /// ����Bool�����ֶ�״̬
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="filed">�ֶ���</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_ask_Reply", "Id");
            basicDAL1.ChangeAudit(id, filed);
        }
        public int ExecuteBySql(string sql)
        {
            return dal.ExecuteBySql(sql);
        }

	}
}

