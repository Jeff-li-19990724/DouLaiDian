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
    public class OrderListsController : Controller
    {
        private MDF_DouLaiDian db = new MDF_DouLaiDian();

        // GET: OrderLists
        public async Task<ActionResult> Index(int id)
        {
           // int id = 1;
            var orderList = db.OrderList.Include(o => o.order).Where(i=>i.OrderID==id);
            return View(await orderList.ToListAsync());
        }

        // GET: OrderLists/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderList orderList = await db.OrderList.FindAsync(id);
            if (orderList == null)
            {
                return HttpNotFound();
            }
            return View(orderList);
        }

        // GET: OrderLists/Create
        public ActionResult Create()
        {
            ViewBag.OrderID = new SelectList(db.Order, "OrderID", "phone");
            return View();
        }

        // POST: OrderLists/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "OrID,OrderID,foodname,price,num")] OrderList orderList)
        {
            if (ModelState.IsValid)
            {
                db.OrderList.Add(orderList);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.OrderID = new SelectList(db.Order, "OrderID", "phone", orderList.OrderID);
            return View(orderList);
        }

        // GET: OrderLists/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderList orderList = await db.OrderList.FindAsync(id);
            if (orderList == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderID = new SelectList(db.Order, "OrderID", "phone", orderList.OrderID);
            return View(orderList);
        }

        // POST: OrderLists/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "OrID,OrderID,foodname,price,num")] OrderList orderList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderList).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.OrderID = new SelectList(db.Order, "OrderID", "phone", orderList.OrderID);
            return View(orderList);
        }

        // GET: OrderLists/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderList orderList = await db.OrderList.FindAsync(id);
            if (orderList == null)
            {
                return HttpNotFound();
            }
            return View(orderList);
        }

        // POST: OrderLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            OrderList orderList = await db.OrderList.FindAsync(id);
            db.OrderList.Remove(orderList);
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
