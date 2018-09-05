using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MindBubbles.Models
{
    public class BubblesList
    {
        public List<BubbleCreateModel> AllBubbleData { get; set; }

        public List<BubbleCreateModel> List1{ get; set; }

        public List<BubbleCreateModel> List2 { get; set; }

        public List<BubbleCreateModel> List3 { get; set; }

        public List<BubbleCreateModel> List4 { get; set; }

        public List<BubbleCreateModel> List5 { get; set; }

        public List<BubbleCreateModel> List6 { get; set; }

        public List<List<BubbleCreateModel>> AllLists { get; set; }
    }
}