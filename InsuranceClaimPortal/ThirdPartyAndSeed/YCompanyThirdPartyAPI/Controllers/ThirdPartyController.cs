using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YCompanyPaymentsAPI.Data;
using YCompanyPaymentsAPI.Models;

namespace YCompanyThirdPartyAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class ThirdPartyController : ControllerBase
    {
        private readonly InsuranceContext _context;

        public ThirdPartyController(InsuranceContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Policy> Get()
        {
            List<Policy> result = _context.Policies.ToList();
            return result;
        }
    }
}