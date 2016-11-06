using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Shop.Web.Models;
using TanLeonaShop.Domain.Models;

namespace Shop.Web.Controllers
{
    public class AdminOptionsController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: AdminOptions
        public ActionResult Index()
        {
            var dbOptions = db.dbOptions.Include(o => o.Product);
            return View(dbOptions.ToList());
        }

        // GET: AdminOptions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Option option = db.dbOptions.Find(id);
            if (option == null)
            {
                return HttpNotFound();
            }
            return View(option);
        }

        // GET: AdminOptions/Create
        public ActionResult Create()
        {
            ViewBag.ProductId = new SelectList(db.dbProducts, "Id", "ProductName");
            return View();
        }

        // POST: AdminOptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OptionName,ProductId")] Option option)
        {
            if (ModelState.IsValid)
            {
                db.dbOptions.Add(option);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductId = new SelectList(db.dbProducts, "Id", "ProductName", option.ProductId);
            return View(option);
        }

        // GET: AdminOptions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Option option = db.dbOptions.Find(id);
            if (option == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductId = new SelectList(db.dbProducts, "Id", "ProductName", option.ProductId);
            return View(option);
        }

        // POST: AdminOptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OptionName,ProductId")] Option option)
        {
            if (ModelState.IsValid)
            {
                db.Entry(option).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductId = new SelectList(db.dbProducts, "Id", "ProductName", option.ProductId);
            return View(option);
        }

        // GET: AdminOptions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Option option = db.dbOptions.Find(id);
            if (option == null)
            {
                return HttpNotFound();
            }
            return View(option);
        }

        // POST: AdminOptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Option option = db.dbOptions.Find(id);
            db.dbOptions.Remove(option);
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
