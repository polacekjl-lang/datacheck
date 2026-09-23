using DataCheck.Core;
using Microsoft.AspNetCore.Mvc;

namespace DataCheck.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjektyController : ControllerBase
    {
        [HttpGet]
        public List<Subjekt> VratVse()
        {
            var repository = new SubjektRepository(DbNastaveni.ConnectionString);
            return repository.NactiVsechny();
        }
    }
}