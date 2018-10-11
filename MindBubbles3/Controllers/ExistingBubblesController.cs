using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MindBubbles3.Context;
using MindBubbles3.Models;

namespace MindBubbles3.Controllers
{
    public class ExistingBubblesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: ExistingBubbles
        [Authorize]
        public ActionResult Index()
        {
            return View(db.ExistingBubbles.ToList());
        }

        // GET: ExistingBubbles/Details/5


        // GET: ExistingBubbles/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExistingBubbles existingBubbles = db.ExistingBubbles.Find(id);
            if (existingBubbles == null)
            {
                return HttpNotFound();
            }
            return View(existingBubbles);
        }

        // POST: ExistingBubbles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExistingBubbles existingBubbles = db.ExistingBubbles.Find(id);
            db.ExistingBubbles.Remove(existingBubbles);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
