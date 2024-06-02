using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Bussiness.Interfaces
{
    public interface IAttachmentBussiness
    {
        public Task<byte[]> GetImage(string fileName);
    }
}
