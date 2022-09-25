using ShippingSystem.Data;
using ShippingSystem.Interfaces;
using ShippingSystem.Models;

namespace ShippingSystem.Repository
{
    public class GovernorateRepository : Repository<Governorate>, IGovernorateRepository
    {
        private readonly ApplicationDbContext _db;

        public GovernorateRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
