using AssetManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementApp.Repository
{

    public class EmployeeRepository:IEmployeeRepository
    {
        private AssetManagementDEVContext db = new AssetManagementDEVContext();

        public Employee CreateEmployee (Employee newEmployee)
        {
            db.Employee.Add(newEmployee);
            db.SaveChanges();
            return newEmployee;
        }

        public Employee GetEmployee(int id)
        {
            return db.Employee.Find(id);
        }

        public ICollection<Employee> GetAllEmployees()
        {            
            return db.Employee.ToList();
        }

        public Employee EditEmployee (Employee emp)
        {
            var employee = db.Employee.Where(x => x.Id == emp.Id).SingleOrDefault();
            employee.Name = emp.Name;
            employee.EmployeeNumber = emp.EmployeeNumber;
            db.SaveChanges();
            return emp;
        }

        public bool DeleteEmployee(int id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
            db.SaveChanges();
            return db.Employee.FirstOrDefault(x => x.Id == id) == null;
        }
    }

}
