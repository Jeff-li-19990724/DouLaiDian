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
using PagedList;

namespace DouLaiDian前台.Controllers
{
    public class FoodLists1Controller : Controller
    {
        private MDF_DouLaiDian db = new MDF_DouLaiDian();
        public async Task<ActionResult> Index(int? page = 1)
        {
            int pageIndex = page ?? 1;
            int pageSize = 15;
            int totalCount = 0;
            String FoodName = null;
            ViewBag.fd = FoodName;
            var foodlists = await Getfoodlist(pageIndex, pageSize, ref totalCount, FoodName);
            var bookAsIPagedList = new StaticPagedList<FoodList>(foodlists, pageIndex, pageSize, totalCount);

            //var foodList = db.FoodList.Include(f => f.FoodType);
            return View(bookAsIPagedList);
        }
        [HttpPost]
        public async Task<ActionResult> Index(int? page, string FoodName)
        {
            int pageIndex = page ?? 1;
            int pageSize = 15;
            int totalCount = 0;
            ViewBag.fd = FoodName;
            var foodlists = await Getfoodlist(pageIndex, pageSize, ref totalCount, FoodName);
            //var A=foodlists.Where(i => i.FoodName.Contains(FoodName)).Include(f => f.FoodType)
            var bookAsIPagedList = new StaticPagedList<FoodList>(foodlists, pageIndex, pageSize, totalCount);

            //var foodList = db.FoodList.Include(f => f.FoodType);
            return View(bookAsIPagedList);
            // var foodList = db.FoodList.Where(i => i.FoodName.Contains(FoodName)).Include(f => f.FoodType);
            // return View(await foodList.ToListAsync());
        }
        public Task<List<FoodList>> Getfoodlist(int pageInsex, int PAgeSize, ref int totalCount, string FoodName)
        {
            return Getfoodlist(pageInsex, PAgeSize, totalCount, FoodName);
        }
        public async Task<List<FoodList>> Getfoodlist(int pageInsex, int PAgeSize, int totalCount, string FoodName)
        {
            IQueryable<FoodList> books;
            if (FoodName == null)
            {
                books = db.FoodList.Include(f => f.FoodType).OrderByDescending(f => f.FoodTypeID).Select(i => i).Skip((pageInsex - 1) * PAgeSize).Take(PAgeSize);
                // (from p in db.FoodList orderby p.FoodTypeID descending select p).Include(f => f.FoodType).Skip((pageInsex - 1) * PAgeSize).Take(PAgeSize);
            }
            else
            {
                books = db.FoodList.Where(i => i.FoodName.Contains(FoodName)).Include(f => f.FoodType).OrderByDescending(f => f.FoodTypeID).Select(i => i).Skip((pageInsex - 1) * PAgeSize).Take(PAgeSize);
                //(from p in db.FoodList orderby p.FoodTypeID descending select p).Where(i => i.FoodName.Contains(FoodName)).Include(f => f.FoodType).Skip((pageInsex - 1) * PAgeSize).Take(PAgeSize);
            }
            totalCount = db.FoodList.Count();
            return await books.ToListAsync();
        }

        // GET: FoodLists1
        //public async Task<ActionResult> Index()
        //{
        //    var foodList = db.FoodList.Include(f => f.FoodType);
        //    return View(await foodList.ToListAsync());
        //}

        // GET: FoodLists1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodList foodList = await db.FoodList.FindAsync(id);
            if (foodList == null)
            {
                return HttpNotFound();
            }
            return View(foodList);
        }

        // GET: FoodLists1/Create
        public ActionResult Create()
        {
            ViewBag.FoodTypeID = new SelectList(db.FoodType, "FoodTypeID", "FoodTypeName");
            return View();
        }

        // POST: FoodLists1/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FoodID,FoodName,Price,FoodTypeID,imageUrl,introduce")] FoodList foodList)
        {
            if (ModelState.IsValid)
            {
                db.FoodList.Add(foodList);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.FoodTypeID = new SelectList(db.FoodType, "FoodTypeID", "FoodTypeName", foodList.FoodTypeID);
            return View(foodList);
        }

        // GET: FoodLists1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodList foodList = await db.FoodList.FindAsync(id);
            if (foodList == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodTypeID = new SelectList(db.FoodType, "FoodTypeID", "FoodTypeName", foodList.FoodTypeID);
            return View(foodList);
        }

        // POST: FoodLists1/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FoodID,FoodName,Price,FoodTypeID,imageUrl,introduce")] FoodList foodList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodList).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.FoodTypeID = new SelectList(db.FoodType, "FoodTypeID", "FoodTypeName", foodList.FoodTypeID);
            return View(foodList);
        }

        // GET: FoodLists1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodList foodList = await db.FoodList.FindAsync(id);
            if (foodList == null)
            {
                return HttpNotFound();
            }
            return View(foodList);
        }

        // POST: FoodLists1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            FoodList foodList = await db.FoodList.FindAsync(id);
            db.FoodList.Remove(foodList);
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
