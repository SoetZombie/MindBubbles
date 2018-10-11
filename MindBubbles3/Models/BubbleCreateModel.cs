using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MindBubbles3.Models
{

    public class BubbleCreateModel
    {
        [Required]
        public string BaseString { get; set; }
        public string[] BaseStringList { get; set; }
        public string OrderNumber { get; set; }
        public string PlainTextInCell { get; set; }
        public string ParametersAfterText { get; set; }
        public List<BubbleCreateModel> ThirdLevelList { get; set; }


    }
}