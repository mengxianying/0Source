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
	/// 业务逻辑类PBnet_Soft 的摘要说明。
	/// </summary>
	public class PBnet_Soft
	{
		private readonly IPBnet_Soft dal=DataAccess.CreatePBnet_Soft();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_Soft", "PBnet_SoftID");
		public PBnet_Soft()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PBnet_SoftID)
		{
			return dal.Exists(PBnet_SoftID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(Pbzx.Model.PBnet_Soft model)
		{
            return dal.Add(model) > 0 ? true : false; 
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Pbzx.Model.PBnet_Soft model)
		{
            return dal.Update(model) > 0 ? true : false; 
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PBnet_SoftID)
		{

            return dal.Delete(PBnet_SoftID) > 0 ? true : false ;
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_Soft GetModel(int PBnet_SoftID)
		{
			
			return dal.GetModel(PBnet_SoftID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.PBnet_Soft GetModelByCache(int PBnet_SoftID)
		{
			
			string CacheKey = "PBnet_SoftModel-" + PBnet_SoftID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PBnet_SoftID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_Soft)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_Soft> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_Soft> modelList = new List<Pbzx.Model.PBnet_Soft>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_Soft model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_Soft();
                    if (dt.Rows[n]["PBnet_SoftID"].ToString() != "")
                    {
                        model.PBnet_SoftID = int.Parse(dt.Rows[n]["PBnet_SoftID"].ToString());
                    }
                    if (dt.Rows[n]["pb_ClassID"].ToString() != "")
                    {
                        model.pb_ClassID = int.Parse(dt.Rows[n]["pb_ClassID"].ToString());
                    }
                    model.PBnet_SoftName = dt.Rows[n]["PBnet_SoftName"].ToString();
                    model.PBnet_SoftVersion = dt.Rows[n]["PBnet_SoftVersion"].ToString();
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
                    if (dt.Rows[n]["PBnet_SoftType"].ToString() != "")
                    {
                        model.PBnet_SoftType = int.Parse(dt.Rows[n]["PBnet_SoftType"].ToString());
                    }
                    if (dt.Rows[n]["PBnet_SoftLanguage"].ToString() != "")
                    {
                        model.PBnet_SoftLanguage = int.Parse(dt.Rows[n]["PBnet_SoftLanguage"].ToString());
                    }
                    if (dt.Rows[n]["pb_CopyrightType"].ToString() != "")
                    {
                        model.pb_CopyrightType = int.Parse(dt.Rows[n]["pb_CopyrightType"].ToString());
                    }
                    if (dt.Rows[n]["PBnet_SoftSize"].ToString() != "")
                    {
                        model.PBnet_SoftSize = int.Parse(dt.Rows[n]["PBnet_SoftSize"].ToString());
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
                    model.PBnet_SoftIntro = dt.Rows[n]["PBnet_SoftIntro"].ToString();
                    model.PBnet_SoftPicUrl = dt.Rows[n]["PBnet_SoftPicUrl"].ToString();
                    model.pb_DownloadUrl1 = dt.Rows[n]["pb_DownloadUrl1"].ToString();
                    model.pb_DownloadUrl2 = dt.Rows[n]["pb_DownloadUrl2"].ToString();
                    model.pb_DownloadUrl3 = dt.Rows[n]["pb_DownloadUrl3"].ToString();
                    model.pb_DownloadUrl4 = dt.Rows[n]["pb_DownloadUrl4"].ToString();
                    if (dt.Rows[n]["PBnet_SoftLevel"].ToString() != "")
                    {
                        model.PBnet_SoftLevel = int.Parse(dt.Rows[n]["PBnet_SoftLevel"].ToString());
                    }
                    if (dt.Rows[n]["PBnet_SoftPoint"].ToString() != "")
                    {
                        model.PBnet_SoftPoint = int.Parse(dt.Rows[n]["PBnet_SoftPoint"].ToString());
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
                    if (dt.Rows[n]["countid"].ToString() != "")
                    {
                        model.countid = int.Parse(dt.Rows[n]["countid"].ToString());
                    }
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
                    if (dt.Rows[n]["scountid"].ToString() != "")
                    {
                        model.scountid = int.Parse(dt.Rows[n]["scountid"].ToString());
                    }
                    if (dt.Rows[n]["icountid"].ToString() != "")
                    {
                        model.icountid = int.Parse(dt.Rows[n]["icountid"].ToString());
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
                    modelList.Add(model);
                }
            }
            return modelList;
        }


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
        /// <summary>
        /// 更改Bool类型字段状态
        /// </summary>
        /// <param name="id">编号</param>
        /// <param name="filed">字段名</param>
        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_Soft", "PBnet_SoftID");
            basicDAL1.ChangeAudit(id, filed);
        }

        /// <summary>
        /// 根据查询字符串获取分页数据
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_Soft", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        public DataTable GetListTitleCount(int count, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Top " + count + " * ");
            strSql.Append(" From PBnet_Soft ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return dal.Query(strSql.ToString());
        }



        public DataTable GetSoft(int count)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Top " + count + " * ");
            strSql.Append(" From PBnet_Soft where 1=1 and " + Method.soft + " order by pb_UpdateTime desc ");

            return dal.Query(strSql.ToString());
        }

        /// <summary>
        /// 根据ＩＤ批量更新数据
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchUpdate(string strID, string column)
        {
            string sql = "update PBnet_Soft set " + column + "=1-" + column + " WHERE PBnet_SoftID IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }

        /// <summary>
        /// 根据ＩＤ批量更新数据
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchUpdate(string strID, string column, bool trueOrFalse)
        {
            int value = trueOrFalse ? 1 : 0;
            string sql = "update PBnet_Soft set " + column + "=" + value + " WHERE PBnet_SoftID IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }


        public int ExecuteBySql(string sql)
        {
            return dal.ExecuteBySql(sql);
        }

        /// <summary>
        /// 根据ＩＤ批量删除删除数据
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchDel(string strID)
        {
            string sql = "DELETE FROM PBnet_Soft WHERE PBnet_SoftID IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }



        /// <summary>
        /// 比较并返回两个MusicEntry对象的排列次序
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int CompareProductEntry(Pbzx.Model.PBnet_Soft x, Pbzx.Model.PBnet_Soft y)
        {
            return x.countid.CompareTo(y.countid);
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_Soft> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }


        /// <summary>
        /// 得到排序后产品列表
        /// </summary>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_Soft> GetProductListSort(string strWhere)
        {
            List<Pbzx.Model.PBnet_Soft> data = GetModelList(strWhere);
            if (data.Count > 1)
            {
                Pbzx.Model.PBnet_Soft productM = new Pbzx.Model.PBnet_Soft();
                data.Sort(productM);
            }
            return data;
        }

	}
}

