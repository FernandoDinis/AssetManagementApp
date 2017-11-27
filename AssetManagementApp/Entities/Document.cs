using System;
using System.Collections.Generic;

namespace AssetManagementApp.Entities
{
    public partial class Document
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime LastUpdate { get; set; }
        public int EmployeeId { get; set; }
        public int AssetId { get; set; }
        public int StatusId { get; set; }

        public Asset Asset { get; set; }
        public Employee Employee { get; set; }
        public Status Status { get; set; }
    }
}
