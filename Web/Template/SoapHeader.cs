using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Pbzx.Web.Template
{
	//<summary>  
	//定义自己的SoapHeader派生类  
	//</summary>  
	public class MySoapHeader : System.Web.Services.Protocols.SoapHeader  
	{  
        private string _UserID = string.Empty;  
	    private string _PassWord = string.Empty;  
	    //<summary>  
	    //构造函数  
	    //</summary>  
	    public MySoapHeader()  
	    {  
	    }  
	    //<summary>  
	    //构造函数  
	    //</summary>  
	    //<param name="nUserID">用户ID</param>  
	    //<param name="nPassWord">加密后的密码</param>  
	    public MySoapHeader(string nUserID, string nPassWord)  
	    {  
	        Initial(nUserID, nPassWord);  
	    }  
	    #region 属性  
	    //<summary>  
	    //用户名  
	    //</summary>  
	    public string UserID  
	    {  
	        get { return _UserID; }  
	        set { _UserID = value; }  
	    }  
	    //<summary>  
	    //加密后的密码  
	    //</summary>  
	    public string PassWord  
	    {  
	        get { return _PassWord; }  
	        set { _PassWord = value; }  
	    }          
	    #endregion  
	    #region 方法  
	    //<summary>  
	    //初始化  
	    //</summary>  
	    //<param name="nUserID">用户ID</param>  
	    //<param name="nPassWord">加密后的密码</param>  
	    private void Initial(string nUserID, string nPassWord)  
	    {  
	        UserID = nUserID;  
	        PassWord = nPassWord;  
	    }  
	    //<summary>  
	    //验证用户名密码是否正确  
	    //</summary>  
	    //<param name="nUserID">用户ID</param>  
	    //<param name="nPassWord">加密后的密码</param>  
	    //<param name="nMsg">返回的错误信息</param>  
	    //<returns>用户名密码是否正确</returns>  
	    public bool IsValid(string nUserID, string nPassWord, out string nMsg)  
	    {  
	        nMsg = "";  
	        try 
	        {  
	            //判断用户名密码是否正确   
                if (nUserID == "asdqHDS131" && nPassWord == "asdqHDS131")  
	            {  
	                return true;  
	            }  
	            else 
	            {  
	                nMsg = "对不起，你无权调用此Web服务。";  
	                return false;  
	            }  
	        }  
	        catch 
	        {  
	            nMsg = "对不起，你无权调用此Web服务。";  
	            return false;  
	        }  
	    }  
	    //<summary>  
	    //验证用户名密码是否正确  
	    //</summary>  
	    //<returns>用户名密码是否正确</returns>  
	    public bool IsValid(out string nMsg)  
	    {  
	        return IsValid(_UserID, _PassWord, out nMsg);  
	    }  
	    #endregion  
	} 


}
