using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// 接口层IPBnet_ask_Question 的摘要说明。
	/// </summary>
	public interface IPBnet_ask_Question
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(int Id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Pbzx.Model.PBnet_ask_Question model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		int Update(Pbzx.Model.PBnet_ask_Question model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		int Delete(int Id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Pbzx.Model.PBnet_ask_Question GetModel(int Id);
		/// <summary>
		/// 获得数据列表
		/// </summary>
		DataSet GetList(string strWhere);
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		DataSet GetList(int Top,string strWhere,string filedOrder);
		/// <summary>
		/// 根据分页获得数据列表
		/// </summary>
		//DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法

        /// <summary>
        /// 根据类别编号得到问题数量
        /// </summary>
        /// <param name="typeId">类别id</param>
        /// <returns>问题数量</returns>
        /// author:meng
        /// date:09-08-17
        object GetCountByTypeId(string typeId);
        int ExecuteBySql(string sql);
	}
}
