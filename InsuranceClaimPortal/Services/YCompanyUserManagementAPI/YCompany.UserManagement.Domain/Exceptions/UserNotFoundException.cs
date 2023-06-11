namespace YCompany.UserManagement.Domain.Exceptions
{
    public abstract class UserNotFoundException : NotFoundException
    {
        protected UserNotFoundException(string message) : base(message)
        {
        }
    }
}
