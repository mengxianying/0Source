using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pinble_Market.admin.Note;
using System.Data;

namespace Pinble_Sms.admin.Note
{
    public partial class Note_Restore : System.Web.UI.Page
    {
        Pbzx.BLL.Note_WriteBack notewrite = new Pbzx.BLL.Note_WriteBack();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取最新消息
                SMSClass sms = new SMSClass();
                DataSet ds = sms.GetSMS();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Pbzx.Model.Note_WriteBack writeback = new Pbzx.Model.Note_WriteBack();
                        writeback.Phone = ds.Tables[0].Rows[i]["SenderNo"].ToString();
                        writeback.Content = ds.Tables[0].Rows[i]["MsgContent"].ToString();
                        writeback.BeginTime = Convert.ToDateTime(ds.Tables[0].Rows[i]["SendTime"].ToString());
                        writeback.Sp_PID = ds.Tables[0].Rows[i]["SP_PID"].ToString();
                        notewrite.Add(writeback);
                    }

                }

                GridView1.DataSource = notewrite.GetIList();
                GridView1.DataBind();
            }
        }
    }
}