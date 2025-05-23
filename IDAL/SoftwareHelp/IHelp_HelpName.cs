using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层ISoftwareHelp_HelpName 的摘要说明。
    /// </summary>
    public interface IHelp_HelpName
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Hn_ID);
        bool Exists(string name);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Help_HelpName model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.Help_HelpName model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int Hn_ID);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Help_HelpName GetModel(int Hn_ID);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  成员方法
    }
}
