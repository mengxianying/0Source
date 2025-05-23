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

namespace Pbzx.Web.PB_Manage
{
    public partial class Cut_value : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnOK_Click(object sender, EventArgs e)
        {

            decimal mo = 0;
            if (!decimal.TryParse(this.txtPayMoney.Text, out mo))
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('������ÿۿ����ȷ')", true);
                return;
            }
            else if (mo < 0)
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('������ÿۿ����ȷ')", true);
                return;
            }
            


            Pbzx.BLL.PBnet_UserTable utBLL = new Pbzx.BLL.PBnet_UserTable();
            Pbzx.Model.PBnet_UserTable ut = utBLL.GetModelName(Input.FilterAll(this.txtUname.Text));
            if (mo > ut.CurrentMoney)
            {
                ClientScript.RegisterStartupScript(GetType(), "error", "alert('���󣡿ۿ�������û���')", true);
                return;
            }
            ut.CurrentMoney -= mo;
            bool result = utBLL.Update(ut);
            /////////////////д�뽻����Ϣ��//////////////////////////////////////////////
            Pbzx.BLL.PBnet_UserTradeInfo tradeBll = new Pbzx.BLL.PBnet_UserTradeInfo();
            Pbzx.Model.PBnet_UserTradeInfo tradeModel = new Pbzx.Model.PBnet_UserTradeInfo();
            tradeModel.Account_UserName = "";
            tradeModel.AccountNumber = "";
            tradeModel.BankName = "";
            tradeModel.CurrentMoney = 0;

            Pbzx.Model.PBnet_UserTable userRealModel = Pbzx.BLL.PBnet_UserTable.GetRealInfoByUname(Input.FilterAll(this.txtUname.Text));
            if (userRealModel != null)
            {
                tradeModel.Account_UserName = userRealModel.RealName;
                tradeModel.AccountNumber = userRealModel.AccountNumber;
                tradeModel.BankName = userRealModel.BankName;
                tradeModel.CurrentMoney = userRealModel.CurrentMoney;
            }
            tradeModel.ForeignKey_id = "";
            tradeModel.OperateManager = WebFunc.GetCurrentAdmin();
             string strBZ = DateTime.Now + "��̨����Ա���û�[" + this.txtUname.Text + "]�۳����" + Math.Round(mo, 2) + "Ԫ";
            if (!string.IsNullOrEmpty(txtDetails.Text))
            {
                strBZ += "����ע��Ϣ��" + this.txtDetails.Text;
            }
            tradeModel.Remark = strBZ;            
            tradeModel.TradeMoney = Math.Round(mo, 2);
            tradeModel.TradeTime = DateTime.Now;
            tradeModel.UserName = this.txtUname.Text;
            tradeModel.TradeType = 773;
            tradeBll.Add(tradeModel);
            /////////////////д�뽻����Ϣ��//////////////////////////////////////////////

            if (result)
            {
                Response.Write("<script language='javascript'>alert('�ۿ�ɹ���');window.returnValue ='1';self.close();</script>");
            }
            else
            {
                Response.Write("<script language='javascript'>alert('�ۿ�ʧ�ܣ�');window.returnValue ='0';self.close();</script>");
            }
        }
    }
}
