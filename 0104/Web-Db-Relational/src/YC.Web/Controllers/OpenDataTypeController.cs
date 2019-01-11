using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YC.Database;

namespace YC.Web.Controllers
{
    public class OpenDataTypeController : Controller
    {
        public OpenDataTypeController()
        {
            DbContext = new OpenDataDbContext();
        }
        public OpenDataDbContext DbContext { get; set; }
        public IActionResult Index()
        {
            return View();
        }
        //public IActionResult Import()
        //{
        //    var groupings = DbContext.OpenData
        //        .GroupBy(x => x.服務分類, y => y)
        //        .ToList();

        //    groupings.ForEach(group =>
        //    {
        //        var key = group.Key;
        //        YC.Models.OpenDataType type = new YC.Models.OpenDataType
        //        {
        //            Name = key
        //        };

        //        DbContext.OpenDataType.Add(type);

        //    });
        //    DbContext.SaveChanges();

        //    return Content("Done");
        //}
        public IActionResult ManagerRelation()
        {
            var types = DbContext.OpenDataType.ToList();

            DbContext.OpenData.ToList().ForEach(item =>
            {
                var type=types.Single(x => x.Name == item.服務分類);
                item.OpenDataType = type;
                item.OpenDataTypeId = type.Id;
            });

            DbContext.SaveChanges();

            return Content("Done");
        }
    }
}