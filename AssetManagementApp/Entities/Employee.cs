using System;
using System.Collections.Generic;

namespace AssetManagementApp.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            Document = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeNumber { get; set; }

        public ICollection<Document> Document { get; set; }
    }
}
