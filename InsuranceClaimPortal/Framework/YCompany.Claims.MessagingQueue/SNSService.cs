namespace YCompany.Claims.MessagingQueue
{
    internal class SNSService : IMessageBroker
    {
        public Task<bool> CheckHealthAsync()
        {
            return Task.FromResult(true);
        }
    }
}
