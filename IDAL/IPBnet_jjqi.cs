using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// 接口层IPBnet_jjqi 的摘要说明。
	/// </summary>
	public interface IPBnet_jjqi
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int jiid);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Pbzx.Model.PBnet_jjqi model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(Pbzx.Model.PBnet_jjqi model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int jiid);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Pbzx.Model.PBnet_jjqi GetModel(int jiid);
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
