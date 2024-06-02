using Bet.Common.Entities.BO;
using Bet.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Data.Version1
{
    public class TournamentData : BaseData<Tournament>, ITournamentData
    {

        IUnitOfWork _unitOfWork;
        public TournamentData(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
