using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Pbzx.Common;
using System.Text;
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class UserDraw_Manage : AdminBasic
    {
        //lblTotal
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MyGridView.PageSize = WebInit.webBaseConfig.WebPageNum;
                if (ViewState["order"] == null)
                {
                    ViewState["order"] = "OrderDate";
                }
                if (ViewState["isDesc"] == null)
                {
                    ViewState["isDesc"] = true;
                }
                BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            }
        }
        protected void AspNetPagerConfig(int tempCount)
        {
            AspNetPager1.PageSize = WebInit.webBaseConfig.WebPageNum;
            AspNetPager1.RecordCount = tempCount;
            AddCustomText();
        }

        protected void AddCustomText()
        {
            AspNetPager1.CustomInfoHTML = "��<font color=\"blue\"><b>" + AspNetPager1.RecordCount.ToString() + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ<font color=\"red\"><b>" + MyGridView.Rows.Count + "</b></font>��&nbsp;";
            AspNetPager1.CustomInfoHTML += "��ҳ:<font color=\"blue\"><b>" + AspNetPager1.CurrentPageIndex.ToString() + "</b>/" + AspNetPager1.PageCount.ToString() + "ҳ</font>";
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        /// <summary>
        /// ����url��ֵ��ѯ
        /// </summary>
        /// <returns></returns>
        private string AddParameter()
        {
            StringBuilder bu = new StringBuilder();

            //�û���
            if (!string.IsNullOrEmpty(Request["strUsername"]))
            {
                bu.Append(" and UserName like '%" + Input.Filter(Request["strUsername"].Trim()) + "%' ");
            }

            //��ʵ����
            if (!string.IsNullOrEmpty(Request["strRealName"]))
            {
                bu.Append(" and RealName like '%" + Input.Filter(Request["strRealName"].Trim()) + "%' ");
            }


            //������
            if (!string.IsNullOrEmpty(Request["strBankName"]))
            {
                bu.Append(" and UserName in (select UserName from PBnet_UserTable where BankName ='" + Input.Filter(Request["strBankName"]) + "') ");
            }

            //��������
            if (!string.IsNullOrEmpty(Request["strBankInfo"]))
            {
                bu.Append(" and UserName in (select UserName from PBnet_UserTable where BankInfo like'%" + Input.Filter(Request["strBankInfo"].Trim()) + "%') ");
            }



            //���
            if (!string.IsNullOrEmpty(Request["strOrderID"]))
            {
                bu.Append(" and OrderID ='" + Input.Filter(Request["strOrderID"].Trim()) + "' ");
            }

            //״̬
            if (!string.IsNullOrEmpty(Request["state"]))
            {
                if (Request["state"] != "-1")
                {
                    bu.Append(" and state ='" + Input.Filter(Request["state"].Trim()) + "' and iscancel=0 ");
                }
            }
            else if (string.IsNullOrEmpty(Request["state"]))
            {
                bu.Append(" and state='0' and iscancel=0 ");
            }

            if (!string.IsNullOrEmpty(Request["strdate"]))
            {
                bu.Append(" and OrderDate between '" + Request["strCreateTime1"].Trim() + "' and '" + DateTime.Parse(Request["strCreateTime2"]).AddDays(1).ToShortDateString() + "'  ");
            }
            return bu.ToString();

        }


        private void BindData(string column, bool isDesc)
        {
            Pbzx.BLL.PBnet_Charge mBLL = new Pbzx.BLL.PBnet_Charge();

            StringBuilder bu = new StringBuilder();
            bu.Append(" 1=1 and type='1' ");
            bu.Append(this.AddParameter());
            string Searchstr = bu.ToString();    
            string order = column;
            int myCount = 0;

            if (isDesc)
            {
                order += " desc ";
            }
            else
            {
                order += " asc ";
            }

            DataTable lsResult = mBLL.GuestGetBySearch(Searchstr, "*", order, WebInit.webBaseConfig.WebPageNum, 3, AspNetPager1.CurrentPageIndex, out myCount);

            this.MyGridView.DataSource = lsResult;
            this.MyGridView.DataBind();
            AspNetPagerConfig(myCount);
            if (lsResult == null)
            {
                this.litContent.Text = "<b>��Ǹ��<p/><br/>Ӧ��û���ҵ������������ݼ�¼</b>";
            }
            else
            {
                string strTotalTemp = mBLL.GetTotalMoney(bu.ToString());

                string totalPrice = strTotalTemp.Split(new char[] { '&' })[1];
                if (!string.IsNullOrEmpty(totalPrice))
                {
                    totalPrice = Convert.ToString(Math.Round(Convert.ToDecimal(totalPrice), 2));
                }
                else
                {
                    totalPrice = "0";
                }
                this.lblTotal.Text = "����" + totalPrice + "Ԫ������" + strTotalTemp.Split(new char[] { '&' })[0] + "��";

                this.litContent.Text = "";
            }

        }

        protected void MyGridView_Sorting(object sender, GridViewSortEventArgs e)
        {
            ViewState["order"] = e.SortExpression.ToString();
            if ((bool)ViewState["isDesc"])
            {
                ViewState["isDesc"] = false;
            }
            else
            {
                ViewState["isDesc"] = true;
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
        }

        protected void MyGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                //  string href = "<a href='/SoftRegisterLog_Editor.aspx?ID=" + e.Row.Cells[0].Text + "'>";
                e.Row.Cells[1].Text = "("+ (((AspNetPager1.CurrentPageIndex - 1) * AspNetPager1.PageSize) + id).ToString()+")";//+ "</a>";

                LinkButton lbtnEdite = (LinkButton)e.Row.Cells[8].FindControl("lbtnEdite");
                LinkButton lbtnCancel = (LinkButton)e.Row.Cells[8].FindControl("lbtnCancel");

                Literal lblState = (Literal)e.Row.Cells[8].FindControl("lblState");
                string strState = MyGridView.DataKeys[e.Row.RowIndex].Values["State"].ToString();

                string result = "";
                switch (strState)
                {
                    case "0":
                        result = "<span style='color:blue;' style='cursor:pointer'  ><a href='https://ibsbjstar.ccb.com.cn/V5/index.html' target='_blank'  >�ȴ�����</a></span>";
                        lbtnEdite.Visible = true;
                        lbtnCancel.Visible = true;
                        break;
                    case "1":
                        result = "<span style='color:green;' >��ͨ��</span>";
                        lbtnEdite.Visible = false;
                        lbtnCancel.Visible = false;
                        break;
                    case "2":
                        result = "<span  style='color:red;' >δͨ��</span>";
                        lbtnEdite.Visible = false;
                        lbtnCancel.Visible = false;
                        break;
                }
                lblState.Text = result;
                decimal payMoney = Convert.ToDecimal(MyGridView.DataKeys[e.Row.RowIndex].Values["PayMoney"]);
                int  IsCancel = Convert.ToInt32(MyGridView.DataKeys[e.Row.RowIndex].Values["IsCancel"]);
                string userName = MyGridView.DataKeys[e.Row.RowIndex].Values["UserName"].ToString();
                if(IsCancel == 1)
                {
                    lbtnEdite.Visible = false;
                    lbtnCancel.Visible = false;
                    lblState.Text = "<span  style='color:red;'>�û�ȡ��</span>";
                }
                else if (IsCancel == 2)
                {
                    lbtnEdite.Visible = false;
                    lbtnCancel.Visible = false;
                    lblState.Text = "<span  style='color:red;'>ϵͳȡ��</span>";
                }
                if(strState == "0")
                {
                    string strResult = GetUserState(userName, payMoney);
                    if (!string.IsNullOrEmpty(strResult)){}                    
                }

            }
        }

        public string GetUserState(string userName,decimal payMoney)
        {
            Pbzx.BLL.PBnet_UserTable realUserBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable realUserModel =  realUserBll.GetModelName(userName);
            if(realUserModel.State != 2)
            {
                return Method.GetRealUserSateByState(realUserModel.State);
            }
            if (realUserModel.CurrentMoney - realUserModel.FrozenMoney < payMoney)
            {
                return "���Ŀ������㣡";
            }
            return "";
        }


        protected string GetZY(object type, object state, object PayTypeName, object PayMoney)
        {
            string result = "";
            //result += PayTypeName;

            if (type.ToString() == "0")
            {
                result += "��ֵ";
            }
            else
            {
                if (state.ToString() == "2")
                {
                    result += "<span color='red'>ȡ��" + PayMoney + "Ԫ<span>";
                }
                else
                {
                    result += "ȡ��" + PayMoney + "Ԫ";
                }
            }
            return result;
        }

        protected string GetState(object state)
        {
            string strSta = state.ToString();
            string result = "";
            switch (strSta)
            {
                case "0":
                    result = "<span style='color:blue;' ><a href='https://ibsbjstar.ccb.com.cn/V5/index.html'  target='_blank' style='cursor:pointer'  >�ȴ�����</a></span>";
                    break;
                case "1":
                    result = "<span style='color:green;' >��ͨ��</span>";
                    break;
                case "2":
                    result = "<span  style='color:red;' >δͨ��</span>";
                    break;
            }
            return result;
        }
     

        /// <summary>
        /// ȡ��ɹ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnEdite_Command(object sender, CommandEventArgs e)
        {
            ((LinkButton)sender).Enabled = false;
            MyGridView.Columns[8].Visible = false;
            Pbzx.BLL.PBnet_Charge chargeBLL = new Pbzx.BLL.PBnet_Charge();
            Pbzx.Model.PBnet_Charge model = chargeBLL.GetModel(Convert.ToInt32(e.CommandArgument));           
            model.State = 1;
            model.IsPay = 1;
            model.Result = "ȡ��ɹ�";
            chargeBLL.Update(model);
            if (ViewState["order"] == null)
            {
                ViewState["order"] = "OrderDate";
            }
            if (ViewState["isDesc"] == null)
            {
                ViewState["isDesc"] = true;
            }
            Pbzx.BLL.PBnet_UserTable userBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable userModel = userBll.GetModelName(model.UserName);
            userModel.LastTrade_time = DateTime.Now;            
            userModel.CurrentMoney -= model.PayMoney;
            if (userModel.FrozenMoney >= model.PayMoney)
            {
                userModel.FrozenMoney -= model.PayMoney;
            }
            else
            {
                throw new Exception("�û����������쳣��");
            }
            userBll.Update(userModel);

            /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
            Pbzx.BLL.PBnet_UserTradeInfo tradeBll = new Pbzx.BLL.PBnet_UserTradeInfo();
            Pbzx.Model.PBnet_UserTradeInfo tradeModel = new Pbzx.Model.PBnet_UserTradeInfo();
            tradeModel.Account_UserName = "";
            tradeModel.AccountNumber = "";
            tradeModel.BankName = "";
            tradeModel.CurrentMoney = 0;
            Pbzx.Model.PBnet_UserTable userRealModel = Pbzx.BLL.PBnet_UserTable.GetRealInfoByUname(model.UserName);
            if (userRealModel != null)
            {
                tradeModel.Account_UserName = userRealModel.RealName;
                tradeModel.AccountNumber = userRealModel.AccountNumber;
                tradeModel.BankName = userRealModel.BankName;
                tradeModel.CurrentMoney = userRealModel.CurrentMoney;
            }
            tradeModel.ForeignKey_id = model.OrderID.ToString();
            tradeModel.OperateManager = WebFunc.GetCurrentAdmin();
            tradeModel.Remark = DateTime.Now + "��̨����Ա���û�[" + model.UserName + "]����" + Math.Round((decimal)model.PayMoney, 2) + "Ԫ�����ֵ���" + model.OrderID;
            tradeModel.TradeMoney = Math.Round((decimal)model.PayMoney, 2);
            tradeModel.TradeTime = DateTime.Now;
            tradeModel.UserName = model.UserName;
            tradeModel.TradeType = 771;
            tradeBll.Add(tradeModel);
            /////////////////д�뽻����Ϣ��//////////////////////////////////////////////

            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            MyGridView.Columns[8].Visible = true; ;
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("���", "���û�[" + model.UserName + "]����" + Math.Round((decimal)model.PayMoney, 2) + "Ԫ�����ֵ���" + model.OrderID);
            ((LinkButton)sender).Enabled = true;
        }

        /// <summary>
        /// ���δͨ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void lbtnCancel_Command(object sender, CommandEventArgs e)
        {
            ((LinkButton)sender).Enabled = false;
            Pbzx.BLL.PBnet_Charge chargeBLL = new Pbzx.BLL.PBnet_Charge();
            Pbzx.Model.PBnet_Charge model = chargeBLL.GetModel(Convert.ToInt32(e.CommandArgument));
            model.State = 2;
            model.Result = "ȡ�����δͨ��";
            chargeBLL.Update(model);
            if (model.Type == 1)
            {
                Pbzx.BLL.PBnet_UserTable UsBll = new Pbzx.BLL.PBnet_UserTable();
                Pbzx.Model.PBnet_UserTable UsModel = UsBll.GetModelName(model.UserName);
                if (UsModel != null)
                {
                    if (UsModel.FrozenMoney >= model.PayMoney)
                    {
                        UsModel.FrozenMoney -= model.PayMoney;
                    }
                    else
                    {
                        throw new Exception("�û����������쳣��");
                    }
                    UsBll.Update(UsModel);
                }
            }


            if (ViewState["order"] == null)
            {
                ViewState["order"] = "OrderDate";
            }
            if (ViewState["isDesc"] == null)
            {
                ViewState["isDesc"] = true;
            }
            BindData(ViewState["order"].ToString(), (bool)ViewState["isDesc"]);
            Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�޸�", "���û�[" + model.UserName + "]���δͨ��������������" + model.OrderID);
            ((LinkButton)sender).Enabled = true;
        }

        protected void btn_add_Click(object sender, EventArgs e)
        {

        }

        protected string[] GetBankInfo(object uName)
        {
            Pbzx.BLL.PBnet_UserTable utBll = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable userModel = utBll.GetModelName(uName.ToString());
            string[] result = new string[3];
            result[0] = userModel.BankName;
            result[1] = userModel.BankInfo;
            result[2] = userModel.AccountNumber;
            return result;
        }


        protected string GetUserIDByUserName(object uName)
        {
            object uid = DbHelperSQLBBS.GetSingle("select top 1 UserID from Dv_User where UserName='" + uName.ToString() + "'  ");
            if(uid != null)
            {
                return uid.ToString();
            }
            else{
                return "";
            }
        }

    }
}
