namespace YCompany.Reporting.Domain.Exceptions
{
    internal class ReportNotFoundException : NotFoundException
    {
        public ReportNotFoundException(string message) : base(message)
        {
        }
    }
}
