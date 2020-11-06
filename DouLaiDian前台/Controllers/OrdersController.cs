using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DouLaiDian.Models;
using QT;

namespace DouLaiDian前台.Controllers
{
    public class OrdersController : Controller
    {
        private MDF_DouLaiDian db = new MDF_DouLaiDian();

        // GET: Orders
        public async Task<ActionResult> Index()
        {
            return View(await db.Order.Where(i=>i.ISOut==false).OrderBy(i=>i.Date).ToListAsync());
        }
        public async Task<ActionResult> Index2()
        {
            return View(await db.Order.Where(i=>i.ISOut==true).OrderByDescending(i=>i.Date).ToListAsync());
        }
        public async Task<ActionResult> FK(int? id)
        {
            var Or = await db.Order.FindAsync(id);
            Or.ISOut = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> ZH(int? id)
        {
            var Or = await db.Order.FindAsync(id);
            Or.ISOut = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Order.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OrderID,phone,TotalParse,Date,ISOut")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Order.Add(order);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Order.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OrderID,phone,TotalParse,Date,ISOut")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = await db.Order.FindAsync(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Order order = await db.Order.FindAsync(id);
            db.Order.Remove(order);
            await db.SaveChangesAsync();
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
