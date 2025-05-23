using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Text;
using Pbzx.Common;
namespace Pbzx.BLL
{
	/// <summary>
	/// ҵ���߼���PBnet_Product ��ժҪ˵����
	/// </summary>
	public class PBnet_Product
	{
		private readonly IPBnet_Product dal=DataAccess.CreatePBnet_Product();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_Product", "pb_SoftID");
		public PBnet_Product()
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
		public bool Exists(int pb_SoftID)
		{
			return dal.Exists(pb_SoftID);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool   Add(Pbzx.Model.PBnet_Product model)
		{
            return dal.Add(model) > 0 ? true : false; 
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public bool Update(Pbzx.Model.PBnet_Product model)
		{
           return  dal.Update(model) > 0 ? true : false; ;
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public bool Delete(int pb_SoftID)
		{

            return dal.Delete(pb_SoftID) > 0 ? true : false; 
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Pbzx.Model.PBnet_Product GetModel(int pb_SoftID)
		{
			
			return dal.GetModel(pb_SoftID);
		}
        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_Product GetModelByCache(int pb_SoftID)
        {

            string CacheKey = "PBnet_ProductModel-" + pb_SoftID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(pb_SoftID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_Product)objModel;
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
        public List<Pbzx.Model.PBnet_Product> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_Product> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_Product> modelList = new List<Pbzx.Model.PBnet_Product>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_Product model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_Product();
                    if (dt.Rows[n]["pb_SoftID"].ToString() != "")
                    {
                        model.pb_SoftID = int.Parse(dt.Rows[n]["pb_SoftID"].ToString());
                    }
                    if (dt.Rows[n]["pb_ClassID"].ToString() != "")
                    {
                        model.pb_ClassID = int.Parse(dt.Rows[n]["pb_ClassID"].ToString());
                    }
                    model.pb_SoftName = dt.Rows[n]["pb_SoftName"].ToString();
                    model.pb_SoftVersion = dt.Rows[n]["pb_SoftVersion"].ToString();
                    model.pb_Author = dt.Rows[n]["pb_Author"].ToString();
                    model.pb_AuthorEmail = dt.Rows[n]["pb_AuthorEmail"].ToString();
                    model.pb_AuthorHomepage = dt.Rows[n]["pb_AuthorHomepage"].ToString();
                    model.pb_DemoUrl = dt.Rows[n]["pb_DemoUrl"].ToString();
                    model.pb_Editor = dt.Rows[n]["pb_Editor"].ToString();
                    model.pb_Keyword = dt.Rows[n]["pb_Keyword"].ToString();
                    if (dt.Rows[n]["pb_Hits"].ToString() != "")
                    {
                        model.pb_Hits = int.Parse(dt.Rows[n]["pb_Hits"].ToString());
                    }
                    if (dt.Rows[n]["pb_DayHits"].ToString() != "")
                    {
                        model.pb_DayHits = int.Parse(dt.Rows[n]["pb_DayHits"].ToString());
                    }
                    if (dt.Rows[n]["pb_WeekHits"].ToString() != "")
                    {
                        model.pb_WeekHits = int.Parse(dt.Rows[n]["pb_WeekHits"].ToString());
                    }
                    if (dt.Rows[n]["pb_MonthHits"].ToString() != "")
                    {
                        model.pb_MonthHits = int.Parse(dt.Rows[n]["pb_MonthHits"].ToString());
                    }
                    if (dt.Rows[n]["pb_UpdateTime"].ToString() != "")
                    {
                        model.pb_UpdateTime = DateTime.Parse(dt.Rows[n]["pb_UpdateTime"].ToString());
                    }
                    model.pb_OperatingSystem = dt.Rows[n]["pb_OperatingSystem"].ToString();
                    model.pb_TypeName = dt.Rows[n]["pb_TypeName"].ToString();
                    if (dt.Rows[n]["pb_SoftType"].ToString() != "")
                    {
                        model.pb_SoftType = int.Parse(dt.Rows[n]["pb_SoftType"].ToString());
                    }
                    if (dt.Rows[n]["pb_SoftLanguage"].ToString() != "")
                    {
                        model.pb_SoftLanguage = int.Parse(dt.Rows[n]["pb_SoftLanguage"].ToString());
                    }
                    if (dt.Rows[n]["pb_CopyrightType"].ToString() != "")
                    {
                        model.pb_CopyrightType = int.Parse(dt.Rows[n]["pb_CopyrightType"].ToString());
                    }
                    if (dt.Rows[n]["pb_SoftSize"].ToString() != "")
                    {
                        model.pb_SoftSize = int.Parse(dt.Rows[n]["pb_SoftSize"].ToString());
                    }
                    model.pb_RegUrl = dt.Rows[n]["pb_RegUrl"].ToString();
                    if (dt.Rows[n]["pb_OnTop"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pb_OnTop"].ToString() == "1") || (dt.Rows[n]["pb_OnTop"].ToString().ToLower() == "true"))
                        {
                            model.pb_OnTop = true;
                        }
                        else
                        {
                            model.pb_OnTop = false;
                        }
                    }
                    if (dt.Rows[n]["pb_Elite"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pb_Elite"].ToString() == "1") || (dt.Rows[n]["pb_Elite"].ToString().ToLower() == "true"))
                        {
                            model.pb_Elite = true;
                        }
                        else
                        {
                            model.pb_Elite = false;
                        }
                    }
                    if (dt.Rows[n]["pb_Passed"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pb_Passed"].ToString() == "1") || (dt.Rows[n]["pb_Passed"].ToString().ToLower() == "true"))
                        {
                            model.pb_Passed = true;
                        }
                        else
                        {
                            model.pb_Passed = false;
                        }
                    }
                    model.pb_SoftIntro = dt.Rows[n]["pb_SoftIntro"].ToString();
                    model.pb_SoftPicUrl = dt.Rows[n]["pb_SoftPicUrl"].ToString();
                    model.pb_DownloadUrl1 = dt.Rows[n]["pb_DownloadUrl1"].ToString();
                    model.pb_DownloadUrl2 = dt.Rows[n]["pb_DownloadUrl2"].ToString();
                    model.pb_DownloadUrl3 = dt.Rows[n]["pb_DownloadUrl3"].ToString();
                    model.pb_DownloadUrl4 = dt.Rows[n]["pb_DownloadUrl4"].ToString();
                    if (dt.Rows[n]["pb_SoftLevel"].ToString() != "")
                    {
                        model.pb_SoftLevel = int.Parse(dt.Rows[n]["pb_SoftLevel"].ToString());
                    }
                    if (dt.Rows[n]["pb_SoftPoint"].ToString() != "")
                    {
                        model.pb_SoftPoint = int.Parse(dt.Rows[n]["pb_SoftPoint"].ToString());
                    }
                    if (dt.Rows[n]["pb_Deleted"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pb_Deleted"].ToString() == "1") || (dt.Rows[n]["pb_Deleted"].ToString().ToLower() == "true"))
                        {
                            model.pb_Deleted = true;
                        }
                        else
                        {
                            model.pb_Deleted = false;
                        }
                    }
                    if (dt.Rows[n]["pb_Stars"].ToString() != "")
                    {
                        model.pb_Stars = int.Parse(dt.Rows[n]["pb_Stars"].ToString());
                    }
                    model.pb_DecompressPassword = dt.Rows[n]["pb_DecompressPassword"].ToString();
                    if (dt.Rows[n]["pb_LastHitTime"].ToString() != "")
                    {
                        model.pb_LastHitTime = DateTime.Parse(dt.Rows[n]["pb_LastHitTime"].ToString());
                    }
                    model.pb_softContent = dt.Rows[n]["pb_softContent"].ToString();
                    if (dt.Rows[n]["countid"].ToString() != "")
                    {
                        model.countid = int.Parse(dt.Rows[n]["countid"].ToString());
                    }
                    model.pb_Softdemo = dt.Rows[n]["pb_Softdemo"].ToString();
                    model.pb_illuminate = dt.Rows[n]["pb_illuminate"].ToString();
                    if (dt.Rows[n]["pb_indexshow"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pb_indexshow"].ToString() == "1") || (dt.Rows[n]["pb_indexshow"].ToString().ToLower() == "true"))
                        {
                            model.pb_indexshow = true;
                        }
                        else
                        {
                            model.pb_indexshow = false;
                        }
                    }
                    if (dt.Rows[n]["pb_freeshow"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pb_freeshow"].ToString() == "1") || (dt.Rows[n]["pb_freeshow"].ToString().ToLower() == "true"))
                        {
                            model.pb_freeshow = true;
                        }
                        else
                        {
                            model.pb_freeshow = false;
                        }
                    }
                    if (dt.Rows[n]["OuterHits"].ToString() != "")
                    {
                        model.OuterHits = int.Parse(dt.Rows[n]["OuterHits"].ToString());
                    }
                    if (dt.Rows[n]["OuterDayHits"].ToString() != "")
                    {
                        model.OuterDayHits = int.Parse(dt.Rows[n]["OuterDayHits"].ToString());
                    }
                    if (dt.Rows[n]["OuterWeekHits"].ToString() != "")
                    {
                        model.OuterWeekHits = int.Parse(dt.Rows[n]["OuterWeekHits"].ToString());
                    }
                    if (dt.Rows[n]["OuterMonthHits"].ToString() != "")
                    {
                        model.OuterMonthHits = int.Parse(dt.Rows[n]["OuterMonthHits"].ToString());
                    }
                    if (dt.Rows[n]["CstID"].ToString() != "")
                    {
                        model.CstID = int.Parse(dt.Rows[n]["CstID"].ToString());
                    }
                    if (dt.Rows[n]["PBnet_Softshow"].ToString() != "")
                    {
                        if ((dt.Rows[n]["PBnet_Softshow"].ToString() == "1") || (dt.Rows[n]["PBnet_Softshow"].ToString().ToLower() == "true"))
                        {
                            model.PBnet_Softshow = true;
                        }
                        else
                        {
                            model.PBnet_Softshow = false;
                        }
                    }
                    if (dt.Rows[n]["icountid"].ToString() != "")
                    {
                        model.icountid = int.Parse(dt.Rows[n]["icountid"].ToString());
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
        #region

        /// <summary>
        /// �Ƚϲ���������MusicEntry��������д���
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int CompareProductEntry(Pbzx.Model.PBnet_Product x, Pbzx.Model.PBnet_Product y)
        {
            return x.countid.CompareTo(y.countid);
        }
        
        /// <summary>
        /// �õ�������Ʒ�б�
        /// </summary>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_Product> GetProductListSort(string strWhere)
        {
            List<Pbzx.Model.PBnet_Product> data = GetModelList(strWhere);
            if(data.Count > 1)
            {
                Pbzx.Model.PBnet_Product productM = new Pbzx.Model.PBnet_Product();
                data.Sort(productM);
            }
            return data;
        }



       

        /// <summary>
        /// ����Bool�����ֶ�״̬
        /// </summary>
        /// <param name="id">���</param>
        /// <param name="filed">�ֶ���</param>
        public static void ChangeAudit(int id,string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_Product", "pb_SoftID");
            basicDAL1.ChangeAudit(id, filed);
        }

        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>         
        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_Product", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// ������²����ID.
        /// </summary>
        public int GetInsertID()
        {
            return Convert.ToInt32(basicDAL.GetValue("TOP 1 pb_SoftID", "", " pb_SoftID DESC"));
        }

        /// <summary>
        /// ���ݣɣ�����ɾ��ɾ������
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchDel(string strID)
        {
            string sql = "DELETE FROM PBnet_Product WHERE pb_SoftID IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }

        /// <summary>
        /// ���ݣɣ�������������
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchUpdate(string strID, string column)
        {
            string sql = "update PBnet_Product set " + column + "=1-" + column + " WHERE pb_SoftID IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }

        /// <summary>
        /// ���ݣɣ�������������
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchUpdate(string strID, string column,bool trueOrFalse)
        {
            int value = trueOrFalse ? 1 : 0;
            string sql = "update PBnet_Product set " + column + "=" + value + " WHERE pb_SoftID IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }


        #endregion

        public DataTable GetListTitleCount(int count, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Top " + count + " * ");
            strSql.Append(" From PBnet_Product ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }           
            return dal.Query(strSql.ToString());
         }

        public DataTable GetSoftPic(int count)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Top " + count + " * ");
            strSql.Append(" From PBnet_Product where 1=1 and " + Method.product + " order by pb_UpdateTime desc ");

            return dal.Query(strSql.ToString());
        }

        public int ExecuteBySql(string sql)
        {
           return  dal.ExecuteBySql(sql);
        }
    }
}

