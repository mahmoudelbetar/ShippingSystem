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

        public void Update(OrderStatus orderStatus)
        {
            _db.OrderStatus.Attach(orderStatus);
            var entry = _db.Entry(orderStatus);
            entry.Property(e => e.CountStatus).IsModified = true;
            _db.SaveChanges();
        }
    }
}
