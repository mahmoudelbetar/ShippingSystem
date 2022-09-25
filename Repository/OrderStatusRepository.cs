using ShippingSystem.Data;
using ShippingSystem.Interfaces;
using ShippingSystem.Models;

namespace ShippingSystem.Repository
{
    public class OrderStatusRepository : Repository<OrderStatus>, IOrderStatusRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderStatusRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
