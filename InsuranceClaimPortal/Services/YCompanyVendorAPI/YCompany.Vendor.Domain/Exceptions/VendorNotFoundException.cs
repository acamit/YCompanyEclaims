namespace YCompany.Vendor.Domain.Exceptions
{
    public class VendorNotFoundException : NotFoundException
    {
        public VendorNotFoundException(string message) : base(message)
        {
        }
    }
}
