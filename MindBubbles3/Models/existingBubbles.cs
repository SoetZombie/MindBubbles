using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MindBubbles3.Models
{
    [Table("SavedBubblesDB")]
    public class ExistingBubbles
    {
        [Key]
        public int BubbleId { get; set; }
        public string ExistingImage { get; set; }
        public string ExistingInputString { get; set; }
        

    }
}