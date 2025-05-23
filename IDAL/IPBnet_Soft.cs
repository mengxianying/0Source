using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// 接口层IPBnet_Soft 的摘要说明。
	/// </summary>
	public interface IPBnet_Soft
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int PBnet_SoftID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Pbzx.Model.PBnet_Soft model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		int Update(Pbzx.Model.PBnet_Soft model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		int Delete(int PBnet_SoftID);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Pbzx.Model.PBnet_Soft GetModel(int PBnet_SoftID);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
//		DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法
        DataTable Query(string sql);

        /// <summary>
        /// 执行sql语句,返回受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        int ExecuteBySql(string sql);
	}
}
