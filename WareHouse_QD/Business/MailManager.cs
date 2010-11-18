using System;
using System.Collections.Generic;
using System.Text;
using EBest.Persistent;
using eBest.Entity;

namespace eBest.Business
{
    public class MailManager
    {
        private string  _subject, _body, _address, _cc;

        public string Subject
        {
            set { _subject = value; }
        }

        public string Body
        {
            set { _body = value; } 
        }

        public string Address
        {
            set { _address = value; }
            get { return _address; }
        }

        public string CC
        {
            set { _cc = value; }
        }

        public bool AddMailList()
        {
            string url = " 系统登录网址:<a href='http://supply.com'>http://supply.com</a>";
            SYS_MailList mailList = new SYS_MailList();
            mailList.Subject = _subject;
            mailList.Body = _body + url;
            mailList.Address = _address;
            mailList.Send = "0";

            if (!string.IsNullOrEmpty(mailList.CC))
                mailList.CC = _cc;

            try
            {
                mailList.Save();
            }
            catch (Exception error)
            {
                return false;
            }
            return true;
        }

        public ObjectTable GetUnSendMailes()
        {
            try
            {
                return new ObjectTable(typeof(SYS_MailList), "this.Send=0 and this.Comment is null");
            }
            catch (Exception error)
            { 
            }
            return new ObjectTable(typeof(SYS_MailList));
        }

    }
}
