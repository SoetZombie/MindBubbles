using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MindBubbles3.Models
{
    public class InputStringModel
    {
        [Required]
        public string InputString { get; set;}

        public bool ThirdLevel { get; set; }
    }
}