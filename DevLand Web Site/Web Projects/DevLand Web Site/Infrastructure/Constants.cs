using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevLandCR.WebProjects.WebSite.Infrastructure
{
    public class Constants
    {
        public const string APP_SMTP_HOST = "smtp:host";
        public const string APP_SMTP_PORT = "smtp:port";
        public const string APP_SMTP_FROM = "smtp:from";
        public const string APP_SMTP_TO = "smtp:to";
        public const string APP_SMTP_USR = "smtp:username";
        public const string APP_SMTP_PWD = "smtp:password";
        public const string APP_SMTP_SSL = "smtp:isssl";

        public const string EMAIL_TEMPLATE_FILE = @"~/App_Data/EmailTemplate.html";
    }
}