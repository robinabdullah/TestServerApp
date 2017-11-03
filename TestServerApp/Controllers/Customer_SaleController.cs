using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TestServerApp;

namespace TestServerApp.Controllers
{
    public class Customer_SaleController : Controller
    {
        private POSNew12Entities db = new POSNew12Entities();

        // GET: Customer_Sale
        public ActionResult Index()
        {
            var customer_Sale = db.Customer_Sale.Include(c => c.Product);
            return View(customer_Sale.ToList());
        }

        // GET: Customer_Sale/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Sale customer_Sale = db.Customer_Sale.Find(id);
            if (customer_Sale == null)
            {
                return HttpNotFound();
            }
            return View(customer_Sale);
        }

        // GET: Customer_Sale/Create
        public ActionResult Create()
        {
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Type");
            return View();
        }

        // POST: Customer_Sale/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Invoice_ID,Product_ID,Quantity,Unit_Price,Sold_Price,Sale_Price_was,Sold_By")] Customer_Sale customer_Sale)
        {
            if (ModelState.IsValid)
            {
                db.Customer_Sale.Add(customer_Sale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Type", customer_Sale.Product_ID);
            return View(customer_Sale);
        }

        // GET: Customer_Sale/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Sale customer_Sale = db.Customer_Sale.Find(id);
            if (customer_Sale == null)
            {
                return HttpNotFound();
            }
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Type", customer_Sale.Product_ID);
            return View(customer_Sale);
        }

        // POST: Customer_Sale/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Invoice_ID,Product_ID,Quantity,Unit_Price,Sold_Price,Sale_Price_was,Sold_By")] Customer_Sale customer_Sale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Sale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Product_ID = new SelectList(db.Products, "ID", "Type", customer_Sale.Product_ID);
            return View(customer_Sale);
        }

        // GET: Customer_Sale/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Sale customer_Sale = db.Customer_Sale.Find(id);
            if (customer_Sale == null)
            {
                return HttpNotFound();
            }
            return View(customer_Sale);
        }

        // POST: Customer_Sale/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_Sale customer_Sale = db.Customer_Sale.Find(id);
            db.Customer_Sale.Remove(customer_Sale);
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
