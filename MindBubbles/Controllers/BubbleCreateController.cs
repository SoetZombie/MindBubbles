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
            inputStringModel.InputString = "1.  Rozvoj dopravy a dopravní infrastruktury obce | 2. Životní prostředí a území | 3. Územní rozvoj obce | 1.1 Zlepšit podmínkysv ramci rozvoje oblastního zatizeni a take odpadu | 2.1 Zlepšit stav | 3.1 Zlepšit psa | 1.2 Zlepsit mozek | 2.2 Zlepsit karla | 3.2 Zlepsit kone | 1.3 Dobudovat | 2.3 Mozek a ruka jdou na nakup myslim si ze maji malo kebabu a tak se bojim aby jim nebylo zle | 3.3 nevim uz";
            
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
                    OrderNumber = " "+number

                };

                bubbleRawList.Add(bubbleToList);

            }
            List<BubbleCreateModel> orderedList = new List<BubbleCreateModel>();
            orderedList = bubbleRawList.OrderBy(p => p.OrderNumber).ToList();

            var listToReturn = new BubblesList
            {
                AllBubbleData = orderedList
        
            };

            
            return GenerateLists(listToReturn);
         
        }

        public BubblesList GenerateLists (BubblesList bubblesList )
        {
            var regex1 = new Regex(@" 1+(\.\d+)+");
            var regex2 = new Regex(@" 2+(\.\d+)+");
            var regex3 = new Regex(@" 3+(\.\d+)+");
            var regex4 = new Regex(@" 4+(\.\d+)+");
            var regex5 = new Regex(@" 5+(\.\d+)+");
            var regex6 = new Regex(@" 6+(\.\d+)+");

            bubblesList.AllLists = new List<List<BubbleCreateModel>>();
            bubblesList.List1 = bubblesList.AllBubbleData.Where(a => regex1.IsMatch(a.OrderNumber) || a.OrderNumber.Equals(" 1")).ToList();
            bubblesList.List2 = bubblesList.AllBubbleData.Where(a => regex2.IsMatch(a.OrderNumber) || a.OrderNumber.Equals(" 2")).ToList();
            bubblesList.List3 = bubblesList.AllBubbleData.Where(a => regex3.IsMatch(a.OrderNumber) || a.OrderNumber.Equals(" 3")).ToList();
            
            //bubblesList.List4 = bubblesList.AllBubbleData.Where(a => regex4.IsMatch(a.OrderNumber) || a.OrderNumber.Equals(" 4")).ToList();
           // bubblesList.List5 = bubblesList.AllBubbleData.Where(a => regex5.IsMatch(a.OrderNumber) || a.OrderNumber.Equals(" 5")).ToList();
            //bubblesList.List6 = bubblesList.AllBubbleData.Where(a => regex6.IsMatch(a.OrderNumber) || a.OrderNumber.Equals(" 6")).ToList();

            bubblesList.AllLists.Add(bubblesList.List1);
            bubblesList.AllLists.Add(bubblesList.List2);
            bubblesList.AllLists.Add(bubblesList.List3);
         
            return bubblesList;

        }


        public ActionResult InputSource()
        {
            return View();
        }

      
    }
}