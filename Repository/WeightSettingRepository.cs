using ShippingSystem.Data;
using ShippingSystem.Interfaces;
using ShippingSystem.Models;

namespace ShippingSystem.Repository
{
    public class WeightSettingRepository : Repository<WeightSettings>, IWeightSettingRepository
    {
        private readonly ApplicationDbContext _db;

        public WeightSettingRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public float DefaultCost()
        {
            return (float)_db.WeightSetting.FirstOrDefault().Cost;
        }

        public float DefaultWeight()
        {
            return (float)_db.WeightSetting.FirstOrDefault().Weight;
        }

        public float ExtraCost()
        {
            return (float)_db.WeightSetting.FirstOrDefault().ExtraWeightCost;
        }
    }
}
