using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// 接口层IPBnet_FreeReg 的摘要说明。
	/// </summary>
	public interface IPBnet_FreeReg
	{
		#region  成员方法
		/// <summary>
		/// 得到最大ID
		/// </summary>
		int GetMaxId();
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		bool Exists(string RN,int Status,int SoftwareType,int InstallType,int intFrID);
		/// <summary>
		/// 增加一条数据
		/// </summary>
		int Add(Pbzx.Model.PBnet_FreeReg model);
		/// <summary>
		/// 更新一条数据
		/// </summary>
		void Update(Pbzx.Model.PBnet_FreeReg model);
		/// <summary>
		/// 删除一条数据
		/// </summary>
		void Delete(string RN,int Status,int SoftwareType,int InstallType,int intFrID);
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		Pbzx.Model.PBnet_FreeReg GetModel(string RN,int Status,int SoftwareType,int InstallType,int intFrID);
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
