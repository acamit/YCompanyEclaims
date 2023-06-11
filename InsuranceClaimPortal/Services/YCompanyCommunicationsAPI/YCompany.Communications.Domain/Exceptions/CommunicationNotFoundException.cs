namespace YCompany.Communications.Domain.Exceptions
{
    public class CommunicationNotFoundException : NotFoundException
    {
        public CommunicationNotFoundException(string message) : base(message)
        {
        }
    }
}
