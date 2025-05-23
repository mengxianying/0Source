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
using System.Collections.Generic;
using Maticsoft.DBUtility;

namespace Pbzx.Web.PB_Manage
{
    public partial class OrderDetails : AdminBasic
    {
        public  string strType="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                MyInit();
            }
        }

        private void MyInit()
        {
            DataSet dsPayType = DbHelperSQL.Query("select PayTypeID,PayTypeName from PBnet_PayType where FTypeID<>'0' ");
            this.ddlPayType.DataSource = dsPayType;
            this.ddlPayType.DataTextField = "PayTypeName";
            this.ddlPayType.DataValueField = "PayTypeID";
            this.ddlPayType.DataBind();
            this.ddlPayType.Items.Add(new ListItem("���֧��", "0"));
            this.ddlPayType.Items.Insert(0, new ListItem("��ѡ��",""));
            this.ddlPayType.Items[0].Selected = true;
            string orderID = Input.FilterAll(Request["ID"]);
            if (!string.IsNullOrEmpty(orderID))
            {
               
                OrderInfo1.BindOrderInfo(orderID);
                Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
                Pbzx.Model.PBnet_Orders orderModel = orderBll.GetModel(orderID);
                if (orderModel.PayTypeID != 1 && orderModel.PayTypeID != 2 && orderModel.PayTypeID != 3)
                {
                    this.ddlPayType.SelectedValue = orderModel.PayTypeID.ToString();
                }
                txtHasPayed.Text = ((decimal)(orderModel.TotalProductPrice + orderModel.PortPrice - orderModel.HasPayedPrice)).ToString("0.00");
                this.lblUserRemark.Text = orderModel.Remark;
                BindOrderStaticTip((int)orderModel.TipID);
                //this.chbIsCancel.Checked = orderModel.IsCancel ;
                //if (orderModel.IsCancel)
                //{                        
                //    this.rblOrderStaticTip.Enabled = false;
                //}
                //else
                //{
                //    this.rblOrderStaticTip.Enabled = true;
                //}                  
                if (orderModel.Type == 1)
                {
                    //  this.rblOrderStaticTip.Enabled = true;
                    this.lblState.Text = "";
                    tbOrderType.Visible = false;
                }
                else
                {
                    //  this.rblOrderStaticTip.Enabled = false;
                    this.lblState.Text = "<font color='red'>�˶��������Զ�����������������������벻���˹���Ԥ��</font>";
                    strType = "0";
                    tbOrderType.Visible = true;
                }


                if (orderModel.IsCancel == 1 || orderModel.IsCancel ==2)
                {
                    this.dvCancel.Visible = true;
                    this.dvSuccess.Visible = false;
                    this.zhifu.Visible = false;
                    btnRight.Enabled = false;
                    btnUpdate.Enabled = false;
                    btnNoPay.Enabled = false;
                }
                else
                {
                    this.dvCancel.Visible = false;
                    if (orderModel.TipName.Contains(Convert.ToString((int)Pbzx.Model.PBnet_OrderStaticTip.�����)))
                    {
                        this.lblSJHKFS.Text = orderModel.PayTypeName + " " + orderModel.Remark;
                        this.lblSJHKJE.Text = Convert.ToDecimal(orderModel.HasPayedPrice).ToString("0.00") + "Ԫ";
                        this.lblSJResult.Text = orderModel.Result;             
                        this.zhifu.Visible = false;
                        btnRight.Enabled = false;
                        btnUpdate.Enabled = false;
                        btnNoPay.Enabled = false;
                        this.dvSuccess.Visible = true;                                                
                    }
                    else
                    {
                        ////////////////�û���Ϣ//////////////////////////////////////
                        string c_memo2 = orderModel.c_memo2;
                        string[] hkInfoSZ = c_memo2.Split(new char[] { '|' });
                        if (hkInfoSZ.Length > 3)
                        {
                            this.lblHKFS.Text = hkInfoSZ[0];
                            this.lblHKJE.Text = hkInfoSZ[1] + "Ԫ";
                            this.lblHKRQ.Text = hkInfoSZ[2];
                        }
                        if (orderModel.HasPayedPrice > 0)
                        {
                            btnNoPay.Enabled = false;
                        }
                        else
                        {
                            btnNoPay.Enabled = true;
                        }
                        this.btnUpdate.Enabled = true;
                        this.zhifu.Visible = true;
                        btnRight.Enabled = true;
                        this.dvSuccess.Visible = false;
                    }
                }
                BindOrderDetail(orderID);
            }
            else
            {
                Response.Redirect("ProductOrderManager.aspx");
            }
        }
        #region ��ȡ�����嵥
        public void BindOrderDetail(string orderID)
        {
            Pbzx.BLL.PBnet_OrderDetail orderDetailBll = new Pbzx.BLL.PBnet_OrderDetail();
            GridView1.DataSource = orderDetailBll.SelectOrderDetailByOrderID(orderID);
            GridView1.DataBind();
            //lblSumQuatity.Text = SumQuatity.ToString();
            //lblSumBookPrice.Text = string.Format("{0:C2}", SumBookPrice);
        }
        #endregion

        #region ͳ�����������ܼ۸�
        decimal SumBookPrice = (decimal)0.00;
        int SumQuatity = 0;
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
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
                SumQuatity += quatity;
                e.Row.Cells[2].Text = Convert.ToString(quatity * price);

                decimal totalBookPrice = Convert.ToDecimal(e.Row.Cells[2].Text);
                SumBookPrice += totalBookPrice;
                e.Row.Cells[2].Text = string.Format("{0:f2}", totalBookPrice);
            }
        }
        #endregion

        protected string CheckRegTye(object regType, object pb_TypeName, object pb_DemoUrl, object pb_RegUrl)
        {

            if (string.IsNullOrEmpty(regType.ToString()))
            {
                return "��û��ѡ���κ�ע�᷽ʽ";
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                string[] strSZ = regType.ToString().Split(new char[] { '|' });
                if (strSZ[0] == "8")
                {

                    sb.Append("����ע�᷽ʽ��");
                    Pbzx.BLL.PBnet_ProductPrice priceBLL = new Pbzx.BLL.PBnet_ProductPrice();
                    DataSet ds = priceBLL.GetList(" VarVersionType='" + pb_TypeName.ToString() + "' ");
                    foreach (DataRow row in ds.Tables[0].Rows)
                    {
                        string useTime = row["VarUseTime"].ToString();
                        string price = row["VarPrice"].ToString();
                        string intPrice = price.Remove(price.IndexOf("Ԫ"));
                        if (strSZ.Length > 1 && !string.IsNullOrEmpty(strSZ[1]))
                        {
                            string[] priceSZ = strSZ[1].Split(new char[] { '&' });
                            if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                            {
                                price = priceSZ[0];
                                if (decimal.Parse(intPrice) == decimal.Parse(price))
                                {
                                    sb.Append(useTime + price + "Ԫ�� ������" + priceSZ[1]);
                                }
                            }
                            else
                            {
                                if (decimal.Parse(intPrice) == decimal.Parse(strSZ[1]))
                                {
                                    sb.Append(useTime + price);
                                }
                            }
                            //����� ����ע�᷽ʽ�û���
                            if (sb.Length > 7 && strSZ.Length > 2 && !string.IsNullOrEmpty(strSZ[2]))
                            {
                                sb.Append("��ע���û�����" + strSZ[2]);
                                break;
                            }
                        }
                        else
                        {
                            if (decimal.Parse(intPrice) == decimal.Parse(strSZ[1]))
                            {
                                sb.Append("��ʹ�÷�ʽ");
                                break;
                            }
                        }
                    }
                }
                else if (strSZ[0] == "1")
                {
                    sb.Append("�����󶨷�ʽ��");
                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                    if (pb_TypeName.ToString() == "רҵ��" || pb_TypeName.ToString() == "��׼��" || pb_TypeName.ToString() == "��ɱ��" || pb_TypeName.ToString() == "���ΰ�" || pb_TypeName.ToString() == "��ǰ�")
                    {
                        if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice))
                        {
                            sb.Append(intPrice + "Ԫ/��");
                        }
                        else if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice2))
                        {
                            sb.Append(intPrice2 + "Ԫ/��");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice + "Ԫ/��");
                    }
                    //����� ����ע�᷽ʽ��֤��
                    if (sb.Length > 7 && strSZ.Length > 2 && !string.IsNullOrEmpty(strSZ[2]))
                    {
                        sb.Append("����֤�룺" + strSZ[2]);
                    }
                }
                else if (strSZ[0] == "9")
                {
                    sb.Append("�������ʽ(����ǰ�����)��");
                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                    if (pb_TypeName.ToString() == "רҵ��" || pb_TypeName.ToString() == "��׼��" || pb_TypeName.ToString() == "��ɱ��" || pb_TypeName.ToString() == "���ΰ�" || pb_TypeName.ToString() == "��ǰ�")
                    {
                        if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice))
                        {
                            sb.Append(intPrice + "Ԫ/��");
                        }
                        else if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice2))
                        {
                            sb.Append(intPrice2 + "Ԫ/��");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice + "Ԫ/��");
                    }
                    //����� ����ע�᷽ʽ��֤��
                    if (sb.Length > 16 && strSZ.Length > 2 && !string.IsNullOrEmpty(strSZ[2]))
                    {
                        sb.Append("����֤�룺" + strSZ[2]);
                    }
                }
                else if (strSZ[0] == "7")
                {
                    sb.Append("�������ʽ(�����������)��");
                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    decimal p2 = 0;
                    if (decimal.TryParse(intPrice2, out p2))
                    {
                    }
                    decimal p4 = p2 + WebInit.webBaseConfig.SoftdogPrice;
                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                    decimal p1 = 0;
                    if (decimal.TryParse(intPrice, out p1))
                    {
                    }
                    else
                    {
                        intPrice = "";
                    }
                    decimal p3 = p1 + WebInit.webBaseConfig.SoftdogPrice;
                    if (pb_TypeName.ToString() == "רҵ��" || pb_TypeName.ToString() == "��׼��" || pb_TypeName.ToString() == "��ɱ��" || pb_TypeName.ToString() == "���ΰ�" || pb_TypeName.ToString() == "��ǰ�")
                    {
                        if (decimal.Parse(strSZ[1]) == p3)
                        {
                            sb.Append(intPrice + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                        else if (decimal.Parse(strSZ[1]) == p4)
                        {
                            sb.Append(intPrice2 + "Ԫ���� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                    }
                }
                else if (strSZ[0] == "6")
                {
                    sb.Append("�������ʽ(���������)��");
                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                    if (pb_TypeName.ToString() == "רҵ��" || pb_TypeName.ToString() == "��׼��" || pb_TypeName.ToString() == "��ɱ��" || pb_TypeName.ToString() == "���ΰ�" || pb_TypeName.ToString() == "��ǰ�")
                    {
                        if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice))
                        {
                            sb.Append(intPrice + "Ԫ/��");
                        }
                        else if (decimal.Parse(strSZ[1]) == decimal.Parse(intPrice2))
                        {
                            sb.Append(intPrice2 + "Ԫ/��");
                        }
                    }
                    else
                    {
                        sb.Append(intPrice + "Ԫ/��");
                    }
                }
                return sb.ToString();
            }
        }


        //�󶨶���״̬��ʾ
        private void BindOrderStaticTip(int tipID)
        {

            //DataSet ds = new Pbzx.BLL.PBnet_Orders().SelectOrderStaticTip();
            //rblOrderStaticTip.DataSource = ds;
            //rblOrderStaticTip.DataTextField = "TipName";
            //rblOrderStaticTip.DataValueField = "TipID";
      
            //rblOrderStaticTip.DataBind();
            ////rblOrderStaticTip.Items.Add(new ListItem("��ȡ��", "-1"));

            //if (ds != null && ds.Tables[0].Rows.Count > 0)
            //{
            //    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            //    {
            //        if (rblOrderStaticTip.Items[i].Value == tipID.ToString())
            //        {
            //            rblOrderStaticTip.Items[i].Selected = true;
            //            break;
            //        }
            //    }
            //}
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            string strResult = this.txtResult.Text;
            string orderID = Input.FilterAll(Request["ID"]);
            if (string.IsNullOrEmpty(orderID))
                return;                     
            int intIsCancel = 0;
            if (!string.IsNullOrEmpty(strResult))
            {
                int result = DbHelperSQL.ExecuteSql(" update  PBnet_Orders set Result='" + Input.FilterAll(strResult) + "' where OrderID='" + orderID + "'   ");
            }  
            Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
            DataSet dsOrder = orderBll.SelectOrdersByOrderID(orderID);
            DataRow row = dsOrder.Tables[0].Rows[0];
            decimal totalPrice = Convert.ToDecimal(row["TotalProductPrice"]) + Convert.ToDecimal(row["PortPrice"]) - Convert.ToDecimal(row["HasPayedPrice"]);
            decimal deHasPay = 0M;
            if(!decimal.TryParse(this.txtHasPayed.Text,out deHasPay))
            {
                Response.Write(JS.Alert("�Ѹ����ʽ����ȷ��"));
                return;
            }
            if(deHasPay < 0)
            {
                Response.Write(JS.Alert("�Ѹ����С��0��"));
                return;
            }
            if (Convert.ToInt32(Convert.ToDecimal(txtHasPayed.Text)) < Convert.ToInt32(totalPrice))
            {

                int tipID = 3;
                string tipName = WebFunc.GetTipNameByTipID(tipID);
                int result2 = 0;
                if (this.ddlPayType.SelectedValue != "")
                {
                    result2 = DbHelperSQL.ExecuteSql(" update  PBnet_Orders set PayTypeID='" + this.ddlPayType.SelectedValue + "' , PayTypeName='" + this.ddlPayType.SelectedItem.Text + "' , IsPay=0, HasPayedPrice=HasPayedPrice+" + Input.FilterAll(this.txtHasPayed.Text) + ",  TipID='" + tipID + "',TipName='" + tipName + "',IsCancel=" + intIsCancel + ",c_memo2='',UpdateStaticDate='" + DateTime.Now.ToString() + "',Remark='"+this.txtResult.Text+"' where OrderID='" + orderID + "'   ");

                }
                else
                {
                    result2 = DbHelperSQL.ExecuteSql(" update  PBnet_Orders set IsPay=0, HasPayedPrice=HasPayedPrice+" + Input.FilterAll(this.txtHasPayed.Text) + ",  TipID='" + tipID + "',TipName='" + tipName + "',IsCancel=" + intIsCancel + ",c_memo2='',UpdateStaticDate='" + DateTime.Now.ToString() + "',Remark='" + this.txtResult.Text + "' where OrderID='" + orderID + "'   ");
                }

                if (result2 > 0)
                {
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("�������ɹ���", "�������㶩����������Ϊ[" + orderID + "].");                  
                }
                else
                {
                    Response.Write("<script language='javascript'>alert('�޸�ʧ�ܣ�');</script>");
                    Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("������ʧ�ܣ�", "�������㶩��ʧ�ܣ�������Ϊ[" + orderID + "].");
                    return;
                }
            }
            else
            {
                Response.Write("<script>alert('����������㣬��ѡ�񣺿�������-��ͨ���');</script>");
                return;
            }
            btnUpdate.Enabled = true;
            MyInit();
            Response.Write("<script>alert('�����ɹ���');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
        }

        protected void chbIsCancel_CheckedChanged(object sender, EventArgs e)
        {
            //if (this.chbIsCancel.Checked)
            //{
            //    this.rblOrderStaticTip.Enabled = false;
            //}
            //else
            //{
            //    this.rblOrderStaticTip.Enabled = true;
            //}
        }

        protected void rblOrderStaticTip_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string orderID = Input.FilterAll(Request["ID"]);
            //Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
            //DataSet dsOrder = orderBll.SelectOrdersByOrderID(orderID);
            //DataRow row = dsOrder.Tables[0].Rows[0];
            //string tipName = WebFunc.GetTipNameByTipID(this.rblOrderStaticTip.SelectedValue);
            //if (tipName.Contains(",4"))
            //{
            //    this.txtHasPay.Text = Convert.ToDecimal(row["HasNotPayedPrice"]).ToString("0.00");
            //}
            //else
            //{
            //    this.txtHasPay.Text = Convert.ToDecimal(row["HasPayedPrice"]).ToString("0.00");
            //}
        }

        protected void btnRight_Click(object sender, EventArgs e)
        {
            this.btnRight.Enabled = false;
            if(this.ddlPayType.SelectedValue == "")
            {
                Response.Write(JS.Alert("��ѡ��ʵ�ʸ��ʽ��"));
                return;
            }
            string orderID = Input.FilterAll(Request["ID"]);
            Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
            DataSet dsOrder = orderBll.SelectOrdersByOrderID(orderID);
            DataRow row = dsOrder.Tables[0].Rows[0];
            decimal totalPrice = Convert.ToDecimal(row["TotalProductPrice"]) + Convert.ToDecimal(row["PortPrice"]) - Convert.ToDecimal(row["HasPayedPrice"]);
            if (!WebFunc.CheckOrderIsValidate(orderID))
            {
                Response.Write(JS.Alert("�˶����Ѿ����������Ѿ�ȡ����"));
                return;
            }
            decimal writeJE = 0;
            if (!decimal.TryParse(this.txtHasPayed.Text, out writeJE))
            {
                Response.Write(JS.Alert("ʵ�ʸ������ʽ����ȷ��"));
                return;
            }
            else
            {
                if (writeJE < 0)
                {
                    Response.Write(JS.Alert("ʵ�ʸ������С��0��"));
                    return;
                }
            }         
            decimal resultJE = writeJE;
            if(this.chbCZ.Checked)
            {
                decimal mo = Math.Round(writeJE - totalPrice,2);
                if(mo > 0)
                {                       
                    Pbzx.BLL.PBnet_Charge chargeBLL = new Pbzx.BLL.PBnet_Charge();
                    Pbzx.Model.PBnet_Charge model = new Pbzx.Model.PBnet_Charge();
                    model.Remark = "�û�[" + row["UserName"] + "]����" + mo + "Ԫ����̨����Ա������������û��˺š�";
                    model.OrderDate = DateTime.Now;
                    // model.OrderID = CreateOrderID();
                    model.OrderID = Method.CreateOrderID("CZ", "PBnet_Charge");
                    model.PayMoney = mo;
                    Pbzx.BLL.PBnet_UserTable utBLL = new Pbzx.BLL.PBnet_UserTable();
                    Pbzx.Model.PBnet_UserTable ut = utBLL.GetModelName(row["UserName"].ToString());
                    ut.CurrentMoney += mo;
                    utBLL.Update(ut);
                    Pbzx.Model.PBnet_UserTable userRealModel = Pbzx.BLL.PBnet_UserTable.GetRealInfoByUname(row["UserName"].ToString());
                    model.State = 1;
                    model.Type = 0;
                    model.PayNum = "";
                    if (userRealModel != null)
                    {
                        model.RealName = userRealModel.RealName;
                    }
                    else
                    {
                        model.RealName = "";
                    }
                    model.HasPayedPrice = mo;                    
                    model.IsPay = 1;
                    model.UserID = Convert.ToInt32(DbHelperSQLBBS.GetSingle("select top 1 UserID from Dv_User where UserName='" + row["UserName"].ToString() + "' "));
                    model.UserName = row["UserName"].ToString();
                    model.c_memo1 = this.ddlPayType.SelectedItem.Text;
                    model.PayTypeID = Convert.ToInt32(this.ddlPayType.SelectedValue);
                    model.PayTypeName = this.ddlPayType.SelectedItem.Text;
                    model.UserIP = Request.UserHostAddress;
                    int result = chargeBLL.Add(model);
                    /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
                    Pbzx.BLL.PBnet_UserTradeInfo tradeBll = new Pbzx.BLL.PBnet_UserTradeInfo();
                    Pbzx.Model.PBnet_UserTradeInfo tradeModel = new Pbzx.Model.PBnet_UserTradeInfo();
                    tradeModel.Account_UserName = "";
                    tradeModel.AccountNumber = "";
                    tradeModel.BankName = "";
                    tradeModel.CurrentMoney = 0;
                    if (userRealModel != null)
                    {
                        tradeModel.Account_UserName = userRealModel.RealName;
                        tradeModel.AccountNumber = userRealModel.AccountNumber;
                        tradeModel.BankName = userRealModel.BankName;
                        tradeModel.CurrentMoney = userRealModel.CurrentMoney;
                    }
                    tradeModel.ForeignKey_id = model.OrderID.ToString();
                    tradeModel.OperateManager = WebFunc.GetCurrentAdmin();
                    tradeModel.Remark = "�û�[" + row["UserName"] + "]����" + mo + "Ԫ����̨����Ա������������û��˺ţ���ֵ������" + model.OrderID + "��";
                    tradeModel.TradeMoney = mo;
                    tradeModel.TradeTime = DateTime.Now;
                    tradeModel.UserName = row["UserName"].ToString(); 
                    tradeModel.TradeType = 313;
                    tradeBll.Add(tradeModel);
                    /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
                    resultJE = writeJE - mo;
                }         
            }
            Pbzx.BLL.PBnet_OrderDetail orderDetailBll = new Pbzx.BLL.PBnet_OrderDetail();
            DataSet dsOrderDetail = orderDetailBll.SelectOrderDetailByOrderID(orderID);
            bool chkIsFH = false;

            foreach (DataRow rowDetail in dsOrderDetail.Tables[0].Rows)
            {
                if (rowDetail["State"].ToString() == "0")
                {
                    string typeLX = rowDetail["RegType"].ToString().Split(new char[] { '|' })[0];
                    if (typeLX == "7")
                    {
                        chkIsFH = true;
                        break;
                    }
                }
            }
            if (chkIsFH)
            {
                Response.Write(JS.Alert("���������δ�����������ڹ�������嵥�е��������"));
                return;
            }

            WebFunc.UpdateOrder(orderID, true, Convert.ToString(resultJE + Convert.ToDecimal(row["HasPayedPrice"])), "order@pinble.com", "", int.Parse(this.ddlPayType.SelectedValue), this.ddlPayType.SelectedItem.Text);      
            string strResult = Input.FilterAll(this.txtResult.Text);
            if (!string.IsNullOrEmpty(strResult))
            {
                int result = DbHelperSQL.ExecuteSql(" update  PBnet_Orders set Result='" + Input.FilterAll(strResult) + "'  where OrderID='" + orderID + "'   ");
            }

            string[] c_memo2SZ = row["c_memo2"].ToString().Split(new char[] { '|' });
            if (c_memo2SZ.Length > 2)
            {
                c_memo2SZ[0] = this.ddlPayType.SelectedItem.Text;
                c_memo2SZ[1] = Convert.ToString(Convert.ToDecimal(this.txtHasPayed.Text) + Convert.ToDecimal(row["HasPayedPrice"]));
                c_memo2SZ[3] = this.ddlPayType.SelectedValue;
                int result6 = DbHelperSQL.ExecuteSql(" update  PBnet_Orders  set IsPay='3',c_memo2='" + c_memo2SZ[0] + "|" + c_memo2SZ[1] + "|" + c_memo2SZ[2] + "|" + c_memo2SZ[3] + "',UpdateStaticDate='" + DateTime.Now.ToString() + "'  where OrderID='" + orderID + "'   ");
            }
            else
            {
                int result6 = DbHelperSQL.ExecuteSql(" update  PBnet_Orders  set IsPay='3',c_memo2='" + this.ddlPayType.SelectedItem.Text + "|" + Convert.ToString(Convert.ToDecimal(this.txtHasPayed.Text) + Convert.ToDecimal(row["HasPayedPrice"])) + "|" + DateTime.Now.ToShortDateString() + "|" + this.ddlPayType.SelectedValue + "',UpdateStaticDate='" + DateTime.Now.ToString() + "'  where OrderID='" + orderID + "'   ");
            }
            MyInit();
            //if (row["OrderClass"].ToString() == "0")
            //{
            //    Response.Write("<script>alert('�����ɹ���');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
            //}
            //else
            //{
            //    Response.Write(JS.Alert("�����ɹ���", "DelegateOrders.aspx"));//, "DelegateOrders.aspx"
            //}
            Response.Write("<script>alert('�����ɹ���');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
       
        }

        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {               
                string OrderDetailID = GridView1.DataKeys[e.Row.RowIndex].Values["OrderDetailID"].ToString();
                string orderID = GridView1.DataKeys[e.Row.RowIndex].Values["OrderID"].ToString();
                string RegType = GridView1.DataKeys[e.Row.RowIndex].Values["RegType"].ToString();
                string State = GridView1.DataKeys[e.Row.RowIndex].Values["State"].ToString();
                string Serial = GridView1.DataKeys[e.Row.RowIndex].Values["Serial"].ToString();

                Pbzx.BLL.PBnet_Orders orderBll1 = new Pbzx.BLL.PBnet_Orders();
                Pbzx.Model.PBnet_Orders orderModel1 = orderBll1.GetModel(orderID);

                Pbzx.BLL.PBnet_OrderDetail ordersBll = new Pbzx.BLL.PBnet_OrderDetail();
                Pbzx.Model.PBnet_OrderDetail orderModel = ordersBll.GetModel(long.Parse(OrderDetailID));
                if (orderModel.State == 0)
                {
                    string typeLX = orderModel.RegType.Split(new char[] {'|'})[0];
                    if (typeLX == "7")
                    {
                        e.Row.Cells[5].Text = "<a onclick=\"OpenEdite('" + orderID + "');\"'  href=\"#\">����</a>";
                        this.btnRight.Enabled = false;
                    }
                    else
                    {
                        e.Row.Cells[5].Text = " --- "; 
                    }
                }
                else if (orderModel.State == 2)
                {
                    e.Row.Cells[5].Text = "<a onclick=\"OpenEdite1('" + OrderDetailID + "');\"'  href=\"#\">�˹�����</a>";
                    this.btnRight.Enabled = false;
                }
                else
                {
                    e.Row.Cells[5].Text = " --- ";
                }
                e.Row.Cells[3].Text = WebFunc.GetProductResultByType((int)orderModel1.TipID, (int)orderModel1.IsPay, RegType, Serial,int.Parse(State));
            }

        }

        

        protected void lbtnCancel_Command(object sender, CommandEventArgs e)
        {
            LinkButton lbtnCancel = (LinkButton)sender;
            if (lbtnCancel.Text == "����")
            {
                DbHelperSQL.ExecuteSql(" update  PBnet_OrderDetail set State=1 where OrderDetailID='" + e.CommandArgument.ToString() + "'   ");
            }
            string orderID = Input.FilterAll(Request["ID"]);
            BindOrderDetail(orderID);
        }

        /// <summary>
        /// δ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnNoPay_Click(object sender, EventArgs e)
        {
            btnNoPay.Enabled = false;
            string orderID = Input.FilterAll(Request["ID"]);
            int  result2 = DbHelperSQL.ExecuteSql(" update  PBnet_Orders set IsPay=0, TipID='2',TipName='2',c_memo2='',UpdateStaticDate='" + DateTime.Now.ToString() + "',Remark='" + this.txtResult.Text + "' where OrderID='" + orderID + "'   ");
            if (result2 > 0)
            {
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("��������", "����δ�����������ɹ���������Ϊ[" + orderID + "].");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('�޸�ʧ�ܣ�');</script>");
                Pbzx.BLL.PBnet_WebLog.WriteMasterOperate("��������", "����δ�����������ʧ�ܣ�������Ϊ[" + orderID + "].");
                return;
            }
            
            Pbzx.BLL.PBnet_Orders orderBll = new Pbzx.BLL.PBnet_Orders();
            DataSet dsOrder = orderBll.SelectOrdersByOrderID(orderID);
            DataRow row = dsOrder.Tables[0].Rows[0];
            //if (row["OrderClass"].ToString() == "0")
            //{
            //    Response.Write(JS.Alert("�����ɹ���", "ProductOrderManager.aspx"));
            //}
            //else
            //{
            //    Response.Write(JS.Alert("�����ɹ���", "DelegateOrders.aspx"));
            //}
            MyInit();
            Response.Write("<script>alert('�����ɹ���');window.opener.location.reload();window.opener.focus();window.opener=null;window.open('','_self');window.close();</script>");
        }


    }
}

                   

//OnClientClick="window.open('','_parent',''); window.close();  "