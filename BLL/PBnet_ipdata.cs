using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类PBnet_ipdata 的摘要说明。
    /// </summary>
    public class PBnet_ipdata
    {
        private readonly IPBnet_ipdata dal = DataAccess.CreatePBnet_ipdata();
        Pbzx.SQLServerDAL.Basic basic = new Pbzx.SQLServerDAL.Basic("PBnet_ipdata", "ip1");
        public PBnet_ipdata()
        {

        }

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(decimal ip1, decimal ip2)
        {
            return dal.Exists(ip1, ip2);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public void Add(Pbzx.Model.PBnet_ipdata model)
        {
            dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update(Pbzx.Model.PBnet_ipdata model)
        {
            dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(decimal ip1, decimal ip2)
        {

            dal.Delete(ip1, ip2);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_ipdata GetModel(decimal ip1, decimal ip2)
        {

            return dal.GetModel(ip1, ip2);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_ipdata GetModelByCache(decimal ip1, decimal ip2)
        {

            string CacheKey = "PBnet_ipdataModel-" + ip1 + ip2;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ip1, ip2);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_ipdata)objModel;
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
        public List<Pbzx.Model.PBnet_ipdata> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.PBnet_ipdata> modelList = new List<Pbzx.Model.PBnet_ipdata>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_ipdata model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_ipdata();
                    if (ds.Tables[0].Rows[n]["ip1"].ToString() != "")
                    {
                        model.ip1 = decimal.Parse(ds.Tables[0].Rows[n]["ip1"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["ip2"].ToString() != "")
                    {
                        model.ip2 = decimal.Parse(ds.Tables[0].Rows[n]["ip2"].ToString());
                    }
                    model.country = ds.Tables[0].Rows[n]["country"].ToString();
                    model.city = ds.Tables[0].Rows[n]["city"].ToString();
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  成员方法
        /// <summary>
        /// '修改时间：2011-2-14
        /// 修改人：杨良伟
        /// 传入IP得到他的地址
        /// </summary>
        /// <param name="userip">IP</param>
        /// <returns>当传入IP错误时，返回IP，否则返回他的地址</returns>
        public string S_getIPaddress(string userip)
        {
            if (string.IsNullOrEmpty(userip))
            {
                return "";
            }
            else if (userip.Length < 2)
            {
                return "未知";
            }
            else if (userip.Contains(":"))
            {
                return "IPV6地址";
            }
            long tnum = 0;
            string result = "";
            int twoTest = 0;
            if (int.TryParse(userip.Substring(0, 1), out twoTest))
            {
                if (userip == "127.0.0.1")
                {
                    result = "192.168.0.1";
                }

                string[] strIPs = userip.Split(new char[] { '.' });
                if (!OperateText.IsNumber(strIPs[0]) || strIPs[0].Length > 3 || !OperateText.IsNumber(strIPs[1]) || strIPs[1].Length > 3 || !OperateText.IsNumber(strIPs[2]) || strIPs[2].Length > 3 || !OperateText.IsNumber(strIPs[3]) || strIPs[3].Length > 3)
                {
                    return "IP地址错误";
                }
                //if(strIPs[0]=="0" || strIPs[1]=="0" || strIPs[2]=="0" || strIPs[3]=="0")
                //{}
                //else
                //{
                tnum = long.Parse(strIPs[0]) * 16777216 + long.Parse(strIPs[1]) * 65536 + long.Parse(strIPs[2]) * 256 + long.Parse(strIPs[3]) - 1;
                // tSQL="select top 1 country,city from ipdata where ip1 <=" + tnum + "and ip2>="+tnum;
                DataSet ds = dal.GetList(" ip1 <=" + tnum + "and ip2>=" + tnum);
                if (ds.Tables.Count < 1)
                {
                }
                else
                {
                    DataRow row = ds.Tables[0].Rows[0];
                    result = row[2].ToString() + row[3].ToString();
                }
                //}               
            }
            else
            {
                result = userip;
            }
            return result;
        }


        #region 自定义方法

        #endregion
    }
}

