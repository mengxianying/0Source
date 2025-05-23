using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using Pbzx.Model;
using Pbzx.DALFactory;
using Pbzx.IDAL;
using System.Web.UI.WebControls;
using System.Text;
namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���CstSoftware ��ժҪ˵����
    /// </summary>
    public class CstSoftware
    {
        private readonly ICstSoftware dal = DataAccess.CreateCstSoftware();

        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("CstSoftware", "CstID");
        public CstSoftware()
        {
            basicDAL.IsCst = true;
        }

        #region  ��Ա����

        /// <summary>
        /// �õ����ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int CstID)
        {
            return dal.Exists(CstID);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Add(Pbzx.Model.CstSoftware model)
        {
            return dal.Add(model) > 0 ? true : false;
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public bool Update(Pbzx.Model.CstSoftware model)
        {
            return dal.Update(model) > 0 ? true : false;
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public bool Delete(int CstID)
        {

            return dal.Delete(CstID) > 0 ? true : false;
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.CstSoftware GetModel(int CstID)
        {

            return dal.GetModel(CstID);
        }

        /// <summary>
        /// �õ�һ������ʵ�壬�ӻ����С�
        /// </summary>
        public Pbzx.Model.CstSoftware GetModelByCache(int CstID)
        {

            string CacheKey = "CstSoftwareModel-" + CstID;
            object objModel = LTP.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(CstID);
                    if (objModel != null)
                    {
                        int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
                        LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (Pbzx.Model.CstSoftware)objModel;
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
        public List<Pbzx.Model.CstSoftware> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            List<Pbzx.Model.CstSoftware> modelList = new List<Pbzx.Model.CstSoftware>();
            int rowsCount = ds.Tables[0].Rows.Count;
            if (rowsCount > 0)
            {
                Pbzx.Model.CstSoftware model;
                for (int n = 0; n < rowsCount; n++)
                {
                    model = new Pbzx.Model.CstSoftware();
                    if (ds.Tables[0].Rows[n]["CstID"].ToString() != "")
                    {
                        model.CstID = int.Parse(ds.Tables[0].Rows[n]["CstID"].ToString());
                    }
                    model.CstName = ds.Tables[0].Rows[n]["CstName"].ToString();
                    if (ds.Tables[0].Rows[n]["SoftwareType"].ToString() != "")
                    {
                        model.SoftwareType = int.Parse(ds.Tables[0].Rows[n]["SoftwareType"].ToString());
                    }
                    model.SoftwareName = ds.Tables[0].Rows[n]["SoftwareName"].ToString();
                    model.SoftwareNameColor = ds.Tables[0].Rows[n]["SoftwareNameColor"].ToString();
                    if (ds.Tables[0].Rows[n]["InstallType"].ToString() != "")
                    {
                        model.InstallType = int.Parse(ds.Tables[0].Rows[n]["InstallType"].ToString());
                    }
                    model.InstallName = ds.Tables[0].Rows[n]["InstallName"].ToString();
                    model.InstallNameColor = ds.Tables[0].Rows[n]["InstallNameColor"].ToString();
                    if (ds.Tables[0].Rows[n]["Flag"].ToString() != "")
                    {
                        model.Flag = int.Parse(ds.Tables[0].Rows[n]["Flag"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["YearMoney"].ToString() != "")
                    {
                        model.YearMoney = int.Parse(ds.Tables[0].Rows[n]["YearMoney"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["LifeMoney"].ToString() != "")
                    {
                        model.LifeMoney = int.Parse(ds.Tables[0].Rows[n]["LifeMoney"].ToString());
                    }
                    if (ds.Tables[0].Rows[n]["VersionType"].ToString() != "")
                    {
                        model.VersionType = int.Parse(ds.Tables[0].Rows[n]["VersionType"].ToString());
                    }
                    model.VersionTypeName = ds.Tables[0].Rows[n]["VersionTypeName"].ToString();
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


        #region �Զ��巽��



        /// <summary>
        /// '����������
        ///������2009��5��13���޸�
        /// </summary>
        /// <param name="num">�������</param>
        /// <returns></returns>
        public string Chksofttype(object num)
        {
            int intNum = int.Parse(num.ToString());
            DataSet ds = dal.GetList("SoftwareType=" + intNum);
            string softtype = "";
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (row["SoftwareType"].ToString() == num.ToString())
                    {
                        softtype = "<font color='" + row[4].ToString() + "'>" + row[3].ToString() + "</font>";
                        break;
                    }
                }
            }

            if ("" == softtype)
            {
                if (num.ToString() == "100")
                {
                    softtype = "ȫ��";
                }
                else
                {
                    softtype = "<font color='#666666'>δ֪</font>";
                }
            }

            return softtype;
        }

        //��װ����
        public string Chksofttype2(object num)
        {
            int intNum = int.Parse(num.ToString());
            DataSet ds = dal.GetList("InstallType=" + intNum);
            string softtype = "";
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (row["InstallType"].ToString() == num.ToString())
                    {
                        softtype = "<font color='" + row[7].ToString() + "'>" + row[6].ToString() + "</font>";
                        break;
                    }
                }
            }

            if ("" == softtype)
            {
                if (num.ToString() == "100")
                {
                    softtype = "ȫ��";
                }
                else
                {
                    softtype = "<font color='#666666'>δ֪</font>";
                }
            }

            return softtype;
        }




        /// <summary>
        /// �õ�������ͺͰ�װ����
        /// </summary>
        /// <param name="objSoftwareType">�������</param>
        /// <param name="objInstallType">��װ����</param>
        /// <returns>���</returns>
        public string[] Chksettype(object objSoftwareType, object objInstallType)
        {
            string[] result = new string[] { "", "" };
            int intNum = int.Parse(objSoftwareType.ToString());
            int intSt = int.Parse(objInstallType.ToString());
            //object objColor  basicDAL.GetValueBySql("Select SoftwareNameColor from [CstSoftware] where SoftwareType="+intNum);
            DataSet ds = dal.GetList("SoftwareType=" + intNum + " and InstallType=" + intSt);

            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (row["SoftwareType"].ToString() == objSoftwareType.ToString() && row["InstallType"].ToString() == objInstallType.ToString())
                    {
                        result[0] = "<font color='" + row["SoftwareNameColor"].ToString() + "'>" + row["SoftwareName"].ToString() + "</font>";

                        result[1] += "<font color='" + row["InstallNameColor"].ToString() + "'>" + row["InstallName"].ToString() + "</font>";
                        break;
                    }
                }
            }

            if (result[0] == "")
            {
                if (objSoftwareType.ToString() == "100")
                {
                    result[0] = "ȫ��";
                }
                else
                {
                    result[0] = "<font color='#666666'>δ֪</font>";
                }
            }

            if (result[1] == "")
            {
                if (objInstallType.ToString() == "100")
                {
                    result[1] = "ȫ��";
                }
                else
                {
                    result[1] = "<font color='#666666'>δ֪</font>";
                }
            }

            return result;
        }



        public string[] Chksettypeid(object objSoftwareType, object objInstallType)
        {
            string[] result = new string[] { "", "" };
            int intNum = int.Parse(objSoftwareType.ToString());
            int intSt = int.Parse(objInstallType.ToString());
            DataSet ds = dal.GetList("SoftwareType=" + intNum + " and InstallType=" + intSt);
            if (ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow row in dt.Rows)
                {
                    if (row["SoftwareType"].ToString() == objSoftwareType.ToString() && row["InstallType"].ToString() == objInstallType.ToString())
                    {
                        result[0] = row["SoftwareName"].ToString();

                        result[1] = row["InstallName"].ToString();
                        break;
                    }
                }
            }
            return result;
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "CstSoftware", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        /// <summary>
        /// ִ��SQL��ȡ�����б�.
        /// </summary>
        public DataTable GetLisBySql(string strSql)
        {
            return basicDAL.GetLisBySql(strSql);
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="list"></param>
        public void BindSoftwareType(System.Web.UI.Control aa)
        {
            DataTable dt = GetLisBySql("Select SoftwareName as SoftwareName from [CstSoftware] Group By SoftwareName order by min(CstID) ");
            if (aa is System.Web.UI.WebControls.DropDownList)
            {
                DropDownList list = ((System.Web.UI.WebControls.DropDownList)aa);
                list.DataTextField = "SoftwareName";
                list.DataValueField = "SoftwareName";
                list.DataSource = dt;
                list.DataBind();
                list.Items.Insert(0, new ListItem("����", ""));
            }
            else if (aa is System.Web.UI.WebControls.ListBox)
            {
                ListBox list = ((System.Web.UI.WebControls.ListBox)aa);
                list.DataTextField = "SoftwareName";
                list.DataValueField = "SoftwareName";
                list.DataSource = dt;
                list.DataBind();
                list.Items.Insert(0, new ListItem("����", ""));
            }
        }

        /// <summary>
        /// ���������
        /// </summary>
        /// <param name="list"></param>
        public void BindProductVersionType(System.Web.UI.Control aa)
        {
            DataTable dt = GetLisBySql("Select max(VersionType) as VersionType, VersionTypeName as VersionTypeName from [CstSoftware] Group By VersionTypeName  order by min(CstID)");
            if (aa is System.Web.UI.WebControls.DropDownList)
            {
                DropDownList list = ((System.Web.UI.WebControls.DropDownList)aa);
                list.DataTextField = "VersionTypeName";
                list.DataValueField = "VersionType";
                list.DataSource = dt;
                list.DataBind();
                list.Items.Insert(0, new ListItem("����", ""));
            }
            else if (aa is System.Web.UI.WebControls.ListBox)
            {
                ListBox list = ((System.Web.UI.WebControls.ListBox)aa);
                list.DataTextField = "VersionTypeName";
                list.DataValueField = "VersionType";
                list.DataSource = dt;
                list.DataBind();
                list.Items.Insert(0, new ListItem("����", ""));
            }
        }


        /// <summary>
        /// �󶨰�װ����
        /// </summary>
        /// <param name="list"></param>
        public void BindInstallType(DropDownList list)
        {
            DataTable dt = GetLisBySql("select distinct InstallName from dbo.CstSoftware ");
            list.DataTextField = "InstallName";
            list.DataValueField = "InstallName";
            list.DataSource = dt;
            list.DataBind();
            list.Items.Insert(0, new ListItem("����", ""));
        }

        /// <summary>
        /// ����������ͱ�ŵõ���Ӧ�İ�װ����
        /// </summary>
        public string GetInstallTypes(string SoftwareName)
        {
            DataTable dt = GetLisBySql("select  InstallName from dbo.CstSoftware where SoftwareName='" + SoftwareName + "' order by CstID  ");
            if (dt.Rows.Count > 0)
            {
                StringBuilder strbu = new StringBuilder();
                foreach (DataRow row in dt.Rows)
                {
                    strbu.Append(row["InstallName"] + "&" + row["InstallName"] + ",");
                }
                return strbu.ToString().Length >= 1 ? strbu.Remove(strbu.Length - 1, 1).ToString() : "";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// ����������ͱ�ŵõ���Ӧ�İ�װ����
        /// </summary>
        public void GetInstallTypes(string SoftwareName, DropDownList list)
        {
            DataTable dt = GetLisBySql("select  InstallType,InstallName from dbo.CstSoftware where SoftwareName='" + SoftwareName + "' order by CstID ");
            list.DataTextField = "InstallName";
            list.DataValueField = "InstallType";
            list.DataSource = dt;
            list.DataBind();
            list.Items.Insert(0, new ListItem("����", ""));
        }

        public bool IsExists(string swtype, string instype)
        {
            if (GetModelList(" SoftwareName='" + swtype + "' and InstallName='" + instype + "'").Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        /// <summary>
        /// ִ��SQL��ȡ�����б�.
        /// </summary>
        //public DataTable GetLisBySql(string strSql)
        //{
        //    Pbzx.SQLServerDAL.Basic bac = new Pbzx.SQLServerDAL.Basic("CstSoftware", "CstID");
        //    return bac.GetLisBySql(strSql);
        //}

        ///<summary>
        ///������ݿ��е���������
        ///
        public void BindClass(DropDownList list)
        {
 //           Pbzx.Common.ErrorLog.WriteLogMeng("��������", "select DISTINCT softwareType,installType, flag from [CN_Software] where flag=1 order by softwareType Desc", true, true);  
            DataTable dt = GetLisBySql("select DISTINCT softwareType,installType, flag from [CN_Software] where flag=1 order by softwareType Desc,installType ASC");
 //           Pbzx.Common.ErrorLog.WriteLogMeng("��������", "sqlִ�����", true, true);  
            ;
            int i = 0;
            foreach (DataRow row in dt.Rows)
            {
                //2020-02-15��� start
                DataTable dtNew = GetLisBySql("select  SoftwareName,InstallName from [CstSoftware] where SoftwareType=" + row["softwareType"].ToString() + " and  installType=" + row["installType"].ToString() + "  order by CstName ");
                if (dtNew != null && dtNew.Rows.Count > 0)
                {
                    list.Items.Add(new ListItem(dtNew.Rows[0]["SoftwareName"].ToString() + dtNew.Rows[0]["InstallName"].ToString(), row["SoftwareType"].ToString() + "-" + row["InstallType"].ToString()));                   
                }
                //2020-02-15��� end                
                i++;
            }
 //           Pbzx.Common.ErrorLog.WriteLogMeng("��������", "ѭ��ִ�����", true, true);  
        }

        public string GetIdByName(string column, string value, string resultColumn)
        {
            if (value == "����6 1") {
                value = "����6+1";
            }
            DataTable dt = GetLisBySql("select top 1 " + resultColumn + " from dbo.CstSoftware where " + column + "='" + value + "'  ");
            return dt.Rows[0][resultColumn].ToString();
        }

    }
}

