namespace YCompany.Claims.MessagingQueue
{
    public interface IMessageBroker
    {
        Task<bool> CheckHealthAsync();
    }
}
