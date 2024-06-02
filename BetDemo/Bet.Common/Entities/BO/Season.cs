using Bet.Common.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bet.Common.Entities.BO
{
    [TableName("season")]
    public class Season : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Tên mùa giải
        /// </summary>
        [Column]
        public string? Name { get; set; }
        /// <summary>
        /// Tổng số vòng đấu
        /// </summary>
        [Column]
        public int TotalRound { get; set; }
        /// <summary>
        /// Thuộc giải đấu
        /// </summary>
        [Column]
        public int TournamentId { get; set; }
        /// <summary>
        /// Đã xóa
        /// </summary>
        [Column]
        public bool IsDelete { get; set; }
    }
}
