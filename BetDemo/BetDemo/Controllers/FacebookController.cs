using Bet.Common;
using Bet.Common.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class FacebookController : ControllerBase
    {
        public FacebookController() { }

        [AllowAnonymous]
        [HttpPost]
        [Route("auth-callback")]
        public IActionResult HandleAuthCallback()
        {
            ServiceResult rs = new ServiceResult();
            try
            {
                return Ok(null);
            }
            catch (Exception ex)
            {
                LogCustom.LogError(ex.Message);
            }
            return Ok(null);
        }
    }
}
