using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Pbzx.IDAL;
using Pbzx.DALFactory;
using Pbzx.Common;

namespace Pbzx.BLL
{
    /// <summary>
    /// ҵ���߼���Help_TreeStructure ��ժҪ˵����
    /// </summary>
    public class Help_TreeStructure
    {
        private static readonly IHelp_TreeStructure dal = DataAccess.CreateHelp_TreeStructure();
        Pbzx.SQLServerDAL.Basic basicDAL = new Pbzx.SQLServerDAL.Basic("Help_TreeStructure", "Tree_id");
        public Help_TreeStructure()
        { }
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
        public bool Exists(int Tree_id)
        {
            return dal.Exists(Tree_id);
        }

        public bool Exists(string name, string lottery, int TreeName)
        {
            return dal.Exists(name, lottery,TreeName);
        }


        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Help_TreeStructure model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.Help_TreeStructure model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int Tree_id)
        {
            return dal.Delete(Tree_id);
        }
        public int Delete(string Noet)
        {
            return dal.Delete(Noet);
        }
        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Help_TreeStructure GetModel(int Tree_id)
        {
            return dal.GetModel(Tree_id);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        /// <summary>
        /// ���ݲ�ѯ�ַ�����ȡ��ҳ����
        /// ������: zhouwei
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
            return basicDAL.GuestGetBySearch(basicDAL.strPKName, "Help_TreeStructure", SearchStr, getFileds, OrderStr, PageNum, orderType, CurrentPage, out Counts);
        }

        //��ѯ�ڵ�
        //public DataTable GetListBySort(int typeID, string Tree_name)
        //{

        //    //DataTable dtResult = basicDAL.GetLisBySql("SELECT * FROM Help_TreeStructure where Tree_superiorNoet=" + typeID + " and 1!=1");
        //    //DataTable dtRoot = basicDAL.GetLisBySql("SELECT * FROM Help_TreeStructure where Tree_superiorNoet=" + typeID + " and Tree_name= " + "'" + Tree_name + "'" + "  ORDER BY Tree_id ASC ");
        //    //for (int i = 0; i < dtRoot.Rows.Count; i++)
        //    //{
        //    //    DataRow myResultRow = dtResult.NewRow();
        //    //    myResultRow.ItemArray = dtRoot.Rows[i].ItemArray;
        //    //    dtResult.Rows.Add(myResultRow);

                
        //    //    //DataTable dtSmall = basicDAL.GetLisBySql("SELECT * FROM Help_TreeStructure where Tree_superiorNoet='" + dtRoot.Rows[i]["Tree_num"] + "' and Tree_name='" + Tree_name + "'  ORDER BY Tree_id ASC ");
        //    //    //for (int j = 0; j < dtSmall.Rows.Count; j++)
        //    //    //{
        //    //    //    DataRow myResultRow1 = dtResult.NewRow();
        //    //    //    myResultRow1.ItemArray = dtSmall.Rows[j].ItemArray;
        //    //    //    dtResult.Rows.Add(myResultRow1);

        //    //    //    DataTable dsTree = basicDAL.GetLisBySql("SELECT * FROM Help_TreeStructure where Tree_superiorNoet='" + dtSmall.Rows[j]["Tree_num"] + "' and Tree_name='" + Tree_name + "'  ORDER BY Tree_id ASC ");
        //    //    //    for (int k = 0; k < dsTree.Rows.Count; k++)
        //    //    //    {
        //    //    //        DataRow myResultRow2 = dtResult.NewRow();
        //    //    //        myResultRow2.ItemArray = dsTree.Rows[k].ItemArray;
        //    //    //        dtResult.Rows.Add(myResultRow2);
        //    //    //    }
        //    //    //}
        //    //}
        //    return dtResult;
        //}
        //��ѯ�ڵ�
        public DataTable GetListBySort(string Tree_name)
        {
            DataTable dtResult = basicDAL.GetLisBySql("SELECT * FROM Help_TreeStructure where Tree_name=" + "'" + Tree_name + "'" +" order by Tree_sort asc");
            return dtResult;
        }


        /// <summary>
        /// ����Ƶ��ID���ɾ�̬ҳ�棨���ݲ���ѡ���Ƿ����ɸ�Ƶ����������������ҳ�棩
        /// </summary>
        /// <param name="ID">��ǰƵ�����</param>
        /// <param name="isAllCreate"></param>
        /// <returns></returns>
        public void CreatHtmlByChannelID(int ID, string aspxHtml, bool isAllCreate)
        {
            if (!isAllCreate)
            {
                Pbzx.Model.Help_TreeStructure model = GetModel(ID);
                if (aspxHtml.IndexOf(".aspx") < 0)
                {
                    System.Web.HttpContext.Current.Server.Execute("/" + aspxHtml + ".aspx");
                    System.Web.HttpContext.Current.Response.Write("<script>alert('����" + model.Tree_RootNotd.Trim() + "�ɹ���');</script>");
                }
                else if (aspxHtml.IndexOf("RefurbishCpXml.aspx") > 0)
                {
                    System.Web.HttpContext.Current.Server.Execute(aspxHtml);
                }
                else
                {
                    if (Files.Create(model.Tree_Path, aspxHtml))
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>alert('����" + model.Tree_RootNotd.Trim() + "�ɹ���');</script>");
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>alert('����" + model.Tree_RootNotd.Trim() + "ʧ�ܣ�');</script>");
                    }
                }
            }
            else
            {
                Pbzx.Model.Help_TreeStructure model = GetModel(ID);
                if (aspxHtml.IndexOf(".aspx") < 0)
                {
                    System.Web.HttpContext.Current.Server.Execute("/" + aspxHtml + ".aspx");
                    System.Web.HttpContext.Current.Response.Write("<script>alert('����" + model.Tree_RootNotd.Trim() + "�ɹ���');</script>");
                }
                else if (aspxHtml.IndexOf("RefurbishCpXml.aspx") > 0)
                {
                    System.Web.HttpContext.Current.Server.Execute(aspxHtml);
                }
                else
                {
                    Files.Create(model.Tree_Path, aspxHtml);
                    System.Web.HttpContext.Current.Response.Write("<script>alert('����" + model.Tree_RootNotd.Trim() + "�ɹ���');</script>");
                }
                DataSet ds = GetList(" Tree_superiorNoet=" + "'" + model.Tree_superiorNoet.ToString() + "'");
                if (ds.Tables[0].Rows.Count < 1)
                {
                    return;
                }
                else
                {
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string AspxHtml = "/right.aspx?noet=" + "'" + model.Tree_num.ToString() + "'";
                        Files.Create(row["Tree_Path"].ToString(), AspxHtml);
                        CreatHtmlByChannelID(int.Parse(row["Tree_id"].ToString()), aspxHtml, true);
                    }
                }

            }
        }


        /// <summary>
        /// �������ɾ�̬ҳ��
        /// </summary>
        /// <param name="ids"></param>
        public void CreateHtmlByBatch(string ids)
        {
            string[] myIds = ids.Split(new char[] { ',' });
            foreach (string str in myIds)
            {
                DataSet ds = GetList("Tree_id=" + Convert.ToInt32(str));
                string aspxHtml = "/right.aspx?noet=" + ds.Tables[0].Rows[0]["Tree_num"].ToString();
                CreatHtmlByChannelID(int.Parse(str), aspxHtml, false);
            }
            System.Web.HttpContext.Current.Response.Write("<script>alert('�������ɾ�̬ҳ��ɹ���');</script>");
        }

        /// <summary>
        /// ȫ�����ɾ�̬ҳ��
        /// </summary>
        public void CreateHtmlByBatch()
        {
            DataTable dt = GetList("1=1").Tables[0];
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    Pbzx.Model.Help_TreeStructure model = GetModel(Convert.ToInt32(row["Tree_id"]));
                    //string AspxHtml = "/right.aspx?noet=" + "'" + model.Tree_num.ToString() + "'";
                    string AspxHtml = "/right.aspx?noet=" + model.Tree_num.ToString();

                    if (AspxHtml.IndexOf(".aspx") < 0)
                    {
                        System.Web.HttpContext.Current.Server.Execute("/" + AspxHtml + ".aspx");
                    }
                    else if (AspxHtml.IndexOf("RefurbishCpXml.aspx") > 0)
                    {
                        System.Web.HttpContext.Current.Server.Execute(AspxHtml);
                    }
                    else
                    {
                        Files.Create(model.Tree_Path, AspxHtml);
                    }
                }
                System.Web.HttpContext.Current.Response.Write("<script>alert('ȫ�����ɾ�̬ҳ��ɹ���');</script>");
            }
        }

        //���������Ϣ
        public static bool WriteMasterOperate(string action, string detail)
        {
            
            PBnet_WebLog LogBLL = new PBnet_WebLog();
            Pbzx.Model.PBnet_WebLog MyLog = new Pbzx.Model.PBnet_WebLog();

            MyLog.Operator = "�������ɰ���";
            //System.Web.HttpContext.Current.Request.Cookies["AdminManager"].Value;
            MyLog.UserIP = Pbzx.Common.Method.GetUserIP();
            MyLog.ActionType = action;
            MyLog.Detail = detail;
            return LogBLL.Add(MyLog);
        }

        #endregion  ��Ա����
    }
}
