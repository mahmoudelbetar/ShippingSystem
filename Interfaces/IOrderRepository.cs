using ShippingSystem.Models;

namespace ShippingSystem.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        void Update(Order order);
        void Save();
        Order? GetLastOrder();

        IEnumerable<CountStatus> CountEachOrderStatus();
    }
}
