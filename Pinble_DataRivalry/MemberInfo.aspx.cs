using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using Pbzx.Common;

namespace Pinble_DataRivalry
{
    public partial class MemberInfo : System.Web.UI.Page
    {
        Pbzx.BLL.DataRivalry_UpLoadFile get_uplod = new Pbzx.BLL.DataRivalry_UpLoadFile();
        DataTable IsResult = new DataTable();
        private int rowCount = 0;
        Pbzx.BLL.publicMethod get_p = new Pbzx.BLL.publicMethod();
        public static string n_uName = "";
        Pbzx.BLL.DataRivalry_Rt get_rt = new Pbzx.BLL.DataRivalry_Rt();
        Pbzx.BLL.DataRivalry_Contrast get_ct = new Pbzx.BLL.DataRivalry_Contrast();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
           
            if (Pbzx.Common.Input.URLDecode(Input.FilterAll(Request["name"].ToString())) != null)
            {
                n_uName = Pbzx.Common.Input.URLDecode(Input.FilterAll(Request["name"].ToString()));
                //用户名不为空
                lab_userName.Text = n_uName;
                //查询用户发布个数
                DataSet ds = get_p.Chipped_Table("DataRivalry_UpLoadFile", "count(*)", "F_username=" + "'" + n_uName + "'");
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    lab_releaseNum.Text = ds.Tables[0].Rows[0][0].ToString();
                }
                //查询被下载次数
                DataSet ds_dl = get_p.Chipped_Table("DataRivalry_downLoad", "sum(Dl_dl)", "Dl_dlName=" + "'" + n_uName + "'");
                if (ds_dl != null && ds_dl.Tables[0].Rows.Count > 0)
                {
                    lab_download.Text = ds_dl.Tables[0].Rows[0][0].ToString();
                }

                //查询中奖次数
                DataSet ds_Awaed = get_p.Chipped_Table("DataRivalry_UpLoadFile", "count(*)", "F_username=" + "'" + n_uName + "'" + " and F_state=1");
                if (ds_Awaed != null && ds_Awaed.Tables[0].Rows.Count > 0)
                {
                    lab_winning.Text = ds_Awaed.Tables[0].Rows[0][0].ToString();
                }

                //查询个人积分
                DataSet ds_n = get_p.Chipped_Table("PlatformPublic_integralPrize", "*", "Pip_belongs='DataRivalry'" + " and Pip_user=" + "'" + n_uName + "'");
                if (ds_n != null && ds_n.Tables[0].Rows.Count > 0)
                {
                    lab_integral.Text = ds_n.Tables[0].Rows[0]["Pip_Interal"].ToString();

                    lab_level.Text = ds_n.Tables[0].Rows[0]["Pip_Prize"].ToString();
                }
                else
                {
                    lab_integral.Text = "0";
                    lab_level.Text = "0";
                }

            }
            if (Request["lottName"] != null)
            {
                string lotteryName = Input.FilterAll(Request["lottName"].ToString());
                rep_dataBind(lotteryName);
                Page.ClientScript.RegisterStartupScript(ClientScript.GetType(), "gg", "<script>tran('" + lotteryName + "'); </script>");
            }
            else
            {
                rep_dataBind("zx");
            }
            rep_payattBind(Pbzx.Common.Input.URLDecode(Input.FilterAll(Request["name"].ToString())));
        }

        public void rep_dataBind(string lotteryName)
        {

            StringBuilder strSql = new StringBuilder();
            
            if (lotteryName == "zx")
            {
                strSql.Append("F_SingleGroup=1");
                strSql.Append(" and F_lottery=1");
            }
            if (lotteryName == "zux")
            {

                strSql.Append("F_SingleGroup=2");
                strSql.Append(" and F_lottery=1");
            }
            if (lotteryName == "pzx")
            {
                strSql.Append("F_SingleGroup=1");
                strSql.Append(" and F_lottery=2");
            }
            if (lotteryName == "pzux")
            {
                strSql.Append("F_SingleGroup=2");
                strSql.Append(" and F_lottery=2");
            }
            strSql.Append(" and F_username=" + "'" + n_uName + "'");
            string Searchstr = strSql.ToString();
            string order = "F_addTime desc";
            int mycount = 0;
            IsResult = get_uplod.GuestGetBySearchUp(Searchstr, "*", order, 40, 3, AspNetPager1.CurrentPageIndex, out mycount);
            rep_data.DataSource = IsResult;
            rep_data.DataBind();
            rowCount = IsResult.Rows.Count;
            AspNetPagerConfig(mycount);
        }

        //自定义序号
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex > -1)
            {
                e.Row.Cells[0].Text = Convert.ToString(e.Row.RowIndex + 1 + (AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize);
            }
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = 40;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }
        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "总计<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>条&nbsp;";
            AspNetPager1.CustomInfoHTML += "<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "页</font>";
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            if (Request["lottName"] != null)
            {
                string lotteryName = Input.FilterAll(Request["lottName"].ToString());
                rep_dataBind(lotteryName);
                
            }
            else
            {
                rep_dataBind("zx");
            }
        }

        protected void rep_data_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            foreach (RepeaterItem RI in this.rep_data.Items)
            {
                //全中
                Label lab_group = RI.FindControl("lab_group") as Label;
                //2D
                Label lab_2D = RI.FindControl("lab_2D") as Label;
                //1D
                Label lab_1D = RI.FindControl("lab_1D") as Label;
                //0D
                Label lab_0D = RI.FindControl("lab_0D") as Label;

                DataSet ds = get_rt.GetList("Rt_AwardNum=" + Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["F_drID"]) + " and Rt_UserName=" + "'" + IsResult.Rows[RI.ItemIndex]["F_username"].ToString() + "'");

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["F_SingleGroup"]) == 1)
                    {
                        lab_group.Text = ds.Tables[0].Rows[0]["Rt_Single"].ToString();
                    }
                    if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["F_SingleGroup"]) == 2)
                    {
                        lab_group.Text = ds.Tables[0].Rows[0]["Rt_Group"].ToString();
                    }
                    lab_2D.Text = ds.Tables[0].Rows[0]["Rt_two"].ToString();
                    lab_1D.Text = ds.Tables[0].Rows[0]["Rt_one"].ToString();
                    lab_0D.Text = ds.Tables[0].Rows[0]["Rt_zero"].ToString();
                }
                else
                {
                    lab_group.Text = "未开奖";
                    lab_2D.Text = "未开奖";
                    lab_1D.Text = "未开奖";
                    lab_0D.Text = "未开奖";
                }
                //开奖号码

                Label lab_awer = RI.FindControl("lab_awer") as Label;
                DataSet ds_awer = new DataSet();
                if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["F_lottery"]) == 1)
                {
                    //3D 开奖号码
                    ds_awer = Maticsoft.DBUtility.DbHelperSQL1.Query("select code from FC3DData where issue=" + "'" + IsResult.Rows[RI.ItemIndex]["F_Period"].ToString() + "'");
                }
                if (Convert.ToInt32(IsResult.Rows[RI.ItemIndex]["F_lottery"]) == 2)
                {
                    //3D 开奖号码
                    ds_awer = Maticsoft.DBUtility.DbHelperSQL1.Query("select code3 from TCPL35Data where issue=" + "'" + IsResult.Rows[RI.ItemIndex]["F_Period"].ToString() + "'");
                }

                if (ds_awer != null && ds_awer.Tables[0].Rows.Count > 0)
                {
                    lab_awer.Text = ds_awer.Tables[0].Rows[0][0].ToString();
                }
                if (IsResult.Rows[RI.ItemIndex]["F_username"].ToString() == Method.Get_UserName.ToString())
                {
                    RI.FindControl("delete").Visible = true;
                }
            }
        }

        protected void rep_data_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "del")
            {
                //上传成功后 半个小时内允许删除
                DataSet ds = get_uplod.GetList("F_drID=" + Convert.ToInt32(e.CommandArgument));
                string strTime1 = ds.Tables[0].Rows[0]["F_addTime"].ToString();
                DateTime DateTime1,
                DateTime2 = DateTime.Now;//现在时间  
                DateTime1 = Convert.ToDateTime(strTime1); //设置要求的减的时间  
                //string dateDiff = null;
                TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                TimeSpan ts = ts1.Subtract(ts2).Duration();
                //显示时间  
                //dateDiff = ts.Days.ToString() + "天"
                //        + ts.Hours.ToString() + "小时"
                //        + ts.Minutes.ToString() + "分钟"
                //        + ts.Seconds.ToString() + "秒";

                if (Convert.ToInt32(ts.Hours.ToString()) > 0 || Convert.ToInt32(ts.Minutes.ToString())>=30)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('发布时间超过30分钟,不能删除数据')</script>");
                }
                else
                {
                    //判断是否  删除的是自己的数据
                    if (ds.Tables[0].Rows[0]["F_username"].ToString() == Method.Get_UserName.ToString())
                    {
                        if (get_ct.DeleteJoint(Convert.ToInt32(e.CommandArgument)) > 0)
                        {
                            if (get_uplod.Delete(Convert.ToInt32(e.CommandArgument)) > 0)
                            {
                                
                                ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('删除成功');</script>");

                                rep_dataBind("zx");
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alt", "<script>alert('您不能删除他人信息,')</script>", false);
                        //ClientScript.RegisterStartupScript(this.GetType(), "up", "<script>alert('您不能删除此信息')</script>");
                    }
                }
            }
        }

        /// <summary>
        /// 绑定关注 (我关注的人 默认值)
        /// </summary>
        /// <param name="name">会员名</param>
        public void rep_payattBind(string name)
        {
            Pbzx.BLL.PBnet_PayAtt get_pt = new Pbzx.BLL.PBnet_PayAtt();
            DataSet ds = get_pt.GetList("Pa_fans=" + "'" + name + "'" + " and Pa_PSign='ddbp'");
            rep_payatt.DataSource = ds;
            rep_payatt.DataBind();

            DataSet ds_Idol = get_pt.GetList("Pa_Idol=" + "'" + name + "'" + " and Pa_PSign='ddbp'");
            lab_payAtt.Text = ds_Idol.Tables[0].Rows.Count.ToString();

            
        }

       
    }
}