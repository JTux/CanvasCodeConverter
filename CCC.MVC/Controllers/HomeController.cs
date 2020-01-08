using CCC.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CCC.MVC.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(CodeModel model)
        {
            if (model.Input == null)
                return View(model);

            var output = model.Input.Replace("<", "&lt;");
            output = output.Replace(">", "&gt;");
            output = output.Replace("reeeturn", "<br />");
            output = output.Replace("&nbsp;&nbsp;", "&emsp;");
            output = "<pre><code>" + output + "</code></pre>";

            model.Output = output;

            return View(model);
        }
    }
}