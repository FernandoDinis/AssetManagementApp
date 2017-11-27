using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManagementApp.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagementApp.Controllers
{
    public class AssetController1 : Controller
    {
        private AssetManagementDEVContext db = new AssetManagementDEVContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            var assets = db.Asset.ToList();
            return View(assets);
        }


    }
}
