using ShippingSystem.Data;
using ShippingSystem.Interfaces;
using ShippingSystem.Models;

namespace ShippingSystem.Repository
{
    public class OrderTypesRepository : Repository<OrderType>, IOrderTypesRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderTypesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
