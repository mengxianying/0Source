using System;
using System.Collections.Generic;
using System.Text;
using System.Data;


namespace Pbzx.IDAL
{
    /// <summary>
    /// 接口层Challenge_Cinfo
    /// </summary>
    public interface IChallenge_Cinfo
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(int C_id);
        bool Exists(string name, int issue, int tid);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Pbzx.Model.Challenge_Cinfo model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(Pbzx.Model.Challenge_Cinfo model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int C_id);
        bool DeleteList(string C_idlist);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        Pbzx.Model.Challenge_Cinfo GetModel(int C_id);
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet GetList(string strWhere);
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        DataSet GetList(int Top, string strWhere, string filedOrder);
        DataSet GetBankTransfer(string strWhere);
        DataSet GetBankTransferD(string strWhere);

        DataSet GetStitaSSq(int Top, string strWhere);

        DataSet GetStitaD(int Top, string strWhere);

        DataSet GetStatiUser(int Top,string strWhere);

        DataSet GetStatiUserD(int Top,string strWhere);
        /// <summary>
        /// 排列3 列转行
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataSet GetBankTransferP(string strWhere);
        /// <summary>
        /// 统计排列3 中奖次数---按条件的和（中奖次数相加）
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        DataSet GetStatiUserP(int Top, string strWhere);
        


        /// <summary>
        /// 所有用户的中奖排行 
        /// </summary>
        /// <param name="steWhere">查询条件</param>
        DataSet GetCompOFs(int Top,string strWhere);

        DataSet GetCompOFs(int TopNum, int Top, string strWhere);

        /// <summary>
        /// 用户的中奖排行 3D 双色球
        /// </summary>
        /// <param name="steWhere">查询条件</param>
        DataSet GetCompOFs(string strWhere);
       

        /// <summary>
        /// 用户的中奖排行 排列3
        /// </summary>
        /// <param name="steWhere">查询条件</param>
        DataSet GetCompOFs_P(int Top, string strWhere);


        /// <summary>
        /// 根据分页获得数据列表
        /// </summary>
        //DataSet GetList(int PageSize,int PageIndex,string strWhere);
        #endregion  成员方法
    }
}