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
	//�����Լ���SoapHeader������  
	//</summary>  
	public class MySoapHeader : System.Web.Services.Protocols.SoapHeader  
	{  
        private string _UserID = string.Empty;  
	    private string _PassWord = string.Empty;  
	    //<summary>  
	    //���캯��  
	    //</summary>  
	    public MySoapHeader()  
	    {  
	    }  
	    //<summary>  
	    //���캯��  
	    //</summary>  
	    //<param name="nUserID">�û�ID</param>  
	    //<param name="nPassWord">���ܺ������</param>  
	    public MySoapHeader(string nUserID, string nPassWord)  
	    {  
	        Initial(nUserID, nPassWord);  
	    }  
	    #region ����  
	    //<summary>  
	    //�û���  
	    //</summary>  
	    public string UserID  
	    {  
	        get { return _UserID; }  
	        set { _UserID = value; }  
	    }  
	    //<summary>  
	    //���ܺ������  
	    //</summary>  
	    public string PassWord  
	    {  
	        get { return _PassWord; }  
	        set { _PassWord = value; }  
	    }          
	    #endregion  
	    #region ����  
	    //<summary>  
	    //��ʼ��  
	    //</summary>  
	    //<param name="nUserID">�û�ID</param>  
	    //<param name="nPassWord">���ܺ������</param>  
	    private void Initial(string nUserID, string nPassWord)  
	    {  
	        UserID = nUserID;  
	        PassWord = nPassWord;  
	    }  
	    //<summary>  
	    //��֤�û��������Ƿ���ȷ  
	    //</summary>  
	    //<param name="nUserID">�û�ID</param>  
	    //<param name="nPassWord">���ܺ������</param>  
	    //<param name="nMsg">���صĴ�����Ϣ</param>  
	    //<returns>�û��������Ƿ���ȷ</returns>  
	    public bool IsValid(string nUserID, string nPassWord, out string nMsg)  
	    {  
	        nMsg = "";  
	        try 
	        {  
	            //�ж��û��������Ƿ���ȷ   
                if (nUserID == "asdqHDS131" && nPassWord == "asdqHDS131")  
	            {  
	                return true;  
	            }  
	            else 
	            {  
	                nMsg = "�Բ�������Ȩ���ô�Web����";  
	                return false;  
	            }  
	        }  
	        catch 
	        {  
	            nMsg = "�Բ�������Ȩ���ô�Web����";  
	            return false;  
	        }  
	    }  
	    //<summary>  
	    //��֤�û��������Ƿ���ȷ  
	    //</summary>  
	    //<returns>�û��������Ƿ���ȷ</returns>  
	    public bool IsValid(out string nMsg)  
	    {  
	        return IsValid(_UserID, _PassWord, out nMsg);  
	    }  
	    #endregion  
	} 


}
