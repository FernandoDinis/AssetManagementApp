using AssetManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagementApp.Repository
{
    public interface IAssetRepository
    {
        Asset CreateAsset(Asset newAsset);

        Asset GetAsset(int id);

        ICollection<Asset> GetAllAsset();

        Asset EditAsset(Asset ass);

        bool DeleteAsset(int id);
    }
}
