using ShippingSystem.Models;

namespace ShippingSystem.Interfaces
{
    public interface IWeightSettingRepository : IRepository<WeightSettings>
    {
        float ExtraCost();
        float DefaultCost();
        float DefaultWeight();
    }
}
