using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CCC.MVC.Models
{
    public class CodeModel
    {
        public string Input { get; set; }

        public string[] MoreWords { get; set; }

        public string Output { get; set; }

        public bool HasLineNumbers { get; set; }
        public bool IsTerminal { get; set; }
        public bool IsCopyable { get; set; }

        [Display(Name="Start At Line:")]
        public int StartingLineNumber { get; set; } = 1;
    }
}