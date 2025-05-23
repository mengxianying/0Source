using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using Pbzx.Common;
namespace Pbzx.BLL
{
    /// <summary>
    /// 业务逻辑类PBnet_UserProtectPwd 的摘要说明。
    /// </summary>
    public class PBnet_UserProtectPwd
    {
        private readonly IPBnet_UserProtectPwd dal = DataAccess.CreatePBnet_UserProtectPwd();
        public PBnet_UserProtectPwd()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_UserProtectPwd model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_UserProtectPwd model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

           return dal.Delete(ID) > 0 ? true : false;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_UserProtectPwd GetModel(int ID)
        {

            return dal.GetModel(ID);
        }
        /// <summary>
        /// 根据用户名得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_UserProtectPwd GetModelName(string UserName)
        {

            return dal.GetModelName(UserName);
        }

        /// <summary>
        /// 自己定义根据用户名得到一个对象实体
        /// </summary>
        public Pbzx.Model.PBnet_UserProtectPwd GetModelPwdName(string Name)
        {

            List<Pbzx.Model.PBnet_UserProtectPwd> ls = GetModelList(" UserName='" +  Input.FilterAll(Name) + "'");
            if (ls.Count > 0)
            {
                return ls[0];
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_UserProtectPwd GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_UserProtectPwdModel-" + ID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(ID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_UserProtectPwd)objModel;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_UserProtectPwd> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Pbzx.Model.PBnet_UserProtectPwd> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_UserProtectPwd> modelList = new List<Pbzx.Model.PBnet_UserProtectPwd>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_UserProtectPwd model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_UserProtectPwd();
                    if (dt.Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(dt.Rows[n]["ID"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.SecurityQuestion = dt.Rows[n]["SecurityQuestion"].ToString();
                    model.Answer = dt.Rows[n]["Answer"].ToString();
                    model.CardID = dt.Rows[n]["CardID"].ToString();
                    model.Mobile = dt.Rows[n]["Mobile"].ToString();
                    model.Email = dt.Rows[n]["Email"].ToString();
                    if (dt.Rows[n]["type"].ToString() != "")
                    {
                        model.type = int.Parse(dt.Rows[n]["type"].ToString());
                    }
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
        /// 根据判断是否存在该用户
        /// </summary>    
        public bool ExistsUser(string Name)
        {
                IList<Pbzx.Model.PBnet_UserProtectPwd> User = DataTableToList(dal.GetList(" UserName='" + Input.FilterAll(Name) + "'").Tables[0]);
                if (User.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }          
        }
        //public bool ExistsEmail(string Name, string txtEmail)
        //{
        //    List<Pbzx.Model.PBnet_UserProtectPwd> Mymodel = DataTableToList(dal.GetList(" UserName='" + Name + "'").Tables[0]);
        //    if (Mymodel.Count < 0)
        //    {
        //        return false;
        //    }
        //    else if (Mymodel[0].Email != txtEmail)
        //    {
        //        return false;
        //    }
        //    return true;
        //}
        //public bool ExistsAsk(string Name, string Question, string Answer)
        //{
        //    bool flag = true;
        //    List<Pbzx.Model.PBnet_UserProtectPwd> Mymodel = DataTableToList(dal.GetList(" UserName='" + Name + "'").Tables[0]);
        //    if (Mymodel.Count > 0)
        //    {
        //        if (Mymodel[0].SecurityQuestion != Question && Mymodel[0].Answer != Answer)
        //        {
        //            flag = true;
        //        }
        //        else
        //        {
        //            flag = false;
        //        }
        //    }
        //    else
        //    {
        //        flag = false;
        //    }
        //    return flag;
        //}
        public bool ExistsAsk(string UserName,string Question,string Answer)
        {
            Pbzx.Model.PBnet_UserProtectPwd Mymodel = GetModelName(UserName);
            if (Mymodel.SecurityQuestion == Question && Mymodel.Answer == Answer)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool ExistsEmail(string UserName, string Email)
        {
            Pbzx.Model.PBnet_UserProtectPwd Mymodel = GetModelName(UserName);
            if (Mymodel.Email == Email)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}

