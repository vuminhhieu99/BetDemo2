using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common
{
    public interface ISessionData
    {
        public void contructorHttpContextAccessor(IHttpContextAccessor accessor);

        public ClaimsPrincipal CurrentPrincipal { get; }

        public IHeaderDictionary Header { get; }

        public int? UserId { get; }

        public string UserName { get; }

        public string LayoutCode { get; }

        public string? Token { get; }
    }
}
