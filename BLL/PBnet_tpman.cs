using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Web;
using Pbzx.Common;
namespace Pbzx.BLL
{
	/// <summary>
	/// 业务逻辑类PBnet_tpman 的摘要说明。
	/// </summary>
	public class PBnet_tpman
	{
		private readonly IPBnet_tpman dal=DataAccess.CreatePBnet_tpman();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_tpman", "Master_Id"); 
		public PBnet_tpman()
		{}
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
		public bool Exists(int Master_Id)
		{
			return dal.Exists(Master_Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool  Add(Pbzx.Model.PBnet_tpman model)
		{
            return dal.Add(model) > 0 ? true : false; 
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Pbzx.Model.PBnet_tpman model)
		{
             return dal.Update(model) > 0 ? true : false; 
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Master_Id)
		{

            return dal.Delete(Master_Id) > 0 ? true : false; 
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Pbzx.Model.PBnet_tpman GetModel(int Master_Id)
		{
			
			return dal.GetModel(Master_Id);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public Pbzx.Model.PBnet_tpman GetModelByCache(int Master_Id)
		{
			
			string CacheKey = "PBnet_tpmanModel-" + Master_Id;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(Master_Id);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Pbzx.Model.PBnet_tpman)objModel;
		}

        /// <summary>
        /// 根据姓名得到一个对象实体，从缓存中。
        /// </summary>
        public Pbzx.Model.PBnet_tpman GetModelByCache(string Master_Name)
        {

            string CacheKey = "PBnet_tpmanModel-" + Master_Name;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModelByName(Master_Name);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_tpman)objModel;
        }


        /// <summary>
        /// 根据用户名和密码检测是否是合法用户
        /// </summary>
        /// <param name="uName"></param>
        /// <param name="uPwd"></param>
        /// <returns></returns>
        public bool CheckUser(string uName, string uPwd)
        {
            return GetModelByCache(uName).Master_Password ==Pbzx.Common.Input.MD5(uPwd, true) ? true : false;
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
        public DataSet GetList()
        {
            return GetAllList();
        }


		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Pbzx.Model.PBnet_tpman> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			List<Pbzx.Model.PBnet_tpman> modelList = new List<Pbzx.Model.PBnet_tpman>();
			int rowsCount = ds.Tables[0].Rows.Count;
			if (rowsCount > 0)
			{
				Pbzx.Model.PBnet_tpman model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Pbzx.Model.PBnet_tpman();
					if(ds.Tables[0].Rows[n]["Master_Id"].ToString()!="")
					{
						model.Master_Id=int.Parse(ds.Tables[0].Rows[n]["Master_Id"].ToString());
					}
					model.Master_Name=ds.Tables[0].Rows[n]["Master_Name"].ToString();
					model.Master_Password=ds.Tables[0].Rows[n]["Master_Password"].ToString();
					model.Column_Setting=ds.Tables[0].Rows[n]["Column_Setting"].ToString();
					model.Setting=ds.Tables[0].Rows[n]["Setting"].ToString();
					if(ds.Tables[0].Rows[n]["LasTime"].ToString()!="")
					{
						model.LasTime=DateTime.Parse(ds.Tables[0].Rows[n]["LasTime"].ToString());
					}
					model.LastIP=ds.Tables[0].Rows[n]["LastIP"].ToString();
					model.Cookiess=ds.Tables[0].Rows[n]["Cookiess"].ToString();
					if(ds.Tables[0].Rows[n]["State"].ToString()!="")
					{
						if((ds.Tables[0].Rows[n]["State"].ToString()=="1")||(ds.Tables[0].Rows[n]["State"].ToString().ToLower()=="true"))
						{
						    model.State=true;
						}
						else
						{
							model.State=false;
						}
					}
					model.CpData_Setting=ds.Tables[0].Rows[n]["CpData_Setting"].ToString();
                    if (ds.Tables[0].Rows[n]["LoginCount"].ToString() != "")
                    {
                        model.LoginCount = int.Parse(ds.Tables[0].Rows[n]["LoginCount"].ToString());
                    }
                    model.ipLimit = ds.Tables[0].Rows[n]["ipLimit"].ToString();
                    model.regionLimit = ds.Tables[0].Rows[n]["regionLimit"].ToString();
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



        public bool ValidateLogin(string UserName, string Password)
        {
            bool result = false;
           
            Pbzx.Model.PBnet_tpman MyAdmin = dal.GetModelByName(UserName);
            Pbzx.BLL.PBnet_WebLog LogBLL = new PBnet_WebLog();
            Pbzx.Model.PBnet_WebLog MyLog = new Pbzx.Model.PBnet_WebLog();
            MyLog.UserIP = Pbzx.Common.Method.GetUserIP();
            MyLog.ActionType = "后台登录";
            MyLog.Operator = UserName;

            if (MyAdmin != null)
            {
                if (MyAdmin.Master_Id == 0)
                {
                    MyLog.Detail = "登录失败[用户名不存在].";
                }
                else if(!MyAdmin.State)
                {
                    MyLog.Detail = "登录失败[用户已禁止登录].";
                }
                else
                {
                    if (MyAdmin.Master_Password == Pbzx.Common.Input.MD5(Password, false))
                    {
                        result = true;
                        MyLog.Detail = "登录成功.";
                    }
                    else
                    {
                        MyLog.Detail = "登录失败[密码错误].";
                    }
                }                
            }
            else
            {
                MyLog.Detail = "登录失败[用户名不存在]"; 
            }
            LogBLL.Add(MyLog);
            return result;
        }

        public void WriteWebLog(string username, string code1, string code2)
        {
            Pbzx.BLL.PBnet_WebLog LogBLL = new PBnet_WebLog();

            Pbzx.Model.PBnet_WebLog MyLog = new Pbzx.Model.PBnet_WebLog();
            MyLog.UserIP = Pbzx.Common.Method.GetUserIP();
            MyLog.ActionType = "后台登录";
            MyLog.Operator = username;
            MyLog.Detail = string.Format("验证码错误[应为:{0},输入:{1}].", code1, code2);
            LogBLL.Add(MyLog);
        }

        public Pbzx.Model.PBnet_tpman GetEntityByUserName(string UserName)
        {
            return dal.GetModelByName(UserName);
        }

        public void UpdateInfo(Pbzx.Model.PBnet_tpman MyEntity)
        {
            MyEntity.LasTime = DateTime.Now;
            MyEntity.LoginCount++;
            if (System.Web.HttpContext.Current.Request.UserHostAddress != null)
            {
                MyEntity.LastIP = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            }
            this.Update(MyEntity);
        }


        public static void IsLogin()
        {
            if (!(System.Web.HttpContext.Current.Request.Cookies["AdminManager"] != null && System.Web.HttpContext.Current.Request.Cookies["AdminManager"].Value != ""))
            {
                System.Web.HttpContext.Current.Response.Write("<script>window.top.location='/PB_Manage/AdminLogin.aspx';</script>");
                System.Web.HttpContext.Current.Response.End();
                return;
               // System.Web.HttpContext.Current.Response.Redirect("~/PB_Manage/AdminLogin.aspx", true);
            }
        }
        public static void IsLoginSoftware()
        {
            if (!(System.Web.HttpContext.Current.Request.Cookies["AdminManager"] != null && System.Web.HttpContext.Current.Request.Cookies["AdminManager"].Value != ""))
            {
                System.Web.HttpContext.Current.Response.Write("<script>window.top.location='" + WebInit.webBaseConfig.WebUrl + "PB_Manage/AdminLogin.aspx';</script>");
                System.Web.HttpContext.Current.Response.End();
                return;
                // System.Web.HttpContext.Current.Response.Redirect("~/PB_Manage/AdminLogin.aspx", true);
            }
        }
        public static void CheckUserPower()
        {
            Pbzx.Model.PBnet_tpman nowMgr = GetNowUser();

        }

        public static Pbzx.Model.PBnet_tpman GetNowUser()
        {
           Pbzx.Model.PBnet_tpman MyAdmin;
            if (0 == 0)
            {
                Pbzx.BLL.PBnet_tpman tpmanBll = new PBnet_tpman();

                HttpCookie aCookie = HttpContext.Current.Request.Cookies["AdminManager"];

                MyAdmin = tpmanBll.GetEntityByUserName(Input.Decrypt(aCookie.Value)); 
                //MyAdmin = (Pbzx.Model.PBnet_tpman)System.Web.HttpContext.Current.Session["Admin"];
            }
            else
            {
                //System.Web.HttpCookie MyCookie = System.Web.HttpContext.Current.Request.Cookies["Admin"];
                //if (MyCookie != null)
                //{
                //    int AdminID = Convert.ToInt32(MyCookie.Value);
                //    MyAdmin =  new Pbzx.BLL.PBnet_tpman().GetModel(AdminID);
                //}
                //else
                //{
                //    return null;
                //}
            }
            return MyAdmin;
        }

        public bool Save(Pbzx.Model.PBnet_tpman MyUser)
        {
            bool result = false;
            Pbzx.Model.PBnet_WebLog MyLog = new Pbzx.Model.PBnet_WebLog();

            Pbzx.BLL.PBnet_WebLog LogBLL = new PBnet_WebLog();

            MyLog.Operator = Input.Decrypt(System.Web.HttpContext.Current.Request.Cookies["AdminManager"].Value);
            MyLog.UserIP = Pbzx.Common.Method.GetUserIP();
            if (MyUser.Master_Id == 0)
            {
                result = Add(MyUser);                 
                MyLog.ActionType = "新增";
                MyLog.Detail = string.Format("新增管理员用户[{0}].", MyUser.Master_Name);
            }
            else
            {
                result = Update(MyUser);
                MyLog.ActionType = "修改";
                MyLog.Detail = string.Format("修改管理员用户[{0}]资料.", MyUser.Master_Name);
            }
            if (result)
            {
                LogBLL.Add(MyLog);
               
            }
            return result;
        }


		#endregion  成员方法

        /// <summary>
        /// 根据查询字符串获取分页数据
        /// </summary>
        /// <param name="SearchStr">查询字符串</param>
        /// <param name="getFileds">获取列</param>
        /// <param name="OrderStr">排序字段</param>
        /// <param name="PageNum">获取的数据数</param>
        /// <param name="CurrentPage">当前的页数</param>
        /// <param name="Counts">返回记录集总数</param>
        /// <returns></returns>
        public DataTable GuestGetBySearch( string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage,out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_tpman", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }
        
	}
}

