using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Web;
using Maticsoft.DBUtility;
using Pbzx.Common;

namespace Pbzx.BLL
{
    public class PBnet_WebLog
    {
        private readonly Pbzx.SQLServerDAL.PBnet_WebLog dal = new Pbzx.SQLServerDAL.PBnet_WebLog();
      //  private readonly IPBnet_WebLog dal = DataAccess.CreatePBnet_WebLog();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("AgentInfo", "ID");
   
        
        public PBnet_WebLog()
        { 
              basicDAL.IsCst = false;
        }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int ID)
        {
            return dal.Exists(ID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.PBnet_WebLog model)
        {
            return dal.Add(model) > 0 ? true : false ;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_WebLog model)
        {
            return dal.Update(model) > 0 ? true : false ;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int ID)
        {

            return dal.Delete(ID) > 0 ? true : false ;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_WebLog GetModel(int ID)
        {

            return dal.GetModel(ID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_WebLog GetModelByCache(int ID)
        {

            string CacheKey = "PBnet_WebLogModel-" + ID;
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
            return (Pbzx.Model.PBnet_WebLog)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_WebLog> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.PBnet_WebLog> modelList = new List<Pbzx.Model.PBnet_WebLog>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_WebLog model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_WebLog();
                    if (ds.Tables[0].Rows[n]["ID"].ToString() != "")
                    {
                        model.ID = int.Parse(ds.Tables[0].Rows[n]["ID"].ToString());
                    }
                    model.ActionType = ds.Tables[0].Rows[n]["ActionType"].ToString();
                    model.Detail = ds.Tables[0].Rows[n]["Detail"].ToString();
                    model.Operator = ds.Tables[0].Rows[n]["Operator"].ToString();
                    model.UserIP = ds.Tables[0].Rows[n]["UserIP"].ToString();
                    if (ds.Tables[0].Rows[n]["ActionTime"].ToString() != "")
                    {
                        model.ActionTime = DateTime.Parse(ds.Tables[0].Rows[n]["ActionTime"].ToString());
                    }
                    modelList.Add(model);
                }
            }
            return modelList;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetAllList()
        {
            return GetList("");
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        //public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        //{
        //return dal.GetList(PageSize,PageIndex,strWhere);
        //}

        #endregion  ��Ա����

        public static bool WriteMasterOperate(string action, string detail)
        {
            Pbzx.SQLServerDAL.Basic basicDAL1 = new Pbzx.SQLServerDAL.Basic("AgentInfo", "ID");
            basicDAL1.IsCst = false;
            PBnet_WebLog LogBLL = new PBnet_WebLog();
            Pbzx.Model.PBnet_WebLog MyLog = new Pbzx.Model.PBnet_WebLog();
            System.Web.HttpCookie aCookie = HttpContext.Current.Request.Cookies["AdminManager"];
            MyLog.Operator = Input.Decrypt(aCookie.Value);             
                //System.Web.HttpContext.Current.Request.Cookies["AdminManager"].Value;
            MyLog.UserIP = Pbzx.Common.Method.GetUserIP();
            MyLog.ActionType = action;
            MyLog.Detail = detail;
            return LogBLL.Add(MyLog);
        }


        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// </summary>
        /// <param name="SearchStr">��ѯ�ַ��� </param>
        /// <param name="getFileds">��ȡ��</param>
        /// <param name="OrderStr">�����ֶ�</param>
        /// <param name="PageNum">��ȡ��������</param>
        /// <param name="desc">�����ǽ���</param>
        /// <param name="CurrentPage">��ǰ��ҳ��</param>
        /// <param name="Counts">���ؼ�¼������</param>
        /// <returns></returns>

        public DataTable GuestGetBySearch(string SearchStr, string getFileds, string OrderStr, int PageNum, int orderType, int CurrentPage, out int Counts)
        {
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_WebLog", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// ���ݣɣ�����ɾ��ɾ������
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public int BatchDel(string strID)
        {
            string sql = "DELETE FROM PBnet_WebLog WHERE ID IN(" + strID + ")";
            return DbHelperSQL.ExecuteSql(sql);

        }
    }
}
