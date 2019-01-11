using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YC.Web.Controllers
{
    public class OpenDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}