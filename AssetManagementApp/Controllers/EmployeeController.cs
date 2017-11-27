using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManagementApp.Entities;

namespace AssetManagementApp.Controllers
{
    public class EmployeeController : Controller
    {
        private AssetManagementDEVContext db = new AssetManagementDEVContext();
        
        public IActionResult Index()
        {
            var employees = db.Employee.ToList();
            return View(employees);
        }

        public IActionResult GetEmployees()
        {
            var employee = db.Employee.ToList();

            return Json(employee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee newEmployee)
        {
            if (ModelState.IsValid)
            {
                Employee employee = new Employee();
                employee.Name = newEmployee.Name;
                employee.EmployeeNumber = newEmployee.EmployeeNumber;
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");                
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            var employeeToEdit = db.Employee.Where(x => x.Id == id).SingleOrDefault();
            return View(employeeToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                //Employee employee = new Employee();
                //employee.Id = emp.Id;
                //employee.Name = emp.Name;
                //employee.EmployeeNumber = emp.EmployeeNumber;
                //db.Employee.Add(employee);
                db.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Modified; 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}