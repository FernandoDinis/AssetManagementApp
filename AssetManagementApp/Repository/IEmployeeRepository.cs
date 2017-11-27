using AssetManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementApp.Repository
{
    public interface IEmployeeRepository
    {
        Employee CreateEmployee(Employee newEmployee);        

        Employee GetEmployee(int id);

        ICollection<Employee> GetAllEmployees();
       
        Employee EditEmployee(Employee emp);

        bool DeleteEmployee(int id);
    }
}
