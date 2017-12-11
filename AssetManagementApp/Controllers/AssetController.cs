using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManagementApp.Entities;
using AssetManagementApp.Repository;
using System.Data;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AssetManagementApp.Controllers
{
    public class AssetController : Controller
    {
        //private AssetManagementDEVContext db = new AssetManagementDEVContext();
        IAssetRepository repo;

        public AssetController(IAssetRepository assetRepository)
        {
            repo = assetRepository;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        public JsonResult GetAllAssetsInDB()
        {
            List<Asset> employees = repo.GetAllAsset().ToList();
            return Json(employees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Asset newAsset)
        {
            if (ModelState.IsValid)
            {
                newAsset = repo.CreateAsset(newAsset);

                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var assetToEdit = repo.GetAsset(id);
            return View(assetToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Asset ass)
        {
            if (ModelState.IsValid)
            {
                ass = repo.EditAsset(ass);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            Asset asset = repo.GetAsset(id);
            if (asset == null)
            {
                return RedirectToAction("Error");
            }
            return View(asset);
        }

        public IActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Asset asset = repo.GetAsset(id);
            if (asset == null)
            {
                return RedirectToAction("Error");
            }
            return View(asset);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                repo.DeleteAsset(id);
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}
