using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YCompany.Claims.Logging
{
    public static class AppLogEvents
    {
		public EventId Create = new(1000, "Created");
		public EventId Read = new(1001, "Read");
		public EventId Update = new(1002, "Updated");
		public EventId Delete = new(1003, "Deleted");
	}
}
