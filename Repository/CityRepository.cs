using ShippingSystem.Data;
using ShippingSystem.Interfaces;
using ShippingSystem.Models;

namespace ShippingSystem.Repository
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly ApplicationDbContext _db;

        public CityRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public float GetCityCost(int cityId)
        {
            return (float)_db.City.FirstOrDefault(c => c.Id == cityId).NormalCostShipping;
        }
    }
}
