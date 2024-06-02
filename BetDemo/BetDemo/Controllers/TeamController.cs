using Bet.Bussiness.Interfaces;
using Bet.Common.Entities.BO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace BetDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : BaseController<Team>
    {
        public TeamController(IBaseBussiness<Team> baseBussiness) : base(baseBussiness)
        {
            ;
        }
    }
}
