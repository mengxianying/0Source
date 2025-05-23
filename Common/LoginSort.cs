using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Pbzx.Common
{
    public class LoginSort
    {
       // private bool _isHas;
        /// <summary>
        /// 判断是否含有此类别信息
        /// </summary>
        /// <param name="_myIndex">信息类型</param>
        /// <returns>是否含有</returns>
        /// author:meng
        public  bool this[string _myIndex]
        {
            get
            {
                //PinbleLogin pb = new PinbleLogin();
                //pb.ReLogin();
                if (!HttpContext.Current.User.Identity.IsAuthenticated)
                {
                    return false;
                }
                bool isfound = false;
                string[] logins =   ((System.Web.Security.FormsIdentity)HttpContext.Current.User.Identity).Ticket.UserData.Split(new char[] { '|' });
                foreach(string str in logins)
                {
                    if(str == _myIndex)
                    {
                        isfound = true;
                        break;
                    }
                }
                return isfound;
            }
        }

    }
}
