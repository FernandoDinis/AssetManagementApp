using System;
using System.Collections.Generic;

namespace AssetManagementApp.Entities
{
    public partial class Status
    {
        public Status()
        {
            Document = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Label { get; set; }

        public ICollection<Document> Document { get; set; }
    }
}
