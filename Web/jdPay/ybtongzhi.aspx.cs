using jdPay.PropertyUtil;
using jdPay.responseObj;
using jdPay.signature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Pbzx.Web;

namespace jdPay
{
    public partial class ybtongzhi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            byte[] byts = new byte[Request.InputStream.Length];
            Request.InputStream.Read(byts, 0, byts.Length);
            string req = Encoding.UTF8.GetString(byts);
            String deskey = PropertyUtils.getProperty("wepay.merchant.desKey");
            String pubKey = PropertyUtils.getProperty("wepay.jd.rsaPublicKey");
            String error = "";
            try
            {
               // Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "jdpbKey：" + pubKey + ",desKey：" + deskey+"|+req"+req, true, true);
                error = "success";
                AsynNotifyResponse anyResponse = XMLUtil.decryptResXml<AsynNotifyResponse>(pubKey, deskey, req);

                //Pbzx.Common.ErrorLog.WriteLogMeng("京东在线交易", "异步通知订单号：" + anyResponse.tradeNum + ",状态：" + anyResponse.status, true, true);
                System.Diagnostics.Debug.WriteLine("异步通知订单号：" + anyResponse.tradeNum + ",状态：" + anyResponse.status);



                //判断交易状态，2代表成功
                if (anyResponse.status == "2")
                {
                    //校验交易
                    //业务参数赋值；
                    string email = "347032@qq.com";
                    string tradeNum = anyResponse.tradeNum;
                    string orderID = "";
                    if (string.IsNullOrEmpty(tradeNum))
                    {
                        Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "京东支付异步返回异常交易号为空", true, true);
                        return;
                    }
                    else
                    {
                        orderID = tradeNum.Split(new char[] { '_' })[1];
                        DataTable dtOrders = WebFunc.GetDsOrder(orderID);
                        if (dtOrders == null)
                        {
                            Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "京东支付异步返回异常，疑是订单号伪造", true, true);
                            return;
                        }
                        else
                        {
                            //校验金额
                            DataRow row = dtOrders.Rows[0];
                            decimal payJE = 0;
                            if (dtOrders.TableName == "PBnet_Orders" || dtOrders.TableName == "PBnet_Orders_Delegates")
                            {
                                payJE = Convert.ToDecimal(dtOrders.Rows[0]["HasNotPayedPrice"]);
                            }
                            else if (dtOrders.TableName == "PBnet_Charge")
                            {
                                payJE = Convert.ToDecimal(dtOrders.Rows[0]["PayMoney"]) - Convert.ToDecimal(dtOrders.Rows[0]["HasPayedPrice"]);
                            }
                            //v_amount = string.Format("{0:f}", Convert.ToDecimal(payJE));

                            if (!Convert.ToDecimal(anyResponse.amount).Equals(payJE*100))
                            {
                                Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "京东支付异步返回异常，支付金额不等于订单金额，订单号：" + orderID + "|支付金额:" + anyResponse.amount + "|payJE=" + payJE*100, true, true);
                                return;
                            }

                            //更新自己数据库的订单语句，请自己填写一下
                            WebFunc.UpdateOrder(orderID, true, string.Format("{0:f}", Convert.ToDecimal(payJE)), email, "（自动）", 22, "京东支付");
                        }

                    }

                }
                else
                {
                    Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "京东支付异步返回状态码：" + anyResponse.status + "|单号："+anyResponse.tradeTime+"|"+anyResponse.result.desc+"，没有交易成功", true, true);
                    return; 
                }

            }
            catch(Exception ex)
            {

                Pbzx.Common.ErrorLog.WriteLogMeng("在线交易", "京东支付异步返回异常:" + ex.Message+"=="+ex.StackTrace, true, true);
                error = "fail";
            }
            byte[] resByte = Encoding.UTF8.GetBytes(error);
            Response.Clear();
            Response.Write(error);
            Response.End();
        }
    }
}