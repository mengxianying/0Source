using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// 接口层IPBnet_ADRecord 的摘要说明。
	/// </summary>
	public interface IPBnet_ADRecord
	{
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Pbzx.Model.PBnet_ADRecord model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(Pbzx.Model.PBnet_ADRecord model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Pbzx.Model.PBnet_ADRecord GetModel(long pb_ADid,DateTime pb_VsTime,string pb_VsIP,long id);
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
