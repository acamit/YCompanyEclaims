namespace YCompany.Vendor.Domain.InfrastructureInterfaces
{
    public interface IVendorStorageService
    {
        Task<bool> CheckHealthAsync();
    }
}
