using ShippingSystem.Data;
using ShippingSystem.Interfaces;
using ShippingSystem.Models;

namespace ShippingSystem.Repository
{
    public class PaymentTypesRepository : Repository<PaymentType>, IPaymentTypesRepository
    {
        private readonly ApplicationDbContext _db;

        public PaymentTypesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
