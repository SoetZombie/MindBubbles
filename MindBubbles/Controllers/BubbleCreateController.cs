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
            inputStringModel.InputString = "1 Loremdgf dfg dfg  ipsum | 2 Logdf gdf grem ipsum | 3 Lorem dfgdfgdfg ipsum | 4 Lorem idg fd fdg psum | 5 Loredfg df gfd m ipsum | 6 Lorem fg dfas g ipsum | 1.1 Dolfd gdf or sit | 1.2 Dolfd gdf or sit | 1.3 Dol dfg or sit | 1.4 Dolor sit | 1.5 Dolor sit | 1.6 Dolo dfg r sit | 2.1 Dolor sit | 2.2 Dolor sit | 2.3 Dolorolor siolor si sit | 2.4 Doloolor siolor sir sit | 2.5 Dolor sit | 2.6 Dolor sit | 3.1 Dol dfg ofdg df r sit | 3.2 Dolor sit | 3.3 Do dfg df lor sit | 3.4 Dolor sit | 3.5 Dolor sit | 3.6 Dololor siolor sior sit | 4.1 Dolor siolor siolor sit | 4.2 Doolor olor sisiolor silor sit | 4.3 Dol df gd or sit | 4.4 Dol df gor sit | 4.5 Dolor sit | 4.6 Dololor siolor siolor siolor sior sit | 5.1 Doloolor siolor sir sit | 5.2 Dolor sit | 5.3 Dololor siolor sior sit | 5.4 Dolor sit | 5.5 Dol dfg or sit | 	5.6 Dolor sit | 6.1 Dolor sit | 6.2 Dolor sit | 6.3 Dolor sit | 6.4 Dolor sit | 6.5 Dolor sit | 6.6 Dolor sit | 1.1.1 Batol kan | 1.1.2 Batol kan | 1.1.3 Batol kan | 1.1.4 Batol kan | 1.1.5 Batol kan | 1.1.6 Batol kan | 1.2.1 Batol kan | 1.2.2 Bat dfg dfg dol kan | 1.2.3 Batol kan | 1.2.4 Batol kan | 1.2.5 Batol kan | 1.2.6 Batol kan ";

            return View(logic.GenerateBubbles(inputStringModel));

        }

       


        public ActionResult InputSource()
        {
            return View();
        }


    }
}