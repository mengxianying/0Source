using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层ISoftwareHelp_Contrast 的摘要说明。
    /// </summary>
    public interface IHelp_Contrast
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Ct_id);
        bool Exists(string Ct_TreeNum, string Ct_software);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Help_Contrast model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        int Update(Pbzx.Model.Help_Contrast model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        int Delete(int Ct_id);
        int DeleteID(int Ct_TreeNum);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Help_Contrast GetModel(int Ct_id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        #endregion  成员方法
    }
}