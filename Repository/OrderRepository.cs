using ShippingSystem.Data;
using ShippingSystem.Interfaces;
using ShippingSystem.Models;

namespace ShippingSystem.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public Order? GetLastOrder()
        {
            return _db.Order.OrderBy(o => o.Id).LastOrDefault();
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Order order)
        {
            _db.Order.Update(order);
            _db.SaveChanges();
        }
    }
}
