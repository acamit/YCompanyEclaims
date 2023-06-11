namespace YCompany.HealthChecks.Interfaces
{
    public interface IStorageHealth
    {
        Task<bool> CheckHealthAsync();
    }
}
