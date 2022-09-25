namespace ShippingSystem.Interfaces
{
    public interface IUnitOfWork
    {
        //ICoverTypeRepository CoverType { get; }
        IOrderRepository Order { get; }
        IProductRepository Product { get; }
        IShippingTypesRepository ShippingTypes { get; }
        IPaymentTypesRepository PaymentTypes { get; }
        IOrderStatusRepository OrderStatus { get; }
        IOrderTypesRepository OrderTypes { get; }
        IGovernorateRepository Governorates { get; }
        ICityRepository Cities { get; }
        IBranchRepository Branches { get; }
        void Save();
    }
}
