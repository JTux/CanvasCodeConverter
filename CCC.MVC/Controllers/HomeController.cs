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

            if (model.HasLineNumbers)
                model.Input = AddLineNumbers(model.Input);

            var output = model.Input.Replace("<", "&lt;");
            output = output.Replace(">", "&gt;");
            output = output.Replace("reeeturn", "<br />");
            output = output.Replace("&nbsp;&nbsp;", "&emsp;");
            output = "<pre><code>" + output + "</code></pre>";

            model.Output = output;

            return View(model);
        }

        private string AddLineNumbers(string input)
        {
            var lineBreakArray = input
                .Split(new string[] { "reeeturn" }, StringSplitOptions.None)
                .ToList();

            int line = 1;
            for (int i = 0; i < lineBreakArray.Count; i += 2)
            {
                string indentation = GetIndentation(line);
                lineBreakArray.Insert(i, line == 1 ? $"{line}{indentation}" : $"reeeturn{line}{indentation}");
                line++;
            }

            return string.Join("", lineBreakArray);
        }

        private string GetIndentation(int lineNumber)
        {
            int spaces = 6 - lineNumber.ToString().Length;
            string indentation = "";

            for (int i = 0; i < spaces; i++)
            {
                indentation += "&emsp;";
            }

            return indentation;
        }
    }
}