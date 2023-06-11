using Microsoft.Extensions.Logging;

namespace YCompany.Claims.Logging.Entities
{
    public abstract class LogEntityBase
    {
        public abstract EventId Event { get; set; }
    }
}