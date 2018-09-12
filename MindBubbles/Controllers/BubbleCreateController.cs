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
        public int cellsNumber;
        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BubbleCreate(InputStringModel inputStringModel)
        {
            inputStringModel.InputString = "1.  Rozvoj dopravy a dopravní infrastruktury obce | 2. Životní prostředí a území | 3. Územní rozvoj obce | 1.1 Zlepšit podmínkysv ramci rozvoje oblastního zatizeni a take odpadu | 2.1 Zlepšit stav | 3.1 Zlepšit psa | 1.2 Zlepsit mozek | 2.2 Zlepsit karla | 3.2 Zlepsit kone | 1.3 Dobudovat | 2.3 Mozek a ruka jdou na nakup myslim si ze maji malo kebabu a tak se bojim aby jim nebylo zle | 3.3 nevim uz| 4.1 Zlepšit stav | 5.1 Zlepšit psa | 4.2 Zlepsit mozek | 5.2 Zlepsit karla | 4.3 Dobudovat | 5.3 Mozek a ruka jdou na nakup myslim si ze maji malo kebabu a tak se bojim aby jim nebylo zle | 4 Zlepšit stav | 5 Zlepšit psa  ";

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
                    OrderNumber = " " + number


                };

                bubbleRawList.Add(bubbleToList);

            }
            List<BubbleCreateModel> orderedList = new List<BubbleCreateModel>();
            orderedList = bubbleRawList.OrderBy(p => p.OrderNumber).ToList();
            var highestNumber = orderedList.Last().OrderNumber;

            cellsNumber = Int32.Parse(Regex.Match(highestNumber, @" \d+").ToString());

            return GenerateLists(orderedList);

        }

        public BubblesList GenerateLists(List<BubbleCreateModel> bubbleCreateModels)
        {

            var filterRegex = "";
            List<BubbleCreateModel>[] listsArray = new List<BubbleCreateModel>[cellsNumber];
            for (int i = 0; i < cellsNumber; i++)
            {
                filterRegex = i.ToString();
                var regexDotPattern = new Regex($@" {i+1}(\.\d+)*");

                listsArray[i] = bubbleCreateModels.Where(a => regexDotPattern.IsMatch(a.OrderNumber)).ToList();
            }


            return new BubblesList
            {
                ListArray = listsArray,
                TotalCellsNumber = cellsNumber
            };

        }


        public ActionResult InputSource()
        {
            return View();
        }


    }
}