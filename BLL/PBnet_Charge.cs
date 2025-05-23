using System;
using System.Collections.Generic;
using System.Text;
using Pbzx.IDAL;
using System.Data;
using Pbzx.DALFactory;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���PBnet_Charge ��ժҪ˵����
    /// </summary>
    public class PBnet_Charge
    {
        private readonly IPBnet_Charge dal = DataAccess.CreatePBnet_Charge();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("PBnet_Charge", "Id");
        public PBnet_Charge()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Id)
        {
            return dal.Exists(Id);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.PBnet_Charge model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.PBnet_Charge model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int Id)
        {

            return dal.Delete(Id) > 0 ? true : false;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.PBnet_Charge GetModel(int Id)
        {

            return dal.GetModel(Id);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.PBnet_Charge GetModelByCache(int Id)
        {

            string CacheKey = "PBnet_ChargeModel-" + Id;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(Id);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.PBnet_Charge)objModel;
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ǰ��������
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_Charge> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// ��������б�
        /// </summary>
        public List<Pbzx.Model.PBnet_Charge> DataTableToList(DataTable dt)
        {
            List<Pbzx.Model.PBnet_Charge> modelList = new List<Pbzx.Model.PBnet_Charge>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.PBnet_Charge model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.PBnet_Charge();
                    if (dt.Rows[n]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(dt.Rows[n]["Id"].ToString());
                    }
                    model.OrderID = dt.Rows[n]["OrderID"].ToString();
                    if (dt.Rows[n]["UserID"].ToString() != "")
                    {
                        model.UserID = int.Parse(dt.Rows[n]["UserID"].ToString());
                    }
                    model.UserName = dt.Rows[n]["UserName"].ToString();
                    model.RealName = dt.Rows[n]["RealName"].ToString();
                    if (dt.Rows[n]["OrderDate"].ToString() != "")
                    {
                        model.OrderDate = DateTime.Parse(dt.Rows[n]["OrderDate"].ToString());
                    }
                    if (dt.Rows[n]["PayMoney"].ToString() != "")
                    {
                        model.PayMoney = decimal.Parse(dt.Rows[n]["PayMoney"].ToString());
                    }
                    if (dt.Rows[n]["PayTypeID"].ToString() != "")
                    {
                        model.PayTypeID = int.Parse(dt.Rows[n]["PayTypeID"].ToString());
                    }
                    model.PayTypeName = dt.Rows[n]["PayTypeName"].ToString();
                    if (dt.Rows[n]["HasPayedPrice"].ToString() != "")
                    {
                        model.HasPayedPrice = decimal.Parse(dt.Rows[n]["HasPayedPrice"].ToString());
                    }
                    model.PayNum = dt.Rows[n]["PayNum"].ToString();
                    model.c_memo1 = dt.Rows[n]["c_memo1"].ToString();
                    model.c_memo2 = dt.Rows[n]["c_memo2"].ToString();
                    if (dt.Rows[n]["Type"].ToString() != "")
                    {
                        model.Type = int.Parse(dt.Rows[n]["Type"].ToString());
                    }
                    if (dt.Rows[n]["State"].ToString() != "")
                    {
                        model.State = int.Parse(dt.Rows[n]["State"].ToString());
                    }
                    model.Remark = dt.Rows[n]["Remark"].ToString();
                    model.Result = dt.Rows[n]["Result"].ToString();
                    if (dt.Rows[n]["IsPay"].ToString() != "")
                    {
                        model.IsPay = int.Parse(dt.Rows[n]["IsPay"].ToString());
                    }
                    if (dt.Rows[n]["IsCancel"].ToString() != "")
                    {
                        model.IsCancel = int.Parse(dt.Rows[n]["IsCancel"].ToString());
                    }
                    if (dt.Rows[n]["UpdateStaticDate"].ToString() != "")
                    {
                        model.UpdateStaticDate = DateTime.Parse(dt.Rows[n]["UpdateStaticDate"].ToString());
                    }
                    if (dt.Rows[n]["OnlineType"].ToString() != "")
                    {
                        model.OnlineType = int.Parse(dt.Rows[n]["OnlineType"].ToString());
                    }
                    if (dt.Rows[n]["TipID"].ToString() != "")
                    {
                        model.TipID = int.Parse(dt.Rows[n]["TipID"].ToString());
                    }
                    model.TipName = dt.Rows[n]["TipName"].ToString();
                    model.UserIP = dt.Rows[n]["UserIP"].ToString();
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "PBnet_Charge", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }


        /// <summary>
        /// ���ݶ�����ŵõ�����model
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public Pbzx.Model.PBnet_Charge GetModelByOrderId(string OrderID)
        {
            List<Pbzx.Model.PBnet_Charge> lsCharge = GetModelList(" OrderID='" + Pbzx.Common.Input.FilterAll(OrderID) + "' ");
            if (lsCharge.Count < 0)
            {
                return null;
            }
            else
            {
                return lsCharge[0];
            }
        }
        /// <summary>
        /// �õ���ֵȡ���״̬
        /// </summary>
        /// <param name="state"></param>
        /// <param name="isCancel"></param>
        /// <returns></returns>
        public string GetState(object state,object isCancel)
        {
            string strSta = state.ToString();
            string strIsCancel = isCancel.ToString();
            string result = "";
            if(strIsCancel == "1")
            {
                return "�û�ȡ��";
            }
            else if (strIsCancel == "2")
            {
                return "ϵͳȡ��";
            }
            else
            {
                switch (strSta)
                {
                    case "0":
                        result = "������";//<span style='color:blue;'></span>
                        break;
                    case "1":
                        result = "��ͨ��";//<span style='color:green;'></span>
                        break;
                    case "2":
                        result = "���δͨ��";//<span  style='color:red;'></span>
                        break;
                }
            }
            return result;
        }

        public string GetZY(object type)
        {
            string result = "";

            if (type.ToString() == "0")
            {
                result = "��ֵ";
            }
            else if (type.ToString() == "1")
            {
                result += "ȡ��";


            }
            return result;
        }

        public string GetTotalMoney(string where)
        {
            string result = "";
            string sql = "select count(OrderID) as TotalID,sum(PayMoney) as TotalMoney  from PBnet_Charge";
            if (!string.IsNullOrEmpty(where))
            {
                sql += " where " + where;
            }
            DataTable dt =  basicDAL.GetLisBySql(sql);
            //DataSet ds = dal.Query(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                result = dt.Rows[0]["TotalID"] + "&" + dt.Rows[0]["TotalMoney"];
            }
            else
            {
                result = "0&0";
            }
            return result;
        }

    }
}
