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
using HT;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;
using QT;

namespace DouLaiDian前台.Controllers
{
    public class reserve
    {
        [DisplayName("预定日期")]
        public DateTime Time { get; set; }
        [DisplayName("预定手机号")]
        public string Phone { get; set; }
        [DisplayName("桌位")]
        public string TableName { get; set; }
    }
    public class FoodTablesController : Controller
    {
        private MDF_DouLaiDian db = new MDF_DouLaiDian();

        // GET: FoodTables
        public async Task<ActionResult> Index()
        {
            string path = Server.MapPath(string.Format("~/TableTxt/"));
            string fileFullPath = path + DateTime.Now.ToString("yyyy-MM-dd") + ".Table.txt";//预定日期文件
            try
            {
                ViewBag.Grid=(Loadreserves(fileFullPath).OrderByDescending(i => i.Time).ToList());//.OrderBy(i => i.DateOut).Take(1)
            }
            catch
            {
               // ViewBag.Grid = null;
            }
            return View(await db.FoodTable.ToListAsync());//.OrderBy(i => i.DateOut).Take(1)
        }

        public ActionResult IndexTable(DateTime Time)
        {
            try
            {
                if(String.IsNullOrEmpty(Time.ToString()))
                {
                    return Content("<script>alert('请输入时间');window.open('" + Url.Content("~/FoodTables/Index") + "','_self')</script>");
                }
                string path = Server.MapPath(string.Format("~/TableTxt/"));
                string fileFullPath = path + Time.ToString("yyyy-MM-dd") + ".Table.txt";//预定日期文件
                return View(Loadreserves(fileFullPath).OrderBy(i=>i.Time).ToList());//.OrderBy(i => i.DateOut).Take(1)
            }
            catch
            {
                return Content("<script>alert('暂未有人预定');window.open('" + Url.Content("~/FoodTables/Index") + "','_self')</script>");

                //return View(db.FoodTable.ToList());//.OrderBy(i => i.DateOut).Take(1)
            }
        }
        [HttpPost]
        public async Task<ActionResult> Index(string TableName)
        {
            if (String.IsNullOrEmpty(TableName))
            {
                return View(await db.FoodTable.ToListAsync());
            }
            else
                return View(await db.FoodTable.Where(i => i.TableName.Contains(TableName)).ToListAsync());
        }
        private void WriteTextLog(string strMessage, DateTime time, string Table)
        {
            string path = Server.MapPath(string.Format("~/TableTxt/"));
            // AppDomain.CurrentDomain.BaseDirectory + @"Log\";//创建公有登录文件夹
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);//判断路径存在性
                                                // DateTime time = DateTime.Now;
            string fileFullPath = path + time.ToString("yyyy-MM-dd") + ".Table.txt";//预定日期文件
            StringBuilder str = new StringBuilder();//定义字符串数据集

            str.Append(time + "|" + strMessage + "|" + Table);//定义书写内容
            StreamWriter sw;
            if (!System.IO.File.Exists(fileFullPath))
            {
                sw = System.IO.File.CreateText(fileFullPath);//不存在创建文件
            }
            else
            {
                sw = System.IO.File.AppendText(fileFullPath);//存在打开追加数据
            }
            sw.WriteLine(str.ToString());//追加响应数据
            sw.Close();//数据流关闭
        }
        //通过时间获取到文件路径
        public List<reserve> Loadreserves(string pat)
        {
            List<reserve> rese = new List<reserve>();
            string path = pat;
            string[] array;
            foreach (var item in System.IO.File.ReadAllLines(path))
            {
                //reserve area = new reserve();
                array = item.Split('|');
                reserve area = new reserve
                {
                    Time = Convert.ToDateTime(array[0]),
                    Phone = array[1],
                    TableName = array[2]
                };
                //string a = item.Replace("|"," ");
                //string date = Regex.Split(item, "|", RegexOptions.IgnoreCase)[0];
                //area.Time = Convert.ToDateTime(date); //利用正则表达式进行空域字符屏蔽
                //area.Phone = Regex.Split(item, "|", RegexOptions.IgnoreCase)[1]; //
                //area.TableName = Regex.Split(item, "|", RegexOptions.IgnoreCase)[2]; //
                rese.Add(area);
            }
            return rese;
        }
        // GET: FoodTables/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    FoodTable foodTable = await db.FoodTable.FindAsync(id);
        //    if (foodTable == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(foodTable);
        //}

        // GET: FoodTables/Create
        public ActionResult Create()
        {

            return View();
        }

        public ActionResult CreateTable(string Tablename)
        {
            ViewBag.Tab = Tablename;
            return View();
        }
        [HttpPost]
        public ActionResult CreateTable(string TableName, DateTime Time, string Phone, string Price)
        {
            if (String.IsNullOrWhiteSpace(TableName))
            {
                return View();
            }
            if (String.IsNullOrWhiteSpace(Time.ToString()))
            {
                return View();
            }
            if (String.IsNullOrWhiteSpace(Phone))
            {
                return View();
            }
            if (String.IsNullOrWhiteSpace(Price))
            {
                return View();
            }
            WriteTextLog(Phone, Time, TableName);
            Order order = new Order
            {
                ISOut = false,
                phone = Phone,
                Date = DateTime.Now,
                TotalParse = Convert.ToDouble(Price)
            };
            db.Order.Add(order);
            db.SaveChanges();
            int id = order.OrderID;
            OrderList list = new OrderList();
            list.OrderID = id;
            list.price = Convert.ToDouble(Price);
            list.num = 1;
            list.foodname = "预定房金";
            db.OrderList.Add(list);
            db.SaveChanges();
            return Content("<script>alert('预定成功,请支付预定款项');window.open('" + Url.Content("~/orders/Index") + "','_self')</script>");
        }

        // POST: FoodTables/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TableName")] FoodTable foodTable)
        {
            if (ModelState.IsValid)
            {
                foodTable.TableState = "空闲";
                foodTable.DateOut = DateTime.Now;
                db.FoodTable.Add(foodTable);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(foodTable);
        }

        // GET: FoodTables/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            //DouLaiDian.DESEncrypt.DesDecrypt(id);
            if (id == null)
            {
                return View();
            }
            FoodTable foodTable = await db.FoodTable.FindAsync(id);
            if (foodTable.TableState == "空闲")
            {
                foodTable.TableState = "预定";
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            if (foodTable.TableState == "占用")
            {
                foodTable.TableState = "空闲";
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            if (foodTable.TableState == "预定")
            {
                foodTable.TableState = "空闲";
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // POST: FoodTables/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性。有关
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。

        public async Task<ActionResult> EditZY(int? id)
        {
            FoodTable foodTable = await db.FoodTable.FindAsync(id);
            // db.Entry(foodTable).State = EntityState.Modified;
            foodTable.TableState = "占用";
            await db.SaveChangesAsync();
            return RedirectToAction("Index");


        }

        // GET: FoodTables/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodTable foodTable = await db.FoodTable.FindAsync(id);
            if (foodTable == null)
            {
                return HttpNotFound();
            }
            return View(foodTable);
        }

        // POST: FoodTables/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int? id)
        {
            FoodTable foodTable = await db.FoodTable.FindAsync(id);
            db.FoodTable.Remove(foodTable);
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
