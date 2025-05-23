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
using Maticsoft.DBUtility;
using Pbzx.Common;
using System.Text;

namespace Pbzx.Web.UserCenter
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoginSort login = new LoginSort();
            if(!login[ELoginSort.delegate_User.ToString()])
            {
                Response.Write("<script>top.location='User_Center.aspx';</script>");
                Response.End();
            }
            if(!Page.IsPostBack)
            {            
                Pbzx.BLL.PBnet_Product productBll = new Pbzx.BLL.PBnet_Product();
                DataSet dsSoft = productBll.GetList(" (pb_SoftID NOT IN (SELECT pb_SoftID FROM PBnet_Product WHERE CHARINDEX('���', pb_DemoUrl) > 0))");
                this.ddlSoftList.DataTextField = "pb_SoftName";
                this.ddlSoftList.DataValueField = "pb_SoftID";
                this.ddlSoftList.DataSource = dsSoft;
                this.ddlSoftList.DataBind();
                this.ddlSoftList.Items.Insert(0, new ListItem("��ѡ��", "-1"));  
                DisItemValues();
                BindShoppingCart();
                if (hdfID.Value == "0")
                {
                    this.ibnAdd.ImageUrl = "~/Images/Web/order_save.gif";
                }
                else
                {
                    this.ibnAdd.ImageUrl = "~/Images/Web/order_make.gif";
                }

            }
        }

        private void DisItemValues()
        {
            if (Request["CartID"] != null)
            {
                string cartID = Input.Decrypt(Input.FilterAll(Request["CartID"]));
                long longCartID = 0;
                if (long.TryParse(cartID, out longCartID))
                {
                    Pbzx.BLL.PBnet_ShoppingCart cartBll = new Pbzx.BLL.PBnet_ShoppingCart();
                    Pbzx.Model.PBnet_ShoppingCart cartModel = cartBll.GetModel(longCartID);
                    hdfID.Value =  Input.Encrypt(longCartID.ToString());
                    this.ddlSoftList.SelectedValue = cartModel.ProductID.ToString();
                    string regType = cartModel.RegType;
                    this.ddlRegType.SelectedValue = regType.Split(new char[] { '|' })[0];
                    CreateRadioList(ddlRegType.SelectedValue, regType);
                    DisplayUnameRZM(regType);
                    //�ж��Ƿ������緽ʽ�еİ��칺��Ȼ������м۸���ܼ۸�
                    if (ddlRegType.SelectedValue == "8")
                    {
                        ListItem li = radio_8.SelectedItem;
                        if (li != null)
                        {
                            if (li.Text.Contains("/��"))
                            {
                                pnlDays.Visible = true;
                                this.txtDays.Text = regType.Split(new char[] { '|' })[1].Split(new char[] { '&' })[1];
                            }
                            else
                            {
                                pnlDays.Visible = false;
                            }
                        }
                        else
                        {
                            pnlDays.Visible = false;
                        }
                    }
                    this.lblPrice.Text = GetOneProductPrice();
                }
            }
            else
            {
            }
        }
        /// <summary>
        /// ���ע�᷽ʽ�ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlRegType_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if(this.ddlSoftList.SelectedValue == "-1")
            {
                ScriptManager.RegisterStartupScript(this.UpAddProduct, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("", "����ѡ��������ƣ�", 400, "2", "", "", false, false) + "", false);
                return;
            }
            CreateRadioCalPrice();
        }

        /// <summary>
        /// ���´���radiobutton,����۸�
        /// </summary>
        private void CreateRadioCalPrice()
        {
            if (this.ddlSoftList.SelectedValue == "-1")
            {
                ScriptManager.RegisterStartupScript(this.UpAddProduct, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("", "��û��ѡ��������ƣ�", 400, "2", "", "", false, false) + "", false);
                return;
            }

            if(this.ddlRegType.SelectedValue =="-1")
            {
                ScriptManager.RegisterStartupScript(this.UpAddProduct, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("", "��û��ѡ�����ע�᷽ʽ��", 400, "2", "", "", false, false) + "", false);
                return;
            }
            if (this.ddlRegType.SelectedValue == "8")
            {
                this.pnlUserName.Visible = true;
            }
            else if (this.ddlRegType.SelectedValue == "1" || this.ddlRegType.SelectedValue == "9")
            {
                this.pnlRZM.Visible = true;
            }
            CreateRadioList(ddlRegType.SelectedValue,this.ddlRegType.SelectedValue);
            DisplayUnameRZM(this.ddlRegType.SelectedValue);
            //�ж��Ƿ������緽ʽ�еİ��칺��Ȼ������м۸���ܼ۸�
            if (ddlRegType.SelectedValue == "8")
            {
                ListItem li = radio_8.SelectedItem;
                if (li != null)
                {
                    if (li.Text.Contains("/��"))
                    {
                        pnlDays.Visible = true;
                    }
                    else
                    {
                        pnlDays.Visible = false;
                    }
                }
                else
                {
                    pnlDays.Visible = false;
                }
            }
            this.lblPrice.Text = GetOneProductPrice();        
        }


        /// <summary>
        /// ����ע�᷽ʽ
        /// </summary>
        /// <param name="CartID"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected void GetbtnRadioWL(object type, string regType)
        {
            radio_8.Items.Clear();
            Pbzx.BLL.PBnet_ProductPrice priceBLL = new Pbzx.BLL.PBnet_ProductPrice();
            DataSet ds = priceBLL.GetList(" VarVersionType='" + type.ToString() + "' ");

            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                // string display = "";
                string useTime = dataRow["VarUseTime"].ToString();
                string price = dataRow["VarPrice"].ToString();
                string typeDay = price.Substring(price.Length - 2, 2);
                string intPrice = price.Remove(price.IndexOf("Ԫ"));                
                intPrice = string.Format("{0:#0.00}",Convert.ToDecimal(intPrice) * WebFunc.GetCurrentPricePercent());
                if (typeDay == "/��")
                {
                    ListItem liTian = new ListItem(intPrice + "Ԫ/��", intPrice);
                    liTian.Attributes.Add("type", "antian");
                    radio_8.Items.Add(liTian);
                    liTian.Selected = CheckStateRadio(intPrice, regType);
                }
                else
                {
                    ListItem liTian = new ListItem(useTime + intPrice + "Ԫ", intPrice);
                    liTian.Attributes.Add("type", "no");
                    radio_8.Items.Add(liTian);
                    liTian.Selected = CheckStateRadio(intPrice, regType);
                }
            }
            ///��������
            pnlDays.Visible = false;
            string[] regTypeSZ = regType.Split(new char[] { '|' });
            if (regTypeSZ.Length > 1)
            {
                if (!string.IsNullOrEmpty(regTypeSZ[1]))
                {
                    string[] myDays = regTypeSZ[1].Split(new char[] { '&' });
                    if (myDays.Length > 1)
                    {
                        if (!string.IsNullOrEmpty(myDays[1]))
                        {
                            txtDays.Text = myDays[1];
                            pnlDays.Visible = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ����ע�᷽ʽ
        /// </summary>
        /// <param name="pb_TypeName"></param>
        /// <param name="CartID"></param>
        /// <param name="pb_DemoUrl"></param>
        /// <param name="pb_RegUrl"></param>
        /// <returns></returns>
        protected void GetbtnRadioBD(object pb_TypeName, string pb_DemoUrl, string pb_RegUrl, string regType)
        {

            radio_8.Items.Clear();
            string danj = pb_DemoUrl.ToString();

            string intPrice = danj;

            string zhoongS = pb_RegUrl.ToString();

            string intPrice2 = zhoongS;

            if (pb_TypeName.ToString() == "רҵ��" || pb_TypeName.ToString() == "��׼��" || pb_TypeName.ToString() == "��ɱ��" || pb_TypeName.ToString() == "���ΰ�" || pb_TypeName.ToString() == "��ǰ�")
            {
                ListItem liZhuan = new ListItem(intPrice + "Ԫ/��", intPrice);
                liZhuan.Selected = CheckStateRadio(intPrice, regType);
                this.radio_8.Items.Add(liZhuan);
            }
//            ListItem liTao = new ListItem(intPrice2 + "Ԫ/��", intPrice2);
//            liTao.Selected = CheckStateRadio(intPrice2, regType);
//            radio_8.Items.Add(liTao);
        }

        /// <summary>
        /// �����ע�᷽ʽ
        /// </summary>
        /// <param name="pb_TypeName"></param>
        /// <param name="CartID"></param>
        /// <param name="pb_DemoUrl"></param>
        /// <param name="pb_RegUrl"></param>
        /// <returns></returns>
        protected void GetbtnRadioRJG(object pb_TypeName,  string pb_DemoUrl, string pb_RegUrl, string regType)
        {
            radio_8.Items.Clear();
            string danj = pb_DemoUrl.ToString();
            string intPrice = danj;
            decimal p1 = 0;
            if (decimal.TryParse(intPrice, out p1))
            {
            }
            else
            {
                intPrice = "";
            }
            string zhoongS = pb_RegUrl.ToString();
            string intPrice2 = zhoongS;
            decimal p2 = 0;
            if (decimal.TryParse(intPrice2, out p2))
            {
            }

            decimal p3 = p1 + WebInit.webBaseConfig.SoftdogPrice;
            decimal p4 = p2 + WebInit.webBaseConfig.SoftdogPrice;
            StringBuilder sb = new StringBuilder();
            if (pb_TypeName.ToString() == "רҵ��" || pb_TypeName.ToString() == "��׼��" || pb_TypeName.ToString() == "��ɱ��" || pb_TypeName.ToString() == "���ΰ�" || pb_TypeName.ToString() == "��ǰ�")
            {
                ListItem liZhuan = new ListItem(intPrice + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ", p3.ToString());
                liZhuan.Selected = CheckStateRadio(p3.ToString(), regType);
                radio_8.Items.Add(liZhuan);
            }
//            ListItem liTao = new ListItem(intPrice2 + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ", p4.ToString());
//            liTao.Selected = CheckStateRadio(p4.ToString(), regType);
//            radio_8.Items.Add(liTao);

        }


        /// <summary>
        /// �������ע�᷽ʽ����radiobuttonlist
        /// </summary>
        /// <param name="ddlType"></param>
        /// <param name="rowIndex"></param>
        private void CreateRadioList(string ddlType, string RegType)
        {
            if (this.ddlSoftList.SelectedValue == "-1")
            {
                ScriptManager.RegisterStartupScript(this.UpAddProduct, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("", "����ѡ��������ƣ�", 400, "2", "", "", false, false) + "", false);
                return;
            }
            DataRow row = DbHelperSQL.Query(" select top 1 pb_SoftID,pb_SoftName,pb_DemoUrl,pb_RegUrl,pb_TypeName from PBnet_Product where pb_SoftID='" + this.ddlSoftList.SelectedValue + "' ").Tables[0].Rows[0];
            string pb_TypeName = row["pb_TypeName"].ToString();
            string pb_DemoUrl = row["pb_DemoUrl"].ToString().Remove(row["pb_DemoUrl"].ToString().IndexOf("Ԫ"));//YearMoney
            pb_DemoUrl = Convert.ToString(Convert.ToDecimal(pb_DemoUrl) * WebFunc.GetCurrentPricePercent());
            string pb_RegUrl = row["pb_RegUrl"].ToString().Remove(row["pb_RegUrl"].ToString().IndexOf("Ԫ"));//LifeMoney
            pb_RegUrl = Convert.ToString(Convert.ToDecimal(pb_RegUrl) * WebFunc.GetCurrentPricePercent());
           
            switch (ddlType)
            {
                case "8":
                    GetbtnRadioWL(pb_TypeName, RegType);
                    break;
                case "1":
                    GetbtnRadioBD(pb_TypeName, pb_DemoUrl, pb_RegUrl, RegType);
                    break;
                case "9":
                    GetbtnRadioBD(pb_TypeName, pb_DemoUrl, pb_RegUrl, RegType);
                    break;
                case "7":
                    GetbtnRadioRJG(pb_TypeName, pb_DemoUrl, pb_RegUrl, RegType);
                    break;
                case "6":
                    GetbtnRadioBD(pb_TypeName, pb_DemoUrl, pb_RegUrl, RegType);
                    break;
            }
        }


        /// <summary>
        /// ���radiobutton���ѡ��״̬
        /// </summary>
        /// <param name="value"></param>
        /// <param name="regType"></param>
        /// <param name="CartID"></param>
        /// <returns></returns>
        protected bool CheckStateRadio(string value, string regType)
        {

            string[] regTypeSZ = regType.Split(new char[] { '|' });
            if (regTypeSZ.Length > 1)
            {
                if (!string.IsNullOrEmpty(regTypeSZ[1]))
                {
                    string price = "";
                    string[] days = regTypeSZ[1].Split(new char[] { '&' });
                    price = days[0];
                    if (decimal.Parse(value) == decimal.Parse(price))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //����۸�ѡ��ı�ʱ��
        protected void radio_8_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListItem li = this.radio_8.SelectedItem;      
            if (li.Text.Contains("/��"))
            {
                pnlDays.Visible = true;
            }
            else
            {
                pnlDays.Visible = false;
            }
            this.lblPrice.Text =  GetOneProductPrice();
        }
        /// <summary>
        /// �ж��Ƿ���ʾ�û�������֤��
        /// </summary>
        private void DisplayUnameRZM(string RegType)
        {
        
            string result = "";
            string[] types = RegType.Split(new char[] { '|' });
            if (types.Length > 2 && !string.IsNullOrEmpty(types[2]))
            {
                result = types[2];
            }
            if (ddlRegType.SelectedValue != "-1")
            {
                if (ddlRegType.SelectedValue == "8")
                {
                    txtUserName.Text = result;
                    pnlUserName.Visible = true;
                    pnlRZM.Visible = false;
                }
                else if (ddlRegType.SelectedValue == "1" || ddlRegType.SelectedValue == "9")
                {
                    txtRZM.Text = result;
                    pnlUserName.Visible = false;
                    pnlRZM.Visible = true;
                }
                else
                {
                    pnlUserName.Visible = false;
                    pnlRZM.Visible = false;
                }
            }
            else
            {
                pnlUserName.Visible = false;
                pnlRZM.Visible = false;
            }
        }

        /// <summary>
        /// ���㵱ǰ�м۸���ܼ۸�
        /// </summary>
        /// <param name="rowIndex"></param>
        private void CalCurrentRowPrice()
        {
            //�û���������֤��start
            string temp = "";
            if (pnlUserName.Visible)
            {
                temp = Input.FilterAll(txtUserName.Text);
            }
            else if (pnlRZM.Visible)
            {
                temp = Input.FilterAll(txtRZM.Text);
            }
            //�û���������֤��end
            if (radio_8.SelectedValue == null)
            {
                ScriptManager.RegisterStartupScript(this.UpAddProduct, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("", "��û��ѡ���κ�������ۣ�", 400, "2", "", "", false, false) + "", false);
                return;
            }
        }

        /// <summary>
        /// ���㵱ǰ�м۸���ܼ۸�����
        /// </summary>
        /// <param name="rowIndex"></param>
        private void CalCurrentRowPrice(string days)
        {
            if (this.radio_8.SelectedItem == null)
            {
                ScriptManager.RegisterStartupScript(this.UpAddProduct, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("", "��û��ѡ��������ۣ�", 400, "2", "", "", false, false) + "", false);
                return;
            }
        }


        /// <summary>
        /// �õ���ǰ�м۸�
        /// </summary>
        /// <param name="CartID"></param>
        /// <param name="regType"></param>
        /// <returns></returns>
        protected string GetOneProductPrice()
        {           
            decimal result = 0;
            decimal tempTotalPrice = 0;
            int quantity = 0;
            int.TryParse(Input.FilterAll(txtQuatity.Text), out quantity);
            if (decimal.TryParse(this.radio_8.SelectedValue, out tempTotalPrice))
            {
                if (pnlDays.Visible)
                {
                    int days = 1;
                    if (int.TryParse(this.txtDays.Text, out days))
                    {
                        result = tempTotalPrice * days * quantity;
                    }
                }
                else
                {
                    result = tempTotalPrice * quantity;
                }
            }           
            return result.ToString();
        }

        /// <summary>
        /// ����ѡ������RegType�ֶ�
        /// </summary>
        /// <returns></returns>
        private string[] CreateRegType()
        {
            string[] resultSZ = new string[2];
            string result = "";
            decimal tempTotalPrice = 0;
            if (decimal.TryParse(this.radio_8.SelectedValue, out tempTotalPrice))
            {
                if (pnlDays.Visible)
                {
                    result = this.ddlRegType.SelectedValue + "|" + this.radio_8.SelectedValue + "&" + Input.FilterAll(this.txtDays.Text);
                }
                else
                {
                    result = this.ddlRegType.SelectedValue + "|" + this.radio_8.SelectedValue;
                }
            }
            else
            {
                result = this.ddlRegType.SelectedValue + "|";
            }
            result += "|";

            //�û���������֤��start
            string useTime1 = "";
            string useTime2 = "";
            string temp = "";
            if (pnlUserName.Visible)
            {
                temp = Input.FilterAll(txtUserName.Text);
                if (pnlDays.Visible)
                {
                    useTime1 = "2";
                    useTime2 = this.txtDays.Text;
                }
                else
                {
                    useTime1 = "1";
                    if(radio_8.SelectedIndex == 0)
                    {
                        useTime2 = "3";
                    }
                    else if (radio_8.SelectedIndex == 1)
                    {
                        useTime2 = "6";
                    }
                    else if (radio_8.SelectedIndex == 2)
                    {
                        useTime2 = "12";
                    }
                }
            }             
            else if (pnlRZM.Visible)
            {
                temp = Input.FilterAll(txtRZM.Text);
            }

            if (!pnlUserName.Visible)
            {
                if(radio_8.SelectedIndex == 0)
                {
                    useTime1 = "4";
                }
                else if (radio_8.SelectedIndex == 1)
                {
                    useTime1 = "7";
                }
            }
            //�û���������֤��end
            if (!string.IsNullOrEmpty(temp))
            {
                result += temp;
            }
            resultSZ[0] = result;
            resultSZ[1] = useTime1 + "|" + useTime2;
            return resultSZ;
        }

        /// <summary>
        /// ������Ʒ���б�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    
        private string  CheckAll()
        {
            StringBuilder sb = new StringBuilder("");
            if(this.ddlSoftList.SelectedValue == "-1")
            {
                sb.Append("��û��ѡ��������ƣ�<br/>");
            }
            if (this.ddlRegType.SelectedValue == "-1")
            {
                sb.Append("��û��ѡ�����ע�᷽ʽ��<br/>");
            }
            if(pnlUserName.Visible)
            {
                int count = Convert.ToInt32(DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + Input.FilterAll(txtUserName.Text) + "' "));
                if (count < 1)
                {
                    sb.Append("�û�������<br/>");
                }              
            }
            if (pnlRZM.Visible)
            {
                string result = Method.CheckCartRegType(Input.FilterAll(txtRZM.Text), ddlRegType.SelectedValue, this.ddlSoftList.SelectedValue);
                if (!string.IsNullOrEmpty(result))
                {
                    sb.Append("��֤�����<br/>");
                }
            }
            if (string.IsNullOrEmpty(this.radio_8.SelectedValue))
            {
                sb.Append("���������û��ѡ��ʹ��ʱ�䣡<br/>");
            }
               
            string tempYZ = CheckIsNum("��������", Input.FilterAll(txtQuatity.Text));
            if (!string.IsNullOrEmpty(tempYZ))
            {
                sb.Append("" + tempYZ + "<br/>");
            }
            if (pnlDays.Visible)
            {
                string tempYZTS = CheckIsNum("����", Input.FilterAll(txtDays.Text));
                if (!string.IsNullOrEmpty(tempYZTS))
                {
                    sb.Append("" + tempYZTS + "<br/>");
                }
            }
            decimal totalPrice = 0;
            if (!decimal.TryParse(this.lblPrice.Text, out totalPrice))
            {
                sb.Append("�۸�����<br/>");
            }
            return sb.ToString();
        }

        /// <summary>
        /// ������������Ƿ�Ϸ�
        /// </summary>
        /// <param name="name"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        private string CheckIsNum(string name, string text)
        {
            int result = 0;
            if (!int.TryParse(text, out result))
            {
                return name + "����";
            }
            else
            {
                if (result < 1)
                {
                    return name + "����";
                }
            }
            return "";
        }


        /// <summary>
        /// ���ѡ��ı��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void ddlSoftList_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ddlRegType.SelectedValue = "-1";
        }

        protected void txtDays_TextChanged(object sender, EventArgs e)
        {
            this.lblPrice.Text = GetOneProductPrice();
        }

        protected void txtQuatity_TextChanged(object sender, EventArgs e)
        {
            this.lblPrice.Text = GetOneProductPrice();
        }

        protected void txtUserName_TextChanged(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(DbHelperSQLBBS.GetSingle("select count(1) from Dv_User where UserName='" + Input.FilterAll(txtUserName.Text) + "' "));
            if (count < 1)
            {
                ScriptManager.RegisterStartupScript(this.UpAddProduct, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("", "�û�������", 400, "2", "", "", false, false) + "", false);
                return;
            }
            this.lblPrice.Text = GetOneProductPrice();

        }

        protected void txtRZM_TextChanged(object sender, EventArgs e)
        {
            string result = Method.CheckCartRegType(Input.FilterAll(txtRZM.Text), ddlRegType.SelectedValue,this.ddlSoftList.SelectedValue);
            if (!string.IsNullOrEmpty(result))
            {
                ScriptManager.RegisterStartupScript(this.UpAddProduct, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("", result, 400, "2", "", "", false, false) + "", false);
                return;
            }
            this.lblPrice.Text = GetOneProductPrice();
        }


        #region ��ȡ���ﳵ
        public void BindShoppingCart()
        {
            string cartGuid = Method.GetDelegateCartGuid();
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();
            GridView1.DataSource = shoppingCartBll.SelectShoppingCartByCartGuid(cartGuid);
            GridView1.DataBind();
            if (GridView1.Rows.Count == 0)
            {
                lblMsg.Text = "���ﳵ��ǰΪ�գ�";
            }
            else
            {
                lblMsg.Text = "";
                lblSumQuatity.Text = SumQuatity.ToString();
                lblSumBookPrice.Text = string.Format("{0:C2}", SumBookPrice);
            }
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
                Label lblQuantity = (Label)e.Row.FindControl("lblQuantity");
                int quatity = Convert.ToInt32(lblQuantity.Text);
                SumQuatity += quatity;
                e.Row.Cells[3].Text = Convert.ToString(quatity * price);

                decimal totalBookPrice = Convert.ToDecimal(e.Row.Cells[3].Text);
                SumBookPrice += totalBookPrice;
                e.Row.Cells[3].Text = string.Format("{0:C2}", totalBookPrice);
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
                        decimal decPrice = decimal.Parse(intPrice)*WebFunc.GetCurrentPricePercent();
                        if (strSZ.Length > 1 && !string.IsNullOrEmpty(strSZ[1]))
                        {
                            string[] priceSZ = strSZ[1].Split(new char[] { '&' });
                            if (priceSZ.Length > 1 && !string.IsNullOrEmpty(priceSZ[1]))
                            {
                                price = priceSZ[0];
                                if (decPrice == decimal.Parse(price))
                                {
                                    sb.Append(useTime + price + "Ԫ�� ������" + priceSZ[1]);
                                }
                            }
                            else
                            {
                                if (decPrice == decimal.Parse(strSZ[1]))
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
                            if (decPrice == decimal.Parse(strSZ[1]))
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

                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                    intPrice = Convert.ToString(decimal.Parse(intPrice) * WebFunc.GetCurrentPricePercent());

                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    intPrice2 = Convert.ToString(decimal.Parse(intPrice2) * WebFunc.GetCurrentPricePercent());

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

                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                    intPrice = Convert.ToString(decimal.Parse(intPrice) * WebFunc.GetCurrentPricePercent());

                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    intPrice2 = Convert.ToString(decimal.Parse(intPrice2) * WebFunc.GetCurrentPricePercent());

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

                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                    decimal p1 = 0;
                    if (decimal.TryParse(intPrice, out p1))
                    {
                        p1 = p1 * WebFunc.GetCurrentPricePercent();
                    }
                    else
                    {
                        intPrice = "";
                    }
                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    decimal p2 = 0;
                    if (decimal.TryParse(intPrice2, out p2))
                    {
                        p2 = p2 * WebFunc.GetCurrentPricePercent();
                    }
                    decimal p3 = p1 + WebInit.webBaseConfig.SoftdogPrice;
                    decimal p4 = p2 + WebInit.webBaseConfig.SoftdogPrice;
                    if (pb_TypeName.ToString() == "רҵ��" || pb_TypeName.ToString() == "��׼��" || pb_TypeName.ToString() == "��ɱ��" || pb_TypeName.ToString() == "���ΰ�" || pb_TypeName.ToString() == "��ǰ�")
                    {
                        if (decimal.Parse(strSZ[1]) == p3)
                        {
                            sb.Append(p1 + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                        else if (decimal.Parse(strSZ[1]) == p4)
                        {
                            sb.Append(p2 + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                        }
                    }
                    else
                    {
                        sb.Append(p1 + "Ԫ/�� + " + WebInit.webBaseConfig.SoftdogPrice + "Ԫ");
                    }
                }
                else if (strSZ[0] == "6")
                {
                    sb.Append("�������ʽ(���������)��");

                    string danj = pb_DemoUrl.ToString();
                    string intPrice = danj.Remove(danj.IndexOf("Ԫ"));
                    intPrice = Convert.ToString(decimal.Parse(intPrice) * WebFunc.GetCurrentPricePercent());

                    string zhoongS = pb_RegUrl.ToString();
                    string intPrice2 = zhoongS.Remove(zhoongS.IndexOf("Ԫ"));
                    intPrice2 = Convert.ToString(decimal.Parse(intPrice2) * WebFunc.GetCurrentPricePercent());

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
 
        protected void lblDisList_Click(object sender, EventArgs e)
        {            
            this.pnlAdd.Visible = false;            
            this.pnlList.Visible = true;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            this.pnlAdd.Visible = false;
            this.pnlList.Visible = true;
        }

        protected void lbtnDel_Command(object sender, CommandEventArgs e)
        {
            WebFunc.DelShoppingCartByID(e.CommandArgument.ToString());
            BindShoppingCart();
        }

        protected void lbtnEdite_Command(object sender, CommandEventArgs e)
        {           
            this.pnlAdd.Visible = false;
            this.pnlList.Visible = true;
            Response.Redirect("AddProduct.aspx?CartID="+Input.Encrypt(e.CommandArgument.ToString()));
        }

        protected void btnbuy_Click(object sender, ImageClickEventArgs e)
        {
            this.pnlAdd.Visible = true;
            this.pnlList.Visible = false;
            Response.Redirect("AddProduct.aspx");
        }

        protected void btnsendp_Click(object sender, ImageClickEventArgs e)
        {
           // Response.Redirect("/UserCenter/AddOrder.aspx?type=1");
            int foundNewRJG = 0;
            int foundBdRJG = 0;
            foreach (GridViewRow row in GridView1.Rows)
            {
                string regType = GridView1.DataKeys[row.RowIndex].Values["RegType"].ToString();
                if (regType.Split(new char[] {'|'})[0] =="7")
                {
                    foundNewRJG++;
                }
                if (regType.Split(new char[] { '|' })[0] == "6")
                {
                    foundBdRJG++;
                }
            }
            if (foundBdRJG > 0 && foundNewRJG < 1)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "ע�᷽ʽѡ��������Ϊ��ѡ����\"�������ʽ(���������)\"������������Ӧѡ��һ��\"�������ʽ(�����������)\"��", 600, "2", "", "", false, false) + "");

                return;
            }
            else if (foundNewRJG > 1)
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "һ�����ﳵ���ֻ��ѡ��һ���������ʽ(�����������)��<br/><br/>���޸ĺ��������ύ��", 600, "2", "", "", false, false) + "");
                return;
            }
            else if (GridView1.Rows.Count < 1 )
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "����û��ѡ�������Ʒ��", 400, "2", "", "", false, false) + "");
                return;
            }
            else
            {
                Response.Write("<script>top.location='/UserCenter/AddOrderAgent.aspx?type=1';</script>");
                //Response.Redirect("/UserCenter/AddOrderAgent.aspx?type=1",true);

                //Response.Write("<script>window.open('/UserCenter/AddOrderAgent.aspx?type=1');</script>");
            }
        }

        protected void ibnAdd_Click(object sender, ImageClickEventArgs e)
        {

            string result = CheckAll();
            if (!string.IsNullOrEmpty(result))
            {
                Page.RegisterStartupScript(WebFunc.GetGuid(), "" + JS.myAlert1("", "���ύ�Ĺ��������Ϣ�д������´���:<br/><br/>" + result + "<br/>���޸ĺ��������ύ��", 400, "2", "", "", false, false) + "");
                //ClientScript.RegisterStartupScript(this.GetType(), "��ʾ", , true);
                return;
            }
            string cartGuid = Method.GetDelegateCartGuid();
            Pbzx.BLL.PBnet_ShoppingCart shoppingCartBll = new Pbzx.BLL.PBnet_ShoppingCart();




            if (hdfID.Value == "0")
            {
                Pbzx.Model.PBnet_ShoppingCart shoppingCart = new Pbzx.Model.PBnet_ShoppingCart();
                shoppingCart.ProductID = int.Parse(this.ddlSoftList.SelectedValue);







                shoppingCart.CartGuid = cartGuid;
                shoppingCart.Quatity = int.Parse(this.txtQuatity.Text);
                string[] resultSz = CreateRegType();
                shoppingCart.RegType = resultSz[0];
                shoppingCart.UseTime = resultSz[1];

                //����useTime��start          
                string useTime1 = "";
                string useTime2 = "";

                if (radio_8.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(this.UpAddProduct, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("����", "��û��ѡ���κ�ע�᷽ʽ��", 370, "2", "", "", false, false) + "", false);
                    return;
                }
                if (ddlRegType.SelectedValue == "8")
                {
                    if (pnlDays.Visible)
                    {
                        useTime1 = "2";
                        useTime2 = txtDays.Text;
                    }
                    else
                    {
                        useTime1 = "1";
                        if (radio_8.SelectedIndex == 0)
                        {
                            useTime2 = "3";
                        }
                        else if (radio_8.SelectedIndex == 1)
                        {
                            useTime2 = "6";
                        }
                        else if (radio_8.SelectedIndex == 2)
                        {
                            useTime2 = "12";
                        }
                    }
                }
                else
                {
                    if (radio_8.SelectedIndex == 0)
                    {
                        useTime1 = "4";
                    }
                    else if (radio_8.SelectedIndex == 1)
                    {
                        useTime1 = "7";
                    }
                }


                string temp = "";
                if (pnlUserName.Visible)
                {
                    temp = Input.FilterAll(txtUserName.Text);
                }
                else if (pnlRZM.Visible)
                {
                    temp = Input.FilterAll(txtRZM.Text);
                }

                shoppingCart.UseTime = useTime1 + "|" + useTime2;

                //����useTime��end


                

               int  cartID =   shoppingCartBll.InsertShoppingCart(shoppingCart);



               Pbzx.Model.PBnet_ShoppingCart CartModel = WebFunc.UpdateShoppingCart(cartID.ToString(), "1", ddlRegType.SelectedValue, radio_8.SelectedValue, temp, useTime1 + "|" + useTime2);

            }
            else
            {
                Pbzx.Model.PBnet_ShoppingCart shoppingCart = shoppingCartBll.GetModel(long.Parse(Input.Decrypt(hdfID.Value)));
                shoppingCart.ProductID = int.Parse(this.ddlSoftList.SelectedValue);
                shoppingCart.CartGuid = cartGuid;
                shoppingCart.Quatity = int.Parse(this.txtQuatity.Text);
                string[] resultSz = CreateRegType();
                shoppingCart.RegType = resultSz[0];
                shoppingCart.UseTime = resultSz[1];


                //����useTime��start          
                string useTime1 = "";
                string useTime2 = "";

                if (radio_8.SelectedValue == "")
                {
                    ScriptManager.RegisterStartupScript(this.UpAddProduct, this.GetType(), WebFunc.GetGuid(), "" + JS.myAlert1("����", "��û��ѡ���κ�ע�᷽ʽ��", 370, "2", "", "", false, false) + "", false);
                    return;
                }
                if (ddlRegType.SelectedValue == "8")
                {
                    if (pnlDays.Visible)
                    {
                        useTime1 = "2";
                        useTime2 = txtDays.Text;
                    }
                    else
                    {
                        useTime1 = "1";
                        if (radio_8.SelectedIndex == 0)
                        {
                            useTime2 = "3";
                        }
                        else if (radio_8.SelectedIndex == 1)
                        {
                            useTime2 = "6";
                        }
                        else if (radio_8.SelectedIndex == 2)
                        {
                            useTime2 = "12";
                        }
                    }
                }
                else
                {
                    if (radio_8.SelectedIndex == 0)
                    {
                        useTime1 = "4";
                    }
                    else if (radio_8.SelectedIndex == 1)
                    {
                        useTime1 = "7";
                    }
                }


                string temp = "";
                if (pnlUserName.Visible)
                {
                    temp = Input.FilterAll(txtUserName.Text);
                }
                else if (pnlRZM.Visible)
                {
                    temp = Input.FilterAll(txtRZM.Text);
                }

                shoppingCart.UseTime = useTime1 + "|" + useTime2;

                //����useTime��end



                shoppingCartBll.Update(shoppingCart);
                Pbzx.Model.PBnet_ShoppingCart CartModel = WebFunc.UpdateShoppingCart(shoppingCart.CartID.ToString(), "1", ddlRegType.SelectedValue, radio_8.SelectedValue, temp, useTime1 + "|" + useTime2);

            }
            BindShoppingCart();
            this.pnlAdd.Visible = false;
            this.pnlList.Visible = true;      
        }


    }
}
