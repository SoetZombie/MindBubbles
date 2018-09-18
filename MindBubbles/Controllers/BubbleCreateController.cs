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
        public int cellsNumber;
        private  Logic logic = new Logic(); 

        
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BubbleCreate(InputStringModel inputStringModel)
        {
            inputStringModel.InputString = "1.  Rozvoj dopravy a dopravní infrastruktury obce | 2. Životní prostředí a území | 3. Územní rozvoj obce | 4.7 Zlepšit podsad mínkysv rasdsadsasdas sda dasa dasdsa as asd asw amci rozvoje oblastního zatizeasdsa ni a take odpadu | 2.1 Zlepšit stav | 3.1 Zlepšit psa | 11.2 vava| 1.1.2 Zlepsd sds d sd sdsdsd sdsd sdsdsd sdsit mozesadk | 2.2 Zlepsit karla | 3.2 Zlepsit kone | 1.3 Dobudasd aovat | 2.3 Mozek a ruka jdou na nakup myslim si ze maji malo kebabu a tak se bojim aby jim nebylo zle | 3.3 nevisaaam uz| 4.1 Zlepšit stav | 2.4 Zlepšit psa | 4.2 Zlepsit mozek | 5.2 Zlepsit karla | 4.3 Dobudovat | 5.3 Mozek a ruka jdou na nakup myslim si ze maji malo kebabu a tak se bojim aby jim nebylo zle | 4 Zlepšit stav | 5 Zlepšit psa | 5.1 Zlepšit psa | 6.1 Zlepšit psa | 6 Zlepšit psa | 4.6 Zlepšit psa | 4.4 Zlepšit psa | 4.5 Zlepšit psa | 11 naskaltam | 11.1 A jed | 1.1 bababa";

            return View(logic.CreateBubbles(inputStringModel));

        }

       


        public ActionResult InputSource()
        {
            return View();
        }


    }
}