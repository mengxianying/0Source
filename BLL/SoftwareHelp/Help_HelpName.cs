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
    /// 业务逻辑类Help_HelpName 的摘要说明。
    /// </summary>
    public class Help_HelpName
    {
        private static readonly IHelp_HelpName dal = DataAccess.CreateHelp_HelpName();
        public Help_HelpName()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
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
        /// 增加一条数据
        /// </summary>
        public int Add(Pbzx.Model.Help_HelpName model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Pbzx.Model.Help_HelpName model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public int Delete(int Hn_ID)
        {
            return dal.Delete(Hn_ID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Pbzx.Model.Help_HelpName GetModel(int Hn_ID)
        {
            return dal.GetModel(Hn_ID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 生成树形结构静态页面
        /// </summary>
        /// <param name="ID">数据库的ID</param>
        /// <param name="aspxHtml">aspx的动态的地址</param>
        /// <param name="isAllCreate"></param>
        public void CreatTree(int ID, string aspxHtml, bool isAllCreate)
        {

            if (!isAllCreate)
            {
                Pbzx.Model.Help_HelpName model = GetModel(ID);
                if (aspxHtml.IndexOf(".aspx") < 0)
                {
                    System.Web.HttpContext.Current.Server.Execute("/" + aspxHtml + ".aspx");
                    System.Web.HttpContext.Current.Response.Write("<script>alert('生成" + model.Hn_name.Trim() + "成功！');</script>");
                }
                else if (aspxHtml.IndexOf("RefurbishCpXml.aspx") > 0)
                {
                    System.Web.HttpContext.Current.Server.Execute(aspxHtml);
                }
                else
                {
                    if (Files.Create(model.Hn_path, aspxHtml))
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>alert('生成" + model.Hn_name.Trim() + "成功！');</script>");
                    }
                    else
                    {
                        System.Web.HttpContext.Current.Response.Write("<script>alert('生成" + model.Hn_name.Trim() + "失败！');</script>");
                    }
                }
            }
        }

        #endregion  成员方法
    }
}

