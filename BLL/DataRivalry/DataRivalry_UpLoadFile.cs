using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using System.Data;
using Pbzx.Common;

namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类DataRivalry_UpLoadFile 的摘要说明。
    /// </summary>
    public class DataRivalry_UpLoadFile
    {
        private static readonly IDataRivalry_UpLoadFile dal = DataAccess.CreateDataRivalry_UpLoadFile();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("v_d_num", "F_drID");
        public DataRivalry_UpLoadFile()
        { }
        #region  成员方法


        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int F_drID)
        {
            return dal.Exists(F_drID);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="UserName">用户名</param>
        /// <param name="FileName">文件名</param>
        /// <returns></returns>
        public bool Exists(string UserName, string FileName, int FileSize)
        {
            return dal.Exists(UserName, FileName, FileSize);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.DataRivalry_UpLoadFile model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.DataRivalry_UpLoadFile model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int F_drID)
        {
            return dal.Delete(F_drID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.DataRivalry_UpLoadFile GetModel(int F_drID)
        {
            return dal.GetModel(F_drID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListDesc(string strWhere)
        {
            return dal.GetListDesc(strWhere);
        }
        public DataSet GetListView(string strWhere)
        {
            return dal.GetListView(strWhere);
        }

        /// <summary>
        /// 截至时间
        /// </summary>
        /// <param name="playName"></param>
        /// <returns></returns>
        public string AllowTime(string playName)
        {
            string dt = "";
            //3D
            if (playName == "1")
            {
                dt = Pbzx.Common.Method.GetFCDateTime.ToString();
            }
            ////双色球
            //if (playName == "3")
            //{
            //    dt = Pbzx.Common.Method.GetSSQDateTime.ToString();
            //}
            //排列三五
            if (playName == "4")
            {
                dt = Pbzx.Common.Method.GetTCPL35DateTime.ToString();
            }
            return dt;
        }
        /// <summary>
        /// 查询当前期号
        /// </summary>
        /// <param name="lottID">彩种编号</param>
        /// <returns></returns>
        public string Period(int lottID)
        {
           
            string issue = Pbzx.BLL.publicMethod.Period(lottID);
            return issue;
        }
        /// <summary>
        /// 查询3D开奖号码
        /// </summary>
        /// <param name="issue">期号</param>
        /// <returns></returns>
        public string SelectlottNum(int issue,int lottID)
        {
            string wNum = Method.RlotteryNum(lottID, issue);
            if (wNum != "")
            {
                string num = wNum;
                return num;
            }
            return "";
        }


        /// <summary>
        /// 根据查询字符串获取分页数据
        /// 创建人: zhouwei
        /// 创建时间: 2010-10-27
        /// </summary>
        /// <param name="SearchStr">查询字符串 </param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="desc">升序还是降序</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>         

        public DataTable GuestGetBySearchUp(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "v_d_num", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        #endregion  成员方法
    }
}
