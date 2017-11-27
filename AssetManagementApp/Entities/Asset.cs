using System;
using System.Collections.Generic;

namespace AssetManagementApp.Entities
{
    public partial class Asset
    {
        public Asset()
        {
            Document = new HashSet<Document>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<Document> Document { get; set; }
    }
}
