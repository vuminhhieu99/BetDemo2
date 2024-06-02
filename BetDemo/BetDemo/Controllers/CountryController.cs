using Bet.Bussiness.Interfaces;
using Bet.Common.Entities.BO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : BaseController<Country>
    {
        public CountryController(IBaseBussiness<Country> baseBussiness) : base(baseBussiness)
        {
        }
    }
}
