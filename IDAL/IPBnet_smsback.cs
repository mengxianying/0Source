using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// 接口层IPBnet_smsback 的摘要说明。
	/// </summary>
	public interface IPBnet_smsback
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Pbzx.Model.PBnet_smsback model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(Pbzx.Model.PBnet_smsback model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(int id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Pbzx.Model.PBnet_smsback GetModel(int id);
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
