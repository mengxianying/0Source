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
using System.Xml;
using Pbzx.Common;

namespace Pinble_Market.admin.WebAdmin
{
    public partial class PageCount : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindTxt();
                //�̻�������ĿĬ�����ݰ�
                BindSH();
                //��3D
                grid3d.DataSource = Input.GetCP("CP3D");
                grid3d.DataBind();
                //���߲���
                GridView2.DataSource = Input.GetCP("CP���ֲ�");
                GridView2.DataBind();
                GridView3.DataSource = Input.GetCP("CP���ǲ�");
                GridView3.DataBind();
                GridView4.DataSource = Input.GetCP("CP˫ɫ��");
                GridView4.DataBind();
                GridView5.DataSource = Input.GetCP("CP������");
                GridView5.DataBind();
                GridView6.DataSource = Input.GetCP("CP����͸");
                GridView6.DataBind();
                GridView7.DataSource = Input.GetCP("CP22ѡ5");
                GridView7.DataBind();
                GridView8.DataSource = Input.GetCP("CP31ѡ7");
                GridView8.DataBind();
            }
        }
        /// <summary>
        /// ���̻�Ĭ������
        /// </summary>
        private void BindSH()
        {
            txtbegmomery.Text = Input.GetValue("SmallMoney");
            txtendmomery.Text = Input.GetValue("BigMoney");
            txtticheng.Text = Input.GetValue("Ticheng");
            rdoistop.SelectedValue = Input.GetValue("Sign");
            rdoistuijian.SelectedValue = Input.GetValue("Recommend");
            rdoisoff.SelectedValue = Input.GetValue("On_Off");
        }

        private void BindTxt()
        {
            txtprice.Text = Input.GetPrice();
            txtwebcount.Text = Input.GetCount();
            txtmanagecount.Text = Input.GetManageCount();
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnok_Click(object sender, EventArgs e)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                //�ж������ʲô�����޶�
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/MarketConfig.xml"));

                //�õ����ڵ�
                XmlElement root = doc.DocumentElement;
                if (root.ChildNodes.Count > 0)
                {

                    XmlNode haha = root.SelectNodes("webPage")[0];
                    XmlNode haha1 = root.SelectNodes("Price")[0];
                    XmlNode txtmanage = root.SelectNodes("webPageManage")[0];
                    //�õ�����ID
                    haha.SelectSingleNode("@value").Value = txtwebcount.Text;
                    haha1.SelectSingleNode("@value").Value = txtprice.Text;
                    txtmanage.SelectSingleNode("@value").Value = txtmanagecount.Text;
                    doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/MarketConfig.xml"));
                }
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸ĳɹ���');</script>");
                return;
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('�޸�ʧ�ܣ�');</script>");
                return;
            }
        }

        /// <summary>
        /// 3d�����¼�����ʱ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid3d_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "BJ")
            {
                Response.Redirect("AddLottory.aspx?number=" + e.CommandArgument);
            }
            else if (e.CommandName == "DE")
            {
                string[] sz = e.CommandArgument.ToString().Split(',');
                string lootroy = sz[0];
                string number = sz[1];
                if (lootroy != "" && number != "")
                {
                    DeleteXML(number, lootroy);
                    Response.Redirect("PageCount.aspx");
                }
            }
        }

        /// <summary>
        /// ɾ�����÷���
        /// </summary>
        /// <param name="e"></param>
        /// <param name="lj"></param>
        private static bool DeleteXML(string number1, string lootroy)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/LottoryCondition.xml"));
                //�õ����ڵ�
                XmlElement root = doc.DocumentElement;

                if (root.ChildNodes.Count > 0)
                {
                    XmlNode haha = root.SelectNodes("CP" + lootroy)[0];
                    //Ϊ�޸�

                    for (int i = 0; i < haha.ChildNodes.Count; i++)
                    {
                        XmlNode haha1 = haha.SelectNodes("chi")[i];
                        string number = haha1.SelectSingleNode("@number").Value;
                        if (number == number1)
                        {
                            haha.RemoveChild(haha1);
                        }
                    }
                }
                doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/LottoryCondition.xml"));
                return false;
            }
            catch
            {
                return true;

            }
        }

        /// <summary>
        /// �༭����ƴ��
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bj"></param>
        /// <param name="bj2"></param>
        /// <returns></returns>
        public string BindBJ(object obj, object bj, object bj2)
        {
            return bj.ToString() + "&itemname=" + bj2 + "&lottoryname=" + obj;
        }

        /// <summary>
        /// ɾ������ƴ��
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="bj"></param>
        /// <param name="bj2"></param>
        /// <returns></returns>
        public string BindDE(object ob, object bj2)
        {
            return ob.ToString() + "," + bj2.ToString();
        }

        /// <summary>
        /// ������3D��Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbut3D_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=3D");
        }
        /// <summary>
        /// ���������ǲ���Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbutqxc_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=���ǲ�");
        }
        /// <summary>
        /// ����������5��Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbutplw_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=������");
        }
        /// <summary>
        /// ������22ѡ5��Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbut22x5_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=22ѡ5");
        }
        /// <summary>
        /// ���������ֲ���Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbutqlc_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=���ֲ�");
        }
        /// <summary>
        /// ������˫ɫ����Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbutssq_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=˫ɫ��");
        }
        /// <summary>
        /// �����Ӵ���͸��Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbutdlt_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=����͸");
        }
        /// <summary>
        /// ������31ѡ7��Ŀ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void linkbut31xq7_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddLottory.aspx?lottoryname=31ѡ7");
        }
        /// <summary>
        /// �а��¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void grid3d_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                (e.Row.Cells[2].FindControl("LinkButton1") as LinkButton).Attributes.Add("onclick", "javascript: return confirm('���ȷ��Ҫɾ����" + e.Row.Cells[1].Text + "����');");
                e.Row.Attributes.Add("onmouseover", "curr=this.style.backgroundColor; this.style.backgroundColor='#A6FFFF';");
                e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=curr");
            }
        }
        /// <summary>
        /// ��������̻�Ĭ������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnokSH_Click(object sender, EventArgs e)
        {
            Input.SetValue("SmallMoney", txtbegmomery.Text);
            Input.SetValue("BigMoney", txtendmomery.Text);
            Input.SetValue("Ticheng", txtticheng.Text);
            Input.SetValue("On_Off", rdoisoff.SelectedValue);
            Input.SetValue("Sign", rdoistop.SelectedValue);
            Input.SetValue("Recommend", rdoistuijian.SelectedValue);
        }


    }
}
