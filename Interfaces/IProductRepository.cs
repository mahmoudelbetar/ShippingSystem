using ShippingSystem.Models;

namespace ShippingSystem.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product product);
        void Save();
    }
}
