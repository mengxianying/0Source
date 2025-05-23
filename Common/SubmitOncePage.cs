using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Common
{
/// <summary>
/// 名称：SubmitOncePage 
/// 父类：System.Web.UI.Page
/// 描述：解决浏览器刷新造成的数据重复提交问题的page扩展类。
/// 示例：if (!this.IsRefreshed)
///{
/////具体代码
///}
/// </summary>
public class SubmitOncePage:System.Web.UI.Page
        {
            private string _strSessionKey;
            private string _hiddenfieldName;
            private string _strLastViewstate;
           
            public SubmitOncePage()
            {
                _hiddenfieldName = "__LastVIEWSTATE_SessionKey";
                _strSessionKey = System.Guid.NewGuid().ToString();
                _strLastViewstate = string.Empty;
            }

            public bool IsRefreshed
            {
                get
                {
                    string str1 = GetSessinContent();
                    _strLastViewstate = str1;
                    string str2 = this.Session[GetSessinKey()] as string;
                    bool flag1 = (str1 != null) && (str2 != null) && (str1 == str2);
                    return flag1;
                }
            }

            protected override void Render(System.Web.UI.HtmlTextWriter writer)
            {
                string str = GetSessinKey();
                this.Session[str] = _strLastViewstate;
                this.RegisterHiddenField(_hiddenfieldName, str);
                base.Render(writer);
            }


            private string GetSessinKey()
            {
                string str = this.Request.Form[_hiddenfieldName];
                return (str == null) ? _strSessionKey : str;
            }

            private string GetSessinContent() {
                string str = this.Request.Form["__VIEWSTATE"];
                if (str == null) {
                    return null;
                }
                return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
            }
           
        }
}


