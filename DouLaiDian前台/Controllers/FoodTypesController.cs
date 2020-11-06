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
    public class FoodTypesController : Controller
    {
        private MDF_DouLaiDian db = new MDF_DouLaiDian();

        // GET: FoodTypes
        public async Task<ActionResult> Index()
        {
            return View(await db.FoodType.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Index(string FoodTypeName)
        {
            if (String.IsNullOrEmpty(FoodTypeName))
                return View(await db.FoodType.ToListAsync());
            else
                return View(await db.FoodType.Where(i => i.FoodTypeName.Contains(FoodTypeName)).ToListAsync());
        }

        // GET: FoodTypes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodType foodType = await db.FoodType.FindAsync(id);
            if (foodType == null)
            {
                return HttpNotFound();
            }
            return View(foodType);
        }

        // GET: FoodTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodTypes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FoodTypeID,FoodTypeName,describe")] FoodType foodType)
        {
            if (ModelState.IsValid)
            {
                db.FoodType.Add(foodType);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(foodType);
        }

        // GET: FoodTypes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodType foodType = await db.FoodType.FindAsync(id);
            if (foodType == null)
            {
                return HttpNotFound();
            }
            return View(foodType);
        }

        // POST: FoodTypes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FoodTypeID,FoodTypeName,describe")] FoodType foodType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodType).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(foodType);
        }

        // GET: FoodTypes/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FoodType foodType = await db.FoodType.FindAsync(id);
        //    if (foodType == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(foodType);
        //}

        //// POST: FoodTypes/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            FoodType foodType = await db.FoodType.FindAsync(id);
            db.FoodType.Remove(foodType);
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
