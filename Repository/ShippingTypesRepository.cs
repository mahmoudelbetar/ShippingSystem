using ShippingSystem.Data;
using ShippingSystem.Interfaces;
using ShippingSystem.Models;

namespace ShippingSystem.Repository
{
    public class ShippingTypesRepository : Repository<ShippingType>, IShippingTypesRepository
    {
        private readonly ApplicationDbContext _db;

        public ShippingTypesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
