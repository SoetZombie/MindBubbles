using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MindBubbles3.Models
{
    public class BubblesList
    {

        public List<BubbleCreateModel> List { get; set; }

        public List<BubbleCreateModel>[] ListArray { get; set; }

        public int TotalCellsNumber { get; set; }

        public int DbId { get; set; }
    }
}