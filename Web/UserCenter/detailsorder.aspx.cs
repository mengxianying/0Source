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
using Maticsoft.DBUtility;
using System.Text;

namespace Pbzx.Web.UserCenter
{
    public partial class detailsorder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string orderID = Input.FilterAll(Request["OrderID"]);

                if (!string.IsNullOrEmpty(orderID))
                {
                    ///����������
                    DataSet dsBank = DbHelperSQL.Query("select PayTypeName,PayTypeID from PBnet_PayType where PayValue='1' and FTypeID<>'0'  ");
                    ddlBankName.DataSource = dsBank;
                    ddlBankName.DataTextField = "PayTypeName";
                    ddlBankName.DataValueField = "PayTypeID";
                    ddlBankName.DataBind();
                    ddlBankName.Items.Insert(0, new ListItem("��ѡ��", ""));
                    ddlBankName.Items[0].Selected = true;
                    txtHKRQ.Text = DateTime.Now.ToShortDateString();

                    Pbzx.BLL.PBnet_Orders MyBll = new Pbzx.BLL.PBnet_Orders();
                    Pbzx.Model.PBnet_Orders MyModel = MyBll.GetModel(orderID);
                    if (MyModel == null)
                    {
                        Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("", "��û��Ȩ�޲鿴���������Ķ�������", 500, "1", "window.returnValue ='yes';window.close();", "", false, false));
                        return;
                    }
                    if (MyModel.UserName != Method.Get_UserName)
                    {
                        Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("", "��û��Ȩ�޲鿴�ö�������", 500, "1", "window.returnValue ='yes';window.close();", "", false, false));
                        return;
                    }
                    if (MyModel.IsCancel == 1 || MyModel.IsCancel == 2)
                    {
                        this.tbRemark.Visible = false;
                        this.tbCancel.Visible = true;
                    }
                    else
                    {
                        if (MyModel.PayTypeID == 1 || MyModel.PayTypeID == 20 || MyModel.TipName.Contains(Convert.ToString((int)Pbzx.Model.PBnet_OrderStaticTip.�Ѹ���)) || MyModel.TipName.Contains(Convert.ToString((int)Pbzx.Model.PBnet_OrderStaticTip.�ѿ�ͨ)) || MyModel.TipName.Contains(Convert.ToString((int)Pbzx.Model.PBnet_OrderStaticTip.�����)))
                        {
                            this.tbRemark.Visible = false;
                        }
                        else
                        {
                            this.tbRemark.Visible = true;
                        }
                        this.tbCancel.Visible = false;
                    }
                    this.lblUserName.Text = MyModel.ReceiverName;
                    this.lblReceiverPhone.Text = MyModel.ReceiverPhone;
                    this.lblPostalCode.Text = MyModel.ReceiverPostalCode;
                    this.lblReceiverEmail.Text = MyModel.ReceiverEmail;
                    this.lblReceiverAddress.Text = MyModel.ReceiverAddress;

                    this.lblOrderID.Text = MyModel.OrderID;

                    if (MyModel.IsCancel == 1 || MyModel.IsCancel == 2)
                    {
                        this.lblTipName.Text = "�Ѿ�ȡ��";
                    }
                    else
                    {
                        this.lblTipName.Text = WebFunc.FormartTipName(MyModel.TipID, MyModel.IsPay);
                    }

                    this.lblPayTypeName.Text = MyModel.PayTypeName;
                    this.lblOrderDate.Text = MyModel.OrderDate.ToString();
                    this.txtRemark.Text = MyModel.Remark;

                    step1.Attributes["class"] = "mshu_menushang";
                    step2.Attributes["class"] = "mshu_menushangGo";
                    string tipName = MyModel.TipName;
                    if (tipName.Contains(Convert.ToString((int)Pbzx.Model.PBnet_OrderStaticTip.�Ѹ���)))
                    {
                        step2.Attributes["class"] = "mshu_menushang";
                        step3.Attributes["class"] = "mshu_menushangGo";
                    }

                    if (tipName.Contains(Convert.ToString((int)Pbzx.Model.PBnet_OrderStaticTip.�ѿ�ͨ)))
                    {
                        step3.Attributes["class"] = "mshu_menushang";
                        step4.Attributes["class"] = "mshu_menushangGo";
                    }
                    if (tipName.Contains(Convert.ToString((int)Pbzx.Model.PBnet_OrderStaticTip.�����)))
                    {
                        step4.Attributes["class"] = "mshu_menushang";
                        step5.Attributes["class"] = "mshu_menushangGo";
                    }
                    BindOrderDetail(orderID);
                    lblOrderResult.Text = MyModel.Result;
                    if (lblOrderResult.Text == "")
                    {
                        lblOrderResult.Text = lblTipName.Text;
                    }
                    string[] pars = MyModel.c_memo2.Split(new char[] { '|' });
                    if (pars.Length > 3)
                    {
                        this.ddlBankName.SelectedValue = pars[3];
                        this.txtHKJE.Text = pars[1];
                        this.txtHKRQ.Text = pars[2];
                    }
                    txtRemark.Text = MyModel.Remark;
                    if (string.IsNullOrEmpty(MyModel.Result))
                    {
                        if (MyModel.IsPay == 1)
                        {
                            this.lblOrderResult.Text = "�ȴ����";
                        }
                        else
                        {
                            this.lblOrderResult.Text = "�ȴ�����";
                        }
                    }

                }

            }
        }

        #region ��ȡ�����嵥
        public void BindOrderDetail(string orderID)
        {
            Pbzx.BLL.PBnet_OrderDetail orderDetailBll = new Pbzx.BLL.PBnet_OrderDetail();
            DataSet dsOrderDetail = orderDetailBll.SelectOrderDetailByOrderID(orderID);
            GridView1.DataSource = dsOrderDetail;
            GridView1.DataBind();

            bool hasRJG = false;
            decimal SumBookPrice = 0.0M;
            decimal SumPrice = 0.0M;
            foreach (DataRow row in dsOrderDetail.Tables[0].Rows)
            {
                string regType = row["RegType"].ToString();
                string[] strRegType = regType.Split(new char[] { '|' });
                decimal price = 0;
                if (strRegType.Length > 1 && !string.IsNullOrEmpty(strRegType[1]))
                {
                    string[] priceSZ = strRegType[1].Split(new char[] { '&' });
                    if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                    {
                        price = decimal.Parse(priceSZ[0]) * decimal.Parse(priceSZ[1]);
                    }
                    else
                    {
                        price = decimal.Parse(strRegType[1]);
                    }
                    if (strRegType[0] == "7")
                    {
                        hasRJG = true;
                    }
                }
                SumBookPrice += price;
            }
            decimal dcJianRJG = SumBookPrice;
            if (hasRJG)
            {
                dcJianRJG = SumBookPrice - WebInit.webBaseConfig.SoftdogPrice;
            }
            StringBuilder sb = new StringBuilder();
            LoginSort login = new LoginSort();
            if (login[ELoginSort.delegate_User.ToString()])
            {
                decimal jjrZK = WebFunc.GetCurrentPricePercent();
                sb.Append("<div style='font-size:14px;'>�����ۿۣ�" + Convert.ToInt32(jjrZK * 100) + "%<br/>��Ʒ��");
                sb.Append(dcJianRJG.ToString("0.00") + "Ԫ*" + Convert.ToInt32(jjrZK * 100) + "%&nbsp;");
                SumPrice += dcJianRJG * jjrZK;
            }
            else
            {
                sb.Append("<font style='font-size:14px;'>��Ʒ��");
                sb.Append(dcJianRJG.ToString("0.00") + "Ԫ");
                sb.Append("&nbsp;-&nbsp;�ۿۣ�0.00Ԫ&nbsp;");
                SumPrice += dcJianRJG;
            }
            if (hasRJG)
            {
                sb.Append("+&nbsp;������۸�" + WebInit.webBaseConfig.SoftdogPrice.ToString("0.00") + "Ԫ&nbsp;");
                SumPrice += WebInit.webBaseConfig.SoftdogPrice;
                sb.Append("+&nbsp;��ݷѣ�20Ԫ&nbsp;");
                SumPrice += 20;
            }
            else
            {
                sb.Append("+&nbsp;��ݷѣ�0.00Ԫ&nbsp;");
            }

            sb.Append("=&nbsp;<font style='font-size:14px; font-weight:bold;'>" + SumPrice.ToString("0.00") + "</font> Ԫ ");
            sb.Append("</div>");

            this.lblJSXX.Text = sb.ToString();
            Pbzx.BLL.PBnet_Orders MyBll = new Pbzx.BLL.PBnet_Orders();
            Pbzx.Model.PBnet_Orders MyModel = MyBll.GetModel(orderID);//
            decimal hasNotPay = Convert.ToDecimal(MyModel.TotalProductPrice + MyModel.PortPrice - MyModel.HasPayedPrice);
            this.lblYFJE.Text = " <font style='font-size:14px; font-weight:bold;'>�Ѹ���<font style='font-size:14px; font-weight:bold; color:Red;'>" + ((Decimal)MyModel.HasPayedPrice).ToString("0.00") + "Ԫ</font>  &nbsp;&nbsp;δ����<font style='font-size:14px; font-weight:bold; color:Red;'>" + hasNotPay.ToString("0.00") + "Ԫ</font></font>";


        }
        #endregion

        #region ͳ�����������ܼ۸�
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtUserName = (TextBox)e.Row.Cells[3].FindControl("txtUserName");
                Button btnTempOpen = (Button)e.Row.Cells[3].FindControl("btnTempOpen");
                btnTempOpen.Attributes.Add("onclick", "return CheckIsValidateUser($('#" + txtUserName.ClientID + "').val())");
                txtUserName.Attributes.Add("rowIndex", e.Row.RowIndex.ToString());
                btnTempOpen.Attributes.Add("rowIndex", e.Row.RowIndex.ToString());
                string regType = GridView1.DataKeys[e.Row.RowIndex].Values["RegType"].ToString();
                string[] strRegType = regType.Split(new char[] { '|' });
                decimal price = 0;
                if (strRegType.Length > 1 && !string.IsNullOrEmpty(strRegType[1]))
                {
                    string[] priceSZ = strRegType[1].Split(new char[] { '&' });
                    if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                    {
                        price = decimal.Parse(priceSZ[0]) * decimal.Parse(priceSZ[1]);
                    }
                    else
                    {
                        price = decimal.Parse(strRegType[1]);
                    }
                }
                int quatity = 1;
                e.Row.Cells[2].Text = Convert.ToString(quatity * price);
                decimal totalBookPrice = Convert.ToDecimal(e.Row.Cells[2].Text);
                e.Row.Cells[2].Text = string.Format("{0:C2}", totalBookPrice);
            }
        }
        #endregion


        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string orderID = GridView1.DataKeys[e.Row.RowIndex].Values["OrderID"].ToString();
                string regType = GridView1.DataKeys[e.Row.RowIndex].Values["RegType"].ToString();
                string serial = GridView1.DataKeys[e.Row.RowIndex].Values["Serial"].ToString();
                string TempOpen = GridView1.DataKeys[e.Row.RowIndex].Values["TempOpen"].ToString();
                int state = Convert.ToInt32(GridView1.DataKeys[e.Row.RowIndex].Values["State"]);
                Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
                Pbzx.Model.PBnet_Orders orderModel = orderBll.GetModel(orderID);
                Label lblResult = ((Label)e.Row.Cells[3].FindControl("lblResult"));
                if (orderModel.IsCancel == 1)
                {
                    lblResult.Text = "�û�ȡ��";
                }
                else if (orderModel.IsCancel == 2)
                {
                    lblResult.Text = "ϵͳȡ��";
                }
                else
                {
                    Panel pnlTempOpen = ((Panel)e.Row.Cells[3].FindControl("pnlTempOpen"));
                    string strText = "";
                    if (orderModel.TipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�ȴ����� && orderModel.IsPay == 0 && orderModel.Type == 0)
                    {
//                        strText = "�ȴ�����";
                        strText = strText = "<a href='OnlinePay.aspx?OrderID=" + orderID + "' target='_blank'> ����֧��</a>";
                    }
                    else if (orderModel.TipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�ȴ����� && orderModel.IsPay == 0)
                    {
                        strText = "�ȴ�����";
                    }
                    else if (orderModel.TipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�ȴ����� && orderModel.IsPay == 1)
                    {
                        strText = "�Ѹ���ȴ����";
                    }
                    else if (orderModel.TipID == (int)Pbzx.Model.PBnet_OrderStaticTip.����)
                    {
                        strText = "�Ѹ��������";
                    }
                    else if (orderModel.TipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�Ѹ���)
                    {
                        strText = "�Ѹ���ȴ���ͨ";
                    }
                    else if (orderModel.TipID == (int)Pbzx.Model.PBnet_OrderStaticTip.�����)
                    {
                        string[] regTypeSZ = regType.Split(new char[] { '|' });
                        if (regTypeSZ[0] == "8")
                        {
                            if (state == 2)
                            {
                                strText = "����" + serial;
                            }
                            else
                            {
                                strText = serial;
                            }
                        }
                        else if (regTypeSZ[0] == "1" || regTypeSZ[0] == "9")
                        {
                            if (state == 2)
                            {
                                strText = "����" + serial;
                            }
                            else
                            {
                                strText = serial;
                            }
                        }
                        else if (regTypeSZ[0] == "7" || regTypeSZ[0] == "6")
                        {
                            string[] tempSerial = serial.Split(new char[] { '|' });
                            if (tempSerial[0] == "")
                            {
                                tempSerial[0] = "�����";
                            }
                            if (orderModel.IsPay == 3)
                            {
                                strText = tempSerial[0];
                                if (tempSerial.Length > 1)
                                {
                                    strText += "<br/>" + tempSerial[1];
                                }
                            }
                            else
                            {
                                if (state == 0)
                                {
                                    strText = "�Ѹ���ȴ��ʼ������";
                                }
                                else
                                {
                                    strText = "�����";
                                }
                            }
                            ///��ͨ��ʱ
                            if (regTypeSZ[0] == "7")
                            {
                                if (TempOpen == "0")
                                {
                                    pnlTempOpen.Visible = true;
                                }
                                else
                                {
                                    pnlTempOpen.Visible = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        strText = serial;
                    }
                    lblResult.Text = strText;
                }
            }
        }

        protected void ibtnHasPay_Click(object sender, ImageClickEventArgs e)
        {

            string orderID = Input.FilterAll(Request["OrderID"]);
            string strErr = "";
            decimal dePayType = 0.00M;
            if (this.ddlBankName.SelectedValue == "")
            {
                strErr += "��δѡ�񸶿ʽ��<br/>";
            }
            if (!decimal.TryParse(this.txtHKJE.Text, out dePayType))
            {
                strErr += "������ĸ������ʽ����ȷ��<br/>";
            }
            DateTime dtHKRQ = DateTime.Now;
            if (!DateTime.TryParse(this.txtHKRQ.Text, out dtHKRQ))
            {
                strErr += "������Ļ�����ڸ�ʽ����ȷ��<br/>";
            }
            else
            {
                if (DateTime.Parse(this.txtHKRQ.Text) > DateTime.Now)
                {
                    strErr += "������׼ȷ�Ļ�����ڣ�<br/>";
                }
            }

            if (!string.IsNullOrEmpty(strErr))
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("", strErr, 500, "1", "", "", false, false));
                return;
            }
            Pbzx.BLL.PBnet_Orders MyBll = new Pbzx.BLL.PBnet_Orders();
            Pbzx.Model.PBnet_Orders MyModel = MyBll.GetModel(orderID);
            if (MyModel == null)
            {
                return;
            }
            if (MyModel.UserName != Method.Get_UserName)
            {
                return;
            }
            if (MyModel.IsPay == 1)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("��ʾ��", "���Ļ��ȷ�����ύ���������ظ��ύ��<br/>�����ĵȴ��ͷ���ˣ�", 500, "1", "window.returnValue ='yes';window.close();", "", false, false));
                return;
            }
            MyModel.c_memo2 = this.ddlBankName.SelectedItem.Text + "|" + this.txtHKJE.Text + "|" + this.txtHKRQ.Text + "|" + this.ddlBankName.SelectedValue;
            MyModel.Remark = Input.FilterHTML(this.txtRemark.Text.Trim());
            MyModel.IsPay = 1;
            MyModel.UpdateStaticDate = DateTime.Now;

            if (MyBll.Update(MyModel))
            {
                //Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("��ʾ��", "���Ļ��ȷ�����ύ����ȴ��ͷ���˺�ͨ��", 500, "1", "window.returnValue ='yes';window.close();", "", false, false));
                Response.Write("<script>alert('�ύ�ɹ���');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");

            }
            else
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), JS.myAlert1("", "�ύʧ�ܣ�����ƴ�����߲���ͨ����ͷ���ϵ��", 500, "1", "", "", false, false));
            }
        }

        //protected void ibtnSave_Click(object sender, ImageClickEventArgs e)
        //{
        //    string orderID = Input.FilterAll(Request["OrderID"]);
        //    Pbzx.BLL.PBnet_Orders MyBll = new Pbzx.BLL.PBnet_Orders();
        //    Pbzx.Model.PBnet_Orders MyModel = MyBll.GetModel(orderID);

        //    MyModel.Remark = Input.FilterAll(this.txtRemark.Text.Trim());
        //    //MyModel.IsPay = 1;
        //    if (MyBll.Update(MyModel))
        //    {
        //        Response.Write("<script language='javascript'>alert('�ύ�ɹ���');window.returnValue ='yes';</script>");
        //        return;
        //    }
        //    else
        //    {
        //        ClientScript.RegisterStartupScript(this.GetType(), "err", JS.Alert("�ύʧ��."));
        //    }
        //}


        /// <summary>
        /// ��֤���緽ʽע���û����Ƿ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            //TextBox txtUserName = (TextBox)sender;
            //int count = Convert.ToInt32(DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + Input.FilterAll(txtUserName.Text) + "' and  " + Method.DV_User));
            //int rowIndex = Convert.ToInt32(txtUserName.Attributes["rowIndex"]);
            //string pb_SoftName = GridView1.DataKeys[rowIndex].Values["pb_SoftName"].ToString();
            //if (count < 1)
            //{
            //    ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("����", "���û���δע�ᣬ���߱����������ʵ����д��", 500, "1", "", "", false, false) + "", false);
            //    return;
            //}
            //LoginSort myLogin = new LoginSort();
            //if (!myLogin["manager_user"])
            //{
            //    ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("��ʾ", "��ȷ��Ϊ " + txtUserName.Text + " ����" + pb_SoftName + "�����", 500, "1", "", "", false, false) + "", false);//document.getElementById('" + txtUserName.ClientID + "').value=''
            //}
            //else if (txtUserName.Text != Method.Get_UserName)
            //{
            //    ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("��ʾ", "���ĵ�¼�û����빺��������û�����һ�£���ȷ��Ϊ���� " + txtUserName.Text + " ����" + pb_SoftName + "�����", 500, "1", "", "", false, false) + "", false);//document.getElementById('" + txtUserName.ClientID + "').value=''                
            //}
            //else if (txtUserName.Text == Method.Get_UserName)
            //{
            //    ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("��ʾ", "��ȷ��Ϊ�Լ� " + txtUserName.Text + " ����" + pb_SoftName + "�����", 500, "1", "", "", false, false) + "", false);//document.getElementById('" + txtUserName.ClientID + "').value=''
            //}
        }

        protected void btnTempOpen_Click(object sender, EventArgs e)
        {
            Button btnTempOpen = (Button)sender;
            int rowIndex = Convert.ToInt32(btnTempOpen.Attributes["rowIndex"]);
            TextBox txtUserName = (TextBox)GridView1.Rows[rowIndex].Cells[3].FindControl("txtUserName");
            Label lblResult = (Label)GridView1.Rows[rowIndex].Cells[3].FindControl("lblResult");
            int count = Convert.ToInt32(DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + Input.FilterAll(txtUserName.Text) + "' and  " + Method.DV_User));
            string pb_SoftName = GridView1.DataKeys[rowIndex].Values["pb_SoftName"].ToString();
            string OrderID = GridView1.DataKeys[rowIndex].Values["OrderID"].ToString();
            string CstID = GridView1.DataKeys[rowIndex].Values["CstID"].ToString();
            string OrderDetailID = GridView1.DataKeys[rowIndex].Values["OrderDetailID"].ToString();
            DataRow row = DbHelperSQL.Query(" select * from PBnet_Orders where OrderID='" + OrderID + "' ").Tables[0].Rows[0];
            if (count < 1)
            {
                ScriptManager.RegisterStartupScript(this.UpShoppingCart, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("����", "���û���δע�ᣬ���߱����������ʵ����д��", 500, "1", "", "", false, false) + "", false);
                return;
            }
            StringBuilder sbZCM = new StringBuilder(1024);
            Pbzx.Common.ErrorLog.WriteLogMeng("��س���", "��������ע���붯̬�⿪ʼ������", true, true);
            int result = CM.DllSoftRegister_Net(WebFunc.GetCharSz(OrderID), WebFunc.GetInt(CstID), 10, 10, WebFunc.GetCharSz(row["PayTypeName"]), WebFunc.GetFloat("0"), WebFunc.GetCharSz(row["ReceiverName"]), WebFunc.GetCharSz(row["ReceiverPhone"]), WebFunc.GetCharSz(row["ReceiverEmail"]), WebFunc.GetCharSz(row["ReceiverAddress"]), WebFunc.GetCharSz(txtUserName.Text.Trim()), 0, WebFunc.GetCharSz("��˾ע��"), 10, sbZCM);
            Pbzx.Common.ErrorLog.WriteLogMeng("��ͨ��ʱʹ��", "��ͨ��ʱʹ�õ���Dll�����" + result + "��������" + sbZCM.ToString(), true, true);
            if (result == 0)
            {
                lblResult.Text = sbZCM.ToString();
                DbHelperSQL.ExecuteSql("update PBnet_OrderDetail set TempOpen=1,Serial=Serial+'|" + sbZCM.ToString() + "'  where  OrderDetailID='" + OrderDetailID + "' ");
            }
            else
            {
                lblResult.Text = sbZCM.ToString();
            }
            BindOrderDetail(OrderID);
        }
    }
}
