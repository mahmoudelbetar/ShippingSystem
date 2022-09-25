using ShippingSystem.Data;
using ShippingSystem.Interfaces;
using ShippingSystem.Models;

namespace ShippingSystem.Repository
{
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        private readonly ApplicationDbContext _db;

        public BranchRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
