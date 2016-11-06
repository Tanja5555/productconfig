using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Shop.Web.Models;
using TanLeonaShop.Domain.Models;

namespace Shop.Web.Controllers
{
    public class AdminOrdersController : Controller
    {
        private ShopContext db = new ShopContext();

        // GET: AdminOrders
        public ActionResult Index()
        {
            var dbOrders = db.dbOrders.Include(o => o.AppUser).Include(o => o.Product);
            return View(dbOrders.ToList());
        }

        // GET: AdminOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.dbOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: AdminOrders/Create
        public ActionResult Create()
        {
            ViewBag.AppUserId = new SelectList(db.Users, "Id", "Firstname");
            ViewBag.ProductId = new SelectList(db.dbProducts, "Id", "ProductName");
            return View();
        }

        // POST: AdminOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderCode,TotalPrice,OrderDate,Delivered,DeliveryDate,AppUserId,ProductId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.dbOrders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AppUserId = new SelectList(db.Users, "Id", "Firstname", order.AppUserId);
            ViewBag.ProductId = new SelectList(db.dbProducts, "Id", "ProductName", order.ProductId);
            return View(order);
        }

        // GET: AdminOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.dbOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.AppUserId = new SelectList(db.Users, "Id", "Firstname", order.AppUserId);
            ViewBag.ProductId = new SelectList(db.dbProducts, "Id", "ProductName", order.ProductId);
            return View(order);
        }

        // POST: AdminOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderCode,TotalPrice,OrderDate,Delivered,DeliveryDate,AppUserId,ProductId")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AppUserId = new SelectList(db.Users, "Id", "Firstname", order.AppUserId);
            ViewBag.ProductId = new SelectList(db.dbProducts, "Id", "ProductName", order.ProductId);
            return View(order);
        }

        // GET: AdminOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.dbOrders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: AdminOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.dbOrders.Find(id);
            db.dbOrders.Remove(order);
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
