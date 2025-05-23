using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using Pbzx.Common;
namespace Pbzx.BLL
{
	/// <summary>
	/// 业务逻辑类PBnet_Adv 的摘要说明。
	/// </summary>
	public class PBnet_Adv
	{
		private readonly IPBnet_Adv dal=DataAccess.CreatePBnet_Adv();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_Adv", "ID");
		public PBnet_Adv()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
        /// 
		/// </summary>
		public bool Exists(long ID)
		{
			return dal.Exists(ID);            
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(Pbzx.Model.PBnet_Adv model)
		{
            return dal.Add(model) > 0 ? true : false;
		}

		/// <summary>
		/// 更新一条数据
        /// 
		/// </summary>
		public bool Update(Pbzx.Model.PBnet_Adv model)
		{
            return dal.Update(model) > 0 ? true : false;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(long ID)
		{

            return dal.Delete(ID) > 0 ? true : false;
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_Adv GetModel(long ID)
		{
			
			return dal.GetModel(ID);
		}

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_Adv GetModelByCache(long ID)
        {

            string CacheKey = "PBnet_AdvModel-" + ID;
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
            return (Pbzx.Model.PBnet_Adv)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_Adv> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_Adv> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_Adv> modelList = new List<Pbzx.Model.PBnet_Adv>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_Adv model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_Adv();
                    //model.ID=dt.Rows[n]["ID"].ToString();
                    model.pb_SiteName = dt.Rows[n]["pb_SiteName"].ToString();
                    model.pb_SiteUrl = dt.Rows[n]["pb_SiteUrl"].ToString();
                    model.pb_SiteIntro = dt.Rows[n]["pb_SiteIntro"].ToString();
                    model.pb_ImgUrl = dt.Rows[n]["pb_ImgUrl"].ToString();
                    if (dt.Rows[n]["pb_ImgWidth"].ToString() != "")
                    {
                        model.pb_ImgWidth = int.Parse(dt.Rows[n]["pb_ImgWidth"].ToString());
                    }
                    if (dt.Rows[n]["pb_ImgHeight"].ToString() != "")
                    {
                        model.pb_ImgHeight = int.Parse(dt.Rows[n]["pb_ImgHeight"].ToString());
                    }
                    if (dt.Rows[n]["pb_IsFlash"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pb_IsFlash"].ToString() == "1") || (dt.Rows[n]["pb_IsFlash"].ToString().ToLower() == "true"))
                        {
                            model.pb_IsFlash = true;
                        }
                        else
                        {
                            model.pb_IsFlash = false;
                        }
                    }
                    if (dt.Rows[n]["pb_IsSelected"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pb_IsSelected"].ToString() == "1") || (dt.Rows[n]["pb_IsSelected"].ToString().ToLower() == "true"))
                        {
                            model.pb_IsSelected = true;
                        }
                        else
                        {
                            model.pb_IsSelected = false;
                        }
                    }
                    model.pb_ADSetting = dt.Rows[n]["pb_ADSetting"].ToString();
                    if (dt.Rows[n]["pb_ADDTime"].ToString() != "")
                    {
                        model.pb_ADDTime = DateTime.Parse(dt.Rows[n]["pb_ADDTime"].ToString());
                    }
                    if (dt.Rows[n]["pb_ENDTime"].ToString() != "")
                    {
                        model.pb_ENDTime = DateTime.Parse(dt.Rows[n]["pb_ENDTime"].ToString());
                    }
                    if (dt.Rows[n]["pb_PeakC1"].ToString() != "")
                    {
                        model.pb_PeakC1 = int.Parse(dt.Rows[n]["pb_PeakC1"].ToString());
                    }
                    if (dt.Rows[n]["pb_PeakC2"].ToString() != "")
                    {
                        model.pb_PeakC2 = int.Parse(dt.Rows[n]["pb_PeakC2"].ToString());
                    }
                    if (dt.Rows[n]["pb_PeakCount"].ToString() != "")
                    {
                        model.pb_PeakCount = int.Parse(dt.Rows[n]["pb_PeakCount"].ToString());
                    }
                    if (dt.Rows[n]["pb_sPeakNum"].ToString() != "")
                    {
                        model.pb_sPeakNum = int.Parse(dt.Rows[n]["pb_sPeakNum"].ToString());
                    }
                    if (dt.Rows[n]["pb_ADBSType"].ToString() != "")
                    {
                        if ((dt.Rows[n]["pb_ADBSType"].ToString() == "1") || (dt.Rows[n]["pb_ADBSType"].ToString().ToLower() == "true"))
                        {
                            model.pb_ADBSType = true;
                        }
                        else
                        {
                            model.pb_ADBSType = false;
                        }
                    }
                    if (dt.Rows[n]["pb_Priority"].ToString() != "")
                    {
                        model.pb_Priority = int.Parse(dt.Rows[n]["pb_Priority"].ToString());
                    }
                    if (dt.Rows[n]["pb_SameIP"].ToString() != "")
                    {
                        model.pb_SameIP = int.Parse(dt.Rows[n]["pb_SameIP"].ToString());
                    }
                    if (dt.Rows[n]["pb_Today"].ToString() != "")
                    {
                        model.pb_Today = DateTime.Parse(dt.Rows[n]["pb_Today"].ToString());
                    }
                    if (dt.Rows[n]["pb_TDCount"].ToString() != "")
                    {
                        model.pb_TDCount = int.Parse(dt.Rows[n]["pb_TDCount"].ToString());
                    }
                    if (dt.Rows[n]["pb_ALLCount"].ToString() != "")
                    {
                        model.pb_ALLCount = int.Parse(dt.Rows[n]["pb_ALLCount"].ToString());
                    }
                    if (dt.Rows[n]["pbs_TDCount"].ToString() != "")
                    {
                        model.pbs_TDCount = int.Parse(dt.Rows[n]["pbs_TDCount"].ToString());
                    }
                    if (dt.Rows[n]["pbs_ALLCount"].ToString() != "")
                    {
                        model.pbs_ALLCount = int.Parse(dt.Rows[n]["pbs_ALLCount"].ToString());
                    }
                    if (dt.Rows[n]["CountID"].ToString() != "")
                    {
                        model.CountID = int.Parse(dt.Rows[n]["CountID"].ToString());
                    }
                    model.PlaceName = dt.Rows[n]["PlaceName"].ToString();
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


        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_Adv", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// 根据ＩＤ批量更新数据
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchUpdate(string strID, string column)
        {
            string sql = "update PBnet_Adv set " + column + "=1-" + column + " WHERE ID IN(" + strID + ")";     
            return dal.ExecuteBySql(sql);
        }

        ///<summary>
        /// 根据ID批量删除数据
        ///</summary>
        public int BatchDel(string strID)
        {
            string sql = "DELETE FROM PBnet_Adv WHERE ID IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
            
        }
        /// <summary>
        /// 根据广告位名得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_Adv GetModelName(string Name)
        {

            List<Pbzx.Model.PBnet_Adv> ls = GetModelList(" PlaceName='" + Name + "'");
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 根据ＩＤ批量更新数据
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchUpdateState(string strID, string column, bool isTrue)
        {
            int i = isTrue ? 1 : 0;
            string sql = "update PBnet_Adv set " + column + "=" + i + " WHERE ID IN(" + strID + ")";
            return dal.ExecuteBySql(sql);
        }

        public List<Pbzx.Model.PBnet_Adv> GetModelListByPlaceType(string typeName,int typeID)
        {
            return GetModelList(" PlaceName in(select PlaceName from PBnet_AdvPlace where PlaceType='" + typeName + "' and TypeID='" + typeID + "' ) and  "+Method.Advs);
        }
	}
}

