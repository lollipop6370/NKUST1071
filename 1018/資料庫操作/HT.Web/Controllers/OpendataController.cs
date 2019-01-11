using HTCore.Database;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HT.Web.Controllers
{
    public class OpenDataController : Controller
    {
        
            public OpenDataDbContext DbContext
            {
                get
                {
                    return this.db;
                }
            }
            private OpenDataDbContext db;
            public OpenDataController()
            {
                db = new OpenDataDbContext();
            }
            public IActionResult Index()
            {
                List<HTCore.Models.OpenData> models = db.OpenData.ToList();

                return View(models);
            }

            public IActionResult Detail(int id, string name)
            {

                var model = db.OpenData.Find(id);
                return View(model);
            }
            [HttpGet]
            public IActionResult Edit(int id)
            {
                var model = db.OpenData.Find(id);
                return View(model);
            }
            [HttpPost]
            public IActionResult Edit(HTCore.Models.OpenData model)
            {

                var upDateModel = db.OpenData.Find(model.id);
                upDateModel.園區別 = model.園區別;
                upDateModel.廠商名稱 = model.廠商名稱;
                upDateModel.地址 = model.地址;
                db.SaveChanges();
                var updated = db.OpenData.Find(model.id);
                return View(updated);
            }
        }
    }
