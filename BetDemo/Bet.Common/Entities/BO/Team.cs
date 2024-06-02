using Bet.Common.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    [TableName("team")]
    public class Team : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Tên đội bóng
        /// </summary>
        [Column]
        public string? Name { get; set; }
        /// <summary>
        /// Tên đội bóng
        /// </summary>
        [Column]
        public bool IsDelete { get; set; }
    }
}
