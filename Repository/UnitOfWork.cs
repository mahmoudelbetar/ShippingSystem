using ShippingSystem.Data;
using ShippingSystem.Interfaces;
using ShippingSystem.Models;

namespace ShippingSystem.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Order = new OrderRepository(_db);
            Product = new ProductRepository(_db);
            ShippingTypes = new ShippingTypesRepository(_db);
            PaymentTypes = new PaymentTypesRepository(_db);
        }

        public IOrderRepository Order { get; private set; }
        public IProductRepository Product { get; private set; }
        public IShippingTypesRepository ShippingTypes { get; private set; }
        public IPaymentTypesRepository PaymentTypes { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
