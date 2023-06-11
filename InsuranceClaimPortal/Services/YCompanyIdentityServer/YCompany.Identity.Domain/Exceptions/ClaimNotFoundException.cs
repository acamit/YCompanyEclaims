namespace YCompany.Identity.Domain.Exceptions
{
    public abstract class ClaimNotFoundException : NotFoundException
    {
        protected ClaimNotFoundException(string message) : base(message)
        {
        }
    }
}
