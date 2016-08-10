#region [ References ]
using System;
using System.Web;
using System.Linq;
using System.Web.Mvc;
using System.Threading;
using System.Collections.Generic;

using DevLandCR.WebProjects.WebSite.Models;
using DevLandCR.WebProjects.WebSite.Infrastructure;
#endregion

namespace DevLandCR.WebProjects.WebSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.IsHome = true;
            return View();
        }

        public ActionResult Services()
        {
            ViewBag.IsHome = false;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.IsHome = false;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.IsHome = false;
            return View();
        }

        [HttpPost]
        public JsonResult SendEmail(EmailModel emailModel)
        {
            var response = string.Empty;
            var fileContents = System.IO.File.ReadAllText(Server.MapPath(Constants.EMAIL_TEMPLATE_FILE));
            if (!string.IsNullOrEmpty(fileContents))
            {
                fileContents = fileContents.Replace("##NAME##", emailModel.name);
                fileContents = fileContents.Replace("##EMAIL##", emailModel.email);
                fileContents = fileContents.Replace("##PHONE##", emailModel.phone);
                fileContents = fileContents.Replace("##MESSAGE##", emailModel.message);

                response = EmailService.SendEmail(emailModel.email, "Contact us Information - DevLandCR", fileContents);
            }

            return Json(response, "json");
        }
    }
}