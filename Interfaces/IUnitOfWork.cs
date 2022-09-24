namespace ShippingSystem.Interfaces
{
    public interface IUnitOfWork
    {
        //ICoverTypeRepository CoverType { get; }
        IOrderRepository Order { get; }
        IProductRepository Product { get; }
        IShippingTypesRepository ShippingTypes { get; }
        IPaymentTypesRepository PaymentTypes { get; }
        void Save();
    }
}
