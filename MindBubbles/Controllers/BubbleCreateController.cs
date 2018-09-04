namespace MindBubbles.Controllers
{
    using MindBubbles.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;

    public class BubbleCreateController : Controller
    {
        private const string BubbleString = "bublina1*bublina2*bublina3*bublina4";
        private List<BubbleCreateModel> bubbleRawList;
        public string BaseString;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BubbleCreate(InputStringModel inputStringModel)
        {
            inputStringModel.InputString = "1.  Rozvoj dopravy a dopravní infrastruktury obce | 2. Životní prostředí a území | 3. Územní rozvoj obce | 1.1 Zlepšit podmínky | 2.1 Zlepšit stav | 3.1 Zlepšit psa | 1.2 Zlepsit mozek | 2.2 Zlepsit karla 	 3.2 Zlepsit kone | 1.3 Dobudovat | 2.3 Mozek | 3.3 nevim uz";
            
            return View(CreateBubbles(inputStringModel));

        }

        public BubblesList CreateBubbles(InputStringModel inputStringModel)
        {
            bubbleRawList = new List<BubbleCreateModel>();
            string[] splittedArray = inputStringModel.InputString.Split('|');
            var regex = new Regex(@"\d+(\.\d+)*");
            foreach (var item in splittedArray)
            {
                string rawText;
                string transformedText;

                rawText = item;
                transformedText = new String(rawText.Where(c => c != '.' && (c < '0' || c > '9')).ToArray());

                var number = regex.Matches(item)
                                  .Cast<Match>()
                                  .Select(match => match.Value)
                                  .First();
                var bubbleToList = new BubbleCreateModel()
                {
                    PlainTextInCell = transformedText,
                    OrderNumber = number

                };

                bubbleRawList.Add(bubbleToList);

            }
            List<BubbleCreateModel> orderedList = new List<BubbleCreateModel>();
            orderedList = bubbleRawList.OrderBy(p => p.OrderNumber).ToList();

            var listToReturn = new BubblesList
            {
                AllBubbleData = orderedList
        
            };

            
            return listToReturn;
         
        }


        public ActionResult InputSource()
        {
            return View();
        }

      
    }
}