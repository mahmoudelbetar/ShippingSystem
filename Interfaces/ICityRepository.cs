using ShippingSystem.Models;

namespace ShippingSystem.Interfaces
{
    public interface ICityRepository : IRepository<City>
    {
        float GetCityCost(int cityId);
    }
}
