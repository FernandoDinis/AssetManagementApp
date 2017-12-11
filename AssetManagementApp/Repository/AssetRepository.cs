using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagementApp.Entities;

namespace AssetManagementApp.Repository
{
    public class AssetRepository : IAssetRepository
    {
        public AssetManagementDEVContext db;

        public AssetRepository(AssetManagementDEVContext dbContext)
        {
            db = dbContext;
        }

        public Asset CreateAsset(Asset newAsset)
        {
            db.Asset.Add(newAsset);
            db.SaveChanges();
            return newAsset;
        }

        public bool DeleteAsset(int id)
        {
            Asset asset = db.Asset.Find(id);
            db.Asset.Remove(asset);
            db.SaveChanges();
            return db.Asset.FirstOrDefault(x => x.Id == id) == null;
        }

        public Asset EditAsset(Asset ass)
        {
            var asset = db.Asset.Where(x => x.Id == ass.Id).SingleOrDefault();
            asset.Name = ass.Name;
            asset.Description = ass.Description;
            db.SaveChanges();
            return ass;
        }

        public ICollection<Asset> GetAllAsset()
        {
            return db.Asset.ToList();
        }

        public Asset GetAsset(int id)
        {
            return db.Asset.Find(id);
        }
    }
}
