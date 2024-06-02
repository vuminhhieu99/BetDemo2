using Bet.Bussiness.Interfaces;
using Bet.Common.Requests;
using Bet.Common.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BetDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        private IBaseBussiness<T> _baseBussiness;

        public BaseController(IBaseBussiness<T> baseBussiness)
        {
            _baseBussiness = baseBussiness;
        }

        // GET: api/[controller]/All
        [HttpGet("All")]
        [Authorize]
        public async virtual Task<ServiceResult> GetAsync()
        {
            //var name = this._configuration.GetSection("appsettings")["Version"];
            return await _baseBussiness.GetDataAsync();
        }

        // GET api/[controller]/{id}
        // todo...
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ServiceResult> GetByIdAsync(string id)
        {
            return await _baseBussiness.GetByIdAsync(id); 
        }

        [HttpPost("Paging")]
        [Authorize]
        public async Task<ServiceResult> GetAsync(PageRequestBase pageRequestBase)
        {
            return await _baseBussiness.GetDataAsync(pageRequestBase);
        }

        // POST api/[controller]
        [HttpPost]
        [Authorize]
        public virtual async Task<ServiceResult> PostAsync([FromBody] T entity)
        {
            var result = await _baseBussiness.InsertAsync(entity);
            return result;
        }

        // PUT api/[controller]
        [HttpPut("")]
        [Authorize]
        public virtual async Task<ServiceResult> PutPostAsync([FromBody] T entity)
        {
            var result = await _baseBussiness.UpdateAsync(entity);
            return result;
        }

        // DELETE api/[controller]/{id}
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ServiceResult> DeleteAsync(string id)
        {
            return await _baseBussiness.DeleteAsync(id);
        }
    }
}
