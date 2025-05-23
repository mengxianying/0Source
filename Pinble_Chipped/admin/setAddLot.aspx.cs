using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Pinble_Chipped.admin
{
    public partial class setAddLot : System.Web.UI.Page
    {
        Pbzx.BLL.PBnet_LotteryMenu get_lu = new Pbzx.BLL.PBnet_LotteryMenu();
        Pbzx.BLL.Chipped_cofig get_cg = new Pbzx.BLL.Chipped_cofig();
        Pbzx.Model.Chipped_cofig mod_cg = new Pbzx.Model.Chipped_cofig();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCheckBoxList();
            }
        }

        //绑定数据
        public void BindCheckBoxList()
        {
            ds= get_lu.GetList("1=1");
            this.CheckBoxList1.DataSource = ds;
            this.CheckBoxList1.DataTextField = "NvarName";
            this.CheckBoxList1.DataValueField = "IntId";
            this.CheckBoxList1.DataBind();
        }

        /// <summary>
        ///添加数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_add_Click(object sender, EventArgs e)
        {
            
            int n_state = 0;
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                { 
                    //添加彩种
                    if (!get_cg.ExistsState(Convert.ToInt32(CheckBoxList1.Items[i].Value)))
                    {
                        mod_cg.cfg_lname = CheckBoxList1.Items[i].Text.ToString();
                        mod_cg.cfg_state = Convert.ToInt32(CheckBoxList1.Items[i].Value);
                        mod_cg.cfg_tarState = 0;
                        if (get_cg.Add(mod_cg) > 0)
                        {
                            n_state++;
                        }
                        else
                        {
                            n_state = 0;
                            break;
                        }
                    }
                }
                
            }
            if (n_state > 0)
            {
                Response.Write("<script>alert('添加成功')</script>");

            }
            else
            {
                Response.Write("<script>alert('添加成功')</script>");
            }
        }
    }
}