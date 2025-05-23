using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// 接口层IPBnet_ipdata 的摘要说明。
	/// </summary>
	public interface IPBnet_ipdata
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(decimal ip1,decimal ip2);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		void Add(Pbzx.Model.PBnet_ipdata model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(Pbzx.Model.PBnet_ipdata model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(decimal ip1,decimal ip2);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Pbzx.Model.PBnet_ipdata GetModel(decimal ip1,decimal ip2);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
	}
}
