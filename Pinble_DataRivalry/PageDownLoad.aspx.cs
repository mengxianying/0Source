using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pbzx.Common;
using System.Data;
using System.IO;
using System.Text;
using Pinble_DataRivalry.AppCod;

namespace Pinble_DataRivalry
{
    public partial class PageDownLoad : System.Web.UI.Page
    {
        Pbzx.BLL.DataRivalry_Level get_l = new Pbzx.BLL.DataRivalry_Level();
        Pbzx.BLL.DataRivalry_downLoad get_down = new Pbzx.BLL.DataRivalry_downLoad();
        Pbzx.BLL.PlatformPublic_integralPrize get_ilp = new Pbzx.BLL.PlatformPublic_integralPrize();
        Pbzx.Model.DataRivalry_downLoad mod_dd = new Pbzx.Model.DataRivalry_downLoad();
        Pbzx.BLL.publicMethod get_pubmd = new Pbzx.BLL.publicMethod();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request["id"]))
                {
                    int ID = Convert.ToInt32(Request["id"]);
                    //判断用户是否登录
                    if (Method.Get_UserName.ToString() != "0")
                    {

                        DataSet ds_pubmd = get_pubmd.Chipped_Table("v_DataRivalry_download", "F_drID,F_username,F_FileName,F_CreateName,F_SingleGroup,F_FileNum,F_Period", "F_drID=" + ID);
                        //检查用户是否第一次下载
                        string down = downloadYN(ds_pubmd.Tables[0].Rows[0]["F_username"].ToString());
                        if (down == "1")
                        {
                            //不是第一次下载 （直接下载）
                            FileDownload(ds_pubmd.Tables[0].Rows[0]["F_FileName"].ToString(), ds_pubmd.Tables[0].Rows[0]["F_CreateName"].ToString(), Convert.ToInt32(ds_pubmd.Tables[0].Rows[0]["F_drID"]), ds_pubmd.Tables[0].Rows[0]["F_username"].ToString());

                        }
                        if (down == "2")
                        {
                            //是第一次下载

                            //下载所需的金币
                            int money = levelMoney(Convert.ToInt32(ds_pubmd.Tables[0].Rows[0]["F_FileNum"].ToString()), Convert.ToInt32(ds_pubmd.Tables[0].Rows[0]["F_SingleGroup"]));
                            //读取配置数据。是否需要验证金币下载
                            string n_Switch = Input.SetConfigValue("Switch", "Switchxml.xml");
                            if (Convert.ToInt32(n_Switch) == 1)
                            {
                                //查看用户的金币是否够支付本次操作
                                int moneyType = selectbalance(ds_pubmd.Tables[0].Rows[0]["F_username"].ToString(), money.ToString());
                                if (moneyType == 1)
                                {

                                    //可以支付
                                    int success = get_ilp.deductMoney(ds_pubmd.Tables[0].Rows[0]["F_username"].ToString(), "DataRivalry", money);
                                    if (success == 1)
                                    {
                                        Pbzx.BLL.PlatformPublic_payments get_pmt = new Pbzx.BLL.PlatformPublic_payments();
                                        //记录收支
                                        //get_pmt.payments(ds_pubmd.Tables[0].Rows[0]["F_username"].ToString(), 1, ds_pubmd.Tables[0].Rows[0]["F_Period"].ToString(), "下载大底", "DataRivalry");
                                        FileDownload(ds_pubmd.Tables[0].Rows[0]["F_FileName"].ToString(), ds_pubmd.Tables[0].Rows[0]["F_CreateName"].ToString(), Convert.ToInt32(ds_pubmd.Tables[0].Rows[0]["F_drID"]), ds_pubmd.Tables[0].Rows[0]["F_username"].ToString());

                                    }
                                    else
                                    {

                                        ClientScript.RegisterStartupScript(this.GetType(), "tip", "<script>alert('下载失败')</script>");
                                    }
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "tip", "<script>alert('您的金币不足，请先兑换。')</script>");

                                }
                            }
                            else
                            {
                                FileDownload(ds_pubmd.Tables[0].Rows[0]["F_FileName"].ToString(), ds_pubmd.Tables[0].Rows[0]["F_CreateName"].ToString(), Convert.ToInt32(ds_pubmd.Tables[0].Rows[0]["F_drID"]), ds_pubmd.Tables[0].Rows[0]["F_username"].ToString());

                            }

                        }
                    }
                    else
                    {
                        //ScriptManager.RegisterStartupScript(Page, this.GetType(), "alert", "<script>alert('您还没有登录，请先登录');window.location.href = 'download.aspx';</script>", false);
                        //Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("提示！", "您还没有登录，请先登录", 350, "1", "history.go(-1);", "", false, false));
                        //Page.ClientScript.RegisterStartupScript(GetType(), "alert", "alert('您还没有登录，请先登录');history.go(-1);");
                        //return;
                        Response.Redirect("download.aspx?err=0");
                        Response.End();
                    }
                }
                else
                {
                    Response.Redirect("error.htm");
                    return;
                }
            }
        }


        private string downloadYN(string UserName)
        {
            Pbzx.BLL.DataRivalry_downLoad get_dl = new Pbzx.BLL.DataRivalry_downLoad();
            DataSet ds = get_dl.GetList("Dl_name=" + "'" + UserName + "'");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {

                //不是第一次添加
                return "1";
            }
            else
            {
                return "2";
            }
        }

        /// <summary>
        /// 文件下载
        /// </summary>
        /// <param name="FullFileName">文件名</param>
        /// <param name="path">文件路径</param>
        /// <param name="Id">发布信息表ID</param>
        /// <param name="Fname">发布信息表会员名</param>
        private void FileDownload(string FullFileName, string path, int Id, string Fname)
        {
            string fileName = FullFileName + ".txt"; //"asd.txt";//客户端保存的文件名 
            string filePath = Server.MapPath("UpLoads/" + path);//路径

            FileInfo fileInfo = new FileInfo(filePath);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "attachment;filename=" + toUtf8String(fileName));

            //Response.AddHeader("Content-Disposition", "attachment;FileName=" + HttpUtility.UrlEncode(toUtf8String(fileName), System.Text.Encoding.UTF8));
            Response.AddHeader("Content-Length", fileInfo.Length.ToString());
            Response.AddHeader("Content-Transfer-Encoding", "binary");
            Response.ContentType = "application/octet-stream";

            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.WriteFile(fileInfo.FullName);

            //下载数据添加到
            donwPrese(Id, Fname);

            Response.Flush();
            Response.End();

        }

        /// <summary> 
        /// 解决下载名称中文乱码 
        /// </summary> 
        /// <param name="s"></param> 
        /// <returns></returns> 
        private String toUtf8String(String s)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (c >= 0 && c <= 255)
                {
                    sb.Append(c);
                }
                else
                {
                    byte[] b;
                    try
                    {
                        b = Encoding.UTF8.GetBytes(c.ToString());
                    }
                    catch (Exception ex)
                    {
                        b = new byte[0];
                    }
                    for (int j = 0; j < b.Length; j++)
                    {
                        int k = b[j];
                        if (k < 0) k += 256;

                        sb.Append("%" + Convert.ToString(k, 16).ToUpper());
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 添加下载信息
        /// </summary>
        /// <param name="drID"></param>
        /// <param name="name"></param>
        private void donwPrese(int drID, string name)
        {

            //修改用户的下载次数
            DataSet ds_dd = get_pubmd.Chipped_Table("DataRivalry_downLoad", "Dl_id", "Dl_ufID=" + drID);
            if (ds_dd != null & ds_dd.Tables[0].Rows.Count > 0)
            {
                mod_dd = get_down.GetModel(Convert.ToInt32(ds_dd.Tables[0].Rows[0]["Dl_id"]));
                mod_dd.Dl_dl = Convert.ToInt32(mod_dd.Dl_dl) + 1;
                if (get_down.Update(mod_dd) > 0)
                {

                }
            }
            else
            {
                //修改用户的下载次数
                mod_dd.Dl_name = Method.Get_UserName.ToString();
                mod_dd.Dl_Time = DateTime.Now;
                mod_dd.Dl_ufID = drID;

                mod_dd.Dl_dl = 1;
                mod_dd.Dl_dlName = name;
                if (get_down.Add(mod_dd) > 0)
                {

                }
            }
        }

        /// <summary>
        /// 查询用户金币余额是否充足
        /// </summary>
        ///<param name="UserName">用户名</param>
        ///<param name="money">下载大底所要花费的金币</param>
        private int selectbalance(string UserName, string money)
        {
            DataSet ds_ilp = get_ilp.GetList("Pip_belongs='DataRivalry' and Pip_user=" + "'" + UserName + "'");
            if (Convert.ToDecimal(ds_ilp.Tables[0].Rows[0]["Pip_money"]) >= Convert.ToDecimal(money))
            {
                //可以支付
                return 1;
            }
            else
            {
                return 2;
            }
        }

        /// <summary>
        /// 查询大底在那一个级别 和下载所需的金币
        /// </summary>
        /// <param name="num">大底注数</param>
        /// <param name="type">大底类型</param>
        /// <returns></returns>
        private int levelMoney(int num, int type)
        {
            DataSet ds_l = get_l.GetList("Le_type=" + type);
            if (ds_l != null && ds_l.Tables[0].Rows.Count > 0)
            {
                if (num >= Convert.ToInt32(ds_l.Tables[0].Rows[0]["Le_BRange"]) && num <= Convert.ToInt32(ds_l.Tables[0].Rows[0]["Le_ERange"]))
                {
                    return Convert.ToInt32(ds_l.Tables[0].Rows[0]["Le_rewards"]);
                }
            }
            return 0;
        }
    }
}