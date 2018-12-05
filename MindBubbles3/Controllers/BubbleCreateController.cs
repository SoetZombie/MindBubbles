namespace MindBubbles3.Controllers
{
    using MindBubbles3.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Mvc;
    using MindBubbles3.Logic;
    using MindBubbles3.Service.Interfaces;
    using System.Text;
    using System.IO;

    public class BubbleCreateController : Controller
    {
        private Logic logic = new Logic();
        private readonly IBubbleService bubbleService;


        public BubbleCreateController(IBubbleService bubbleService)
        {
            this.bubbleService = bubbleService;
        }


        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult BubbleCreate(InputStringModel inputStringModel)
        {
            if (ModelState.IsValid)
            {

                return View(bubbleService.GenerateBubbles(inputStringModel));
            }

            else
            {
                TempData["ErrorMessage"] = "Please enter some text";
                return RedirectToAction("InputSource");
            }

        }
        [AllowAnonymous]
        public FileResult DownloadXLSM()
        {
            return File(new FileStream(Server.MapPath("~/Content/Sample.xlsm"), FileMode.Open), "application/vnd.ms-excel.sheet.macroEnabled.12", "Sample.xlsm");

        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult PostImage(int id, string img)
        {
            bubbleService.AddImageToExistingBubble(id, img);
            return View();
        }


        [AllowAnonymous]
        public ActionResult InputSource()
        {
            if (ModelState.IsValid)
            {

                return View();
            }

            else
            {
                return View();

            }
        }


    }
}