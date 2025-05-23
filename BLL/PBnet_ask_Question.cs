using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Text;
using System.Web.UI.WebControls;
namespace Pbzx.BLL
{
	/// <summary>
	/// ҵ���߼���PBnet_ask_Question ��ժҪ˵����
	/// </summary>
	public class PBnet_ask_Question
	{
		private readonly IPBnet_ask_Question dal=DataAccess.CreatePBnet_ask_Question();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_ask_Question", "Id");
		public PBnet_ask_Question()
		{}
		#region  ��Ա����


		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_ask_Question model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Pbzx.Model.PBnet_ask_Question model)
		{
            return dal.Update(model) > 0 ? true : false;
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int Id)
		{

            return dal.Delete(Id) > 0 ? true : false;
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_ask_Question GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_ask_Question GetModelByCache(int Id)
		{
			
			string CacheKey = "PBnet_ask_QuestionModel-" + Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_ask_Question)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Pbzx.Model.PBnet_ask_Question> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_ask_Question> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_ask_Question> modelList = new List<Pbzx.Model.PBnet_ask_Question>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_ask_Question model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_ask_Question();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.Title = dt.Rows[n]["Title"].ToString();
                    model.Content = dt.Rows[n]["Content"].ToString();
                    model.Relay = dt.Rows[n]["Relay"].ToString();
                    model.Asker = dt.Rows[n]["Asker"].ToString();
                    if (dt.Rows[n]["AskTime"].ToString() != "")
                    {
                        model.AskTime = DateTime.Parse(dt.Rows[n]["AskTime"].ToString());
                    }
                    if (dt.Rows[n]["OverTime"].ToString() != "")
                    {
                        model.OverTime = DateTime.Parse(dt.Rows[n]["OverTime"].ToString());
                    }
                    if (dt.Rows[n]["UpdateTime"].ToString() != "")
                    {
                        model.UpdateTime = DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
                    }
                    if (dt.Rows[n]["Views"].ToString() != "")
                    {
                        model.Views = int.Parse(dt.Rows[n]["Views"].ToString());
                    }
                    model.TypeName = dt.Rows[n]["TypeName"].ToString();
                    if (dt.Rows[n]["TypeID"].ToString() != "")
                    {
                        model.TypeID = int.Parse(dt.Rows[n]["TypeID"].ToString());
                    }
                    if (dt.Rows[n]["FTypeID"].ToString() != "")
                    {
                        model.FTypeID = int.Parse(dt.Rows[n]["FTypeID"].ToString());
                    }
                    if (dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    model.Answerer = dt.Rows[n]["Answerer"].ToString();
                    if (dt.Rows[n]["LargessPoint"].ToString() != "")
                    {
                        model.LargessPoint = int.Parse(dt.Rows[n]["LargessPoint"].ToString());
                    }
                    if (dt.Rows[n]["IsCommend"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsCommend"].ToString() == "1") || (dt.Rows[n]["IsCommend"].ToString().ToLower() == "true"))
                        {
                            model.IsCommend = true;
                        }
                        else
                        {
                            model.IsCommend = false;
                        }
                    }
                    if (dt.Rows[n]["IsAnonymous"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsAnonymous"].ToString() == "1") || (dt.Rows[n]["IsAnonymous"].ToString().ToLower() == "true"))
                        {
                            model.IsAnonymous = true;
                        }
                        else
                        {
                            model.IsAnonymous = false;
                        }
                    }
                    if (dt.Rows[n]["AttachId"].ToString() != "")
                    {
                        model.AttachId = int.Parse(dt.Rows[n]["AttachId"].ToString());
                    }
                    if (dt.Rows[n]["Replys"].ToString() != "")
                    {
                        model.Replys = int.Parse(dt.Rows[n]["Replys"].ToString());
                    }
                    if (dt.Rows[n]["AskerId"].ToString() != "")
                    {
                        model.AskerId = int.Parse(dt.Rows[n]["AskerId"].ToString());
                    }
                    if (dt.Rows[n]["AnswererId"].ToString() != "")
                    {
                        model.AnswererId = int.Parse(dt.Rows[n]["AnswererId"].ToString());
                    }
                    if (dt.Rows[n]["BitIsHot"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitIsHot"].ToString() == "1") || (dt.Rows[n]["BitIsHot"].ToString().ToLower() == "true"))
                        {
                            model.BitIsHot = true;
                        }
                        else
                        {
                            model.BitIsHot = false;
                        }
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
                    if (dt.Rows[n]["Auditing"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Auditing"].ToString() == "1") || (dt.Rows[n]["Auditing"].ToString().ToLower() == "true"))
                        {
                            model.Auditing = true;
                        }
                        else
                        {
                            model.Auditing = false;
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
        /// <summary>
        /// ���ݲ�ѯ����������Ҫ���ص��������ؽ����
        /// </summary>
        /// <param name="strWhere">��ѯ����</param>
        /// <param name="count">���ص�����</param>
        /// <returns>�����</returns>
        /// author:��
        public DataTable GetTitleListByCount(string strWhere, int count)
        {
            return dal.GetList(count, strWhere, " AskTime desc ").Tables[0];
        }

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_ask_Question", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        /// <summary>
        /// ��������ŵõ���������
        /// </summary>
        /// <param name="typeId">���id</param>
        /// <returns>��������</returns>
        /// author:meng
        /// date:09-08-17
        public object GetCountByTypeID(string typeId)
        {           
            return dal.GetCountByTypeId(typeId);
        }

        /// <summary>
        /// ����sql��䷵�ز�ѯ���
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
            string sql = "DELETE FROM PBnet_ask_Question WHERE Id IN(" + strID + ")";
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
            string sql = "update PBnet_ask_Question set " + column + "=" + value + " WHERE Id IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }
        /// <summary>
        /// ����Bool�����ֶ�״̬
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="filed">�ֶ���</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_ask_Question", "Id");
            basicDAL1.ChangeAudit(id, filed);
        }
        public int ExecuteBySql(string sql)
        {
            return dal.ExecuteBySql(sql);
        }
	}
}

