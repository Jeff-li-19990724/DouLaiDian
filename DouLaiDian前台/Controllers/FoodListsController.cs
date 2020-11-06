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
using System.IO;
using PagedList;

namespace DouLaiDian前台.Controllers
{
    public class FoodListsController : Controller
    {
        private MDF_DouLaiDian db = new MDF_DouLaiDian();

        // GET: FoodLists
        public async Task<ActionResult> Index()
        {
            //int pageIndex = page ?? 1;
            //int pageSize = 15;
            //int totalCount = 0;
            //String FoodName = null;
            //ViewBag.fd = FoodName;
            //var foodlists =await Getfoodlist(pageIndex, pageSize, ref totalCount,FoodName);
            //var bookAsIPagedList = new StaticPagedList<FoodList>(foodlists, pageIndex, pageSize, totalCount);
            ViewBag.FoodTypeID = new SelectList(db.FoodType, "FoodTypeID", "FoodTypeName");
            var foodList = db.FoodList.Include(f => f.FoodType);
            return View(await foodList.ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult> Index(string FoodName,int FoodTypeID)
        {
            IQueryable<FoodList> foodList= db.FoodList.Include(f => f.FoodType); 
            ViewBag.FoodTypeID = new SelectList(db.FoodType, "FoodTypeID", "FoodTypeName");
            if(!String.IsNullOrEmpty(FoodName)&& FoodTypeID != 0)
            {
                foodList = db.FoodList.Where(i => i.FoodName.Contains(FoodName)&&i.FoodTypeID.Equals(FoodTypeID));
                return View(await foodList.Include(f => f.FoodType).ToListAsync());
            }
            if (!String.IsNullOrEmpty(FoodName))
            {
                foodList = db.FoodList.Where(i => i.FoodName.Contains(FoodName));
                return View(await foodList.Include(f => f.FoodType).ToListAsync());
            }
            if(FoodTypeID!=0)
            {
                foodList = db.FoodList.Where(i => i.FoodTypeID.Equals(FoodTypeID));
                return View(await foodList.Include(f => f.FoodType).ToListAsync());
            }
            //int pageIndex = page ?? 1;
            //int pageSize = 15;
            //int totalCount = 0;
            //ViewBag.fd = FoodName;
            //var foodlists = await Getfoodlist(pageIndex, pageSize, ref totalCount,FoodName);
            ////var A=foodlists.Where(i => i.FoodName.Contains(FoodName)).Include(f => f.FoodType)
            //var bookAsIPagedList = new StaticPagedList<FoodList>(foodlists, pageIndex, pageSize, totalCount);

            ////var foodList = db.FoodList.Include(f => f.FoodType);
            //return View(bookAsIPagedList);
            return View(await foodList.ToListAsync());
        }
        public  Task<List<FoodList>> Getfoodlist(int pageInsex, int PAgeSize,ref int totalCount,string FoodName)
        {
            return Getfoodlist( pageInsex, PAgeSize, totalCount,FoodName);
        }
        public async Task<List<FoodList>> Getfoodlist(int pageInsex, int PAgeSize,int totalCount,string FoodName)
        {
            IQueryable<FoodList> books;
            if (FoodName==null)
            {
                 books = db.FoodList.Include(f => f.FoodType).OrderByDescending(f=>f.FoodTypeID).Select(i=>i).Skip((pageInsex - 1) * PAgeSize).Take(PAgeSize);
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

        // GET: FoodLists/Details/5
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

        // GET: FoodLists/Create
        public ActionResult Create()
        {
            ViewBag.FoodTypeID = new SelectList(db.FoodType, "FoodTypeID", "FoodTypeName");
            return View();
        }

        // POST: FoodLists/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "FoodID,FoodName,Price,FoodTypeID,introduce")] FoodList foodList, HttpPostedFileBase imageUrl)
        {

            ViewBag.FoodTypeID = new SelectList(db.FoodType, "FoodTypeID", "FoodTypeName", foodList.FoodTypeID);
            var Y = db.FoodList.Find(foodList.FoodID);
            if (Y != null)
            {
                ViewBag.FoodID = "该编号食品已存在";
                return View(foodList);
            }
            if (Request.Files.Count == 0)
            {
                //判断数量
                return Content("<script>alert('上传失败');</script>");
            }
            else
            {
                var file1 = Request.Files[0];
                if (file1.ContentLength == 0)
                {
                    //文件大小大（以字节为单位）为0时，做一些操作
                    return Content("<script>alert('上传失败');</script>");
                }
                else
                {
                    if (file1.ContentLength > 4194304)
                    {
                        return Content("<script>alert('文件过大，不可大于4M');</script>");
                    }
                    File(imageUrl);
                    // return View();
                }
            }
            foodList.imageUrl = "https://localhost:44316/wwwroot/" + DateTime.Now.ToString("yyyy-MM-dd") + imageUrl.FileName;
            db.FoodList.Add(foodList);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");



            // return View(foodList);
        }
        private void File(HttpPostedFileBase fileone)
        {
            var fileName = DateTime.Now.ToString("yyyy-MM-dd") + fileone.FileName;
            var filePath = Server.MapPath(string.Format("~/wwwroot/"));
            if (!Directory.Exists(filePath))//判断文件夹是否存在 
            {
                Directory.CreateDirectory(filePath);//不存在则创建文件夹 
            }
            fileone.SaveAs(Path.Combine(filePath, fileName));
        }

        // GET: FoodLists/Edit/5
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

        // POST: FoodLists/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "FoodID,FoodName,Price,FoodTypeID,introduce")] FoodList foodList, HttpPostedFileBase imageUrl)
        {
            //  db.FoodList.Add(foodList);
            //await db.SaveChangesAsync();
            // return RedirectToAction("Index");
            //if (db.FoodList.Find(foodList.FoodID) != foodList)
            //{
            //    ViewBag.FoodTypeID = new SelectList(db.FoodType, "FoodTypeID", "FoodTypeName", foodList.FoodTypeID);
            //    ViewBag.FoodID = "该编号食品已存在";
            //    return View(foodList);
            //}
            // if(imageUrl.C)
            if(imageUrl==null)
            {
                db.Entry(foodList).State = EntityState.Modified;
                 db.Entry(foodList).Property("imageUrl").IsModified = false;
                // foodList.imageUrl = "https://localhost:44316/wwwroot/" + DateTime.Now.ToString("yyyy-MM-dd") + imageUrl.FileName;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            if (Request.Files.Count == 0)
            {
               
                //判断数量
                 return Content("<script>alert('上传失败');</script>");
            }
            else
            {
                var file1 = Request.Files[0];
                if (file1.ContentLength == 0)
                {
                    //文件大小大（以字节为单位）为0时，做一些操作
                    return Content("<script>alert('上传失败');</script>");
                }
                else
                {
                    if (file1.ContentLength > 4194304)
                    {
                        return Content("<script>alert('文件过大，不可大于4M');</script>");
                    }
                    File(imageUrl);
                    db.Entry(foodList).State = EntityState.Modified;
                    // db.Entry(foodList).Property("FoodID").IsModified = false;
                    foodList.imageUrl = "https://localhost:44316/wwwroot/" + DateTime.Now.ToString("yyyy-MM-dd") + imageUrl.FileName;
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                    // return View();
                }
            }
        }

        // GET: FoodLists/Delete/5
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

        // POST: FoodLists/Delete/5
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
