namespace YCompany.Payments.Domain.Exceptions
{
    public abstract class PaymentNotFoundException : NotFoundException
    {
        public PaymentNotFoundException(string message) : base(message)
        {
        }
    }
}
