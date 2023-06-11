namespace YCompany.Claims.MessagingQueue
{
    public class SQSService : IMessageBroker
    {
        public Task<bool> CheckHealthAsync()
        {
            return Task.FromResult(true);
        }
    }
}