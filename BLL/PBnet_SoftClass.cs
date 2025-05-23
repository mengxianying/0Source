using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Web.UI.WebControls;
using System.Text;
namespace Pbzx.BLL
{
	/// <summary>
	/// 业务逻辑类PBnet_SoftClass 的摘要说明。
	/// </summary>
	public class PBnet_SoftClass
	{
		private readonly IPBnet_SoftClass dal=DataAccess.CreatePBnet_SoftClass();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_SoftClass", "IntClassID");
		public PBnet_SoftClass()
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
		public bool Exists(int IntClassID)
		{
			return dal.Exists(IntClassID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(Pbzx.Model.PBnet_SoftClass model)
		{
            return dal.Add(model) > 0 ? true : false;
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Pbzx.Model.PBnet_SoftClass model)
		{
            return  dal.Update(model) > 0 ? true : false;
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int IntClassID)
		{

            return dal.Delete(IntClassID) > 0 ? true : false;
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_SoftClass GetModel(int IntClassID)
		{
			
			return dal.GetModel(IntClassID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.PBnet_SoftClass GetModelByCache(int IntClassID)
		{
			
			string CacheKey = "PBnet_SoftClassModel-" + IntClassID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(IntClassID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_SoftClass)objModel;
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
		public List<Pbzx.Model.PBnet_SoftClass> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_SoftClass> modelList = new List<Pbzx.Model.PBnet_SoftClass>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_SoftClass model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_SoftClass();
					if(ds.Tables[0].Rows[n]["IntClassID"].ToString()!="")
					{
						model.IntClassID=int.Parse(ds.Tables[0].Rows[n]["IntClassID"].ToString());
					}
					model.NvarClassName=ds.Tables[0].Rows[n]["NvarClassName"].ToString();
					if(ds.Tables[0].Rows[n]["IntParentID"].ToString()!="")
					{
						model.IntParentID=int.Parse(ds.Tables[0].Rows[n]["IntParentID"].ToString());
					}
					model.Var_ParentPath=ds.Tables[0].Rows[n]["Var_ParentPath"].ToString();
					if(ds.Tables[0].Rows[n]["IntDepth"].ToString()!="")
					{
						model.IntDepth=int.Parse(ds.Tables[0].Rows[n]["IntDepth"].ToString());
					}
					if(ds.Tables[0].Rows[n]["IntRootID"].ToString()!="")
					{
						model.IntRootID=int.Parse(ds.Tables[0].Rows[n]["IntRootID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["IntChild"].ToString()!="")
					{
						model.IntChild=int.Parse(ds.Tables[0].Rows[n]["IntChild"].ToString());
					}
					if(ds.Tables[0].Rows[n]["IntPrevID"].ToString()!="")
					{
						model.IntPrevID=int.Parse(ds.Tables[0].Rows[n]["IntPrevID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["Int_NextID"].ToString()!="")
					{
						model.Int_NextID=int.Parse(ds.Tables[0].Rows[n]["Int_NextID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["IntOrderID"].ToString()!="")
					{
						model.IntOrderID=int.Parse(ds.Tables[0].Rows[n]["IntOrderID"].ToString());
					}
					model.NvarReadme=ds.Tables[0].Rows[n]["NvarReadme"].ToString();
					if(ds.Tables[0].Rows[n]["IntSetting"].ToString()!="")
					{
						model.IntSetting=int.Parse(ds.Tables[0].Rows[n]["IntSetting"].ToString());
					}
					model.NvarLinkUrl=ds.Tables[0].Rows[n]["NvarLinkUrl"].ToString();
					model.NvarClassPicUrl=ds.Tables[0].Rows[n]["NvarClassPicUrl"].ToString();
					if(ds.Tables[0].Rows[n]["IntSkinID"].ToString()!="")
					{
						model.IntSkinID=int.Parse(ds.Tables[0].Rows[n]["IntSkinID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["IntLayoutID"].ToString()!="")
					{
						model.IntLayoutID=int.Parse(ds.Tables[0].Rows[n]["IntLayoutID"].ToString());
					}
					if(ds.Tables[0].Rows[n]["IntBrowsePurview"].ToString()!="")
					{
						model.IntBrowsePurview=int.Parse(ds.Tables[0].Rows[n]["IntBrowsePurview"].ToString());
					}
					if(ds.Tables[0].Rows[n]["IntAddPurview"].ToString()!="")
					{
						model.IntAddPurview=int.Parse(ds.Tables[0].Rows[n]["IntAddPurview"].ToString());
					}
					if(ds.Tables[0].Rows[n]["BitIsElite"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["BitIsElite"].ToString()=="1")||(ds.Tables[0].Rows[n]["BitIsElite"].ToString().ToLower()=="true"))
						{
						model.BitIsElite=true;
						}
						else
						{
							model.BitIsElite=false;
						}
					}
					if(ds.Tables[0].Rows[n]["pb_ShowOnTop"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["pb_ShowOnTop"].ToString()=="1")||(ds.Tables[0].Rows[n]["pb_ShowOnTop"].ToString().ToLower()=="true"))
						{
						model.pb_ShowOnTop=true;
						}
						else
						{
							model.pb_ShowOnTop=false;
						}
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_SoftClass", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        /// <summary>
        /// 执行SQL获取数据列表.
        /// </summary>
        public DataTable GetLisBySql(string strSql)
        {
            Pbzx.SQLServerDAL.Basic bac = new Pbzx.SQLServerDAL.Basic("PBnet_SoftClass", "IntSetting");
            return bac.GetLisBySql(strSql);
        }

        public static string  GetNameByID(int id)
        {
            Pbzx.BLL.PBnet_SoftClass classBll = new PBnet_SoftClass();
            Pbzx.Model.PBnet_SoftClass classModel = classBll.GetModel(id);
            return classModel == null ? "---" : classModel.NvarClassName;
        }

        public void BindSoftClass(DropDownList list, int parentClass)
        {

            DataTable dt = GetLisBySql("select IntClassID,NvarClassName from PBnet_SoftClass where IntSetting =" + parentClass + " order by IntOrderID ");
            foreach (DataRow row in dt.Rows)
            {
                StringBuilder sb = new StringBuilder();
                //if (parentClass != 0)
                //{
                //    sb.Append("-|");
                //}
                sb.Append(row["NvarClassName"].ToString());
                list.Items.Add(new ListItem(sb.ToString(), row["IntClassID"].ToString()));
              //  BindSoftClass(list,int.Parse(row["IntClassID"].ToString()));
            }
        }

        public static void ChangeAudit(int id, string filed)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("PBnet_SoftClass", "IntClassID");
            basicDAL1.ChangeAudit(id, filed);
        }



        /// <summary>
        /// 比较并返回两个MusicEntry对象的排列次序
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int CompareProductEntry(Pbzx.Model.PBnet_SoftClass x, Pbzx.Model.PBnet_SoftClass y)
        {
            return x.IntOrderID.CompareTo(y.IntOrderID);
        }

        /// <summary>
        /// 得到排序后产品列表
        /// </summary>
        /// <returns></returns>
        public List<Pbzx.Model.PBnet_SoftClass> GetProductListSort(string strWhere)
        {
            List<Pbzx.Model.PBnet_SoftClass> data = GetModelList(strWhere);
            if (data.Count > 1)
            {
                Pbzx.Model.PBnet_SoftClass productM = new Pbzx.Model.PBnet_SoftClass();
                data.Sort(productM);
            }
            return data;
        }


	}
}

