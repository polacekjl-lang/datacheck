using DataCheck.Core;
using Microsoft.AspNetCore.Mvc;

namespace DataCheck.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NalezyController : ControllerBase
    {
        [HttpGet]
        public List<Nalez> VratVse()
        {
            var repository = new NalezRepository(DbNastaveni.ConnectionString);
            return repository.NactiVsechny();
        }
    }
}