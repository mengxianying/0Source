using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Data;

namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类PlatformPublic_payments 的摘要说明。
    /// </summary>
    public class PlatformPublic_payments
    {
        private static readonly IPlatformPublic_payments dal = DataAccess.CreatePlatformPublic_payments();

        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PlatformPublic_payments", "Pp_id");
        public PlatformPublic_payments()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int Pp_id)
        {
            return dal.Exists(Pp_id);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.PlatformPublic_payments model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.PlatformPublic_payments model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Pp_id)
        {
            return dal.Delete(Pp_id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PlatformPublic_payments GetModel(int Pp_id)
        {
            return dal.GetModel(Pp_id);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 添加用户收支信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="Pp_num">合买平台为订单号，其他平台是流水号。可以为空</param>
        /// <param name="type">操作类型：1：支出  2：收取 3：冻结</param>
        /// <param name="issue">期号</param>
        /// <param name="LotName">彩种标识</param>
        /// <param name="explain">说明文字</param>
        /// <param name="data">具体收支金额</param>
        /// <param name="date_Time">添加时间</param>
        /// <param name="belongs">平台标识</param>
        public void payments(string UserName,string Pp_num, int type, int issue,int LotName, string explain,decimal data, string belongs)
        {
            Pbzx.Model.PlatformPublic_payments mod_pt = new Pbzx.Model.PlatformPublic_payments();
            mod_pt.Pp_name = UserName;
            mod_pt.Pp_num = Pp_num;
            mod_pt.Pp_Type = type;
            mod_pt.Pp_issue = Convert.ToInt32(issue);
            mod_pt.Pp_LotName = LotName;
            mod_pt.Pp_Time = Convert.ToDateTime(DateTime.Now);
            mod_pt.Pp_explain = explain;
            mod_pt.Pp_data = data;
            mod_pt.Pp_belongs = belongs;
            try
            {
                Add(mod_pt);
            }
            catch (Exception ex)
            {
                Pbzx.Common.ErrorLog.WriteLog(ex);
            }
        }
        /// <summary>
        /// 根据查询字符串获取分页数据
        /// 创建人: zhouwei
        /// 创建时间: 2011-02-28
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchChipped(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PlatformPublic_payments", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        #endregion  成员方法
    }
}
