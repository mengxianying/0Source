using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// 接口层IPBnet_ProductPrice 的摘要说明。
	/// </summary>
	public interface IPBnet_ProductPrice
	{
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int IntPriceID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Pbzx.Model.PBnet_ProductPrice model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		int Update(Pbzx.Model.PBnet_ProductPrice model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		int Delete(int IntPriceID);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Pbzx.Model.PBnet_ProductPrice GetModel(int IntPriceID);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        DataSet SelectAllProductPrice();

         /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere, string orderbyStr);

		#endregion  成员方法
	}
}
