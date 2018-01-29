using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Web.Mvc;
using System.Web.Security;
using System.Text;
using System.Security.Cryptography;
using SCMProfit.Models;
using SCMProfitCore.Model.CustomerModule;

namespace SCMProfit.EmailService
{
    public class EmailService
    {

        public static void SendConfirmationMessageByEmail(Customer customer, string body)
        {
            using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["SMTPuser"], customer.Email))
            {
                mm.Subject = "User Information Detail";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = true;

                NetworkCredential networkCred = new NetworkCredential(ConfigurationManager.AppSettings["SMTPuser"], ConfigurationManager.AppSettings["SMTPpassword"]);
                smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"]);
                smtp.Credentials = networkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["EmailPort"]);
                smtp.Send(mm);
            }
        }

        public static void SendPasswordByEmail(Customer customer, string body)
        {
            using (MailMessage mm = new MailMessage(ConfigurationManager.AppSettings["SMTPuser"], customer.Email))
            {
                mm.Subject = "User Information Detail";
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = ConfigurationManager.AppSettings["Host"];
                smtp.EnableSsl = true;

                NetworkCredential networkCred = new NetworkCredential(ConfigurationManager.AppSettings["SMTPuser"],
                    ConfigurationManager.AppSettings["SMTPpassword"]);
                smtp.UseDefaultCredentials = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSSL"]);
                smtp.Credentials = networkCred;
                smtp.Port = int.Parse(ConfigurationManager.AppSettings["EmailPort"]);
                smtp.Send(mm);
            }
        }

    }
}