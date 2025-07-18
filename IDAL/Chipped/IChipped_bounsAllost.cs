using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层IChipped_bounsAllost 的摘要说明。
    /// </summary>
    public interface IChipped_bounsAllost
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string AwardNum, string AwardName, int lotteryState);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Chipped_bounsAllost model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        void Update(Pbzx.Model.Chipped_bounsAllost model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        void Delete(string AwardNum);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Chipped_bounsAllost GetModel(int ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  成员方法
    }
}
