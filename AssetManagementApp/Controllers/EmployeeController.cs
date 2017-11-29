using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AssetManagementApp.Entities;
using System.Data;
using AssetManagementApp.Repository;

namespace AssetManagementApp.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepository repo;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            repo = employeeRepository;
        }
        
        public IActionResult Index()
        {
            return View(repo.GetAllEmployees());
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
                //Employee employee = new Employee();
                //employee.Name = newEmployee.Name;
                //employee.EmployeeNumber = newEmployee.EmployeeNumber;

                newEmployee = repo.CreateEmployee(newEmployee);

                return RedirectToAction("Index");                
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            var employeeToEdit = repo.GetEmployee(id);
            return View(employeeToEdit);
        }

        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            if (ModelState.IsValid)
            {
                emp = repo.EditEmployee(emp);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Details(int id)
        {
            Employee employee = repo.GetEmployee(id);
            if(employee == null)
            {
                return RedirectToAction("Error");
            }
            return View(employee);
        }

        public IActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Employee employee = repo.GetEmployee(id);
            if (employee == null)
            {
                return RedirectToAction("Error");
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            try
            {
                repo.DeleteEmployee(id);
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