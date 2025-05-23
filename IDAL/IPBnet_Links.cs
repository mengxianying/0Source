using System;
using System.Data;
namespace Pbzx.IDAL
{
	/// <summary>
	/// 接口层IPBnet_Links 的摘要说明。
	/// </summary>
    public interface IPBnet_Links
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int IntID);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.PBnet_Links model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.PBnet_Links model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int IntID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.PBnet_Links GetModel(int IntID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
		#endregion  成员方法


        /// <summary>
        /// 删除友情链接.
        /// </summary>
        /// <param name="linkid">多个ID.</param>
        /// <returns>被删除的记录数.</returns>
        int Delete(string linkid);

        int Auditing(string linkid);
        int NoAuditing(string linkid);
	}
}
