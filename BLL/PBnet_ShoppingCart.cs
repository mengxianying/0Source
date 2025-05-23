using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.Common;
namespace Pbzx.BLL
{
	/// <summary>
	/// 业务逻辑类PBnet_ShoppingCart 的摘要说明。
	/// </summary>
	public class PBnet_ShoppingCart
	{
        private readonly Pbzx.SQLServerDAL.PBnet_ShoppingCart dal = new Pbzx.SQLServerDAL.PBnet_ShoppingCart();
		public PBnet_ShoppingCart()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(long CartID)
		{
			return dal.Exists(CartID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(Pbzx.Model.PBnet_ShoppingCart model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(Pbzx.Model.PBnet_ShoppingCart model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(long CartID)
		{
			
			dal.Delete(CartID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_ShoppingCart GetModel(long CartID)
		{
			
			return dal.GetModel(CartID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.PBnet_ShoppingCart GetModelByCache(long CartID)
		{
			
			string CacheKey = "PBnet_ShoppingCartModel-" + CartID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CartID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_ShoppingCart)objModel;
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
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Pbzx.Model.PBnet_ShoppingCart> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_ShoppingCart> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_ShoppingCart> modelList = new List<Pbzx.Model.PBnet_ShoppingCart>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_ShoppingCart model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_ShoppingCart();
                    //model.CartID=dt.Rows[n]["CartID"].ToString();
                    model.CartGuid = dt.Rows[n]["CartGuid"].ToString();
                    if (dt.Rows[n]["ProductID"].ToString() != "")
                    {
                        model.ProductID = int.Parse(dt.Rows[n]["ProductID"].ToString());
                    }
                    model.RegType = dt.Rows[n]["RegType"].ToString();
                    if (dt.Rows[n]["Quatity"].ToString() != "")
                    {
                        model.Quatity = int.Parse(dt.Rows[n]["Quatity"].ToString());
                    }
                    if (dt.Rows[n]["DataAdded"].ToString() != "")
                    {
                        model.DataAdded = DateTime.Parse(dt.Rows[n]["DataAdded"].ToString());
                    }
                    model.UseTime = dt.Rows[n]["UseTime"].ToString();
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

        public int InsertShoppingCart(Pbzx.Model.PBnet_ShoppingCart shoppingCart)
        {
            return dal.InsertShoppingCart(shoppingCart);
        }

        public DataSet SelectShoppingCartByCartGuid(string cartGuid)
        {
            if (string.IsNullOrEmpty(cartGuid))
                return new DataSet();
            try
            {
                return dal.SelectShoppingCartByCartGuid(cartGuid);
            }
            catch(Exception ex)
            {
                return new DataSet();
            }
        }

        public int UpdateShoppingCart(Pbzx.Model.PBnet_ShoppingCart shoppingCart)
        {
            return dal.UpdateShoppingCart(shoppingCart);
        }

        public int UpdateShoppingCart(List<Pbzx.Model.PBnet_ShoppingCart> shoppingCartList)
        {
            if (shoppingCartList == null || shoppingCartList.Count == 0)
                return 0;

            return dal.UpdateShoppingCart(shoppingCartList);
        }

        public int DeleteShoppingCartByCartID(string cartID)
        {
            return dal.DeleteShoppingCartByCartID(Convert.ToInt32(cartID));
        }

        public int DeleteShoppingCartByCartGuid(string cartGuid)
        {
            return dal.DeleteShoppingCartByCartGuid(cartGuid);
        }

        public Pbzx.Model.PBnet_ShoppingCart GetModelByProductID(string productID,string regType)
        {
            string cartGuid = Method.GetCartGuid();
            List<Pbzx.Model.PBnet_ShoppingCart> lsTemp = GetModelList(" CartGuid='" + cartGuid + "' and ProductID='" + productID + "' and  RegType='" + regType + "' ");
            if (lsTemp.Count > 0)
            {
                return lsTemp[0];
            }
            else
            {
                return null;
            }

        }
	}
}

