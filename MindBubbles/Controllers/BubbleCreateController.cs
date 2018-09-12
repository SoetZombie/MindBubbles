namespace MindBubbles.Controllers
{
    using MindBubbles.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;
    using MindBubbles.Logic;

    public class BubbleCreateController : Controller
    {
        private const string BubbleString = "bublina1*bublina2*bublina3*bublina4";
        private List<BubbleCreateModel> bubbleRawList;
        public int cellsNumber;
        private  Logic logic = new Logic(); 

        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BubbleCreate(InputStringModel inputStringModel)
        {
            inputStringModel.InputString = "1.  Rozvoj dopravy a dopravní infrastruktury obce | 2. Životní prostředí a území | 3. Územní rozvoj obce | 1.1 Zlepšit podmínkysv ramci rozvoje oblastního zatizeni a take odpadu | 2.1 Zlepšit stav | 3.1 Zlepšit psa | 1.2 Zlepsit mozek | 2.2 Zlepsit karla | 3.2 Zlepsit kone | 1.3 Dobudovat | 2.3 Mozek a ruka jdou na nakup myslim si ze maji malo kebabu a tak se bojim aby jim nebylo zle | 3.3 nevim uz| 4.1 Zlepšit stav | 5.1 Zlepšit psa | 4.2 Zlepsit mozek | 5.2 Zlepsit karla | 4.3 Dobudovat | 5.3 Mozek a ruka jdou na nakup myslim si ze maji malo kebabu a tak se bojim aby jim nebylo zle | 4 Zlepšit stav | 5 Zlepšit psa  ";

            return View(logic.CreateBubbles(inputStringModel));

        }

       


        public ActionResult InputSource()
        {
            return View();
        }


    }
}