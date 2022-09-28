using ShippingSystem.Models;

namespace ShippingSystem.Interfaces
{
    public interface IOrderStatusRepository : IRepository<OrderStatus>
    {
        void Update(OrderStatus orderStatus);
    }
}
