using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IChallenge_integral 的摘要说明。
    /// </summary>
    public interface IChallenge_integral
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int I_id);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Challenge_integral model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Pbzx.Model.Challenge_integral model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int I_id);
        bool DeleteList(string I_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Challenge_integral GetModel(int I_id);
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

        //DataSet GetRank(string strWhere,string TempWhere);
        /// <summary>
        /// //积分 按条件同统计
        /// </summary>
        /// <param name="V_table">视图名称</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        DataSet RankSSq(string V_table, string strWhere);

        /// <summary>
        /// 获得前几行 的 积分排名
        /// </summary>
        /// <param name="V_table">视图名称</param>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        DataSet RankSSq(int Top, string V_table, string strWhere);
        /// <summary>
        /// 双色球积分查询
        /// </summary>
        /// <param name="strWhere">条件</param>
        /// <returns></returns>
        DataSet selectRankS(string strWhere);
        #endregion  成员方法
    }
}
