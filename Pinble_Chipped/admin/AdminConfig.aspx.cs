using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pbzx.Common;
using System.Xml;

namespace Pinble_Chipped.admin
{
    public partial class AdminConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                fcssqendtime.Text = Method.GetSSQDateTime;
                fcssqissue.Text = Pbzx.BLL.publicMethod.Period("FCSSData");

                FC3DData_Issue.Text = Pbzx.BLL.publicMethod.Period("FC3DData");
                FC3DData_EndTime.Text = Method.GetFCDateTime;

                plswendtime.Text = Method.GetTCPL35DateTime;
                plswissue.Text = Pbzx.BLL.publicMethod.Period("TCPL35Data");

                qxcendtime.Text = Method.GetTC7XCDateTime;
                qxcissue.Text = Pbzx.BLL.publicMethod.Period("TC7XCData_New");

                qlcendtime.Text = Method.GetFC7LCDateTime;
                qlcissue.Text = Pbzx.BLL.publicMethod.Period("FC7LC");

                dltendtime.Text = Method.GetTCDLTDateTime;
                dltissue.Text = Pbzx.BLL.publicMethod.Period("TCDLTData");
            }
        }
        /// <summary>
        /// 点击保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            SaveSSq();

            SaveFCSD();

            SavePlsw();

            SaveQXC();

            SaveQLC();

            SaveDlt();
        }
        /// <summary>
        /// 大乐透
        /// </summary>
        private void SaveDlt()
        {
            SaveIssue("TCDLTData", dltissue.Text);
            Method.GetTCDLTDateTime = dltendtime.Text;
        }
        /// <summary>
        /// 七乐彩
        /// </summary>
        private void SaveQLC()
        {
            SaveIssue("FC7LC", qlcissue.Text);
            Method.GetFC7LCDateTime = qlcendtime.Text;
        }
        /// <summary>
        /// 七星彩
        /// </summary>
        private void SaveQXC()
        {
            SaveIssue("TC7XCData_New", qxcissue.Text);
            Method.GetTC7XCDateTime = qxcendtime.Text;
        }
        /// <summary>
        /// 排列三五
        /// </summary>
        private void SavePlsw()
        {
            SaveIssue("TCPL35Data", plswissue.Text);
            Method.GetTCPL35DateTime = plswendtime.Text;
        }


        /// <summary>
        /// 福彩3D
        /// </summary>
        private void SaveFCSD()
        {

            SaveIssue("FC3DData", FC3DData_Issue.Text);
            Method.GetFCDateTime = FC3DData_EndTime.Text;
        }
        /// <summary>
        /// 双色球保存
        /// </summary>
        private void SaveSSq()
        {
            SaveIssue("FCSSData", FC3DData_Issue.Text);
            Method.GetSSQDateTime = fcssqissue.Text;

        }

        public void SaveIssue(string LottoryName, string Issue)
        {
            #region//保存期号
            XmlDocument doc_1 = new XmlDocument();
            doc_1.Load(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
            XmlElement root_1 = doc_1.DocumentElement;
            if (root_1.ChildNodes.Count > 0)
            {

                XmlNode node = root_1.SelectNodes(LottoryName)[0];
                node.SelectSingleNode("@Issue").Value = Issue;
                doc_1.Save(System.Web.HttpContext.Current.Server.MapPath("~/xml/DownIssue.xml"));
            }

            #endregion
        }
    }
}