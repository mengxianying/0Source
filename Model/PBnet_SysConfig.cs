using System;
using System.Collections.Generic;
using System.Text;

namespace Pbzx.Model
{
    public class PBnet_SysConfig
    {
        #region ¹¹Ôìº¯Êý
        public PBnet_SysConfig()
		{              
            //_ID = 0;
            //_Title = "";
            //_Master = "";
            //_Email = "";
            //_Telephone = "";
            //_Address = "";
            //_CopyRight = "";
            //_CharSet = "";
            //_MailSender = "";
            //_Sender = "";
            //_ReplyTo = "";
            //_UserName = "";
            //_Password = "";
            //_MailServer = "";
            //_Remark = "";
        }
        #endregion
		#region Model
		private int _id;
		private string _title;
		private string _master;
		private string _email;
		private string _telephone;
		private string _address;
		private string _copyright;
		private string _charset;
		private string _mailsender;
		private string _sender;
		private string _replyto;
		private string _username;
		private string _password;
		private string _mailserver;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Master
		{
			set{ _master=value;}
			get{return _master;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Email
		{
			set{ _email=value;}
			get{return _email;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Telephone
		{
			set{ _telephone=value;}
			get{return _telephone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Address
		{
			set{ _address=value;}
			get{return _address;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CopyRight
		{
			set{ _copyright=value;}
			get{return _copyright;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CharSet
		{
			set{ _charset=value;}
			get{return _charset;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MailSender
		{
			set{ _mailsender=value;}
			get{return _mailsender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Sender
		{
			set{ _sender=value;}
			get{return _sender;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ReplyTo
		{
			set{ _replyto=value;}
			get{return _replyto;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Password
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string MailServer
		{
			set{ _mailserver=value;}
			get{return _mailserver;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

    }
}
