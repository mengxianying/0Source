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
	/// ҵ���߼���PBnet_LotteryMenu ��ժҪ˵����
	/// </summary>
	public class PBnet_LotteryMenu
	{
		private readonly IPBnet_LotteryMenu dal=DataAccess.CreatePBnet_LotteryMenu();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_LotteryMenu", "IntId");
		public PBnet_LotteryMenu()
		{}
		#region  ��Ա����


		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int IntId)
		{
			return dal.Exists(IntId);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool  Add(Pbzx.Model.PBnet_LotteryMenu model)
		{
            return dal.Add(model) > 0 ? true : false ;
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Pbzx.Model.PBnet_LotteryMenu model)
		{
            return dal.Update(model) > 0 ? true : false;
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int IntId)
		{
            return dal.Delete(IntId) > 0 ? true : false;
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_LotteryMenu GetModel(int IntId)
		{			
			return dal.GetModel(IntId);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_LotteryMenu GetModelByCache(int IntId)
		{
			
			string CacheKey = "PBnet_LotteryMenuModel-" + IntId;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(IntId);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_LotteryMenu)objModel;
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
        public List<Pbzx.Model.PBnet_LotteryMenu> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_LotteryMenu> modelList = new List<Pbzx.Model.PBnet_LotteryMenu>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_LotteryMenu model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_LotteryMenu();
                    if (dt.Rows[n]["IntId"].ToString() != "")
                    {
                        model.IntId = int.Parse(dt.Rows[n]["IntId"].ToString());
                    }
                    model.NvarName = dt.Rows[n]["NvarName"].ToString();
                    model.NvarClass = dt.Rows[n]["NvarClass"].ToString();
                    if (dt.Rows[n]["IntClass_OrderId"].ToString() != "")
                    {
                        model.IntClass_OrderId = int.Parse(dt.Rows[n]["IntClass_OrderId"].ToString());
                    }
                    if (dt.Rows[n]["NvarOrderId"].ToString() != "")
                    {
                        model.NvarOrderId = int.Parse(dt.Rows[n]["NvarOrderId"].ToString());
                    }
                    if (dt.Rows[n]["BitIs_show"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitIs_show"].ToString() == "1") || (dt.Rows[n]["BitIs_show"].ToString().ToLower() == "true"))
                        {
                            model.BitIs_show = true;
                        }
                        else
                        {
                            model.BitIs_show = false;
                        }
                    }
                    if (dt.Rows[n]["BitState"].ToString() != "")
                    {
                        if ((dt.Rows[n]["BitState"].ToString() == "1") || (dt.Rows[n]["BitState"].ToString().ToLower() == "true"))
                        {
                            model.BitState = true;
                        }
                        else
                        {
                            model.BitState = false;
                        }
                    }
                    if (dt.Rows[n]["IntCase"].ToString() != "")
                    {
                        model.IntCase = int.Parse(dt.Rows[n]["IntCase"].ToString());
                    }
                    model.NvarApp_name = dt.Rows[n]["NvarApp_name"].ToString();
                    model.NvarLott_date = dt.Rows[n]["NvarLott_date"].ToString();
                    model.Url = dt.Rows[n]["Url"].ToString();
                    if (dt.Rows[n]["DayLottCount"].ToString() != "")
                    {
                        model.DayLottCount = int.Parse(dt.Rows[n]["DayLottCount"].ToString());
                    }
                    model.TimeList = dt.Rows[n]["TimeList"].ToString();
                    if (dt.Rows[n]["LottTypeCount"].ToString() != "")
                    {
                        model.LottTypeCount = int.Parse(dt.Rows[n]["LottTypeCount"].ToString());
                    }
                    model.LottTypeInfo = dt.Rows[n]["LottTypeInfo"].ToString();
                    model.LottWebsites = dt.Rows[n]["LottWebsites"].ToString();
                    model.Mark = dt.Rows[n]["Mark"].ToString();
                    if (dt.Rows[n]["IsRefresh"].ToString() != "")
                    {
                        if ((dt.Rows[n]["IsRefresh"].ToString() == "1") || (dt.Rows[n]["IsRefresh"].ToString().ToLower() == "true"))
                        {
                            model.IsRefresh = true;
                        }
                        else
                        {
                            model.IsRefresh = false;
                        }
                    }
                    if (dt.Rows[n]["IssueLen"].ToString() != "")
                    {
                        model.IssueLen = int.Parse(dt.Rows[n]["IssueLen"].ToString());
                    }
                    model.IssueInfo = dt.Rows[n]["IssueInfo"].ToString();
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

        #region
        /// <summary>
        /// �õ�������Ʒ�б�
        /// </summary>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_LotteryMenu> GetProductListSort(string strWhere)
        {
            List<Pbzx.Model.PBnet_LotteryMenu> data = DataTableToList(GetList(strWhere).Tables[0]);
            if (data.Count > 1)
            {
                Pbzx.Model.PBnet_LotteryMenu productM = new Pbzx.Model.PBnet_LotteryMenu();
                data.Sort(productM);
            }
            return data;
        }

        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ���</param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_LotteryMenu", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// ��ȡָ�������ĵ���ֵ,����ѯ,��������.
        /// </summary>
        /// <param name="strName">����.</param>
        /// <param name="strName">��ѯ����.</param>
        /// <param name="strName">��������.</param>
        public object GetValue(string strName, string strWhere, string strOrderBy)
        {          
            return basicDAL.GetValue(strName, strWhere, strOrderBy);
        }

         /// <summary>
        /// ��ȡָ�������ĵ���ֵ.
        /// </summary>
        /// <param name="strName">����.</param>
        public object GetValue(string strName)
        {            
            return basicDAL.GetValue(strName);
        }

        /// <summary>
        /// ִ��SQL��ȡ�����б�.
        /// </summary>
        public DataTable GetLisBySql(string strSql)
        {       
            return basicDAL.GetLisBySql(strSql);
        }
        #endregion

        /// <summary>
        /// ����Bool�����ֶ�״̬
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="filed">�ֶ���</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_LotteryMenu", "IntId");
            basicDAL1.ChangeAudit(id, filed);
        }

    }
}

