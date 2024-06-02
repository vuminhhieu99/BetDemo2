using Bet.Common.Entities.BO;
using Bet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bet.Bussiness.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Bet.Bussiness.Version1
{
    public partial class TournamentBussiness : BaseBussiness<Tournament>, ITournamentBussiness
    {
        private IBaseData<Tournament> _baseData;

        public TournamentBussiness(IBaseData<Tournament> baseData) : base(baseData)
        {
            _baseData = baseData;
        }
    }
}
