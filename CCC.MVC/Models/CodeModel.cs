using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace CCC.MVC.Models
{
    public class CodeModel
    {
        public string Input { get; set; }

        public string[] MoreWords { get; set; }

        public string Output { get; set; }

        [DisplayName("Include line numbers?")]
        public bool HasLineNumbers { get; set; }
    }
}