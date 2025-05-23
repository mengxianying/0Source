using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using System.Web.UI.WebControls;
namespace Pbzx.BLL
{
	/// <summary>
	/// ҵ���߼���PBnet_PayType ��ժҪ˵����
	/// </summary>
	public class PBnet_PayType
	{
        private readonly Pbzx.SQLServerDAL.PBnet_PayType dal = new Pbzx.SQLServerDAL.PBnet_PayType();
		public PBnet_PayType()
		{}
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
		public bool Exists(int PayTypeID)
		{
			return dal.Exists(PayTypeID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(Pbzx.Model.PBnet_PayType model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Pbzx.Model.PBnet_PayType model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int PayTypeID)
		{
			
			dal.Delete(PayTypeID);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_PayType GetModel(int PayTypeID)
		{
			
			return dal.GetModel(PayTypeID);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
		/// </summary>
		public Pbzx.Model.PBnet_PayType GetModelByCache(int PayTypeID)
		{
			
			string CacheKey = "PBnet_PayTypeModel-" + PayTypeID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PayTypeID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_PayType)objModel;
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
		public List<Pbzx.Model.PBnet_PayType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}

        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_PayType> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_PayType> modelList = new List<Pbzx.Model.PBnet_PayType>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_PayType model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_PayType();
                    if (dt.Rows[n]["PayTypeID"].ToString() != "")
                    {
                        model.PayTypeID = int.Parse(dt.Rows[n]["PayTypeID"].ToString());
                    }
                    model.PayTypeName = dt.Rows[n]["PayTypeName"].ToString();
                    if (dt.Rows[n]["PayValue"].ToString() != "")
                    {
                        model.PayValue = int.Parse(dt.Rows[n]["PayValue"].ToString());
                    }
                    if (dt.Rows[n]["OrderID"].ToString() != "")
                    {
                        model.OrderID = int.Parse(dt.Rows[n]["OrderID"].ToString());
                    }
                    model.Url = dt.Rows[n]["Url"].ToString();
                    if (dt.Rows[n]["FTypeID"].ToString() != "")
                    {
                        model.FTypeID = int.Parse(dt.Rows[n]["FTypeID"].ToString());
                    }
                    if (dt.Rows[n]["Display"].ToString() != "")
                    {
                        if ((dt.Rows[n]["Display"].ToString() == "1") || (dt.Rows[n]["Display"].ToString().ToLower() == "true"))
                        {
                            model.Display = true;
                        }
                        else
                        {
                            model.Display = false;
                        }
                    }
                    model.SelectAddress = dt.Rows[n]["SelectAddress"].ToString();
                    model.LinkUrl = dt.Rows[n]["LinkUrl"].ToString();
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
        public DataTable GetLisBySql(string strSql)
        {
            Pbzx.SQLServerDAL.Basic bac = new Pbzx.SQLServerDAL.Basic("PBnet_PayType", "PayTypeID");
            return bac.GetLisBySql(strSql);
        }


        /// <summary>
        /// ������DropDownList
        /// </summary>
        /// <param name="list"></param>
        /// <param name="parentClass"></param>
        public  void BindPlayType(DropDownList list)
        {
            DataTable dt = GetLisBySql("select * from PBnet_PayType where PayValue >= 0");
            foreach (DataRow row in dt.Rows)
            {
                list.Items.Add(new ListItem(row["PayTypeName"].ToString(), row["PayTypeID"].ToString()));              
            }           
            list.Items.Insert(0, new ListItem("��������", ""));
            list.Items[0].Selected = true;
        }

	}
}

