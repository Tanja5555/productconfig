using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Shop.Web.Models;
using TanLeonaShop.Domain.Models;

namespace Shop.Web.Controllers
{
    public class AdminOptionChoicesController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: AdminOptionChoices
        public ActionResult Index()
        {
            var dbOptionChoices = db.dbOptionChoices.Include(o => o.Option);
            return View(dbOptionChoices.ToList());
        }

        // GET: AdminOptionChoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionChoice optionChoice = db.dbOptionChoices.Find(id);
            if (optionChoice == null)
            {
                return HttpNotFound();
            }
            return View(optionChoice);
        }

        // GET: AdminOptionChoices/Create
        public ActionResult Create()
        {
            ViewBag.OptionId = new SelectList(db.dbOptions, "Id", "OptionName");
            return View();
        }

        // POST: AdminOptionChoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OptionChoiceName,OptionChoiceCode,OptionChoicePrice,OptionChoiceDeliveryDate,OptionId")] OptionChoice optionChoice)
        {
            if (ModelState.IsValid)
            {
                db.dbOptionChoices.Add(optionChoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OptionId = new SelectList(db.dbOptions, "Id", "OptionName", optionChoice.OptionId);
            return View(optionChoice);
        }

        // GET: AdminOptionChoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionChoice optionChoice = db.dbOptionChoices.Find(id);
            if (optionChoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.OptionId = new SelectList(db.dbOptions, "Id", "OptionName", optionChoice.OptionId);
            return View(optionChoice);
        }

        // POST: AdminOptionChoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OptionChoiceName,OptionChoiceCode,OptionChoicePrice,OptionChoiceDeliveryDate,OptionId")] OptionChoice optionChoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(optionChoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OptionId = new SelectList(db.dbOptions, "Id", "OptionName", optionChoice.OptionId);
            return View(optionChoice);
        }

        // GET: AdminOptionChoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OptionChoice optionChoice = db.dbOptionChoices.Find(id);
            if (optionChoice == null)
            {
                return HttpNotFound();
            }
            return View(optionChoice);
        }

        // POST: AdminOptionChoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OptionChoice optionChoice = db.dbOptionChoices.Find(id);
            db.dbOptionChoices.Remove(optionChoice);
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
