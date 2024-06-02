using Bet.Common.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    [TableName("tournament")]
    public class Tournament : BaseEntity
    {
        [Key]        
        public int Id { get; set; }
        /// <summary>
        /// Tên giải đấu 
        /// </summary>
        [Column]
        [MaxLength(4000)]
        public string? Name { get; set; }
        /// <summary>
        /// Tên đội bóng
        /// </summary>
        [Column]
        public bool IsDelete { get; set; }
    }
}
