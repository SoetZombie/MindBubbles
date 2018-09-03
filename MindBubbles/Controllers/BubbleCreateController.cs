namespace MindBubbles.Controllers
{
    using MindBubbles.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class BubbleCreateController : Controller
    {
        private const string BubbleString = "bublina1*bublina2*bublina3*bublina4";

        public string BaseString;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BubbleCreate(BubbleCreateModel bubbleCreateModel)
        {
            
            return View(CreateBubble(bubbleCreateModel));

        }

        public BubbleCreateModel CreateBubble(BubbleCreateModel bubbleCreateModel)
        {
            if(bubbleCreateModel.BaseString == null)
            {
                bubbleCreateModel.BaseString = "Please enter at least one character into bubble";
            }
            string[] converted;
            converted = bubbleCreateModel.BaseString.Split('*');
            bubbleCreateModel.BaseStringList = converted;
            return bubbleCreateModel;
        }


        public ActionResult InputSource()
        {
            return View();
        }

      
    }
}