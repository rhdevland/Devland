#region [ References ]
using System;
using System.Net.Mail;
using System.Configuration;
#endregion

namespace DevLandCR.WebProjects.WebSite.Infrastructure
{
    public sealed class EmailService
    {
        public static string SendEmail(string inputEmail, string subject, string body)
        {
            string smtp_host = ConfigurationManager.AppSettings[Constants.APP_SMTP_HOST];
            string smtp_port = ConfigurationManager.AppSettings[Constants.APP_SMTP_PORT];
            string smtp_from = ConfigurationManager.AppSettings[Constants.APP_SMTP_FROM];
            string smtp_to = ConfigurationManager.AppSettings[Constants.APP_SMTP_TO];
            string smtp_usr = ConfigurationManager.AppSettings[Constants.APP_SMTP_USR];
            string smtp_pwd = ConfigurationManager.AppSettings[Constants.APP_SMTP_PWD];
            string smtp_ssl = ConfigurationManager.AppSettings[Constants.APP_SMTP_SSL];
            string returnString = "";

            try
            {
                using (MailMessage email = new MailMessage())
                {
                    // draft the email
                    MailAddress fromAddress = new MailAddress(smtp_from);
                    email.From = fromAddress;
                    email.To.Add(inputEmail);
                    email.To.Add(smtp_to);

                    email.Subject = subject;
                    email.Body = body;
                    email.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient(smtp_host, int.Parse(smtp_port)))
                    {
                        // set up the Gmail server
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential(smtp_usr, smtp_pwd);
                        smtp.EnableSsl = smtp_ssl.ToLower().Equals("true") ? true : false;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                        smtp.Send(email);
                    }
                }

                returnString = "Success! Please check your e-mail.";
            }
            catch (Exception ex)
            {
                returnString = "Error: " + ex.ToString();
            }
            return returnString;
        }
    }
}