using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MindBubbles.Models
{

    public class BubbleCreateModel
    {
        [Required]
        public string BaseString { get; set; }
        public string[] BaseStringList { get; set; }
        public string OrderNumber { get; set; }
        public string PlainTextInCell { get; set; }
        public string ParametersAfterText { get; set; }


    }
}