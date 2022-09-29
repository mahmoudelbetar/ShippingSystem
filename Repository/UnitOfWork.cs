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
            OrderStatus = new OrderStatusRepository(_db);
            OrderTypes = new OrderTypesRepository(_db);
            Governorates = new GovernorateRepository(_db);
            Cities = new CityRepository(_db);
            Branches = new BranchRepository(_db);
            WeightSettings = new WeightSettingRepository(_db);
        }

        public IOrderRepository Order { get; private set; }
        public IProductRepository Product { get; private set; }
        public IShippingTypesRepository ShippingTypes { get; private set; }
        public IPaymentTypesRepository PaymentTypes { get; private set; }
        public IOrderStatusRepository OrderStatus { get; private set; }
        public IOrderTypesRepository OrderTypes { get; private set; }
        public IGovernorateRepository Governorates { get; private set; }
        public ICityRepository Cities { get; private set; }
        public IBranchRepository Branches { get; private set; }
        public IWeightSettingRepository WeightSettings { get; private set; }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
