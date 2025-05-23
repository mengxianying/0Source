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
using Pbzx.BLL;

namespace Pbzx.Web
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string Name = Method.Get_UserName;
            if (Name == "0")
            {
                Name = "游客";
            }
            Method.record_user_log(Name, "校验失败，数据可疑", "数据可疑", "恶意攻击");

            // Response.Write("你好");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            //string url = Input.GetWebConfig("Market").Rows[0]["WebName"];

            CM_MainBySoftwareTypeManager bz = new CM_MainBySoftwareTypeManager();
            DataSet ds = bz.GetAllList();
            Response.Write(ds.Tables[0].Rows.Count);
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
           

        }
    }
}
































//<div id="myBig" runat="server">
//    <p>
//        <!-- 控制器 -->
//        <asp:Button ID="btnInfo" runat="server" OnClientClick="return false;" Text="Click Here" />
//    </p>
//    <!-- "Wire frame" div used to transition from the button to the info panel -->
//    <div id="flyout" style="display: none; overflow: hidden; z-index: 2; background-color: #FFFFFF;
//        border: solid 1px #D0D0D0;">
//    </div>
//    <!-- Info panel to be displayed as a flyout when the button is clicked -->
//<div runat="server" id="info" style="display: none; width: 250px; z-index: 2; opacity: 0;
//    filter: progid:DXImageTransform.Microsoft.Alpha(opacity=0); font-size: 12px;
//    border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
//    <div id="btnCloseParent" style="float: right; opacity: 0; filter: progid:DXImageTransform.Microsoft.Alpha(opacity=0);">
//        <asp:LinkButton ID="btnClose" runat="server" OnClientClick="return false;" Text="X"
//            ToolTip="Close" Style="background-color: #666666; color: #FFFFFF; text-align: center;
//            font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
//    </div>
//    <div>
//        <p>
//            Once you get the general idea of the animation's markup, you'll want to play a bit.
//            All of the animations are created from simple, reusable building blocks that you
//            can compose together. Before long you'll be creating dazzling visuals. By grouping
//            steps together and specifying them to be run either in sequence or in parallel,
//            you'll achieve almost anything you can imagine, without writing a single line of
//            code!
//        </p>
//        <br />
//        <p>
//            The XML defining the animations is very easy to learn and write, such as this example's
//            <asp:LinkButton ID="lnkShow" OnClientClick="return false;" runat="server">show</asp:LinkButton>
//            and
//            <asp:LinkButton OnClientClick="return false;" ID="lnkClose" runat="server">close</asp:LinkButton>
//            markup.
//        </p>
//    </div>
//</div>

//    <script type="text/javascript" language="javascript">
//    // Move an element directly on top of another element (and optionally
//    // make it the same size)
//    function Cover(bottom, top, ignoreSize) {
//        var location = Sys.UI.DomElement.getLocation(bottom);
//        top.style.position = 'absolute';
//        top.style.top = location.y + 'px';
//        top.style.left = location.x + 'px';
//        if (!ignoreSize) {
//            top.style.height = bottom.offsetHeight + 'px';
//            top.style.width = bottom.offsetWidth + 'px';
//        }
//    }
//    </script>

//    <ajaxToolkit:AnimationExtender ID="OpenAnimation" runat="server" TargetControlID="btnInfo">
//        <Animations>
//       <OnMouseOver>

//            <Sequence>
//                <%-- Disable the button so it can't be clicked again --%>
//                <EnableAction Enabled="false" />

//                <%-- Position the wire frame on top of the button and show it --%>
//                <ScriptAction Script="Cover($get('ctl00_SampleContent_btnInfo'), $get('flyout'));" />
//                <StyleAction AnimationTarget="flyout" Attribute="display" Value="block"/>

//                <%-- Move the wire frame from the button's bounds to the info panel's bounds --%>
//                <Parallel AnimationTarget="flyout" Duration=".3" Fps="25">
//                    <Move Horizontal="150" Vertical="-50" />
//                    <Resize Width="260" Height="280" />
//                    <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
//                </Parallel>

//                <%-- Move the info panel on top of the wire frame, fade it in, and hide the frame --%>
//                <ScriptAction Script="Cover($get('flyout'), $get('info'), true);" />
//                <StyleAction AnimationTarget="info" Attribute="display" Value="block"/>
//                <FadeIn AnimationTarget="info" Duration=".2"/>
//                <StyleAction AnimationTarget="flyout" Attribute="display" Value="none"/>

//                <%-- Flash the text/border red and fade in the "close" button --%>
//                <Parallel AnimationTarget="info" Duration=".5">
//                    <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
//                    <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
//                </Parallel>
//                <Parallel AnimationTarget="info" Duration=".5">
//                    <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
//                    <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
//                    <FadeIn AnimationTarget="btnCloseParent" MaximumOpacity=".9" />
//                </Parallel>
//            </Sequence>
//        </OnMouseOver>

//        </Animations>
//    </ajaxToolkit:AnimationExtender>
//    <ajaxToolkit:AnimationExtender ID="CloseAnimation" runat="server" TargetControlID="myBig">
//        <Animations>
//        <OnMouseOut>
//            <Sequence AnimationTarget="info">
//                <%--  Shrink the info panel out of view --%>
//                <StyleAction Attribute="overflow" Value="hidden"/>
//                <Parallel Duration=".3" Fps="15">
//                    <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
//                    <FadeOut />
//                </Parallel>

//                <%--  Reset the sample so it can be played again --%>
//                <StyleAction Attribute="display" Value="none"/>
//                <StyleAction Attribute="width" Value="250px"/>
//                <StyleAction Attribute="height" Value=""/>
//                <StyleAction Attribute="fontSize" Value="12px"/>
//                <OpacityAction AnimationTarget="btnCloseParent" Opacity="0" />

//                <%--  Enable the button so it can be played again --%>
//                <EnableAction AnimationTarget="btnInfo" Enabled="true" />
//            </Sequence>
//        </OnMouseOut>
//        </Animations>
//    </ajaxToolkit:AnimationExtender>
//</div>