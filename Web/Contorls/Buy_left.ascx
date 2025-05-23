<%@ Control Language="C#" AutoEventWireup="true" Codebehind="Buy_left.ascx.cs" Inherits="Pbzx.Web.Contorls.Buy_left" %>
<%@ Register Src="UC_QQ2.ascx" TagName="UC_QQ2" TagPrefix="uc1" %>
<div class="Y_box Y_l1">
    <div class="title">
        <p>
            <span>注册购买</span></p>
    </div>
    <div class="content">
        <div>
            <div class="margin_Top">
                <a href="/SoftwarePrices.htm" style="cursor: pointer;">
                    <div class="li_box">
                        软件价格
                    </div>
                </a><a href="/RegistrationMode.htm" style="cursor: pointer;">
                    <div class="li_box">
                        注册方式
                    </div>
                </a><a href="/Payment.htm" style="cursor: pointer;">
                    <div class="li_box">
                        付款方式
                    </div>
                </a><a href="/ShowShoppingCart.aspx" style="cursor: pointer;">
                    <div class="li_box">
                        自助购买
                    </div>
                </a><a href="/ArtificialBuy.htm" style="cursor: pointer;">
                    <div class="li_box">
                        人工购买
                    </div>
                </a><a href="/Troubleshooting.aspx" style="cursor: pointer;">
                    <div class="li_box">
                        疑难解答
                    </div>
                </a><a href="/FreeUse.htm" style="cursor: pointer;">
                    <div class="li_box">
                        免费使用
                    </div>
                </a><a href="/PostedInquiry.aspx" style="cursor: pointer;">
                    <div class="li_box">
                        发帖查询
                    </div>
                </a>
            </div>
        </div>
    </div>
</div>
<div class="Y_box Y_l1 MT">
    <div class="title">
        <p>
            <span>在线客服</span></p>
    </div>
    <div class="content">
        <uc1:UC_QQ2 id="UC_QQ2_1" runat="server">
        </uc1:UC_QQ2>
    </div>
</div>
