using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pbzx.Common;

namespace Pbzx.Web.PB_Manage.CST
{
    public partial class pageCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ReqId = Request["id"].ToString();   // Msg ID
                string mbNo = Request["mbNo"].ToString();  // 模板号
                pageCreateMain(ReqId, mbNo);
            }
        }

        private void pageCreateMain(string id, string mbno)
        {
            //生成HTML静态页面
            //先判断是否选择HTML
            //模版路径
            if (mbno == null || !OperateText.IsNumber(mbno))
            {
                mbno = "1";
            }
            string MB = "";
            MB = "~/Template/CM_mainTemplate/CM_mainTemplate2011_" + mbno + ".aspx?id=" + id;

            //必须不为空时，进行静态化
            if (id != null && OperateText.IsNumber(id))
            {
                try
                {
                    //找年份文件夹
                    if (!DirectoryFile.IsCreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + 3)))
                    {
                        //不存在创建文件夹
                        DirectoryFile.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + 3));
                    }
                    //找类型文件夹！(不同类型的消息放到不同的文件夹下！)
                    if (!DirectoryFile.IsCreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + 3 + "/" + DateTime.Now.Year.ToString())))
                    {
                        //不存在创建文件夹
                        DirectoryFile.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + 3 + "/" + DateTime.Now.Year.ToString()));
                    }

                    //静态化
                    //新建文件
                    DirectoryFile.CreateFile(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + 3 + "/" + DateTime.Now.Year.ToString() + "/Msg_" + id + ".html"));

                    using (System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Web.HttpContext.Current.Server.MapPath("~/html/CM_Main/" + 3 + "/" + DateTime.Now.Year.ToString() + "/Msg_" + id + ".html"), false, System.Text.Encoding.GetEncoding("gb2312")))
                    {
                        //将aspx文件静态化到 html
                        System.Web.HttpContext.Current.Server.Execute(MB, sw, true);
                        sw.Close();
                    }

                }
                catch
                {
                    Response.Write("<script>alert('数据静态化错误！');</script>");
                }
            }


        }
    }
}