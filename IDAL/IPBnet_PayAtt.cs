using System;
using System.Data;
namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层PBnet_PayAtt
    /// </summary>
    public interface IPBnet_PayAtt
    {
        #region  成员方法
        /// <summary>
        /// 得到最大ID
        /// </summary>
        int GetMaxId();
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int Pa_id);
        bool Exists(string Pa_Idol, string Pa_fans, string Pa_PSign);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.PBnet_PayAtt model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Pbzx.Model.PBnet_PayAtt model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int Pa_id);
        bool DeleteList(string Pa_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.PBnet_PayAtt GetModel(int Pa_id);
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
    }
}