using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dag11_CodeFirst3__Work.Models
{
    public class Const
    {
        public const string SMTP_ADDDRESS = "10.138.22.47";

        private static string _mailSubject = "Skolen er brændt ned til grunden !!!";
        private static string _mailMessage = "Da skolen er brændt ned til grunden her i nat," +
                                             " har alle skolens elever fri på ubestemt tid !!!";

        public static string MailSubject
        {
            get
            {
                return (_mailSubject);
            }

            set
            {
                _mailSubject = value;
            }
        }

        public static string MailMesage
        {
            get
            {
                return (_mailMessage);
            }

            set
            {
                _mailMessage = value;
            }
        }
    }
}