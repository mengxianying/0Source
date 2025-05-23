using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// 接口层IPBnet_tpman 的摘要说明。
	/// </summary>
	public interface IPBnet_tpman
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int Master_Id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Pbzx.Model.PBnet_tpman model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		int Update(Pbzx.Model.PBnet_tpman model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		int Delete(int Master_Id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Pbzx.Model.PBnet_tpman GetModel(int Master_Id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
        Pbzx.Model.PBnet_tpman GetModelByName(string Master_Name);
		#endregion  成员方法
	}
}
