namespace YCompany.Claims.Domain.Exceptions
{
    public abstract class ClaimNotFoundException : NotFoundException
    {
        protected ClaimNotFoundException(string message) : base(message)
        {
        }
    }
}
