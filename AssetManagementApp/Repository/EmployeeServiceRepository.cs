using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagementApp.Entities;

namespace AssetManagementApp.Repository
{
    //Go for example to an API or another DB...
    public class EmployeeServiceRepository : IEmployeeRepository
    {
        public Employee CreateEmployee(Employee newEmployee)
        {
            throw new NotImplementedException();
        }

        public bool DeleteEmployee(int id)
        {
            throw new NotImplementedException();
        }

        public Employee EditEmployee(Employee emp)
        {
            throw new NotImplementedException();
        }

        public ICollection<Employee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int id)
        {
            throw new NotImplementedException();
        }
    }
}
