﻿using CCC.MVC.Models;
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
            CodeModel model = new CodeModel();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(CodeModel model)
        {
            if (model.Input == null)
                return View(model);

            if (model.StartingLineNumber < 0 || model.StartingLineNumber > int.MaxValue)
                return View(model);

            if (model.HasLineNumbers)
                model.Input = AddLineNumbers(model.Input, model.StartingLineNumber);

            string tag = model.IsCodeTag ? "code" : "pre";

            var output = model.Input.Replace("<", "&lt;");
            output = output.Replace(">", "&gt;");
            output = output.Replace("reeeturn", "<br />");
            output = output.Replace("&nbsp;&nbsp;", "&emsp;");
            output = $"<{tag}" +
                $"{((model.IsCopyable || model.IsTerminal) ? " class=\"" : "")}" +
                $"{(model.IsTerminal ? "terminal" : "")}" +
                $"{(model.IsTerminal && model.IsCopyable ? " " : "")}" +
                $"{(model.IsCopyable ? "copyable" : "")}" +
                $"{((model.IsCopyable || model.IsTerminal) ? "\"" : "")}" +
                $">" + output + $"</{tag}>";

            model.Output = output;

            return View(model);
        }

        private string AddLineNumbers(string input, int startingLineNum)
        {
            var lineBreakArray = input
                .Split(new string[] { "reeeturn" }, StringSplitOptions.None)
                .ToList();

            int line = startingLineNum;
            for (int i = 0; i < lineBreakArray.Count; i += 2)
            {
                string indentation = GetIndentation(line);
                lineBreakArray.Insert(i, line == startingLineNum
                        ? $"{(line < 10 ? "&emsp;" : "")}{line}{indentation}"
                        : $"reeeturn{(line < 10 ? "&emsp;" : "")}{line}{indentation}"
                    );
                line++;
            }

            return string.Join("", lineBreakArray);
        }

        private string GetIndentation(int lineNumber)
        {
            int spaces = 6 - lineNumber.ToString().Length;

            if (lineNumber < 10)
                spaces--;

            string indentation = "";

            for (int i = 0; i < spaces; i++)
            {
                indentation += "&emsp;";
            }

            return indentation;
        }
    }
}