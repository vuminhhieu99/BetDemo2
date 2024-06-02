using Bet.Bussiness.Interfaces;
using Bet.Common.Entities.BO;
using Bet.Common.Resources;
using Bet.Common.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace BetDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TournamentController : BaseController<Tournament>
    {
        private ITournamentBussiness _tournamentBussiness;

        private readonly IStringLocalizer<TournamentResource> _localizer;
        public TournamentController(ITournamentBussiness tournamentBussiness, IBaseBussiness<Tournament> baseBussiness, IStringLocalizer<TournamentResource> localizer) : base(baseBussiness)
        {
            this._tournamentBussiness = tournamentBussiness;
            this._localizer = localizer;
        }

        // GET: api/[controller]/All
        [HttpGet("All")]
        [Authorize]
        public override async Task<ServiceResult> GetAsync()
        {
            var testLocalizer = _localizer["Stringa"].Value;
            //var name = this._configuration.GetSection("appsettings")["Version"];
            return await base.GetAsync();
        }
    }
}
