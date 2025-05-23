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
    /// ҵ���߼���Help_HelpName ��ժҪ˵����
    /// </summary>
    public class Help_HelpName
    {
        private static readonly IHelp_HelpName dal = DataAccess.CreateHelp_HelpName();
        public Help_HelpName()
        { }
        #region  ��Ա����
        /// <summary>
        /// �Ƿ���ڸü�¼
        /// </summary>
        public bool Exists(int Hn_ID)
        {
            return dal.Exists(Hn_ID);
        }
        public bool Exists(string name)
        {
            return dal.Exists(name);
        }
        /// <summary>
        /// ����һ������
        /// </summary>
        public int Add(Pbzx.Model.Help_HelpName model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// ����һ������
        /// </summary>
        public int Update(Pbzx.Model.Help_HelpName model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// ɾ��һ������
        /// </summary>
        public int Delete(int Hn_ID)
        {
            return dal.Delete(Hn_ID);
        }

        /// <summary>
        /// �õ�һ������ʵ��
        /// </summary>
        public Pbzx.Model.Help_HelpName GetModel(int Hn_ID)
        {
            return dal.GetModel(Hn_ID);
        }

        /// <summary>
        /// ��������б�
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// �������νṹ��̬ҳ��
        /// </summary>
        /// <param name="ID">���ݿ��ID</param>
        /// <param name="aspxHtml">aspx�Ķ�̬�ĵ�ַ</param>
        /// <param name="isAllCreate"></param>
        public void CreatTree(int ID, string aspxHtml, bool isAllCreate)
        {

            if (!isAllCreate)
            {
                Pbzx.Model.Help_HelpName model = GetModel(ID);
                if (aspxHtml.IndexOf(".aspx") < 0)
                {
                    System.Web.HttpContext.Current.Server.Execute("/" + aspxHtml + ".aspx");
                    System.Web.HttpContext.Current.Response.Write("<script>alert('����" + model.Hn_name.Trim() + "�ɹ���');</script>");
                }
                else if (aspxHtml.IndexOf("RefurbishCpXml.aspx") > 0)
                {
                    System.Web.HttpContext.Current.Server.Execute(aspxHtml);
                }
                else
                {
                    if (Files.Create(model.Hn_path, aspxHtml))
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>alert('����" + model.Hn_name.Trim() + "�ɹ���');</script>");
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>alert('����" + model.Hn_name.Trim() + "ʧ�ܣ�');</script>");
                    }
                }
            }
        }

        #endregion  ��Ա����
    }
}

